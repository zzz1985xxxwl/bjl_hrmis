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
        #region ISmsServiceContract 成员

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
                throw new ApplicationException("业务已经完成，短信发送失败，具体原因，请联系管理员查看");
            }

            try
            {
                ISmsServiceContract proxy = new ChannelFactory<ISmsServiceContract>("ISmsServiceContractService").CreateChannel();
                proxy.SendOneMessage(aMessage);
                ((IChannel)proxy).Close();
            }
            catch (FaultException)
            {
                throw new ApplicationException("业务已经完成,短信发送失败，无法访问服务，请联系管理员尝试重置短信服务");
            }
        }

        public void UnRegisterSmsClient(string clientListenAddrss, string clientId)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
