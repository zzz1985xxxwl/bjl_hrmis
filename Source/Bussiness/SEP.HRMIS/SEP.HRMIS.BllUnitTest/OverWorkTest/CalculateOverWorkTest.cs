//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CalculateOverWorkTest.cs
// Creater:  Xue.wenlong
// Date:  2009-05-14
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using SEP.HRMIS.Bll.OverWorks;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.OverWork;
using SEP.Model.SpecialDates;

namespace SEP.HRMIS.BllUnitTest.OverWorkTest
{
    [TestFixture]
    public class CalculateOverWorkTest
    {
        [Test]
        public void Test1()
        {
            CalculateOverWorkHour target =
                new CalculateOverWorkHour(DT("2009-3-27 8:00:00"), DT("2009-3-30 12:00:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            string error = "";
            try
            {
                target.TestCalculate(new CalculateDays(), planDutyDetails);
            }
            catch (ApplicationException ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("不能跨天", error);
        }

        [Test]
        public void Test2()
        {
            CalculateOverWorkHour target =
                new CalculateOverWorkHour(DT("2009-3-27 13:00:00"), DT("2009-3-27 12:00:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            string error = "";
            try
            {
                target.TestCalculate( new CalculateDays(), planDutyDetails);
            }
            catch (ApplicationException ex)
            {
                error = ex.Message;
            }
            Assert.AreEqual("开始时间大于结束时间", error);
        }

        [Test] 
        public void Test3()
        {
            CalculateOverWorkHour target =
                new CalculateOverWorkHour(DT("2009-3-27 11:00:00"), DT("2009-3-27 12:00:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal ans = target.TestCalculate( GetCalculateDays(), planDutyDetails);
            Assert.AreEqual(0, ans);
            Assert.AreEqual(OverWorkType.PuTong, target.OverWorkType);
        }

        [Test]
        public void Test4()
        {
            CalculateOverWorkHour target =
                new CalculateOverWorkHour(DT("2009-3-27 17:30:00"), DT("2009-3-27 17:45:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal ans = target.TestCalculate( GetCalculateDays(), planDutyDetails);
            Assert.AreEqual(0.25, ans);
            Assert.AreEqual(OverWorkType.PuTong, target.OverWorkType);
        }
        [Test]
        public void Test5()
        {
            CalculateOverWorkHour target =
                new CalculateOverWorkHour(DT("2009-3-27 8:30:00"), DT("2009-3-27 18:00:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal ans = target.TestCalculate( GetCalculateDays(), planDutyDetails);
            Assert.AreEqual(1.5, ans);
            Assert.AreEqual(OverWorkType.PuTong, target.OverWorkType);
        }
        [Test,Description("双休加班")]
        public void Test6()
        {
            CalculateOverWorkHour target =
                new CalculateOverWorkHour(DT("2009-3-28 8:30:00"), DT("2009-3-28 18:00:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal ans = target.TestCalculate( GetCalculateDays(), planDutyDetails);
            Assert.AreEqual(8.5, ans);
            Assert.AreEqual(OverWorkType.ShuangXiu, target.OverWorkType);
        }
        [Test, Description("节假加班")]
        public void Test7()
        {
            CalculateOverWorkHour target =
                new CalculateOverWorkHour(DT("2009-6-1 8:00:00"), DT("2009-6-1 17:00:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal ans = target.TestCalculate( GetCalculateDays(), planDutyDetails);
            Assert.AreEqual(8, ans);
            Assert.AreEqual(OverWorkType.JieRi,target.OverWorkType);
        }

        [Test, Description("")]
        public void Test8()
        {
            CalculateOverWorkHour target =
                new CalculateOverWorkHour(DT("2009-3-27 17:00:00"), DT("2009-3-28 00:00:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal ans = target.TestCalculate(GetCalculateDays(), planDutyDetails);
            Assert.AreEqual(7, ans);
            Assert.AreEqual(OverWorkType.PuTong, target.OverWorkType);
        }

        [Test, Description("")]
        public void Test9()
        {
            CalculateOverWorkHour target =
                new CalculateOverWorkHour(DT("2009-6-1 17:00:00"), DT("2009-6-2 00:00:00"), 0);
            List<PlanDutyDetail> planDutyDetails = GetPlanDutyDetails();
            decimal ans = target.TestCalculate(GetCalculateDays(), planDutyDetails);
            Assert.AreEqual(7, ans);
            Assert.AreEqual(OverWorkType.JieRi, target.OverWorkType);
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
            planDutyDetail7.Date = Convert.ToDateTime("2009-06-1 00:00:00");
            planDutyDetail7.PlanDutyClass = ruleNull;
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

        private static CalculateDays GetCalculateDays()
        {
            //是否工作,0不工作，1工作，2法定节假
            List<SpecialDate> specialDateList=new List<SpecialDate>();
            SpecialDate specialDate1=new SpecialDate();
            specialDate1.IsWork = 2;
            specialDate1.SpecialDateTime = DT("2009-6-1");
            SpecialDate specialDate2 = new SpecialDate();
            specialDate2.IsWork = 1;
            specialDate2.SpecialDateTime = DT("2009-6-2");
            specialDateList.Add(specialDate1);
            specialDateList.Add(specialDate2);
            return new CalculateDays(specialDateList);
        }
    }
}