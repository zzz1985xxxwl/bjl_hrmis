//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: UpdateReimburseItemCustomer.cs
// 创建者: liudan
// 创建日期: 2009-09-08
// 概述: 更新报销item的客户信息
// ----------------------------------------------------------------

using SEP.HRMIS.DalFactory;
using HRMISModel = SEP.HRMIS.Model;
using SEP.HRMIS.IDal;

namespace SEP.HRMIS.Bll.Reimburse
{
    ///<summary>
    /// 更新item的客户信息
    ///</summary>
    public class UpdateReimburseItemCustomer: Transaction
    {
        private static IReimburse _DalReimburse = DalFactory.DataAccess.CreateReimburse();
        private readonly HRMISModel.Reimburse _Reimburse;
        private HRMISModel.Reimburse _OldRimburse;
                /// <summary>
        /// 构造函数
        /// </summary>
        /// <returns></returns>
        public UpdateReimburseItemCustomer(HRMISModel.Reimburse reimburse)
        {
            _Reimburse = reimburse;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reimburse"></param>
        /// <param name="iReimburseMock"></param>
        public UpdateReimburseItemCustomer(HRMISModel.Reimburse reimburse, IReimburse iReimburseMock)
        {
            _DalReimburse = iReimburseMock;
            _Reimburse = reimburse;
        }


        protected override void Validation()
        {
            //验证报销单已存在
            _OldRimburse = _DalReimburse.GetReimburseByReimburseID(_Reimburse.ReimburseID);
            if (_OldRimburse == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Not_Exist);
            }
        }

        protected override void ExcuteSelf()
        {
            //修改报销单的基本信息
            try
            {
                _DalReimburse.UpdateReimburseItemCustomer(_Reimburse);

            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }
    }
}
