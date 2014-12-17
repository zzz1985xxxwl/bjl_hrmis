//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: DepartmentDal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 部门组织结构持久层实现
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Framework.Common;
using SEP.IDal.Departments;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.SqlServerDal
{
    public class DepartmentDal : IDepartmentDal
    {
        #region

        private const string _DepartmentPKID = "@PKID";
        private const string _DepartmentName = "@DepartmentName";
        private const string _DepartmentLeader = "@LeaderId";
        private const string _ParentDepartment = "@ParentId";
        private const string _DepartmentId = "@DepartmentId";

        private const string _EmployeeId = "@EmployeeId";

        private const string _DbDepartmentID = "PKID";
        private const string _DbDepartmentName = "DepartmentName";
        private const string _DbDepartmentLeaderId = "LeaderId";
        private const string _DbDepartmentParentId = "ParentId";

        private const string _Address = "@Address";
        private const string _Phone = "@Phone";
        private const string _Fax = "@Fax";
        private const string _FoundationTime = "@FoundationTime";
        private const string _Others = "@Others";
        private const string _Description = "@Description";

        private const string _DbAddress = "Address";
        private const string _DbPhone = "Phone";
        private const string _DbFax = "Fax";
        private const string _DbFoundationTime = "FoundationTime";
        private const string _DbOthers = "Others";
        private const string _DbDescription = "Description";
        #endregion

        /// <summary>
        /// 缓存公司部门树
        /// </summary>
        private static List<Department> _DeptTree;

        public Department CreateDeptFromDB(IDataRecord dr)
        {
            Department department = null;

            if (dr == null)
                return department;

            if (dr[_DbDepartmentID] == DBNull.Value)
                return department;

            department = new Department();

            department.Id = Convert.ToInt32(dr[_DbDepartmentID]);
            department.Name = dr[_DbDepartmentName].ToString();
            department.Leader = new Account();
            department.Leader.Id = Convert.ToInt32(dr[_DbDepartmentLeaderId]);
            if (dr[_DbAddress] != DBNull.Value)
            {
                department.Address = dr[_DbAddress].ToString();
            }
            if (dr[_DbPhone] != DBNull.Value)
            {
                department.Phone = dr[_DbPhone].ToString();
            }
            if (dr[_DbFax] != DBNull.Value)
            {
                department.Fax = dr[_DbFax].ToString();
            }
            if (dr[_DbOthers] != DBNull.Value)
            {
                department.Others = dr[_DbOthers].ToString();
            }
            if (dr[_DbDescription] != DBNull.Value)
            {
                department.Description = dr[_DbDescription].ToString();
            }
            if (dr[_DbFoundationTime] != DBNull.Value)
            {
                department.FoundationTime = Convert.ToDateTime(dr[_DbFoundationTime]);
            }
            return department;
        }

        private List<Department> CreateDeptTree(List<DBDept> sdrs)
        {
            List<Department> depts = new List<Department>();

            if (sdrs == null || sdrs.Count == 0)
                return depts;

            int loadDeptCount = 0;
            int deptCount;
            do
            {
                deptCount = 0;
                foreach (DBDept sdr in sdrs)
                {
                    ++deptCount;

                    if (sdr.HasLoad)
                        continue;

                    int parentId = sdr.ParentId;

                    if (parentId == 0)
                    {
                        ++loadDeptCount;
                        Department dept = new Department();
                        dept.Id = sdr.Pkid;
                        dept.Name = sdr.Name;

                        dept.Leader = new Account();
                        dept.Leader.Id = sdr.LeaderId;
                        dept.Address = sdr.Address;
                        dept.Fax = sdr.Fax;
                        dept.Phone = sdr.Phone;
                        dept.FoundationTime = sdr.FoundationTime;
                        dept.Description = sdr.Description;
                        dept.Others = sdr.Others;
                        depts.Add(dept);
                        sdr.HasLoad = true;
                    }
                    else
                    {
                        Department parentDept = null;
                        foreach (Department dept in depts)
                        {
                            parentDept = dept.FindDept(parentId);
                            if (parentDept != null)
                                break;
                        }
                        if (parentDept != null)
                        {
                            ++loadDeptCount;
                            Department dept = new Department();
                            dept.Id = sdr.Pkid;
                            dept.Name = sdr.Name;

                            dept.Leader = new Account();
                            dept.Leader.Id = sdr.LeaderId;

                            dept.ParentDepartment = parentDept;
                            dept.Address = sdr.Address;
                            dept.Fax = sdr.Fax;
                            dept.Phone = sdr.Phone;
                            dept.FoundationTime = sdr.FoundationTime;
                            dept.Description = sdr.Description;
                            dept.Others = sdr.Others;

                            parentDept.ChildDept.Add(dept);
                            sdr.HasLoad = true;
                        }
                    }
                }
            }
            while (deptCount != loadDeptCount);

            return depts;
        }

        #region IDepartmentDal 成员

        public int InsertDepartment(int parentId, Department obj)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_DepartmentPKID, SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.Parameters.Add(_DepartmentName, SqlDbType.NVarChar, 50).Value = obj.Name;
            cmd.Parameters.Add(_DepartmentLeader, SqlDbType.Int).Value = obj.Leader.Id;
            cmd.Parameters.Add(_ParentDepartment, SqlDbType.Int).Value = parentId;
            cmd.Parameters.Add(_Address, SqlDbType.NVarChar, 200).Value = obj.Address;
            cmd.Parameters.Add(_Phone, SqlDbType.NVarChar, 50).Value = obj.Phone;
            cmd.Parameters.Add(_Fax, SqlDbType.NVarChar, 50).Value = obj.Fax;
            cmd.Parameters.Add(_Description, SqlDbType.Text).Value = obj.Description;
            cmd.Parameters.Add(_Others, SqlDbType.NVarChar, 50).Value = obj.Others;
            if (obj.FoundationTime == null)
            {
                cmd.Parameters.Add(_FoundationTime, SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add(_FoundationTime, SqlDbType.DateTime).Value = obj.FoundationTime;
            }

            int pkid;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertDepartment", cmd, out pkid);
            obj.Id = pkid;

            _DeptTree = null;
            return pkid;
        }

        public void UpdateDepartment(int parentId, Department obj)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_DepartmentPKID, SqlDbType.Int).Value = obj.Id;
            cmd.Parameters.Add(_DepartmentName, SqlDbType.NVarChar, 50).Value = obj.Name;
            cmd.Parameters.Add(_DepartmentLeader, SqlDbType.Int).Value = obj.Leader.Id;
            cmd.Parameters.Add(_ParentDepartment, SqlDbType.Int).Value = parentId;
            cmd.Parameters.Add(_Address, SqlDbType.NVarChar, 200).Value = obj.Address;
            cmd.Parameters.Add(_Phone, SqlDbType.NVarChar, 50).Value = obj.Phone;
            cmd.Parameters.Add(_Fax, SqlDbType.NVarChar, 50).Value = obj.Fax;
            cmd.Parameters.Add(_Description, SqlDbType.Text).Value = obj.Description;
            cmd.Parameters.Add(_Others, SqlDbType.NVarChar, 50).Value = obj.Others;
            if (obj.FoundationTime == null)
            {
                cmd.Parameters.Add(_FoundationTime, SqlDbType.DateTime).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add(_FoundationTime, SqlDbType.DateTime).Value = obj.FoundationTime;
            }
            SqlHelper.ExecuteNonQuery("UpdateDepartment", cmd);
            _DeptTree = null;
        }

        public void DeleteDepartment(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_DepartmentPKID, SqlDbType.Int).Value = id;
            SqlHelper.ExecuteNonQuery("DeleteDepartment", cmd);

            _DeptTree = null;
        }

        public List<Department> GetAllDepartment()
        {
            List<Department> departments = new List<Department>();

            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDepartment", cmd))
            {
                while (sdr.Read())
                {
                    Department temp = CreateDeptFromDB(sdr);
                    if (temp != null)
                        departments.Add(temp);
                }
            }
            return departments;
        }


        public List<Department> GetAllDepartmentOrderName()
        {
            List<Department> departments = new List<Department>();

            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllDepartmentOrderName", cmd))
            {
                while (sdr.Read())
                {
                    Department temp = CreateDeptFromDB(sdr);
                    if (temp != null)
                        departments.Add(temp);
                }
            }
            return departments;
        }

        public List<Department> GetDepartmentTree()
        {
            if (_DeptTree != null)
                return _DeptTree;

            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDepartment", cmd))
            {
                List<DBDept> sdrList = new List<DBDept>();
                while (sdr.Read())
                {
                    DBDept dbDept = null;
                    try
                    {
                        dbDept = new DBDept(sdr.GetInt32(sdr.GetOrdinal(_DbDepartmentID)), sdr.GetString(sdr.GetOrdinal(_DbDepartmentName)), sdr.GetInt32(sdr.GetOrdinal(_DbDepartmentLeaderId)), sdr.GetInt32(sdr.GetOrdinal(_DbDepartmentParentId)));
                        if (sdr[_DbAddress] != DBNull.Value)
                        {
                            dbDept.Address = sdr.GetString(sdr.GetOrdinal(_DbAddress));
                        }
                        if (sdr[_DbPhone] != DBNull.Value)
                        {
                            dbDept.Phone = sdr.GetString(sdr.GetOrdinal(_DbPhone));
                        }
                        if (sdr[_DbFax] != DBNull.Value)
                        {
                            dbDept.Fax = sdr.GetString(sdr.GetOrdinal(_DbFax));
                        }
                        if (sdr[_DbOthers] != DBNull.Value)
                        {
                            dbDept.Others = sdr.GetString(sdr.GetOrdinal(_DbOthers));
                        }
                        if (sdr[_DbDescription] != DBNull.Value)
                        {
                            dbDept.Description = sdr.GetString(sdr.GetOrdinal(_DbDescription));
                        }
                        if (sdr[_DbFoundationTime] != DBNull.Value)
                        {
                            dbDept.FoundationTime = sdr.GetDateTime(sdr.GetOrdinal(_DbFoundationTime));
                        }

                    }
                    catch
                    {
                        throw new DataException("department data error!");
                    }

                    sdrList.Add(dbDept);
                }
                _DeptTree = CreateDeptTree(sdrList);
                return _DeptTree;
            }
        }

        public Department GetDepartmentById(int deptId)
        {
            Department department = null;
            if (_DeptTree == null)
            {
                _DeptTree = GetDepartmentTree();
            }
            foreach (Department dep in _DeptTree)
            {
                department = dep.FindDept(deptId);
                if (department != null)
                    break;
            }
            return department;
        }

        public Department GetDepartmentByName(string name)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_DepartmentName, SqlDbType.NVarChar, 50).Value = name;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDepartment", cmd))
            {
                while (sdr.Read())
                {
                    return CreateDeptFromDB(sdr);
                }
            }
            return null;
        }

        public bool IsExistDept(int deptId)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_DepartmentPKID, SqlDbType.Int).Value = deptId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDepartment", cmd))
            {
                return sdr.HasRows;
            }
        }

        public List<Department> GetDepartmentByLeaderId(int leaderId)
        {
            List<Department> departments = new List<Department>();

            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_DepartmentLeader, SqlDbType.Int).Value = leaderId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDepartment", cmd))
            {
                while (sdr.Read())
                {
                    Department temp = CreateDeptFromDB(sdr);
                    if (temp != null)
                        departments.Add(temp);
                }
            }
            return departments;
        }

        public List<Department> GetChildDepartment(int deptId)
        {
            List<Department> departments = new List<Department>();

            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_ParentDepartment, SqlDbType.Int).Value = deptId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDepartment", cmd))
            {
                while (sdr.Read())
                {
                    Department temp = CreateDeptFromDB(sdr);
                    if (temp != null)
                        departments.Add(temp);
                }
            }
            return departments;
        }

        public bool HasChildDept(int deptId)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_ParentDepartment, SqlDbType.Int).Value = deptId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDepartment", cmd))
            {
                return sdr.HasRows;
            }
        }

        public Department GetDepartmentByEmployeeId(int employeeId)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_EmployeeId, SqlDbType.Int).Value = employeeId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDepartmentByEmployeeId", cmd))
            {
                while (sdr.Read())
                {
                    return CreateDeptFromDB(sdr);
                }
            }
            return null;
        }

        public Department GetParentDepartment(int deptId)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_DepartmentPKID, SqlDbType.Int).Value = deptId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetParentDeptByDeptId", cmd))
            {
                while (sdr.Read())
                {
                    return CreateDeptFromDB(sdr);
                }
            }
            return null;
        }

        public bool HasEmployee(int deptId)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_DepartmentId, SqlDbType.Int).Value = deptId;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccount", cmd))
            {
                return sdr.HasRows;
            }
        }

        /// <summary>
        /// 清空部门树缓存
        /// </summary>
        public void ClearCache()
        {
            _DeptTree = null;
        }

        #endregion

        private class DBDept
        {
            public int Pkid;
            public string Name;
            public int LeaderId;
            public int ParentId;

            public bool HasLoad;

            public DBDept(int pkid, string name, int leaderId, int parentId)
            {
                Pkid = pkid;
                Name = name;
                LeaderId = leaderId;
                ParentId = parentId;
                HasLoad = false;
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
                get
                {
                    return _Description;
                }
                set
                {
                    _Description = value;
                }
            }
        }
    }
}