using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.PlanDutyTest
{
    [TestFixture]
    public class InsertPlanDutyTest
    {
        [Test, Description("≤‚ ‘≤Â»Î≈≈∞‡±Ì")]
        public void TestInsertAttendanceRuleSuccessful()
        {
            PlanDutyTable planDutyTable = new PlanDutyTable();
            planDutyTable.PlanDutyTableName = "1";
            planDutyTable.Period = 7;
            planDutyTable.FromTime = Convert.ToDateTime("2008-02-02");
            planDutyTable.ToTime = Convert.ToDateTime("2008-02-03");
            planDutyTable.PlanDutyDetailList = new List<PlanDutyDetail>();
            planDutyTable.PlanDutyAccountList = new List<Account>();
            MockRepository mock = new MockRepository();
            IPlanDutyDal dalRule = mock.CreateMock<IPlanDutyDal>();
            List<Account> accounts = new List<Account>();
            Expect.Call(dalRule.CountPlanDutyTableByPlanDutyTableName("1")).Return(0);
            Expect.Call(dalRule.InsertPlanDutyTable(planDutyTable, accounts)).Return(1);
            mock.ReplayAll();
            InsertPlanDuty insertRule = new InsertPlanDuty(planDutyTable, dalRule);
            insertRule.Excute();
            mock.VerifyAll();
        }

        [Test, Description("≤‚ ‘≤Â»Î≈≈∞‡±Ì√˚≥∆÷ÿ∏¥")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestInsertAttendanceRuleSameName()
        {
            PlanDutyTable planDutyTable = new PlanDutyTable();
            planDutyTable.PlanDutyTableName = "1";
            planDutyTable.Period = 7;
            planDutyTable.FromTime = Convert.ToDateTime("2008-02-02");
            planDutyTable.ToTime = Convert.ToDateTime("2008-02-03");
            planDutyTable.PlanDutyDetailList = new List<PlanDutyDetail>();
            MockRepository mock = new MockRepository();
            IPlanDutyDal dalRule = mock.CreateMock<IPlanDutyDal>();
            List<Account> accounts = new List<Account>();
            Expect.Call(dalRule.CountPlanDutyTableByPlanDutyTableName("1")).Return(1);
            Expect.Call(dalRule.InsertPlanDutyTable(planDutyTable, accounts)).Return(1);
            mock.ReplayAll();
            InsertPlanDuty insertRule = new InsertPlanDuty(planDutyTable, dalRule);
            insertRule.Excute();
            mock.VerifyAll();
            Assert.Fail("≈≈∞‡±Ì√˚≥∆÷ÿ∏¥");
        }
    }
}
