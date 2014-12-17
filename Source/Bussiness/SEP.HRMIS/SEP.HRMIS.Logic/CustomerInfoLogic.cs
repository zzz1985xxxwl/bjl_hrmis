using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;

namespace SEP.HRMIS.Logic
{
    public class CustomerInfoLogic
    {
        public static CustomerInfoEntity GetCustomerInfoByCode(string code)
        {
            return CustomerInfoDA.GetCustomerInfoByCode(code);
        }


    }
}
