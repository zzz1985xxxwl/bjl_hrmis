//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateAttendanceInOutRecordTest.cs
// 创建者: 刘丹
// 创建日期: 2008-10-20
// 概述: 测试删除考勤记录
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
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics;

namespace SEP.HRMIS.BllUnitTest.AttendanceStatistics
{
    [TestFixture]
    public class DeleteAttendanceInOutRecordTest
    {
        [Test, Description("删除记录")]
        public void DeleteRecordTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            IAttendanceInAndOutRecord iRecord =
                (IAttendanceInAndOutRecord)mocks.CreateMock(typeof(IAttendanceInAndOutRecord));
            Transaction _BllInAndOutRecordLog = (Transaction)mocks.CreateMock(typeof(Transaction));
            //UpdateEmployeeAttendance _BllUpdateEmployeeAttendance =
            //    mocks.DynamicMock<UpdateEmployeeAttendance>(new Account());

            Employee employee = new Employee();
            employee.EmployeeAttendance = new EmployeeAttendance();
            AttendanceInAndOutRecord record = new AttendanceInAndOutRecord();
            List<AttendanceInAndOutRecord> records = new List<AttendanceInAndOutRecord>();
            DateTime oldDate = Convert.ToDateTime("2008-9-9 19:23:30");
            DateTime theDate = Convert.ToDateTime("2008-9-9 15:23:30");
            record.IOStatus = InOutStatusEnum.Out;
            record.OperateStatus = OutInRecordOperateStatusEnum.ModifyByOperator;
            record.IOTime = theDate;
            records.Add(record);
            employee.EmployeeAttendance.AttendanceInAndOutRecordList = records;

            Expect.Call(
                iRecord.GetAttendanceInAndOutRecordByCondition(1, string.Empty,
                                                               Convert.ToDateTime("1900-1-1"),
                                                               Convert.ToDateTime("2999-12-31"),
                                                               InOutStatusEnum.All,
                                                               OutInRecordOperateStatusEnum.All,
                                                               Convert.ToDateTime("1900-1-1"),
                                                               Convert.ToDateTime("2999-12-31"))
                ).Return(records);
            //Expect.Call(delegate { iRecord.UpdatetAttendanceInAndOutRecord(employee); });
            Expect.Call(delegate { _BllInAndOutRecordLog.Excute(); });
            //Expect.Call(delegate { _BllUpdateEmployeeAttendance.UpdateEmployeeDayAttendanceWithOld(employee, theDate, oldDate); });

            mocks.ReplayAll();

            DeleteAttendanceInOutRecord target = new DeleteAttendanceInOutRecord(1, theDate, iRecord,
                _BllInAndOutRecordLog, 
                //_BllUpdateEmployeeAttendance,
                new Account());
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "数据库访问错误");
            }
        }

        [Ignore, Description("删除的记录不存在")]
        [ExpectedException(typeof(ApplicationException))]
        public void DeleteRecordTestNotExist()
        {
            MockRepository mocks = new MockRepository();
            IAttendanceInAndOutRecord iRecord =
                (IAttendanceInAndOutRecord)mocks.CreateMock(typeof(IAttendanceInAndOutRecord));
            Transaction _BllInAndOutRecordLog = (Transaction)mocks.CreateMock(typeof(Transaction));
            //UpdateEmployeeAttendance _BllUpdateEmployeeAttendance =
            //    mocks.DynamicMock<UpdateEmployeeAttendance>(new Account());

            Employee employee = new Employee();
            employee.EmployeeAttendance = new EmployeeAttendance();
            List<AttendanceInAndOutRecord> records = new List<AttendanceInAndOutRecord>();
            DateTime oldDate = Convert.ToDateTime("2008-9-9 19:23:30");
            employee.EmployeeAttendance.AttendanceInAndOutRecordList = records;

            Expect.Call(
                iRecord.GetAttendanceInAndOutRecordByCondition(1, string.Empty, 
                                                               Convert.ToDateTime("1900-1-1"),
                                                               Convert.ToDateTime("2999-12-31"),
                                                               InOutStatusEnum.All,
                                                               OutInRecordOperateStatusEnum.All,
                                                               Convert.ToDateTime("1900-1-1"),
                                                               Convert.ToDateTime("2999-12-31"))
                ).Return(records);

            mocks.ReplayAll();
            DeleteAttendanceInOutRecord target = new DeleteAttendanceInOutRecord(1,oldDate, iRecord,
                _BllInAndOutRecordLog, 
                //_BllUpdateEmployeeAttendance, 
                new Account());
            try
            {
                target.Excute();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "改进出记录不存在");
            }
        }
    }
}
