

namespace SEP.HRMIS.Bll.TraineeApplications.MailAndPhone
{
    ///<summary>
    ///</summary>
    public class TraineeApplicationPhone
    {
        private delegate void DelSendSubmitPhone(int traineeApplicationID);

        private delegate void DelSendPhoneUseID2(int traineeApplicationID, int accountAccountID);

        private delegate void DelSendPhoneToNextOperator(int traineeApplicationID, int nowAccount);

        /// <summary>
        /// �����ύ����
        /// </summary>
        public void SendSubmitPhone(int traineeApplicationID)
        {
            DelSendSubmitPhone sendPhoneDelegate = SendSubmitPhoneF;
            sendPhoneDelegate.BeginInvoke(traineeApplicationID,  null, null);
        }

        private static void SendSubmitPhoneF(int traineeApplicationID)
        {
            new TraineeApplicationPhoneSubmit(traineeApplicationID).SendPhone();
        }
 
        /// <summary>
        /// ���Ͷ��Ÿ���һ��������
        /// </summary>
        public void SendPhoneToNextOperator(int traineeApplicationID,  int nowAccountID)
        {
            DelSendPhoneToNextOperator sendPhoneDelegate = SendPhoneToNextOperatorF;
            sendPhoneDelegate.BeginInvoke(traineeApplicationID, nowAccountID, null, null);
        }

        private static void SendPhoneToNextOperatorF(int traineeApplicationID, int nowAccount)
        {
            TraineeApplicationPhoneConfirm confirmphone = new TraineeApplicationPhoneConfirm(traineeApplicationID);
            confirmphone.SendPhoneToNextOperator(traineeApplicationID, nowAccount);
        }

        /// <summary>
        /// ������˽�������
        /// </summary>
        public void SendConfirmOverPhone(int traineeApplicationID,  int nowAccountID)
        {
            DelSendPhoneUseID2 sendPhoneDelegate = SendConfirmOverPhoneF;
            sendPhoneDelegate.BeginInvoke(traineeApplicationID, nowAccountID, null, null);
        }

        private static void SendConfirmOverPhoneF(int traineeApplicationID, int nowAccountID)
        {
            new TraineeApplicationPhoneOver(traineeApplicationID, nowAccountID).ConfirmOverPhone();
        }

    }
}
