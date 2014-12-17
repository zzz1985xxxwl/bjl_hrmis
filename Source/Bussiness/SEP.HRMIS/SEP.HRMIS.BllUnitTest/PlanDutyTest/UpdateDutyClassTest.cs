using System;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;

namespace SEP.HRMIS.BllUnitTest.PlanDutyTest
{
    [TestFixture]
    public class UpdateDutyClassTest
    {
        [Test, Description("���Ը��¿��ڹ���")]
        public void TestUpdateAttendanceRuleSuccessful()
        {
            DutyClass rule =
                new DutyClass("rules", DT(" 8:00:00"), DT(" 9:00:00"),
                DT(" 11:30:00"), DT(" 12:30:00"), DT(" 17:00:00"), 9, 60, 60, 15, 15);
            rule.DutyClassID = 2;
            MockRepository mock = new MockRepository();
            IPlanDutyDal dalRule = mock.CreateMock<IPlanDutyDal>();
            Expect.Call(dalRule.CountDutyClassByDutyClassDiffPkid(rule.DutyClassID, rule.DutyClassName)).Return(0);
            Expect.Call(dalRule.GetDutyClassByPkid(2)).Return(rule);
            Expect.Call(dalRule.UpdateDutyClass(rule)).Return(1);
            mock.ReplayAll();
            UpdateDutyClass updateRule = new UpdateDutyClass(rule, dalRule);
            updateRule.Excute();
        }

        [Test, Description("���Ը��¿��ڹ��������ظ�")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateAttendanceRuleSameName()
        {
            DutyClass rule =
                new DutyClass("rules", DT(" 8:00:00"), DT(" 9:00:00"),
                DT(" 11:30:00"), DT(" 12:30:00"), DT(" 17:00:00"), 9, 60, 60, 15, 15);
            rule.DutyClassID = 2;
            MockRepository mock = new MockRepository();
            IPlanDutyDal dalRule = mock.CreateMock<IPlanDutyDal>();
            Expect.Call(dalRule.CountDutyClassByDutyClassDiffPkid(rule.DutyClassID, rule.DutyClassName)).Return(1);
            Expect.Call(dalRule.GetDutyClassByPkid(2)).Return(rule);
            Expect.Call(dalRule.UpdateDutyClass(rule)).Return(1);
            mock.ReplayAll();
            UpdateDutyClass updateRule = new UpdateDutyClass(rule, dalRule);
            updateRule.Excute();
            Assert.Fail("���ڹ��������ظ�");
        }

        [Test, Description("���Ը��¿��ڹ��򲻴���")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateAttendanceRuleNotExist()
        {
            DutyClass rule =
                new DutyClass("rules", DT(" 8:00:00"), DT(" 9:00:00"),
                DT(" 11:30:00"), DT(" 12:30:00"), DT(" 17:00:00"), 9, 60, 60, 15, 15);
            rule.DutyClassID = 2;
            MockRepository mock = new MockRepository();
            IPlanDutyDal dalRule = mock.CreateMock<IPlanDutyDal>();
            Expect.Call(dalRule.CountDutyClassByDutyClassDiffPkid(rule.DutyClassID, rule.DutyClassName)).Return(0);
            Expect.Call(dalRule.GetDutyClassByPkid(2)).Return(null);
            Expect.Call(dalRule.UpdateDutyClass(rule)).Return(1);
            mock.ReplayAll();
            UpdateDutyClass updateRule = new UpdateDutyClass(rule, dalRule);
            updateRule.Excute();
            Assert.Fail("���ڹ��򲻴���");
        }
        private static DateTime DT(string datetime)
        {
            return Convert.ToDateTime(datetime);
        }
    }
}
