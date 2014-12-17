//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateReimburseItemCustomer.cs
// ������: liudan
// ��������: 2009-09-08
// ����: ���±���item�Ŀͻ���Ϣ
// ----------------------------------------------------------------

using SEP.HRMIS.DalFactory;
using HRMISModel = SEP.HRMIS.Model;
using SEP.HRMIS.IDal;

namespace SEP.HRMIS.Bll.Reimburse
{
    ///<summary>
    /// ����item�Ŀͻ���Ϣ
    ///</summary>
    public class UpdateReimburseItemCustomer: Transaction
    {
        private static IReimburse _DalReimburse = DalFactory.DataAccess.CreateReimburse();
        private readonly HRMISModel.Reimburse _Reimburse;
        private HRMISModel.Reimburse _OldRimburse;
                /// <summary>
        /// ���캯��
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
            //��֤�������Ѵ���
            _OldRimburse = _DalReimburse.GetReimburseByReimburseID(_Reimburse.ReimburseID);
            if (_OldRimburse == null)
            {
                BllUtility.ThrowException(BllExceptionConst._Reimburse_Not_Exist);
            }
        }

        protected override void ExcuteSelf()
        {
            //�޸ı������Ļ�����Ϣ
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
