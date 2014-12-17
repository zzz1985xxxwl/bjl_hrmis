using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.Model.CalendarExt;
using SEP.Model.SpecialDates;

namespace SEP.Presenter.CalendarExt.TurnToUIModel
{
    public class OutApplicationsToCalendarADays
    {
        public static List<CalendarADay> Turn(List<OutApplication> originalDataList,
                List<PlanDutyDetail> planDutyDetailList, List<SpecialDate> specialList, List<CalendarADay> retList)
        {
            foreach (OutApplication outApplication in originalDataList)
            {
                foreach (OutApplicationItem originalDataItem in outApplication.Item)
                {
                    DateTime from = originalDataItem.FromDate;
                    DateTime to = originalDataItem.ToDate;
                    decimal costHour = 0m;
                    if (from >= to)
                    {
                        CreateOutApplicationInfoInADay(retList, from, 0, outApplication, originalDataItem, from, to);
                    }
                    int days = (to.Date - from.Date).Days;
                    DateTime date = from;
                    for (int i = 0; i <= days; i++)
                    {
                        PlanDutyDetail detail = PlanDutyDetail.GetPlanDutyDetailByDate(planDutyDetailList, date);

                        if (detail != null && detail.PlanDutyClass != null)
                        {
                            TimeSpan ts = detail.PlanDutyClass.FirstStartToTime -
                                          detail.PlanDutyClass.FirstStartFromTime;
                            DateTime fromtemp =
                                new DateTime(date.Year, date.Month, date.Day, detail.PlanDutyClass.FirstStartFromTime.Hour,
                                             detail.PlanDutyClass.FirstStartFromTime.Minute,
                                             detail.PlanDutyClass.FirstStartFromTime.Second);
                            DateTime totemp =
                                new DateTime(date.Year, date.Month, date.Day, detail.PlanDutyClass.SecondEndTime.Add(ts).Hour,
                                             detail.PlanDutyClass.SecondEndTime.Add(ts).Minute,
                                             detail.PlanDutyClass.SecondEndTime.Add(ts).Second);
                            if (i == 0)
                            {
                                fromtemp = from;
                            }
                            if (i == days)
                            {
                                totemp = to;
                            }
                            //�ų�˫����,�ڼ���
                            if (!detail.PlanDutyClass.IsWeek)
                            {
                                decimal hour = Utility.CalculateOneDay(fromtemp, totemp, 0, detail);
                                costHour += hour;
                                CreateOutApplicationInfoInADay(retList, date, hour, outApplication, originalDataItem,
                                                               fromtemp, totemp);

                            }
                        }
                        date = date.AddDays(1);
                    }
                }
            }
            return retList;
        }
        private static void CreateOutApplicationInfoInADay(List<CalendarADay> retList, DateTime date,
                decimal hour, OutApplication originalData, OutApplicationItem originalDataItem,
                DateTime from, DateTime to)
        {
            CalendarADay calendarADay = CalendarADay.CreateOrGetCalendarADayByDate(retList, date.Date);
            string typeName = originalData.OutType.Name;
            // -1 ȫ��;0 ����;1 �ύ;2 ��˲�ͨ��;3 ���ͨ��;4 ȡ�����;5 �ܾ�ȡ������;6 ��׼ȡ������;7 �����;8 ���ȡ����
            if (originalDataItem.Status == RequestStatus.New ||
                originalDataItem.Status == RequestStatus.Submit ||
                originalDataItem.Status == RequestStatus.Approving ||
                originalDataItem.Status == RequestStatus.CancelApproving ||
                originalDataItem.Status == RequestStatus.Cancelled)
            {
                typeName = typeName + "(" + originalDataItem.Status.Name + ")";
            }

            DayItem day = new DayItem();
            day.ObjectID = originalDataItem.ItemID;
            day.CType = CalendarShowType.Out;
            day.Start = from;
            day.End = to;
            day.DayDetail = typeName + " " + Convert.ToSingle(hour) + "Сʱ<br>�ص㣺" + originalData.OutLocation + "<br>���ɣ�" +
                            originalData.Reason;
            calendarADay.DayItems.Add(day);

            MonthItem month = new MonthItem();
            month.ObjectID = originalDataItem.ItemID;
            month.CType = CalendarShowType.Out;
            month.Title = typeName + " " + Convert.ToSingle(hour) + "Сʱ";
            month.Date = date;
            month.Detail = typeName + " ʱ�Σ�" +
                           originalDataItem.FromDate.ToShortDateString() + " " +
                           originalDataItem.FromDate.ToShortTimeString() + "--" +
                           originalDataItem.ToDate.ToShortDateString() + " " +
                           originalDataItem.ToDate.ToShortTimeString() + " ���ʱ��(Сʱ)��" +
                           originalDataItem.CostTime + " �ص㣺" + originalData.OutLocation + " ���ɣ�" + originalData.Reason;
            calendarADay.MonthItems.Add(month);
            Utility.Clean(calendarADay);
        }
    }
}
