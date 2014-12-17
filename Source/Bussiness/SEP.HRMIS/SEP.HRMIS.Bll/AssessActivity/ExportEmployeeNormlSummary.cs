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
    public class ExportEmployeeNormlSummary
    {
        private readonly string _EmployeeExportLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
        private static readonly IAssessActivity _DalAssessActivity = DalFactory.DataAccess.AssessActivityDal;
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
                Table tbBase = doc.Tables[1];
                Table tbSummary = doc.Tables[2];
                InitSubmitInfoIndex();
                ExportBasicInfo(ref tbBase);
                InitRows(ref tbBase);
                ExportItemInfoItem(ref tbBase);
                ExportItemInfoSummary(ref tbSummary);
                app.ActiveWindow.View.SeekView = WdSeekView.wdSeekCurrentPageFooter; //页脚 
                app.Selection.InsertAfter(string.Format("员工个人{0}",_AssessActivity.ItsAssessActivityPaper.PaperName));
                object fileFormat = WdSaveFormat.wdFormatTemplate97;
                string ffname = _AssessActivity.ItsEmployee.Account.Name + "个人" +
                                _AssessActivity.ItsAssessActivityPaper.PaperName +
                                ".doc";
                ffname = ffname.Replace("/", "").Replace(@"\", "");
                object filename = _EmployeeExportLocation + "\\" + ffname;
                doc.SaveAs(ref filename, ref fileFormat, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                           ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                           ref nothing, ref nothing);
                return filename.ToString();
            }
            catch (Exception e)
            {
                doc.Tables[1].Cell(3, 2).Range.Text = e.Message;
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


        private void ExportBasicInfo(ref Table tb)
        {
            tb.Cell(1, 1).Range.Text =string.Format("员工个人{0}",_AssessActivity.ItsAssessActivityPaper.PaperName) ;
            tb.Cell(2, 2).Range.Text = _AssessActivity.ItsEmployee.Account.Name;
            tb.Cell(2, 4).Range.Text = _AssessActivity.ItsEmployee.EmployeeDetails.Gender.Name;
            tb.Cell(2, 6).Range.Text = _AssessActivity.ItsEmployee.EmployeeDetails.Birthday.ToShortDateString();
            tb.Cell(3, 2).Range.Text = _AssessActivity.ItsEmployee.Account.Dept.DepartmentName;
            tb.Cell(3, 4).Range.Text = _AssessActivity.ItsEmployee.Account.Position.Name;
            tb.Cell(3, 6).Range.Text = _AssessActivity.ItsEmployee.Account.Dept.DepartmentLeader.Name;
            tb.Cell(4, 2).Range.Text = _AssessActivity.ItsEmployee.EmployeeDetails.Education.EducationalBackground.Name;
            tb.Cell(4, 4).Range.Text = _AssessActivity.ItsEmployee.EmployeeDetails.Work.ComeDate.ToShortDateString();
            tb.Cell(4, 6).Range.Text = _AssessActivity.ScopeFrom.ToShortDateString() + "--" +
                                       _AssessActivity.ScopeTo.ToShortDateString();
        }
        private void InitRows(ref Table tb)
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
            AddNeedRow(ref tb, _ItemCount, 6);
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


        private void ExportItemInfoSummary(ref Table tb)
        {
            int i = 1;
            StringBuilder sb=new StringBuilder();
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
                    sb.AppendFormat("{0}、{1}",i,item.Question);
                    sb.Append(Environment.NewLine);
                    sb.Append(item.Note);
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                    i++;
                }
            }
            sb.Append("总评");
            sb.Append(Environment.NewLine);
            sb.Append(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoIndex].Comment );
            sb.Append(Environment.NewLine);

            tb.Cell(3, 1).Range.Text = sb.ToString();
        }


        private void ExportItemInfoItem(ref Table tb)
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
                foreach (
                    AssessActivityItem item in AssessActivityItemList)
                {
                    if (item.AssessTemplateItemType == AssessTemplateItemType.Option && item.Classfication == c)
                    {
                        if (j == 0)
                        {
                            tb.Cell(6 + i, 1).Range.Text =
                                string.Format("{0}考评", AssessUtility.ClassficationToString(item.Classfication));
                        }

                        tb.Cell(6 + i, 2).Range.Text = item.Question;
                        int gradecellindex = item.Grade < 6 ? Convert.ToInt32(item.Grade) : Convert.ToInt32(item.Grade) / 20;
                        tb.Cell(6 + i, gradecellindex + 2).Range.Text =
                            Convert.ToInt32(item.Grade).ToString();
                        tb.Cell(6 + i, 8).Range.Text = string.Format("{0}%", Convert.ToInt32(item.Weight * 100));
                        totalScore += Convert.ToInt32(item.Grade) * item.Weight;
                        i++;
                        j++;
                    }
                }
                if (j > 1)
                {
                    mergework.Add(string.Format("{0}:{1}", 5 + i, 6 + i - j));
                }
            }
            _ItemCount = _ItemCount > 0 ? _ItemCount : 1;
            tb.Cell(_ItemCount + 6, 2).Range.Text = totalScore.ToString();

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