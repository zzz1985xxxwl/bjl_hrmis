using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.Model.CalendarExt;
using SEP.Model.SpecialDates;

namespace SEP.Presenter.CalendarExt.TurnToUIModel
{
    public class OverWorksToCalendarADays
    {
        public static List<CalendarADay> Turn(List<OverWork> originalDataList,
                List<PlanDutyDetail> planDutyDetailList, List<SpecialDate> specialList, List<CalendarADay> retList)
        {
            foreach (OverWork overWork in originalDataList)
            {
                foreach (OverWorkItem originalDataItem in overWork.Item)
                {
                    string typeName = "加班";
                    // -1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
                    if (originalDataItem.Status == RequestStatus.New ||
                        originalDataItem.Status == RequestStatus.Submit ||
                        originalDataItem.Status == RequestStatus.Approving ||
                        originalDataItem.Status == RequestStatus.CancelApproving ||
                        originalDataItem.Status == RequestStatus.Cancelled)
                    {
                        typeName = typeName + "(" + originalDataItem.Status.Name + ")";
                    }
                    CalendarADay calendarADay = CalendarADay.CreateOrGetCalendarADayByDate(retList, originalDataItem.FromDate.Date);
                    DayItem day = new DayItem();
                    day.ObjectID = originalDataItem.ItemID;
                    day.CType = CalendarShowType.OverWork;
                    day.Start = originalDataItem.FromDate;
                    day.End = originalDataItem.ToDate;
                    day.DayDetail = typeName + " " + originalDataItem.CostTime + "小时<br>项目：" + overWork.ProjectName +
                                    "<br>理由：" + overWork.Reason;
                    calendarADay.DayItems.Add(day);

                    MonthItem month = new MonthItem();
                    month.ObjectID = originalDataItem.ItemID;
                    month.CType = CalendarShowType.OverWork;
                    month.Title = typeName + " " + originalDataItem.CostTime + "小时";
                    month.Date = originalDataItem.FromDate;
                    month.Detail = typeName + " 时段：" +
                                   originalDataItem.FromDate.ToShortDateString() + " " +
                                   originalDataItem.FromDate.ToShortTimeString() + "--" +
                                   originalDataItem.ToDate.ToShortDateString() + " " +
                                   originalDataItem.ToDate.ToShortTimeString() + " 加班时间(小时)：" +
                                   originalDataItem.CostTime + " 项目：" + overWork.ProjectName + " 理由：" + overWork.Reason;
                    calendarADay.MonthItems.Add(month);
                    Utility.Clean(calendarADay);
                }
            }
            return retList;
        }

    }
}
