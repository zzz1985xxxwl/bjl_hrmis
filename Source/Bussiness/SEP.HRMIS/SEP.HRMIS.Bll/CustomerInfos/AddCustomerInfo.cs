//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddCustomerInfo.cs
// 创建者: 刘丹
// 创建日期: 2009-08-14
// 概述: 新增客户信息
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;


namespace SEP.HRMIS.Bll.CustomerInfos
{
    /// <summary>
    /// 新增客户信息
    /// </summary>
    public  class AddCustomerInfo: Transaction
    {
        private static  ICustomerInfoDal _Dal = new CustomerInfoDal();
        private readonly CustomerInfo _CustomerInfo;

        /// <summary>
        /// 
        /// </summary>
        public AddCustomerInfo(CustomerInfo customerInfo)
        {
            _CustomerInfo = customerInfo;
        }
        /// <summary>
        /// test
        /// </summary>
        public AddCustomerInfo(CustomerInfo customerInfo, ICustomerInfoDal ruledal)
        {
            _CustomerInfo = customerInfo;
            _Dal = ruledal;
        }
        protected override void Validation()
        {
            if (_Dal.CountCustomerInfoByNameDiffPKID(_CustomerInfo.CompanyName, 0) > 0)
            {
                HrmisUtility.ThrowException(HrmisUtility._CustomerInfo_Name_Repeat);
            }
            if (_CustomerInfo.CompanyName.Split(' ').Length > 1)
            {
                if (_Dal.CountCustomerInfoByCodeDiffPKID(_CustomerInfo.CompanyName.Split(' ')[0], _CustomerInfo.CustomerInfoId) > 0)
                {
                    HrmisUtility.ThrowException("客户编号重复"); 
                }
            }
            else
            {
                HrmisUtility.ThrowException("请填写客户编号"); 
            }
        }

        protected override void ExcuteSelf()
        {
            _Dal.InsertCustomerInfo(_CustomerInfo);
        }
    }
}
