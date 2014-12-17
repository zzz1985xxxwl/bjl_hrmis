//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AttendanceOutInRecordTest.cs
// 创建者: wyq
// 创建日期: 2008-11-26
// 概述: 测试考勤进出记录
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.AttendanceStatistics
{
    [TestFixture]
    public class AttendanceOutInRecordTest
    {
        [Test, Description("Test GetEmployeeInAndOutRecordByEmployeeId")]
        public void GetEmployeeInAndOutRecordByEmployeeIdTest()
        {
            MockRepository mocks = new MockRepository();

            IEmployee dalEmployee = mocks.CreateMock<IEmployee>();
            IAttendanceInAndOutRecord dalAttendanceInAndOutRecord = mocks.CreateMock<IAttendanceInAndOutRecord>();
            IAccountBll dalAccountBll = mocks.CreateMock<IAccountBll>();

            Employee employee = new Employee(new Account(1,"1", "1"), "", "", EmployeeTypeEnum.NormalEmployee, null, null);
            employee.EmployeeAttendance =
                new Model.EmployeeAttendance.AttendanceStatistics.EmployeeAttendance();
            employee.EmployeeAttendance.DoorCardNo = "test01";
            AttendanceInAndOutRecord record1 = new AttendanceInAndOutRecord();
            record1.DoorCardNo = "test01";
            record1.RecordID = 1;
            AttendanceInAndOutRecord record2 = new AttendanceInAndOutRecord();
            record2.DoorCardNo = "test01";
            record2.RecordID = 2;
            AttendanceInAndOutRecord record3 = new AttendanceInAndOutRecord();
            record3.DoorCardNo = "test01";
            record3.RecordID = 3;

            List<AttendanceInAndOutRecord> records = new List<AttendanceInAndOutRecord>();
            records.Add(record1);
            records.Add(record2);
            records.Add(record3);

            Expect.Call(dalEmployee.GetEmployeeBasicInfoByAccountID(1)).Return(employee);
            Expect.Call(dalAttendanceInAndOutRecord.GetAttendanceInAndOutRecordByCondition(employee.Account.Id, "", 
                                                                                           Convert.ToDateTime("1900-1-1"),
                                                                                           Convert.ToDateTime(
                                                                                               "2900-12-31"),
                                                                                           InOutStatusEnum.All,
                                                                                           OutInRecordOperateStatusEnum.
                                                                                               All,
                                                                                           Convert.ToDateTime("1900-1-1"),
                                                                                           Convert.ToDateTime(
                                                                                               "2900-12-31"))).Return(
                records);
            mocks.ReplayAll();

            AttendanceOutInRecord attendanceOutInRecord = 
                new AttendanceOutInRecord(dalEmployee, dalAttendanceInAndOutRecord,dalAccountBll,new Account());
            Employee employee1 = attendanceOutInRecord.GetEmployeeInAndOutRecordByEmployeeId(1);

            mocks.VerifyAll();

            Assert.AreEqual(employee1.Account.Id, employee.Account.Id);

            Assert.AreEqual(3, employee1.EmployeeAttendance.AttendanceInAndOutRecordList.Count);
            Assert.IsTrue(employee1.EmployeeAttendance.AttendanceInAndOutRecordList.Contains(record1));
            Assert.IsTrue(employee1.EmployeeAttendance.AttendanceInAndOutRecordList.Contains(record2));
            Assert.IsTrue(employee1.EmployeeAttendance.AttendanceInAndOutRecordList.Contains(record3));

            //Assert.AreEqual(doorNo, employee1.EmployeeAttendance.DoorCardNo);
            //Assert.AreEqual(rule, employee1.EmployeeAttendance.AttendanceRule);
        }
    }
}
