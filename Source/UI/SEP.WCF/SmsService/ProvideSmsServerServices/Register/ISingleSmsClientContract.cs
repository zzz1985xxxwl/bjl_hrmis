using System.Collections.Generic;
using SmsDataContract;

namespace ProvideSmsServerServices.Register
{
    public interface ISingleSmsClientContract
    {
        void ClientIsAvailable(string clientAddress);
        void ClearBlockMessages(string clientAddress);
        void TheServiceStatusChanged(bool theStatus,string clientAddress);
        void ReceiveTheMessages(List<ReceiveMessageDataModel> theMessages,string clientAddress);
        void SendFailedMessages(SendMessageDataModel theFaildMessage,string clientAddress);
    }
}