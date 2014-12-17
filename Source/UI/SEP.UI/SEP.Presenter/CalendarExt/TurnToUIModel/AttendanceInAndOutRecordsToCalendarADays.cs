using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.Model.CalendarExt;

namespace SEP.Presenter.CalendarExt.TurnToUIModel
{
    public class AttendanceInAndOutRecordsToCalendarADays
    {
        public static List<CalendarADay> Turn(List<AttendanceInAndOutRecord> originalDataList, List<CalendarADay> retList
                                                            , List<PlanDutyDetail> planDutyDetailList
                                                            , DateTime from, DateTime to)
        {
            for (int i = 0; from.AddDays(i).Date <= to.Date; i++)
            {
                PlanDutyDetail planDutyDetail =
                    PlanDutyDetail.GetPlanDutyDetailByDate(planDutyDetailList, from.AddDays(i).Date);
                if (planDutyDetail == null || planDutyDetail.PlanDutyClass.IsWeek)
                {
                    continue;
                }
                CalendarADay calendarADay = CalendarADay.CreateOrGetCalendarADayByDate(retList, from.AddDays(i).Date);
                List<AttendanceInAndOutRecord> dtOriginalDataList =
                    AttendanceInAndOutRecord.GetAttendanceInAndOutRecordByDate(originalDataList, from.AddDays(i).Date);
                if (dtOriginalDataList.Count == 0)
                {
                    MonthItem monthNoRecord = new MonthItem();
                    monthNoRecord.CType = CalendarShowType.Attendance;
                    monthNoRecord.Title = "�޴򿨼�¼";
                    monthNoRecord.Date = from.AddDays(i).Date;
                    monthNoRecord.Detail = "�޴򿨼�¼";
                    calendarADay.MonthItems.Add(monthNoRecord);
                    Utility.Clean(calendarADay);
                    continue;
                }
                DateTime dtStart = AttendanceInAndOutRecord.FindEarlistTime(dtOriginalDataList);
                DateTime dtEnd = AttendanceInAndOutRecord.FindLatestTime(dtOriginalDataList);

                if (!IsInitTime(dtStart))
                {
                    DayItem day = new DayItem();
                    day.CType = CalendarShowType.Attendance;
                    day.Start = day.End = dtStart;
                    day.DayDetail = "�� " + dtStart.ToShortTimeString();
                    calendarADay.DayItems.Add(day);
                }
                if (!IsInitTime(dtEnd))
                {
                    DayItem day = new DayItem();
                    day.CType = CalendarShowType.Attendance;
                    day.Start = day.End = dtEnd;
                    day.DayDetail = "�� " + dtEnd.ToShortTimeString();
                    calendarADay.DayItems.Add(day);
                }

                MonthItem month = new MonthItem();
                month.CType = CalendarShowType.Attendance;
                month.Title = "�� " + (!IsInitTime(dtStart) ? dtStart.ToShortTimeString() : "") +
                                 "--" + (!IsInitTime(dtEnd) ? dtEnd.ToShortTimeString() : "");
                month.Date = from.AddDays(i).Date;
                month.Detail = "�����ʱ�䣺" + (!IsInitTime(dtStart) ? dtStart.ToString() : "--") + "<br>" + "�����ʱ�䣺" +
                                  (!IsInitTime(dtEnd) ? dtEnd.ToString() : "--");
                calendarADay.MonthItems.Add(month);
                Utility.Clean(calendarADay);
            }

            return retList;
        }
        private static bool IsInitTime(DateTime dt)
        {
            return dt.Date <= new DateTime(1900, 1, 1).Date;
        }

    }
}
