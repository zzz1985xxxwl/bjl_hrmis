//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkConfirm.cs
// Creater:  Xue.wenlong
// Date:  2009-05-25
// Resume:
// ---------------------------------------------------------------

using System.Text;
using SEP.HRMIS.Bll.OverWorks;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.IBll.SMS;
using SmsDataContract;

namespace SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class OverWorkConfirm : BasicConfirm
    {
        /// <summary>
        /// 
        /// </summary>
        public OverWorkConfirm(PhoneMessage phoneMessage)
            : base(phoneMessage)
        {
        }

        protected override void ExcuteSelf()
        {
            ApproveOverWorkItem approveWholeOverWork =
                new ApproveOverWorkItem(PhoneMessage.PhoneMessageType.PKID, PhoneMessage.Assessor.Id, Operation, Remark);
            approveWholeOverWork.Excute();
        }

        protected override void SendManagerMessage()
        {
            OverWork overWork = new GetOverWork().GetOverWorkByOverWorkID(PhoneMessage.PhoneMessageType.PKID);
            StringBuilder answer = new StringBuilder();
            answer.AppendFormat("成功{0}了{1}的加班申请", Operation ? "通过" : "拒绝", overWork.Account.Name);
            _Sms.SendOneMessage(
                new SendMessageDataModel(-1, PhoneMessage.Assessor.MobileNum, answer.ToString(),
                                         SmsClientProcessCenter._HrmisId));
        }

    }
}