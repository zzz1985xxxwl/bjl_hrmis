//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: AuthDal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 权限持久层实现
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.IDal.Accounts;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;

namespace SEP.SqlServerDal
{
    public class AuthDal : IAuthDal
    {

        #region

        private const string _AccountId = "@AccountId";
        private const string _AuthId = "@AuthId";
        private const string _DepartmentID = "@DepartmentID";

        private const string _DbAuthId = "PKID";
        private const string _DbAccountId = "AccountId";
        private const string _DbName = "AuthName";
        private const string _DbParentId = "AuthParentId";
        private const string _DbNavigateUrl = "NavigateUrl";
        private const string _DbDepartmentID = "DepartmentID";
        private const string _DbIfHasDepartment = "IfHasDepartment";

        #endregion

        /// <summary>
        /// 获取用户权限，是树形结构
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public List<Auth> GetAccountAuthTree(int accountId)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Value = accountId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccountAuth", cmd))
            {
                return CreateAuthTree(sdr, true);
            }
        }

        public List<Auth> GetAllAuthTree()
        {
            return AllAuthTreeCach;
        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="accountId">用户Id</param>
        public List<Auth> GetAccountAuthList(int accountId)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Value = accountId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccountAuth", cmd))
            {
                return CreateAuthTreeList(sdr);
            }
        }

        /// <summary>
        /// 为用户赋予权限
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="authId"></param>
        /// <param name="departmentID"></param>
        public void SetAccountAuth(int accountId, int authId, int departmentID)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Value = accountId;
            cmd.Parameters.Add(_AuthId, SqlDbType.Int).Value = authId;
            cmd.Parameters.Add(_DepartmentID, SqlDbType.Int).Value = departmentID;

            SqlHelper.ExecuteNonQuery("SetAccountAuth", cmd);
        }

        /// <summary>
        /// 取消用户的所有权限
        /// </summary>
        /// <param name="accountId"></param>
        public void CancelAccountAllAuth(int accountId)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Value = accountId;

            SqlHelper.ExecuteNonQuery("CancelAccountAllAuth", cmd);
        }

        /// <summary>
        /// 根据权限、帐号查找该帐号该权限下的范围
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="authID"></param>
        /// <returns></returns>
        public List<Department> GetDepartmentByBackAccontsID(int accountId, int authID)
        {
            List<Department> returnDepartment = new List<Department>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AuthId, SqlDbType.Int).Value = authID;
            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Value = accountId;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetDepartmentByBackAccontsIDAndAuthID", cmd))
            {
                while (sdr.Read())
                {
                    returnDepartment.Add(
                        new Department((Int32)sdr[_DbDepartmentID], ""));
                }
            }

            if (returnDepartment.Count == 1 && returnDepartment[0].DepartmentID == 0)
            {
                returnDepartment = null;
            }
            return returnDepartment;
        }

        /// <summary>
        /// 获取对某部门有某权限的账号
        /// </summary>
        public List<Account> GetAccountsByAuthIdAndDeptId(int authId, int? deptId)
        {
            List<Account> accounts = new List<Account>();

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AuthId, SqlDbType.Int).Value = authId;
            if (deptId.HasValue)
                cmd.Parameters.Add(_DepartmentID, SqlDbType.Int).Value = deptId.Value;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccountsByAuthIdAndDeptId", cmd))
            {
                while (sdr.Read())
                {
                    int accountId = Convert.ToInt32(sdr[_DbAccountId]);
                    if (accountId == Account.AdminPkid)
                        continue;

                    accounts.Add(new Account(accountId, "", ""));
                }
            }

            return accounts;
        }

        private static List<Auth> _AllAuthTreeCach;

        protected static List<Auth> AllAuthTreeCach
        {
            get
            {
                if (_AllAuthTreeCach == null)
                {
                    SqlCommand cmd = new SqlCommand();

                    using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAllAuth", cmd))
                    {
                        _AllAuthTreeCach = CreateAuthTree(sdr, false);
                    }
                }
                return _AllAuthTreeCach;
            }
        }

        private static Auth FindParentAuth(List<Auth> list, int parentId)
        {
            if (list == null)
            {
                throw new ArgumentNullException("arg list error!");
            }

            Auth parentAuth = Tools.FindAuth(list, AuthType.SEP, parentId);
            if (parentAuth != null)
            {
                return parentAuth;
            }

            Auth temp = Tools.FindAuth(AllAuthTreeCach, AuthType.SEP, parentId);
            if (temp == null)
                throw new DataException("SEP 权限初始化数据错误!");

            parentAuth = new Auth();
            parentAuth.Id = temp.Id;
            parentAuth.Name = temp.Name;
            parentAuth.NavigateUrl = temp.NavigateUrl;
            parentAuth.Type = AuthType.SEP;
            parentAuth.IfHasDepartment = temp.IfHasDepartment;
            list.Add(parentAuth);

            return parentAuth;
        }

        private static List<Auth> CreateAuthTree(IDataReader sdr, bool hasDept)
        {
            List<Auth> myAuthTree = new List<Auth>();
            while (sdr.Read())
            {
                Auth auth;
                int authId = Convert.ToInt32(sdr[_DbAuthId]);

                int deptId = 0;
                if (hasDept)
                    deptId = Convert.ToInt32(sdr[_DbDepartmentID]);

                auth = Tools.FindAuth(myAuthTree, AuthType.SEP, authId);
                if (auth != null && deptId != 0)
                {
                    auth.Departments.Add(new Department(deptId, ""));
                }

                if (auth != null)
                    continue;

                auth = new Auth();
                auth.Id = authId;
                auth.Name = sdr[_DbName].ToString();
                auth.NavigateUrl = sdr[_DbNavigateUrl].ToString();
                auth.Type = AuthType.SEP;
                auth.IfHasDepartment = Convert.ToBoolean(sdr[_DbIfHasDepartment]);
                if (deptId != 0)
                {
                    auth.Departments.Add(new Department(deptId, ""));
                }

                int parentId = Convert.ToInt32(sdr[_DbParentId]);
                if (parentId == 0)
                {
                    myAuthTree.Add(auth);
                }
                else
                {
                    FindParentAuth(myAuthTree, parentId).ChildAuths.Add(auth);
                }
            }

            return myAuthTree;
        }

        private static List<Auth> CreateAuthTreeList(IDataReader sdr)
        {
            List<Auth> auths = new List<Auth>();

            if (sdr == null)
                return auths;

            while (sdr.Read())
            {
                Auth auth = new Auth();
                auth.Id = Convert.ToInt32(sdr[_DbAuthId]);
                auth.Name = sdr[_DbName].ToString();
                auth.NavigateUrl = sdr[_DbNavigateUrl].ToString();
                auth.Type = AuthType.SEP;
                auth.IfHasDepartment = Convert.ToBoolean(sdr[_DbIfHasDepartment]);
                auths.Add(auth);
            }
            return auths;
        }

    }
}
