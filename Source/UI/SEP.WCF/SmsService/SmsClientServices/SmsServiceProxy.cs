using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SmsDataContract;

namespace SmsClientServices
{
    public class SmsServiceProxy
    {
        public static bool SendAMessage(SendMessageDataModel aMessage)
        {
            if (!SmsClientProcessCenter.GetSmsServiceEnable.Enable)
            {
                if(SmsClientProcessCenter.GetSmsServiceEnable.SmsFailedTypes == SmsFailedType.Others)
                {
                    throw new ApplicationException("业务已经完成，短信发送失败，具体原因，请联系管理员查看");
                }
                return false;
            }
            
            try
            {
                ISmsServiceContract proxy = new ChannelFactory<ISmsServiceContract>("ISmsServiceContractService").CreateChannel();
                proxy.SendOneMessage(aMessage);
                ((IChannel)proxy).Close();
            }
            catch
            {
                throw new ApplicationException("业务已经完成,短信发送失败，无法访问服务，请联系管理员重置短信服务");
            }

            return true;
        }
    }
}