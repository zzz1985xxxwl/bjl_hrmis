//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: UpdateDepartment.cs
// 创建者: colbert
// 创建日期: 2009-02-20
// 概述: 修改部门
// ----------------------------------------------------------------
using System.Transactions;
using SEP.IDal;
using SEP.Model;
using SEP.Model.Departments;
using SEP.Model.Accounts;

namespace SEP.Bll.Departments
{
    internal class UpdateDepartment : Transaction
    {
        private int? _ParentDeptId;
        private Department _Department;
        private Account _LoginUser;

        public UpdateDepartment(int? parentDeptId, Department department, Account loginUser)
        {
            _ParentDeptId = parentDeptId;
            _Department = department;
            _LoginUser = loginUser;
        }
        
        protected override void ExcuteSelf()
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
                {
                    int parentId = 0;
                    if (_ParentDeptId.HasValue)
                    {
                        parentId = _ParentDeptId.Value;
                    }
                    else
                    {
                        Department parentDept = DalInstance.DeptDalInstance.GetDepartmentById(_Department.Id);
                        parentId = parentDept != null && parentDept.ParentDepartment != null
                                       ? parentDept.ParentDepartment.Id
                                       : 0;
                    }

                    DalInstance.DeptDalInstance.UpdateDepartment(parentId, _Department);
                    ts.Complete();
                }
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }

        protected override void Validation()
        {
            //验证权限
            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A201))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            //上级部门是否存在
            if (_ParentDeptId.HasValue && !DalInstance.DeptDalInstance.IsExistDept(_ParentDeptId.Value))
                throw MessageKeys.AppException(MessageKeys._Department_ParentDepartment_NotExist);

            //部门名称不能与已有部门重名
            Department dept = DalInstance.DeptDalInstance.GetDepartmentByName(_Department.Name);
            if (dept != null && dept.Id != _Department.Id)
                throw MessageKeys.AppException(MessageKeys._Department_Name_Repeat);

            //部门主管验证
            if (_Department.Leader == null)
                throw MessageKeys.AppException(MessageKeys._Department_Leader_NotEmpty);
            Account leader = DalInstance.AccountDalInstance.GetAccountByName(_Department.Leader.Name);
            if (leader == null)
            {  throw MessageKeys.AppException(MessageKeys._Department_Leader_NotExist);}

            _Department.Leader.Id = leader.Id;
        }
    }
}