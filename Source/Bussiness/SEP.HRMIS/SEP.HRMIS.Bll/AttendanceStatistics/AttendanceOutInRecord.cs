//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AttendanceOutInRecord.cs
// ������: ���h��
// ��������: 2008-10-16
// ����: Ա�����ڽ�����¼
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;
using SEP.HRMIS.Bll.OutApplications;
using SEP.HRMIS.Bll.OverWorks;
using SEP.Model.Utility;
using SEP.Model.Calendar;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    /// <summary>
    /// 
    /// </summary>
    public class AttendanceOutInRecord
    {
        private readonly IEmployee _dalEmployee = new EmployeeDal();
        private readonly IAttendanceInAndOutRecord _dalAttendanceInAndOutRecord = new AttendanceInAndOutRecordDal();
        private readonly IAccountBll _IAccountBll;
        private GetEmployee _GetEmployee;
        private readonly Account _LoginUser;

        /// <summary>
        /// 
        /// </summary>
        public AttendanceOutInRecord(Account loginUser)
        {
            _LoginUser = loginUser;
            _IAccountBll = BllInstance.AccountBllInstance;
        }
        /// <summary>
        /// ����ר��
        /// </summary>
        public AttendanceOutInRecord(IEmployee mockEmployee, IAttendanceInAndOutRecord dalAttendanceInAndOutRecord, IAccountBll mockAccountBll, Account loginUser)
        {
            _dalEmployee = mockEmployee;
            _LoginUser = loginUser;
            _dalAttendanceInAndOutRecord = dalAttendanceInAndOutRecord;
            _IAccountBll = mockAccountBll;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Employee> GetAttendanceOutInRecordByCondition(string employeeName, int? gradesId,int departmentID,
            DateTime from, DateTime to, OutInTimeConditionEnum outInTimeCondition)
        {
            List<Employee> retEmployeeList = new List<Employee>();

            //List<Account> accountList = _IAccountBll.GetAccountByBaseCondition(employeeName, departmentID, -1, gradesId, true, null);
            //if (departmentID == -1)
            //{
            //    accountList = Tools.RemoteUnAuthAccount(accountList, AuthType.HRMIS, _LoginUser, HrmisPowers.A503);
            //}

            //_GetEmployee = new GetEmployee();
            //List<Employee> EmployeeList = _GetEmployee.GetEmployeeAttendenceInfoByAccountList(accountList, EmployeeTypeEnum.All, -1);
            int? powerID = null;
            if (departmentID == -1)
            {
                powerID = HrmisPowers.A503;
            }
            var EmployeeList = EmployeeLogic.GetEmployeeBasicInfoByBasicConditionRetModel(employeeName,
                EmployeeTypeEnum.All, -1, gradesId, departmentID, null, true, powerID, _LoginUser.Id, -1,
                new List<int>() { (int)EmployeeTypeEnum.BorrowedEmployee });

            for (int i = 0; i < EmployeeList.Count; i++)
            {
                if (EmployeeList[i].EmployeeType == EmployeeTypeEnum.BorrowedEmployee)
                {
                    continue;
                }
                //��ȡ�Ű���Ϣ
                EmployeeList[i].EmployeeAttendance.PlanDutyDetailList = 
                    new PlanDutyDal().GetPlanDutyDetailByAccount(
                    EmployeeList[i].Account.Id, from, to);
                //���Ա��û���Ű���Ϣ
                if (EmployeeList[i].EmployeeAttendance.PlanDutyDetailList == null 
                    || EmployeeList[i].EmployeeAttendance.PlanDutyDetailList.Count == 0)
                {
                    continue;
                }

                DateTime employeeFromDate = DateTime.Compare(EmployeeList[i].EmployeeDetails.Work.ComeDate, from) > 0
                                                ? EmployeeList[i].EmployeeDetails.Work.ComeDate
                                                : from;
                DateTime employeeToDate;
                if (EmployeeList[i].EmployeeType == EmployeeTypeEnum.DimissionEmployee
                    && EmployeeList[i].EmployeeDetails.Work.DimissionInfo != null)
                {
                    employeeToDate =
                        DateTime.Compare(EmployeeList[i].EmployeeDetails.Work.DimissionInfo.DimissionDate, to) < 0
                            ? EmployeeList[i].EmployeeDetails.Work.DimissionInfo.DimissionDate
                            : to;
                }
                else
                {
                    employeeToDate = to;
                }
                if (DateTime.Compare(employeeFromDate, employeeToDate) > 0)
                {
                    continue;
                }
                EmployeeList[i].EmployeeAttendance.FromDate = employeeFromDate;
                EmployeeList[i].EmployeeAttendance.ToDate = employeeToDate;
                EmployeeList[i].EmployeeAttendance.AttendanceInAndOutRecordList =
                    _dalAttendanceInAndOutRecord.GetAttendanceInAndOutRecordByCondition(EmployeeList[i].Account.Id, "",
                                                                                        from, to, InOutStatusEnum.All,
                                                                                        OutInRecordOperateStatusEnum.All,
                                                                                        Convert.ToDateTime("1900-1-1"),
                                                                                        Convert.ToDateTime("2900-12-31"));

                //����ϸ
                EmployeeList[i].EmployeeAttendance.DayAttendanceList = new List<DayAttendance>();
                EmployeeList[i].EmployeeAttendance.DayAttendanceList.AddRange(new GetBadAttendance(_LoginUser).GetCalendarByEmployee(EmployeeList[i].Account.Id,
                                                         EmployeeList[i].EmployeeAttendance.FromDate,
                                                         EmployeeList[i].EmployeeAttendance.ToDate, AttendanceTypeEmnu.All));

                //���
                EmployeeList[i].EmployeeAttendance.DayAttendanceList.AddRange(
                    new GetLeaveRequest().GetCalendarByEmployee(EmployeeList[i].Account.Id, from, to));

                //�Ӱ�
                EmployeeList[i].EmployeeAttendance.DayAttendanceList.AddRange(
                    new GetOverWork().GetCalendarByEmployee(EmployeeList[i].Account.Id, from, to));

                //���
                EmployeeList[i].EmployeeAttendance.DayAttendanceList.AddRange(
                    new GetOutApplication().GetCalendarByEmployee(EmployeeList[i].Account.Id, from, to));

                //ͳ�ƿ���
                EmployeeList[i].EmployeeAttendance.InAndOutStatistics(employeeFromDate);
                if (EmployeeList[i].EmployeeAttendance.IsOutInTimeCondition(outInTimeCondition))
                {
                    retEmployeeList.Add(EmployeeList[i]);
                }
            }
            return retEmployeeList;
        }

        /// <summary>
        /// ���ڲ�ѯĳ��Ա��������Ϣ
        /// </summary>
        public List<AttendanceInAndOutRecord> GetEmployeeInAndOutRecordByCondition(int employeeID, string employeeName,
                                                                                   int departmentID, string doorCardNo,
                                                                                   DateTime iOTimeFrom,
                                                                                   DateTime iOTimeTo,
                                                                                   InOutStatusEnum iOStatus,
                                                                                   OutInRecordOperateStatusEnum
                                                                                       operateStatus,
                                                                                   DateTime operateTimeFrom,
                                                                                   DateTime operateTimeTo)
        {
            List<Account> accountList = _IAccountBll.GetAccountByBaseCondition(employeeName, departmentID, -1, null, true, null);
            if (departmentID == -1)
            {
                accountList = Tools.RemoteUnAuthAccount(accountList, AuthType.HRMIS, _LoginUser, HrmisPowers.A504);
            }

            List<AttendanceInAndOutRecord> records =
                _dalAttendanceInAndOutRecord.GetAttendanceInAndOutRecordByCondition(employeeID, doorCardNo, iOTimeFrom,
                                                                                    iOTimeTo,
                                                                                    iOStatus, operateStatus,
                                                                                    operateTimeFrom,
                                                                                    operateTimeTo);

            for (int i = records.Count - 1; i >= 0; i--)
            {
                Account temp = Tools.FindAccountById(accountList, records[i].EmployeeId);

                if (temp == null)
                    records.RemoveAt(i);
                else
                {
                    records[i].EmployeeName = temp.Name;
                }
            }
            return records;
        }
        /// <summary>
        /// ͨ��Ա��ID���ҳ�Ա���ĳ�����Ϣ
        /// </summary>
        public Employee GetEmployeeInAndOutRecordByEmployeeId(int employeeId)
        {
            Employee employee = _dalEmployee.GetEmployeeBasicInfoByAccountID(employeeId);
            if (employee.EmployeeAttendance == null)
            {
                employee.EmployeeAttendance = new EmployeeAttendance(Convert.ToDateTime("1900-1-1"),
                                                                     Convert.ToDateTime("2900-12-31"));
            }
            employee.EmployeeAttendance.AttendanceInAndOutRecordList =
                _dalAttendanceInAndOutRecord.GetAttendanceInAndOutRecordByCondition(employee.Account.Id, "",
                                                                                    Convert.ToDateTime("1900-1-1"),
                                                                                    Convert.ToDateTime("2900-12-31"),
                                                                                    InOutStatusEnum.All,
                                                                                    OutInRecordOperateStatusEnum.All,
                                                                                    Convert.ToDateTime("1900-1-1"),
                                                                                    Convert.ToDateTime("2900-12-31"));
            return employee;
        }


        /// <summary>
        /// �õ�Ա���Լ��Ľ�����¼
        /// </summary>
        public List<AttendanceInAndOutRecord> GetSelfAttendanceInAndOutRecordByCondition(int accountid, DateTime from,
                                                                                       DateTime to)
        {
            return _dalAttendanceInAndOutRecord.GetAttendanceInAndOutRecordByCondition(accountid, "",
                                                                                      from, to, InOutStatusEnum.All,
                                                                                      OutInRecordOperateStatusEnum.All,
                                                                                      Convert.ToDateTime("1900-1-1"),
                                                                                      Convert.ToDateTime("2900-12-31"));
        }

    }
}
