//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutSubmitPhone.cs
// Creater:  Xue.wenlong
// Date:  2009-05-25
// Resume:
// ---------------------------------------------------------------

using System.Text;
using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OutApplications.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OutSubmitPhone
    {
        private static readonly IOutApplication _OutApplicationDal = new OutApplicationDal();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly OutApplication _OutApplication;
        private readonly OutDiyProcessUtility _OutDiyProcessUtility = new OutDiyProcessUtility();

        /// <summary>
        /// </summary>
        public OutSubmitPhone(int outApplicationId)
        {
            _OutApplication = _OutApplicationDal.GetOutApplicationByOutApplicationID(outApplicationId);
            _OutApplication.Account = _AccountBll.GetAccountById(_OutApplication.Account.Id);
        }


        /// <summary>
        /// 
        /// </summary>
        public void SendPhone()
        {
            foreach (OutApplicationItem item in _OutApplication.Item)
            {
                if (item.Status == RequestStatus.Submit)
                {
                    SendSubmitToPhone(item);
                }
               
            }
        }

        private void SendSubmitToPhone(OutApplicationItem outApplicationItem)
        {
            Account phoneToAccount = GetPhoneToAccount();
            string contant = BuildBody(_OutApplication, outApplicationItem);
            ConfirmMessage confirmmessage = new ConfirmMessage();
            confirmmessage.SendNewMessage(_OutApplication.Account, phoneToAccount, contant,
                                          new PhoneMessageType(PhoneMessageEnumType.OutApplication, outApplicationItem.ItemID));
        }


        private Account GetPhoneToAccount()
        {
            Account account =
                _OutDiyProcessUtility.GetNextOperator(_OutApplication.DiyProcess, _OutApplication.Item[0],
                                                      _OutApplication.Account.Id);
            account = _AccountBll.GetAccountById(account.Id);
            return account;
        }

        /// <summary>
        /// 
        /// </summary>
        private static string BuildBody(OutApplication outApplication,OutApplicationItem outApplicationItem)
        {
            StringBuilder Content = new StringBuilder();
            Content.AppendFormat("请审批{0}提交的外出申请,从{2}到{3},共{4}小时,地点{1},理由:{5}",
                                     outApplication.Account.Name, outApplication.OutLocation, outApplicationItem.FromDate,
                                     outApplicationItem.ToDate, outApplicationItem.CostTime
                                     , outApplication.Reason);
            return Content.ToString();
        }
    }
}