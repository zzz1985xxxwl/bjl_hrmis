//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AddDepartmentHistory.cs
// ������: ���h��
// ��������: 2008-11-11
// ����: ���Ӳ�����ʷ
// ----------------------------------------------------------------
using System;
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using System.Collections.Generic;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ����������ʷ�����µ�ʱ��֯�ṹ������Ϣ
    /// </summary>
    public class AddDepartmentHistory : Transaction
    {
        private readonly IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance; 
        private readonly IDepartmentHistory _DalDepartmentHistory = new DepartmentHistoryDal();
        private readonly Account _OperatorAccount;
        private readonly DateTime _DtNow = DateTime.Now;
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="operatorAccount"></param>
        public AddDepartmentHistory(Account operatorAccount)
        {
            _OperatorAccount = operatorAccount;
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="operatorAccount"></param>
        /// <param name="mockDepartmentBll"></param>
        /// <param name="mockDalDepartmentHistory"></param>
        public AddDepartmentHistory(Account operatorAccount, IDepartmentBll mockDepartmentBll, IDepartmentHistory mockDalDepartmentHistory)
        {
            _DalDepartmentHistory = mockDalDepartmentHistory;
            _IDepartmentBll = mockDepartmentBll;
            _OperatorAccount = operatorAccount;
        }

        protected override void Validation()
        {
            //throw new System.NotImplementedException();
        }

        protected override void ExcuteSelf()
        {
            List<Department> departmentList = _IDepartmentBll.GetAllDepartment();
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                List<DepartmentHistory> departmentHistoryList = new List<DepartmentHistory>();
                foreach (Department department in departmentList)
                {
                    DepartmentHistory departmentHistory = new DepartmentHistory();
                    departmentHistory.Department = _IDepartmentBll.GetDepartmentById(department.Id, null);
                    departmentHistory.Department.ParentDepartment = _IDepartmentBll.GetParentDept(department.Id, null);
                    if (departmentHistory.Department.ParentDepartment == null)
                    {
                        departmentHistory.Department.ParentDepartment =
                            new Department(0, new Account(0, "", ""), "", null);
                    }
                    departmentHistory.OperationTime = _DtNow;
                    departmentHistory.Operator = _OperatorAccount;
                    departmentHistoryList.Add(departmentHistory);
                }
                _DalDepartmentHistory.InsertDepartmentHistory(departmentHistoryList);
                ts.Complete();
            }
        }
    }
}
