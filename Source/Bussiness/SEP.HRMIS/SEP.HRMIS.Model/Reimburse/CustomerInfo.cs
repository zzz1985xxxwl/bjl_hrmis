//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: CustomerInfo.cs
// 创建者: 刘丹
// 创建日期: 2009-08-14
// 概述: 客户信息
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 客户信息
    /// </summary>
     [Serializable]
    public class CustomerInfo
    {
        private int _CustomerInfoId;
        private string _CompanyName;

        ///<summary>
        ///</summary>
        ///<param name="customerInfoId"></param>
        ///<param name="companyName"></param>
        public CustomerInfo(int customerInfoId,string companyName)
        {
            _CustomerInfoId = customerInfoId;
            _CompanyName = companyName;
        }

         /// <summary>
         /// 公司名称
         /// </summary>
        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        ///<summary>
        ///</summary>
        public int CustomerInfoId
        {
            get { return _CustomerInfoId; }
            set { _CustomerInfoId = value; }
        }
    }
}
