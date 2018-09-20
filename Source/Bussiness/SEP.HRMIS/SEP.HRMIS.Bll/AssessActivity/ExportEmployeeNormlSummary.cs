//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: ExportEmployeeNormlSummary.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-11
// Resume: bjl 导出员工除年终考评外的其他考评表
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Departments;
using NPOI.XWPF.UserModel;
using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.Model;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class ExportEmployeeNormlSummary
    {
        private readonly string _EmployeeExportLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
        private static readonly IAssessActivity _DalAssessActivity = new AssessActivityDal();
        private Model.AssessActivity _AssessActivity;
        private readonly string _EmployeeTemplateLocation;
        private readonly int _AssessActivityId;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private int _SubmitInfoIndex;
        private int _ItemCount;

        /// <summary>
        /// 
        /// </summary>
        public ExportEmployeeNormlSummary(int assessActivityId, string employeeTemplateLocation)
        {
            _AssessActivityId = assessActivityId;
            _EmployeeTemplateLocation = employeeTemplateLocation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Excute()
        {
            if (!Directory.Exists(_EmployeeExportLocation))
            {
                Directory.CreateDirectory(_EmployeeExportLocation);
            }
            PrepareData();
            using (FileStream stream = File.OpenRead(_EmployeeTemplateLocation))
            {
                var document = new XWPFDocument(stream);

                InitSubmitInfoIndex();
                ExportBasicInfo(document.Tables[0]);
                InitRows(document.Tables[1]);
                ExportItemInfoItem(document.Tables[1]);
                ExportItemInfoSummary(document.Tables[2]);

                string ffname = _AssessActivity.ItsEmployee.Account.Name + "个人" +
                                _AssessActivity.ItsAssessActivityPaper.PaperName +
                                ".docx";

                string filename = _EmployeeExportLocation + "\\" + ffname;

                MemoryStream ms = new MemoryStream();
                document.Write(ms);
                ms.Flush();
                SaveToFile(ms, filename);
                return filename;
            }
        }

        private void PrepareData()
        {
            _AssessActivity = _DalAssessActivity.GetAssessActivityById(_AssessActivityId);
            _AssessActivity.ItsEmployee.Account =
                BllInstance.AccountBllInstance.GetAccountById(_AssessActivity.ItsEmployee.Account.Id);
            _AssessActivity.ItsEmployee.Account.Dept =
                _IDepartmentBll.GetDepartmentById(_AssessActivity.ItsEmployee.Account.Dept.Id, null);
        }


        private void ExportBasicInfo(XWPFTable tb)
        {
            SetText(tb, 0, 0, string.Format("员工个人{0}", _AssessActivity.ItsAssessActivityPaper.PaperName), ParagraphAlignment.CENTER, 16);
            SetText(tb, 1, 1, _AssessActivity.ItsEmployee.Account.Name);
            SetText(tb, 1, 3, _AssessActivity.ItsEmployee.EmployeeDetails.Gender.Name);
            SetText(tb, 1, 5, _AssessActivity.ItsEmployee.EmployeeDetails.Birthday.ToShortDateString());
            SetText(tb, 2, 1, _AssessActivity.ItsEmployee.Account.Dept.DepartmentName);
            SetText(tb, 2, 3, _AssessActivity.ItsEmployee.Account.Position.Name);
            SetText(tb, 2, 5, _AssessActivity.ItsEmployee.Account.Dept.DepartmentLeader.Name);
            SetText(tb, 3, 1, _AssessActivity.ItsEmployee.EmployeeDetails.Education.EducationalBackground.Name);
            SetText(tb, 3, 3, _AssessActivity.ItsEmployee.EmployeeDetails.Work.ComeDate.ToShortDateString());
            SetText(tb, 3, 5, _AssessActivity.ScopeFrom.ToShortDateString() + "--" +
                                       _AssessActivity.ScopeTo.ToShortDateString());
        }
        private void InitRows(XWPFTable tb)
        {
            List<AssessActivityItem> AssessActivityItemList = new List<AssessActivityItem>();
            AssessActivityItemList.AddRange(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoIndex].
                                                ItsAssessActivityItems);

            foreach (AssessActivityItem item in AssessActivityItemList)
            {
                if (item.AssessTemplateItemType == AssessTemplateItemType.Option
                    && item.Classfication != ItemClassficationEmnu._360)
                {
                    _ItemCount++;
                }
            }
            AddNeedRow(tb, _ItemCount);
        }

        /// <summary>
        /// 初始化第几个考评是个人考评
        /// </summary>
        private void InitSubmitInfoIndex()
        {
            for (int i = 0; i < _AssessActivity.ItsAssessActivityPaper.SubmitInfoes.Count; i++)
            {
                if (_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].SubmitInfoType.Id ==
                    SubmitInfoType.MyselfAssess.Id)
                {
                    _SubmitInfoIndex = i;
                }
            }

        }


        private void ExportItemInfoSummary(XWPFTable tb)
        {

            int i = 1;
            StringBuilder sb = new StringBuilder();
            foreach (
                AssessActivityItem item in
                    _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoIndex].ItsAssessActivityItems)
            {
                if (item.Classfication == ItemClassficationEmnu._360)
                {
                    continue;
                }
                if (item.AssessActivityItemType == AssessActivityItemType.PersonalItem &&
                    item.AssessTemplateItemType == AssessTemplateItemType.Open)
                {
                    if (i == 1)
                    {
                        SetParagraph(tb.GetRow(1).GetCell(0), string.Format("{0}、{1}", i, item.Question));
                    }
                    else
                    {
                        AppendParagraph(tb.GetRow(1).GetCell(0), string.Format("{0}、{1}", i, item.Question));
                    }
                    AppendParagraph(tb.GetRow(1).GetCell(0), item.Note);
                    AppendParagraph(tb.GetRow(1).GetCell(0), "");
                    AppendParagraph(tb.GetRow(1).GetCell(0), "");
                    i++;
                }
            }
            if (!string.IsNullOrEmpty(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoIndex].Comment))
            {
                if (i == 1)
                {
                    SetParagraph(tb.GetRow(1).GetCell(0), "总评");
                }
                else
                {
                    AppendParagraph(tb.GetRow(1).GetCell(0), "总评");
                }
                AppendParagraph(tb.GetRow(1).GetCell(0), _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoIndex].Comment);
            }

        }

        private void ExportItemInfoItem(XWPFTable tb)
        {
            int i = 0;
            decimal totalScore = 0;
            List<string> mergework = new List<string>(); //用于合并单元格
            List<AssessActivityItem> AssessActivityItemList = new List<AssessActivityItem>();
            AssessActivityItemList.AddRange(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoIndex].
                                                ItsAssessActivityItems);
            foreach (ItemClassficationEmnu c in AssessUtility.GetAllItemClassficationEmnu())
            {
                if (c == ItemClassficationEmnu._360)
                {
                    continue;
                }
                int j = 0; //重复项数量
                foreach (AssessActivityItem item in AssessActivityItemList)
                {
                    if (item.AssessTemplateItemType == AssessTemplateItemType.Option && item.Classfication == c)
                    {
                        if (j == 0)
                        {
                            SetText(tb, i + 1, 0, string.Format("{0}考评", AssessUtility.ClassficationToString(item.Classfication)));
                        }
                        SetText(tb, i + 1, 1, item.Question);
                        int gradecellindex = item.Grade < 6 ? Convert.ToInt32(item.Grade) : Convert.ToInt32(item.Grade) / 20;
                        SetText(tb, i + 1, gradecellindex + 1, Convert.ToInt32(item.Grade).ToString());
                        SetText(tb, i + 1, 7, string.Format("{0}%", Convert.ToInt32(item.Weight * 100)));
                        totalScore += Convert.ToInt32(item.Grade) * item.Weight;
                        i++;
                        j++;
                    }
                }
                if (j > 1)
                {
                    mergework.Add(string.Format("{0}:{1}", 1 + i - j, i));
                }
            }
            _ItemCount = _ItemCount > 0 ? _ItemCount : 1;
            SetText(tb, i + 1, 1, totalScore.ToString());
            MergeCellsHorizontal(tb, 0, 2, 6);
            SetText(tb, 0, 2, "评定（很差→很好）", ParagraphAlignment.CENTER);
            MergeCellsHorizontal(tb, i + 1, 1, 7);
            SetText(tb, i + 1, 0, "总评分");
            //合并单元格
            for (int k = mergework.Count - 1; k >= 0; k--)
            {
                string[] s = mergework[k].Split(':');
                int start = Convert.ToInt32(s[0]);
                int end = Convert.ToInt32(s[1]);
                MergeCellsVertically(tb, 0, start, end);
            }
        }

        /// <summary>
        /// 根据需要在table中增加必要的行
        /// </summary>
        private void AddNeedRow(XWPFTable tb, int count)
        {
            for (int i = 0; i < count; i++)
            {
                XWPFTableRow m_Row = tb.CreateRow();
                m_Row.SetHeight(380);
            }
        }

        private void SetText(XWPFTable tb, int row, int column, String cellText, ParagraphAlignment paragraphAlignment = ParagraphAlignment.LEFT, int fontSize = 11)
        {
            var cell = tb.GetRow(row).GetCell(column);
            XWPFParagraph p0 = new XWPFParagraph(new CT_P(), cell);
            p0.Alignment = paragraphAlignment;
            XWPFRun r0 = p0.CreateRun();
            r0.FontFamily = "宋体";
            r0.FontSize = fontSize;
            r0.SetBold(true);
            r0.SetText(cellText);
            cell.SetParagraph(p0);
        }

        private void MergeCellsHorizontal(XWPFTable table, int row, int fromCell, int toCell)
        {
            for (int cellIndex = fromCell; cellIndex <= toCell; cellIndex++)
            {
                XWPFTableCell cell = table.GetRow(row).GetCell(cellIndex);
                if (cellIndex == fromCell)
                {
                    cell.GetCTTc().AddNewTcPr().AddNewHMerge().val = ST_Merge.restart;
                }
                else
                {
                    cell.GetCTTc().AddNewTcPr().AddNewHMerge().val = ST_Merge.@continue;
                }
            }
        }

        // word跨行并单元格  
        private void MergeCellsVertically(XWPFTable table, int col, int fromRow, int toRow)
        {
            for (int rowIndex = fromRow; rowIndex <= toRow; rowIndex++)
            {
                XWPFTableCell cell = table.GetRow(rowIndex).GetCell(col);
                if (rowIndex == fromRow)
                {
                    // The first merged cell is set with RESTART merge value    
                    cell.GetCTTc().AddNewTcPr().AddNewVMerge().val = ST_Merge.restart;
                }
                else
                {
                    // Cells which join (merge) the first one, are set with CONTINUE    
                    cell.GetCTTc().AddNewTcPr().AddNewVMerge().val = ST_Merge.@continue;
                }
            }
        }

        private void SaveToFile(MemoryStream ms, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                byte[] data = ms.ToArray();

                fs.Write(data, 0, data.Length);
                fs.Flush();
                data = null;
            }
        }

        private void SetParagraph(XWPFTableCell cell, String cellText)
        {
            XWPFParagraph p0 = new XWPFParagraph(new CT_P(), cell);//创建段落
            p0.Alignment = ParagraphAlignment.LEFT;//居中显示
            XWPFRun r0 = p0.CreateRun();
            //设置字体
            r0.FontFamily = "宋体";
            //设置字体大小
            r0.FontSize = 11;
            //字体是否加粗，这里加粗了
            r0.SetBold(true);
            r0.SetText(cellText);
            cell.SetParagraph(p0);
        }

        private void AppendParagraph(XWPFTableCell cell, String cellText)
        {
            XWPFParagraph paragraph = cell.AddParagraph();
            XWPFRun run = paragraph.CreateRun();
            run.FontFamily = "宋体";
            //设置字体大小
            run.FontSize = 11;
            //字体是否加粗，这里加粗了
            run.SetBold(true);
            run.SetText(cellText);
        }
    }
}