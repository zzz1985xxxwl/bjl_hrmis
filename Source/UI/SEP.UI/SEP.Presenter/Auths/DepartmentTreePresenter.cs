//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// filename: DepartmentTreePresenter.cs
// Creater: Xue.wenlong
// CreateDate: 2009-08-17
// Resume: 
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Presenter.IPresenter.IAccounts;

namespace SEP.Presenter.Auths
{
    public class DepartmentTreePresenter
    {
        private readonly IAssignAuthDepartmentTree _TreeView;
        private readonly string _BackAccountsIDAndAuthID;
        private List<Department> DepartmentOrder;

        public DepartmentTreePresenter(IAssignAuthDepartmentTree iTreeView, string backAccountsIDAndAuthID)
        {
            _TreeView = iTreeView;
            _BackAccountsIDAndAuthID = backAccountsIDAndAuthID;
        }

        public void AttachViewEvent()
        {
            _TreeView.SaveClick += BindDepartment;
        }

        public void BindDepartment()
        {
            Auth auth = new Auth(Convert.ToInt32(_TreeView.AuthID), "");

            auth.Departments = new List<Department>();
            foreach (Department department in _TreeView.DepartmentList)
            {
                auth.Departments.Add(department);
            }

            if (_TreeView.AuthSource == null)
            {
                _TreeView.AuthSource = new List<Auth>();
            }
            List<Auth> tempAuthList = _TreeView.AuthSource;
            for (int i = 0; i < _TreeView.AuthSource.Count; i++)
            {
                if (_TreeView.AuthSource[i].Id == auth.Id)
                {
                    tempAuthList.RemoveAt(i);
                    i--;
                }
            }
            _TreeView.AuthSource = tempAuthList;
            _TreeView.AuthSource.Add(auth);
        }

        private void InitBindDepartment()
        {
            List<Department> departmentList = BllInstance.DepartmentBllInstance.GetAllDepartmentTree(null);
            DepartmentOrder = new List<Department>();
            Order(departmentList, "");
        }

        public void InitDepartmentTree()
        {
            if (_BackAccountsIDAndAuthID != "0")
            {
                string[] temp = _BackAccountsIDAndAuthID.Split('|');
                _TreeView.AuthID = temp[1];
                _TreeView.BackAccountsID = temp[0];
                List<Department> hasDepartments = new List<Department>();
                foreach (Auth auth in _TreeView.AuthSource)
                {
                    if (auth.Id.ToString() == _TreeView.AuthID)
                    {
                        hasDepartments = auth.Departments;
                    }
                }

                InitBindDepartment();
                if (hasDepartments != null)
                {
                    foreach (Department hasDepartment in hasDepartments)
                    {
                        foreach (Department department in DepartmentOrder)
                        {
                            if (hasDepartment.DepartmentID == department.DepartmentID)
                            {
                                department.IfSelected = true;
                                break;
                            }
                        }
                    }
                }
                _TreeView.DepartmentList = DepartmentOrder;
            }
            else
            {
                InitBindDepartment();
                _TreeView.DepartmentList = DepartmentOrder;
            }
        }

        private void Order(IEnumerable<Department> departmentList, string indexfromroot)
        {
            if (departmentList != null)
            {
                int i = 1;
                foreach (Department department in departmentList)
                {
                    department.IfSelected = false;
                    department.IndexFromRoot = indexfromroot + "_" + i++;
                    DepartmentOrder.Add(department);
                    if (department.ChildDept.Count > 0)
                    {
                        Order(department.ChildDept, department.IndexFromRoot);
                    }
                }
            }
        }
    }
}