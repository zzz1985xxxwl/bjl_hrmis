//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CalculateLeaveRequestPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-03-27
// Resume:
// ---------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class CalculateLeaveRequestPresenter
    {
        private readonly ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();
        private readonly string _FromDate;
        private readonly string _FromHour;
        private readonly string _FromMinute;
        private readonly string _ToDate;
        private readonly string _ToHour;
        private readonly string _ToMinute;
        private readonly int _AccountID;
        private readonly int _LeaveRequestTypeID;
        public CalculateLeaveRequestPresenter(string fromDate,string fromHour,string fromMinute,string toDate,string toHour,string toMinute,int accountID,int leaveRequestTypeID)
        {
            _FromDate = fromDate;
            _FromHour = fromHour;
            _FromMinute = fromMinute;
            _ToDate = toDate;
            _ToHour = toHour;
            _ToMinute = toMinute;
            _AccountID = accountID;
            _LeaveRequestTypeID = leaveRequestTypeID;
        }
        
        public string  GetHour()
        {
            if (_LeaveRequestTypeID==-1)
            {
                return "error";
            }
            try
            {
                DateTime from = Convert.ToDateTime(DTS(_FromDate, _FromHour, _FromMinute));
                DateTime to = Convert.ToDateTime(DTS(_ToDate, _ToHour, _ToMinute));
                if(from>to)
                {
                    return "error";
                }
                return _ILeaveRequestFacade.CalculateCostHour(from, to, _AccountID, _LeaveRequestTypeID).ToString();
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