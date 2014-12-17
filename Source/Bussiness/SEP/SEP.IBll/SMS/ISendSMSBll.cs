using SmsDataContract;

namespace SEP.IBll.SMS
{
    public interface ISendSMSBll
    {
        void RegisterSmsClient(string clientListenAddress, string clientId);
        void UnRegisterSmsClient(string clientListenAddrss, string clientId);

        void SendOneMessage(SendMessageDataModel aMessage);
    }
}
