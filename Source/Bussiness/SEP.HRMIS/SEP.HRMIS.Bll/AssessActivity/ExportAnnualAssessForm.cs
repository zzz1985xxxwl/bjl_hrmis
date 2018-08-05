//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: ExportAnnualAssessForm.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-11
// Resume: 年度员工绩效考核统计表
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Departments;
using NPOI.XWPF.UserModel;
using NPOI.OpenXmlFormats.Wordprocessing;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class ExportAnnualAssessForm
    {
        private readonly string _EmployeeExportLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
        private static readonly IAssessActivity _DalAssessActivity = new AssessActivityDal();
        private Model.AssessActivity _AssessActivity;
        private readonly string _EmployeeTemplateLocation;
        private readonly int _AssessActivityId;
        private int _SubmitInfoManageIndex;
        private int _SubmitInfoHrIndex;
        private int _ItemCount;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;

        /// <summary>
        /// 
        /// </summary>
        public ExportAnnualAssessForm(int assessActivityId, string employeeTemplateLocation)
        {
            _AssessActivityId = assessActivityId;
            _EmployeeTemplateLocation = employeeTemplateLocation;
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public string Excute()
        //{
        //    PrepareData();
        //    Application app = new Application();
        //    object nothing = Type.Missing;
        //    object localPatho = _EmployeeTemplateLocation;
        //    Document doc = app.Documents.Add(ref localPatho, ref nothing, ref nothing, ref nothing);
        //    try
        //    {
        //        if (!Directory.Exists(_EmployeeExportLocation))
        //        {
        //            Directory.CreateDirectory(_EmployeeExportLocation);
        //        }
        //        Table tb = doc.Tables[1];
        //        InitSubmitInfoIndex();
        //        InitRows(ref tb);
        //        ExportBasicInfo(ref tb);
        //        ExportItemInfo(ref tb);
        //        object fileFormat = WdSaveFormat.wdFormatTemplate97;
        //        object filename = _EmployeeExportLocation + "\\" + _AssessActivity.ItsEmployee.Account.Name +
        //                          "年度员工绩效考核统计表.doc";
        //        doc.SaveAs(ref filename, ref fileFormat, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
        //                   ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
        //                   ref nothing, ref nothing);
        //        return filename.ToString();
        //    }
        //    catch 
        //    {
        //        object filename = _EmployeeExportLocation + "\\" + "temp.doc";
        //        object fileFormat = WdSaveFormat.wdFormatTemplate97;
        //        doc.SaveAs(ref filename, ref fileFormat, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
        //                   ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
        //                   ref nothing, ref nothing);
        //        return "";
        //    }
        //    finally
        //    {
        //        doc.Close(ref nothing, ref nothing, ref nothing);
        //        app.Quit(ref nothing, ref nothing, ref nothing);
        //    }
        //}

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
                ExportDate(document.Tables[0]);
                InitRows(document.Tables[1]);
                ExportBasicInfo(document.Tables[1]);
                ExportItemInfo(document.Tables[1]);
                string ffname = _AssessActivity.ItsEmployee.Account.Name + "年度员工绩效考核统计表.docx";
                string filename = _EmployeeExportLocation + "\\" + ffname;

                MemoryStream ms = new MemoryStream();
                document.Write(ms);
                ms.Flush();
                SaveToFile(ms, filename);
                return filename;
            }
        }

        /// <summary>
        /// 初始化第几个考评是主管考评
        /// </summary>
        private void InitSubmitInfoIndex()
        {
            for (int i = 0; i < _AssessActivity.ItsAssessActivityPaper.SubmitInfoes.Count; i++)
            {
                if (_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].SubmitInfoType.Id ==
                    SubmitInfoType.ManagerAssess.Id)
                {
                    _SubmitInfoManageIndex = i;
                }
                if (_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].SubmitInfoType.Id ==
                   SubmitInfoType.HRAssess.Id)
                {
                    _SubmitInfoHrIndex = i;
                }
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

        private void InitRows(XWPFTable tb)
        {
            List<AssessActivityItem> AssessActivityItemList = new List<AssessActivityItem>();
            AssessActivityItemList.AddRange(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoManageIndex].
                                                ItsAssessActivityItems);
            AssessActivityItemList.AddRange(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoHrIndex].
                                                ItsAssessActivityItems);
            foreach (AssessActivityItem item in AssessActivityItemList)
            {
                if ((item.AssessTemplateItemType != AssessTemplateItemType.Open)
                    && item.Classfication != ItemClassficationEmnu._360)
                {
                    _ItemCount++;
                }
            }
            AddNeedRow(tb, _ItemCount);
        }

        private void ExportDate(XWPFTable tb)
        {
            SetText(tb, 1, 0, string.Format("考评时间段：{0}", _AssessActivity.ScopeFrom.ToShortDateString() + "--" +
                                   _AssessActivity.ScopeTo.ToShortDateString()), ParagraphAlignment.RIGHT);
        }

        private void ExportBasicInfo(XWPFTable tb)
        {
            SetText(tb, 0, 0, string.Format("部门：{0}", _AssessActivity.ItsEmployee.Account.Dept.DepartmentName));
            SetText(tb, 0, 1, string.Format("姓名：{0}", _AssessActivity.ItsEmployee.Account.Name));
            SetText(tb, 0, 2, string.Format("岗位：{0}", _AssessActivity.ItsEmployee.Account.Position.Name));
        }

        private void ExportItemInfo(XWPFTable tb)
        {
            int i = 0;
            decimal totalScore = 0;

            ExportItemByItemType(tb, ref i, ref totalScore);
            _ItemCount = _ItemCount > 0 ? _ItemCount : 1;
            SetText(tb, _ItemCount + 2, 0, "本年度总评分ΣCi×λi");
            SetText(tb, _ItemCount + 2, 1, decimal.Round(totalScore, 2).ToString());
            SetText(tb, _ItemCount + 3, 0, "综合评价");
            SetText(tb, _ItemCount + 3, 1, GetAns(totalScore));
            SetText(tb, _ItemCount + 4, 0, string.Format("考评人评语：{0}", _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoManageIndex].Comment));
            SetText(tb, _ItemCount + 5, 0, string.Format("年度考评人：{0}", _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoManageIndex].FillPerson));

            mergeCellsHorizontal(tb, _ItemCount + 2, 1, 2);
            mergeCellsHorizontal(tb, _ItemCount + 3, 1, 2);
            mergeCellsHorizontal(tb, _ItemCount + 4, 0, 2);
            mergeCellsHorizontal(tb, _ItemCount + 5, 0, 2);
        }

        ///<summary>
        ///</summary>
        ///<param name="totalScore"></param>
        ///<returns></returns>
        public static string GetAns(decimal totalScore)
        {
            string ans = "";
            if (totalScore < 60)
            {
                ans = "未达到要求";
            }
            else if (totalScore >= 60 && totalScore < 80)
            {
                ans = "合格";
            }
            else if (totalScore >= 80 && totalScore < 90)
            {
                ans = "中";
            }
            else if (totalScore >= 90 && totalScore < 100)
            {
                ans = "良好";
            }
            else if (totalScore >= 100)
            {
                ans = "优秀";
            }
            return ans;
        }

        private void ExportItemByItemType(XWPFTable tb, ref int i, ref decimal totalScore)
        {
            List<AssessActivityItem> AssessActivityItemList = new List<AssessActivityItem>();
            AssessActivityItemList.AddRange(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoManageIndex].
                                                ItsAssessActivityItems);
            AssessActivityItemList.AddRange(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoHrIndex].
                                                ItsAssessActivityItems);

            foreach (AssessActivityItem item in AssessActivityItemList)
            {
                if (item.Classfication == ItemClassficationEmnu._360)
                {
                    continue;
                }
                if (item.AssessTemplateItemType == AssessTemplateItemType.Option
                    || item.AssessTemplateItemType == AssessTemplateItemType.Score
                    || item.AssessTemplateItemType == AssessTemplateItemType.Formula)
                {
                    SetText(tb, 2 + i, 0, item.Question);
                    SetText(tb, 2 + i, 1, string.Format("年度评分＝{0}", item.Grade));
                    SetText(tb, 2 + i, 2, string.Format("{0}%", Convert.ToInt32(item.Weight * 100)));

                    totalScore += item.Grade * item.Weight;
                    i++;
                }
            }
        }

        /// <summary>
        /// 根据需要在table中增加必要的行
        /// </summary>
        private void AddNeedRow(XWPFTable tb, int count)
        {
            for (int i = 0; i < count - 1; i++)
            {
                tb.CreateRow();
            }
            tb.CreateRow();
            tb.CreateRow();
            tb.CreateRow();
            tb.CreateRow();
        }

        //private void SetText(XWPFTable tb, int row, int column, string text, ParagraphAlignment paragraphAlignment = ParagraphAlignment.LEFT)
        //{
        //    tb.GetRow(row).GetCell(column).SetText(text);
        //}

        private void SetText(XWPFTable tb, int row, int column, String cellText, ParagraphAlignment paragraphAlignment = ParagraphAlignment.LEFT)
        {
            var cell = tb.GetRow(row).GetCell(column);
            XWPFParagraph p0 = new XWPFParagraph(new CT_P(), cell);
            p0.Alignment = paragraphAlignment;
            XWPFRun r0 = p0.CreateRun();
            r0.FontFamily = "宋体";
            r0.FontSize = 11;
            r0.SetText(cellText);
            cell.SetParagraph(p0);
        }

        private void mergeCellsHorizontal(XWPFTable table, int row, int fromCell, int toCell)
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
    }
}