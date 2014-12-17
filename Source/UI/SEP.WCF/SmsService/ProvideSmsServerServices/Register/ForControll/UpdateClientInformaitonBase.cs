using System;
using ProvideSmsServerServices.Register.DbRestrictLayer;
using SmsControlContract.ClientAddressModels;
using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register.ForControll
{
    public abstract class UpdateClientInformaitonBase:ITransaction
    {
        private readonly int _ClientInfomationId;
        private readonly IClientInformationDal _TheDal;
        protected abstract void ChangeTheObject(ClientInformationModel theModelTobeUpdated);

        protected UpdateClientInformaitonBase(int clientInfomationId, IClientInformationDal theDal)
        {
            _ClientInfomationId = clientInfomationId;
            _TheDal = theDal;
        }

        public void Excute()
        {
            ClientInformationModel _TheModelToBeUpdated = _TheDal.GetClientInformationById(_ClientInfomationId);
            if (_TheModelToBeUpdated == null)
            {
                throw new ApplicationException("无法找到该Id标记的客户信息");
            }
            ChangeTheObject(_TheModelToBeUpdated);
            new ClientInformationDbRestrictLayer(_TheDal).UpdateTheObject(_TheModelToBeUpdated);
        }
    }
}