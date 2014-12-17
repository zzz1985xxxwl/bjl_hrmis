using System;
using System.Configuration;
using System.Data;
using System.IO;
using Microsoft.Office.Interop.Word;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.Train
{
    /// <summary>
    /// 导出培训反馈结果
    /// </summary>
    public class ExportFeedBackResult
    {
        private readonly string _EmployeeExportLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
        private Course _Course;
        private readonly string _ReportTemplateLocation;
        private readonly int _CourseId;
        private readonly GetTrainCourse _GetTrainCourse = new GetTrainCourse();
        private int _AverageCount;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ExportFeedBackResult(int courseId, string reportTemplateLocation)
        {
            _CourseId = courseId;
            _ReportTemplateLocation = reportTemplateLocation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Excute()
        {
            Application app = new Application();
            object nothing = Type.Missing;
            object localPatho = _ReportTemplateLocation;
            Document doc = app.Documents.Add(ref localPatho, ref nothing, ref nothing, ref nothing);
            try
            {
                _Course = _GetTrainCourse.GetTrainCourseByPKID(_CourseId);
                if (!Directory.Exists(_EmployeeExportLocation))
                {
                    Directory.CreateDirectory(_EmployeeExportLocation);
                }
                Table tbTitle = doc.Tables[1];
                tbTitle.Cell(1, 1).Range.Text = _Course.CourseName + "问卷调查汇总";
                Table tb = doc.Tables[3];
                DataTable dt = CreateTableData();
                SetCols(ref tb, dt);
                SetRows(ref tb, dt);
                tb.Columns.Width = 70;
                Table tbSummary = doc.Tables[2];
                tbSummary.Cell(1, 1).Range.Text = "参与本次问卷调查的人数共" + _AverageCount + "人，统计结果是：";
                Table tbRemark = doc.Tables[4];
                tbRemark.Cell(1, 1).Range.Text = "对本次培训的评价、意见和建议：";
                Table tbRemarks = doc.Tables[5];
                string strRemarks=string.Empty;
                foreach (TrainEmployeeFB result in _Course.TrainFBResult.TrainEmployeeFBs)
                {
                    if (!string.IsNullOrEmpty(result.Remark))
                    {
                        strRemarks += !string.IsNullOrEmpty(strRemarks)
                                                               ? "\r" + result.Remark
                                                               : result.Remark;
                    }
                }
                tbRemarks.Cell(1, 1).Range.Text = strRemarks + "\a";

                object fileFormat = WdSaveFormat.wdFormatTemplate97;
                string ffname = _Course.CourseName + "问卷调查汇总.doc";

                ffname = ffname.Replace("/", "").Replace(@"\", "");
                object filename = _EmployeeExportLocation + "\\" + ffname;
                doc.SaveAs(ref filename, ref fileFormat, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                           ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                           ref nothing, ref nothing);
                return filename.ToString();
            }
            catch
            {
                object filename = _EmployeeExportLocation + "\\" + "temp.doc";
                object fileFormat = WdSaveFormat.wdFormatTemplate97;
                doc.SaveAs(ref filename, ref fileFormat, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                           ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                           ref nothing, ref nothing);
                return "";
            }
            finally
            {
                doc.Close(ref nothing, ref nothing, ref nothing);
                app.Quit(ref nothing, ref nothing, ref nothing);
            }
        }

        private DataTable CreateTableData()
        {
            if (_Course.TrainFBResult == null)
            {
                return null;
            }
            DataTable dt = new DataTable();
            //add columns
            dt.Columns.Add("ItemName");
            foreach (FBPaperItem item in _Course.TrainFBResult.FBPaperItem)
            {
                for (int i = 0; i < item.FBQueItems.Split(',').Length; i++)
                {
                    if (!dt.Columns.Contains(item.FBQueItems.Split(',')[i] + " " + item.Worths.Split(',')[i] + "分"))
                    {
                        //add columns
                        dt.Columns.Add(item.FBQueItems.Split(',')[i] + " " + item.Worths.Split(',')[i] + "分");
                    }
                }
            }
            dt.Columns.Add("Average");

            foreach (FBPaperItem item in _Course.TrainFBResult.FBPaperItem)
            {
                DataRow dr = dt.NewRow();
                dr["ItemName"] = item.FBQuestion;
                decimal averageGrade = 0;
                _AverageCount = 0;
                for (int i = 0; i < item.FBQueItems.Split(',').Length; i++)
                {
                    int itemCount = 0;
                    foreach (TrainEmployeeFB result in _Course.TrainFBResult.TrainEmployeeFBs)
                    {
                        foreach (TraineeFBItem resultitem in result.FBItem)
                        {
                            if (resultitem.FBPaperItemId == item.FBPaperItemId
                                && resultitem.Grade.ToString() == item.Worths.Split(',')[i])
                            {
                                averageGrade += resultitem.Grade;
                                itemCount++;
                                _AverageCount++;
                            }
                        }
                    }
                    dr[item.FBQueItems.Split(',')[i] + " " + item.Worths.Split(',')[i] + "分"] = itemCount;
                }
                if (_AverageCount != 0)
                {
                    dr["Average"] = decimal.Round(averageGrade/_AverageCount, 2);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private static void SetCols(ref Table tb, DataTable dt)
        {
            if (dt == null)
            {
                return;
            }
            object col = tb.Columns[2];
            for (int i = 1; i < dt.Columns.Count - 1; i++)
            {
                tb.Columns[i].Select();
                tb.Columns.Add(ref col);
            }
            for (int i = 1; i < dt.Columns.Count - 1; i++)
            {
                tb.Cell(0, i + 1).Range.Text = dt.Columns[i].ColumnName;
            }
        }

        private static void SetRows(ref Table tb, DataTable dt)
        {
            if (dt == null)
            {
                return;
            }
            object row = tb.Rows[2];
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                tb.Rows[i].Select();
                tb.Rows.Add(ref row);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    tb.Cell(i + 2, j + 1).Range.Text = string.IsNullOrEmpty(dt.Rows[i][j].ToString())
                                                           ? "0"
                                                           : dt.Rows[i][j].ToString();
                }
            }
        }
    }
}