//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: ExportAnualAssessListExcel.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-20
// Resume: 导出所有员工的绩效考核
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using SEP.HRMIS.Bll.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;
using SEP.HRMIS.Model.PayModule;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AssessActivity
{
    /// <summary>
    /// 
    /// </summary>
    public class ExportAnualAssessListExcel
    {
        private readonly string _EmployeeExportLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
        private List<Model.AssessActivity> _AssessActivityList;
        private readonly string _EmployeeTemplateLocation;
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private readonly IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
        private int _TotalScoreLocation;
        private List<string> _HrmisQuestion;
        private List<string> _360Question;

        private readonly GetBindField _GetBindField = new GetBindField();

        /// <summary>
        /// 
        /// </summary>
        public ExportAnualAssessListExcel(string employeeTemplateLocation, string employeeName, DateTime? hrSubmitTimeFrom, DateTime? hrSubmitTimeTo,
                                                    int finishStatus, DateTime? scopeFrom, DateTime? scopeTo, int departmentID,
                                                    Account loginuser, int power, AssessStatus assessStatus)
        {
            _EmployeeTemplateLocation = employeeTemplateLocation;
            _AssessActivityList =
                new GetAssessActivity().GetAssessActivityByCondition(employeeName, AssessCharacterType.Annual,
                                                                     assessStatus, hrSubmitTimeFrom,
                                                                     hrSubmitTimeTo, finishStatus, scopeFrom, scopeTo,
                                                                     departmentID, loginuser, power);
            PrepareData();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void PrepareData()
        {      
            foreach (Model.AssessActivity activity in _AssessActivityList)
            {
                activity.ItsEmployee = new GetEmployee().GetEmployeeByAccountID(activity.ItsEmployee.Account.Id);
                activity.ItsEmployee.Account.Dept =
                    _IDepartmentBll.GetDepartmentById(activity.ItsEmployee.Account.Dept.Id, null);
                if (activity.ItsEmployee.Account.Position.Grade != null)
                {
                    activity.ItsEmployee.Account.Position.Grade =
                        _IPositionBll.GetPositionGradeById(activity.ItsEmployee.Account.Position.Grade.Id, null);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Excute()
        {
            GC.Collect();

            if (!Directory.Exists(_EmployeeExportLocation))
            {
                Directory.CreateDirectory(_EmployeeExportLocation);
            }
            string templocation = _EmployeeExportLocation + "\\绩效评估结果.xls";
            Application excel = new Application();
            _Workbook xBk = excel.Workbooks.Add(_EmployeeTemplateLocation);
            _Worksheet xSt = (_Worksheet) xBk.ActiveSheet;

            try
            {
                InitHrmisQuestionRow(excel);
                ExportALLInfo(excel);
                object nothing = Type.Missing;
                object fileFormat = XlFileFormat.xlExcel8;
                object file = templocation;
                if (File.Exists(file.ToString()))
                {
                    File.Delete(file.ToString());
                }
                xBk.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange, nothing, nothing, nothing, nothing, nothing);
            }
            finally
            {
                xBk.Close(false, null, null);
                excel.Quit();
                Marshal.ReleaseComObject(xBk);
                Marshal.ReleaseComObject(excel);
                Marshal.ReleaseComObject(xSt);
                GC.Collect();
            }
            return templocation;
        }


        private void ExportALLInfo(_Application excel)
        {
            int i;
            for (i = 0; i < _AssessActivityList.Count; i++)
            {
                ExportNormalInfo(i, excel);

                int submintInfoManageIndex = -1;
                int submintInfoHrIndex = -1;
                int submintInfoSelfIndex = -1;
                int submintInfoCeoIndex = -1;
                GetIndex(_AssessActivityList[i], ref submintInfoSelfIndex, ref submintInfoManageIndex,
                         ref submintInfoHrIndex, ref submintInfoCeoIndex);
                if (submintInfoCeoIndex != -1)
                {
                    //建议工资
                    excel.Cells[i + 2, 7] = _AssessActivityList[i].ItsAssessActivityPaper.SubmitInfoes[submintInfoCeoIndex].SalaryChange.
                            ToString();
                }

                if (submintInfoSelfIndex != -1)
                {
                    //个人评分
                    excel.Cells[i + 2, 8] =
                        CalculateScore(
                            _AssessActivityList[i].ItsAssessActivityPaper.SubmitInfoes[submintInfoSelfIndex].
                                ItsAssessActivityItems);
                }
                if (submintInfoManageIndex != -1)
                {
                    //主管评分
                    excel.Cells[i + 2, 9] =
                        CalculateScore(
                            _AssessActivityList[i].ItsAssessActivityPaper.SubmitInfoes[submintInfoManageIndex].
                                ItsAssessActivityItems);
                    excel.Cells[i + 2, _TotalScoreLocation + 4] =
                        _AssessActivityList[i].ItsAssessActivityPaper.SubmitInfoes[submintInfoManageIndex].Comment;
                        //主管总评
                }
                if (submintInfoHrIndex != -1)
                {
                    //目前工资
                    excel.Cells[i + 2, 6] =
                        _AssessActivityList[i].ItsAssessActivityPaper.SubmitInfoes[submintInfoHrIndex].SalaryNow.
                            ToString();
                    //导出人事项
                    for (int t = 0; t < _HrmisQuestion.Count; t++)
                    {
                        foreach (
                            AssessActivityItem item in
                                _AssessActivityList[i].ItsAssessActivityPaper.SubmitInfoes[submintInfoHrIndex].
                                    ItsAssessActivityItems)
                        {
                            if (item.Question == _HrmisQuestion[t])
                            {
                                excel.Cells[i + 2, 12 + t] = item.Grade*item.Weight;
                                break;
                            }
                        }
                    }
                }
                decimal totlescore = _AssessActivityList[i].ItsAssessActivityPaper.Score;
                excel.Cells[i + 2, _TotalScoreLocation] = totlescore; //年度总评分
                excel.Cells[i + 2, _TotalScoreLocation + 1] = ExportAnnualAssessForm.GetAns(totlescore); //综合评价
                //360
                if (submintInfoSelfIndex != -1)
                {
                    //导出360项
                    for (int t = 0; t < _360Question.Count; t++)
                    {
                        foreach (
                            AssessActivityItem item in
                                _AssessActivityList[i].ItsAssessActivityPaper.SubmitInfoes[submintInfoSelfIndex].
                                    ItsAssessActivityItems)
                        {
                            if (item.Question == _360Question[t])
                            {
                                excel.Cells[i + 2, _TotalScoreLocation + 5 + t] = item.AssessTemplateItemType ==
                                                                                  AssessTemplateItemType.Open
                                                                                      ? item.Note
                                                                                      : item.Grade.ToString();
                                break;
                            }
                        }
                    }
                }
            }
            //设置边框和列宽
            Range range = excel.get_Range(excel.Cells[1, 1], excel.Cells[i + 1, _TotalScoreLocation + 4 + _360Question.Count]);
            range.Cells.Borders.LineStyle = 1;
            range.EntireColumn.AutoFit();
        }

        /// <summary>
        /// 初始化主管人事个人在哪一个位置
        /// </summary>
        private static void GetIndex(Model.AssessActivity assessActivity, ref int submintInfoSelfIndex,
                                     ref int submintInfoManageIndex,
                                     ref int submintInfoHrIndex,ref int submitInfoCeoIndex)
        {
            for (int j = 0; j < assessActivity.ItsAssessActivityPaper.SubmitInfoes.Count; j++)
            {
                if (assessActivity.ItsAssessActivityPaper.SubmitInfoes[j].SubmitInfoType.Id ==
                    SubmitInfoType.ManagerAssess.Id)
                {
                    submintInfoManageIndex = j;
                }
                else if (assessActivity.ItsAssessActivityPaper.SubmitInfoes[j].SubmitInfoType.Id ==
                         SubmitInfoType.HRAssess.Id)
                {
                    submintInfoHrIndex = j;
                }

                else if (assessActivity.ItsAssessActivityPaper.SubmitInfoes[j].SubmitInfoType.Id ==
                         SubmitInfoType.MyselfAssess.Id)
                {
                    submintInfoSelfIndex = j;
                }
                else if (assessActivity.ItsAssessActivityPaper.SubmitInfoes[j].SubmitInfoType.Id ==
                    SubmitInfoType.Approve.Id)
                {
                    submitInfoCeoIndex = j;
                }
            }
        }

        private void ExportNormalInfo(int i, _Application excel)
        {
            excel.Cells[i + 2, 1] = _AssessActivityList[i].ItsEmployee.Account.Name;
            if (_AssessActivityList[i].ItsEmployee.Account.Position.Grade != null)
            {
                excel.Cells[i + 2, 2] = _AssessActivityList[i].ItsEmployee.Account.Position.Grade.Name;
            }
            excel.Cells[i + 2, 3] = _AssessActivityList[i].ItsEmployee.EmployeeDetails.Work.ComeDate;
            excel.Cells[i + 2, 4] =
                _AssessActivityList[i].ItsEmployee.EmployeeDetails.Education.EducationalBackground.Name;
            excel.Cells[i + 2, 5] = _AssessActivityList[i].ItsEmployee.Account.Dept.DepartmentName;
            BindItemValueCollection collection =
                _GetBindField.BindItemValueCollection(_AssessActivityList[i].ItsEmployee.Account.Id,
                                                      _AssessActivityList[i].ScopeFrom, _AssessActivityList[i].ScopeTo);
            foreach (BindItemValue item in collection.BindItemValueList)
            {
                if (item.BindItemEnum.Id == BindItemEnum.OutCityDays.Id)
                {
                    excel.Cells[i + 2, 10] = item.Value;
                }
                else if (item.BindItemEnum.Id == BindItemEnum.Absenteeism.Id)
                {
                    excel.Cells[i + 2, 11] = item.Value;
                }
            }
        }

        private static decimal CalculateScore(IEnumerable<AssessActivityItem> AssessActivityItemList)
        {
            decimal totalScore = 0;
            foreach (AssessActivityItem item in AssessActivityItemList)
            {
                totalScore += (item.Grade*item.Weight);
            }
            return totalScore;
        }

        /// <summary>
        /// 创建人事项，放入表头
        /// </summary>
        /// <param name="excel"></param>
        private void InitHrmisQuestionRow(_Application excel)
        {
            InitHrmisQuestion();
            Init360Question();
            int i = 0;
            foreach (string s in _HrmisQuestion)
            {
                excel.Cells[1, 12 + i] = s;
                i++;
            }

            _TotalScoreLocation = 12 + i;
            excel.Cells[1, _TotalScoreLocation] = "年度总评分";
            excel.Cells[1, _TotalScoreLocation + 1] = "综合评价";
            excel.Cells[1, _TotalScoreLocation + 2] = "加薪建议";
            excel.Cells[1, _TotalScoreLocation + 3] = "备注";
            excel.Cells[1, _TotalScoreLocation + 4] = "主管总评";
            int j = 0;
            foreach (string s in _360Question)
            {
                excel.Cells[1, _TotalScoreLocation + 5 + j] = s;
                j++;
            }
        }

        private void Init360Question()
        {
            _360Question=new List<string>();
            foreach (Model.AssessActivity activity in _AssessActivityList)
            {
                int submintInfo360Index = -1;
                for (int i = 0; i < activity.ItsAssessActivityPaper.SubmitInfoes.Count; i++)
                {
                    if (activity.ItsAssessActivityPaper.SubmitInfoes[i].SubmitInfoType.Id ==
                        SubmitInfoType.MyselfAssess.Id)
                    {
                        submintInfo360Index = i;
                    }
                }
                if (submintInfo360Index >= 0)
                {
                    foreach (
                        AssessActivityItem item in
                            activity.ItsAssessActivityPaper.SubmitInfoes[submintInfo360Index].ItsAssessActivityItems)
                    {
                        if (!_360Question.Contains(item.Question) && item.Classfication == ItemClassficationEmnu._360)
                        {
                            _360Question.Add(item.Question);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 初始化hrmis项
        /// </summary>
        /// <returns></returns>
        private void InitHrmisQuestion()
        {
            _HrmisQuestion = new List<string>();
            foreach (Model.AssessActivity activity in _AssessActivityList)
            {
                int submintInfoHrIndex = -1;
                for (int i = 0; i < activity.ItsAssessActivityPaper.SubmitInfoes.Count; i++)
                {
                    if (activity.ItsAssessActivityPaper.SubmitInfoes[i].SubmitInfoType.Id ==
                        SubmitInfoType.HRAssess.Id)
                    {
                        submintInfoHrIndex = i;
                    }
                }
                if (submintInfoHrIndex >= 0)
                {
                    foreach (
                        AssessActivityItem item in
                            activity.ItsAssessActivityPaper.SubmitInfoes[submintInfoHrIndex].ItsAssessActivityItems)
                    {
                        if (!_HrmisQuestion.Contains(item.Question))
                        {
                            _HrmisQuestion.Add(item.Question);
                        }
                    }
                }
            }
        }
    }
}