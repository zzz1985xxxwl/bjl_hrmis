//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IOverWork.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// </summary>
    public interface IOverWork
    {
        ///<summary>
        /// 查询申请
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="formTime"></param>
        ///<param name="toTime"></param>
        ///<param name="status"></param>
        ///<returns></returns>
        List<OverWork> GetOverWorkByCondition(int employeeID, DateTime formTime, DateTime toTime,
            RequestStatus status);

        /// <summary>
        /// </summary>
        int InsertOverWork(OverWork OverWork);

        /// <summary>
        /// </summary>
        int UpdateOverWork(OverWork OverWork);

        /// <summary>
        /// </summary>
        int UpdateOverWorkItemStatusByItemID(int itemID, RequestStatus status);

        /// <summary>
        /// </summary>
        int UpdateOverWorkItemAdjustByItemID(int itemID, bool isAdjust, decimal adjustHour);

        ///<summary>
        ///</summary>
        int DeleteOverWorkByPKID(int pkid);

        /// <summary>
        /// </summary>
        int InsertOverWorkItem(int OverWorkID, OverWorkItem item);

        ///<summary>
        ///</summary>
        List<OverWork> GetAllOverWorkByAccountID(int accountID);

        ///<summary>
        ///</summary>
        List<OverWorkItem> GetOverWorkItemByOverWorkID(int OverWorkID);

        ///<summary>
        ///</summary>
        OverWorkItem GetOverWorkItemByItemID(int itemID);

        ///<summary>
        ///</summary>
        OverWork GetOverWorkByOverWorkID(int pKID);

        /// <summary>
        /// </summary>
        int DeleteOverWorkItemByOverWorkID(int OverWorkID);

        /// <summary>
        /// </summary>
        int CountOverWorkInRepeatDateDiffPKID(int AccountID, int? OverWorkID, DateTime from, DateTime to);

        /// <summary> 
        /// </summary>
        int DeleteOverWorkFlowByItemID(int itemID);

        /// <summary> 
        /// </summary>
        int InsertOverWorkFlow(int OverWorkItemID, OverWorkFlow outFlow);

        /// <summary>
        /// 得到要审核的外出
        /// </summary>
        List<OverWork> GetNeedConfirmOverWork();

        /// <summary>
        /// 
        /// </summary>
        List<OverWork> GetConfirmHistroy(int accountID, DateTime fromTime, DateTime toTime);

        #region wyq

        /// <summary>
        /// 
        /// </summary>
        List<OverWorkItem> GetOverWorkForCalendar(int accountID, DateTime from, DateTime to);
        /// <summary>
        /// 
        /// </summary>
        List<OverWorkItem> GetAllOverWorkForCalendar(int accountID, DateTime from, DateTime to);

        /// <summary>
        /// 
        /// </summary>
        List<OverWork> GetOverWorkDetailByEmployee(int accountID, DateTime date);
        /// <summary>
        /// 为高级日历的数据获取
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        List<OverWork> GetOverWorkByAccountAndRelatedDate(int accountID, DateTime from, DateTime to);
        #endregion
    }
}