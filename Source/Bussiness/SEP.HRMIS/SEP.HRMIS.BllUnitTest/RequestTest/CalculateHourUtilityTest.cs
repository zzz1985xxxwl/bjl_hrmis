//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: CalculateHourUtilityTest.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-13
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using SEP.HRMIS.Bll.Requests;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.BllUnitTest.RequestTest
{
    [TestFixture]
    public class CalculateHourUtilityTest
    {
        private DateTime _MorningStart;
        private DateTime _MorningEnd;
        private DateTime _AfternoonStart;
        private DateTime _AfternoonEnd;

        [SetUp]
        public void SetUp()
        {
            _MorningStart = Convert.ToDateTime("2009-1-1 8:00:00");
            _MorningEnd = Convert.ToDateTime("2009-1-1 11:30:00");
            _AfternoonStart = Convert.ToDateTime("2009-1-1 12:30:00");
            _AfternoonEnd = Convert.ToDateTime("2009-1-1 18:00:00");
        }

        [Test]
        public void TestInit()
        {
            CalculateHourUtility calculateHour = new CalculateHourUtility();
            Assert.AreEqual(_AfternoonEnd, calculateHour.AfternoonEnd);
            Assert.AreEqual(_AfternoonStart, calculateHour.AfternoonStart);
            Assert.AreEqual(_MorningStart, calculateHour.MorningStart);
            Assert.AreEqual(_MorningEnd, calculateHour.MorningEnd);
        }


        [Test]
        public void Test2()
        {
            CalculateHourUtility calculateHour = new CalculateHourUtility();
            MockRepository mocks = new MockRepository();
            IPlanDutyDal _IPlanDutyDal = mocks.CreateMock<IPlanDutyDal>();
            Expect.Call(
                _IPlanDutyDal.GetPlanDutyDetailByAccount(1, Convert.ToDateTime("2009-02-27 00:00:00"),
                                                         Convert.ToDateTime("2009-04-27 00:00:00"))).Return(
                GetPlanDutyDetails());
            mocks.ReplayAll();
            calculateHour.MockIPlanDutyDal = _IPlanDutyDal;
            calculateHour.InitPlanDuty(Convert.ToDateTime("2009-03-27 00:00:00"), Convert.ToDateTime("2009-03-27 00:00:00"),1);
            Assert.AreEqual(RequestUtility.ConvertToTime(Convert.ToDateTime("2009-8-13 19:00:00")) , RequestUtility.ConvertToTime(calculateHour.AfternoonEnd));
            Assert.AreEqual(RequestUtility.ConvertToTime(Convert.ToDateTime("2009-8-13 13:30:00")), RequestUtility.ConvertToTime(calculateHour.AfternoonStart));
            Assert.AreEqual(RequestUtility.ConvertToTime(Convert.ToDateTime("2009-8-13 7:00:00")), RequestUtility.ConvertToTime(calculateHour.MorningStart));
            Assert.AreEqual(RequestUtility.ConvertToTime(Convert.ToDateTime("2009-8-13 10:30:00")), RequestUtility.ConvertToTime(calculateHour.MorningEnd));
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
            DutyClass rule2 =
               new DutyClass("°à±ð1", DT(" 7:00:00"), DT(" 8:00:00"),
                             DT(" 10:30:00"), DT(" 13:30:00"), DT(" 16:00:00"), 9,
                             1, 11, 1, 11);
            rule2.DutyClassID = 1;

            List<PlanDutyDetail> planDutyDetails = new List<PlanDutyDetail>();
            PlanDutyDetail planDutyDetail0 = new PlanDutyDetail();
            planDutyDetail0.Date = Convert.ToDateTime("2009-02-27 00:00:00");
            planDutyDetail0.PlanDutyClass = rule2;

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
            planDutyDetails.Add(planDutyDetail0);
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