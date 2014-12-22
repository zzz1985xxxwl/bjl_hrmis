//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateContractType.cs
// ������: ����
// ��������: 2008-05-21
// ����: �޸Ĳ���
// ----------------------------------------------------------------
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// �޸ĺ�ͬ����
    /// </summary>
    public class UpdateContractType : Transaction
    {
        private static IContractType _DalContractType = new ContractTypeDal();
        private readonly ContractType _ContractType;
        /// <summary>
        /// ��ͬ���͹��캯��
        /// </summary>
        /// <param name="contractType"></param>
        public UpdateContractType(ContractType contractType)
        {
            _ContractType = contractType;
        }
        /// <summary>
        /// ��ͬ���͹��캯��
        /// </summary>
        /// <param name="contractType"></param>
        /// <param name="dalContractType"></param>
        public UpdateContractType(ContractType contractType, IContractType dalContractType)
        {
            _ContractType = contractType;
            _DalContractType = dalContractType;
        }

        //�޸ĺ�ͬ����ҵ���߼���
        //�ж���Ч��
        //���ͨ���ж�
        // �����²���޸ĺ�ͬ���͵ķ���
        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DalContractType.UpdateContractType(_ContractType);
                    new CreateContractBookMark(_ContractType);
                    ts.Complete();
                }
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        // �޸ĺ�ͬ������Ч���жϣ�
        //1���޸ĵ�����Ҫ����
        //2����ͬ���Ͳ��������е�������ͬ��������
        protected override void Validation()
        {
            if (_DalContractType.GetContractTypeByPkid(_ContractType.ContractTypeID) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._ContractType_Name_NotExist);
            }
            if (_DalContractType.CountContractTypeByNameDiffPKID(_ContractType.ContractTypeID, _ContractType.ContractTypeName) != 0)
            {
                BllUtility.ThrowException(BllExceptionConst._ContractType_Name_Repeat);
            }
        }
    }
}
