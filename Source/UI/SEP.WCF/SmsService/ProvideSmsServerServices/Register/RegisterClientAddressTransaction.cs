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

            //有该Hrmisid相关的对象
            if (theClientAddress != null)
            {
                //更新对象信息，由于所有信息都全了，在返回给客户端信息之前作保存
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
                        throw new ApplicationException("服务器调用客户端监听端口失败");
                    }
                }
                else
                {
                    throw new ApplicationException("当前客户端HrmisId未被允许");
                }
            }
            //无该Hrmisid相关的对象
            else
            {
                new ClientInformationDbRestrictLayer(_TheAddressDal).AddAnObject(ClientInformationModel.CreateGuestAddress(_Address, _HrmisId, theClientAddressIsGood));
                throw new ApplicationException("当前客户端HrmisId未被允许");
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