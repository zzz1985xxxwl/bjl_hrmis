using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register.ForControll
{
    public class ActiveTheClientInformation : UpdateClientInformaitonBase
    {
        public ActiveTheClientInformation(int theClientId,IClientInformationDal theDal)
            : base(theClientId, theDal)
        {
        }

        protected override void ChangeTheObject(SmsControlContract.ClientAddressModels.ClientInformationModel theModelTobeUpdated)
        {
            theModelTobeUpdated.SetTheServiceStatus(true);
        }
    }
}