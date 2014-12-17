using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.AttendanceStatistics;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.IBll;
using SEP.Model.Accounts;

namespace SEP.HRMIS.BllUnitTest.PlanDutyTest
{
    [TestFixture]
    public class UpdatePlanDutyTest
    {
        [Test, Description("测试更新排班表")]
        public void TestUpdateAttendanceRuleSuccessful()
        {
            PlanDutyTable planDutyTable = new PlanDutyTable();
            planDutyTable.PlanDutyTableID = 2;
            planDutyTable.PlanDutyTableName = "班别2";
            planDutyTable.PlanDutyAccountList = new List<Account>();
            MockRepository mock = new MockRepository();
            IPlanDutyDal dalRule = mock.CreateMock<IPlanDutyDal>();
            List<Account> accounts = new List<Account>();
            Expect.Call(dalRule.CountPlanDutyByPlanDutyDiffPkid(planDutyTable.PlanDutyTableID, planDutyTable.PlanDutyTableName)).Return(0);
            Expect.Call(dalRule.GetPlanDutyTableByPkid(2)).Return(planDutyTable);
            Expect.Call(dalRule.UpdatePlanDutyTable(planDutyTable, accounts)).Return(1);
            mock.ReplayAll();
            UpdatePlanDuty updateRule = new UpdatePlanDuty(planDutyTable, dalRule);
            updateRule.Excute();
        }

        [Test, Description("测试更新排班表名称重复")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateAttendanceRuleSameName()
        {
            PlanDutyTable planDutyTable = new PlanDutyTable();
            planDutyTable.PlanDutyTableID = 2;
            planDutyTable.PlanDutyTableName = "班别2";
            planDutyTable.PlanDutyAccountList = new List<Account>();
            MockRepository mock = new MockRepository();
            IPlanDutyDal dalRule = mock.CreateMock<IPlanDutyDal>();
            List<Account> accounts = new List<Account>();
            Expect.Call(dalRule.CountPlanDutyByPlanDutyDiffPkid(planDutyTable.PlanDutyTableID, planDutyTable.PlanDutyTableName)).Return(1);
            Expect.Call(dalRule.GetPlanDutyTableByPkid(2)).Return(planDutyTable);
            Expect.Call(dalRule.UpdatePlanDutyTable(planDutyTable, accounts)).Return(1);
            mock.ReplayAll();
            UpdatePlanDuty updateRule = new UpdatePlanDuty(planDutyTable, dalRule);
            updateRule.Excute();
            Assert.Fail("该排班表名字重复");
        }

        [Test, Description("测试更新排班表不存在")]
        [ExpectedException(typeof(ApplicationException))]
        public void TestUpdateAttendanceRuleNotExist()
        {
            PlanDutyTable planDutyTable = new PlanDutyTable();
            planDutyTable.PlanDutyTableID = 2;
            MockRepository mock = new MockRepository();
            IPlanDutyDal dalRule = mock.CreateMock<IPlanDutyDal>();
            List<Account> accounts = new List<Account>();
            Expect.Call(dalRule.CountPlanDutyByPlanDutyDiffPkid(planDutyTable.PlanDutyTableID, planDutyTable.PlanDutyTableName)).Return(0);
            Expect.Call(dalRule.GetPlanDutyTableByPkid(2)).Return(null);
            Expect.Call(dalRule.UpdatePlanDutyTable(planDutyTable, accounts)).Return(1);
            mock.ReplayAll();
            UpdatePlanDuty updateRule = new UpdatePlanDuty(planDutyTable, dalRule);
            updateRule.Excute();
            Assert.Fail("排班表不存在");
        }
    }
}
