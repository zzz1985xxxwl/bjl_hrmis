//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: InsertDutyClassTest.cs
// ������: SYY
// ��������: 2009-05-13
// ����: : ���Բ�����
// ----------------------------------------------------------------

using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;

namespace SEP.HRMIS.BllUnitTest.PlanDutyTest
{
    [TestFixture]
    public class InsertDutyClassTest
    {
        [Test, Description("���Բ�����")]
        public void TestInsertAttendanceRuleSuccessful()
        {
            DutyClass rule =
                new DutyClass("rules", DT(" 8:00:00"), DT(" 9:00:00"),
                DT(" 11:30:00"), DT(" 12:30:00"), DT(" 17:00:00"), 9, 60, 60, 15, 15);
            MockRepository mock = new MockRepository();
            IPlanDutyDal dalRule = mock.CreateMock<IPlanDutyDal>();
            Expect.Call(dalRule.CountDutyClassByDutyClassName("rules")).Return(0);
            Expect.Call(dalRule.InsertDutyClass(rule)).Return(1);
            mock.ReplayAll();
            InsertDutyClass insertRule = new InsertDutyClass(rule, dalRule);
            insertRule.Excute();
            mock.VerifyAll();
        }

        [Test, Description("���Բ����������ظ�")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestInsertAttendanceRuleSameName()
        {
            DutyClass rule =
                new DutyClass("rules", DT(" 8:00:00"), DT(" 9:00:00"),
                DT(" 11:30:00"), DT(" 12:30:00"), DT(" 17:00:00"), 9, 60, 60, 15, 15);
            MockRepository mock = new MockRepository();
            IPlanDutyDal dalRule = mock.CreateMock<IPlanDutyDal>();
            Expect.Call(dalRule.CountDutyClassByDutyClassName("rules")).Return(1);
            Expect.Call(dalRule.InsertDutyClass(rule)).Return(1);
            mock.ReplayAll();
            InsertDutyClass insertRule = new InsertDutyClass(rule, dalRule);
            insertRule.Excute();
            mock.VerifyAll();
            Assert.Fail("���ڹ��������ظ�");
        }
        private static DateTime DT(string datetime)
        {
            return Convert.ToDateTime(datetime);
        }
    }
}
