using System.Collections.Generic;
using System.ServiceModel;
using Logs;
using SmsControlContract.ClientAddressModels;
using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register.ForControll
{
    public class ClearBlockMessages : ITransaction
    {
        private readonly IClientInformationDal _TheDal;
        private readonly ISingleSmsClientContract _TheClientProxy;

        public ClearBlockMessages(ISingleSmsClientContract theClientProxy, IClientInformationDal thedal)
        {
            _TheDal = thedal;
            _TheClientProxy = theClientProxy;
        }

        public void Excute()
        {
            List<ClientInformationModel> allClientInfoModels = _TheDal.GetAllClientInfomationModel();
            foreach (ClientInformationModel aClient in allClientInfoModels)
            {
                foreach (string address in aClient.GetBoardCastAddress())
                {
                    try
                    {
                        _TheClientProxy.ClearBlockMessages(address);
                    }
                    catch (FaultException)
                    {
                        aClient.CloseTheAddress(address);
                        _TheDal.UpdateClientInfomationModel(aClient);
                        GetLogInstance.GetInstance.DoWriteEventLog(string.Format("为客户端清空业务对象的时候失败，可能是由于客户端已经关闭了，客户端地址为：{0}", address), EventType.Information);
                    }
                }
            }
        }
    }
}