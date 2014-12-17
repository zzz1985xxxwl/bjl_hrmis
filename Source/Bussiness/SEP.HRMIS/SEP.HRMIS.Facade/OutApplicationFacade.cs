//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutApplicationFacade.cs
// Creater:  Xue.wenlong
// Date:  2009-04-13
// Resume:
// ---------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.OutApplications;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.OutApplication;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    /// <summary> 
    /// </summary>
    public class OutApplicationFacade : IOutApplicationFacade
    {
        /// <summary>
        /// </summary>
        public void AddOutApplication(OutApplication outapplication,List<Account> ccList)
        {
            new AddOutApplication(outapplication,ccList).Excute();
        }
        /// <summary>
        /// </summary>
        public OutApplication GetOutApplicationByOutApplicationID(int pKID)
        {
            return new GetOutApplication().GetOutApplicationByOutApplicationID(pKID);
        }
        /// <summary>
        /// </summary>
        public List<OutApplication> GetAllOutApplicationByAccountID(int accountID)
        {
            return new GetOutApplication().GetAllOutApplicationByAccountID(accountID);
        }
        /// <summary>
        /// </summary>
        public void UpdateOutApplication(OutApplication outapplication,List<Account> ccList)
        {
            new UpdateOutApplication(outapplication,ccList).Excute();
        }
        /// <summary>
        /// </summary>
        public void DeleteOutApplicationByPKID(int pkid)
        {
            new DeleteOutApplication(pkid).Excute();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ApproveWholeOutApplication(int OutApplicationID, int accountID, bool agree,
                                               string remark)
        {
            new ApproveWholeOutApplication(OutApplicationID, accountID, agree, remark).Excute();
        }

        /// <summary> 
        /// </summary>
        public void CancelAllOutApplication(int outApplicationID, string remark)
        {
            new CancelAllOutApplication(outApplicationID, remark).Excute();
        }

        /// <summary> 
        /// </summary>
        public void CancelOutApplicationItem(int itemID, string remark, Account account)
        {
            new CancelOutApplicationItem(itemID, remark, account).Excute();
        }

        
        /// <summary>
        /// </summary>
        public decimal CalculateOutHour(DateTime from, DateTime to, int accountID)
        {
            return new CalculateOutHour(from, to, accountID).Excute();
        }

        /// <summary>
        /// </summary>
        public decimal CalculateOutCityHour(DateTime from, DateTime to,int accountid)
        {
            return new CalculateOutCityHour(from, to,accountid).Excute();
        }

        /// <summary>
        /// </summary>
        public List<OutApplication> GetConfirmOutApplicationByNextOperatorID(int accountID)
        {
            return new GetOutApplication().GetConfirmOutApplicationByNextOperatorID(accountID);
        }
        
        /// <summary>
        /// </summary>
        public List<OutApplication> GetConfirmHistroy(int accountID, string name, DateTime fromTime, DateTime toTime)
        {
            return new GetOutApplication().GetConfirmHistroy(accountID, name, fromTime, toTime);
        }

        /// <summary>
        /// </summary>
        public void ApproveOutApplicationItem(int itemID, int accountID, bool isAgree,
                                        string remark, int outApplicationID,bool isAdjust,decimal adjustHour)
        {
            new ApproveOutApplicationItem(itemID, accountID, isAgree, remark, outApplicationID,isAdjust,adjustHour).Excute();
        }

        public List<OutApplicationFlow> GetOutApplicationFlowList(int outApplicationID)
        {
            return new GetOutApplication().GetOutApplicationFlowList(outApplicationID);
        }

        /// <summary>
        /// </summary>
        public OutApplicationItem GetOutApplicationItemByItemID(int itemID)
        {
            return new GetOutApplication().GetOutApplicationItemByItemID(itemID); 
        }

        public void SetCanChangeAdjust(OutApplication outApplication)
        {
            foreach (OutApplicationItem item in outApplication.Item)
            {
                item.CanChangeAdjust = new OutApplicationUtility().CanChangeAdjust(outApplication.DiyProcess, item);
            }
        }
        public List<OutApplication> GetOutApplicationByAccountAndRelatedDate(int accountID, DateTime fromDate,
                                                                 DateTime toDate)
        {
            return new GetOutApplication().GetOutApplicationByAccountAndRelatedDate(accountID, fromDate, toDate);
        }
    }
}