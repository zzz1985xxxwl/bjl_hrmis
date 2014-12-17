using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Utility;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// ʵ��IAuthDal�ӿ��еķ���
    /// </summary>
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
        /// ��ȡ�û�Ȩ�ޣ������νṹ
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public List<Auth> GetAccountAuth(int accountId)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Value = accountId;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccountAuth", cmd))
            {
                return CreateAuthTree(sdr, true);
            }
        }

        /// <summary>
        /// ��ȡ�û�Ȩ��
        /// </summary>
        /// <param name="accountId">�û�Id</param>
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
        /// Ϊ�û�����Ȩ��
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
        /// ȡ���û�������Ȩ��
        /// </summary>
        /// <param name="accountId"></param>
        public void CancelAccountAllAuth(int accountId)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Value = accountId;

            SqlHelper.ExecuteNonQuery("CancelAccountAllAuth", cmd);
        }

        /// <summary>
        /// ����Ȩ�ޡ��ʺŲ��Ҹ��ʺŸ�Ȩ���µķ�Χ
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
        /// ��ȡ��ĳ������ĳȨ�޵��˺�
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
                    if(accountId == Account.AdminPkid)
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
                        _AllAuthTreeCach = CreateAuthTree(sdr,false);
                    }
                }
                return _AllAuthTreeCach;
            }
        }

        private static Auth FindParentAuth(List<Auth> list, int parentId)
        {
            if(list == null)
            {
                throw new ArgumentNullException("arg list error!");
            }

            Auth parentAuth = Tools.FindAuth(list, AuthType.HRMIS, parentId);
            if (parentAuth != null)
            {
                return parentAuth;
            }

            Auth temp = Tools.FindAuth(AllAuthTreeCach, AuthType.HRMIS, parentId);
            if (temp == null)
                throw new DataException("hrmis Ȩ�޳�ʼ�����ݴ���!");

            parentAuth = new Auth();
            parentAuth.Id = temp.Id;
            parentAuth.Name = temp.Name;
            parentAuth.NavigateUrl = temp.NavigateUrl;
            parentAuth.Type = AuthType.HRMIS;
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

                auth = Tools.FindAuth(myAuthTree, AuthType.HRMIS, authId);
                if (auth != null && deptId != 0)
                {
                    auth.Departments.Add(new Department(deptId, ""));
                }

                if(auth != null)
                    continue;

                auth = new Auth();
                auth.Id = authId;
                auth.Name = sdr[_DbName].ToString();
                auth.NavigateUrl = sdr[_DbNavigateUrl].ToString();
                auth.Type = AuthType.HRMIS;
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
                auth.Type = AuthType.HRMIS;
                auth.IfHasDepartment = Convert.ToBoolean(sdr[_DbIfHasDepartment]);
                auths.Add(auth);
            }
            return auths;
        }
    }
}
