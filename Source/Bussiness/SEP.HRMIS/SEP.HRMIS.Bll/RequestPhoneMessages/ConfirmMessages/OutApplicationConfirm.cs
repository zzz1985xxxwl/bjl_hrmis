//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutApplicationConfirm.cs
// Creater:  Xue.wenlong
// Date:  2009-05-25
// Resume:
// ---------------------------------------------------------------

using System.Text;
using SEP.HRMIS.Bll.OutApplications;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.IBll.SMS;
using SmsDataContract;

namespace SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class OutApplicationConfirm : BasicConfirm
    {
       
        /// <summary>
        /// 
        /// </summary>
        public OutApplicationConfirm(PhoneMessage phoneMessage)
            : base(phoneMessage)
        {
        }

        protected override void ExcuteSelf()
        {
            ApproveOutApplicationItem approveOutApplicationItem =
                new ApproveOutApplicationItem(_PhoneMessage.PhoneMessageType.PKID,_PhoneMessage.Assessor.Id, Operation, Remark);
            approveOutApplicationItem.Excute();
        }

        protected override void SendManagerMessage()
        {
            OutApplication outApplication = new GetOutApplication().GetOutApplicationByOutApplicationID(PhoneMessage.PhoneMessageType.PKID);
            StringBuilder answer = new StringBuilder();
            answer.AppendFormat("成功{0}了{1}的外出申请", Operation ? "通过" : "拒绝", outApplication.Account.Name);
            _Sms.SendOneMessage(
                new SendMessageDataModel(-1, _PhoneMessage.Assessor.MobileNum, answer.ToString(),
                                         SmsClientProcessCenter._HrmisId));
        }
    }
}