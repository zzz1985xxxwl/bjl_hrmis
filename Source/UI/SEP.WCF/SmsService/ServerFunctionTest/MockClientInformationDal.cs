using System.Collections;
using System.Collections.Generic;
using SmsControlContract.ClientAddressModels;
using SqlServerDal.AddressDal;

namespace ServerFunctionTest
{
    public class MockClientInformationDal : IClientInformationDal
    {
        private static readonly Hashtable _ClientInformation = new Hashtable();
        private static int _Pkid = 1;
        private static int _AddressPkid = 1;

        #region IClientInformationDal ≥…‘±

        public List<ClientInformationModel> GetAllClientInfomationModel()
        {
            List<ClientInformationModel> retval = new List<ClientInformationModel>();
            foreach (ClientInformationModel model in _ClientInformation.Values)
            {
                retval.Add(model);
            }
            return retval;
        }

        public ClientInformationModel GetClientInformationById(int pkid)
        {
            return _ClientInformation[pkid] as ClientInformationModel;
        }

        public void InsertClientInfomationModel(ClientInformationModel aClientAddressModel)
        {
            aClientAddressModel.Pkid = _Pkid;
            foreach (ListenAddressModel lam in aClientAddressModel.TheAddressModelCollcetion)
            {
                lam.Pkid = _AddressPkid++;
            }
            _ClientInformation.Add(_Pkid++, aClientAddressModel);
        }

        public void UpdateClientInfomationModel(ClientInformationModel theClientAddress)
        {
            _ClientInformation[theClientAddress.Pkid] = theClientAddress;
            foreach (ListenAddressModel lam in theClientAddress.TheAddressModelCollcetion)
            {
                lam.Pkid = _AddressPkid++;
            }
        }

        public void ClearAll()
        {
            _ClientInformation.Clear();
            _Pkid = 1;
            _AddressPkid = 1;
        }

        #endregion
    }
}