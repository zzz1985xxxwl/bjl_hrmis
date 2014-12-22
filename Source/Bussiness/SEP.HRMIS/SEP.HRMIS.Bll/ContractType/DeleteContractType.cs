//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddContractType.cs
// ������: ����
// ��������: 2008-05-21
// ����: ɾ������
// ----------------------------------------------------------------
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ɾ����ͬ����
    /// </summary>
    public class DeleteContractType : Transaction
    {
        private static IContractType _DalContractType = new ContractTypeDal();
        private static IContractBookMark _ContractBookMark = new ContractBookMarkDal();
        private static IContract _DalContract = new ContractDal();
        private readonly int _ContractTypeId;
        /// <summary>
        /// ɾ����ͬ����
        /// </summary>
        /// <param name="contractTypeId"></param>
        public DeleteContractType(int contractTypeId)
        {
            _ContractTypeId = contractTypeId;
        }

        /// <summary>
        /// ɾ����ͬ���ͣ�������
        /// </summary>
        public DeleteContractType(int contractTypeId, IContractType dalContractType, IContract dalContract,IContractBookMark dalContractBookMark)
        {
            _ContractTypeId = contractTypeId;
            _DalContractType = dalContractType;
            _DalContract = dalContract;
            _ContractBookMark = dalContractBookMark;

        }

        /// <summary>
        /// �����²��ɾ����ͬ���͵ķ���
        /// </summary>
        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    _DalContractType.DeleteContractType(_ContractTypeId);
                    _ContractBookMark.DeleteContractBookMarkByContractTypeID(_ContractTypeId);
                    ts.Complete();
                }
                
            }
            catch
            {
                BllUtility.ThrowException(BllExceptionConst._DbError);
            }
        }

        /// <summary>
        /// ɾ����ͬ������Ч���жϣ�
        /// 1��Ҫɾ���ĺ�ͬ���ͱ������Ѿ����ڵĺ�ͬ����
        /// 2��û�к�ͬ�������Ҫɾ���ĺ�ͬ����
        /// </summary>
        protected override void Validation()
        {
            if (_DalContractType.GetContractTypeByPkid(_ContractTypeId) == null)
            {
                BllUtility.ThrowException(BllExceptionConst._ContractType_Name_NotExist);
            }
            if (_DalContract.GetEmployeeContractByContractTypeId(_ContractTypeId).Count!=0)
            {
                BllUtility.ThrowException(BllExceptionConst._ConstractType_HasConstract);

            }
        }
    }
}
