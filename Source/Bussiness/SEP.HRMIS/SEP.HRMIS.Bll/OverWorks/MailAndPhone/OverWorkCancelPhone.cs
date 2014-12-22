//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkCancelPhone.cs
// Creater:  Xue.wenlong
// Date:  2009-05-26
// Resume:
// ---------------------------------------------------------------

using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OverWorks.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OverWorkCancelPhone
    {
        private static readonly IOverWork _OverWorkDal = new OverWorkDal();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly OverWork _OverWork;
        private readonly OverWorkItem _OverWorkItem;
        private readonly OverWorkDiyProcessUtility _OverWorkDiyProcessUtility = new OverWorkDiyProcessUtility();

        /// <summary>
        /// </summary>
        public OverWorkCancelPhone(int overWorkId,int itemID)
        {
            _OverWork = _OverWorkDal.GetOverWorkByOverWorkID(overWorkId);
            _OverWorkItem = _OverWorkDal.GetOverWorkItemByItemID(itemID);
            _OverWork.Account = _AccountBll.GetAccountById(_OverWork.Account.Id);
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
            string contant = string.Format("请审批{0}取消的{6}申请,从{2}到{3},共{4}小时,项目:{1},理由:{5}",
                                           _OverWork.Account.Name, _OverWork.ProjectName,
                                           _OverWorkItem.FromDate,
                                           _OverWorkItem.ToDate, _OverWorkItem.CostTime
                                           , _OverWork.Reason, OverWorkUtility.GetOverWorkTypeName(_OverWorkItem.OverWorkType));
            ConfirmMessage confirmmessage = new ConfirmMessage();
            confirmmessage.SendCancelMessage(phoneToAccount, contant,
                                             new PhoneMessageType(PhoneMessageEnumType.OverWork,
                                                                  _OverWorkItem.ItemID));
        }

        private Account GetPhoneToAccount()
        {
            Account account =
                _OverWorkDiyProcessUtility.GetNextOperator(_OverWork.DiyProcess, 1, _OverWork.Account.Id);
            account = _AccountBll.GetAccountById(account.Id);
            return account;
        }
    }
}