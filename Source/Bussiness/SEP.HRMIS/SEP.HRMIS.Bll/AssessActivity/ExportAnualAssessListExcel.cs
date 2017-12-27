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
using SEP.HRMIS.Bll.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AssessFlow;
using SEP.HRMIS.Model.PayModule;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.IBll.Positions;
using SEP.Model.Accounts;
using NPOI.HSSF.UserModel;
using System.Data;
using SEP.HRMIS.Entity;

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
        //public string Excute()
        //{
        //GC.Collect();

        //if (!Directory.Exists(_EmployeeExportLocation))
        //{
        //    Directory.CreateDirectory(_EmployeeExportLocation);
        //}
        //string templocation = _EmployeeExportLocation + "\\绩效评估结果.xls";
        //Application excel = new Application();
        //_Workbook xBk = excel.Workbooks.Add(_EmployeeTemplateLocation);
        //_Worksheet xSt = (_Worksheet) xBk.ActiveSheet;

        //try
        //{
        //    InitHrmisQuestionRow(excel);
        //    ExportALLInfo(excel);
        //    object nothing = Type.Missing;
        //    object fileFormat = XlFileFormat.xlExcel8;
        //    object file = templocation;
        //    if (File.Exists(file.ToString()))
        //    {
        //        File.Delete(file.ToString());
        //    }
        //    xBk.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange, nothing, nothing, nothing, nothing, nothing);
        //}
        //finally
        //{
        //    xBk.Close(false, null, null);
        //    excel.Quit();
        //    Marshal.ReleaseComObject(xBk);
        //    Marshal.ReleaseComObject(excel);
        //    Marshal.ReleaseComObject(xSt);
        //    GC.Collect();
        //}
        //return templocation;
        //return "";
        //}

        public MemoryStream Excute()
        {
            //var workbook = new HSSFWorkbook();
            //MemoryStream ms = new MemoryStream();
            //HSSFSheet sheet = workbook.CreateSheet("sheet1") as HSSFSheet;
            //HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;

            DataTable dt = new DataTable("Table");
            InitHrmisQuestionRow(dt);
            ExportALLInfo(dt);
            var workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            HSSFSheet sheet = workbook.CreateSheet("sheet1") as HSSFSheet;
            HSSFRow headerRow = sheet.CreateRow(0) as HSSFRow;

            // handling header.
            foreach (DataColumn column in dt.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in dt.Rows)
            {
                HSSFRow dataRow = sheet.CreateRow(rowIndex) as HSSFRow;

                foreach (DataColumn column in dt.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }

                rowIndex++;
            }
            for (var i = 0; i < dt.Columns.Count; i++)
            {
                sheet.AutoSizeColumn(i);
            }
            //_TotalScoreLocation + 4 + _360Question.Count
            //Range range = excel.get_Range(excel.Cells[1, 1], excel.Cells[i + 1, _TotalScoreLocation + 4 + _360Question.Count]);
            //range.Cells.Borders.LineStyle = 1;
            //range.EntireColumn.AutoFit();


            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            workbook = null;

            return ms;
        }

        private void ExportALLInfo(DataTable dt)
        {
            int i;
            for (i = 0; i < _AssessActivityList.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                ExportNormalInfo(i, dr);

                int submintInfoManageIndex = -1;
                int submintInfoHrIndex = -1;
                int submintInfoSelfIndex = -1;
                int submintInfoCeoIndex = -1;
                GetIndex(_AssessActivityList[i], ref submintInfoSelfIndex, ref submintInfoManageIndex,
                         ref submintInfoHrIndex, ref submintInfoCeoIndex);
                if (submintInfoCeoIndex != -1)
                {
                    //建议工资
                    dr[6] = _AssessActivityList[i].ItsAssessActivityPaper.SubmitInfoes[submintInfoCeoIndex].SalaryChange.
                            ToString();
                }

                if (submintInfoSelfIndex != -1)
                {
                    //个人评分
                    dr[7] =
                        CalculateScore(
                            _AssessActivityList[i].ItsAssessActivityPaper.SubmitInfoes[submintInfoSelfIndex].
                                ItsAssessActivityItems);
                }
                if (submintInfoManageIndex != -1)
                {
                    //主管评分
                    dr[8] =
                        CalculateScore(
                            _AssessActivityList[i].ItsAssessActivityPaper.SubmitInfoes[submintInfoManageIndex].
                                ItsAssessActivityItems);
                    dr[_TotalScoreLocation + 3] =
                        _AssessActivityList[i].ItsAssessActivityPaper.SubmitInfoes[submintInfoManageIndex].Comment;
                    //主管总评
                }
                if (submintInfoHrIndex != -1)
                {
                    //目前工资
                    dr[5] =
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
                                dr[12 + t - 1] = item.Grade * item.Weight;
                                break;
                            }
                        }
                    }
                }
                decimal totlescore = _AssessActivityList[i].ItsAssessActivityPaper.Score;
                dr[_TotalScoreLocation - 1] = totlescore; //年度总评分
                dr[_TotalScoreLocation] = ExportAnnualAssessForm.GetAns(totlescore); //综合评价
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
                                dr[_TotalScoreLocation + 5 + t - 1] = item.AssessTemplateItemType ==
                                                                                  AssessTemplateItemType.Open
                                                                                      ? item.Note
                                                                                      : item.Grade.ToString();
                                break;
                            }
                        }
                    }
                }
            }
            ////设置边框和列宽
            //Range range = excel.get_Range(excel.Cells[1, 1], excel.Cells[i + 1, _TotalScoreLocation + 4 + _360Question.Count]);
            //range.Cells.Borders.LineStyle = 1;
            //range.EntireColumn.AutoFit();
        }

        /// <summary>
        /// 初始化主管人事个人在哪一个位置
        /// </summary>
        private static void GetIndex(Model.AssessActivity assessActivity, ref int submintInfoSelfIndex,
                                     ref int submintInfoManageIndex,
                                     ref int submintInfoHrIndex, ref int submitInfoCeoIndex)
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

        private void ExportNormalInfo(int i, DataRow dr)
        {
            dr[0] = _AssessActivityList[i].ItsEmployee.Account.Name;
            if (_AssessActivityList[i].ItsEmployee.Account.Position.Grade != null)
            {
                dr[1] = _AssessActivityList[i].ItsEmployee.Account.Position.Grade.Name;
            }
            dr[2] = _AssessActivityList[i].ItsEmployee.EmployeeDetails.Work.ComeDate;
            dr[3] =
                _AssessActivityList[i].ItsEmployee.EmployeeDetails.Education.EducationalBackground.Name;
            dr[4] = _AssessActivityList[i].ItsEmployee.Account.Dept.DepartmentName;
            BindItemValueCollection collection =
                _GetBindField.BindItemValueCollection(_AssessActivityList[i].ItsEmployee.Account.Id,
                                                      _AssessActivityList[i].ScopeFrom, _AssessActivityList[i].ScopeTo);
            foreach (BindItemValue item in collection.BindItemValueList)
            {
                if (item.BindItemEnum.Id == BindItemEnum.OutCityDays.Id)
                {
                    dr[9] = item.Value;
                }
                else if (item.BindItemEnum.Id == BindItemEnum.Absenteeism.Id)
                {
                    dr[10] = item.Value;
                }
            }
        }

        private static decimal CalculateScore(IEnumerable<AssessActivityItem> AssessActivityItemList)
        {
            decimal totalScore = 0;
            foreach (AssessActivityItem item in AssessActivityItemList)
            {
                totalScore += (item.Grade * item.Weight);
            }
            return totalScore;
        }

        /// <summary>
        /// 创建人事项，放入表头
        /// </summary>
        /// <param name="excel"></param>
        private void InitHrmisQuestionRow(DataTable dt)
        {
            InitHrmisQuestion();
            Init360Question();

            dt.Columns.Add("姓名", typeof(String));
            dt.Columns.Add("职等", typeof(String));
            dt.Columns.Add("进本单位年月", typeof(String));
            dt.Columns.Add("最高学历", typeof(String));
            dt.Columns.Add("部门", typeof(String));
            dt.Columns.Add("目前工资", typeof(String));
            dt.Columns.Add("建议工资", typeof(String));
            dt.Columns.Add("个人考评分", typeof(String));
            dt.Columns.Add("部门考评分", typeof(String));
            dt.Columns.Add("出差天数", typeof(String));
            dt.Columns.Add("缺勤天数", typeof(String));
            int i = 0;
            foreach (string s in _HrmisQuestion)
            {
                dt.Columns.Add(s, typeof(String));
                i++;
            }
            _TotalScoreLocation = 12 + i;
            dt.Columns.Add("年度总评分", typeof(String));
            dt.Columns.Add("综合评价", typeof(String));
            dt.Columns.Add("加薪建议", typeof(String));
            dt.Columns.Add("备注", typeof(String));
            dt.Columns.Add("主管总评", typeof(String));
            foreach (string s in _360Question)
            {
                dt.Columns.Add(s, typeof(String));
            }
        }

        private void Init360Question()
        {
            _360Question = new List<string>();
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