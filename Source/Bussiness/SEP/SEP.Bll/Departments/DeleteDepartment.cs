//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DeleteDepartment.cs
// 创建者: 张燕、杨俞彬
// 创建日期: 2008-05-21
// 概述: 删除部门
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
            //验证权限
            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A201))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            //是否存在子部门
            if (DalInstance.DeptDalInstance.HasChildDept(_DeptId))
                throw MessageKeys.AppException(MessageKeys._Department_HasChildren);

            //是否存在员工
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
