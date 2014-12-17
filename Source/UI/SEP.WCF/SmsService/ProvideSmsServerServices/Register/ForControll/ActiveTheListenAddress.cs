using ProvideSmsServerServices.Register.ForControll;
using SqlServerDal.AddressDal;

namespace ProvideSmsServerServices.Register.ForControll
{
    public class ActiveTheListenAddress : SetListenAddressBase
    {
        public ActiveTheListenAddress(int theClientInformationId,int theListenAddressId,IClientInformationDal theDal)
            : base(theClientInformationId, theListenAddressId, theDal)
        {
        }

        protected override bool SetTheListenAddressStatus()
        {
            return true;
        }
    }
}