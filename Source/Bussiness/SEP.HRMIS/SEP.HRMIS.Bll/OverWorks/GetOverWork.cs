//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: GetOverWork.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.OverWorks.MailAndPhone;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.Model.Calendar;

namespace SEP.HRMIS.Bll.OverWorks
{
    /// <summary>
    /// </summary>
    public class GetOverWork
    {
        private static IOverWork _OverWorkDal = new OverWorkDal();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly OverWorkDiyProcessUtility _OverWorkDiyProcessUtility = new OverWorkDiyProcessUtility();

        /// <summary>
        /// for test
        /// </summary>
        public IOverWork MockIOverWork
        {
            set { _OverWorkDal = value; }
        }

        /// <summary> 
        /// </summary>
        public OverWork GetOverWorkByOverWorkID(int pKID)
        {
            OverWork OverWork = _OverWorkDal.GetOverWorkByOverWorkID(pKID);
            OverWork.Account = _AccountBll.GetAccountById(OverWork.Account.Id);
            return OverWork;
        }

        /// <summary>
        /// </summary>
        public OverWorkItem GetOverWorkItemByItemID(int itemID)
        {
            return _OverWorkDal.GetOverWorkItemByItemID(itemID);
        }

        /// <summary>
        /// </summary>
        public List<OverWork> GetAllOverWorkByAccountID(int accountID)
        {
            List<OverWork> OverWorkList = _OverWorkDal.GetAllOverWorkByAccountID(accountID);
            AccountDetail(OverWorkList);
            return OverWorkList;
        }

        /// <summary>
        /// </summary>
        public List<OverWork> GetConfirmOverWorkByNextOperatorID(int accountID)
        {
            List<OverWork> OverWorkList = _OverWorkDal.GetNeedConfirmOverWork();
            List<OverWork> returnlist = new List<OverWork>();
            foreach (OverWork application in OverWorkList)
            {
                bool error = false;
                foreach (OverWorkItem item in application.Item)
                {
                    Account nextOperator = _OverWorkDiyProcessUtility.GetNextOperator(application.DiyProcess,
                                                                                      item, application.Account.Id);

                    if (nextOperator == null || nextOperator.AccountType == VisibleType.None)
                    {
                        if (item.OverWorkFlow[item.OverWorkFlow.Count - 1].Step != -1)
                        {
                            _OverWorkDal.UpdateOverWorkItemStatusByItemID(item.ItemID,
                                                                          RequestUtility.MakeDisAggree(
                                                                              item.Status));
                            error = true;
                            continue;
                        }
                    }
                    else if (accountID == nextOperator.Id)
                    {
                        returnlist.Add(application);
                        break;
                    }
                }
                if (error)
                {
                    new OverWorkMail().SendErrorMail(application.PKID);
                }
            }
            AccountDetail(returnlist);
            return returnlist;
        }

        /// <summary>
        ///
        /// </summary>
        public List<OverWork> GetConfirmHistroy(int accountID, string name, bool? adjust, DateTime fromTime, DateTime toTime)
        {
            List<OverWork> OverWorkListAll = _OverWorkDal.GetConfirmHistroy(accountID, fromTime, toTime);
            List<OverWork> OverWorkList = new List<OverWork>();
            AccountDetail(OverWorkListAll);
            foreach (OverWork item in OverWorkListAll)
            {
                if (item.Account.Name.Contains(name))
                {
                    OverWorkList.Add(item);
                }
            }

            return IsAdjustOverWork(OverWorkList, adjust);

        }

        private List<OverWork> IsAdjustOverWork(List<OverWork> theOverWorkList, bool? adjust)
        {
            if (adjust == null)
            {
                return theOverWorkList;
            }
            else
            {
                List<OverWork> OverWorkListAdjust = new List<OverWork>();
                foreach (OverWork item in theOverWorkList)
                {
                    foreach (OverWorkItem owitem in item.Item)
                    {
                        if (owitem.Adjust == adjust)
                        {
                            OverWorkListAdjust.Add(item);
                            break;
                        }
                    }
                }
                return OverWorkListAdjust;
            }
        }

        /// <summary>
        /// </summary>
        public List<OverWorkFlow> GetOverWorkFlowList(int OverWorkID)
        {
            List<OverWorkFlow> flows = new List<OverWorkFlow>();
            List<OverWorkItem> items = _OverWorkDal.GetOverWorkItemByOverWorkID(OverWorkID);
            if (items != null)
            {
                foreach (OverWorkItem item in items)
                {
                    foreach (OverWorkFlow flow in item.OverWorkFlow)
                    {
                        flow.Item = item;
                        flow.Account = _AccountBll.GetAccountById(flow.Account.Id);
                        flows.Add(flow);
                    }
                }
            }
            return flows;
        }

