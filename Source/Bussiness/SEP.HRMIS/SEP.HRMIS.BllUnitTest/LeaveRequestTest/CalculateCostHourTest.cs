//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CalculateCostHourTest.cs
// Creater:  Xue.wenlong
// Date:  2009-03-27
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model.SpecialDates;

namespace SEP.HRMIS.BllUnitTest.LeaveRequestTest
{
    [TestFixture]
    public class CalculateCostHourTest
    {
        private decimal _OneDayMaxHour;
        private decimal _LeastHour ;
        private bool _InCludeWeek;
        private bool _InCludeLegalHoliday;
        [SetUp]
        public void SetUp()
        {
             _OneDayMaxHour = 8;
             _LeastHour = 4;
             _InCludeWeek = false;
             _InCludeLegalHoliday = false;
        }
        [Test]
        public void Test1()
        {
            CalculateCostHour target = new CalculateCostHour(DT("2009-3-27 8:00:00"), DT("2009-3-30 12:00:00"), 0, 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal answer = target.TestCalculate(_LeastHour, _InCludeWeek, _InCludeLegalHoliday, _OneDayMaxHour, planDutyDetails, GetCalculateDays());
           Assert.AreEqual(12, answer);
        }
        [Test]
        public void Test2()
        {
            CalculateCostHour target = new CalculateCostHour(DT("2009-3-27 8:00:00"), DT("2009-3-30 12:00:00"), 0, 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            _InCludeWeek = true;
            decimal answer = target.TestCalculate(_LeastHour, _InCludeWeek, _InCludeLegalHoliday, _OneDayMaxHour, planDutyDetails, GetCalculateDays());
            Assert.AreEqual(20, answer);
        }

        [Test]
        public void Test22()
        {
            CalculateCostHour target = new CalculateCostHour(DT("2009-3-30 14:27:00"), DT("2009-3-31 11:00:00"), 0, 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal answer = target.TestCalculate(_LeastHour, _InCludeWeek, _InCludeLegalHoliday, _OneDayMaxHour, planDutyDetails, GetCalculateDays());
            Assert.AreEqual(8, answer);
        }

        [Test]
        public void Test3()
        {
            CalculateCostHour target = new CalculateCostHour(DT("2009-3-27 7:00:00"), DT("2009-3-27 8:00:00"), 0, 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal answer = target.TestCalculate(_LeastHour, _InCludeWeek, _InCludeLegalHoliday, _OneDayMaxHour, planDutyDetails,GetCalculateDays());
            Assert.AreEqual(0, answer);
        }
        [Test]
        public void Test4()
        {
            CalculateCostHour target = new CalculateCostHour(DT("2009-3-27 11:30:00"), DT("2009-3-27 12:30:00"), 0, 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal answer = target.TestCalculate(_LeastHour, _InCludeWeek, _InCludeLegalHoliday, _OneDayMaxHour, planDutyDetails, GetCalculateDays());
            Assert.AreEqual(0, answer);
        }
        [Test]
        public void Test5()
        {
            CalculateCostHour target = new CalculateCostHour(DT("2009-3-27 13:00:00"), DT("2009-3-27 13:31:00"), 0, 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal answer = target.TestCalculate(_LeastHour, _InCludeWeek, _InCludeLegalHoliday, _OneDayMaxHour, planDutyDetails, GetCalculateDays());
            Assert.AreEqual(4, answer);
        }
        [Test]
        public void Test6()
        {
            CalculateCostHour target = new CalculateCostHour(DT("2009-3-27 11:00:00"), DT("2009-3-27 5:00:00"), 0, 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal answer = target.TestCalculate(_LeastHour, _InCludeWeek, _InCludeLegalHoliday, _OneDayMaxHour, planDutyDetails, GetCalculateDays());
            Assert.AreEqual(0, answer);
        }
        [Test]
        public void Test7()
        {
            CalculateCostHour target = new CalculateCostHour(DT("2009-3-29 9:00:00"), DT("2009-4-2 17:00:00"), 0, 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            _InCludeLegalHoliday = true;
            decimal answer = target.TestCalculate(_LeastHour, _InCludeWeek, _InCludeLegalHoliday, _OneDayMaxHour, planDutyDetails, GetCalculateDays());
            Assert.AreEqual(40, answer);
        }
        [Test]
        public void Test8()
        {
            CalculateCostHour target = new CalculateCostHour(DT("2009-3-27 8:30:00"), DT("2009-3-27 11:30:00"), 0, 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal answer = target.TestCalculate(_LeastHour, _InCludeWeek, _InCludeLegalHoliday, _OneDayMaxHour, planDutyDetails, GetCalculateDays());
            Assert.AreEqual(4, answer);
        }
        private static List<PlanDutyDetail> GetPlanDutyDetails()
        {
            DutyClass ruleNull = new DutyClass();
            ruleNull.DutyClassID = -1;
            DutyClass rule1 =
                new DutyClass("班别1", DT(" 8:00:00"), DT(" 9:00:00"),
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
        private static CalculateDays GetCalculateDays()
        {
            //是否工作,0不工作，1工作，2法定节假
            List<SpecialDate> specialDateList = new List<SpecialDate>();
            SpecialDate specialDate1 = new SpecialDate();
            specialDate1.IsWork = 2;
            specialDate1.SpecialDateTime = DT("2009-3-29");
            specialDateList.Add(specialDate1);
            return new CalculateDays(specialDateList);
        }
        private static DateTime DT(string datetime)
        {
            return Convert.ToDateTime(datetime);
        }
        
    }
}