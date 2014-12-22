//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: DeleteAdjustRestByDateTime.cs
// Creater: Xue.wenlong
// CreateDate: 2009-09-04
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Model.Enum;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Calendar;

namespace SEP.HRMIS.Bll.EmployeeAdjustRest
{
    /// <summary>
    /// 当申请的调休通过后，扣除调休
    /// </summary>
    public class DeleteAdjustRestByLeaveRequest
    {
        private readonly int _AccountID;
        private readonly LeaveRequestItem _LeaveRequestItem;
        private readonly int _LeaveRequestID;
        private readonly IAdjustRest _IAdjustRest = new AdjustRestDal();
        private readonly IAdjustRestHistory _IAdjustRestHistory = new AdjustRestHistoryDal();
        private static readonly ILeaveRequestDal _LeaveRequestDal = new LeaveRequestDal();
        private List<AdjustRest> _AdjustRestDay = new List<AdjustRest>();

        /// <summary>
        /// 
        /// </summary>
        public DeleteAdjustRestByLeaveRequest(LeaveRequestItem item, int accountid, int leaveRequsetID)
        {
            _LeaveRequestItem = item;
            _AccountID = accountid;
            _LeaveRequestID = leaveRequsetID;
        }


        /// <summary>
        /// 将请的调休分到每一天
        /// 然后看要更新那些调休，让好取出
        /// 更新调休
        /// 然后记录历史
        /// </summary>
        public void Excute()
        {
            _AdjustRestDay = InitDayAttendanceList(_LeaveRequestItem);
            List<AdjustRest> UpdateadjustRestList = InitUpdateAdjustRestList(_AdjustRestDay);
            UpdateAdjustRestDB(UpdateadjustRestList, true);
            CreateHistory();
        }

        /// <summary>
        /// 用于验证是否可以删除
        /// </summary>
        /// <param name="adjustRestList"></param>
        public void Excute(List<AdjustRest> adjustRestList)
        {
            _AdjustRestDay = adjustRestList;
            List<AdjustRest> UpdateadjustRestList = InitUpdateAdjustRestList(adjustRestList);
            UpdateAdjustRestDB(UpdateadjustRestList, false);
        }

        /// <summary>
        /// 更新调休
        /// </summary>
        private void UpdateAdjustRestDB(IEnumerable<AdjustRest> UpdateadjustRestList, bool isupdate)
        {
            _LeaveRequestItem.UseList = "";
            //初始化要扣除的调休
            List<AdjustRest> adjustRestList = new List<AdjustRest>();
            foreach (AdjustRest rest in UpdateadjustRestList)
            {
                AdjustRest adjustRest = _IAdjustRest.GetAdjustRestByAccountIDAndYear(_AccountID, rest.AdjustYear);
                adjustRestList.Add(adjustRest);
            }
            if (adjustRestList.Count > 0)
            {
                foreach (AdjustRest rest in _AdjustRestDay)
                {
                    AdjustRest adjustFirst = ContainByYear(rest.AdjustYear, adjustRestList);
                    AdjustRest adjustSecond = Contain(rest.AdjustYear, adjustRestList);
                    //同年说明只扣一条记录
                    if (adjustFirst.AdjustYear.Year == adjustSecond.AdjustYear.Year)
                    {
                        adjustFirst.SurplusHours -= rest.SurplusHours;
                        adjustFirst.ChangeHours += rest.SurplusHours;
                    }
                    else
                    {
                        //不同年则扣第二年的记录，如果扣不了，则还是扣第一年的记录
                        decimal chagehour = adjustSecond.SurplusHours - rest.SurplusHours;
                        if (chagehour < 0)
                        {
                            if (adjustSecond.SurplusHours > 0)
                            {
                                adjustFirst.SurplusHours += chagehour;
                                adjustFirst.ChangeHours += (-chagehour);
                                adjustSecond.ChangeHours += adjustSecond.SurplusHours;
                                adjustSecond.SurplusHours = 0;
                            }
                            else
                            {
                                adjustFirst.SurplusHours -= rest.SurplusHours;
                                adjustFirst.ChangeHours += rest.SurplusHours;
                            }
                        }
                        else
                        {
                            adjustSecond.ChangeHours += rest.SurplusHours;
                            adjustSecond.SurplusHours = chagehour;
                        }
                    }
                }
                foreach (AdjustRest rest in adjustRestList)
                {
                    if (rest.SurplusHours < 0)
                    {
                        HrmisUtility.ThrowException("剩余调休不足");
                    }
                    if (isupdate)
                    {
                        _IAdjustRest.UpdateAdjustRest(rest);
                        _LeaveRequestItem.UseList =
                            string.Format("{0},{1}/{2}", rest.AdjustRestID, rest.ChangeHours,
                                          _LeaveRequestItem.UseList);
                    }
                }
                if (isupdate)
                {
                    //记录下使用情况
                    _LeaveRequestDal.UpdateLeaveRequestItemUseDetail(_LeaveRequestItem);
                }
            }
            else
            {
                HrmisUtility.ThrowException("剩余调休不足");
            }
        }

