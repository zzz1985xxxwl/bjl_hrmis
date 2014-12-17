using System;
using System.ServiceModel;
using ProvideSmsServerServices.Register.ForControll;
using SmsControlContract.ClientAddressModels;
using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register.ForControll
{
    public class DisableTheListenAddressProxy : DisableTheListenAddress
    {
        private readonly ISingleSmsClientContract _TheClientProxy;

        public DisableTheListenAddressProxy(int theClientInformationId, int theListenAddressId, ISingleSmsClientContract theClientProxy, IClientInformationDal theDal)
            : base(theClientInformationId, theListenAddressId, theDal)
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
            ListenAddressModel listenAddressModel = theModelTobeUpdated.GetTheAddressModelById(_TheListenAddressId);
            if (!listenAddressModel.IsActivited)
            {
                return;
            }

            try
            {
                _TheClientProxy.TheServiceStatusChanged(false, listenAddressModel.ListenAddress);
            }
            catch (FaultException)
            {
                throw new ApplicationException("业务已经完成，但是通知客户端服务已经改变未能成功，可能是客户端已经关闭");
            }
        }
    }
}