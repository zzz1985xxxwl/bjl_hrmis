//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutOverPhone.cs
// Creater:  Xue.wenlong
// Date:  2009-05-25
// Resume:
// ---------------------------------------------------------------
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.SMS;
using SmsDataContract;

namespace SEP.HRMIS.Bll.OutApplications.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class OutOverPhone
    {
        private static readonly IOutApplication _OutApplicationDal = DalFactory.DataAccess.CreateOutApplication();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly OutApplication _OutApplication;
        private readonly OutApplicationItem _OutApplicationItem;
        private readonly ISendSMSBll _Sms = BllInstance.SendSMSBllInstance;

        /// <summary>
        /// 
        /// </summary>
        public OutOverPhone(int outApplicationId,int itemID)
        {
            _OutApplication = _OutApplicationDal.GetOutApplicationByOutApplicationID(outApplicationId);
            _OutApplicationItem = _OutApplicationDal.GetOutApplicationItemByItemID(itemID);
            _OutApplication.Account = _AccountBll.GetAccountById(_OutApplication.Account.Id);
        }

        /// <summary>
        /// 发送审核结束邮件
        /// </summary>
        public void ConfirmOverPhone()
        {
            if (_OutApplicationItem.Status == RequestStatus.ApproveCancelFail ||
              _OutApplicationItem.Status == RequestStatus.ApproveCancelPass ||
              _OutApplicationItem.Status == RequestStatus.ApproveFail ||
              _OutApplicationItem.Status == RequestStatus.ApprovePass)
            {
                string contant="";
                if (_OutApplicationItem.Status == RequestStatus.ApproveCancelFail || _OutApplicationItem.Status == RequestStatus.ApproveFail)
                {
                    contant = "你的外出单已审核拒绝";
                }
                else if (_OutApplicationItem.Status == RequestStatus.ApprovePass || _OutApplicationItem.Status == RequestStatus.ApproveCancelPass)
                {
                    contant = "你的外出单已审核通过";
                }
                _Sms.SendOneMessage(
                    new SendMessageDataModel(-1, _OutApplication.Account.MobileNum, contant,
                                             SmsClientProcessCenter._HrmisId));
            }
        }
    }
}