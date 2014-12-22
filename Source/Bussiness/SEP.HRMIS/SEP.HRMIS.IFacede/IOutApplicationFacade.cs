//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IOutApplicationFacade.cs
// Creater:  Xue.wenlong
// Date:  2009-04-13
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.OutApplication;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOutApplicationFacade
    {
        /// <summary>
        /// </summary>
        void AddOutApplication(OutApplication outapplication,List<Account> ccList);

        ///<summary>
        ///</summary>
        OutApplication GetOutApplicationByOutApplicationID(int pKID);

        ///<summary>
        ///</summary>
        List<OutApplication> GetAllOutApplicationByAccountID(int accountID);

        /// <summary>
        /// </summary>
        void UpdateOutApplication(OutApplication outapplication, List<Account> ccList);

        ///<summary>
        ///</summary>
        void DeleteOutApplicationByPKID(int pkid);

        /// <summary>
        /// 自动计算小时
        /// </summary>
        decimal CalculateOutHour(DateTime from, DateTime to, int accountID);

        /// <summary>
        /// 自动计算出差小时
        /// </summary>
        decimal CalculateOutCityHour(DateTime from, DateTime to, int accountID);

        /// <summary>
        /// 得到审核待审核的单子
        /// </summary>
        List<OutApplication> GetConfirmOutApplicationByNextOperatorID(int accountID);

        /// <summary>
        /// 审核历史
        /// </summary>
        List<OutApplication> GetConfirmHistroy(int accountID, string name, DateTime fromTime, DateTime toTime);

        /// <summary> 
        /// </summary>
        void ApproveWholeOutApplication(int OutApplicationID, int accountID, bool agree, string remark);

        /// <summary> 
        /// </summary>
        void CancelAllOutApplication(int outApplicationID, string remark);

        /// <summary> 
        /// </summary>
        void CancelOutApplicationItem(int itemID, string remark, Account account);

        /// <summary> 
        /// </summary>
        void ApproveOutApplicationItem(int itemID, int accountID, bool isAgree, string remark, int outApplicationID, bool isAdjust, decimal adjustHour);

        /// <summary> 
        /// </summary>
        List<OutApplicationFlow> GetOutApplicationFlowList(int outApplicationID);

        /// <summary>
        /// </summary>
        OutApplicationItem GetOutApplicationItemByItemID(int itemID);

        /// <summary>
        /// 
        /// </summary>
        void SetCanChangeAdjust(OutApplication outApplication);
        /// <summary>
        /// 为高级日历的数据获取
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        List<OutApplication> GetOutApplicationByAccountAndRelatedDate(int accountID, DateTime from, DateTime to);
        
    }
}