using System.Collections.Generic;
using ProvideSmsServerServices.Register;
using SmsDataContract;

namespace ServerFunctionTest
{
    public class MockSingleSmsClientContract : ISingleSmsClientContract
    {
        public static readonly List<string> _ClientIsAvailableCalled = new List<string>();
        public static readonly List<string> _TheServiceStatusChanged = new List<string>();
        public static readonly List<string> _ReceiveTheMessages = new List<string>();
        public static readonly List<string> _SendFailedMessages = new List<string>();
        public static readonly List<string> _ClearBlockMessages = new List<string>();

        #region ISingleSmsClientContract ≥…‘±

        public void ClientIsAvailable(string clientAddress)
        {
            _ClientIsAvailableCalled.Add(clientAddress);
        }

        public void ClearBlockMessages(string clientAddress)
        {
            _ClearBlockMessages.Add(clientAddress);
        }

        public void TheServiceStatusChanged(bool theStatus, string clientAddress)
        {
            _TheServiceStatusChanged.Add(clientAddress);
        }

        public void ReceiveTheMessages(List<ReceiveMessageDataModel> theMessages, string clientAddress)
        {
            _ReceiveTheMessages.Add(clientAddress);
        }

        public void SendFailedMessages(SendMessageDataModel theFaildMessage, string clientAddress)
        {
            _SendFailedMessages.Add(clientAddress);
        }

        public void ClearAll()
        {
            _ClientIsAvailableCalled.Clear();
            _TheServiceStatusChanged.Clear();
            _ReceiveTheMessages.Clear();
            _SendFailedMessages.Clear();
        }

        #endregion
    }
}