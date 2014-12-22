//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: GetOutApplication.cs
// Creater:  Xue.wenlong
// Date:  2009-04-13
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.OutApplications.MailAndPhone;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;
using SEP.Model.Calendar;

namespace SEP.HRMIS.Bll.OutApplications
{
    /// <summary>
    /// </summary>
    public class GetOutApplication
    {
        private static IOutApplication _OutApplicationDal = new OutApplicationDal();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly OutDiyProcessUtility _OutDiyProcessUtility = new OutDiyProcessUtility();

        /// <summary>
        /// for test
        /// </summary>
        public IOutApplication MockIOutApplication
        {
            set { _OutApplicationDal = value; }
        }

        /// <summary> 
        /// </summary>
        public OutApplication GetOutApplicationByOutApplicationID(int pKID)
        {
            OutApplication outapplication = _OutApplicationDal.GetOutApplicationByOutApplicationID(pKID);
            outapplication.Account = _AccountBll.GetAccountById(outapplication.Account.Id);
            return outapplication;
        }

        /// <summary> 
        /// </summary>
        public OutApplicationItem GetOutApplicationItemByItemID(int itemID)
        {
            return _OutApplicationDal.GetOutApplicationItemByItemID(itemID);
        }

        /// <summary>
        /// </summary>
        public List<OutApplication> GetAllOutApplicationByAccountID(int accountID)
        {
            List<OutApplication> outapplicationList = _OutApplicationDal.GetAllOutApplicationByAccountID(accountID);
            AccountDetail(outapplicationList);
            return outapplicationList;
        }


