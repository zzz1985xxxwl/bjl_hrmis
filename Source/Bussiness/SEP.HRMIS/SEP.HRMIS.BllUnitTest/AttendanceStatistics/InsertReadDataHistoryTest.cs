//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: InsertReadDataHistoryTest.cs
// ������: ����
// ��������: 2008-10-16
// ����: ���Բ����ȡ��¼
// ----------------------------------------------------------------
using System;
using NUnit.Framework;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.HRMIS.IDal;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.AttendanceStatistics
{
    [TestFixture]
    public class InsertReadDataHistoryTest
    {
        [Test, Description("���Բ��뿼�ڶ�ȡ���")]
        public void TestInsertReadDataHistorySuccessful()
        {
            ReadDataHistory history =
                new ReadDataHistory(Convert.ToDateTime("2008-10-13 9:00:00"), ReadDataResultType.Reading,"");
            MockRepository mock = new MockRepository();
            IReadDataHistory dal = mock.CreateMock<IReadDataHistory>();
            Expect.Call(dal.InsertReadDataHistory(history)).Return(1);
            mock.ReplayAll();
            InsertReadDataHistory insert = new InsertReadDataHistory(history, dal, new Account());
            insert.Excute();
            mock.VerifyAll();
        }
    }
}
