//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ApproveOverWorkItem.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System;
using System.Transactions;
using SEP.HRMIS.Bll.EmployeeAdjustRest;
using SEP.HRMIS.Bll.OverWorks.MailAndPhone;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OverWorks
{
    /// <summary>
    /// 
    /// </summary>
    public class ApproveOverWorkItem : Transaction
    {
        private readonly int _ItemID;
        private readonly Account _Account;
        private readonly OverWork _OverWork;
        private readonly bool _IsAgree;
        private readonly string _Remark;
        private OverWorkItem _OverWorkItem;
        private readonly IOverWork  _OverWorkDal = new OverWorkDal();
        private readonly IAccountBll _DalAccountBll = BllInstance.AccountBllInstance;
        private readonly OverWorkDiyProcessUtility _overWorkProcess = new OverWorkDiyProcessUtility();
        private readonly bool _IsAdjust;
        private readonly decimal _AdjustHour;

        /// <summary>
        /// </summary>
        public ApproveOverWorkItem(int itemID, int accountID, bool isAgree, string remark, bool isAdjust, int OverWorkID,decimal adjustHour)
        {
            _Account = _DalAccountBll.GetAccountById(accountID);
            _OverWork = _OverWorkDal.GetOverWorkByOverWorkID(OverWorkID);
            _ItemID = itemID;
            _Remark = remark;
            _IsAgree = isAgree;
            _IsAdjust = isAdjust;
            _AdjustHour = adjustHour;
        }

        /// <summary>
        /// </summary>
        public ApproveOverWorkItem(int itemID, int accountID, bool isAgree, string remark , int OverWorkID)
        {
            _Account = _DalAccountBll.GetAccountById(accountID);
            _OverWorkItem = _OverWorkDal.GetOverWorkItemByItemID(itemID);
            _OverWork = _OverWorkDal.GetOverWorkByOverWorkID(OverWorkID);
            _ItemID = itemID;
            _Remark = remark;
            _IsAgree = isAgree;
            _IsAdjust = _OverWorkItem.Adjust;
            _AdjustHour = _OverWorkItem.AdjustHour;
        }

        /// <summary>
        /// </summary>
        public ApproveOverWorkItem(int itemID, int accountID, bool isAgree, string remark)
        {
            _Account = _DalAccountBll.GetAccountById(accountID);
            _OverWorkItem = _OverWorkDal.GetOverWorkItemByItemID(itemID);
            _OverWork = _OverWorkDal.GetOverWorkByOverWorkID(_OverWorkItem.OverWorkID);
            _ItemID = itemID;
            _Remark = remark;
            _IsAgree = isAgree;
            _IsAdjust = _OverWorkItem.Adjust;
            _AdjustHour = _OverWorkItem.AdjustHour;
        }
        /// <summary>
        /// 
        /// </summary>
        public ApproveOverWorkItem()
        {
        }

        protected override void Validation()
        {
            _OverWorkItem = _OverWorkDal.GetOverWorkItemByItemID(_ItemID);
            if (_OverWorkItem == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._OverWorkItem_Not_Exit);
            }
        }


        protected override void ExcuteSelf()
        {
            Account nextOperator = null;
            bool valide = false;
            try
            {
                valide = ApproveOneItem(_OverWorkItem, _IsAgree, _Account, _OverWork, _Remark, _OverWorkDal,
                                        _overWorkProcess, _IsAdjust, true,_AdjustHour, out nextOperator);
            }
            catch
            {
                HrmisUtility.ThrowException(HrmisUtility._DbError);
            }
            if (valide)
            {
                new OverWorkMailAndPhoneDelegate().ConfirmOperation(_OverWork.PKID, _ItemID, nextOperator, _Account);
                new OverWorkMailAndPhoneDelegate().ConfirmOperationMail(_OverWork.PKID, nextOperator, _Account);
            }
        }


        /// <summary>
        /// </summary>
        public bool ApproveOneItem(OverWorkItem item, bool isAgree, Account account,
                                          OverWork overWork, string remark,
                                          IOverWork dalOverWork, OverWorkDiyProcessUtility overWorkDiyProcessUtility,
                                          bool isAdjust, bool isChangeAdjust,decimal adjustHour,out Account nextOperator)
        {
            if(!isAdjust)
            {
                adjustHour = 0;
            }
            nextOperator = null;
            item = dalOverWork.GetOverWorkItemByItemID(item.ItemID);
            item.AdjustHour = adjustHour;
            bool valide = RequestStatus.CanApproveStatus(item.Status) &&
                          account.Id ==
                          overWorkDiyProcessUtility.GetNextOperator(overWork.DiyProcess, item, overWork.Account.Id).Id;
            if (valide)
            {
                if (!isAgree)
                {
                    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                    {
                        RequestStatus requestStatus = RequestUtility.GetStatus(item.Status, isAgree, 1);
                        dalOverWork.UpdateOverWorkItemStatusByItemID(item.ItemID, requestStatus);
                        item.Status = requestStatus;
                        if (isChangeAdjust)
                        {
                            dalOverWork.UpdateOverWorkItemAdjustByItemID(item.ItemID, isAdjust, adjustHour);
                            item.Adjust = isAdjust;
                        }
                        dalOverWork.InsertOverWorkFlow(item.ItemID,
                                                       new OverWorkFlow(0, account,
                                                                        DateTime.Now,
                                                                        remark,
                                                                        requestStatus,
                                                                        -1));

                        new UpdateAdjustRestByOverWork(item,overWork.Account.Id).Excute();
                        ts.Complete();
                    }
                    nextOperator = null;
                }
                else
                {
                    int step =
                        overWorkDiyProcessUtility.GetNextStep(item.OverWorkFlow, overWork.DiyProcess);
                    RequestStatus requestStatus = RequestUtility.GetStatus(item.Status, isAgree, step);
                    OverWorkFlow OverWorkFlow =
                        new OverWorkFlow(0, account, DateTime.Now, remark, requestStatus, step);
                    using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                    {
                        dalOverWork.InsertOverWorkFlow(item.ItemID, OverWorkFlow);
                        dalOverWork.UpdateOverWorkItemStatusByItemID(item.ItemID, requestStatus);
                        item.Status = requestStatus;
                        if (isChangeAdjust)
                        {
                            dalOverWork.UpdateOverWorkItemAdjustByItemID(item.ItemID, isAdjust,adjustHour);
                            item.Adjust = isAdjust;
                        }
                        new UpdateAdjustRestByOverWork(item,overWork.Account.Id).Excute();
                        ts.Complete();
                    }
                    nextOperator =
                        overWorkDiyProcessUtility.GetNextOperator(overWork.DiyProcess, step, overWork.Account.Id);
                }
            }
            return valide;
        }
    }
}