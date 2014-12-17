//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: Department.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 部门
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.Model.Departments
{

    #region Obsolete

    /*
    [Serializable]
    [Obsolete]
    public class Department
    {
        private int _DepartmentID;
        private string _DepartmentName;
        private Employee _DepartmentLeader;
        private Department _ParentDepartment;
        private List<Department> _ChildDepartments = new List<Department>();
        /// <summary>
        /// 用于团队目标中组装团队信息（包括部门ID和名称）
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="departmentName"></param>
        public Department(int departmentID, string departmentName)
        {
            _DepartmentID = departmentID;
            _DepartmentName = departmentName;
        }
        public Department(int departmentID, Employee departmentLeader, string departmentName, Department parentDepartment)
        {
            _DepartmentID = departmentID;
            _DepartmentName = departmentName;
            _DepartmentLeader = departmentLeader;
            _ParentDepartment = parentDepartment;
        }

        public int DepartmentID
        {
            get
            {
                return _DepartmentID;
            }
            set
            {
                _DepartmentID = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return _DepartmentName;
            }
            set
            {
                _DepartmentName = value;
            }
        }

        public Employee DepartmentLeader
        {
            get
            {
                return _DepartmentLeader;
            }
            set
            {
                _DepartmentLeader = value;
            }
        }

        public Department ParentDepartment
        {
            get
            {
                return _ParentDepartment;
            }
            set
            {
                _ParentDepartment = value;
            }
        }

        public List<Department> ChildDepartment
        {
            get
            {
                return _ChildDepartments;
            }
            set
            {
                _ChildDepartments = value;
            }
        }

        private string _IndexFromRoot;
        public string IndexFromRoot
        {
            get { return _IndexFromRoot; }
            set { _IndexFromRoot = value; }
        }
        private bool _HasChild;
        public bool HasChild
        {
            get { return _HasChild; }
            set { _HasChild = value; }
        }
        public bool HasMemeber
        {
            get
            {
                if (Employees == null || Employees.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private bool _IfSelected;
        public bool IfSelected
        {
            get { return _IfSelected; }
            set { _IfSelected = value; }
        }
        
        private List<Employee> _Employees;
        public List<Employee> Employees
        {
            get { return _Employees; }
            set { _Employees = value; }
        }

        public string EmployeesNamePositionShow
        {
            get
            {
                if (Employees == null)
                {
                    return "";
                }
                string ret = "";
                foreach (Employee employee in Employees)
                {
                    if (employee.EmployeeType==EmployeeTypeEnum.DimissionEmployee)
                    {
                        continue;
                    }
                    ret = ret + "<tr><td>&nbsp;&nbsp;</td><td align='left' width='30%'>" + employee.Name + "</td>" +
                        "<td align='left' width='70%'class='hetong1'>"+employee.Position.Name+"</td></tr>";
                }
                return ret;
            }
        }

        public bool FindEmployee(Employee employee)
        {
            return employee.Department.DepartmentID == DepartmentID;
        }
    }

    */

    #endregion

    /// <summary>
    /// 部门
    /// </summary>
    [Serializable]
    public class Department
    {
        #region

        private int _Id;
        private string _Name;
        private Account _leader;
        private List<Department> _childDept;
        private List<Account> _Members;
        private Department _ParentDepartment;

        /// <summary>
        /// 部门Id
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// 部门领导
        /// </summary>
        public Account Leader
        {
            get { return _leader; }
            set { _leader = value; }
        }

        /// <summary>
        /// 上级部门
        /// </summary>
        public Department ParentDepartment
        {
            get { return _ParentDepartment; }
            set { _ParentDepartment = value; }
        }


        /// <summary>
        /// 下级部门
        /// </summary>
        public List<Department> ChildDept
        {
            get { return _childDept; }
            set { _childDept = value; }
        }

        /// <summary>
        /// 部门成员
        /// </summary>
        public List<Account> Members
        {
            get
            {
                //排除离职人员 add by liudan 2009-09-11
                _Members = _Members ?? new List<Account>();
                List<Account> returnMembers = new List<Account>();
                foreach (Account member in _Members)
                {
                    if (member.AccountType != VisibleType.None)
                    {
                        returnMembers.Add(member);
                    }
                }
                return returnMembers;
            }
            set { _Members = value; }
        }
        /// <summary>
        /// 部门成员,包括不在职的
        /// </summary>
        public List<Account> AllMembers
        {
            get
            {
                return _Members;
            }
        }

        /// <summary>
        /// 下级部门数量
        /// </summary>
        public int CountChildDept
        {
            get { return CalcDept(); }
        }

        /// <summary>
        /// 部门员工数
        /// </summary>
        public int CountEmployee
        {
            get { return CalcEmployees(); }
        }

        #region 用于树形部门结构的网页显示

        /// <summary>
        /// 是否有子部门
        /// </summary>
        public bool HasChild
        {
            get { return ChildDept != null && ChildDept.Count > 0; }
        }

        /// <summary>
        /// 是否有部门成员
        /// </summary>
        public bool HasMemeber
        {
            get
            {
                if (Members != null && Members.Count > 0)
                {
                    foreach (Account member in Members)
                    {
                        if (member.AccountType != VisibleType.None)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 节点
        /// </summary>
        private string _IndexFromRoot;

        public string IndexFromRoot
        {
            get { return _IndexFromRoot; }
            set { _IndexFromRoot = value; }
        }

        public string EmployeesNamePositionShow
        {
            get
            {
                if (Members == null)
                {
                    return "";
                }
                string ret = "";
                foreach (Account account in Members)
                {
                    if (account.AccountType == VisibleType.None)
                    {
                        continue;
                    }
                    ret = ret + "<tr><td>&nbsp;&nbsp;</td><td align='left' width='30%'><span accountid='" + account.Id +
                          "' class='nameshowphoto'>" + account.Name + "</span></td>" +
                          "<td align='left' width='70%'class='hetong1'>" + account.Position.Name + "</td></tr>";
                }
                return ret;
            }
        }

        #endregion

        #endregion

        public Department()
        {
            _Members = new List<Account>();
            _childDept = new List<Department>();
        }

        public Department(int id, string name)
            : this()
        {
            _Id = id;
            _Name = name;
        }

        private int CalcEmployees()
        {
            int count = Members.Count;
            foreach (Department department in _childDept)
            {

                count += department.CountEmployee;
            }
            return count;
        }

        private int CalcDept()
        {
            int count = 0;
            foreach (Department department in _childDept)
            {
                count += department.CountChildDept;
            }
            return count;
        }

        public Department FindDept(int id)
        {
            if (id == _Id)
                return this;

            Department temp = null;
            foreach (Department dept in ChildDept)
            {
                temp = dept.FindDept(id);
                if (temp != null)
                    break;
            }

            return temp;
        }
        public static Department FindDepartment(List<Department> departments, int deptId)
        {
            foreach (Department department in departments)
            {
                if (department.Id == deptId)
                    return department;
            }
            return null;
        }
        public bool IsExistDept(int deptId)
        {
            if (_Id == deptId)
                return true;

            bool temp = false;
            foreach (Department dept in ChildDept)
            {
                temp = dept.IsExistDept(deptId);
                if (temp)
                    break;
            }
            return temp;
        }

        //todo noted by wsl transfer waiting for modify

        public Department(int departmentID, Account departmentLeader, string departmentName, Department parentDepartment)
        {
            _Id = departmentID;
            _Name = departmentName;
            _leader = departmentLeader;
            _ParentDepartment = parentDepartment;
        }

        private bool _IfSelected;

        public bool IfSelected
        {
            get { return _IfSelected; }
            set { _IfSelected = value; }
        }

        public int DepartmentID
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string DepartmentName
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public Account DepartmentLeader
        {
            get { return _leader; }
            set { _leader = value; }
        }

        private string _Address;
        private string _Phone;
        private string _Fax;
        private DateTime? _FoundationTime;
        private string _Others;
        private string _Description;

        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? FoundationTime
        {
            get { return _FoundationTime; }
            set { _FoundationTime = value; }
        }

        /// <summary>
        /// 其他
        /// </summary>
        public string Others
        {
            get { return _Others; }
            set { _Others = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public bool IsEqual(Department dept)
        {
            if (Name != dept.Name
                || Leader.Id != dept.Leader.Id
                || Address != dept.Address
                || Description != dept.Description
                || Fax != dept.Fax
                || Others != dept.Others
                || FoundationTime != dept.FoundationTime
                || Phone != dept.Phone)
            {
                return false;
            }
            return true;
        }

      

        public static Department FindDepartmentInTreeStruct(List<Department> departments, int deptId)
        {
            Department ret = null;
            foreach (Department department in departments)
            {
                if (department.Id == deptId)
                {
                    return department;
                }
                if (department.ChildDept != null)
                {
                    ret = FindDepartmentInTreeStruct(department.ChildDept, deptId);
                }
            }
            return ret;
        }

        public static bool DepartmentsIsEqual(List<Department> deptlist1, List<Department> deptlist2)
        {
            if (deptlist2.Count != deptlist1.Count)
            {
                return false;
            }
            foreach (Department dept in deptlist1)
            {
                if (FindDepartment(deptlist2, dept.Id) == null)
                {
                    return false;
                }
            }
            foreach (Department dept in deptlist2)
            {
                if (FindDepartment(deptlist1, dept.Id) == null)
                {
                    return false;
                }
            }
            return true;
        }

    }
}