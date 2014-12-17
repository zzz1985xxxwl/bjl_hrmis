//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkConfirmPhone.cs
// Creater:  Xue.wenlong
// Date:  2009-05-26
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OverWorks.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OverWorkConfirmPhone
    {
        private static readonly IOverWork _OverWorkDal = DalFactory.DataAccess.CreateOverWork();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly OverWork _OverWork;
        private readonly OverWorkItem _OverWorkItem;

        /// <summary>
        /// 
        /// </summary>
        public OverWorkConfirmPhone(int overWorkId,int itemID)
        {
            _OverWork = _OverWorkDal.GetOverWorkByOverWorkID(overWorkId);
            _OverWorkItem = _OverWorkDal.GetOverWorkItemByItemID(itemID);
            _OverWork.Account = _AccountBll.GetAccountById(_OverWork.Account.Id);
        }


        /// <summary>
        /// 给下一步操作人发邮件
        /// </summary>
        public void SendPhoneToNextOperator(Account nextOperator, Account nowAccount)
        {
            ConfirmMessage confirmmessage = new ConfirmMessage();
            confirmmessage.FinishPhoneMessageOperationByAssessorID(
                new PhoneMessageType(PhoneMessageEnumType.OverWork,
                                     _OverWorkItem.ItemID), nowAccount.Id);
           if(nextOperator!=null)
           {
               Account phoneToAccount = _AccountBll.GetAccountById(nextOperator.Id);
               confirmmessage.SendConfirmMessage(phoneToAccount, new PhoneMessageType(PhoneMessageEnumType.OverWork,
                                                                                       _OverWorkItem.ItemID));
           }
        }
    }
}