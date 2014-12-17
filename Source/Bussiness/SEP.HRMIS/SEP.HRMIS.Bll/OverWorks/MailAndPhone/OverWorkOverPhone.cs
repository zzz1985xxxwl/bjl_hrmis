//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkOverPhone.cs
// Creater:  Xue.wenlong
// Date:  2009-05-26
// Resume:
// ---------------------------------------------------------------
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.SMS;
using SmsDataContract;

namespace SEP.HRMIS.Bll.OverWorks.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OverWorkOverPhone
    {
        private static readonly IOverWork _OverWorkDal = DalFactory.DataAccess.CreateOverWork();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly OverWork _OverWork;
        private readonly OverWorkItem _OverWorkItem;
        private readonly ISendSMSBll _Sms = BllInstance.SendSMSBllInstance;

        /// <summary>
        /// 
        /// </summary>
        public OverWorkOverPhone(int overWorkId,int itemID)
        {
            _OverWork = _OverWorkDal.GetOverWorkByOverWorkID(overWorkId);
            _OverWorkItem = _OverWorkDal.GetOverWorkItemByItemID(itemID);
            _OverWork.Account = _AccountBll.GetAccountById(_OverWork.Account.Id);
        }

        /// <summary>
        /// 发送审核结束邮件
        /// </summary>
        public void ConfirmOverPhone()
        {
            if (_OverWorkItem.Status == RequestStatus.ApproveCancelFail ||
            _OverWorkItem.Status == RequestStatus.ApproveCancelPass ||
            _OverWorkItem.Status == RequestStatus.ApproveFail ||
            _OverWorkItem.Status == RequestStatus.ApprovePass)
            {
                string contant = "";
                if (_OverWorkItem.Status == RequestStatus.ApproveCancelFail || _OverWorkItem.Status == RequestStatus.ApproveFail)
                {
                    contant = "你的加班单已审核拒绝";
                }
                else if (_OverWorkItem.Status == RequestStatus.ApprovePass || _OverWorkItem.Status == RequestStatus.ApproveCancelPass)
                {
                    contant = "你的加班单已审核通过";
                }
                _Sms.SendOneMessage(
                    new SendMessageDataModel(-1, _OverWork.Account.MobileNum, contant,
                                             SmsClientProcessCenter._HrmisId));
            }
        }
    }
}