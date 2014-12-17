//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateCustomerInfo.cs
// 创建者: 刘丹
// 创建日期: 2009-08-14
// 概述: 更新客户信息
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.DalFactory;

namespace SEP.HRMIS.Bll.CustomerInfos
{
    ///<summary>
    ///</summary>
    public class UpdateCustomerInfo : Transaction
    {
        private static ICustomerInfoDal _Dal = DalFactory.DataAccess.CreateCustomerInfoDal();
        private readonly CustomerInfo _CustomerInfo;

        /// <summary>
        /// 
        /// </summary>
        public UpdateCustomerInfo(CustomerInfo customerInfo)
        {
            _CustomerInfo = customerInfo;
        }
        /// <summary>
        /// test
        /// </summary>
        public UpdateCustomerInfo(CustomerInfo customerInfo, ICustomerInfoDal ruledal)
        {
            _CustomerInfo = customerInfo;
            _Dal = ruledal;
        }
        protected override void Validation()
        {
            //判此客户信息是否存在
            if (_Dal.GetCustomerInfoByCustomerInfoID(_CustomerInfo.CustomerInfoId) == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._CustomerInfo_Not_Exit);
            }
            //判是否重名
            else if (_Dal.CountCustomerInfoByNameDiffPKID(_CustomerInfo.CompanyName, _CustomerInfo.CustomerInfoId) > 0)
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
            _Dal.UpdateCustomerInfo(_CustomerInfo);
        }
    }
}
