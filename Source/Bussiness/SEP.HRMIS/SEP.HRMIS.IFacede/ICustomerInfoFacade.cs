//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ICustomerInfoFacade.cs
// 创建者: 刘丹
// 创建日期: 2009-08-14
// 概述: 客户信息Facade
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
