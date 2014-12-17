//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ICustomerInfoDal.cs
// 创建者: 刘丹
// 创建日期: 2009-08-14
// 概述: 客户信息Dal
// ----------------------------------------------------------------

using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomerInfoDal
    {
        /// <summary>
        /// 
        /// </summary>
        int InsertCustomerInfo(CustomerInfo customerInfo);
        /// <summary>
        /// 
        /// </summary>
        int UpdateCustomerInfo(CustomerInfo customerInfo);
        /// <summary>
        /// 
        /// </summary>
        int DeleteCustomerInfo(int pKID);
        /// <summary>
        /// 
        /// </summary>
        CustomerInfo GetCustomerInfoByCustomerInfoID(int pKID);
        /// <summary>
        /// 
        /// </summary>
        List<CustomerInfo> GetCustomerInfoByNameLike(string name);
        /// <summary>
        /// 
        /// </summary>
        int CountCustomerInfoByNameDiffPKID(string name, int pkid);

        int CountCustomerInfoByCodeDiffPKID(string code, int pkid);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        CustomerInfo GetCustomerIDInfoByName(string name);
    }
}
