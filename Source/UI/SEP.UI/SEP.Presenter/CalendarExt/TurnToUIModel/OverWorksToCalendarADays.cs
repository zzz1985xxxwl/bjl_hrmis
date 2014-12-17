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
                    string typeName = "�Ӱ�";
                    // -1 ȫ��;0 ����;1 �ύ;2 ��˲�ͨ��;3 ���ͨ��;4 ȡ�����;5 �ܾ�ȡ������;6 ��׼ȡ������;7 �����;8 ���ȡ����
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
                    day.DayDetail = typeName + " " + originalDataItem.CostTime + "Сʱ<br>��Ŀ��" + overWork.ProjectName +
                                    "<br>���ɣ�" + overWork.Reason;
                    calendarADay.DayItems.Add(day);

                    MonthItem month = new MonthItem();
                    month.ObjectID = originalDataItem.ItemID;
                    month.CType = CalendarShowType.OverWork;
                    month.Title = typeName + " " + originalDataItem.CostTime + "Сʱ";
                    month.Date = originalDataItem.FromDate;
                    month.Detail = typeName + " ʱ�Σ�" +
                                   originalDataItem.FromDate.ToShortDateString() + " " +
                                   originalDataItem.FromDate.ToShortTimeString() + "--" +
                                   originalDataItem.ToDate.ToShortDateString() + " " +
                                   originalDataItem.ToDate.ToShortTimeString() + " �Ӱ�ʱ��(Сʱ)��" +
                                   originalDataItem.CostTime + " ��Ŀ��" + overWork.ProjectName + " ���ɣ�" + overWork.Reason;
                    calendarADay.MonthItems.Add(month);
                    Utility.Clean(calendarADay);
                }
            }
            return retList;
        }

    }
}
