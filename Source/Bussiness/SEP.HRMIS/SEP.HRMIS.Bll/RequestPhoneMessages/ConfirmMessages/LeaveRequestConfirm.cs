//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: LeaveRequestConfirm.cs
// Creater:  Xue.wenlong
// Date:  2009-05-25
// Resume:
// ---------------------------------------------------------------

using System.Text;
using SEP.HRMIS.Bll.LeaveRequests;
using SEP.HRMIS.DalFactory;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.Model.Request;
using SEP.IBll.SMS;
using SmsDataContract;

namespace SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages
{
    /// <summary>
    /// 
    /// </summary>
    public class LeaveRequestConfirm : BasicConfirm
    {
        private readonly ILeaveRequestDal _DalLeaveRequest = DalFactory.DataAccess.CreateLeaveRequest();
        /// <summary>
        /// 
        /// </summary>
        public LeaveRequestConfirm(PhoneMessage phoneMessage)
            : base(phoneMessage)
        {
        }

        protected override void ExcuteSelf()
        {
            RequestStatus status;
            LeaveRequestItem item = _DalLeaveRequest.GetLeaveRequestItemByPKID(PhoneMessage.PhoneMessageType.PKID);
            RequestStatus s = item.Status;
            if (Operation)
            {
                switch (s.Id)
                {
                    case 1:
                    case 7:
                        status = RequestStatus.ApprovePass;
                        break;
                    case 4:
                    case 8:
                        status = RequestStatus.ApproveCancelPass;
                        break;
                    default:
                        status = RequestStatus.ApprovePass;
                        break;
                }
                //status = RequestStatus.ApprovePass;
            }
            else
            {
                switch (s.Id)
                {
                    case 1:
                    case 7:
                        status = RequestStatus.ApproveFail;
                        break;
                    case 4:
                    case 8:
                        status = RequestStatus.ApproveCancelFail;
                        break;
                    default:
                        status = RequestStatus.ApproveFail;
                        break;
                }
                //status = RequestStatus.ApproveFail;
            }
            int leaverequestID = item.LeaveRequestID;
            ApproveLeaveRequestItem approveWholeLeaveRequest = new ApproveLeaveRequestItem(leaverequestID, PhoneMessage.PhoneMessageType.PKID, _PhoneMessage.Assessor.Id, status, Remark);
            approveWholeLeaveRequest.Excute();

        }

        protected override void SendManagerMessage()
        {
            LeaveRequest leaveRequest = new GetLeaveRequest().GetLeaveRequestByPKID(PhoneMessage.PhoneMessageType.PKID);
            StringBuilder answer = new StringBuilder();
            answer.AppendFormat("成功{0}了{1}的请假申请", Operation ? "通过" : "拒绝", leaveRequest.Account.Name);
            _Sms.SendOneMessage(
                new SendMessageDataModel(-1, PhoneMessage.Assessor.MobileNum, answer.ToString(),
                                         SmsClientProcessCenter._HrmisId));
        }

        //protected override void SendApplicantMessage()
        //{
        //    LeaveRequest leaveRequest = new GetLeaveRequest().GetLeaveRequestByPKID(PhoneMessage.PhoneMessageType.PKID);
        //    StringBuilder answer = new StringBuilder();
        //    answer.AppendFormat("{0}{1}了你的请假申请", _PhoneMessageOperation.Assessor.Name, Operation ? "通过" : "拒绝");
        //    _Sms.SendOneMessage(
        //        new SendMessageDataModel(-1, leaveRequest.Account.MobileNum, answer.ToString(),
        //                                 SmsClientProcessCenter._HrmisId));
        //}
    }
}