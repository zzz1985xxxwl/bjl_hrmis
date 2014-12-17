//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: JudgeAdjustRestCanDelete.cs
// Creater: Xue.wenlong
// CreateDate: 2009-09-05
// Resume: 
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.EmployeeAdjustRest;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Model.Request;
using SEP.Model.Calendar;

namespace SEP.HRMIS.Bll.LeaveRequests
{
    /// <summary>
    /// 
    /// </summary>
    public class JudgeAdjustRestCanDelete
    {
        private readonly int _AccountID;
        private readonly List<LeaveRequestItem> _LeaveRequestItemList;
        private readonly List<AdjustRest> _AdjustRestDay = new List<AdjustRest>();

        /// <summary>
        /// 
        /// </summary>
        public JudgeAdjustRestCanDelete(List<LeaveRequestItem> items, int accountid)
        {
            _LeaveRequestItemList = items;
            _AccountID = accountid;
        }


        /// <summary>
        /// 
        /// </summary>
        public void Excute()
        {
            foreach (LeaveRequestItem item in _LeaveRequestItemList)
            {
                List<AdjustRest> rest = InitDayAttendanceList(item);
                _AdjustRestDay.AddRange(rest);
            }
            new DeleteAdjustRestByLeaveRequest(_LeaveRequestItemList[0], _AccountID,0).Excute(_AdjustRestDay);
        }


        private List<AdjustRest> InitDayAttendanceList(LeaveRequestItem item)
        {
            List<AdjustRest> adjustRestList = new List<AdjustRest>();
            CalculateCostHour cal =
                new CalculateCostHour(item.FromDate, item.ToDate, _AccountID,
                                      Convert.ToInt32(LeaveRequestTypeEnum.AdjustRest));
            cal.Excute();
            foreach (DayAttendance attendance in cal.DayAttendanceList)
            {
                AdjustRest ar = new AdjustRest();
                ar.AdjustYear = attendance.Date;
                ar.SurplusHours = attendance.Hours;
                adjustRestList.Add(ar);
            }
            return adjustRestList;
        }
    }
}