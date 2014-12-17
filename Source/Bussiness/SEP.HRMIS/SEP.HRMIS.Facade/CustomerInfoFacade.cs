//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: CustomerInfoFacade.cs
// ������: ����
// ��������: 2009-08-14
// ����: �ͻ���ϢFacade
// ----------------------------------------------------------------

using SEP.HRMIS.IFacede;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Bll.CustomerInfos;

namespace SEP.HRMIS.Facade
{
    ///<summary>
    ///</summary>
    public class CustomerInfoFacade : ICustomerInfoFacade
    {
        public void InsertCustomerInfo(CustomerInfo customerInfo)
        {
             new AddCustomerInfo(customerInfo).Excute();
        }

        public void UpdateCustomerInfo(CustomerInfo customerInfo)
        {
            new UpdateCustomerInfo(customerInfo).Excute();
        }

        public void DeleteCustomerInfo(int pKID)
        {
            new DeleteCustomerInfo(pKID).Excute();
        }

        public CustomerInfo GetCustomerInfoByID(int pKID)
        {
            return new GetCustomerInfo().GetCustomerInfoByCustomerInfoID(pKID);
        }

        public List<CustomerInfo> GetCustomerInfoByNameLike(string name)
        {
            return new GetCustomerInfo().GetCustomerInfoByNameLike(name);
        }

        #region ICustomerInfoFacade ��Ա


        public CustomerInfo GetCustomerIDInfoByName(string name)
        {
            return new GetCustomerInfo().GetCustomerIDInfoByName(name);
        }

        #endregion
    }
}