        private static void AccountDetail(ICollection<OverWork> OverWorkList)
        {
            if (OverWorkList != null && OverWorkList.Count > 0)
            {
                foreach (OverWork application in OverWorkList)
                {
                    application.Account = _AccountBll.GetAccountById(application.Account.Id);
                    application.SurplusAdjustRest =
                        new GetAdjustRest().GetNowAdjustRestByAccountID(application.Account.Id).SurplusHours;
                }
            }
        }

        #region wyq

        /// <summary>
        /// 
        /// </summary>
        public List<DayAttendance> GetCalendarByEmployee(int AccountID, DateTime fromDate, DateTime toDate)
        {
            List<DayAttendance> dayAttendanceList = new List<DayAttendance>();
            List<OverWorkItem> OverWorkItemList = new List<OverWorkItem>();
            List<OverWorkItem> OverWorkItemFromDal =
                _OverWorkDal.GetOverWorkForCalendar(AccountID, fromDate, toDate);
            foreach (OverWorkItem item in OverWorkItemFromDal)
            {
                if (item.Status == RequestStatus.Cancelled || item.Status == RequestStatus.CancelApproving)
                {
                    OverWorkItem OverWorkItem =
                        _OverWorkDal.GetOverWorkItemByItemID(item.ItemID);
                    if (OverWorkUtility.IsAgreed(OverWorkItem))
                    {
                        OverWorkItemList.Add(item);
                    }
                }
                else
                {
                    OverWorkItemList.Add(item);
                }
            }
            //由于加班的一项只能是一天，所以直接加就可以了
            foreach (OverWorkItem item in OverWorkItemList)
            {
                DayAttendance dayAttendance;
                if (!item.Adjust)
                {
                    dayAttendance =
                        new DayAttendance(-1, OverWorkUtility.GetOverWorkTypeNotAdjustName(item.OverWorkType),
                                          item.CostTime, 0, item.FromDate, "", CalendarType.OverTime);
                    dayAttendance.FromTime = fromDate;
                    dayAttendance.ToTime = toDate;
                    dayAttendanceList.Add(dayAttendance);
                }
                dayAttendance =
                    new DayAttendance(-1, OverWorkUtility.GetOverWorkTypeName(item.OverWorkType), item.CostTime, 0,
                                      item.FromDate, "", CalendarType.OverTime);
                dayAttendance.FromTime = fromDate;
                dayAttendance.ToTime = toDate;
                dayAttendanceList.Add(dayAttendance);
            }
            return dayAttendanceList;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<DayAttendance> GetAllCalendarByEmployee(int AccountID, DateTime fromDate, DateTime toDate)
        {
            List<DayAttendance> dayAttendanceList = new List<DayAttendance>();
            List<OverWorkItem> OverWorkItemList = 
                _OverWorkDal.GetAllOverWorkForCalendar(AccountID, fromDate, toDate);
            //由于加班的一项只能是一天，所以直接加就可以了
            foreach (OverWorkItem item in OverWorkItemList)
            {
                string typeName = "加班";
                // -1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
                if (item.Status == RequestStatus.New ||
                    item.Status == RequestStatus.Submit ||
                    item.Status == RequestStatus.Approving ||
                    item.Status == RequestStatus.CancelApproving ||
                    item.Status == RequestStatus.Cancelled)
                {
                    typeName = typeName + "(" + item.Status.Name + ")";
                }
                DayAttendance dayAttendance =
                    new DayAttendance(-1, typeName, item.CostTime, 0, item.FromDate, "", CalendarType.OverTime);
                dayAttendance.FromTime = fromDate;
                dayAttendance.ToTime = toDate;
                dayAttendanceList.Add(dayAttendance);
            }
            return dayAttendanceList;
        }
        /// <summary>
        /// 获得与fromDate-toDate事件上有交集的加班信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<OverWork> GetOverWorkByAccountAndRelatedDate(int accountID, DateTime fromDate, DateTime toDate)
        {
            List<OverWork> OverWorkItemFromDal =
                _OverWorkDal.GetOverWorkByAccountAndRelatedDate(accountID, fromDate, toDate);
            return OverWorkItemFromDal;
        }
        /// <summary>
        /// 
        /// </summary>
        public List<OverWork> GetOverWorkDetailByEmployee(int accountID, DateTime date)
        {
            List<OverWork> fromdal = _OverWorkDal.GetOverWorkDetailByEmployee(accountID, date);
            List<OverWork> toreturn = new List<OverWork>();
            foreach (OverWork application in fromdal)
            {
                toreturn.Add(application);

                //foreach (OverWorkItem item in application.Item)
                //{
                //if (item.Status == RequestStatus.Cancelled || item.Status == RequestStatus.CancelApproving)
                //{
                //    if (OverWorkUtility.IsAgreed(item))
                //    {
                //        toreturn.Add(application);
                //        break;
                //    }
                //}
                //else if (item.Status == RequestStatus.ApprovePass || item.Status == RequestStatus.ApproveCancelFail)
                //{
                //    toreturn.Add(application);
                //    break;
                //}
                //}
            }
            return toreturn;
        }

        #endregion
    }
}