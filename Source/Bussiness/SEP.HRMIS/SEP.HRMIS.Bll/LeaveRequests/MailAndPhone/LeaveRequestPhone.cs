using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Bll.LeaveRequests.MailAndPhone
{
    /// <summary>
    /// 
    /// </summary>
    public class LeaveRequestPhone
    {
        private delegate void DelSendSubmitPhone(int leaveRequestID, DiyStep nextStep);

        private delegate void DelSendPhoneUseID(int leaveRequestID, LeaveRequestItem item, DiyStep nextStep);

        private delegate void DelSendPhoneUseID2(int leaveRequestID, LeaveRequestItem item, DiyStep nextStep, int accountAccountID);

        private delegate void DelSendPhoneToNextOperator(int leaveRequestID, LeaveRequestItem item, int nextOperator, int nowAccount);

        /// <summary>
        /// �����ύ����
        /// </summary>
        public void SendSubmitPhone(int leaveRequestID, DiyStep nextStep)
        {
            DelSendSubmitPhone sendPhoneDelegate = SendSubmitPhoneF;
            sendPhoneDelegate.BeginInvoke(leaveRequestID, nextStep, null, null);
        }

        private static void SendSubmitPhoneF(int leaveRequestID, DiyStep nextStep)
        {
            new LeaveRequestSubmitPhone(leaveRequestID, nextStep).SendPhone();
        }

        /// <summary>
        /// ����ȡ������
        /// </summary>
        public void SendCancelPhone(int leaveRequestID, LeaveRequestItem item, DiyStep nextStep)
        {
            DelSendPhoneUseID sendPhoneDelegate = SendCancelPhoneF;
            sendPhoneDelegate.BeginInvoke(leaveRequestID, item, nextStep, null, null);
        }

        private static void SendCancelPhoneF(int leaveRequestID, LeaveRequestItem item, DiyStep nextStep)
        {
            new LeaveRequestCancelPhone(leaveRequestID, item, nextStep).SendPhone();
        }

        /// <summary>
        /// ���Ͷ��Ÿ���һ��������
        /// </summary>
        public void SendPhoneToNextOperator(int leaveRequestID, LeaveRequestItem item, int nextOperator, int nowAccountID)
        {
            DelSendPhoneToNextOperator sendPhoneDelegate = SendPhoneToNextOperatorF;
            sendPhoneDelegate.BeginInvoke(leaveRequestID, item, nextOperator, nowAccountID, null, null);
        }

        private static void SendPhoneToNextOperatorF(int leaveRequestID, LeaveRequestItem item, int nextOperator, int nowAccount)
        {
            LeaveRequestConfirmPhone confirmphone = new LeaveRequestConfirmPhone(leaveRequestID);
            confirmphone.SendPhoneToNextOperator(nextOperator, item, nowAccount);
        }

        /// <summary>
        /// ������˽�������
        /// </summary>
        public void SendConfirmOverPhone(int leaveRequestID, LeaveRequestItem item, DiyStep nextStep,int nowAccountID)
        {
            DelSendPhoneUseID2 sendPhoneDelegate = SendConfirmOverPhoneF;
            sendPhoneDelegate.BeginInvoke(leaveRequestID, item, nextStep, nowAccountID, null, null);
        }

        private static void SendConfirmOverPhoneF(int leaveRequestID, LeaveRequestItem item, DiyStep nextStep,int nowAccountID)
        {
            new LeaveRequestOverPhone(leaveRequestID, item, nowAccountID).ConfirmOverPhone();
        }
    }
}
