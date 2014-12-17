//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: CancelOutApplicationItem.cs
// Creater:  Xue.wenlong
// Date:  2009-05-06
// Resume:
// ---------------------------------------------------------------

using System;
using System.Transactions;
using SEP.HRMIS.Bll.OutApplications.MailAndPhone;
using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OutApplications
{
    /// <summary>
    /// 
    /// </summary>
    public class CancelOutApplicationItem : Transaction
    {
        private readonly int _ItemID;
        private readonly string _Remark;
        private readonly Account _Account;
        private OutApplicationItem _OutApplicationItem;
        private OutApplication _OutApplication;
        private readonly IOutApplication _DalOutApplication = DalFactory.DataAccess.CreateOutApplication();
        private readonly OutDiyProcessUtility _OutDiyProcessUtility = new OutDiyProcessUtility();

        /// <summary>
        /// 
        /// </summary>
        public CancelOutApplicationItem(int itemID, string remark, Account account)
        {
            _ItemID = itemID;
            _Remark = remark;
            _Account = account;
        }

        protected override void Validation()
        {
            _OutApplicationItem = _DalOutApplication.GetOutApplicationItemByItemID(_ItemID);
            _OutApplication =
                _DalOutApplication.GetOutApplicationByOutApplicationID(_OutApplicationItem.OutApplicationID);
            if (_OutApplicationItem == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._OutApplicationItem_Not_Exit);
            }
        }

        protected override void ExcuteSelf()
        {
            bool valide =
                CancelOneItem(_OutApplicationItem, _Account, _Remark, _DalOutApplication, _OutDiyProcessUtility,
                              _OutApplication);
            if (valide)
            {
                new OutMailAndPhoneDelegate().CancelOperation(_OutApplicationItem.OutApplicationID,
                                                              _OutApplicationItem.ItemID);
                new OutMailAndPhoneDelegate().CancelOperationMail(_OutApplicationItem.OutApplicationID);
            }
        }

        /// <summary>
        /// </summary>
        public static bool CancelOneItem(OutApplicationItem item, Account account, string remark,
                                         IOutApplication dalOutApplication, OutDiyProcessUtility outDiyProcessUtility,
                                         OutApplication outApplication)
        {
            item = dalOutApplication.GetOutApplicationItemByItemID(item.ItemID);
            bool valide = RequestStatus.CanCancelStatus(item.Status);
            if (valide)
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    RequestStatus status = RequestStatus.Cancelled;
                    if (outApplication.OutType.ID == OutType.InCity.ID || outApplication.OutType.ID == OutType.Train.ID)
                    {
                        status = RequestStatus.ApproveCancelPass;
                        ConfirmMessage confirmmessage = new ConfirmMessage();
                        confirmmessage.FinishPhoneMessageOperation(
                            new PhoneMessageType(PhoneMessageEnumType.OutApplication,
                                                 item.ItemID));
                        valide = false;
                    }
                    dalOutApplication.UpdateOutApplicationItemStatusByItemID(item.ItemID,
                                                                             status);
                    OutApplicationFlow OutApplicationFlow =
                        new OutApplicationFlow(0, account, DateTime.Now, remark,
                                               RequestStatus.Cancelled, 1);
                    dalOutApplication.InsertOutApplicationFlow(item.ItemID, OutApplicationFlow);
                    ts.Complete();
                }
            }
            return valide;
        }
    }
}