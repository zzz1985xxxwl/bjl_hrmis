//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CalculateOutHourTest.cs
// Creater:  Xue.wenlong
// Date:  2009-05-14
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP.HRMIS.Bll.OutApplications;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;

namespace SEP.HRMIS.BllUnitTest.OutApplicationTest
{
    [TestFixture]
    public class CalculateOutHourTest
    {
        [Test]
        public void Test1()
        {
            CalculateOutHour target = new CalculateOutHour(DT("2009-3-27 8:00:00"), DT("2009-3-30 12:00:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal answer = target.TestCalculate(8, planDutyDetails);
            Assert.AreEqual(11.5, answer);
        }
        [Test]
        public void Test22()
        {
            CalculateOutHour target = new CalculateOutHour(DT("2009-3-30 14:27:00"), DT("2009-3-31 13:37:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal answer = target.TestCalculate(8, planDutyDetails);
            Assert.AreEqual(8.17m, answer);
        }

        [Test]
        public void Test3()
        {
            CalculateOutHour target = new CalculateOutHour(DT("2009-3-27 7:00:00"), DT("2009-3-27 8:00:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal answer = target.TestCalculate(8, planDutyDetails);
            Assert.AreEqual(0, answer);
        }
        [Test]
        public void Test4()
        {
            CalculateOutHour target = new CalculateOutHour(DT("2009-3-27 11:30:00"), DT("2009-3-27 12:30:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal answer = target.TestCalculate(8, planDutyDetails);
            Assert.AreEqual(0, answer);
        }
        [Test]
        public void Test5()
        {
            CalculateOutHour target = new CalculateOutHour(DT("2009-3-27 11:30:00"), DT("2009-3-27 12:31:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal answer = target.TestCalculate(8, planDutyDetails);
            Assert.AreEqual(0.02, answer);
        }
        [Test]
        public void Test6()
        {
            CalculateOutHour target = new CalculateOutHour(DT("2009-3-27 11:00:00"), DT("2009-3-27 5:00:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal answer = target.TestCalculate(8, planDutyDetails);
            Assert.AreEqual(0, answer);
        }
        private static List<PlanDutyDetail> GetPlanDutyDetails()
        {
            DutyClass ruleNull = new DutyClass();
            ruleNull.DutyClassID = -1;
            DutyClass rule1 =
                new DutyClass("°à±ð1", DT(" 8:00:00"), DT(" 9:00:00"),
                DT(" 11:30:00"), DT(" 12:30:00"), DT(" 17:00:00"), 9,
                1, 11, 1, 11);
            rule1.DutyClassID = 1;
            List<PlanDutyDetail> planDutyDetails = new List<PlanDutyDetail>();
            PlanDutyDetail planDutyDetail1 = new PlanDutyDetail();
            planDutyDetail1.Date = Convert.ToDateTime("2009-03-27 00:00:00");
            planDutyDetail1.PlanDutyClass = rule1;
            PlanDutyDetail planDutyDetail2 = new PlanDutyDetail();
            planDutyDetail2.Date = Convert.ToDateTime("2009-03-28 00:00:00");
            planDutyDetail2.PlanDutyClass = ruleNull;
            PlanDutyDetail planDutyDetail3 = new PlanDutyDetail();
            planDutyDetail3.Date = Convert.ToDateTime("2009-03-29 00:00:00");
            planDutyDetail3.PlanDutyClass = ruleNull;
            PlanDutyDetail planDutyDetail4 = new PlanDutyDetail();
            planDutyDetail4.Date = Convert.ToDateTime("2009-03-30 00:00:00");
            planDutyDetail4.PlanDutyClass = rule1;
            PlanDutyDetail planDutyDetail5 = new PlanDutyDetail();
            planDutyDetail5.Date = Convert.ToDateTime("2009-03-31 00:00:00");
            planDutyDetail5.PlanDutyClass = rule1;
            PlanDutyDetail planDutyDetail6 = new PlanDutyDetail();
            planDutyDetail6.Date = Convert.ToDateTime("2009-04-1 00:00:00");
            planDutyDetail6.PlanDutyClass = rule1;
            PlanDutyDetail planDutyDetail7 = new PlanDutyDetail();
            planDutyDetail7.Date = Convert.ToDateTime("2009-04-2 00:00:00");
            planDutyDetail7.PlanDutyClass = rule1;
            planDutyDetails.Add(planDutyDetail1);
            planDutyDetails.Add(planDutyDetail2);
            planDutyDetails.Add(planDutyDetail3);
            planDutyDetails.Add(planDutyDetail4);
            planDutyDetails.Add(planDutyDetail5);
            planDutyDetails.Add(planDutyDetail6);
            planDutyDetails.Add(planDutyDetail7);
            return planDutyDetails;
        }

        private static DateTime DT(string datetime)
        {
            return Convert.ToDateTime(datetime);
        }
    }

          
}