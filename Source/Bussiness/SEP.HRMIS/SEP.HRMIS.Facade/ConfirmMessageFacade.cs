using SEP.HRMIS.Bll.RequestPhoneMessages;
using SEP.HRMIS.Bll.RequestPhoneMessages.ConfirmMessages;
using SEP.HRMIS.IFacede;
using SmsDataContract;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfirmMessageFacade : IConfirmMessageFacade
    {
        public void ReSendBlockMessage()
        {
            new ConfirmMessage().ReSendBlockMessage();
        }

        public void ReceiveMessage(ReceiveMessageDataModel message)
        {
            new ReceivedMessageFactory(message).Excute();
        }

        public void FailedSendMessageProcess(SendMessageDataModel theFaildMessage)
        {
           
        }
    }
}