//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkSubmitPhone.cs
// Creater:  Xue.wenlong
// Date:  2009-05-26
// Resume:
// ---------------------------------------------------------------

using System.Text;
using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.OverWorks.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OverWorkSubmitPhone
    {
        private static readonly IOverWork _OverWorkDal = new OverWorkDal();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly OverWork _OverWork;
        private readonly OverWorkDiyProcessUtility _OverWorkDiyProcessUtility = new OverWorkDiyProcessUtility();

        /// <summary>
        /// </summary>
        public OverWorkSubmitPhone(int overWorkId)
        {
            _OverWork = _OverWorkDal.GetOverWorkByOverWorkID(overWorkId);
            _OverWork.Account = _AccountBll.GetAccountById(_OverWork.Account.Id);
        }


        /// <summary>
        /// 
        /// </summary>
        public void SendPhone()
        {
            foreach (OverWorkItem item in _OverWork.Item)
            {
                if (item.Status == RequestStatus.Submit)
                {
                    SendSubmitToPhone(item);
                }

            }
        }

        private void SendSubmitToPhone(OverWorkItem item)
        {
            Account phoneToAccount = GetPhoneToAccount();
            string contant = BuildBody(_OverWork,item);
            ConfirmMessage confirmmessage = new ConfirmMessage();
            confirmmessage.SendNewMessage(_OverWork.Account, phoneToAccount, contant,
                                          new PhoneMessageType(PhoneMessageEnumType.OverWork, item.ItemID));
        }


        private Account GetPhoneToAccount()
        {
            Account account =
                _OverWorkDiyProcessUtility.GetNextOperator(_OverWork.DiyProcess, _OverWork.Item[0],
                                                           _OverWork.Account.Id);
            account = _AccountBll.GetAccountById(account.Id);
            return account;
        }

        /// <summary>
        /// 
        /// </summary>
        private static string BuildBody(OverWork overWork,OverWorkItem item)
        {
            StringBuilder Content = new StringBuilder();
            Content.AppendFormat("请审批{0}提交的{6}申请,从{2}到{3},共{4}小时,项目:{1},理由:{5}",
                                 overWork.Account.Name, overWork.ProjectName, item.FromDate,
                                 item.ToDate, item.CostTime
                                 , overWork.Reason, OverWorkUtility.GetOverWorkTypeName(item.OverWorkType));
            return Content.ToString();
        }
    }
}