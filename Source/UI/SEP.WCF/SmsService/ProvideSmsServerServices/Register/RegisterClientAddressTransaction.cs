using System;
using System.Collections.Generic;
using ProvideSmsServerServices.Register.DbRestrictLayer;
using SmsControlContract.ClientAddressModels;
using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register
{
    public class RegisterClientAddressTransaction:ITransaction
    {
        private readonly IClientInformationDal _TheAddressDal;
        private readonly string _Address;
        private readonly string _HrmisId;
        private readonly ISingleSmsClientContract _TheSmsClientContract;

        public RegisterClientAddressTransaction(string address, string hrmisId,ISingleSmsClientContract theSmsClientContract, IClientInformationDal theDal)
        {
            _Address = address;
            _HrmisId = hrmisId;
            _TheAddressDal = theDal;
            _TheSmsClientContract = theSmsClientContract;
        }

        public void Excute()
        {
            ClientInformationModel theClientAddress = CheckTheClientAddress(_HrmisId);
            bool theClientAddressIsGood = VerifyTheClientAddress(_Address);

            //�и�Hrmisid��صĶ���
            if (theClientAddress != null)
            {
                //���¶�����Ϣ������������Ϣ��ȫ�ˣ��ڷ��ظ��ͻ�����Ϣ֮ǰ������
                theClientAddress.TryAddDiffierentListenAddress(_Address, theClientAddressIsGood);
                new ClientInformationDbRestrictLayer(_TheAddressDal).UpdateTheObject(theClientAddress);
          
                if (theClientAddress.IsMePermitted(_Address))
                {
                    if (theClientAddressIsGood)
                    {
                        return;
                    }
                    else
                    {
                        throw new ApplicationException("���������ÿͻ��˼����˿�ʧ��");
                    }
                }
                else
                {
                    throw new ApplicationException("��ǰ�ͻ���HrmisIdδ������");
                }
            }
            //�޸�Hrmisid��صĶ���
            else
            {
                new ClientInformationDbRestrictLayer(_TheAddressDal).AddAnObject(ClientInformationModel.CreateGuestAddress(_Address, _HrmisId, theClientAddressIsGood));
                throw new ApplicationException("��ǰ�ͻ���HrmisIdδ������");
            }
        }

        private ClientInformationModel CheckTheClientAddress(string hrmisId)
        {
            List<ClientInformationModel> theClientAddresses = new ClientInformationModelCollection(_TheAddressDal.GetAllClientInfomationModel()).GetClientAddressByHrmisId(hrmisId);
            if (theClientAddresses.Count != 1)
            {
                return null;
            }

            return theClientAddresses[0];
        }

        private bool VerifyTheClientAddress(string address)
        {
            try
            {
                _TheSmsClientContract.ClientIsAvailable(address);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}