//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: GetAttendanceError.cs
// Creater:  Xue.wenlong
// Date:  2009-10-21
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.SystemError;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;
using SEP.Model.Utility;
using ShiXin.Security;

namespace SEP.HRMIS.Bll.SystemErrors
{
    /// <summary>
    /// </summary>
    public class GetAttendanceError : Transaction
    {
        private readonly string _EmployeeName;
        private readonly int _DepartmentID;
        private readonly DateTime _From;
        private readonly DateTime _To;
        private readonly Account _Operator;
        private readonly int _PowerID;
        private List<SystemError> _SystemErrorList;
        private IPlanDutyDal _PlanDutyDal = new PlanDutyDal();

        ///<summary>
        ///</summary>
        public GetAttendanceError(string EmployeeName, int DepartmentID,
                                  DateTime Form, DateTime To, Account account, int powers)
        {
            _EmployeeName = EmployeeName;
            _DepartmentID = DepartmentID;
            _From = Form;
            _To = To;
            _Operator = account;
            _PowerID = powers;
            _SystemErrorList = new List<SystemError>();
        }

        /// <summary>
        /// 
        /// </summary>
        public List<SystemError> SystemErrorList
        {
            get { return _SystemErrorList; }
            set { _SystemErrorList = value; }
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            List<Employee> employeeList =
                new GetEmployeeAttendanceStatistics().GetAllEmployeeAttendanceByCondition(_EmployeeName, _DepartmentID,null,
                                                                                          _From, _To, _Operator,
                                                                                          _PowerID);
            foreach (Employee employee in employeeList)
            {
                for (DateTime from = _From; from <= _To; from = from.AddDays(1))
                {
                    employee.EmployeeAttendance.InAndOutStatistics(from);
                    bool isIncludeOutInTime;
                    string absentString;
                    if (bool.TryParse(CompanyConfig.ATTENDANCEISNORMALISINCLUDEOUTINTIME, out isIncludeOutInTime)
                        && isIncludeOutInTime && from.Date < DateTime.Now.Date &&
                        (employee.EmployeeAttendance.IsOutInTimeCondition(
                             OutInTimeConditionEnum.InOrOutTimeOnlyOneIsNull) ||
                         !employee.EmployeeAttendance.StatisticIsNormal(from, out absentString))
                        )
                    {
                        string description =
                            string.Format("{0}{1}的考勤数据异常", employee.Account.Name, from.Date.ToShortDateString());
                        SystemError error = new SystemError(description, ErrorType.AttendanceError, employee.Account.Id);
                        error.ErrorEmployee = employee;
                        error.EditUrl =
                            string.Format("{0}employeeID={1}&DepartmentID={2}&SearchFrom={3}&SearchTo={4}",
                                          ErrorType.AttendanceError.EditPageUrl,
                                          SecurityUtil.DECEncrypt(employee.Account.Id.ToString()),
                                          SecurityUtil.DECEncrypt(employee.Account.Dept.Id.ToString()),
                                          SecurityUtil.DECEncrypt(from.ToShortDateString() + " 0:00:00"),
                                          SecurityUtil.DECEncrypt(from.ToShortDateString() + " 23:59:59"));
                        error.ErrorEmployee.EmployeeAttendance.PlanDutyTableList =
                            _PlanDutyDal.GetPlanDutyTableByConditionAndAccountID(from, from, employee.Account.Id);
                        _SystemErrorList.Add(error);
                    }
                }
            }
        }
    }
}