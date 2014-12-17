//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteDepartment.cs
// ������: ���ࡢ�����
// ��������: 2008-05-21
// ����: ɾ������
// ----------------------------------------------------------------
using System.Transactions;

using SEP.Model;
using SEP.Model.Accounts;
using SEP.IDal;

namespace SEP.Bll.Departments
{
    internal class DeleteDepartment : Transaction
    {
        private int _DeptId;
        private Account _LoginUser;

        public DeleteDepartment(int departmentId, Account loginUser)
        {
            _DeptId = departmentId;
            _LoginUser = loginUser;
        }

        protected override void Validation()
        {
            //��֤Ȩ��
            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A201))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            //�Ƿ�����Ӳ���
            if (DalInstance.DeptDalInstance.HasChildDept(_DeptId))
                throw MessageKeys.AppException(MessageKeys._Department_HasChildren);

            //�Ƿ����Ա��
            if (DalInstance.DeptDalInstance.HasEmployee(_DeptId))
                throw MessageKeys.AppException(MessageKeys._Department_HasEmployee);
        }

        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.Required))
                {
                    DalInstance.DeptDalInstance.DeleteDepartment(_DeptId);
                    transScope.Complete();
                }
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }
    }
}
