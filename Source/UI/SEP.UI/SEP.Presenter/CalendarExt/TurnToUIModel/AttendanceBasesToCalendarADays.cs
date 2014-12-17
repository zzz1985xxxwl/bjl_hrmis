using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.Model.CalendarExt;

namespace SEP.Presenter.CalendarExt.TurnToUIModel
{
    public class AttendanceBasesToCalendarADays
    {
        public static List<CalendarADay> Turn(List<AttendanceBase> originalDataList,
                List<CalendarADay> retList, List<PlanDutyDetail> planDutyDetailList,
                List<OutApplication> outApplicationList, List<LeaveRequest> leaveRequestList, List<AttendanceInAndOutRecord> attendanceInAndOutRecordList)
        {
            foreach (AttendanceBase originalData in originalDataList)
            {
                PlanDutyDetail theDayPlanDuty =
                    PlanDutyDetail.GetPlanDutyDetailByDate(planDutyDetailList, originalData.TheDay);
                if (theDayPlanDuty == null)
                {
                    continue;
                }
                CalendarADay calendarADay = CalendarADay.CreateOrGetCalendarADayByDate(retList, originalData.TheDay);

                DayItem day = new DayItem();
                MonthItem month = new MonthItem();
                day.ObjectID = month.ObjectID = originalData.AttendanceId;
                day.CType = month.CType = CalendarShowType.Absent;
                day.ObjectID = month.ObjectID = originalData.AttendanceId;
                month.Date = calendarADay.Date;
                LaterAttendance late;
                EarlyLeaveAttendance early;
                if (originalData is AbsentAttendance)
                {
                    day.Start = theDayPlanDuty.PlanDutyClass.FirstStartFromTime;
                    day.End = originalData.Days == 1
                                  ? theDayPlanDuty.PlanDutyClass.SecondEndTime
                                  : theDayPlanDuty.PlanDutyClass.FirstEndTime;
                    if (originalData.Days != 1)
                    {
                        List<UnKownTimeSpan> uktsList =
                            CaculateAbsentTimes(originalData.TheDay, theDayPlanDuty, outApplicationList,
                                                leaveRequestList,
                                                attendanceInAndOutRecordList);
                        foreach (UnKownTimeSpan span in uktsList)
                        {
                            if ((span.To - span.From).TotalMinutes >= theDayPlanDuty.PlanDutyClass.AbsentLateTime
                                ||
                                (span.To - span.From).TotalMinutes >= theDayPlanDuty.PlanDutyClass.AbsentEarlyLeaveTime)
                            {
                                day.Start = span.From;
                                day.End = span.To;
                            }
                        }
                    }
                    day.DayDetail = originalData.Name + " " + Utility.FormatNumData(originalData.Days*8) + "小时";
                    month.Title = month.Detail = originalData.Name + " " + Utility.FormatNumData(originalData.Days * 8) + "小时";
                }
                else if ((early = originalData as EarlyLeaveAttendance) != null)
                {
                    day.Start = theDayPlanDuty.PlanDutyClass.SecondEndTime.AddMinutes(-early.EarlyLeaveMinutes);
                    day.End = theDayPlanDuty.PlanDutyClass.SecondEndTime;
                    day.DayDetail = early.Name + " " + Utility.FormatNumData(early.EarlyLeaveMinutes) + "分钟";
                    month.Title =
                        month.Detail = early.Name + " " + Utility.FormatNumData(early.EarlyLeaveMinutes) + "分钟";
                }
                else if ((late = originalData as LaterAttendance) != null)
                {
                    day.Start = theDayPlanDuty.PlanDutyClass.FirstStartFromTime;
                    day.End = theDayPlanDuty.PlanDutyClass.FirstStartFromTime.AddMinutes(late.LaterMinutes);
                    day.DayDetail = late.Name + " " + Utility.FormatNumData(late.LaterMinutes) + "分钟";
                    month.Title = month.Detail = late.Name + " " + Utility.FormatNumData(late.LaterMinutes) + "分钟";
                }

                calendarADay.DayItems.Add(day);
                calendarADay.MonthItems.Add(month);
                Utility.Clean(calendarADay);
            }
            return retList;
        }
        private static List<UnKownTimeSpan> CaculateAbsentTimes(DateTime theday, PlanDutyDetail thedayPlanDutyDetail,
                    List<OutApplication> outApplicationList, List<LeaveRequest> leaveRequestList,
                    List<AttendanceInAndOutRecord> attendanceInAndOutRecordList)
        {
            List<UnKownTimeSpan> uktsList = new List<UnKownTimeSpan>();
            uktsList.Add(
                new UnKownTimeSpan(
                    new DateTime(theday.Year, theday.Month, theday.Day,
                                 thedayPlanDutyDetail.PlanDutyClass.FirstStartFromTime.Hour,
                                 thedayPlanDutyDetail.PlanDutyClass.FirstStartFromTime.Minute,
                                 thedayPlanDutyDetail.PlanDutyClass.FirstStartFromTime.Second),
                    new DateTime(theday.Year, theday.Month, theday.Day,
                                 thedayPlanDutyDetail.PlanDutyClass.FirstEndTime.Hour,
                                 thedayPlanDutyDetail.PlanDutyClass.FirstEndTime.Minute,
                                 thedayPlanDutyDetail.PlanDutyClass.FirstEndTime.Second)));
            uktsList.Add(
                new UnKownTimeSpan(
                    new DateTime(theday.Year, theday.Month, theday.Day,
                                 thedayPlanDutyDetail.PlanDutyClass.SecondStartTime.Hour,
                                 thedayPlanDutyDetail.PlanDutyClass.SecondStartTime.Minute,
                                 thedayPlanDutyDetail.PlanDutyClass.SecondStartTime.Second),
                    new DateTime(theday.Year, theday.Month, theday.Day,
                                 thedayPlanDutyDetail.PlanDutyClass.SecondEndTime.Hour,
                                 thedayPlanDutyDetail.PlanDutyClass.SecondEndTime.Minute,
                                 thedayPlanDutyDetail.PlanDutyClass.SecondEndTime.Second)));
            foreach (LeaveRequest leaveRequest in leaveRequestList)
            {
                foreach (LeaveRequestItem leaveRequestItem in leaveRequest.LeaveRequestItems)
                {
                    UpdateAbsentTimesForKownTimeSpan(uktsList, leaveRequestItem.FromDate, leaveRequestItem.ToDate);
                }
            }
            foreach (OutApplication outApplication in outApplicationList)
            {
                foreach (OutApplicationItem outApplicationItem in outApplication.Item)
                {
                    UpdateAbsentTimesForKownTimeSpan(uktsList, outApplicationItem.FromDate, outApplicationItem.ToDate);
                }
            }
            UpdateAbsentTimesForKownTimeSpan(uktsList,
                                             AttendanceInAndOutRecord.FindEarlistTime(attendanceInAndOutRecordList),
                                             AttendanceInAndOutRecord.FindLatestTime(attendanceInAndOutRecordList));
            return uktsList;
        }

