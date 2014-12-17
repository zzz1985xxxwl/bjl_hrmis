using System;
using System.ServiceModel;
using SmsControlContract.ClientAddressModels;
using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register.ForControll
{
    public class DisableTheClientInformationProxy : DisableTheClientInformation
    {
        private readonly ISingleSmsClientContract _TheClientProxy;

        public DisableTheClientInformationProxy(int theClientId, ISingleSmsClientContract theClientProxy, IClientInformationDal theDal)
            : base(theClientId, theDal)
        {
            _TheClientProxy = theClientProxy;
        }

        protected override void ChangeTheObject(ClientInformationModel theModelTobeUpdated)
        {
            base.ChangeTheObject(theModelTobeUpdated);
            AfterChangeTheObject(theModelTobeUpdated);
        }

        private void AfterChangeTheObject(ClientInformationModel theModelTobeUpdated)
        {
            try
            {
                foreach (string address in theModelTobeUpdated.GetActivedAddress())
                {
                    _TheClientProxy.TheServiceStatusChanged(false, address);
                }
            }
            catch (FaultException)
            {
                throw new ApplicationException("业务已经完成，但是通知客户端服务已经改变未能成功，可能是客户端已经关闭");
            }
        }
    }
}