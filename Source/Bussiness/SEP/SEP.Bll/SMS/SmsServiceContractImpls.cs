using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using SEP.IBll.SMS;
using SmsDataContract;

namespace SEP.Bll.SMS
{
    internal class SmsServiceContractImpls : ISmsServiceContract
    {
        #region ISmsServiceContract ��Ա

        public void RegisterSmsClient(string clientListenAddress, string clientId)
        {
            try
            {
                ISmsServiceContract proxy = new ChannelFactory<ISmsServiceContract>("ISmsServiceContractService").CreateChannel();
                proxy.RegisterSmsClient(clientListenAddress, clientId);
                ((IChannel)proxy).Close();
            }
            catch (FaultException fe)
            {
                throw new ApplicationException(fe.Message);
            }
        }

        public void SendOneMessage(SendMessageDataModel aMessage)
        {
            if (!SmsClientProcessCenter.GetSmsServiceEnable.Enable)
            {
                throw new ApplicationException("ҵ���Ѿ���ɣ����ŷ���ʧ�ܣ�����ԭ������ϵ����Ա�鿴");
            }

            try
            {
                ISmsServiceContract proxy = new ChannelFactory<ISmsServiceContract>("ISmsServiceContractService").CreateChannel();
                proxy.SendOneMessage(aMessage);
                ((IChannel)proxy).Close();
            }
            catch (FaultException)
            {
                throw new ApplicationException("ҵ���Ѿ����,���ŷ���ʧ�ܣ��޷����ʷ�������ϵ����Ա�������ö��ŷ���");
            }
        }

        public void UnRegisterSmsClient(string clientListenAddrss, string clientId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
