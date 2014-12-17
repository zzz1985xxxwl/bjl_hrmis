//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: InsertAttendanceInOutRecord.cs
// ������: ����
// ��������: 2008-10-20
// ����: �����������
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.Model.Accounts;
using SEP.Model.Calendar;


namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    using IDal;
    using Model;
    using Model.EmployeeAttendance.AttendanceInAndOutRecord;
    using Model.EmployeeAttendance.AttendanceStatistics;

    /// <summary>
    /// 
    /// </summary>
    public class InsertAttendanceInOutRecord : Transaction
    {
        private static IAttendanceInAndOutRecord _IRecord = DalFactory.DataAccess.CreateAttendanceInAndOutRecord();
        //private static IEmployee _DalEmployee = DalFactory.DataAccess.CreateEmployee();
        //private readonly GetEmployee getEmployee = new GetEmployee();
        private readonly Transaction _InsertLog;
        //private readonly UpdateEmployeeAttendance updateEmployeeAttendance;
        private readonly int _EmployeeId;
        private readonly AttendanceInAndOutRecord _Record;
        private Employee _Employee;
        private readonly AttendanceInAndOutRecordLog _AttendanceInAndOutRecordLog;
        private DateTime _TheDate;
        private readonly Account _LoginUser;
        /// <summary>
        /// 
        /// </summary>
        public InsertAttendanceInOutRecord(int employeeId, AttendanceInAndOutRecord record,
         AttendanceInAndOutRecordLog attendanceInAndOutRecordLog, Account loginUser)
        {
            _LoginUser = loginUser;
            //updateEmployeeAttendance = new UpdateEmployeeAttendance(_LoginUser);
            _AttendanceInAndOutRecordLog = attendanceInAndOutRecordLog;
            _InsertLog = new InsertInAndOutRecordLog(_AttendanceInAndOutRecordLog, _LoginUser);
            _EmployeeId = employeeId;
            _Record = record;
            _TheDate = record.IOTime;
            GetInAndOutRecords();
        }
        /// <summary>
        /// ������
        /// </summary>
        public InsertAttendanceInOutRecord(int employeeId, AttendanceInAndOutRecord record,
        AttendanceInAndOutRecordLog attendanceInAndOutRecordLog, IAttendanceInAndOutRecord mock, Transaction mockLog, 
            //UpdateEmployeeAttendance mockUpdateEmployeeAttendance, 
            Employee employee, Account loginUser)
        {
            _LoginUser = loginUser;
            //updateEmployeeAttendance = mockUpdateEmployeeAttendance;
            _AttendanceInAndOutRecordLog = attendanceInAndOutRecordLog;
            _InsertLog = mockLog;
            _EmployeeId = employeeId;
            _Record = record;
            _IRecord = mock;
            _TheDate = record.IOTime;
            //_DalEmployee = mockEmployee;
            //GetInAndOutRecords();
            _Employee = employee;
        }

        /// <summary>
        /// �õ�����Ա���Ľ�����¼
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
                _Employee.EmployeeAttendance = new EmployeeAttendance(_TheDate, _TheDate);
            }
            _Employee.EmployeeAttendance.AttendanceInAndOutRecordList = new List<AttendanceInAndOutRecord>();
            records.Add(_Record);
            _Employee.EmployeeAttendance.AttendanceInAndOutRecordList = records;
            _Employee.EmployeeAttendance.DayAttendanceList = new List<DayAttendance>();
            //�����Ű���Ϣ
            _Employee.EmployeeAttendance.PlanDutyDetailList =
DalFactory.DataAccess.CreatePlanDutyDal().GetPlanDutyDetailByAccount(_Employee.Account.Id,
                                                                 _TheDate, _TheDate);
        }

        protected override void Validation()
        {

        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _IRecord.UpdatetAttendanceInAndOutRecord(_Employee);
                    //������־
                    _InsertLog.Excute();
                    //���㿼��
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
        /// ���ұ��ζ�ȡ�Ŀ��ڼ�¼����ΧΪһ��
        /// </summary>
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
