using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.Request;
using SEP.Model.CalendarExt;
using SEP.Model.SpecialDates;

namespace SEP.Presenter.CalendarExt.TurnToUIModel
{
    public class LeaveRequestsToCalendarADays
    {
        private static readonly decimal _OneDayMaxHour = 8;
        public static List<CalendarADay> Turn(List<LeaveRequest> originalDataList,
       List<PlanDutyDetail> planDutyDetailList, List<SpecialDate> specialList, List<CalendarADay> retList)
        {
            CalculateDays _CalculateDays = new CalculateDays(specialList);
            foreach (LeaveRequest originalData in originalDataList)
            {
                foreach (LeaveRequestItem originalDataItem in originalData.LeaveRequestItems)
                {
                    DateTime from = originalDataItem.FromDate;
                    DateTime to = originalDataItem.ToDate;
                    decimal costHour = 0m;
                    if (from >= to)
                    {
                        CreateLeaveRequestInfoInADay(retList, from, 0, originalData, originalDataItem, from, to);
                    }
                    int days = (to.Date - from.Date).Days;
                    DateTime date = from;
                    for (int i = 0; i <= days; i++)
                    {
                        PlanDutyDetail detail = PlanDutyDetail.GetPlanDutyDetailByDate(planDutyDetailList, date);
                        if (detail != null && detail.PlanDutyClass != null)
                        {
                            DateTime dtMorningStart, dtAfternoonEnd;
                            InitDateTime(from, to, detail, out dtMorningStart, out dtAfternoonEnd);
                            DateTime fromtemp =
                                new DateTime(date.Year, date.Month, date.Day, dtMorningStart.Hour,
                                             dtMorningStart.Minute, dtMorningStart.Second);
                            DateTime totemp =
                                new DateTime(date.Year, date.Month, date.Day, dtAfternoonEnd.Hour,
                                             dtAfternoonEnd.Minute, dtAfternoonEnd.Second);
                            if (i == 0)
                            {
                                fromtemp = from;
                            }
                            if (i == days)
                            {
                                totemp = to;
                            }
                            decimal hour;
                            //排除双休日,节假日
                            if (originalData.LeaveRequestType.IncludeLegalHoliday == LegalHoliday.Include
                                && _CalculateDays.IsNationalHoliday(date))
                            {
                                if (detail.PlanDutyClass.IsWeek)
                                {
                                    hour = Utility._OneDayMaxHour;
                                    costHour += hour;
                                }
                                else
                                {
                                    hour = Utility.CalculateOneDay(fromtemp, totemp, originalData.LeaveRequestType.LeastHour, detail);
                                    costHour += hour;
                                }
                                CreateLeaveRequestInfoInADay(retList, date, hour, originalData, originalDataItem, fromtemp,
                                                             totemp);
                            }
                            else if (originalData.LeaveRequestType.IncludeLegalHoliday == LegalHoliday.Include
                                && detail.PlanDutyClass.IsWeek && !_CalculateDays.IsNationalHoliday(date))
                            {
                                hour = Utility._OneDayMaxHour;
                                costHour += hour;
                                CreateLeaveRequestInfoInADay(retList, date, hour, originalData, originalDataItem, fromtemp,
                                                             totemp);
                            }

                            else if (!detail.PlanDutyClass.IsWeek)
                            {
                                hour = Utility.CalculateOneDay(fromtemp, totemp, originalData.LeaveRequestType.LeastHour, detail);
                                costHour += hour;
                                CreateLeaveRequestInfoInADay(retList, date, hour, originalData, originalDataItem, fromtemp,
                                                             totemp);
                            }
                        }
                        date = date.AddDays(1);
                    }
                }
            }

            return retList;
        }

        private static void InitDateTime(DateTime from, DateTime to, PlanDutyDetail detail,
            out DateTime dtMorningStart, out DateTime dtAfternoonEnd)
        {
            DateTime lastenddate =
                detail.PlanDutyClass.FirstStartToTime.AddHours(
                    (detail.PlanDutyClass.SecondStartTime - detail.PlanDutyClass.FirstEndTime).
                        TotalHours + (double)_OneDayMaxHour);
            if (RequestUtility.ConvertToTime(from) >=
                RequestUtility.ConvertToTime(detail.PlanDutyClass.FirstStartFromTime) &&
                RequestUtility.ConvertToTime(from) <=
                RequestUtility.ConvertToTime(detail.PlanDutyClass.FirstStartToTime))
            {
                dtMorningStart = RequestUtility.ConvertToTime(from);
            }
            else
            {
                dtMorningStart = RequestUtility.ConvertToTime(detail.PlanDutyClass.FirstStartFromTime);
            }
            if (RequestUtility.ConvertToTime(to) >=
                RequestUtility.ConvertToTime(detail.PlanDutyClass.SecondEndTime) &&
                RequestUtility.ConvertToTime(to) <=
                RequestUtility.ConvertToTime(lastenddate))
            {
                dtAfternoonEnd = RequestUtility.ConvertToTime(to);
            }
            else
            {
                dtAfternoonEnd =
                    RequestUtility.ConvertToTime(lastenddate);
            }
        }
        private static void CreateLeaveRequestInfoInADay(List<CalendarADay> retList, DateTime date,
            decimal hour, LeaveRequest originalData, LeaveRequestItem originalDataItem,
            DateTime from, DateTime to)
        {
            CalendarADay calendarADay = CalendarADay.CreateOrGetCalendarADayByDate(retList, date.Date);
            string leaveRequestTypeName = originalData.LeaveRequestType.Name;
            // -1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
            if (originalDataItem.Status == RequestStatus.New ||
                originalDataItem.Status == RequestStatus.Submit ||
                originalDataItem.Status == RequestStatus.Approving ||
                originalDataItem.Status == RequestStatus.CancelApproving ||
                originalDataItem.Status == RequestStatus.Cancelled)
            {
                leaveRequestTypeName = originalData.LeaveRequestType.Name + "(" + originalDataItem.Status.Name + ")";
            }

            DayItem day = new DayItem();
            day.ObjectID = originalDataItem.LeaveRequestItemID;
            day.CType = CalendarShowType.Leave;
            day.Start = from;
            day.End = to;
            day.DayDetail = leaveRequestTypeName + " " + Convert.ToSingle(hour) + "小时<br>理由：" + originalData.Reason;
            calendarADay.DayItems.Add(day);

            MonthItem month = new MonthItem();
            month.ObjectID = originalDataItem.LeaveRequestItemID;
            month.CType = CalendarShowType.Leave;
            month.Title = leaveRequestTypeName + " " + Convert.ToSingle(hour) + "小时";
            month.Date = date;
            month.Detail = leaveRequestTypeName + " 时段：" +
                               originalDataItem.FromDate.ToShortDateString() + " " +
                               originalDataItem.FromDate.ToShortTimeString() + "--" +
                               originalDataItem.ToDate.ToShortDateString() + " " +
                               originalDataItem.ToDate.ToShortTimeString() + " 请假时间(小时)：" +
                           originalDataItem.CostTime + " 理由：" + originalData.Reason;
            calendarADay.MonthItems.Add(month);
            Utility.Clean(calendarADay);
        }

    }
}
