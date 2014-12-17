//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IOutApplication.cs
// Creater:  Xue.wenlong
// Date:  2009-04-13
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.IDal
{
    /// <summary>
    /// </summary>
    public interface IOutApplication
    {
        ///<summary>
        /// 查询申请
        ///</summary>
        List<OutApplication> GetOutApplicationByCondition(int employeeID, DateTime formTime, DateTime toTime,
                                                         RequestStatus status,OutType type);
        /// <summary>
        /// </summary>
        int InsertOutApplication(OutApplication outapplication);

        /// <summary>
        /// </summary>
        int UpdateOutApplication(OutApplication outapplication);

        /// <summary>
        /// </summary>
        int UpdateOutApplicationItemStatusByItemID(int itemID, RequestStatus status);

        ///<summary>
        ///</summary>
        int DeleteOutApplicationByPKID(int pkid);

        /// <summary>
        /// </summary>
        int InsertOutApplicationItem(int OutApplicationID, OutApplicationItem item);

        /// <summary>
        /// </summary>
        int UpdateOutApplicationItem(int OutApplicationID, OutApplicationItem item);

        /// <summary>
        /// </summary>
        int DeleteOutApplicationItem(int OutApplicationItemID);
        
        ///<summary>
        ///</summary>
        List<OutApplication> GetAllOutApplicationByAccountID(int accountID);

        ///<summary>
        ///</summary>
        List<OutApplicationItem> GetOutApplicationItemByOutApplicationID(int OutApplicationID);

        ///<summary>
        ///</summary>
        OutApplicationItem GetOutApplicationItemByItemID(int itemID);

        ///<summary>
        ///</summary>
        OutApplication GetOutApplicationByOutApplicationID(int pKID);

        /// <summary>
        /// </summary>
        int DeleteOutApplicationItemByOutApplicationID(int OutApplicationID);

        /// <summary>
        /// </summary>
        int CountOutApplicationInRepeatDateDiffPKID(int AccountID, int? outApplicationID, DateTime from, DateTime to);

        /// <summary> 
        /// </summary>
        int DeleteOutApplicationFlowByItemID(int itemID);

        /// <summary> 
        /// </summary>
        int InsertOutApplicationFlow(int outApplicationItemID, OutApplicationFlow outFlow);

        /// <summary>
        /// 得到自己要审核的外出
        /// </summary>
        List<OutApplication> GetNeedConfirmOutApplication();

        /// <summary>
        /// 
        /// </summary>
        List<OutApplication> GetConfirmHistroy(int accountID, DateTime fromTime, DateTime toTime);

        /// <summary>
        /// </summary>
        int UpdateOutApplicationItemAdjustByItemID(int itemID, bool isAdjust, decimal adjustHour);

        #region add by wyq todo

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        List<OutApplicationItem> GetOutApplicationForCalendar(int accountID, DateTime from, DateTime to);
        ///<summary>
        ///</summary>
        ///<param name="accountID"></param>
        ///<param name="from"></param>
        ///<param name="to"></param>
        ///<returns></returns>
        List<OutApplicationItem> GetAllOutApplicationForCalendar(int accountID, DateTime from, DateTime to);
        /// <summary>
        /// 
        /// </summary>
        List<OutApplication> GetOutApplicationDetailByEmployee(int accountID, DateTime date);
        /// <summary>
        /// 为高级日历的数据获取
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        List<OutApplication> GetOutApplicationByAccountAndRelatedDate(int accountID, DateTime from, DateTime to);
        #endregion
    }
}