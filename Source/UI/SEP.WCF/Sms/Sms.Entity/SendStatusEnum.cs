namespace Sms.Entity
{
    public enum SendStatusEnum
    {
        //等待发送
        ToBeSend = 0,
        //成功发送
        SuccessSended = 1,
        //发送失败的消息，等待被回送
        FailSendedToBeCallback = 2,
        //发送失败的消息，已经被回送
        FailSendedCallbacked = 3,
    }
}