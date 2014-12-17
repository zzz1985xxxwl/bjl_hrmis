using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model;
using SEP.Model.CalendarExt;

namespace SEP.Presenter.CalendarExt.TurnToUIModel
{
    public class WorkTasksToCalendarADays
    {
        public static List<CalendarADay> Turn(List<WorkTask> originalDataList, List<CalendarADay> retList,
            List<PlanDutyDetail> planDutyDetailList, int accountID, DateTime startDate, DateTime endDate)
        {
            foreach (WorkTask originalData in originalDataList)
            {
                for (int i = 0; originalData.StartDate.AddDays(i).Date <= originalData.EndDate.Date; i++)
                {
                    if (originalData.StartDate.AddDays(i).Date < startDate.Date
                        || originalData.StartDate.AddDays(i).Date > endDate.Date)
                    {
                        continue;
                    }
                    PlanDutyDetail detail = PlanDutyDetail.GetPlanDutyDetailByDate(planDutyDetailList, originalData.StartDate.AddDays(i).Date);
                    if (detail != null && detail.PlanDutyClass != null && detail.PlanDutyClass.IsWeek)
                    {
                        continue;
                    }
                    CalendarADay calendarADay =
                        CalendarADay.CreateOrGetCalendarADayByDate(retList, originalData.StartDate.AddDays(i).Date);

                    MonthItem month = new MonthItem();
                    month.CType = CalendarShowType.WorkTask;
                    month.Title = originalData.Title;
                    month.Date = originalData.StartDate.AddDays(i).Date;
                    month.Detail = month.Title +
                                    (originalData.Account.Id == accountID ? "" : "<br>创建人：" + originalData.Account.Name)
                                     + "<br>时段：" + originalData.StartDate.ToShortDateString() + "--" +
                                   originalData.EndDate.ToShortDateString() + " 状态：<span class=\"" +
                                   originalData.Status.Style + "\">" + originalData.Status.Name +
                                   "</span><br>" + originalData.Description ;
                    calendarADay.MonthItems.Add(month);

                    DayItem day = new DayItem();
                    day.CType = CalendarShowType.WorkTask;
                    day.Start = day.End = originalData.StartDate.AddDays(i).Date;

                    if (detail != null)
                    {
                        day.Start =
                            new DateTime(day.Start.Year, day.Start.Month, day.Start.Day,
                                         detail.PlanDutyClass.FirstStartFromTime.Hour,
                                         detail.PlanDutyClass.FirstStartFromTime.Minute,
                                         detail.PlanDutyClass.FirstStartFromTime.Second); //todo by wsl
                        day.End =
                            new DateTime(day.End.Year, day.End.Month, day.End.Day,
                                         detail.PlanDutyClass.SecondEndTime.Hour,
                                         detail.PlanDutyClass.SecondEndTime.Minute,
                                         detail.PlanDutyClass.SecondEndTime.Second);
                    }
                    else
                    {
                        day.Start = new DateTime(day.Start.Year, day.Start.Month, day.Start.Day, 9, 0, 0);
                        day.End = new DateTime(day.End.Year, day.End.Month, day.End.Day, 17, 0, 0);
                    }

                    day.DayDetail = month.Title +
                                    (originalData.Account.Id == accountID ? "" : "<br>创建人：" + originalData.Account.Name)
                                    + "<br>时段：" +
                                    originalData.StartDate.ToShortDateString() + "--" +
                                    originalData.EndDate.ToShortDateString() + "<br>状态：" + originalData.Status.Name +
                                    "<br>" + originalData.Description;
                    calendarADay.DayItems.Add(day);
                    Utility.Clean(calendarADay);
                }
            }
            return retList;
        }

    }
}