using SEP.Bll.SMS;
using SEP.IBll.SMS;
using SmsDataContract;
using SEP.Model.Accounts;
using SEP.IDal;

namespace SEP.Bll
{
    internal class SendSMSBll : ISendSMSBll
    {
        private ISmsServiceContract sendSMS = new SmsServiceContractImpls();
        #region ISendSMSBll ≥…‘±

        public void RegisterSmsClient(string clientListenAddress, string clientId)
        {
            sendSMS.RegisterSmsClient(clientListenAddress, clientId);
        }

        public void UnRegisterSmsClient(string clientListenAddress, string clientId)
        {
            sendSMS.UnRegisterSmsClient(clientListenAddress, clientId);
        }

        public void SendOneMessage(SendMessageDataModel aMessage)
        {
            Account account = DalInstance.AccountDalInstance.GetAccountByMobileNum(aMessage.SendNumber);
            if(account == null || !account.IsAcceptSMS)
                return;

            try
            {
                sendSMS.SendOneMessage(aMessage);
            }
            catch
            {
            }
        }

        #endregion
    }
}
