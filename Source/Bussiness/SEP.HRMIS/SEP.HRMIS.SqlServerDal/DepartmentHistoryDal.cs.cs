//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DepartmentHistoryDal.cs
// 创建者: 王玥琦
// 创建日期: 2008-11-11
// 概述:  实现DepartmentHistoryDal接口中的方法
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 部门历史数据交互
    /// </summary>
    public class DepartmentHistoryDal : IDepartmentHistory
    {
        private const string _DepartmentHistoryID = "@PKID";
        private const string _DepartmentID = "@DepartmentID";
        private const string _DepartmentName = "@DepartmentName";
        private const string _LeaderID = "@LeaderID";
        private const string _LeaderName = "@LeaderName";
        private const string _ParentID = "@ParentID";
        private const string _OperatorName = "@OperatorName";
        private const string _OperationTime = "@OperationTime";

        private const string _DbDepartmentHistoryID = "PKID";
        private const string _DbDepartmentID = "DepartmentID";
        private const string _DbDepartmentName = "DepartmentName";
        private const string _DbLeaderID = "LeaderID";
        private const string _DbLeaderName = "LeaderName";
        private const string _DbParentID = "ParentID";
        private const string _DbOperatorName = "OperatorName";
        private const string _DbOperationTime = "OperationTime";

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

        /// <summary>
        /// 拍下部门历史
        /// </summary>
        /// <param name="departmentHistoryList"></param>
        /// <returns></returns>
        public int InsertDepartmentHistory(List<DepartmentHistory> departmentHistoryList)
        {
            foreach (DepartmentHistory departmentHistory in departmentHistoryList)
            {
                int pkid;
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_DepartmentHistoryID, SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(_DepartmentID, SqlDbType.Int).Value = departmentHistory.Department.DepartmentID;
                cmd.Parameters.Add(_DepartmentName, SqlDbType.NVarChar, 50).Value =
                    departmentHistory.Department.DepartmentName;
                cmd.Parameters.Add(_LeaderID, SqlDbType.Int).Value = departmentHistory.Department.DepartmentLeader.Id;
                cmd.Parameters.Add(_LeaderName, SqlDbType.NVarChar, 50).Value =
                    departmentHistory.Department.DepartmentLeader.Name;
                cmd.Parameters.Add(_ParentID, SqlDbType.Int).Value =
                    departmentHistory.Department.ParentDepartment.DepartmentID;
                cmd.Parameters.Add(_OperatorName, SqlDbType.NVarChar, 50).Value = departmentHistory.Operator.Name;
                cmd.Parameters.Add(_OperationTime, SqlDbType.DateTime).Value = departmentHistory.OperationTime;

                if (departmentHistory.Department.Address == null)
                {
                    cmd.Parameters.Add(_Address, SqlDbType.NVarChar, 200).Value = DBNull.Value;
                }
                else
                {
                cmd.Parameters.Add(_Address, SqlDbType.NVarChar, 200).Value = departmentHistory.Department.Address;
                            }
            if (departmentHistory.Department.Phone == null)
                {
                    cmd.Parameters.Add(_Phone, SqlDbType.NVarChar, 50).Value = DBNull.Value;
                }
                else
                {
                cmd.Parameters.Add(_Phone, SqlDbType.NVarChar, 50).Value = departmentHistory.Department.Phone;
                            }
            if (departmentHistory.Department.Fax == null)
                {
                    cmd.Parameters.Add(_Fax, SqlDbType.NVarChar, 50).Value = DBNull.Value;
                }
                else
                {
                cmd.Parameters.Add(_Fax, SqlDbType.NVarChar, 50).Value = departmentHistory.Department.Fax;
            }
            if (departmentHistory.Department.Description == null)
                {
                    cmd.Parameters.Add(_Description, SqlDbType.Text).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(_Description, SqlDbType.Text).Value = departmentHistory.Department.Description;
                }
                if (departmentHistory.Department.Others == null)
                {
                    cmd.Parameters.Add(_Others, SqlDbType.NVarChar, 50).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(_Others, SqlDbType.NVarChar, 50).Value = departmentHistory.Department.Others;
                }
                if (departmentHistory.Department.FoundationTime == null)
                {
                    cmd.Parameters.Add(_FoundationTime, SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(_FoundationTime, SqlDbType.DateTime).Value = departmentHistory.Department.FoundationTime;
                }
                SqlHelper.ExecuteNonQueryReturnPKID("DepartmentHistoryInsert", cmd, out pkid);
                departmentHistory.DepartmentHistoryPKID = pkid;
            }
            return departmentHistoryList.Count;
        }
        /// <summary>
        /// 获得dt时间点部门的信息
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DepartmentHistory GetDepartmentByDepartmentIDAndDateTime(int departmentID, DateTime dt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_DepartmentID, SqlDbType.Int).Value = departmentID;
            cmd.Parameters.Add(_OperationTime, SqlDbType.DateTime).Value = dt;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDepartmentByDepartmentIDAndDateTime", cmd))
            {
                while (sdr.Read())
                {
                    DepartmentHistory departmentHistory  = new DepartmentHistory();
                    string departmentName = sdr[_DbDepartmentName].ToString();
                    Department parentDepartment = new Department(Convert.ToInt32(sdr[_DbParentID]), "");
                    Department depatment =
                        new Department(departmentID,
                                       new Account(Convert.ToInt32(sdr[_DbLeaderID]), "", sdr[_DbLeaderName].ToString()),
                                       departmentName, parentDepartment);
                    if (sdr[_DbAddress] != DBNull.Value)
                    {
                        depatment.Address = sdr[_DbAddress].ToString();
                    }
                    if (sdr[_DbPhone] != DBNull.Value)
                    {
                        depatment.Phone = sdr[_DbPhone].ToString();
                    }
                    if (sdr[_DbFax] != DBNull.Value)
                    {
                        depatment.Fax = sdr[_DbFax].ToString();
                    }
                    if (sdr[_DbOthers] != DBNull.Value)
                    {
                        depatment.Others = sdr[_DbOthers].ToString();
                    }
                    if (sdr[_DbDescription] != DBNull.Value)
                    {
                        depatment.Description = sdr[_DbDescription].ToString();
                    }
                    if (sdr[_DbFoundationTime] != DBNull.Value)
                    {
                        depatment.FoundationTime = Convert.ToDateTime(sdr[_DbFoundationTime]);
                    }
                    departmentHistory.Department = depatment;
                    departmentHistory.DepartmentHistoryPKID = Convert.ToInt32(sdr[_DbDepartmentHistoryID].ToString());
                    departmentHistory.OperationTime = Convert.ToDateTime(sdr[_DbOperationTime].ToString());
                    departmentHistory.Operator = new Account(0, "", sdr[_DbOperatorName].ToString());
                    return departmentHistory;
                }
            }
            return null;
        }
        /// <summary>
        /// 获得dt时间点的组织架构,无结构
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentNoStructByDateTime(DateTime dt)
        {
            List<Department> departmentList = new List<Department>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_OperationTime, SqlDbType.DateTime).Value = dt;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDepartmentByDateTime", cmd))
            {
                while (sdr.Read())
                {
                    int departmentID = Convert.ToInt32(sdr[_DbDepartmentID]);
                    string departmentName = sdr[_DbDepartmentName].ToString();
                    Department parentDepartment = new Department(Convert.ToInt32(sdr[_DbParentID]), "");
                    Department depatment =
                        new Department(departmentID,
                                       new Account(Convert.ToInt32(sdr[_DbLeaderID]), "", sdr[_DbLeaderName].ToString()),
                                       departmentName, parentDepartment);
                    if (sdr[_DbAddress] != DBNull.Value)
                    {
                        depatment.Address = sdr[_DbAddress].ToString();
                    }
                    if (sdr[_DbPhone] != DBNull.Value)
                    {
                        depatment.Phone = sdr[_DbPhone].ToString();
                    }
                    if (sdr[_DbFax] != DBNull.Value)
                    {
                        depatment.Fax = sdr[_DbFax].ToString();
                    }
                    if (sdr[_DbOthers] != DBNull.Value)
                    {
                        depatment.Others = sdr[_DbOthers].ToString();
                    }
                    if (sdr[_DbDescription] != DBNull.Value)
                    {
                        depatment.Description = sdr[_DbDescription].ToString();
                    }
                    if (sdr[_DbFoundationTime] != DBNull.Value)
                    {
                        depatment.FoundationTime = Convert.ToDateTime(sdr[_DbFoundationTime]);
                    }
                    departmentList.Add(depatment);
                }
            }
            return departmentList;
        }
        private static List<Department> CreateDeptTree(List<DBDept> sdrs)
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
                        dept.Leader.Name = sdr.LeaderName;
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
                            dept.Leader.Name = sdr.LeaderName;

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

        /// <summary>
        /// 获得dt时间点的组织架构,有树形结构
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentTreeStructByDateTime(DateTime dt)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_OperationTime, SqlDbType.DateTime).Value = dt;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDepartmentByDateTime", cmd))
            {
                List<DBDept> sdrList = new List<DBDept>();
                while (sdr.Read())
                {
                    DBDept dbDept;
                    try
                    {
                        dbDept =
                            new DBDept(sdr.GetInt32(sdr.GetOrdinal(_DbDepartmentID)),
                                       sdr.GetString(sdr.GetOrdinal(_DbDepartmentName)),
                                       sdr.GetInt32(sdr.GetOrdinal(_DbLeaderID)),
                                       sdr.GetInt32(sdr.GetOrdinal(_DbParentID)),
                                       sdr.GetString(sdr.GetOrdinal(_DbLeaderName)));
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
                return CreateDeptTree(sdrList);

            }
        }
        /// <summary>
        /// 数据转换使用
        /// </summary>
        private class DBDept
        {
            public readonly int Pkid;
            public readonly string Name;
            public readonly int LeaderId;
            public readonly string LeaderName;
            public readonly int ParentId;
            public bool HasLoad;
            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="pkid"></param>
            /// <param name="name"></param>
            /// <param name="leaderId"></param>
            /// <param name="parentId"></param>
            /// <param name="leaderName"></param>
            public DBDept(int pkid, string name, int leaderId, int parentId,string leaderName)
            {
                Pkid = pkid;
                Name = name;
                LeaderId = leaderId;
                ParentId = parentId;
                LeaderName = leaderName;
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
