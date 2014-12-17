//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkFacade.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.OutApplications;
using SEP.HRMIS.Bll.OverWorks;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.OverWork;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// </summary>
    public class OverWorkFacade : IOverWorkFacade
    {
        /// <summary>
        /// </summary>
        public void AddOverWork(OverWork OverWork, List<Account> ccList)
        {
            new AddOverWork(OverWork, ccList).Excute();
        }

        /// <summary>
        /// </summary>
        public void UpdateOverWork(OverWork OverWork, List<Account> ccList)
        {
            new UpdateOverWork(OverWork, ccList).Excute();
        }

        /// <summary>
        /// </summary>
        public OverWork GetOverWorkByOverWorkID(int pKID)
        {
            return new GetOverWork().GetOverWorkByOverWorkID(pKID);
        }

        /// <summary>
        /// </summary>
        public List<OverWork> GetAllOverWorkByAccountID(int accountID)
        {
            return new GetOverWork().GetAllOverWorkByAccountID(accountID);
        }

        /// <summary>
        /// </summary>
        public void DeleteOverWorkByPKID(int pkid)
        {
            new DeleteOverWork(pkid).Excute();
        }

        /// <summary>
        /// </summary>
        public decimal CalculateOverWorkHour(DateTime from, DateTime to, int accountID, out OverWorkType overWorkType)
        {
            CalculateOverWorkHour calculateOverWorkHour = new CalculateOverWorkHour(from, to, accountID);
            decimal ans = calculateOverWorkHour.Excute();
            overWorkType = calculateOverWorkHour.OverWorkType;
            return ans;
        }

        /// <summary>
        /// </summary>
        public List<OverWork> GetConfirmOverWorkByNextOperatorID(int accountID)
        {
            return new GetOverWork().GetConfirmOverWorkByNextOperatorID(accountID);
        }

        /// <summary>
        /// </summary>
        public List<OverWork> GetConfirmHistroy(int accountID,string name,bool? adjust,DateTime fromTime,DateTime toTime)
        {
            return new GetOverWork().GetConfirmHistroy(accountID,name,adjust,fromTime,toTime);
        }

        /// <summary>
        /// </summary>
        public void ApproveWholeOverWork(int OverWorkID, int accountID, bool agree, string remark)
        {
            new ApproveWholeOverWork(OverWorkID, accountID, agree, remark).Excute();
        }

        /// <summary>
        /// </summary>
        public void CancelAllOverWork(int OverWorkID, string remark)
        {
            new CancelAllOverWork(OverWorkID, remark).Excute();
        }

        /// <summary>
        /// </summary>
        public void CancelOverWorkItem(int itemID, string remark, Account account)
        {
            new CancelOverWorkItem(itemID, remark, account).Excute();
        }

        /// <summary>
        /// </summary>
        public void ApproveOverWorkItem(int itemID, int accountID, bool isAgree, string remark, bool isAdjust,
                                        int OverWorkID, decimal adjustHour)
        {
            new ApproveOverWorkItem(itemID, accountID, isAgree, remark, isAdjust, OverWorkID, adjustHour).Excute();
        }

        public void ApproveOverWorkItem(int itemID, int accountID, bool isAgree, string remark, int OverWorkID)
        {
            new ApproveOverWorkItem(itemID, accountID, isAgree, remark, OverWorkID).Excute();
        }

        /// <summary>
        /// </summary>
        public List<OverWorkFlow> GetOverWorkFlowList(int OverWorkID)
        {
            return new GetOverWork().GetOverWorkFlowList(OverWorkID);
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetCanChangeAdjust(OverWork overWork)
        {
            foreach (OverWorkItem item in overWork.Item)
            {
                item.CanChangeAdjust = new OverWorkDiyProcessUtility().CanChangeAdjust(overWork.DiyProcess, item);
            }
        }

        /// <summary>
        /// </summary>
        public OverWorkItem GetOverWorkItemByItemID(int itemID)
        {
            return new GetOverWork().GetOverWorkItemByItemID(itemID);
        }
        public List<OverWork> GetOverWorkByAccountAndRelatedDate(int accountID, DateTime fromDate, DateTime toDate)
        {
            return new GetOverWork().GetOverWorkByAccountAndRelatedDate(accountID, fromDate, toDate);
        }
    }
}