//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ExportLeaderAssessForm.cs
// 创建者: yyb
// 创建日期: 2008-11-11
// 概述: 用于导出考评表
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

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 用于导出考评表
    /// </summary>
    public class ExportLeaderAssessForm
    {
        private readonly string _EmployeeExportLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
        private static readonly IAssessActivity _DalAssessActivity = new AssessActivityDal();
        private Model.AssessActivity _AssessActivity;
        private readonly string _EmployeeTemplateLocation;
        private int _ItemCount;
        private readonly int _AssessActivityId;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance; 

        /// <summary>
        /// 用于导出考评表
        /// </summary>
        /// <param name="assessActivityId"></param>
        /// <param name="employeeTemplateLocation"></param>
        public ExportLeaderAssessForm(int assessActivityId, string employeeTemplateLocation)
        {
            _AssessActivityId = assessActivityId;
            _EmployeeTemplateLocation = employeeTemplateLocation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ExcuteSelf()
        {
            PrepareData();
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            object nothing = Type.Missing;
            object localPatho = _EmployeeTemplateLocation;
            Microsoft.Office.Interop.Word.Document doc = app.Documents.Add(ref localPatho, ref nothing, ref nothing, ref nothing);
            try
            {
                if (!Directory.Exists(_EmployeeExportLocation))
                {
                    Directory.CreateDirectory(_EmployeeExportLocation);
                }
                Microsoft.Office.Interop.Word.Table tb = doc.Tables[1];
                ExportBasicInfo(ref tb);
                InitRows(ref tb);
                ExportAssessSystemInfo(ref tb);

                object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatTemplate97;
                object filename = _EmployeeExportLocation + "\\" + _AssessActivity.ItsEmployee.Account.Name + "考核表(主管评定).doc";
                doc.SaveAs(ref filename, ref fileFormat, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                           ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                           ref nothing, ref nothing);
                return filename.ToString();
            }
            catch (Exception e)
            {
                doc.Tables[1].Cell(3, 2).Range.Text = e.Message;
                object filename = _EmployeeExportLocation + "\\" + "temp.doc";
                object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatTemplate97;
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
            List<AssessActivityItem> assessActivityItems =
                _AssessActivity.ItsAssessActivityPaper.FindManagerAssessActivityItems();
            //todo yyb
            _AssessActivity.ItsAssessActivityPaper.ItsAssessActivityItems.Clear();
            _AssessActivity.ItsAssessActivityPaper.ItsAssessActivityItems = assessActivityItems;
            _AssessActivity.ItsEmployee.Account.Dept =
              _IDepartmentBll.GetDepartmentById(_AssessActivity.ItsEmployee.Account.Dept.Id, null);
        }

        private void ExportBasicInfo(ref Microsoft.Office.Interop.Word.Table tb)
        {
            tb.Cell(1, 3).Range.Text = AssessSystemUtility.GetCharacterNameByType(_AssessActivity.AssessCharacterType);
            tb.Cell(1, 5).Range.Text = _AssessActivity.ScopeFrom.ToShortDateString() + " 至 " + _AssessActivity.ScopeTo.ToShortDateString();
            tb.Cell(2, 2).Range.Text = _AssessActivity.ItsEmployee.Account.Name;
            tb.Cell(2, 4).Range.Text = _AssessActivity.ItsEmployee.EmployeeDetails.Gender.Name;
            tb.Cell(2, 6).Range.Text = _AssessActivity.ItsEmployee.EmployeeDetails.Birthday.ToShortDateString();
            tb.Cell(3, 2).Range.Text = _AssessActivity.ItsEmployee.Account.Dept.DepartmentName;
            tb.Cell(3, 4).Range.Text = _AssessActivity.ItsEmployee.Account.Position.Name;
            tb.Cell(3, 6).Range.Text = _AssessActivity.ItsEmployee.Account.Dept.DepartmentLeader.Name;
            tb.Cell(4, 2).Range.Text = _AssessActivity.ItsEmployee.EmployeeDetails.Education.EducationalBackground.Name;
            tb.Cell(4, 4).Range.Text = _AssessActivity.ItsEmployee.EmployeeDetails.Work.ComeDate.ToShortDateString();
            string PersonalChoose = "";
            if (_AssessActivity != null &&
                _AssessActivity.ItsAssessActivityPaper != null &&
                _AssessActivity.ItsAssessActivityPaper.SubmitInfoes != null)
            {
                foreach (SubmitInfo info in _AssessActivity.ItsAssessActivityPaper.SubmitInfoes)
                {
                    if (info.SubmitInfoType.Id == SubmitInfoType.MyselfAssess.Id)
                    {
                        PersonalChoose = info.Choose;
                    }
                }
            }
            tb.Cell(7, 2).Range.Text = PersonalChoose;
        }

        private void ExportAssessSystemInfo(ref Microsoft.Office.Interop.Word.Table tb)
        {
            decimal grade = 0;
            for (int i = 0; i < _ItemCount; i++)
            {
                //todo yyb
                AssessActivityItem managerItem = _AssessActivity.ItsAssessActivityPaper.ItsAssessActivityItems[i];
                if (managerItem.Classfication == ItemClassficationEmnu._360)
                {
                    continue;
                }
                tb.Cell(6 + i, 1).Range.Text =
                    AssessSystemUtility.GetItemClassficationNameByItemClassfication(managerItem.Classfication);
                string questionAndNote = managerItem.Question;
                if (!string.IsNullOrEmpty(managerItem.Note))
                {
                    questionAndNote += "(" + managerItem.Note + ")";
                }     
                if (managerItem.AssessTemplateItemType == AssessTemplateItemType.Option)
                {
                    tb.Cell(6 + i, 2).Range.Text = questionAndNote;
                    //如果不是1到5分将存在问题
                    string[] options = managerItem.Option.Split('/');
                    int gradecellindex = managerItem.Grade < 6 ? Decimal.ToInt32(managerItem.Grade) : Decimal.ToInt32(managerItem.Grade) / 20;

                    tb.Cell(6 + i, 3).Range.Text = options[5 - gradecellindex];
                    tb.Cell(6 + i, 4).Range.Text = (managerItem.Grade * managerItem.Weight).ToString();
                }
                else if (managerItem.AssessTemplateItemType == AssessTemplateItemType.Open)
                {
                    tb.Cell(6 + i, 2).Range.Text = managerItem.Question;
                    tb.Cell(6 + i, 3).Range.Text = managerItem.Note;
                    tb.Cell(6 + i, 4).Range.Text = "不计分";
                }
                else
                {
                    tb.Cell(6 + i, 2).Range.Text = questionAndNote;
                    tb.Cell(6 + i, 4).Range.Text = (managerItem.Grade*managerItem.Weight).ToString();
                }
                grade += (managerItem.Grade * managerItem.Weight);
            }
            tb.Cell(6 + _ItemCount, 4).Range.Text = grade.ToString();
        }

        private void InitRows(ref Microsoft.Office.Interop.Word.Table tb)
        {
            //todo yyb
            foreach (AssessActivityItem item in _AssessActivity.ItsAssessActivityPaper.ItsAssessActivityItems)
            {
                if (item.Classfication != ItemClassficationEmnu._360)
                {
                    _ItemCount++;
                }
            }
            AddNeedRow(ref tb, _ItemCount, 6);
        }

        /// <summary>
        /// 根据需要在table中增加必要的行
        /// </summary>
        private static void AddNeedRow(ref Microsoft.Office.Interop.Word.Table tb, int count, int rowIndex)
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
