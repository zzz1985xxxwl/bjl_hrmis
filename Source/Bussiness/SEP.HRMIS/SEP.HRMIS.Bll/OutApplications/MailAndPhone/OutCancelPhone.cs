//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutCancelPhone.cs
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
    public class OutCancelPhone
    {
        private static readonly IOutApplication _OutApplicationDal = new OutApplicationDal();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly OutApplication _OutApplication;
        private readonly OutApplicationItem _OutApplicationItem;
        private readonly OutDiyProcessUtility _OutDiyProcessUtility = new OutDiyProcessUtility();

        /// <summary>
        /// </summary>
        public OutCancelPhone(int outApplicationId,int itemID)
        {
            _OutApplication = _OutApplicationDal.GetOutApplicationByOutApplicationID(outApplicationId);
            _OutApplicationItem = _OutApplicationDal.GetOutApplicationItemByItemID(itemID);
            _OutApplication.Account = _AccountBll.GetAccountById(_OutApplication.Account.Id);
        }


        /// <summary>
        /// 
        /// </summary>
        public void SendPhone()
        {
            SendSubmitToPhone();
        }

        private void SendSubmitToPhone()
        {
            Account phoneToAccount = GetPhoneToAccount();
            string contant = string.Format("请审批{0}取消的外出申请,从{2}到{3},共{4}小时,地点{1},理由:{5}",
                                           _OutApplication.Account.Name, _OutApplication.OutLocation,
                                           _OutApplicationItem.FromDate,
                                           _OutApplicationItem.ToDate, _OutApplicationItem.CostTime
                                           , _OutApplication.Reason);
            ConfirmMessage confirmmessage = new ConfirmMessage();
            confirmmessage.SendCancelMessage(phoneToAccount, contant,
                                             new PhoneMessageType(PhoneMessageEnumType.OutApplication,
                                                                  _OutApplicationItem.ItemID));
        }

        private Account GetPhoneToAccount()
        {
            Account account =
                _OutDiyProcessUtility.GetNextOperator(_OutApplication.DiyProcess, 1, _OutApplication.Account.Id);
            account = _AccountBll.GetAccountById(account.Id);
            return account;
        }
    }
}