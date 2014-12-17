//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: InsertAttendanceInOutRecordTest.cs
// ������: ����
// ��������: 2008-10-20
// ����: ���Բ��뿼�ڼ�¼
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.AttendanceStatistics
{
    [TestFixture]
    public class InsertAttendanceInOutRecordTest
    {
        [Ignore, Description("������¼")]
        public void InsertRecordTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            IAttendanceInAndOutRecord iRecord =
                (IAttendanceInAndOutRecord) mocks.CreateMock(typeof (IAttendanceInAndOutRecord));
            Transaction _BllInAndOutRecordLog = (Transaction)mocks.CreateMock(typeof(Transaction));
            //UpdateEmployeeAttendance _BllUpdateEmployeeAttendance = new UpdateEmployeeAttendance(new Account());
            //IAttendanceRule _IRule = (IAttendanceRule)mocks.CreateMock(typeof(IAttendanceRule));

            Employee employee = new Employee(new Account(1, "liu.dan", "����"), "", "", EmployeeTypeEnum.NormalEmployee, null, null);
            DateTime theDate = Convert.ToDateTime("2008-9-9 19:23:30");
            employee.EmployeeAttendance =
                new Model.EmployeeAttendance.AttendanceStatistics.EmployeeAttendance();
     
            AttendanceInAndOutRecord record = new AttendanceInAndOutRecord();
            record.RecordID = 1;
            record.IOTime = theDate;
            record.IOStatus = InOutStatusEnum.In;
            record.OperateTime = DateTime.Now;
            record.OperateStatus = OutInRecordOperateStatusEnum.AddByOperator;
            record.DoorCardNo = "123456";
            List<AttendanceInAndOutRecord> records = new List<AttendanceInAndOutRecord>();
            records.Add(record);
            AttendanceInAndOutRecordLog attendanceInAndOutRecordLog = new AttendanceInAndOutRecordLog();
            //string cardNo;
            //AttendanceRule rule = new AttendanceRule("ruleTest", Convert.ToDateTime("2008-1-1"), Convert.ToDateTime("2008-12-31"), Convert.ToDateTime("2008-12-31"), Convert.ToDateTime("2008-12-31"), 60, 60);
       employee.EmployeeAttendance.AttendanceInAndOutRecordList = records;
            //Expect.Call(
            //    iRecord.GetAttendanceInAndOutRecordByCondition(1, string.Empty, -1, string.Empty,
            //         Convert.ToDateTime("1900-1-1"),
            //        Convert.ToDateTime("2999-12-31"),
            //                                                   InOutStatusEnum.All,
            //                                                   OutInRecordOperateStatusEnum.All,
            //                                                   Convert.ToDateTime("1900-1-1"),
            //                                                   Convert.ToDateTime("2999-12-31"))
            //    ).Return(records);
            //Expect.Call(iEmployee.GetEmployeeBasicInfoByAccountID(1)).Return(employee);
            Expect.Call(delegate { iRecord.UpdatetAttendanceInAndOutRecord(employee); });

            Expect.Call(delegate { _BllInAndOutRecordLog.Excute(); });
            //Expect.Call(delegate { _BllUpdateEmployeeAttendance.UpdateEmployeeDayAttendance(employee, theDate); });
            //Expect.Call(iEmployee.GetAttendanceRuleAndDoorCardNoByAccountID(1, out cardNo)).Return(rule);

            mocks.ReplayAll();

            InsertAttendanceInOutRecord target = new InsertAttendanceInOutRecord(1, record, attendanceInAndOutRecordLog,
                iRecord, _BllInAndOutRecordLog, 
                //_BllUpdateEmployeeAttendance,
                employee,new Account());
            target.Excute();
            mocks.VerifyAll();
            Assert.IsTrue(employee.EmployeeAttendance.AttendanceInAndOutRecordList.Count > 0);
        }
    }
}
