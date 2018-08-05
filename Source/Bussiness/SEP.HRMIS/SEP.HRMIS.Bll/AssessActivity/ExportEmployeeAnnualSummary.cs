//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: ExportEmployeeAnnualSummary.cs
// Creater: Xue.wenlong
// CreateDate: 2009-09-03
// Resume: bjl 导出员工年终考评表
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using Microsoft.Office.Interop.Word;

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
    public class ExportEmployeeAnnualSummary
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
        public ExportEmployeeAnnualSummary(int assessActivityId, string employeeTemplateLocation)
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
        //    Microsoft.Office.Interop.Word.Document doc = app.Documents.Add(ref localPatho, ref nothing, ref nothing, ref nothing);
        //    try
        //    {
        //        if (!Directory.Exists(_EmployeeExportLocation))
        //        {
        //            Directory.CreateDirectory(_EmployeeExportLocation);
        //        }
        //        Table tbBase = doc.Tables[1];
        //        Table tbSummary = doc.Tables[2];
        //        InitSubmitInfoIndex();
        //        ExportBasicInfo(ref tbBase);
        //        InitRows(ref tbBase);
        //        ExportItemInfoItem(ref tbBase);
        //        ExportItemInfoSummary(ref tbSummary);
        //        object fileFormat = WdSaveFormat.wdFormatTemplate97;
        //        string ffname = _AssessActivity.ItsEmployee.Account.Name + "员工绩效考评个人工作总结表.doc";
        //        object filename = _EmployeeExportLocation + "\\" + ffname;
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

                document.Tables[0].GetRow(1).GetCell(0).SetText(_AssessActivity.ScopeFrom.ToShortDateString() + "--" +
                                _AssessActivity.ScopeTo.ToShortDateString());
                SetParagraph(document.Tables[1].GetRow(0).GetCell(0), string.Format("部门：{0}", _AssessActivity.ItsEmployee.Account.Dept.DepartmentName));
                SetParagraph(document.Tables[1].GetRow(0).GetCell(1), string.Format("姓名：{0}", _AssessActivity.ItsEmployee.Account.Name));
                SetParagraph(document.Tables[1].GetRow(0).GetCell(2), string.Format("岗位：{0}", _AssessActivity.ItsEmployee.Account.Position.Name));

                InitRows(document.Tables[1]);
                ExportItemInfoItem(document.Tables[1]);
                ExportItemInfoSummary(document.Tables[2]);

                SetParagraph(document.Tables[1].GetRow(_ItemCount + 2).GetCell(0), "本年度总评分ΣCi×λi");
                SetParagraph(document.Tables[1].GetRow(_ItemCount + 3).GetCell(0), "综合评价");
                mergeCellsHorizontal(document.Tables[1], _ItemCount + 2, 1, 2);
                mergeCellsHorizontal(document.Tables[1], _ItemCount + 3, 1, 2);
                string ffname = _AssessActivity.ItsEmployee.Account.Name + "员工绩效考评个人工作总结表.docx";
                string filename = _EmployeeExportLocation + "\\" + ffname;

                MemoryStream ms = new MemoryStream();
                document.Write(ms);
                ms.Flush();
                SaveToFile(ms, filename);
                return filename;
            }
        }


        private void mergeCellsHorizontal(XWPFTable table, int row, int fromCell, int toCell)
        {
            for (int cellIndex = fromCell; cellIndex <= toCell; cellIndex++)
            {
                XWPFTableCell cell = table.GetRow(row).GetCell(cellIndex);
                if (cellIndex == fromCell)
                {
                    // The first merged cell is set with RESTART merge value    
                    cell.GetCTTc().AddNewTcPr().AddNewHMerge().val = ST_Merge.restart;
                }
                else
                {
                    // Cells which join (merge) the first one, are set with CONTINUE    
                    cell.GetCTTc().AddNewTcPr().AddNewHMerge().val = ST_Merge.@continue;
                }
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
            AssessActivityItemList.AddRange(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoIndex].
                                                ItsAssessActivityItems);
            foreach (AssessActivityItem item in AssessActivityItemList)
            {
                if (item.Classfication == ItemClassficationEmnu._360)
                {
                    continue;
                }
                if ((item.AssessTemplateItemType != AssessTemplateItemType.Open))
                {
                    _ItemCount++;
                }
            }

            AddNeedRow(tb, _ItemCount, 5);
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
                AppendParagraph(tb.GetRow(1).GetCell(0), "总评");
                AppendParagraph(tb.GetRow(1).GetCell(0), "");
                AppendParagraph(tb.GetRow(1).GetCell(0), _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoIndex].Comment);
                AppendParagraph(tb.GetRow(1).GetCell(0), "");
            }

        }


        private void ExportItemInfoItem(XWPFTable tb)
        {
            int i = 0;
            decimal totalScore = 0;

            ExportItemByItemType(tb, ref i, ref totalScore);
            _ItemCount = _ItemCount > 0 ? _ItemCount : 1;
            SetParagraph(tb.GetRow(_ItemCount + 3 - 1).GetCell(2 - 1), decimal.Round(totalScore, 2).ToString());
            SetParagraph(tb.GetRow(_ItemCount + 4 - 1).GetCell(2 - 1), ExportAnnualAssessForm.GetAns(totalScore));

        }

        private void ExportItemByItemType(XWPFTable tb, ref int i, ref decimal totalScore)
        {
            List<AssessActivityItem> AssessActivityItemList = new List<AssessActivityItem>();
            AssessActivityItemList.AddRange(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoIndex].
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
                    SetParagraph(tb.GetRow(3 + i - 1).GetCell(1 - 1), item.Question);
                    SetParagraph(tb.GetRow(3 + i - 1).GetCell(2 - 1), string.Format("年度评分＝{0}", item.Grade));
                    SetParagraph(tb.GetRow(3 + i - 1).GetCell(3 - 1), string.Format("{0}%", Convert.ToInt32(item.Weight * 100)));

                    //tb.Cell(5 + i, 2).Range.Text = string.Format("年度评分＝{0}", item.Grade);
                    //tb.Cell(5 + i, 3).Range.Text = string.Format("{0}%", Convert.ToInt32(item.Weight * 100));
                    totalScore += item.Grade * item.Weight;
                    i++;
                }
            }
        }

        /// <summary>
        /// 根据需要在table中增加必要的行
        /// </summary>
        private void AddNeedRow(XWPFTable tb, int count, int rowIndex)
        {
            for (int i = 0; i < count; i++)
            {
                XWPFTableRow m_Row = tb.CreateRow();
            }
            tb.CreateRow();
            tb.CreateRow();
        }
    }
}