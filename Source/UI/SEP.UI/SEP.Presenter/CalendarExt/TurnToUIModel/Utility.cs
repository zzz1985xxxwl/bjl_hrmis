using System;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model.CalendarExt;

namespace SEP.Presenter.CalendarExt.TurnToUIModel
{
    public class Utility
    {
        public const decimal _OneDayMaxHour = 8;
        private static double DateTimeCompareShortTime(DateTime dt1, DateTime dt2)
        {
            dt1 = new DateTime(2000, 1, 1, dt1.Hour, dt1.Minute, dt1.Second);
            dt2 = new DateTime(2000, 1, 1, dt2.Hour, dt2.Minute, dt2.Second);
            return (dt1 - dt2).TotalMinutes;
        }

        public static decimal CalculateOneDay(DateTime from, DateTime to, decimal leastHour, PlanDutyDetail detail)
        {
            TimeSpan ts = detail.PlanDutyClass.FirstStartToTime -
                 detail.PlanDutyClass.FirstStartFromTime;
            DateTime fromtemp = from;
            DateTime totemp = to;
            if (DateTimeCompareShortTime(from, detail.PlanDutyClass.FirstStartFromTime) <= 0)
            {
                fromtemp = detail.PlanDutyClass.FirstStartFromTime;
            }
            else if (DateTimeCompareShortTime(from, detail.PlanDutyClass.FirstEndTime) >= 0 &&
                     DateTimeCompareShortTime(from, detail.PlanDutyClass.SecondStartTime) <= 0)
            {
                fromtemp = detail.PlanDutyClass.SecondStartTime;
            }
            if (DateTimeCompareShortTime(to, detail.PlanDutyClass.SecondEndTime.Add(ts)) >= 0)
            {
                totemp = detail.PlanDutyClass.SecondEndTime.Add(ts);
            }
            else if (DateTimeCompareShortTime(to, detail.PlanDutyClass.FirstEndTime) >= 0 &&
                     DateTimeCompareShortTime(to, detail.PlanDutyClass.SecondStartTime) <= 0)
            {
                totemp = detail.PlanDutyClass.FirstEndTime;
            }
            double tsTotalMinutes = DateTimeCompareShortTime(totemp, fromtemp);
            decimal costMinutes = tsTotalMinutes < 0 ? 0m : Convert.ToDecimal(tsTotalMinutes);
            if (DateTimeCompareShortTime(fromtemp, detail.PlanDutyClass.FirstEndTime) <= 0 &&
                DateTimeCompareShortTime(fromtemp, detail.PlanDutyClass.FirstStartFromTime) >= 0 &&
                DateTimeCompareShortTime(totemp, detail.PlanDutyClass.SecondEndTime.Add(ts)) <= 0 &&
                DateTimeCompareShortTime(totemp, detail.PlanDutyClass.SecondStartTime) >= 0)
            {
                costMinutes -=
                    Convert.ToDecimal(
                        (detail.PlanDutyClass.SecondStartTime - detail.PlanDutyClass.FirstEndTime).TotalMinutes);
            }
            decimal answer = leastHour == 0 ? ConvertToHour(costMinutes / 60) : ConvertToHour(costMinutes / 60, leastHour);
            return answer > _OneDayMaxHour ? _OneDayMaxHour : answer;
        }

        private static decimal ConvertToHour(decimal actualHour)
        {
            return decimal.Round(actualHour, 2);
        }

        private static decimal ConvertToHour(decimal actualHour, decimal leastHour)
        {
            return decimal.ToInt32((actualHour / leastHour)) * leastHour +
                   (actualHour % leastHour == 0 ? 0 : leastHour);
        }

        public static float FormatNumData(object data)
        {
            decimal d;
            if(!decimal.TryParse(data.ToString(),out d))
            {
                return 0;
            }
            return Convert.ToSingle(decimal.Round(d, 2));
        }

        public static void Clean(CalendarADay aday)
        {
            foreach (DayItem item in aday.DayItems)
            {
                item.End =
                    new DateTime(aday.Date.Year, aday.Date.Month, aday.Date.Day, item.End.Hour, item.End.Minute,
                                 item.End.Second);
                item.Start =
                    new DateTime(aday.Date.Year, aday.Date.Month, aday.Date.Day, item.Start.Hour, item.Start.Minute,
                                 item.Start.Second);
            }
            foreach (MonthItem item in aday.MonthItems)
            {
                item.Date = aday.Date;
            }
        }
    }
}
