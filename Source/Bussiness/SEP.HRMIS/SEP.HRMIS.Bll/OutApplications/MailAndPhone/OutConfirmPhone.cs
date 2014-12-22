//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutConfirmPhone.cs
// Creater:  Xue.wenlong
// Date:  2009-05-25
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OutApplications.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OutConfirmPhone
    {
        private static readonly IOutApplication _OutApplicationDal = new OutApplicationDal();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly OutApplication _OutApplication;
        private readonly OutApplicationItem _OutApplicationItem;
        /// <summary>
        /// 
        /// </summary>
        public OutConfirmPhone(int outApplicationId,int itemid)
        {
            _OutApplication = _OutApplicationDal.GetOutApplicationByOutApplicationID(outApplicationId);
            _OutApplicationItem=_OutApplicationDal.GetOutApplicationItemByItemID(itemid);
            _OutApplication.Account = _AccountBll.GetAccountById(_OutApplication.Account.Id);
        }


        /// <summary>
        ///
        /// </summary>
        public void SendPhoneToNextOperator(Account nextOperator,Account nowAccount)
        {
            ConfirmMessage confirmmessage = new ConfirmMessage();
            confirmmessage.FinishPhoneMessageOperationByAssessorID(
                new PhoneMessageType(PhoneMessageEnumType.OutApplication,
                                     _OutApplicationItem.ItemID), nowAccount.Id);
            if(nextOperator!=null)
            {
                Account phoneToAccount = _AccountBll.GetAccountById(nextOperator.Id);
                confirmmessage.SendConfirmMessage(phoneToAccount,
                                                      new PhoneMessageType(PhoneMessageEnumType.OutApplication,
                                                                           _OutApplicationItem.ItemID));
            }
        }

    }
}