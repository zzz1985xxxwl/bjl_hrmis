using System;
using SmsControlContract.ClientAddressModels;
using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register.ForControll
{
    public abstract class SetListenAddressBase : UpdateClientInformaitonBase
    {
        protected readonly int _TheListenAddressId;
        protected abstract bool SetTheListenAddressStatus();

        protected SetListenAddressBase(int theClientInformationId, int theListenAddressId, IClientInformationDal theDal)
            : base(theClientInformationId, theDal)
        {
            _TheListenAddressId = theListenAddressId;
        }

        protected override void ChangeTheObject(ClientInformationModel theModelTobeUpdated)
        {
            ListenAddressModel theAddressModel = theModelTobeUpdated.GetTheAddressModelById(_TheListenAddressId);
            if(theAddressModel == null)
            {
                throw new ApplicationException("�޷��ҵ���Id��ǵĵ�ַ��Ϣ");
            }
            theAddressModel.IsPermitted = SetTheListenAddressStatus();
        }
    }
}