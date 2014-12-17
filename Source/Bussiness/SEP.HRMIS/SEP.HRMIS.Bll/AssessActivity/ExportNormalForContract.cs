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
using Microsoft.Office.Interop.Word;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;
using SEP.IBll;
using SEP.IBll.Departments;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class ExportNormalForContract
    {
        private readonly string _EmployeeExportLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
        private static readonly IAssessActivity _DalAssessActivity = DalFactory.DataAccess.AssessActivityDal;
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
            PrepareData();
            Application app = new Application();
            object nothing = Type.Missing;
            object localPatho = _EmployeeTemplateLocation;
            Document doc = app.Documents.Add(ref localPatho, ref nothing, ref nothing, ref nothing);
            try
            {
                if (!Directory.Exists(_EmployeeExportLocation))
                {
                    Directory.CreateDirectory(_EmployeeExportLocation);
                }
                Table tbTitle = doc.Tables[1];
                ExportTitleInfo(ref tbTitle);
                Table tb = doc.Tables[2];

                ExportBasicInfo(ref tb);
                InitSubmitInfoIndex();
                InitRows(ref tb);
                ExportItemInfo(ref tb);
                app.ActiveWindow.View.SeekView = WdSeekView.wdSeekCurrentPageFooter; //页脚 
                app.Selection.InsertAfter(_AssessActivity.ItsAssessActivityPaper.PaperName);
                object fileFormat = WdSaveFormat.wdFormatTemplate97;
                string ffname = _AssessActivity.ItsEmployee.Account.Name +
                                _AssessActivity.ItsAssessActivityPaper.PaperName +
                                ".doc";
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


        private void PrepareData()
        {
            _AssessActivity = _DalAssessActivity.GetAssessActivityById(_AssessActivityId);
            _AssessActivity.ItsEmployee.Account =
                BllInstance.AccountBllInstance.GetAccountById(_AssessActivity.ItsEmployee.Account.Id);
            _AssessActivity.ItsEmployee.Account.Dept =
                _IDepartmentBll.GetDepartmentById(_AssessActivity.ItsEmployee.Account.Dept.Id, null);
        }

        private void ExportTitleInfo(ref Table tb)
        {
            tb.Cell(1, 1).Range.Text = _AssessActivity.ItsAssessActivityPaper.PaperName;
        }

        private void ExportBasicInfo(ref Table tb)
        {
            tb.Cell(1, 2).Range.Text = _AssessActivity.ItsEmployee.Account.Name;
            tb.Cell(1, 4).Range.Text = _AssessActivity.ItsEmployee.EmployeeDetails.Gender.Name;
            tb.Cell(1, 6).Range.Text = _AssessActivity.ItsEmployee.EmployeeDetails.Birthday.ToShortDateString();
            tb.Cell(2, 2).Range.Text = _AssessActivity.ItsEmployee.Account.Dept.DepartmentName;
            tb.Cell(2, 4).Range.Text = _AssessActivity.ItsEmployee.Account.Position.Name;
            tb.Cell(2, 6).Range.Text = _AssessActivity.ItsEmployee.Account.Dept.DepartmentLeader.Name;
            tb.Cell(3, 2).Range.Text = _AssessActivity.ItsEmployee.EmployeeDetails.Education.EducationalBackground.Name;
            tb.Cell(3, 4).Range.Text = _AssessActivity.ItsEmployee.EmployeeDetails.Work.ComeDate.ToShortDateString();
            tb.Cell(3, 6).Range.Text = _AssessActivity.ScopeFrom.ToShortDateString() + "--" +
                                       _AssessActivity.ScopeTo.ToShortDateString();
        }

        private void InitRows(ref Table tb)
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
            AddNeedRow(ref tb, _ItemCount, 5);
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


        private void ExportItemInfo(ref Table tb)
        {
            int i = 0;
            decimal totalScore = 0;
            List<string> mergework = new List<string>(); //用于合并单元格
            List<AssessActivityItem> AssessActivityItemList = new List<AssessActivityItem>();
            AssessActivityItemList.AddRange(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoManageIndex].
                                                ItsAssessActivityItems);
            AssessActivityItemList.AddRange(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoHrIndex].
                                                ItsAssessActivityItems);
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
                            tb.Cell(5 + i, 1).Range.Text =
                                string.Format("{0}考评", AssessUtility.ClassficationToString(item.Classfication));
                        }

                        tb.Cell(5 + i, 2).Range.Text = item.Question;
                        int gradecellindex = item.Grade < 6 ? Convert.ToInt32(item.Grade) : Convert.ToInt32(item.Grade) / 20;
                        tb.Cell(5 + i, gradecellindex + 2).Range.Text =
                            Convert.ToInt32(item.Grade).ToString();
                        tb.Cell(5 + i, 8).Range.Text = string.Format("{0}%", Convert.ToInt32(item.Weight*100));
                        totalScore += Convert.ToInt32(item.Grade)*item.Weight;
                        i++;
                        j++;
                    }
                }
                if (j > 1)
                {
                    mergework.Add(string.Format("{0}:{1}", 4 + i, 5 + i - j));
                }
            }
            _ItemCount = _ItemCount > 0 ? _ItemCount : 1;
            tb.Cell(_ItemCount + 5, 2).Range.Text = totalScore.ToString();
            tb.Cell(_ItemCount + 6, 2).Range.Text =_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoHrIndex].SalaryNow.ToString();
            tb.Cell(_ItemCount + 6, 4).Range.Text = _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoCEOIndex].SalaryChange.ToString();
                

            foreach (SubmitInfo info in _AssessActivity.ItsAssessActivityPaper.SubmitInfoes)
            {
                if (info.SubmitInfoType.Id == SubmitInfoType.ManagerAssess.Id)
                {
                    tb.Cell(_ItemCount + 8, 1).Range.Text = info.Comment;
                    tb.Cell(_ItemCount + 9, 1).Range.Text =string.Format("{0}/{1}", info.FillPerson,info.SubmitTime.ToShortDateString());
                }
                else if (info.SubmitInfoType.Id == SubmitInfoType.SummarizeCommment.Id)
                {
                    tb.Cell(_ItemCount + 8, 3).Range.Text = info.Comment;
                    tb.Cell(_ItemCount + 9, 3).Range.Text = string.Format("{0}/{1}", info.FillPerson, info.SubmitTime.ToShortDateString());
                }

                else if (info.SubmitInfoType.Id == SubmitInfoType.Approve.Id)
                {
                    tb.Cell(_ItemCount + 8, 2).Range.Text = info.Comment;
                    tb.Cell(_ItemCount + 9, 2).Range.Text = string.Format("{0}/{1}", info.FillPerson, info.SubmitTime.ToShortDateString());
                }
            }
            if(_AssessActivity.AssessCharacterType==AssessCharacterType.ProbationII)
            {
                tb.Cell(_ItemCount + 6, 3).Range.Text = "转正后工资";
            }

            //合并单元格
            for (int k = mergework.Count - 1; k >= 0; k--)
            {
                string[] s = mergework[k].Split(':');
                int start = Convert.ToInt32(s[0]);
                int end = Convert.ToInt32(s[1]);
                tb.Cell(start, 1).Merge(tb.Cell(end, 1));
            }
        }


        /// <summary>
        /// 根据需要在table中增加必要的行
        /// </summary>
        private static void AddNeedRow(ref Table tb, int count, int rowIndex)
        {
            object row = tb.Rows[rowIndex];
            for (int i = 0; i < count - 1; i++)
            {
                tb.Rows[rowIndex].Select();
                tb.Rows.Add(ref row);
            }
        }
    }
}