        /// <summary>
        /// </summary>
        public List<OutApplication> GetConfirmOutApplicationByNextOperatorID(int accountID)
        {
            List<OutApplication> OutApplicationList = _OutApplicationDal.GetNeedConfirmOutApplication();
            List<OutApplication> returnlist = new List<OutApplication>();
            foreach (OutApplication application in OutApplicationList)
            {
                bool error = false;
                foreach (OutApplicationItem item in application.Item)
                {
                    Account nextOperator = _OutDiyProcessUtility.GetNextOperator(application.DiyProcess,
                                                                                 item, application.Account.Id);

                    if (nextOperator == null || nextOperator.AccountType == VisibleType.None)
                    {
                        if (item.OutApplicationFlow[item.OutApplicationFlow.Count - 1].Step != -1)
                        {
                            _OutApplicationDal.UpdateOutApplicationItemStatusByItemID(item.ItemID,
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
                    new OutApplicationMail().SendErrorMail(application.PKID);
                }
            }
            AccountDetail(returnlist);
            return returnlist;
        }

        /// <summary>
        ///
        /// </summary>
        public List<OutApplication> GetConfirmHistroy(int accountID, string name, DateTime fromTime, DateTime toTime)
        {
            List<OutApplication> outapplicationListAll = _OutApplicationDal.GetConfirmHistroy(accountID, fromTime, toTime);
            List<OutApplication> outapplicationList = new List<OutApplication>();
            AccountDetail(outapplicationListAll);
            foreach (OutApplication item in outapplicationListAll)
            {
                if (item.Account.Name.Contains(name))
                {
                    outapplicationList.Add(item);
                }
            }
            return outapplicationList;
        }

        private static void AccountDetail(ICollection<OutApplication> outapplicationList)
        {
            if (outapplicationList != null && outapplicationList.Count > 0)
            {
                foreach (OutApplication application in outapplicationList)
                {
                    application.Account = _AccountBll.GetAccountById(application.Account.Id);
                }
            }
        }

        /// <summary>
        /// </summary>
        public List<OutApplicationFlow> GetOutApplicationFlowList(int outApplicationID)
        {
            List<OutApplicationFlow> flows = new List<OutApplicationFlow>();
            List<OutApplicationItem> items =
                _OutApplicationDal.GetOutApplicationItemByOutApplicationID(outApplicationID);
            if (items != null)
            {
                foreach (OutApplicationItem item in items)
                {
                    foreach (OutApplicationFlow flow in item.OutApplicationFlow)
                    {
                        flow.Item = item;
                        flow.Account = _AccountBll.GetAccountById(flow.Account.Id);
                        flows.Add(flow);
                    }
                }
            }
            return flows;
        }

        #region wyq

        /// <summary>
        /// 
        /// </summary>
        public List<DayAttendance> GetCalendarByEmployee(int AccountID, DateTime fromDate, DateTime toDate)
        {
            List<DayAttendance> dayAttendance = new List<DayAttendance>();
            List<OutApplicationItem> outApplicationItemList = new List<OutApplicationItem>();
            List<OutApplicationItem> outApplicationItemFromDal =
                _OutApplicationDal.GetOutApplicationForCalendar(AccountID, fromDate, toDate);
            foreach (OutApplicationItem item in outApplicationItemFromDal)
            {
                OutApplicationItem outApplicationItem =
                    _OutApplicationDal.GetOutApplicationItemByItemID(item.ItemID);
                item.OutApplicationID = outApplicationItem.OutApplicationID;
                if (item.Status == RequestStatus.Cancelled || item.Status == RequestStatus.CancelApproving)
                {
                    if (OutApplicationUtility.IsAgreed(outApplicationItem))
                    {
                        outApplicationItemList.Add(item);
                    }
                }
                else
                {
                    outApplicationItemList.Add(item);
                }
            }
            foreach (OutApplicationItem item in outApplicationItemList)
            {
                OutType outType = _OutApplicationDal.GetOutApplicationByOutApplicationID(item.OutApplicationID).OutType;
                if (outType.ID == OutType.InCity.ID || outType.ID == OutType.OutCity.ID)
                {
                    CalculateOutHour cal = new CalculateOutHour(item.FromDate, item.ToDate, AccountID);
                    cal.Excute();
                    dayAttendance.AddRange(cal.DayAttendanceList);
                }
                else if (outType.ID == OutType.OutCity.ID)
                {
                    CalculateOutCityHour cal = new CalculateOutCityHour(item.FromDate, item.ToDate, AccountID);
                    cal.Excute();
                    dayAttendance.AddRange(cal.DayAttendanceList);
                }
            }
            return dayAttendance;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<DayAttendance> GetAllCalendarByEmployee(int AccountID, DateTime fromDate, DateTime toDate)
        {
            List<DayAttendance> dayAttendance = new List<DayAttendance>();
            List<OutApplicationItem> outApplicationItemList = new List<OutApplicationItem>();
            List<OutApplicationItem> outApplicationItemFromDal =
                _OutApplicationDal.GetAllOutApplicationForCalendar(AccountID, fromDate, toDate);
            foreach (OutApplicationItem item in outApplicationItemFromDal)
            {
                OutApplicationItem outApplicationItem =
                    _OutApplicationDal.GetOutApplicationItemByItemID(item.ItemID);
                item.OutApplicationID = outApplicationItem.OutApplicationID;
                outApplicationItemList.Add(item);

                //if (item.Status == RequestStatus.Cancelled || item.Status == RequestStatus.CancelApproving)
                //{
                //    OutApplicationItem outApplicationItem =
                //        _OutApplicationDal.GetOutApplicationItemByItemID(item.ItemID);
                //    if (OutApplicationUtility.IsAgreed(outApplicationItem))
                //    {
                //        outApplicationItemList.Add(item);
                //    }
                //}
                //else
                //{
                //    outApplicationItemList.Add(item);
                //}
            }
            foreach (OutApplicationItem item in outApplicationItemList)
            {
                OutType outType = _OutApplicationDal.GetOutApplicationByOutApplicationID(item.OutApplicationID).OutType;
                if (outType.ID == OutType.InCity.ID)
                {
                    string typeName = "外出";
                    typeName = GetTypeName(item, typeName);
                    CalculateOutHour cal = new CalculateOutHour(item.FromDate, item.ToDate, AccountID, typeName);
                    cal.Excute();
                    dayAttendance.AddRange(cal.DayAttendanceList);
                }
                else if (outType.ID == OutType.OutCity.ID)
                {
                    string typeName = OutType.OutCity.Name;
                    typeName = GetTypeName(item, typeName);
                    CalculateOutCityHour cal = new CalculateOutCityHour(item.FromDate, item.ToDate, typeName, AccountID);
                    cal.Excute();
                    dayAttendance.AddRange(cal.DayAttendanceList);
                }
                else if (outType.ID == OutType.Train.ID)
                {
                    string typeName = OutType.Train.Name;
                    typeName = GetTypeName(item, typeName);
                    CalculateOutHour cal = new CalculateOutHour(item.FromDate, item.ToDate, AccountID, typeName);
                    cal.Excute();
                    dayAttendance.AddRange(cal.DayAttendanceList);
                }
            }
            return dayAttendance;
        }
        /// <summary>
        /// 获得与fromDate-toDate事件上有交集的外出信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<OutApplication> GetOutApplicationByAccountAndRelatedDate(int accountID, DateTime fromDate, DateTime toDate)
        {
            return _OutApplicationDal.GetOutApplicationByAccountAndRelatedDate(accountID, fromDate, toDate);
        }
        /// <summary>
        /// -1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 审核取消中
        /// </summary>
        /// <param name="item"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        private static string GetTypeName(OutApplicationItem item, string typeName)
        {
            if (item.Status == RequestStatus.New ||
                item.Status == RequestStatus.Submit ||
                item.Status == RequestStatus.Approving ||
                item.Status == RequestStatus.CancelApproving ||
                item.Status == RequestStatus.Cancelled)
            {
                typeName = typeName + "(" + item.Status.Name + ")";
            }
            return typeName;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<OutApplication> GetOutApplicationDetailByEmployee(int accountID, DateTime date)
        {
            List<OutApplication> fromdal = _OutApplicationDal.GetOutApplicationDetailByEmployee(accountID, date);
            List<OutApplication> toreturn = new List<OutApplication>();
            foreach (OutApplication application in fromdal)
            {
                toreturn.Add(application);
                //foreach (OutApplicationItem item in application.Item)
                //{
                //if (item.Status == RequestStatus.Cancelled || item.Status == RequestStatus.CancelApproving)
                //{
                //    if (OutApplicationUtility.IsAgreed(item))
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