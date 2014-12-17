using System;
using System.Collections.Generic;
using MachineDll;
using SmsDataContract;

namespace ProvideSmsServerServices.BoardCast
{
    public class BoardCastReceivedMessage:IBoardCastCommand
    {
        private readonly ICallbackDataGateWay _TheGateWay;

        public BoardCastReceivedMessage(ICallbackDataGateWay theGateWay)
        {
            _TheGateWay = theGateWay;
        }

        public void BoardCastNow(object sender, EventArgs e)
        {
            List<ReceiveMessageDataModel> messagesToBeBoardCast = new List<ReceiveMessageDataModel>();
            foreach (ReceiveMessageDataModel aMessage in ObjectSource.GetMessageBox._ReceiveMessages)
            {
                aMessage.MoveNumber86();
                if (!aMessage.IsCleanMessage)
                {
                    continue;
                }
                messagesToBeBoardCast.Add(aMessage);
                aMessage.BoradCasted = true;
                ObjectSource.GetMessageBox.EnqueueReceiveMessage(aMessage);
            }
            //之上处理的是待发送数据，之下处理的是发送数据的地址
            _TheGateWay.OnReceivedMessages(messagesToBeBoardCast);
        }
    }
}