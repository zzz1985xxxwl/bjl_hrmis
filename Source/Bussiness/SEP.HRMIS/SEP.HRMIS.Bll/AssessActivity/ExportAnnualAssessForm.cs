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
using Microsoft.Office.Interop.Word;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Departments;

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
                Table tb = doc.Tables[1];
                InitSubmitInfoIndex();
                InitRows(ref tb);
                ExportBasicInfo(ref tb);
                ExportItemInfo(ref tb);
                object fileFormat = WdSaveFormat.wdFormatTemplate97;
                object filename = _EmployeeExportLocation + "\\" + _AssessActivity.ItsEmployee.Account.Name +
                                  "年度员工绩效考核统计表.doc";
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
            AddNeedRow(ref tb, _ItemCount, 5);
        }


        private void ExportItemInfo(ref Table tb)
        {
            int i = 0;
            decimal totalScore = 0;

            ExportItemByItemType(tb, ref i, ref totalScore);
            _ItemCount = _ItemCount > 0 ? _ItemCount : 1;
            tb.Cell(_ItemCount + 5, 2).Range.Text = decimal.Round(totalScore,2).ToString();
            tb.Cell(_ItemCount + 6, 2).Range.Text = GetAns(totalScore);
            tb.Cell(_ItemCount + 7, 1).Range.Text =
                string.Format("考评人评语：{0}",
                              _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoManageIndex].Comment);
            tb.Cell(_ItemCount + 8, 1).Range.Text =
               string.Format("年度考评人：{0}",
                             _AssessActivity.ItsAssessActivityPaper.SubmitInfoes[_SubmitInfoManageIndex].FillPerson);
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

        private void ExportItemByItemType(Table tb, ref int i, ref decimal totalScore)
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
                    tb.Cell(5 + i, 1).Range.Text = item.Question;
                    tb.Cell(5 + i, 2).Range.Text = string.Format("年度评分＝{0}", item.Grade);
                    tb.Cell(5 + i, 3).Range.Text = string.Format("{0}%", Convert.ToInt32(item.Weight*100));
                    totalScore += item.Grade*item.Weight;
                    i++;
                }
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