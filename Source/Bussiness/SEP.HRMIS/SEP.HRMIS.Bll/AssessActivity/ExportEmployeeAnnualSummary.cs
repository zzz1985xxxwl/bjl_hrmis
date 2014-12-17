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
    public class ExportEmployeeAnnualSummary
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
        public ExportEmployeeAnnualSummary(int assessActivityId, string employeeTemplateLocation)
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
                object fileFormat = WdSaveFormat.wdFormatTemplate97;
                string ffname = _AssessActivity.ItsEmployee.Account.Name + "员工绩效考评个人工作总结表.doc";
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


        private void ExportBasicInfo(ref Table tb)
        {
            tb.Cell(2, 1).Range.Text = string.Format("考评时间段：{0}", _AssessActivity.ScopeFrom.ToShortDateString() + "--" +
                                       _AssessActivity.ScopeTo.ToShortDateString());
            tb.Cell(3, 1).Range.Text = string.Format("部门：{0}", _AssessActivity.ItsEmployee.Account.Dept.DepartmentName);
            tb.Cell(3, 2).Range.Text = string.Format("姓名：{0}", _AssessActivity.ItsEmployee.Account.Name);
            tb.Cell(3, 3).Range.Text = string.Format("岗位：{0}", _AssessActivity.ItsEmployee.Account.Position.Name);
        }
        private void InitRows(ref Table tb)
        {
            List<AssessActivityItem> AssessActivityItemList = new List<AssessActivityItem>();
            AssessActivityItemList.AddRange(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoIndex].
                                                ItsAssessActivityItems);
            foreach (AssessActivityItem item in AssessActivityItemList)
            {
                if( item.Classfication == ItemClassficationEmnu._360)
                {
                    continue;
                }
                if ((item.AssessTemplateItemType != AssessTemplateItemType.Open))
                {
                    _ItemCount++;
                }
            }
            AddNeedRow(ref tb, _ItemCount, 5);
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
            if (!string.IsNullOrEmpty(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoIndex].Comment))
            {
                sb.Append("总评");
                sb.Append(Environment.NewLine);
                sb.Append(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoIndex].Comment);
                sb.Append(Environment.NewLine);
            }
            tb.Cell(3, 1).Range.Text = sb.ToString();
        }


        private void ExportItemInfoItem(ref Table tb)
        {
            int i = 0;
            decimal totalScore = 0;

            ExportItemByItemType(tb, ref i, ref totalScore);
            _ItemCount = _ItemCount > 0 ? _ItemCount : 1;
            tb.Cell(_ItemCount + 5, 2).Range.Text = decimal.Round(totalScore, 2).ToString();
            tb.Cell(_ItemCount + 6, 2).Range.Text = ExportAnnualAssessForm.GetAns(totalScore);
        }
        private void ExportItemByItemType(Table tb, ref int i, ref decimal totalScore)
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
                    tb.Cell(5 + i, 1).Range.Text = item.Question;
                    tb.Cell(5 + i, 2).Range.Text = string.Format("年度评分＝{0}", item.Grade);
                    tb.Cell(5 + i, 3).Range.Text = string.Format("{0}%", Convert.ToInt32(item.Weight * 100));
                    totalScore += item.Grade * item.Weight;
                    i++;
                }
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