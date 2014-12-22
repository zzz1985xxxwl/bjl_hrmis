//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CancelOverWorkItem.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System;
using System.Transactions;
using SEP.HRMIS.Bll.OverWorks.MailAndPhone;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OverWorks
{
    /// <summary>
    /// </summary>
    public class CancelOverWorkItem : Transaction
    {
        private readonly IOverWork  _OverWorkDal = new OverWorkDal();
        private readonly OverWorkDiyProcessUtility _OverWorkDiyProcessUtility = new OverWorkDiyProcessUtility();
        private readonly int _ItemID;
        private readonly string _Remark;
        private readonly Account _Account;
        private OverWorkItem _OverWorkItem;


        /// <summary>
        /// </summary>
        public CancelOverWorkItem(int itemID, string remark, Account account)
        {
            _ItemID = itemID;
            _Remark = remark;
            _Account = account;
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
            bool valide = CancelOneItem(_OverWorkItem, _Account, _Remark, _OverWorkDal, _OverWorkDiyProcessUtility);
            if(valide)
            {
                new OverWorkMailAndPhoneDelegate().CancelOperation(_OverWorkItem.OverWorkID,
                                                            _OverWorkItem.ItemID);
                new OverWorkMailAndPhoneDelegate().CancelOperationMail(_OverWorkItem.OverWorkID);
            }
        }

        /// <summary>
        /// </summary>
        public static bool CancelOneItem(OverWorkItem item, Account account, string remark,
                                         IOverWork dalOverWork, OverWorkDiyProcessUtility OverWorkDiyProcessUtility)
        {
            item = dalOverWork.GetOverWorkItemByItemID(item.ItemID);
            bool valide = RequestStatus.CanCancelStatus(item.Status);
            if (valide)
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    dalOverWork.UpdateOverWorkItemStatusByItemID(item.ItemID, RequestStatus.Cancelled);
                    OverWorkFlow OverWorkFlow =
                        new OverWorkFlow(0, account, DateTime.Now, remark,
                                         RequestStatus.Cancelled, 1);
                    dalOverWork.InsertOverWorkFlow(item.ItemID, OverWorkFlow);
                    ts.Complete();
                }
            }
            return valide;
        }
    }
}