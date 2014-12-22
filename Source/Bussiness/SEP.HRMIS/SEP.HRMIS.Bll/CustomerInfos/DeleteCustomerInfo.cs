//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteCustomerInfo.cs
// ������: ����
// ��������: 2009-08-14
// ����: ɾ���ͻ���Ϣ
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
            //�д˿ͻ���Ϣ�Ƿ����
            if (_Dal.GetCustomerInfoByCustomerInfoID(_CustomerInfoId) == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._CustomerInfo_Not_Exit);
            }
            //�ж��Ƿ񱻱�����ʹ��
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
