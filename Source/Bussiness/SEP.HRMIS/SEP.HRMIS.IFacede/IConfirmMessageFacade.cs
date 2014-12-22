using SmsDataContract;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConfirmMessageFacade
    {
        /// <summary>
        /// 
        /// </summary>
        void ReSendBlockMessage();

        /// <summary>
        /// 
        /// </summary>
        void ReceiveMessage(ReceiveMessageDataModel message);

        /// <summary>
        /// 
        /// </summary>
        void FailedSendMessageProcess(SendMessageDataModel theFaildMessage);
    }
}