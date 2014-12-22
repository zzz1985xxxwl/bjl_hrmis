//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: IOverWorkFacade.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.OverWork;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// </summary>
    public interface IOverWorkFacade
    {
        /// <summary>
        /// </summary>
        void AddOverWork(OverWork OverWork, List<Account> ccList);

        ///<summary>
        ///</summary>
        OverWork GetOverWorkByOverWorkID(int pKID);

        ///<summary>
        ///</summary>
        List<OverWork> GetAllOverWorkByAccountID(int accountID);

        /// <summary>
        /// </summary>
        void UpdateOverWork(OverWork OverWork, List<Account> ccList);

        ///<summary>
        ///</summary>
        void DeleteOverWorkByPKID(int pkid);

        /// <summary>
        /// 自动计算小时
        /// </summary>
        decimal CalculateOverWorkHour(DateTime from, DateTime to, int accountID,out OverWorkType overWorkType);

        /// <summary>
        /// 得到审核待审核的单子
        /// </summary>
        List<OverWork> GetConfirmOverWorkByNextOperatorID(int accountID);

        /// <summary>
        /// 审核历史
        /// </summary>
        List<OverWork> GetConfirmHistroy(int accountID,string name,bool? adjust,DateTime fromTime,DateTime toTime);

        /// <summary> 
        /// </summary>
        void ApproveWholeOverWork(int OverWorkID, int accountID, bool agree, string remark);

        /// <summary> 
        /// </summary>
        void CancelAllOverWork(int OverWorkID, string remark);

        /// <summary> 
        /// </summary>
        void CancelOverWorkItem(int itemID, string remark, Account account);

        /// <summary> 
        /// </summary>
        void ApproveOverWorkItem(int itemID, int accountID, bool isAgree, string remark, bool isAdjust,
                                 int OverWorkID, decimal adjustHour);

        /// <summary> 
        /// </summary>
        void ApproveOverWorkItem(int itemID, int accountID, bool isAgree, string remark, int OverWorkID);

        /// <summary> 
        /// </summary>
        List<OverWorkFlow> GetOverWorkFlowList(int OverWorkID);

        /// <summary> 
        /// </summary>
        void SetCanChangeAdjust(OverWork overWork);

        /// <summary> 
        /// </summary>
        OverWorkItem GetOverWorkItemByItemID(int itemID);
        /// <summary>
        /// 为高级日历的数据获取
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        List<OverWork> GetOverWorkByAccountAndRelatedDate(int accountID, DateTime from, DateTime to);
    }
}