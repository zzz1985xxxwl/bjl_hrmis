//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: ExportNormalForContract.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-10
// Resume: 贝加莱需求，除年终绩效外的所有导出
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
    public class ExportNormalForContract
    {
        private readonly string _EmployeeExportLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
        private static readonly IAssessActivity _DalAssessActivity = new AssessActivityDal();
        private Model.AssessActivity _AssessActivity;
        private readonly string _EmployeeTemplateLocation;
        private readonly int _AssessActivityId;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private int _ItemCount;
        private int _SubmitInfoManageIndex;
        private int _SubmitInfoHrIndex;
        private int _SubmitInfoCEOIndex;

        /// <summary>
        /// 
        /// </summary>
        public ExportNormalForContract(int assessActivityId, string employeeTemplateLocation)
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
                ExportTitleInfo(document.Tables[0]);
                ExportBasicInfo(document.Tables[1]);
                InitSubmitInfoIndex();
                InitRows(document.Tables[2]);
                ExportItemInfo(document.Tables[2]);

                string ffname = _AssessActivity.ItsEmployee.Account.Name +
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

        private void ExportTitleInfo(XWPFTable tb)
        {
            SetText(tb, 0, 0, _AssessActivity.ItsAssessActivityPaper.PaperName, ParagraphAlignment.CENTER, 16, true);
        }

        private void ExportBasicInfo(XWPFTable tb)
        {
            SetText(tb, 0, 1, _AssessActivity.ItsEmployee.Account.Name);
            SetText(tb, 0, 3, _AssessActivity.ItsEmployee.EmployeeDetails.Gender.Name);
            SetText(tb, 0, 5, _AssessActivity.ItsEmployee.EmployeeDetails.Birthday.ToShortDateString());
            SetText(tb, 1, 1, _AssessActivity.ItsEmployee.Account.Dept.DepartmentName);
            SetText(tb, 1, 3, _AssessActivity.ItsEmployee.Account.Position.Name);
            SetText(tb, 1, 5, _AssessActivity.ItsEmployee.Account.Dept.DepartmentLeader.Name);
            SetText(tb, 2, 1, _AssessActivity.ItsEmployee.EmployeeDetails.Education.EducationalBackground.Name);
            SetText(tb, 2, 3, _AssessActivity.ItsEmployee.EmployeeDetails.Work.ComeDate.ToShortDateString());
            SetText(tb, 2, 5, _AssessActivity.ScopeFrom.ToShortDateString() + "--" + _AssessActivity.ScopeTo.ToShortDateString());
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
                if (item.AssessTemplateItemType == AssessTemplateItemType.Option)
                {
                    _ItemCount++;
                }
            }
            AddNeedRow(tb, _ItemCount + 5);
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
                else if (_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].SubmitInfoType.Id ==
                         SubmitInfoType.HRAssess.Id)
                {
                    _SubmitInfoHrIndex = i;
                }
                else if (_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i].SubmitInfoType.Id ==
                    SubmitInfoType.Approve.Id)
                {
                    _SubmitInfoCEOIndex = i;
                }
            }
        }


        private void ExportItemInfo(XWPFTable tb)
        {
            int i = 0;
            decimal totalScore = 0;
            List<string> mergework = new List<string>(); //用于合并单元格
            List<AssessActivityItem> AssessActivityItemList = new List<AssessActivityItem>();
            AssessActivityItemList.AddRange(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoManageIndex].
                                                ItsAssessActivityItems);
            AssessActivityItemList.AddRange(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoHrIndex].
                                                ItsAssessActivityItems);

            MergeCellsHorizontal(tb, 0, 2, 6);

            foreach (ItemClassficationEmnu c in AssessUtility.GetAllItemClassficationEmnu())
            {
                int j = 0; //重复项数量
                foreach (
                    AssessActivityItem item in AssessActivityItemList)
                {
                    if (item.AssessTemplateItemType == AssessTemplateItemType.Option && item.Classfication == c)
                    {
                        if (j == 0)
                        {
                            SetText(tb, i + 1, 0, string.Format("{0}考评", AssessUtility.ClassficationToString(item.Classfication)), ParagraphAlignment.CENTER);
                        }
                        SetText(tb, i + 1, 1, item.Question, ParagraphAlignment.CENTER);
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
            SetText(tb, _ItemCount + 1, 0, "总评分");
            SetText(tb, _ItemCount + 1, 1, totalScore.ToString());
            MergeCellsHorizontal(tb, _ItemCount + 1, 1, 7);
            SetText(tb, 0, 2, "评定（很差→很好）", ParagraphAlignment.CENTER);

            SetText(tb, _ItemCount + 2, 0, "目前工资");
            SetText(tb, _ItemCount + 2, 1, _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoHrIndex].SalaryNow.ToString());

            SetText(tb, _ItemCount + 2, 3, _AssessActivity.AssessCharacterType == AssessCharacterType.ProbationII ? "转正后工资" : "调薪工资");
            SetText(tb, _ItemCount + 2, 5, _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoCEOIndex].SalaryChange.ToString());
            MergeCellsHorizontal(tb, _ItemCount + 2, 1, 2);
            MergeCellsHorizontal(tb, _ItemCount + 2, 3, 4);
            MergeCellsHorizontal(tb, _ItemCount + 2, 5, 7);


            foreach (SubmitInfo info in _AssessActivity.ItsAssessActivityPaper.SubmitInfoes)
            {
                if (info.SubmitInfoType.Id == SubmitInfoType.ManagerAssess.Id)
                {
                    AddComment(tb, 0, info, "用人部门意见");
                }
                else if (info.SubmitInfoType.Id == SubmitInfoType.Approve.Id)
                {
                    AddComment(tb, 2, info, "总经理意见");
                }
                else if (info.SubmitInfoType.Id == SubmitInfoType.SummarizeCommment.Id)
                {
                    AddComment(tb, 5, info, "人力资源部意见");
                }
            }
            MergeCellsHorizontal(tb, _ItemCount + 3, 0, 1);
            MergeCellsHorizontal(tb, _ItemCount + 4, 0, 1);
            MergeCellsHorizontal(tb, _ItemCount + 5, 0, 1);
            MergeCellsHorizontal(tb, _ItemCount + 3, 2, 4);
            MergeCellsHorizontal(tb, _ItemCount + 4, 2, 4);
            MergeCellsHorizontal(tb, _ItemCount + 5, 2, 4);
            MergeCellsHorizontal(tb, _ItemCount + 3, 5, 7);
            MergeCellsHorizontal(tb, _ItemCount + 4, 5, 7);
            MergeCellsHorizontal(tb, _ItemCount + 5, 5, 7);
            //合并单元格
            for (int k = mergework.Count - 1; k >= 0; k--)
            {
                string[] s = mergework[k].Split(':');
                int start = Convert.ToInt32(s[0]);
                int end = Convert.ToInt32(s[1]);
                MergeCellsVertically(tb, 0, start, end);
            }
        }

        private void AddComment(XWPFTable tb, int cell, SubmitInfo info, string title)
        {
            SetText(tb, _ItemCount + 3, cell, title);
            SetText(tb, _ItemCount + 4, cell, info.Comment);
            SetText(tb, _ItemCount + 5, cell, string.Format("{0}/{1}", info.FillPerson, info.SubmitTime.ToShortDateString()));
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

        private void SetText(XWPFTable tb, int row, int column, String cellText, ParagraphAlignment paragraphAlignment = ParagraphAlignment.LEFT, int fontSize = 11, bool bold = false)
        {
            var cell = tb.GetRow(row).GetCell(column);
            XWPFParagraph p0 = new XWPFParagraph(new CT_P(), cell);
            p0.Alignment = paragraphAlignment;
            XWPFRun r0 = p0.CreateRun();
            r0.FontFamily = "宋体";
            r0.FontSize = fontSize;
            r0.SetBold(bold);
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