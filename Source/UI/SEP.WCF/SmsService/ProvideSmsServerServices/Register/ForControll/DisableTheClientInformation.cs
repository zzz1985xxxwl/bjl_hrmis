using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register.ForControll
{
    public class DisableTheClientInformation : UpdateClientInformaitonBase
    {
        public DisableTheClientInformation(int theClientId, IClientInformationDal theDal)
            : base(theClientId, theDal)
        {
        }

        protected override void ChangeTheObject(SmsControlContract.ClientAddressModels.ClientInformationModel theModelTobeUpdated)
        {
            theModelTobeUpdated.SetTheServiceStatus(false);
        }
    }
}