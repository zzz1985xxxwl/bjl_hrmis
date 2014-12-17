using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Utility;

namespace SEP.HRMIS.Presenter.EmployeeReimburse
{
    public class CustomerNameLikePresenter
    {
        private List<CustomerInfo> _AllCustomerName;
        private readonly ICustomerInfoFacade _ICustomerInfoFacade = InstanceFactory.CreateCustomerInfoFacade();

        public CustomerNameLikePresenter()
        {
            _AllCustomerName = _ICustomerInfoFacade.GetCustomerInfoByNameLike(string.Empty);
        }

        public string SearchLikeName(string key)
        {
            string result = String.Empty;

            foreach (CustomerInfo customerInfo in _AllCustomerName)
            {
                bool isSprical = false;
                try
                {
                    CHS2PinYin.FirstCHSCap(customerInfo.CompanyName);
                }
                catch
                {
                    isSprical = true;
                }
                if (customerInfo.CompanyName.Contains(key))
                {
                    result += customerInfo.CompanyName + "\n";
                }
                else if (!isSprical && CHS2PinYin.FirstCHSCap(customerInfo.CompanyName).Contains(key.ToUpper()))
                {
                    result += customerInfo.CompanyName + "\n";
                }
            }
            return result;
        }
    }
}
