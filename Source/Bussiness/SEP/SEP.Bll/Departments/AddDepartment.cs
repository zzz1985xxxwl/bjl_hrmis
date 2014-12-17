//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddDepartment.cs
// ������: colbert
// ��������: 2009-02-02
// ����: ��������
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
            //��֤Ȩ��
            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A201))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            //�ϼ������Ƿ����
            if (_ParentDeptId.HasValue && !DalInstance.DeptDalInstance.IsExistDept(_ParentDeptId.Value))
                throw MessageKeys.AppException(MessageKeys._Department_ParentDepartment_NotExist);
                
            //�������Ʋ��������в�������
            Department dept = DalInstance.DeptDalInstance.GetDepartmentByName(_Department.Name);
            if (dept != null)
                throw MessageKeys.AppException(MessageKeys._Department_Name_Repeat);

            //����������֤
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
