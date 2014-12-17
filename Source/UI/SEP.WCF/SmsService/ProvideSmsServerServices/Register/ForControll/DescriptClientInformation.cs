using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register.ForControll
{
    public class DescriptClientInformation : UpdateClientInformaitonBase
    {
        private readonly string _Description;

        public DescriptClientInformation(int clientInformationId,string description,IClientInformationDal thedal)
            : base(clientInformationId, thedal)
        {
            _Description = description;
        }

        protected override void ChangeTheObject(SmsControlContract.ClientAddressModels.ClientInformationModel theModelTobeUpdated)
        {
            theModelTobeUpdated.CompanyDescription = _Description;
        }
    }
}