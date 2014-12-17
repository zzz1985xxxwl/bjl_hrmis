//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CalendarExtUIFacade.cs
// Creater:  Xue.wenlong
// Date:  2010-02-22
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.Model.CalendarExt;
using SEP.Model.SpecialDates;
using SEP.Presenter.CalendarExt.TurnToUIModel;

namespace SEP.Presenter.CalendarExt
{
    /// <summary>
    /// </summary>
    public class CalendarExtUIFacade
    {
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;

        /// <summary>
        /// 用于日月试图显示
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="start">开始时间，如月头</param>
        /// <param name="end">结束时间，如月末</param>
        /// <param name="typelist">要查询的类型，如0|2|3，代表查询班别，请假，外出</param>
        /// <returns></returns>
        public List<CalendarADay> GetCalendarADayList(string accountName, DateTime start, DateTime end, string typelist)
        {
            Account account;
            if (accountName == "self" || string.IsNullOrEmpty(accountName))
            {
                account = HttpContext.Current.Session["LoginInfo"] as Account;
            }
            else
            {
                account = _AccountBll.GetAccountByName(accountName);
            }

            List<CalendarADay> items = new CalendarADayList(account.Id, start, end, typelist).GetList();
            return Merge(items);
        }


        private static List<CalendarADay> Merge(IEnumerable<CalendarADay> list)
        {
            List<CalendarADay> items = new List<CalendarADay>();
            if (list != null)
            {
                foreach (CalendarADay day in list)
                {
                    Utility.Clean(day);
                    bool finded = false;
                    foreach (CalendarADay item in items)
                    {
                        if (item.Date.Date == day.Date.Date)
                        {
                            item.MonthItems.AddRange(day.MonthItems);
                            item.DayItems.AddRange(day.DayItems);
                            finded = true;
                            break;
                        }
                    }
                    if (!finded)
                    {
                        items.Add(day);
                    }
                }
            }
            return items;
        }

        /// <summary>
        /// 取法定假日
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<Holiday> GetHolidayList(DateTime start, DateTime end)
        {
            List<SpecialDate> specialDateList = BllInstance.SpecialDateBllInstance.GetAllSpecialDate(null);
            return SpecialDatesToHolidays.Turn(specialDateList);
        }

        /// <summary>
        /// 用于日试图显示
        /// </summary>
        public List<DayItem> GetDayItems(string accountName, DateTime date, string typelist)
        {
            List<DayItem> items = new List<DayItem>();
            List<CalendarADay> adayList =
                GetCalendarADayList(accountName, date, date.AddDays(1).AddSeconds(-1), typelist);
            foreach (CalendarADay day in adayList)
            {
                items.AddRange(day.DayItems);
            }
            return items;
        }
    }
}