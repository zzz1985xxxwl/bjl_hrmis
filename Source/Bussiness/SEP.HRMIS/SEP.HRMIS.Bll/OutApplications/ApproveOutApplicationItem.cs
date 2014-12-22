//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ApproveOutApplicationItem.cs
// Creater:  Xue.wenlong
// Date:  2009-05-07
// Resume:
// ---------------------------------------------------------------

using System;
using System.Transactions;
using SEP.HRMIS.Bll.EmployeeAdjustRest;
using SEP.HRMIS.Bll.OutApplications.MailAndPhone;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OutApplications
{
    /// <summary>
    /// 
    /// </summary>
    public class ApproveOutApplicationItem : Transaction
    {
        private readonly int _ItemID;
        private readonly Account _Account;
        private readonly OutApplication _OutApplication;
        private readonly bool _IsAgree;
        private readonly string _Remark;
        private readonly IOutApplication _DalOutApplication = new OutApplicationDal();
        private readonly IAccountBll _DalAccountBll = BllInstance.AccountBllInstance;
        private readonly OutDiyProcessUtility _OutDiyProcess = new OutDiyProcessUtility();
        private OutApplicationItem _OutApplicationItem;
        private readonly bool _IsAdjust;
        private decimal _AdjustHour;

        /// <summary>
        /// </summary>
        public ApproveOutApplicationItem(int itemID, int accountID, bool isAgree,
                                         string remark, int outApplicationID, bool isAdjust, decimal adjustHour)
        {
            _Account = _DalAccountBll.GetAccountById(accountID);
            _OutApplication = _DalOutApplication.GetOutApplicationByOutApplicationID(outApplicationID);
            _ItemID = itemID;
            _Remark = remark;
            _IsAgree = isAgree;
            _IsAdjust = isAdjust;
            _AdjustHour = adjustHour;
        }

        /// <summary>
        /// </summary>
        public ApproveOutApplicationItem(int itemID, int accountID, bool isAgree,
                                         string remark)
        {
            _Account = _DalAccountBll.GetAccountById(accountID);
            _OutApplicationItem = _DalOutApplication.GetOutApplicationItemByItemID(itemID);
            _OutApplication =
                _DalOutApplication.GetOutApplicationByOutApplicationID(_OutApplicationItem.OutApplicationID);
            _ItemID = itemID;
            _Remark = remark;
            _IsAgree = isAgree;
            _IsAdjust = _OutApplicationItem.Adjust;
            _AdjustHour = _OutApplicationItem.AdjustHour;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void Validation()
        {
            _OutApplicationItem = _DalOutApplication.GetOutApplicationItemByItemID(_ItemID);
            if (_OutApplicationItem == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._OutApplicationItem_Not_Exit);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool ApproveOneItem(OutApplicationItem item, bool isAgree, Account account,
                                          OutApplication outApplication, string remark,
                                          IOutApplication dalOutApplication, OutDiyProcessUtility outDiyProcess,
                                          bool isAdjust, bool isChangeAdjust, decimal adjustHour,
                                          out Account nextOperator)
        {
            if (!isAdjust)
            {
                adjustHour = 0;
            }
            nextOperator = null;
            item = dalOutApplication.GetOutApplicationItemByItemID(item.ItemID);
            item.AdjustHour = adjustHour;
            bool ans = RequestStatus.CanApproveStatus(item.Status) &&
                       account.Id ==
                       outDiyProcess.GetNextOperator(outApplication.DiyProcess, item, outApplication.Account.Id).Id;
            if (ans)
            {
                if (!isAgree)
                {
                    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                    {
                        RequestStatus requestStatus = RequestUtility.GetStatus(item.Status, isAgree, 1);
                        dalOutApplication.UpdateOutApplicationItemStatusByItemID(item.ItemID,
                                                                                 requestStatus);
                        dalOutApplication.InsertOutApplicationFlow(item.ItemID,
                                                                   new OutApplicationFlow(0, account,
                                                                                          DateTime.Now,
                                                                                          remark,
                                                                                          requestStatus,
                                                                                          -1));
                        nextOperator = null;
                        item.Status = requestStatus;
                        if (outApplication.OutType.ID == OutType.OutCity.ID)
                        {
                            if (isChangeAdjust)
                            {
                                dalOutApplication.UpdateOutApplicationItemAdjustByItemID(item.ItemID, isAdjust, adjustHour);
                                item.Adjust = isAdjust;
                            }
                            new UpdateAdjustRestByOut(item, outApplication.Account.Id).Excute();
                        }
                        ts.Complete();
                    }
                }
                else
                {
                    //现在做到第几步，就是上一步加1
                    int step =
                        outDiyProcess.GetNextStep(item.OutApplicationFlow, outApplication.DiyProcess);
                    RequestStatus requestStatus = RequestUtility.GetStatus(item.Status, isAgree, step);
                    OutApplicationFlow OutApplicationFlow =
                        new OutApplicationFlow(0, account, DateTime.Now, remark, requestStatus, step);
                    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                    {
                        dalOutApplication.InsertOutApplicationFlow(item.ItemID, OutApplicationFlow);
                        dalOutApplication.UpdateOutApplicationItemStatusByItemID(item.ItemID, requestStatus);
                        item.Status = requestStatus;
                        if (outApplication.OutType.ID == OutType.OutCity.ID)
                        {
                            if (isChangeAdjust)
                            {
                                dalOutApplication.UpdateOutApplicationItemAdjustByItemID(item.ItemID, isAdjust, adjustHour);
                                item.Adjust = isAdjust;
                            }
                            new UpdateAdjustRestByOut(item, outApplication.Account.Id).Excute();
                        }
                        ts.Complete();
                    }
                    nextOperator =
                        outDiyProcess.GetNextOperator(outApplication.DiyProcess, step, outApplication.Account.Id);
                }
            }
            return ans;
        }

        /// <summary>
        /// </summary>
        protected override void ExcuteSelf()
        {
            Account nextOperator = null;
            bool ans = false;
            try
            {
                ans =
                    ApproveOneItem(_OutApplicationItem, _IsAgree, _Account, _OutApplication, _Remark, _DalOutApplication,
                                   _OutDiyProcess, _IsAdjust, true, _AdjustHour, out nextOperator);
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
            if (ans)
            {
                new OutMailAndPhoneDelegate().ConfirmOperation(_OutApplication.PKID, _ItemID, nextOperator, _Account);
                new OutMailAndPhoneDelegate().ConfirmOperationMail(_OutApplication.PKID, nextOperator, _Account);
            }
        }
    }
}