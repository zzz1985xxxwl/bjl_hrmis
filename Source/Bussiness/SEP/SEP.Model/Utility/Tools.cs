using System;
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.Model.Utility
{
    public static class Tools
    {
        /// <summary>
        /// 移出depts中的重复数据
        /// </summary>
        /// <param name="depts"></param>
        public static void RemoveDuplicatedDeptData(List<Department> depts)
        {
            for (int i = 0; i < depts.Count - 1; i++)
            {
                for (int j = i + 1; j < depts.Count; j++)
                {
                    if (depts[i].Id == depts[j].Id)
                    {
                        depts.RemoveAt(j);
                        j--;
                    }
                }
            }
        } 
        public static bool IsDeptListContainsDept(List<Department> list, Department dept)
        {
            if (dept == null)
                return false;

            if (list == null || list.Count == 0)
                return false;

            foreach (Department department in list)
            {
                if (dept.Id == department.Id)
                    return true;
            }
            return false;
        }

        public static bool ContainsAccountById(List<Account> accounts, int accountId)
        {
            return FindAccountById(accounts, accountId) != null;
        }

        public static Account FindAccountById(List<Account> accounts, int accountId)
        {
            if (accounts == null || accounts.Count == 0)
                return null;

            foreach (Account account in accounts)
            {
                if (account.Id == accountId)
                    return account;
            }
            return null;
        }

        public static Auth FindAuth(List<Auth> auths, AuthType type, int id)
        {
            foreach (Auth auth in auths)
            {
                if (auth.Type != type)
                    continue;

                Auth myAuth = auth.FindAuth(id);
                if (myAuth != null)
                {
                    return myAuth;
                }
            }
            return null;
        }
        /// <summary>
        /// 根据当前操作人，过滤没有权限操作的帐号
        /// </summary>
        /// <param name="oldAccountList"></param>
        /// <param name="type"></param>
        /// <param name="loginUser"></param>
        /// <param name="powersID"></param>
        /// <returns></returns>
        public static List<Account> RemoteUnAuthAccount(List<Account> oldAccountList,
            AuthType type, Account loginUser, int powersID)
        {
            Auth myAuth = loginUser.FindAuth(type, powersID);

            if (myAuth == null)
            {
                return new List<Account>();
                //throw new ApplicationException("没有权限访问");
            }
            if (myAuth.Departments.Count == 0)
                return oldAccountList;

            List<Account> newAccountList = new List<Account>();
            for (int i = 0; i < oldAccountList.Count; i++)
            {
                if (IsDeptListContainsDept(myAuth.Departments, oldAccountList[i].Dept))
                    newAccountList.Add(oldAccountList[i]);
            }
            return newAccountList;
        }

        /// <summary>
        /// 根据当前操作人，过滤没有权限操作的部门
        /// </summary>
        /// <param name="oldDepartmentList"></param>
        /// <param name="type"></param>
        /// <param name="loginUser"></param>
        /// <param name="powersID"></param>
        /// <returns></returns>
        public static List<Department> RemoteUnAuthDeparetment(List<Department> oldDepartmentList, 
            AuthType type, Account loginUser, int powersID)
        {
            Auth myAuth = loginUser.FindAuth(type, powersID);

            if (myAuth == null)
            {
                return new List<Department>();
                //throw new ApplicationException("没有权限访问");
            }
            if (myAuth.Departments.Count == 0)
                return oldDepartmentList;

            List<Department> newDepartmentList = new List<Department>();
            for (int i = 0; i < oldDepartmentList.Count; i++)
            {
                if (IsDeptListContainsDept(myAuth.Departments, oldDepartmentList[i]))
                    newDepartmentList.Add(oldDepartmentList[i]);
            }
            return newDepartmentList;
        }

        public static Account MakeAccountHaveAuth(int accountID, string accountName, AuthType authType, int powerID)
        {
            Account account = new Account(accountID, "", accountName);
            account.Auths = new List<Auth>();
            if (account.Auths == null)
            {
                account.Auths = new List<Auth>();
            }
            Auth ret = account.FindAuth(authType, powerID);
            if (ret == null)
            {
                Auth auth = new Auth(powerID, "");
                auth.Departments = new List<Department>();
                auth.Type = authType;
                account.Auths.Add(auth);
            }
            else
            {
                if (ret.Departments != null && ret.Departments.Count > 0)
                {
                    ret.Departments = new List<Department>();
                }
            }
            return account;
        }

        public static Account MakeAccountHaveAuth(int accountID, string accountName, List<Auth> accountAuthList, AuthType authType, int powerID, List<Department> deptListForAuth)
        {
            Account account = new Account(accountID, "", accountName);
            account.Auths = new List<Auth>();
            account.Auths = accountAuthList;
            if (account.Auths == null)
            {
                account.Auths = new List<Auth>();
            }
            Auth ret = account.FindAuth(authType, powerID);
            if (ret == null)
            {
                Auth auth = new Auth(powerID, "");
                auth.Departments = new List<Department>();
                auth.Departments = deptListForAuth;
                auth.Type = authType;
                account.Auths.Add(auth);
            }
            else
            {
                if (ret.Departments != null && ret.Departments.Count > 0)
                {
                    ret.Departments.AddRange(deptListForAuth);
                    RemoveDuplicatedDeptData(ret.Departments);
                }
            }
            return account;
        }

        public static Account MakeAccountHaveAuth(Account account, AuthType authType, int powerID, List<Department> deptListForAuth)
        {
            if(account ==null)
            {
                return null;
            }
            if (account.Auths == null)
            {
                account.Auths = new List<Auth>();
            }
            Auth ret = account.FindAuth(authType, powerID);
            if (ret == null)
            {
                Auth auth = new Auth(powerID, "");
                auth.Departments = new List<Department>();
                auth.Departments = deptListForAuth;
                auth.Type = authType;
                account.Auths.Add(auth);
            }
            else
            {
                if (ret.Departments != null && ret.Departments.Count > 0)
                {
                    ret.Departments.AddRange(deptListForAuth);
                    RemoveDuplicatedDeptData(ret.Departments);
                }
            }
            return account;
        }
 

    }
}
