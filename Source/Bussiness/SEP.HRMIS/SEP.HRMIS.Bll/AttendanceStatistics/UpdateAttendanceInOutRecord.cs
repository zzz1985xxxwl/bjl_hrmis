//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateAttendanceInOutRecord.cs
// 创建者: 刘丹
// 创建日期: 2008-10-20
// 概述: 更新出勤情况
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.Model.Accounts;
using SEP.Model.Calendar;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    using Model.EmployeeAttendance.AttendanceStatistics;

    ///<summary>
    ///</summary>
    public class UpdateAttendanceInOutRecord : Transaction
    {
        private static IAttendanceInAndOutRecord _IRecord = DalFactory.DataAccess.CreateAttendanceInAndOutRecord();
        //private static IEmployee _DalEmployee = DalFactory.DataAccess.CreateEmployee();
        private readonly Transaction _InsertLog;
        //private readonly UpdateEmployeeAttendance updateEmployeeAttendance;

        private readonly int _EmployeeId;
        private readonly AttendanceInAndOutRecord _Record;
        private Employee _Employee;
        private readonly AttendanceInAndOutRecordLog _AttendanceInAndOutRecordLog;
        private readonly DateTime _OldDate;
        private readonly DateTime _TheDate;
        private readonly Account _LoginUser;
        private DateTime _SearchFrom;
        private DateTime _SearchTo;

        /// <summary>
        /// 
        /// </summary>
        public UpdateAttendanceInOutRecord(int employeeId, AttendanceInAndOutRecord record,
            DateTime oldDate, AttendanceInAndOutRecordLog log, Account loginUser)
        {
            _LoginUser = loginUser;
            //updateEmployeeAttendance = new UpdateEmployeeAttendance(loginUser);
            _OldDate = oldDate;
            _AttendanceInAndOutRecordLog = log;
            _InsertLog = new InsertInAndOutRecordLog(_AttendanceInAndOutRecordLog, loginUser);
            _EmployeeId = employeeId;
            _Record = record;
            _TheDate = _Record.IOTime;
            GetInAndOutRecords();
        }
        /// <summary>
        /// 测试用
        /// </summary>
        public UpdateAttendanceInOutRecord(int employeeId, AttendanceInAndOutRecord record,
            DateTime oldDate, IAttendanceInAndOutRecord mock, Transaction logmock,
            //UpdateEmployeeAttendance mockUpdateEmployeeAttendance,
            Account loginUser)
        {
            _LoginUser = loginUser;
            //updateEmployeeAttendance = mockUpdateEmployeeAttendance;
            _OldDate = oldDate;
            _EmployeeId = employeeId;
            _Record = record;
            _TheDate = _Record.IOTime;
            _IRecord = mock;
            _InsertLog = logmock;
            GetInAndOutRecordsForTest();
        }
        /// <summary>
        /// 得到单个员工的进出记录
        /// </summary>
        private void GetInAndOutRecords()
        {
            FindSearchTime();
            _Employee = new GetEmployee().GetEmployeeBasicInfoByAccountID(_EmployeeId);
            List<AttendanceInAndOutRecord> records =
                _IRecord.GetAttendanceInAndOutRecordByCondition(_EmployeeId, string.Empty,
                                                                Convert.ToDateTime("1900-1-1"),
                                                                Convert.ToDateTime("2999-12-31"), InOutStatusEnum.All,
                                                                OutInRecordOperateStatusEnum.All,
                                                                Convert.ToDateTime("1900-1-1"),
                                                                Convert.ToDateTime("2999-12-31"));
            if (_Employee.EmployeeAttendance == null)
            {
                _Employee.EmployeeAttendance = new EmployeeAttendance(_SearchFrom,_SearchTo);
            }
            _Employee.EmployeeAttendance.AttendanceInAndOutRecordList = records;
            _Employee.EmployeeAttendance.DayAttendanceList=new List<DayAttendance>();
            //加载排班信息
            _Employee.EmployeeAttendance.PlanDutyDetailList =
DalFactory.DataAccess.CreatePlanDutyDal().GetPlanDutyDetailByAccount(_Employee.Account.Id,
                                                                 _SearchFrom, _SearchTo);
        }

        /// <summary>
        /// for test
        /// </summary>
        private void GetInAndOutRecordsForTest()
        {
            _Employee = new Employee();
            List<AttendanceInAndOutRecord> records =
                _IRecord.GetAttendanceInAndOutRecordByCondition(_EmployeeId, string.Empty,
                                                                Convert.ToDateTime("1900-1-1"),
                                                                Convert.ToDateTime("2999-12-31"), InOutStatusEnum.All,
                                                                OutInRecordOperateStatusEnum.All,
                                                                Convert.ToDateTime("1900-1-1"),
                                                                Convert.ToDateTime("2999-12-31"));
            _Employee.EmployeeAttendance = new EmployeeAttendance();
            _Employee.EmployeeAttendance.AttendanceInAndOutRecordList = records;
        }

        protected override void Validation()
        {
            AttendanceInAndOutRecord temp = _Employee.EmployeeAttendance.FindInAndOutRecordByRecordId(_Record.RecordID);
            if (temp == null)
            {
                BllUtility.ThrowException(BllExceptionConst._AttendanceInAndOut_Not_Exist);
            }
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    //更新员工进出信息
                    _Employee.EmployeeAttendance.RemoveInAndOutRecordByRecordId(_Record.RecordID);
                    _Employee.EmployeeAttendance.AttendanceInAndOutRecordList.Add(_Record);
                    _IRecord.UpdatetAttendanceInAndOutRecord(_Employee);
                    //插入日志
                    _InsertLog.Excute();

                    //计算考勤
                    List<AttendanceInAndOutRecord> allRecords;
                    List<AttendanceInAndOutRecord> records =
                        _Employee.EmployeeAttendance.AttendanceInAndOutRecordList.FindAll(
                            FindOldAttendanceInAndOutRecord);
                    allRecords = records;
                    if (!_TheDate.Date.Equals(_OldDate.Date))
                    {
                        records =
                            _Employee.EmployeeAttendance.AttendanceInAndOutRecordList.FindAll(
                                FindNewAttendanceInAndOutRecord);
                        allRecords.AddRange(records);
                    }
                    _Employee.EmployeeAttendance.AttendanceInAndOutRecordList = allRecords;
                    //updateEmployeeAttendance.UpdateEmployeeDayAttendanceWithOld(_Employee, _TheDate, _OldDate);

                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
        /// <summary>
        /// 查找上次读取的考勤记录，范围为一天
        /// </summary>
        private bool FindOldAttendanceInAndOutRecord(AttendanceInAndOutRecord attendanceInAndOutRecord)
        {
            if ((DateTime.Compare(attendanceInAndOutRecord.IOTime,
                                  new DateTime(_OldDate.Year, _OldDate.Month, _OldDate.Day, 0, 0, 0))) >= 0 &&
                (DateTime.Compare(attendanceInAndOutRecord.IOTime,
                                  new DateTime(_OldDate.Year, _OldDate.Month, _OldDate.Day, 23, 59, 59))) <= 0)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 查找这次读取的考勤记录，范围为一天
        /// </summary>
        private bool FindNewAttendanceInAndOutRecord(AttendanceInAndOutRecord attendanceInAndOutRecord)
        {
            if ((DateTime.Compare(attendanceInAndOutRecord.IOTime,
                                  new DateTime(_TheDate.Year, _TheDate.Month, _TheDate.Day, 0, 0, 0))) >= 0 &&
                (DateTime.Compare(attendanceInAndOutRecord.IOTime,
                                  new DateTime(_TheDate.Year, _TheDate.Month, _TheDate.Day, 23, 59, 59))) <= 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 比较查询排班表时间
        /// </summary>
        /// <returns></returns>
        private void FindSearchTime()
        {
            if ((DateTime.Compare(_OldDate,_TheDate)>= 0))
            {
                _SearchTo = _OldDate;
                _SearchFrom = _TheDate;
            }
            else
            {
                _SearchTo = _TheDate;
                _SearchFrom = _OldDate;
            }
        }

    }
}

