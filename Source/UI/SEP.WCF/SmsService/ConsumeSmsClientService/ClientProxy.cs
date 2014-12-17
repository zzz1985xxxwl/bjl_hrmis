using System;
using System.Collections.Generic;
using System.ServiceModel;
using SmsDataContract;

namespace ConsumeSmsClientService
{
    public class ClientProxy : ISmsClientContract,IDisposable
    {
        private readonly string _Address;
        private readonly ISmsClientContract _Proxy;

        public ClientProxy(string address)
        {
            _Address = address;
            _Proxy = new ChannelFactory<ISmsClientContract>(new BasicHttpBinding(), _Address).CreateChannel();
        }

        #region ISmsClientContract ≥…‘±

        public void ClientIsAvailable()
        {
           _Proxy.ClientIsAvailable();
        }

        public void TheServiceStatusChanged(bool theStatus)
        {
            _Proxy.TheServiceStatusChanged(theStatus);
        }

        public void ReceiveTheMessages(List<ReceiveMessageDataModel> theMessages)
        {
            _Proxy.ReceiveTheMessages(theMessages);
        }

        public void SendFailedMessages(SendMessageDataModel theFaildMessage)
        {
            _Proxy.SendFailedMessages(theFaildMessage);
        }

        public void ClearBlockMessage()
        {
            _Proxy.ClearBlockMessage();
        }

        #endregion

        public void Dispose()
        {
            ((System.ServiceModel.Channels.IChannel)_Proxy).Close();
        }
    }
}