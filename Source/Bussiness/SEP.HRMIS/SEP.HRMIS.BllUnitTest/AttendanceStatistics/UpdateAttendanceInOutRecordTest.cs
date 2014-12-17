//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateAttendanceInOutRecordTest.cs
// 创建者: 刘丹
// 创建日期: 2008-10-20
// 概述: 测试修改考勤记录
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
    public class UpdateAttendanceInOutRecordTest
    {
        [Test, Description("修改记录")]
        public void UpdateRecordTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            IAttendanceInAndOutRecord iRecord =
                (IAttendanceInAndOutRecord) mocks.CreateMock(typeof (IAttendanceInAndOutRecord));
            Transaction _BllInAndOutRecordLog = (Transaction) mocks.CreateMock(typeof (Transaction));
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
            //AttendanceInAndOutRecordLog attendanceInAndOutRecordLog = new AttendanceInAndOutRecordLog();
            //string cardNo;
            //AttendanceRule rule = new AttendanceRule("ruleTest", Convert.ToDateTime("2008-1-1"),
            //                                         Convert.ToDateTime("2008-12-31"), Convert.ToDateTime("2008-12-31"),
            //                                         Convert.ToDateTime("2008-12-31"), 60, 60);

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
            UpdateAttendanceInOutRecord target = new UpdateAttendanceInOutRecord(1, record, oldDate, iRecord,_BllInAndOutRecordLog,
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
   
            //mocks.
            Assert.AreEqual(theDate, employee.EmployeeAttendance.AttendanceInAndOutRecordList[0].IOTime);
            Assert.AreEqual(InOutStatusEnum.Out, employee.EmployeeAttendance.AttendanceInAndOutRecordList[0].IOStatus);
            Assert.AreEqual(OutInRecordOperateStatusEnum.ModifyByOperator,
                            employee.EmployeeAttendance.AttendanceInAndOutRecordList[0].OperateStatus);
        }

        [Test, Description("修改记录,修改的时间不是同一天")]
        public void UpdateRecordDiffDateTestSuccess()
        {
            MockRepository mocks = new MockRepository();
            IAttendanceInAndOutRecord iRecord =
                (IAttendanceInAndOutRecord)mocks.CreateMock(typeof(IAttendanceInAndOutRecord));
            IEmployee iEmployee = (IEmployee)mocks.CreateMock(typeof(IEmployee));
            Transaction _BllInAndOutRecordLog = (Transaction)mocks.CreateMock(typeof(Transaction));
            //UpdateEmployeeAttendance _BllUpdateEmployeeAttendance = mocks.DynamicMock<UpdateEmployeeAttendance>(new Account());

            Employee employee = new Employee(new Account(1, "liu.dan", "刘丹"), "", "", EmployeeTypeEnum.NormalEmployee, null, null);
            AttendanceInAndOutRecord record = new AttendanceInAndOutRecord();
            List<AttendanceInAndOutRecord> records = new List<AttendanceInAndOutRecord>();
            DateTime oldDate = Convert.ToDateTime("2008-9-9 19:23:30");
            DateTime theDate = Convert.ToDateTime("2008-9-10 15:23:30");
            record.IOTime = oldDate;
            records.Add(record);

            Expect.Call(
                iRecord.GetAttendanceInAndOutRecordByCondition(1, string.Empty, 
                    Convert.ToDateTime("1900-1-1"),
                    Convert.ToDateTime("2999-12-31"),
                                                               InOutStatusEnum.All,
                                                               OutInRecordOperateStatusEnum.All,
                                                               Convert.ToDateTime("1900-1-1"),
                                                               Convert.ToDateTime("2999-12-31"))
                ).Return(records);
            Expect.Call(iEmployee.GetEmployeeByAccountID(1)).Return(employee);
            Expect.Call(delegate { iRecord.UpdatetAttendanceInAndOutRecord(employee); });
            Expect.Call(delegate { _BllInAndOutRecordLog.Excute(); });
            //Expect.Call(_BllUpdateEmployeeAttendance.UpdateEmployeeDayAttendanceWithOld(employee, theDate, oldDate));
            //Expect.Call(iEmployee.GetAttendanceRuleAndDoorCardNoByAccountID(1, out cardNo)).Return(rule);

            //note colbert 2
            //mocks.ReplayAll();
            //record.IOStatus = InOutStatusEnum.Out;
            //record.OperateStatus = OutInRecordOperateStatusEnum.ModifyByOperator;
            //record.IOTime = theDate;
            //UpdateAttendanceInOutRecord target = new UpdateAttendanceInOutRecord(1, record,
            //    oldDate, attendanceInAndOutRecordLog, iRecord, iEmployee, _BllInAndOutRecordLog,
            //    _BllUpdateEmployeeAttendance);
            //target.Excute();
            //mocks.VerifyAll();
            //Assert.AreEqual(theDate, employee.EmployeeAttendance.AttendanceInAndOutRecordList[0].IOTime);
            //Assert.AreEqual(InOutStatusEnum.Out, employee.EmployeeAttendance.AttendanceInAndOutRecordList[0].IOStatus);
            //Assert.AreEqual(OutInRecordOperateStatusEnum.ModifyByOperator,
            //                employee.EmployeeAttendance.AttendanceInAndOutRecordList[0].OperateStatus);
        }

        [Ignore, Description("修改的记录不存在")]
        //[ExpectedException(typeof(ApplicationException))]
        public void UpdateRecordTestNotExist()
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
            UpdateAttendanceInOutRecord target = new UpdateAttendanceInOutRecord(1, record, oldDate, iRecord, _BllInAndOutRecordLog,
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
            //mocks.VerifyAll();

        }
    }
}
