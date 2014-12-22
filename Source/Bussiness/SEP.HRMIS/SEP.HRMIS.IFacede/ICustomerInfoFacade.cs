//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ICustomerInfoFacade.cs
// ������: ����
// ��������: 2009-08-14
// ����: �ͻ���ϢFacade
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;
namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomerInfoFacade
    {
        /// <summary>
        /// 
        /// </summary>
        void InsertCustomerInfo(CustomerInfo customerInfo);
        /// <summary>
        /// 
        /// </summary>
        void UpdateCustomerInfo(CustomerInfo customerInfo);
        /// <summary>
        /// 
        /// </summary>
        void DeleteCustomerInfo(int pKID);
        /// <summary>
        /// 
        /// </summary>
        CustomerInfo GetCustomerInfoByID(int pKID);
        /// <summary>
        /// 
        /// </summary>
        CustomerInfo GetCustomerIDInfoByName(string name);

        /// <summary>
        /// 
        /// </summary>
        List<CustomerInfo> GetCustomerInfoByNameLike(string name);

    }
}
