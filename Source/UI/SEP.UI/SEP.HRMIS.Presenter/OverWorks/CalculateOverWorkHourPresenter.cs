//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CalculateOutHourPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-04-16
// Resume:
// ---------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.OverWork;

namespace SEP.HRMIS.Presenter.OverWorks
{
    public class CalculateOverWorkHourPresenter
    {
        private readonly IOverWorkFacade _IOverWorkFacade = InstanceFactory.CreateOverWorkFacade();
        private readonly string _FromDate;
        private readonly string _FromHour;
        private readonly string _FromMinute;
        private readonly string _ToDate;
        private readonly string _ToHour;
        private readonly string _ToMinute;
        private readonly int _AccountID;

        public CalculateOverWorkHourPresenter(string fromDate, string fromHour, string fromMinute, string toDate,
                                              string toHour, string toMinute, int accountID)
        {
            _FromDate = fromDate;
            _FromHour = fromHour;
            _FromMinute = fromMinute;
            _ToDate = toDate;
            _ToHour = toHour;
            _ToMinute = toMinute;
            _AccountID = accountID;
        }

        public string GetHour(out OverWorkType type)
        {
            type = OverWorkType.PuTong;
            try
            {
                DateTime from = Convert.ToDateTime(DTS(_FromDate, _FromHour, _FromMinute));
                DateTime to = Convert.ToDateTime(DTS(_ToDate, _ToHour, _ToMinute));
                if (from > to)
                {
                    return "error";
                }
                return _IOverWorkFacade.CalculateOverWorkHour(from, to, _AccountID, out type).ToString();
            }
            catch
            {
                return "error";
            }
        }


        private static string DTS(string date, string hour, string minute)
        {
            DateTime dt = Convert.ToDateTime(date);
            return string.Format("{0} {1}:{2}:00", dt.ToShortDateString(), hour, minute);
        }
    }
}