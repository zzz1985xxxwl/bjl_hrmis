using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.PhoneMessage;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.SMS;
using SmsDataContract;

namespace SEP.HRMIS.Bll.LeaveRequests.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class LeaveRequestOverPhone
    {
        private readonly ILeaveRequestDal _DalLeaveRequest = new LeaveRequestDal();
        private static readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly LeaveRequest _LeaveRequest;
        private readonly ISendSMSBll _Sms = BllInstance.SendSMSBllInstance;
        private readonly LeaveRequestItem _LeaveRequestItem;
        private readonly int _NowAccount;

        /// <summary>
        /// 
        /// </summary>
        public LeaveRequestOverPhone(int leaveRequestID, LeaveRequestItem item, int nowAccountID)
        {
            _LeaveRequest = _DalLeaveRequest.GetLeaveRequestByPKID(leaveRequestID);
            _LeaveRequest.Account = _AccountBll.GetAccountById(_LeaveRequest.Account.Id);
            _LeaveRequestItem = _DalLeaveRequest.GetLeaveRequestItemByPKID(item.LeaveRequestItemID);
            _NowAccount = nowAccountID;
        }

        /// <summary>
        /// ������˽����ʼ�
        /// </summary>
        public void ConfirmOverPhone()
        {
            ConfirmMessage confirmmessage = new ConfirmMessage();
            confirmmessage.FinishPhoneMessageOperationByAssessorID(
                new PhoneMessageType(PhoneMessageEnumType.LeaveRequest,
                                     _LeaveRequestItem.LeaveRequestItemID), _NowAccount);
            if (_LeaveRequestItem.Status == RequestStatus.ApproveCancelFail ||
                _LeaveRequestItem.Status == RequestStatus.ApproveCancelPass ||
                _LeaveRequestItem.Status == RequestStatus.ApproveFail ||
                _LeaveRequestItem.Status == RequestStatus.ApprovePass)
            {
                string contant = "";
                if (_LeaveRequestItem.Status == RequestStatus.ApproveCancelFail ||
                    _LeaveRequestItem.Status == RequestStatus.ApproveFail)
                {
                    contant = "�����ٵ�����˾ܾ�";
                }
                else if (_LeaveRequestItem.Status == RequestStatus.ApprovePass ||
                         _LeaveRequestItem.Status == RequestStatus.ApproveCancelPass)
                {
                    contant = "�����ٵ������ͨ��";
                }
                _Sms.SendOneMessage(
                    new SendMessageDataModel(-1, _LeaveRequest.Account.MobileNum, contant,
                                             SmsClientProcessCenter._HrmisId));
            }
        }
    }
}