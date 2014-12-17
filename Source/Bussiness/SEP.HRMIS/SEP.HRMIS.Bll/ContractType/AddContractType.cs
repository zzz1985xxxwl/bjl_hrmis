//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddContractType.cs
// ������: ����
// ��������: 2008-05-21
// ����: ��������
// ----------------------------------------------------------------
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ������ͬ����
    /// </summary>
    public class AddContractType : Transaction
    {
        private static IContractType _DalContractType = DalFactory.DataAccess.CreateContractType();
        private readonly ContractType _ContractType;
        /// <summary>
        /// ������ͬ���͹��캯��
        /// </summary>
        /// <param name="contractType"></param>
        public AddContractType(ContractType contractType)
        {
            _ContractType = contractType;
        }

        /// <summary>
        /// AddContractType�Ĺ��캯����רΪ�����ṩ
        /// </summary>
        public AddContractType(ContractType contractType, IContractType dalContractType)
        {

            _ContractType = contractType;
            _DalContractType = dalContractType;
        }

        /// <summary>
        /// �����²��������ͬ���͵ķ���
        /// </summary>
        protected override void ExcuteSelf()
        {
            //try
            //{
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _ContractType.ContractTypeID = _DalContractType.InsertContractType(_ContractType);
                    new CreateContractBookMark(_ContractType);
                    ts.Complete();
                }

            //}
            //catch
            //{
            //    BllUtility.ThrowException(BllExceptionConst._DbError);
            //}
        }

        /// <summary>
        /// ������ͬ������Ч���жϣ�
        /// 1����ͬ���Ͳ��������к�ͬ��������
        /// </summary>
        protected override void Validation()
        {
            //��ͬ���Ͳ��������к�ͬ��������
            if (_DalContractType.CountContractTypeByName(_ContractType.ContractTypeName) != 0)
            {
                BllUtility.ThrowException(BllExceptionConst._ContractType_Name_Repeat);
            }
        }
    }
}