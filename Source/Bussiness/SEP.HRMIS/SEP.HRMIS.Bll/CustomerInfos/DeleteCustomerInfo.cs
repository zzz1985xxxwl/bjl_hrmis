//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteCustomerInfo.cs
// 创建者: 刘丹
// 创建日期: 2009-08-14
// 概述: 删除客户信息
// ----------------------------------------------------------------

using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;


namespace SEP.HRMIS.Bll.CustomerInfos
{
    ///<summary>
    ///</summary>
    public class DeleteCustomerInfo: Transaction
    {
        private static  ICustomerInfoDal _Dal = new CustomerInfoDal();
        private static IReimburse _IReimburse = new ReimburseDal();
        private readonly int _CustomerInfoId;

        /// <summary>
        /// 
        /// </summary>
        public DeleteCustomerInfo(int customerInfoid)
        {
            _CustomerInfoId = customerInfoid;
        }
        /// <summary>
        /// test
        /// </summary>
        public DeleteCustomerInfo(int customerInfoid, ICustomerInfoDal ruledal, IReimburse _iReimburse)
        {
            _CustomerInfoId = customerInfoid;
            _Dal = ruledal;
            _IReimburse = _iReimburse;
        }
        protected override void Validation()
        {
            //判此客户信息是否存在
            if (_Dal.GetCustomerInfoByCustomerInfoID(_CustomerInfoId) == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._CustomerInfo_Not_Exit);
            }
            //判断是否被报销单使用
            if(_IReimburse.GetReiburseByCustomerID(_CustomerInfoId))
            {
                HrmisUtility.ThrowException(HrmisUtility._CustomerInfo_Used);
            }
        }

        protected override void ExcuteSelf()
        {
            _Dal.DeleteCustomerInfo(_CustomerInfoId);
        }
    }
}
