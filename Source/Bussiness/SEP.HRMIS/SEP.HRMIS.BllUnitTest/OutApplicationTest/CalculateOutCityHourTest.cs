using System;
using NUnit.Framework;
using SEP.HRMIS.Bll.OutApplications;

namespace SEP.HRMIS.BllUnitTest.OutApplicationTest
{
    [TestFixture]
    public class CalculateOutCityHourTest
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
        public void Test()
        {
            CalculateOutCityHour calculate =
                new CalculateOutCityHour(DT("2009-3-27 8:00:00"), DT("2009-3-30 12:00:00"), 72);
            Assert.AreEqual(24 + 3.5,
                            calculate.TestCalculate(_MorningStart, _MorningEnd, _AfternoonStart, _AfternoonEnd));
            Assert.AreEqual(4,calculate.DayAttendanceList.Count);
            Assert.AreEqual(8,calculate.DayAttendanceList[0].Hours);
            Assert.AreEqual(8, calculate.DayAttendanceList[1].Hours);
            Assert.AreEqual(8, calculate.DayAttendanceList[2].Hours);
            Assert.AreEqual(3.5, calculate.DayAttendanceList[3].Hours);
            Assert.AreEqual(Convert.ToDateTime("2009-3-27 8:00:00").Date, calculate.DayAttendanceList[0].Date.Date);
            Assert.AreEqual(Convert.ToDateTime("2009-3-28 8:00:00").Date, calculate.DayAttendanceList[1].Date.Date);
            Assert.AreEqual(Convert.ToDateTime("2009-3-29 8:00:00").Date, calculate.DayAttendanceList[2].Date.Date);
            Assert.AreEqual(Convert.ToDateTime("2009-3-30 8:00:00").Date, calculate.DayAttendanceList[3].Date.Date);

        }

        [Test]
        public void Test1()
        {
            CalculateOutCityHour calculate =
                new CalculateOutCityHour(DT("2009-3-1 8:00:00"), DT("2009-3-1 12:00:00"), 72);
            Assert.AreEqual(3.5, calculate.TestCalculate(_MorningStart, _MorningEnd, _AfternoonStart, _AfternoonEnd));
        }

        [Test]
        public void Test2()
        {
            CalculateOutCityHour calculate =
                new CalculateOutCityHour(DT("2009-3-1 8:00:00"), DT("2009-3-1 19:00:00"), 72);
            Assert.AreEqual(8, calculate.TestCalculate(_MorningStart, _MorningEnd, _AfternoonStart, _AfternoonEnd));
        }

        [Test]
        public void Test3()
        {
            CalculateOutCityHour calculate =
                new CalculateOutCityHour(DT("2009-3-12 8:00:00"), DT("2009-3-13 19:00:00"), 72);
            Assert.AreEqual(16, calculate.TestCalculate(_MorningStart, _MorningEnd, _AfternoonStart, _AfternoonEnd));
        }

        private static DateTime DT(string datetime)
        {
            return Convert.ToDateTime(datetime);
        }
    }
}