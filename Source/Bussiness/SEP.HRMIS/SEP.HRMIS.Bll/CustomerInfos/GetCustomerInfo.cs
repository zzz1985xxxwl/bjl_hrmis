//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: GetCustomerInfo.cs
// 创建者: 刘丹
// 创建日期: 2009-08-14
// 概述: 客户信息get方法
// ----------------------------------------------------------------

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

using System.Collections.Generic;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.CustomerInfos
{
    ///<summary>
    ///</summary>
    public class GetCustomerInfo
    {
        private static ICustomerInfoDal _Dal = new CustomerInfoDal();

        /// <summary>
        /// 
        /// </summary>
        public CustomerInfo GetCustomerInfoByCustomerInfoID(int pKID)
        {
            return _Dal.GetCustomerInfoByCustomerInfoID(pKID);
        }
        /// <summary>
        /// 
        /// </summary>
        public List<CustomerInfo> GetCustomerInfoByNameLike(string name)
        {
            return _Dal.GetCustomerInfoByNameLike(name);
        }

        /// <summary>
        /// 
        /// </summary>
        public CustomerInfo GetCustomerIDInfoByName(string name)
        {
            return _Dal.GetCustomerIDInfoByName(name);
        }
    }
}
