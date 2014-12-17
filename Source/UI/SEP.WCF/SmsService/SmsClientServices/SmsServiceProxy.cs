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
                    throw new ApplicationException("ҵ���Ѿ���ɣ����ŷ���ʧ�ܣ�����ԭ������ϵ����Ա�鿴");
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
                throw new ApplicationException("ҵ���Ѿ����,���ŷ���ʧ�ܣ��޷����ʷ�������ϵ����Ա���ö��ŷ���");
            }

            return true;
        }
    }
}