        /// <summary>
        /// 记录历史
        /// </summary>
        private void CreateHistory()
        {
            string remark;
            AdjustRestHistory _AdjustRestHistory =
                UpdateAdjustRestByOperator.GetNewAdjustRestHistory(AdjustRestHistoryTypeEnum.AdjustRestRequest,
                                                                   _AccountID);
            remark = _LeaveRequestItem.FromDate + " - " + _LeaveRequestItem.ToDate + " 调休" +
                     _LeaveRequestItem.CostTime +
                     "小时";
            _AdjustRestHistory.ChangeHours = -_LeaveRequestItem.CostTime;
            _AdjustRestHistory.Remark = remark;
            _AdjustRestHistory.RelevantID = _LeaveRequestID;
            _IAdjustRestHistory.InsertAdjustRestHistory(_AccountID, _AdjustRestHistory);
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

        ///<summary>
        /// 初始化有多少个要更改的adjustrest
        ///</summary>
        public static List<AdjustRest> InitUpdateAdjustRestList(List<AdjustRest> adjustRestList)
        {
            List<AdjustRest> UpdateadjustRestList = new List<AdjustRest>();
            foreach (AdjustRest rest in adjustRestList)
            {
                AdjustRest findrest = ContainByYear(rest.AdjustYear, UpdateadjustRestList);
                if (findrest == null)
                {
                    //判断是不是12月21号以后
                    if (rest.AdjustYear.Month == AdjustRestUtility.StartTime.Month &&
                        rest.AdjustYear.Day >= AdjustRestUtility.StartTime.Day)
                    {
                        AdjustRest r = new AdjustRest();
                        r.AdjustYear = rest.AdjustYear.AddYears(1);
                        r.SurplusHours = rest.SurplusHours;
                        UpdateadjustRestList.Add(r);
                    }
                    else
                    {
                        UpdateadjustRestList.Add(rest);
                    }
                }
                if (rest.AdjustYear.Date <=
                    new DateTime(WhichYear(rest.AdjustYear), AdjustRestUtility.AvailableTime.Month,
                                 AdjustRestUtility.AvailableTime.Day)
                    &&
                    rest.AdjustYear.Date >=
                    new DateTime(WhichYear(rest.AdjustYear) - 1, AdjustRestUtility.StartTime.Month,
                                 AdjustRestUtility.StartTime.Day))
                {
                    if (
                        ContainByYear(
                            new DateTime(WhichYear(rest.AdjustYear)-1, 1, 1),
                            UpdateadjustRestList) == null)
                    {
                        UpdateadjustRestList.Add(
                            new AdjustRest(0, rest.SurplusHours, rest.Employee, new DateTime(WhichYear(rest.AdjustYear) - 1, 1, 1)));
                    }
                }
            }
            return UpdateadjustRestList;
        }

        /// <summary>
        /// 
        /// </summary>
        public static AdjustRest Contain(DateTime year, IEnumerable<AdjustRest> adjusrRestList)
        {
            if (year.Date <=
                    new DateTime(WhichYear(year), AdjustRestUtility.AvailableTime.Month,
                                 AdjustRestUtility.AvailableTime.Day)
                    &&
                    year.Date >=
                    new DateTime(WhichYear(year) - 1, AdjustRestUtility.StartTime.Month,
                                 AdjustRestUtility.StartTime.Day))
            {
                return ContainByYear(new DateTime(WhichYear(year) - 1, 1, 1), adjusrRestList);
            }
            else
            {
                return ContainByYear(year, adjusrRestList);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static AdjustRest ContainByYear(DateTime year, IEnumerable<AdjustRest> adjusrRestList)
        {
            foreach (AdjustRest adjustRest in adjusrRestList)
            {
                if (
                    new DateTime(adjustRest.AdjustYear.Year - 1, AdjustRestUtility.StartTime.Month,
                                 AdjustRestUtility.StartTime.Day) <= year.Date &&
                    year.Date <=
                    new DateTime(adjustRest.AdjustYear.Year, AdjustRestUtility.StartTime.Month,
                                 AdjustRestUtility.StartTime.Day - 1))
                {
                    return adjustRest;
                }
            }
            return null;
        }

        private static int WhichYear(DateTime year)
        {
            if (year.Month == AdjustRestUtility.StartTime.Month && year.Day >= AdjustRestUtility.StartTime.Day)
            {
                return year.Year + 1;
            }
            return year.Year;
        }
    }
}