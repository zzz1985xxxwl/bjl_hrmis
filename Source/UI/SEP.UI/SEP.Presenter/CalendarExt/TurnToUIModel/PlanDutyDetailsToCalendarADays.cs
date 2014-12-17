using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model.CalendarExt;

namespace SEP.Presenter.CalendarExt.TurnToUIModel
{
    public class PlanDutyDetailsToCalendarADays
    {
        public static List<CalendarADay> Turn(List<PlanDutyDetail> originalDataList, List<CalendarADay> retList)
        {
            foreach (PlanDutyDetail originalData in originalDataList)
            {
                CalendarADay calendarADay = CalendarADay.CreateOrGetCalendarADayByDate(retList, originalData.Date);

                MonthItem month = new MonthItem();
                month.CType = CalendarShowType.DutyClass;
                month.ObjectID = originalData.PlanDutyClass.DutyClassID;
                month.Date = originalData.Date;
                month.Title = originalData.PlanDutyClass.DutyClassName;
                if (originalData.PlanDutyClass.DutyClassID != -1)
                {
                    TimeSpan ts = originalData.PlanDutyClass.FirstStartToTime -
                                  originalData.PlanDutyClass.FirstStartFromTime;
                    
                    DayItem day1 = new DayItem();
                    DayItem day2 = new DayItem();
                    day1.CType = CalendarShowType.DutyClass;
                    day1.ObjectID = originalData.PlanDutyClass.DutyClassID;
                    day1.Start = originalData.PlanDutyClass.FirstStartFromTime;
                    day1.End = originalData.PlanDutyClass.FirstEndTime;
                    day1.DayDetail = "";
                    calendarADay.DayItems.Add(day1);

                    day2.CType = CalendarShowType.DutyClass;
                    day2.ObjectID = originalData.PlanDutyClass.DutyClassID;
                    day2.Start = originalData.PlanDutyClass.SecondStartTime;
                    day2.End = originalData.PlanDutyClass.SecondEndTime.Add(ts);
                    day2.DayDetail = "";
                    calendarADay.DayItems.Add(day2);

                    month.Detail = "上午上班时间：" + originalData.PlanDutyClass.FirstStartFromTime.ToShortTimeString() + "/" +
                                   originalData.PlanDutyClass.FirstStartToTime.ToShortTimeString() + "--" +
                                   originalData.PlanDutyClass.FirstEndTime.ToShortTimeString() + "<br>下午午上班时间：" +
                                   originalData.PlanDutyClass.SecondStartTime.ToShortTimeString() + "--" +
                                   originalData.PlanDutyClass.SecondEndTime.ToShortTimeString() + "/" +
                                   originalData.PlanDutyClass.SecondEndTime.Add(ts).ToShortTimeString() +
                                   "<br>迟到判定：上班晚于" +
                                   originalData.PlanDutyClass.LateTime + "分钟记迟到<br>早退判定：下班早于" +
                                   originalData.PlanDutyClass.EarlyLeaveTime + "分钟记早退<br>旷工判定：迟到" +
                                   originalData.PlanDutyClass.AbsentLateTime + "分钟或早退" +
                                   originalData.PlanDutyClass.AbsentEarlyLeaveTime + "分钟，为旷工";
                }
                else
                {
                    month.BackgroundColor = "#FFEDED";
                    month.Detail = originalData.PlanDutyClass.DutyClassName;
                }
                calendarADay.MonthItems.Add(month);
                Utility.Clean(calendarADay);
            }
            return retList;
        }


    }
}
