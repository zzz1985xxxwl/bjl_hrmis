//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DepartmentShowListPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-03-12
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Departments;
using SEP.Model.Departments;
using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IDepartments;
using SEP.Model.Accounts;

namespace SEP.Presenter.Departments
{
    public class DepartmentShowListPresenter : BasePresenter
    {
        private readonly IDepartmentListView _ItsView;
        public IDepartmentBll _DepartmentBll = BllInstance.DepartmentBllInstance;
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private List<Department> DepartmentOrder;

        public DepartmentShowListPresenter(IDepartmentListView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
            _ItsView.Message = string.Empty;
            DepartmentDataBind();
        }  

        public void DepartmentDataBind()
        {
            try
            {
                DepartmentOrder = new List<Department>();
                List<Department> itsSource = _DepartmentBll.GetAllDepartmentTree(LoginUser);
                Order(itsSource,"");
                foreach (Department department in DepartmentOrder)
                {
                    department.Members =
                        _AccountBll.GetAccountByCondition("", department.Id, null, null);
                }
                foreach (Department department in DepartmentOrder)
                {
                    department.Leader = _AccountBll.GetAccountById(department.Leader.Id);
                }
                _ItsView.Departments = DepartmentOrder;
            }
            catch (ApplicationException ae)
            {
                _ItsView.Message = ae.Message;
            }
        }

        private void Order(IEnumerable<Department> departmentList,string indexfromroot)
        {
            if (departmentList != null)
            {
                int i = 1;
                foreach (Department department in departmentList)
                {
                    department.IndexFromRoot = indexfromroot + "_" + i++;
                    DepartmentOrder.Add(department);
                    if (department.ChildDept.Count > 0)
                    {
                        Order(department.ChildDept,department.IndexFromRoot);
                    }
                }
            }
        }

        public override void Initialize(bool isPostBack)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}