        private static void UpdateAbsentTimesForKownTimeSpan(List<UnKownTimeSpan> list, DateTime fromDate, DateTime toDate)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].From > toDate || list[i].To < fromDate)
                {
                    continue;
                }
                if (list[i].From >= fromDate && list[i].To <= toDate)
                {
                    list.RemoveAt(i);
                    i--;
                    continue;
                }
                if (fromDate < list[i].From && list[i].From < toDate)
                {
                    list[i].To =
                        new DateTime(list[i].To.Year, list[i].To.Month, list[i].To.Day, toDate.Hour, toDate.Minute,
                                     toDate.Second);
                    continue;
                }
                if (fromDate < list[i].To && list[i].To < toDate)
                {
                    list[i].From =
                        new DateTime(list[i].From.Year, list[i].From.Month, list[i].From.Day, fromDate.Hour,
                                     fromDate.Minute,
                                     fromDate.Second);
                    continue;
                }
                if (list[i].From < fromDate && toDate < list[i].To)
                {
                    DateTime dt1Start = list[i].From;
                    DateTime dt1End = fromDate;
                    DateTime dt2Start = toDate;
                    DateTime dt2End = list[i].To;
                    list.RemoveAt(i);
                    list.Insert(i, new UnKownTimeSpan(dt1Start, dt1End));
                    i++;
                    list.Insert(i, new UnKownTimeSpan(dt2Start, dt2End));
                    continue;
                }
            }
        }

        private class UnKownTimeSpan
        {
            public UnKownTimeSpan(DateTime from, DateTime to)
            {
                _From = from;
                _To = to;
            }

            private DateTime _From;
            private DateTime _To;
            public DateTime From
            {
                get { return _From; }
                set { _From = value; }
            }
            public DateTime To
            {
                get { return _To; }
                set { _To = value; }
            }
        }

    }
}