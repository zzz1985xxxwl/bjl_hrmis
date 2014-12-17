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
using SEP.HRMIS.Model.OutApplication;

namespace SEP.HRMIS.Presenter.OutApplications
{
    public class CalculateOutHourPresenter
    {
       private readonly IOutApplicationFacade _IOutFacade = InstanceFactory.CreateOutApplicationFacade();
        private readonly string _FromDate;
        private readonly string _FromHour;
        private readonly string _FromMinute;
        private readonly string _ToDate;
        private readonly string _ToHour;
        private readonly string _ToMinute;
        private readonly int _AccountID;
        private readonly OutType _OutType;
        public CalculateOutHourPresenter(string fromDate, string fromHour, string fromMinute, string toDate, string toHour, string toMinute, int accountID,OutType type)
        {
            _FromDate = fromDate;
            _FromHour = fromHour;
            _FromMinute = fromMinute;
            _ToDate = toDate;
            _ToHour = toHour;
            _ToMinute = toMinute;
            _AccountID = accountID;
            _OutType = type;
        }
        
        public string  GetHour()
        {
            try
            {
                DateTime from = Convert.ToDateTime(DTS(_FromDate, _FromHour, _FromMinute));
                DateTime to = Convert.ToDateTime(DTS(_ToDate, _ToHour, _ToMinute));
                if(from>to)
                {
                    return "error";
                }
                if(_OutType.ID==OutType.OutCity.ID)
                {
                    return _IOutFacade.CalculateOutCityHour(from, to, _AccountID).ToString();
                }
                else
                {
                    return _IOutFacade.CalculateOutHour(from, to, _AccountID).ToString();
                }
              
            }
            catch
            {
                return "error";
            }
        }


        private static string DTS(string date,string hour,string minute)
        {
            DateTime dt=Convert.ToDateTime(date);
            return string.Format("{0} {1}:{2}:00", dt.ToShortDateString(), hour, minute);
        }
    }
}