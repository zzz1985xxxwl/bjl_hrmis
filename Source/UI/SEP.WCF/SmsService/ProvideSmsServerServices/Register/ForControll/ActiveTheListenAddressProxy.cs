using System;
using System.ServiceModel;
using SmsControlContract.ClientAddressModels;
using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register.ForControll
{
    public class ActiveTheListenAddressProxy : ActiveTheListenAddress
    {
        private readonly ISingleSmsClientContract _TheClientProxy;

        public ActiveTheListenAddressProxy(int theClientInformationId, int theListenAddressId,ISingleSmsClientContract theClientProxy, IClientInformationDal theDal)
            :base(theClientInformationId,theListenAddressId,theDal)
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
                _TheClientProxy.TheServiceStatusChanged(true, listenAddressModel.ListenAddress);
            }
            catch (FaultException)
            {
                throw new ApplicationException("ҵ���Ѿ���ɣ�����֪ͨ�ͻ��˷����Ѿ��ı�δ�ܳɹ��������ǿͻ����Ѿ��ر�");
            }
        }
    }
}