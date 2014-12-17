//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateCustomerInfo.cs
// ������: ����
// ��������: 2009-08-14
// ����: ���¿ͻ���Ϣ
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
            //�д˿ͻ���Ϣ�Ƿ����
            if (_Dal.GetCustomerInfoByCustomerInfoID(_CustomerInfo.CustomerInfoId) == null)
            {
                HrmisUtility.ThrowException(HrmisUtility._CustomerInfo_Not_Exit);
            }
            //���Ƿ�����
            else if (_Dal.CountCustomerInfoByNameDiffPKID(_CustomerInfo.CompanyName, _CustomerInfo.CustomerInfoId) > 0)
            {
                HrmisUtility.ThrowException(HrmisUtility._CustomerInfo_Name_Repeat);
            }
            if (_CustomerInfo.CompanyName.Split(' ').Length > 1)
            {
                if (_Dal.CountCustomerInfoByCodeDiffPKID(_CustomerInfo.CompanyName.Split(' ')[0], _CustomerInfo.CustomerInfoId) > 0)
                {
                    HrmisUtility.ThrowException("�ͻ�����ظ�");
                }
            }
            else
            {
                HrmisUtility.ThrowException("����д�ͻ����");
            }
        }

        protected override void ExcuteSelf()
        {
            _Dal.UpdateCustomerInfo(_CustomerInfo);
        }
    }
}
