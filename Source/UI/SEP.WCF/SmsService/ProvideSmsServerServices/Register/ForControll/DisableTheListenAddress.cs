using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register.ForControll
{
    public class DisableTheListenAddress : SetListenAddressBase
    {
        public DisableTheListenAddress(int theClientInformationId,int theListenAddressId,IClientInformationDal theDal)
            : base(theClientInformationId, theListenAddressId, theDal)
        {
        }

        protected override bool SetTheListenAddressStatus()
        {
            return false;
        }
    }
}