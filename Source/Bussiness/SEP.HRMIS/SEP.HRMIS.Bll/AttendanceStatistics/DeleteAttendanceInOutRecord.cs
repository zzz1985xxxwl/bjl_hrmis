//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteAttendanceInOutRecord.cs
// 创建者: 刘丹
// 创建日期: 2008-10-20
// 概述: 删除出勤情况
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;
using SEP.Model.Calendar;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    using Model.EmployeeAttendance.AttendanceStatistics;

    /// <summary>
    /// 
    /// </summary>
    public class DeleteAttendanceInOutRecord :Transaction
    {
        private static IAttendanceInAndOutRecord _IRecord = new AttendanceInAndOutRecordDal();
        //private static IEmployee _DalEmployee = new Employee();

        private readonly int _EmployeeId;
        private readonly int _RecordId;
        private Employee _Employee;
        private readonly Transaction _InsertLog;
        //private readonly UpdateEmployeeAttendance updateEmployeeAttendance;

        private readonly AttendanceInAndOutRecordLog _AttendanceInAndOutRecordLog;
        private readonly DateTime _TheDate;
        private readonly Account _LoginUser;

        /// <summary>
        /// 
        /// </summary>
        public DeleteAttendanceInOutRecord(int employeeId, int recordId,
            DateTime theDate, AttendanceInAndOutRecordLog attendanceInAndOutRecordLog, Account loginUser)
        {
            _LoginUser = loginUser;
            _AttendanceInAndOutRecordLog = attendanceInAndOutRecordLog;
            _InsertLog = new InsertInAndOutRecordLog(_AttendanceInAndOutRecordLog, _LoginUser);
            //updateEmployeeAttendance = new UpdateEmployeeAttendance(_LoginUser);
            _TheDate = theDate;
            _EmployeeId = employeeId;
            _RecordId = recordId;
            GetInAndOutRecords();
        }
        /// <summary>
        /// 测试用
        /// </summary>
        public DeleteAttendanceInOutRecord(int employeeId, DateTime theDate,IAttendanceInAndOutRecord mock, Transaction mockLog,
            //UpdateEmployeeAttendance mockUpdateEmployeeAttendance,
            Account loginUser)
        {
            _LoginUser = loginUser;
            //updateEmployeeAttendance = mockUpdateEmployeeAttendance;
            _InsertLog = mockLog;
            _TheDate = theDate;
            _EmployeeId = employeeId;
            _IRecord = mock;
            GetInAndOutRecordsForTest();
        }

        /// <summary>
        /// 获取进出记录
        /// </summary>
        private void GetInAndOutRecords()
        {
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
                _Employee.EmployeeAttendance = new EmployeeAttendance(DateTime.Now, DateTime.Now);
            }
            _Employee.EmployeeAttendance.AttendanceInAndOutRecordList = records;
            _Employee.EmployeeAttendance.DayAttendanceList = new List<DayAttendance>();
            //加载排班信息
            _Employee.EmployeeAttendance.PlanDutyDetailList =
new PlanDutyDal().GetPlanDutyDetailByAccount(_Employee.Account.Id,
                                                                 _TheDate, _TheDate);

        }

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
            _Employee.EmployeeAttendance = new EmployeeAttendance(DateTime.Now, DateTime.Now);
            _Employee.EmployeeAttendance.AttendanceInAndOutRecordList = records;

        }

        protected override void Validation()
        {
            AttendanceInAndOutRecord temp = _Employee.EmployeeAttendance.FindInAndOutRecordByRecordId(_RecordId);
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
                    _Employee.EmployeeAttendance.RemoveInAndOutRecordByRecordId(_RecordId);
                    _IRecord.UpdatetAttendanceInAndOutRecord(_Employee);

                    //插入日志
                    _InsertLog.Excute();
                    //计算考勤
                    List<AttendanceInAndOutRecord> records =
                        _Employee.EmployeeAttendance.AttendanceInAndOutRecordList.FindAll(FindAttendanceInAndOutRecord);
                    _Employee.EmployeeAttendance.AttendanceInAndOutRecordList = records;
                    //updateEmployeeAttendance.UpdateEmployeeDayAttendance(_Employee, _TheDate);
                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        /// <summary>
        /// insert,update,delete 存在这个相同方法，但是不好复用
        /// </summary>
        /// <param name="attendanceInAndOutRecord"></param>
        /// <returns></returns>
        private bool FindAttendanceInAndOutRecord(AttendanceInAndOutRecord attendanceInAndOutRecord)
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
    }
}
