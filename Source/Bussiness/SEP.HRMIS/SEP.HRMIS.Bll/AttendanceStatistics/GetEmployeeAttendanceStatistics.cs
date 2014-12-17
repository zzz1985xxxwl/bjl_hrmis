//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeAttendanceStatistics.cs
// 创建者: 王玥琦
// 创建日期: 2008-08-8
// 概述: 员工考勤统计
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.OutApplications;
using SEP.HRMIS.Bll.OverWorks;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    ///<summary>
    /// 员工考勤统计
    ///</summary>
    public class GetEmployeeAttendanceStatistics
    {
        /// <summary>
        /// 构造类工厂
        /// </summary>
        private static GetBadAttendance _GetBadAttendance;
        private static GetOutApplication _GetOutApplication;
        private static GetOverWork _GetOverWork;
        private static GetLeaveRequest _GetLeaveRequest;
        private readonly GetEmployee _GetEmployee = new GetEmployee();
        private static IEmployee _dalEmployee = DalFactory.DataAccess.CreateEmployee();
        private static IPlanDutyDal _IPlanDutyDal = DalFactory.DataAccess.CreatePlanDutyDal();
        private static IAccountBll _IAccountBll = BllInstance.AccountBllInstance;
        private static IAttendanceInAndOutRecord _dalAttendanceInAndOutRecord =
        DalFactory.DataAccess.CreateAttendanceInAndOutRecord();

        ///<summary>
        /// 构造函数
        ///</summary>
        public GetEmployeeAttendanceStatistics()
        {
            _GetLeaveRequest = new GetLeaveRequest();
            _GetOutApplication = new GetOutApplication();
            _GetOverWork = new GetOverWork();
        }

        /// <summary>
        /// for test
        /// </summary>
        /// <param name="mockEmployee"></param>
        /// <param name="mockPlanDuty"></param>
        /// <param name="mockAccount"></param>
        /// <param name="mockInAndOut"></param>
        public GetEmployeeAttendanceStatistics(IEmployee mockEmployee, IPlanDutyDal mockPlanDuty, IAccountBll mockAccount, IAttendanceInAndOutRecord mockInAndOut)
        {
            _dalEmployee = mockEmployee;
            _IPlanDutyDal = mockPlanDuty;
            _IAccountBll = mockAccount;
            _dalAttendanceInAndOutRecord = mockInAndOut;
            _GetOutApplication = new GetOutApplication();
            _GetLeaveRequest = new GetLeaveRequest();
            _GetOverWork = new GetOverWork();
        }
        ///<summary>
        /// 通过employeeID,开始结束时间得到员工的考勤信息,只获得已经结束的考勤
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="startDt"></param>
        ///<param name="endDt"></param>
        ///<returns></returns>
        public Employee GetEmployeeAttendanceByCondition(int employeeID, DateTime startDt, DateTime endDt)
        {
            _GetBadAttendance = new GetBadAttendance(null);

            Account account = _IAccountBll.GetAccountById(employeeID);
            Employee employee = _dalEmployee.GetEmployeeBasicInfoByAccountID(account.Id);
            employee.Account = account;
            if (GetEmployeeAttendanceInfo(employee, startDt, endDt))
            {
                return employee;
            }
            else
            {
                return null;
            }
        }


        ///<summary>
        /// 通过员工姓名部门，得到考勤情况,只获得已经结束的考勤
        ///</summary>
        ///<returns></returns>
        public List<Employee> GetEmployeeAttendanceByCondition(string EmployeeName, int DepartmentID,int? gradesId,
            DateTime FromDate, DateTime ToDate, Account _Account, int? powers)
        {
            _GetBadAttendance = new GetBadAttendance(_Account);

            List<Employee> retEmployeeList = new List<Employee>();
            List<Account> AccountList =
                _IAccountBll.GetAccountByBaseCondition(EmployeeName, DepartmentID, -1, gradesId, true, null);

            if (powers != null)
            {
                AccountList = Tools.RemoteUnAuthAccount(AccountList, AuthType.HRMIS, _Account, (int) powers);
            }
            List<Employee> EmployeeList = new List<Employee>();
            foreach (Account account in AccountList)
            {
                Employee employee = _dalEmployee.GetEmployeeBasicInfoByAccountID(account.Id);
                if (employee == null)
                {
                    continue;
                }
                employee.Account = account;
                EmployeeList.Add(employee);
            }

            for (int i = 0; i < EmployeeList.Count; i++)
            {
                if (GetEmployeeAttendanceInfo(EmployeeList[i], FromDate, ToDate))
                {
                    retEmployeeList.Add(EmployeeList[i]);
                }
            }
            return retEmployeeList;
        }

        /// <summary>
        /// 获得员工的考勤信息
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="FromDate"></param>
        /// <param name="ToDate"></param>
        private static bool GetEmployeeAttendanceInfo(Employee employee, DateTime FromDate, DateTime ToDate)
        {
            if (employee.EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
            {
                return false;
            }
            //根据入职离职时间确定考勤的有效时间
            DateTime employeeFromDate = DateTime.Compare(employee.EmployeeDetails.Work.ComeDate, FromDate) > 0
                                            ? employee.EmployeeDetails.Work.ComeDate
                                            : FromDate;
            DateTime employeeToDate;
            if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee && employee.EmployeeDetails.Work.DimissionInfo != null)
            {
                employeeToDate =
                    DateTime.Compare(employee.EmployeeDetails.Work.DimissionInfo.DimissionDate, ToDate) < 0
                        ? employee.EmployeeDetails.Work.DimissionInfo.DimissionDate
                        : ToDate;
            }
            else
            {
                employeeToDate = ToDate;
            }
            employeeToDate = employeeToDate.AddDays(1).AddSeconds(-1); 
            if (DateTime.Compare(employeeFromDate, employeeToDate) > 0)
            {
                return false;
            }
            employee.EmployeeAttendance = new EmployeeAttendance(employeeFromDate, employeeToDate);
            //打卡信息
            employee.EmployeeAttendance.AttendanceInAndOutRecordList =
                _dalAttendanceInAndOutRecord.GetAttendanceInAndOutRecordByCondition(employee.Account.Id, "",
                                                                                    employeeFromDate,
                                                                                    employeeToDate,
                                                                                    InOutStatusEnum.All,
                                                                                    OutInRecordOperateStatusEnum.All,
                                                                                    Convert.ToDateTime("1900-1-1"),
                                                                                    Convert.ToDateTime("2900-12-31"));
            //考勤规则
            employee.EmployeeAttendance.PlanDutyDetailList =
                _IPlanDutyDal.GetPlanDutyDetailByAccount(employee.Account.Id, employeeFromDate, employeeToDate);
            //迟到早退旷工详情
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                _GetBadAttendance.GetCalendarByEmployee(employee.Account.Id,
                                                     employee.EmployeeAttendance.FromDate,
                                                     employee.EmployeeAttendance.ToDate, AttendanceTypeEmnu.All));
            //请假详情
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                _GetLeaveRequest.GetCalendarByEmployee(employee.Account.Id,
                                                                        employee.EmployeeAttendance.FromDate,
                                                                        employee.EmployeeAttendance.ToDate));
            //加班外出申请
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                _GetOutApplication.GetCalendarByEmployee(employee.Account.Id,
                                                          employee.EmployeeAttendance.FromDate,
                                                          employee.EmployeeAttendance.ToDate));
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                _GetOverWork.GetCalendarByEmployee(employee.Account.Id,
                                          employee.EmployeeAttendance.FromDate,
                                          employee.EmployeeAttendance.ToDate));
            return true;
        }


        ///<summary>
        /// 通过员工姓名部门，得到考勤情况，获得正在进行审批或者审批结束的所有考勤
        ///</summary>
        ///<returns></returns>
        public List<Employee> GetAllEmployeeAttendanceByCondition(string EmployeeName, int DepartmentID,int? gradesId,
            DateTime FromDate, DateTime ToDate, Account _Account, int powers)
        {
            _GetBadAttendance = new GetBadAttendance(_Account);

            List<Employee> retEmployeeList = new List<Employee>();
            //List<EmployeeAttendance> EmployeeAttendanceList=new List<EmployeeAttendance>();
            //获取符合条件的员工

            List<Account> AccountList =
                _IAccountBll.GetAccountByBaseCondition(EmployeeName, DepartmentID, -1, gradesId, true, null);
            if (DepartmentID == -1)
            {
                AccountList = Tools.RemoteUnAuthAccount(AccountList, AuthType.HRMIS, _Account, powers);
            }
            List<Employee> EmployeeList = new List<Employee>();
            foreach (Account account in AccountList)
            {
                Employee employee = _GetEmployee.GetEmployeeByAccountID(account.Id);
                if (employee == null)
                {
                    continue;
                }
                employee.Account = account;
                EmployeeList.Add(employee);
            }

            for (int i = 0; i < EmployeeList.Count; i++)
            {
                if (EmployeeList[i].EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
                {
                    continue;
                }
                //根据入职离职时间确定考勤的有效时间
                DateTime employeeFromDate = DateTime.Compare(EmployeeList[i].EmployeeDetails.Work.ComeDate, FromDate) > 0
                                                ? EmployeeList[i].EmployeeDetails.Work.ComeDate
                                                : FromDate;
                DateTime employeeToDate;
                if (EmployeeList[i].EmployeeType == EmployeeTypeEnum.DimissionEmployee && EmployeeList[i].EmployeeDetails.Work.DimissionInfo != null)
                {
                    employeeToDate =
                        DateTime.Compare(EmployeeList[i].EmployeeDetails.Work.DimissionInfo.DimissionDate, ToDate) < 0
                            ? EmployeeList[i].EmployeeDetails.Work.DimissionInfo.DimissionDate
                            : ToDate;
                }
                else
                {
                    employeeToDate = ToDate;
                }
                employeeToDate = employeeToDate.AddDays(1).AddSeconds(-1);
                if (DateTime.Compare(employeeFromDate, employeeToDate) > 0)
                {
                    continue;
                }
                EmployeeList[i].EmployeeAttendance = new EmployeeAttendance(employeeFromDate, employeeToDate);
                //打卡信息
                EmployeeList[i].EmployeeAttendance.AttendanceInAndOutRecordList =
                    _dalAttendanceInAndOutRecord.GetAttendanceInAndOutRecordByCondition(EmployeeList[i].Account.Id, "",
                                                                                        employeeFromDate,
                                                                                        employeeToDate,
                                                                                        InOutStatusEnum.All,
                                                                                        OutInRecordOperateStatusEnum.All,
                                                                                        Convert.ToDateTime("1900-1-1"),
                                                                                        Convert.ToDateTime("2900-12-31"));
                //考勤规则
                EmployeeList[i].EmployeeAttendance.PlanDutyDetailList =
                    _IPlanDutyDal.GetPlanDutyDetailByAccount(EmployeeList[i].Account.Id, employeeFromDate, employeeToDate);
                //迟到早退旷工详情
                EmployeeList[i].EmployeeAttendance.DayAttendanceList.AddRange(
                    _GetBadAttendance.GetCalendarByEmployee(EmployeeList[i].Account.Id,
                                                         EmployeeList[i].EmployeeAttendance.FromDate,
                                                         EmployeeList[i].EmployeeAttendance.ToDate, AttendanceTypeEmnu.All));
                //请假详情
                EmployeeList[i].EmployeeAttendance.DayAttendanceList.AddRange(
                    _GetLeaveRequest.GetAllCalendarByEmployee(EmployeeList[i].Account.Id,
                                                                            EmployeeList[i].EmployeeAttendance.FromDate,
                                                                            EmployeeList[i].EmployeeAttendance.ToDate));
                //加班外出申请
                EmployeeList[i].EmployeeAttendance.DayAttendanceList.AddRange(
                    _GetOutApplication.GetAllCalendarByEmployee(EmployeeList[i].Account.Id,
                                                              EmployeeList[i].EmployeeAttendance.FromDate,
                                                              EmployeeList[i].EmployeeAttendance.ToDate));
                EmployeeList[i].EmployeeAttendance.DayAttendanceList.AddRange(
                    _GetOverWork.GetAllCalendarByEmployee(EmployeeList[i].Account.Id,
                                              EmployeeList[i].EmployeeAttendance.FromDate,
                                              EmployeeList[i].EmployeeAttendance.ToDate));

                retEmployeeList.Add(EmployeeList[i]);
            }
            return retEmployeeList;
        }


        ///<summary>
        /// 通过员工姓名部门，得到考勤情况，获得正在进行审批或者审批结束的所有考勤
        ///</summary>
        ///<returns></returns>
        public Employee GetAllEmployeeAttendanceByCondition(int employeeID,
            DateTime FromDate, DateTime ToDate)
        {
            _GetBadAttendance = new GetBadAttendance(null);

            Account account = _IAccountBll.GetAccountById(employeeID);
            Employee employee = _dalEmployee.GetEmployeeBasicInfoByAccountID(account.Id);
            employee.Account = account;

            if (employee.EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
            {
                return null;
            }
            //根据入职离职时间确定考勤的有效时间
            DateTime employeeFromDate = DateTime.Compare(employee.EmployeeDetails.Work.ComeDate, FromDate) > 0
                                            ? employee.EmployeeDetails.Work.ComeDate
                                            : FromDate;
            DateTime employeeToDate;
            if (employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee &&
                employee.EmployeeDetails.Work.DimissionInfo != null)
            {
                employeeToDate =
                    DateTime.Compare(employee.EmployeeDetails.Work.DimissionInfo.DimissionDate, ToDate) < 0
                        ? employee.EmployeeDetails.Work.DimissionInfo.DimissionDate
                        : ToDate;
            }
            else
            {
                employeeToDate = ToDate;
            }
            employeeToDate = employeeToDate.AddDays(1).AddSeconds(-1);
            if (DateTime.Compare(employeeFromDate, employeeToDate) > 0)
            {
                return null;
            }
            employee.EmployeeAttendance = new EmployeeAttendance(employeeFromDate, employeeToDate);
            //打卡信息
            employee.EmployeeAttendance.AttendanceInAndOutRecordList =
                _dalAttendanceInAndOutRecord.GetAttendanceInAndOutRecordByCondition(employee.Account.Id, "",
                                                                                    employeeFromDate,
                                                                                    employeeToDate,
                                                                                    InOutStatusEnum.All,
                                                                                    OutInRecordOperateStatusEnum.All,
                                                                                    Convert.ToDateTime("1900-1-1"),
                                                                                    Convert.ToDateTime("2900-12-31"));
            //考勤规则
            employee.EmployeeAttendance.PlanDutyDetailList =
                _IPlanDutyDal.GetPlanDutyDetailByAccount(employee.Account.Id, employeeFromDate, employeeToDate);
            //迟到早退旷工详情
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                _GetBadAttendance.GetCalendarByEmployee(employee.Account.Id,
                                                        employee.EmployeeAttendance.FromDate,
                                                        employee.EmployeeAttendance.ToDate, AttendanceTypeEmnu.All));
            //请假详情
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                _GetLeaveRequest.GetAllCalendarByEmployee(employee.Account.Id,
                                                          employee.EmployeeAttendance.FromDate,
                                                          employee.EmployeeAttendance.ToDate));
            //加班外出申请
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                _GetOutApplication.GetAllCalendarByEmployee(employee.Account.Id,
                                                            employee.EmployeeAttendance.FromDate,
                                                            employee.EmployeeAttendance.ToDate));
            employee.EmployeeAttendance.DayAttendanceList.AddRange(
                _GetOverWork.GetAllCalendarByEmployee(employee.Account.Id,
                                                      employee.EmployeeAttendance.FromDate,
                                                      employee.EmployeeAttendance.ToDate));

            return employee;
        }
    }
}

