//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AddDepartment.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 新增部门
// ----------------------------------------------------------------
using System.Transactions;

using SEP.IDal;
using SEP.Model.Accounts;
using SEP.Model;
using SEP.Model.Departments;

namespace SEP.Bll.Departments
{
    internal class AddDepartment : Transaction
    {
        private Account _LoginUser;
        private Department _Department;
        private int? _ParentDeptId;

        public AddDepartment(int? parentDeptId, Department department, Account loginUser)
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
                        parentId = _ParentDeptId.Value;

                    DepartmentID = DalInstance.DeptDalInstance.InsertDepartment(parentId, _Department);
                    ts.Complete();
                }
            }
            catch
            {
                throw MessageKeys.AppException(MessageKeys._DbError);
            }
        }
        private int _DepartmentID;
        public int DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
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
            if (dept != null)
                throw MessageKeys.AppException(MessageKeys._Department_Name_Repeat);

            //部门主管验证
            if(_Department.Leader == null)
                throw MessageKeys.AppException(MessageKeys._Department_Leader_NotEmpty);
            Account leader = DalInstance.AccountDalInstance.GetAccountByName(_Department.Leader.Name);
            if (leader == null)
            {throw MessageKeys.AppException(MessageKeys._Department_Leader_NotExist);}
            else 
            {_Department.Leader.Id = leader.Id;}
        }
    }
}
