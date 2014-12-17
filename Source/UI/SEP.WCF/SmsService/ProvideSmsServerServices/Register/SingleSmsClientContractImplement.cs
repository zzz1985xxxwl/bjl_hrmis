using System.Collections.Generic;
using ConsumeSmsClientService;
using SmsDataContract;

namespace ProvideSmsServerServices.Register
{
    public class SingleSmsClientContractImplement : ISingleSmsClientContract
    {
        private ClientProxy theProxy;

        #region ISingleSmsClientContract ≥…‘±

        public void ClientIsAvailable(string clientAddress)
        {
            using (theProxy = new ClientProxy(clientAddress))
            {
                theProxy.ClientIsAvailable();
            }
        }

        public void TheServiceStatusChanged(bool theStatus, string clientAddress)
        {
            using (theProxy = new ClientProxy(clientAddress))
            {
                theProxy.TheServiceStatusChanged(theStatus);
            }
        }

        public void ReceiveTheMessages(List<ReceiveMessageDataModel> theMessages, string clientAddress)
        {
            using (theProxy = new ClientProxy(clientAddress))
            {
                theProxy.ReceiveTheMessages(theMessages);
            }
        }

        public void SendFailedMessages(SendMessageDataModel theFaildMessage, string clientAddress)
        {
            using (theProxy = new ClientProxy(clientAddress))
            {
                theProxy.SendFailedMessages(theFaildMessage);
            }
        }

        public void ClearBlockMessages(string clientAddress)
        {
            using (theProxy = new ClientProxy(clientAddress))
            {
                theProxy.ClearBlockMessage();
            }
        }

        #endregion
    }
}