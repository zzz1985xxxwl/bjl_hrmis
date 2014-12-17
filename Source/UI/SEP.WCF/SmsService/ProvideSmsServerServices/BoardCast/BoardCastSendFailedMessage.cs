using System;
using MachineDll;
using SmsDataContract;

namespace ProvideSmsServerServices.BoardCast
{
    public class BoardCastSendFailedMessage:IBoardCastCommand
    {
        private readonly ICallbackDataGateWay _TheGateWay;

        public BoardCastSendFailedMessage(ICallbackDataGateWay theGateWay)
        {
            _TheGateWay = theGateWay;
        }

        public void BoardCastNow(object sender, EventArgs e)
        {
            foreach (SendMessageDataModel failedMessage in ObjectSource.GetMessageBox._FailedSendMessages)
            {
                _TheGateWay.OnSendFailedMessages(failedMessage);
                ObjectSource.GetMessageBox.EnqueueFaildMessageCallBacked(failedMessage);
            }
        }
    }
}