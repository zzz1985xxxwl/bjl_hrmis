//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: InsertInAndOutRecordLogTest.cs
// ������: ����
// ��������: 2008-10-23
// ����: ���Բ��뿼����־
// ----------------------------------------------------------------

using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.AttendanceStatistics
{
    [TestFixture]
    public class InsertInAndOutRecordLogTest
    {
        [Test, Description("���Բ��뿼�ڹ���")]
        public void TestInsertAttendanceRuleSuccessful()
        {
            AttendanceInAndOutRecordLog log=new  AttendanceInAndOutRecordLog();
            log.EmployeeID = 1;
            log.EmployeeName = "tester";
            log.OldIOStatus = InOutStatusEnum.In;
            log.OldIOTime = Convert.ToDateTime("2008-10-23 8:00:00");
            log.NewIOStatus = InOutStatusEnum.In;
            log.NewIOTime = Convert.ToDateTime("2008-10-13 13:00:00");
            log.OperateReason = "�޸�";
            log.OperateStatus = OutInRecordOperateStatusEnum.ModifyByOperator;
            log.OperateTime = Convert.ToDateTime("2008-10-13 13:30:00");
            log.Operator = "test";

            MockRepository mock = new MockRepository();
            IInAndOutRecordLog dalLog = mock.CreateMock<IInAndOutRecordLog>();

            Expect.Call(dalLog.InsertInAndOutRecordLog(log)).Return(1);
            mock.ReplayAll();
            InsertInAndOutRecordLog insertLog=new  InsertInAndOutRecordLog(log,dalLog,new Account());
            insertLog.Excute();
            mock.VerifyAll();
        }
    }
}
