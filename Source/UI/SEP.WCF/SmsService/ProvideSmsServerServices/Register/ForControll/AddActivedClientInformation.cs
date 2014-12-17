using ProvideSmsServerServices.Register.DbRestrictLayer;
using SmsControlContract.ClientAddressModels;
using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register.ForControll
{
    public class AddActivedClientInformation:ITransaction
    {
        private readonly string _HrmisId;
        private readonly string _CompanyDescription;
        private readonly IClientInformationDal _Thedal;

        public AddActivedClientInformation(string hrmisId,string companyDescription,IClientInformationDal thedal)
        {
            _HrmisId = hrmisId;
            _CompanyDescription = companyDescription;
            _Thedal = thedal;
        }

        #region ITransaction ≥…‘±

        public void Excute()
        {
            new ClientInformationDbRestrictLayer(_Thedal).AddAnObject(new ClientInformationModel(_HrmisId, _CompanyDescription, true));
        }

        #endregion
    }
}