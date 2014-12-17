//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: AddAdjustRestByDateTime.cs
// Creater: Xue.wenlong
// CreateDate: 2009-09-04
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.EmployeeAdjustRules;
using SEP.HRMIS.Bll.OutApplications;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.Enum;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.Model.Calendar;
using SEP.Model.SpecialDates;

namespace SEP.HRMIS.Bll.EmployeeAdjustRest
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateAdjustRestByOut
    {
        private readonly OutApplicationItem _OutApplicationItem;
        private readonly int _AccountID;
        private readonly IAdjustRest _IAdjustRest = DalFactory.DataAccess.CreateAdjustRest();
        private readonly IAdjustRestHistory _IAdjustRestHistory = DalFactory.DataAccess.CreateAdjustRestHistory();
        private readonly AdjustRule _AdjustRule;
        private decimal _ChangeHour = 0;

        /// <summary>
        /// 
        /// </summary>
        public UpdateAdjustRestByOut(OutApplicationItem item, int accountid)
        {
            _OutApplicationItem = item;
            _AccountID = accountid;
            _AdjustRule = new GetEmployeeAdjustRule().GetAdjustRuleByAccountID(accountid);
            if (_AdjustRule == null)
            {
                _AdjustRule = new AdjustRule(0, "", 0, 0, 0, 0, 0, 0);
            }
        }


        /// <summary>
        /// 先初始化OperatorType，看是否要更新调休
        /// 然后将出差记录分成一天一天的记录
        /// 将同年的出差记录合并
        /// 更新合并后的调休，以处理跨年现象
        /// 记录历史
        /// </summary>
        public void Excute()
        {
            if (_OutApplicationItem.Adjust)
            {
                OperatorType operatorType = InitOperatorType();
                if (operatorType != OperatorType.empty)
                {
                    List<AdjustRest> adjustRestList = InitAdjustRestListIner();
                    List<AdjustRest> UpdateadjustRestList = InitUpdateAdjustRestList(adjustRestList);
                    UpdateAdjustRestDB(operatorType, UpdateadjustRestList);
                    if (_ChangeHour != 0)
                    {
                        CreateHistory(operatorType);
                    }
                }
            }
        }

        /// <summary>
        /// 更新调休
        /// </summary>
        /// <param name="operatorType"></param>
        /// <param name="UpdateadjustRestList"></param>
        private void UpdateAdjustRestDB(OperatorType operatorType, IEnumerable<AdjustRest> UpdateadjustRestList)
        {
            foreach (AdjustRest rest in UpdateadjustRestList)
            {
                AdjustRest adjustRest = _IAdjustRest.GetAdjustRestByAccountIDAndYear(_AccountID, rest.AdjustYear);
                if (operatorType == OperatorType.add)
                {
                    adjustRest.SurplusHours = adjustRest.SurplusHours + rest.SurplusHours; //获得调休
                    _ChangeHour += rest.SurplusHours;
                }
                else if (operatorType == OperatorType.delete)
                {
                    adjustRest.SurplusHours = adjustRest.SurplusHours - rest.SurplusHours; //返还调休
                    _ChangeHour += rest.SurplusHours;
                }
                _IAdjustRest.UpdateAdjustRest(adjustRest);
            }
        }

        /// <summary>
        /// 记录历史
        /// </summary>
        /// <param name="operatorType"></param>
        private void CreateHistory(OperatorType operatorType)
        {
            string remark = "";
            AdjustRestHistory _AdjustRestHistory =
                UpdateAdjustRestByOperator.GetNewAdjustRestHistory(AdjustRestHistoryTypeEnum.OutCityApplication,
                                                                   _AccountID);
            if (operatorType == OperatorType.add)
            {
                remark = _OutApplicationItem.FromDate + " - " + _OutApplicationItem.ToDate + " 出差" +
                         _OutApplicationItem.CostTime +
                         "小时";
                _AdjustRestHistory.ChangeHours = _ChangeHour;
            }
            else if (operatorType == OperatorType.delete)
            {
                remark = _OutApplicationItem.FromDate + " - " + _OutApplicationItem.ToDate + " 取消出差" +
                         _OutApplicationItem.CostTime +
                         "小时";
                _AdjustRestHistory.ChangeHours = -_ChangeHour;
            }
            _AdjustRestHistory.Remark = remark;
            _AdjustRestHistory.RelevantID = _OutApplicationItem.OutApplicationID;
            _IAdjustRestHistory.InsertAdjustRestHistory(_AccountID, _AdjustRestHistory);
        }

        ///<summary>
        /// 合并同年调休
        ///</summary>
        public static List<AdjustRest> InitUpdateAdjustRestList(List<AdjustRest> adjustRestList)
        {
            List<AdjustRest> UpdateadjustRestList = new List<AdjustRest>();
            foreach (AdjustRest rest in adjustRestList)
            {
                AdjustRest findrest = Contain(rest.AdjustYear, UpdateadjustRestList);
                if (findrest != null)
                {
                    findrest.SurplusHours += rest.SurplusHours;
                }
                else
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
            }
            return UpdateadjustRestList;
        }

        private List<AdjustRest> InitAdjustRestListIner()
        {
            List<AdjustRest> adjustRestList = new List<AdjustRest>();
            AdjustRest ar = new AdjustRest();
            ar.AdjustYear = _OutApplicationItem.ToDate;
            ar.SurplusHours = _OutApplicationItem.AdjustHour;
            adjustRestList.Add(ar);
            return adjustRestList;
        }

        /// <summary>
        /// 初始化调休，将出差信息变成一条条调休记录
        /// </summary>
        /// <returns></returns>
        private List<AdjustRest> InitAdjustRestList()
        {
            List<AdjustRest> adjustRestList = new List<AdjustRest>();
            DateTime from = _OutApplicationItem.FromDate;
            DateTime to = _OutApplicationItem.ToDate;
            CalculateDays _CalculateDays = new CalculateDays(BllInstance.SpecialDateBllInstance.GetAllSpecialDate(null));
            List<PlanDutyDetail> _PlanDutyDetailList =
                DalFactory.DataAccess.CreatePlanDutyDal().GetPlanDutyDetailByAccount(_AccountID, from, to);

            CalculateOutCityHour calculateOutCityHour = new CalculateOutCityHour(from, to, _AccountID);
            calculateOutCityHour.Excute();
            foreach (DayAttendance attendance in calculateOutCityHour.DayAttendanceList)
            {
                PlanDutyDetail planDutyDetail =
                    PlanDutyDetail.GetPlanDutyDetailByDate(_PlanDutyDetailList, attendance.Date);
                AdjustRest ar = new AdjustRest();
                ar.AdjustYear = attendance.Date;
                if (_CalculateDays.IsNationalHoliday(attendance.Date))
                {
                    //节日
                    ar.SurplusHours = attendance.Hours*_AdjustRule.OutCityJieRiRate;
                }

                else if (planDutyDetail.PlanDutyClass.IsWeek)
                {
                    //双休
                    ar.SurplusHours = attendance.Hours*_AdjustRule.OutCityShuangXiuRate;
                }
                else
                {
                    //普通
                    ar.SurplusHours = 0; //attendance.Hours*_AdjustRule.OutCityPuTongRate;
                }
                adjustRestList.Add(ar);
            }
            return adjustRestList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetItemAdjustHour()
        {
            decimal a = 0;
            List<AdjustRest> adjustRest = InitAdjustRestList();
            foreach (AdjustRest rest in adjustRest)
            {
                a += rest.SurplusHours;
            }
            return a;
        }

        private enum OperatorType
        {
            empty,
            add,
            delete
        }

        private OperatorType InitOperatorType()
        {
            if (_OutApplicationItem.Status.Id == RequestStatus.ApprovePass.Id)
            {
                return OperatorType.add;
            }
            if (OutApplicationUtility.IsItemFlowContainStatus(_OutApplicationItem, RequestStatus.ApprovePass))
            {
                if (_OutApplicationItem.Status.Id == RequestStatus.ApproveCancelPass.Id
                    && !OutApplicationUtility.IsItemFlowContainStatus(_OutApplicationItem, RequestStatus.ApproveCancelPass))
                {
                    return OperatorType.delete;
                }
            }
            else
            {
                if (_OutApplicationItem.Status.Id == RequestStatus.ApproveCancelFail.Id)
                {
                    return OperatorType.add;
                }
                if (_OutApplicationItem.Status.Id == RequestStatus.ApproveCancelPass.Id
                    &&
                    OutApplicationUtility.IsItemFlowContainStatus(_OutApplicationItem,
                                                                     RequestStatus.ApproveCancelFail))
                {
                    return OperatorType.delete;
                }
            }
            return OperatorType.empty;
        }

        /// <summary>
        /// 
        /// </summary>
        private static AdjustRest Contain(DateTime year, IEnumerable<AdjustRest> adjustRestList)
        {
            foreach (AdjustRest adjustRest in adjustRestList)
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
    }
}