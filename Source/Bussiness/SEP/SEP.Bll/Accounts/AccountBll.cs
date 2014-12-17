//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: AccountBll.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 账号业务实现
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Bll.Accounts;
using SEP.IBll.Accounts;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.IDal;
using SEP.Model.Departments;
using System;
using SEP.Model.Utility;
using SEP.IDal.Accounts;
namespace SEP.Bll
{
    internal class AccountBll : IAccountBll
    {
        #region IAccountBll 成员

        public Account LoginVerify(string loginName, string password)
        {
            Login login = new Login(loginName, password);
            login.Excute();
            return login.LoginAccount;
        }

        public Account LoginVerify(string loginName, string password, string usbKey, int usbKeyCount)
        {
            Login login = new Login(loginName, password, usbKey, usbKeyCount);
            login.Excute();
            return login.LoginAccount;
        }

        public void CreateAccount(Account account, Account loginUser)
        {
            EmployeeNames = null;

            CreateAccount createAccount = new CreateAccount(account, loginUser);
            createAccount.Excute();
        }

        public void UpdateAccount(Account account, Account loginUser)
        {
            EmployeeNames = null;

            UpdateAccount updateAccount = new UpdateAccount(account, loginUser);
            updateAccount.Excute();
        }

        public void DeleteAccount(int accountId)
        {
            DeleteAccount deleteAccount = new DeleteAccount(accountId);
            deleteAccount.Excute();
        }

        public void DeleteAccount(int accountId, Account loginUser)
        {
            DeleteAccount deleteAccount = new DeleteAccount(accountId, loginUser);
            deleteAccount.Excute();
        }

        public void SetAccountType(int accountId, VisibleType visibleType, Account loginUser)
        {
            DalInstance.AccountDalInstance.ChangeAccountType(accountId, visibleType);
        }

        public void RemoveAccountType(int accountId, VisibleType visibleType, Account loginUser)
        {
            Account account = DalInstance.AccountDalInstance.GetAccountById(accountId);

            if (account == null)
                throw MessageKeys.AppException(MessageKeys._Account_Not_Exist);

            account.AccountType = account.AccountType ^ visibleType;
            DalInstance.AccountDalInstance.ChangeAccountType(accountId, visibleType);
        }

        public void ChangePassword(string loginName, string oldPassword, string newPassword, Account loginUser)
        {
            UpdatePassword changePassword = new UpdatePassword(loginName, oldPassword, newPassword, loginUser);
            changePassword.Excute();
        }

        public void SetDefaultPassword(string loginName, Account loginUser)
        {
            ResetPassword resetPassword = new ResetPassword(loginName, loginUser);
            resetPassword.Excute();
        }

        public void SetUsbKey(string loginName, string usbKey, Account loginUser)
        {
            UpdateUsbKey updateUsbKey = new UpdateUsbKey(loginName, usbKey, loginUser);
            updateUsbKey.Excute();
        }

        public void SavePersonalConfig(Account loginUser, byte[] electronIdiograph)
        {
            SavePersonalConfig SavePersonalConfig = new SavePersonalConfig(loginUser, electronIdiograph);
            SavePersonalConfig.Excute();
        }

        public Account GetAccountByName(string name)
        {
            return DalInstance.AccountDalInstance.GetAccountByName(name);
        }
        public Account GetAccountById(int accountId)
        {
            return DalInstance.AccountDalInstance.GetAccountById(accountId);
        }

        public List<Account> GetAllAccount()
        {
            return DalInstance.AccountDalInstance.GetAllAccount();
        }

        public List<Account> GetAllAccount(Account loginUser)
        {
            return DalInstance.AccountDalInstance.GetAllAccount();
        }

        public List<Account> GetAllValidAccount()
        {
            return DalInstance.AccountDalInstance.GetAllValidAccount();
        }

        public List<Account> GetAllValidAccount(Account loginUser)
        {
            return DalInstance.AccountDalInstance.GetAllValidAccount();
        }

        public List<Account> GetAllHRMisAccount()
        {
            return DalInstance.AccountDalInstance.GetAllHRMisAccount();
        }

        public List<Account> GetAllCRMAccount()
        {
            return DalInstance.AccountDalInstance.GetAllCRMAccount();
        }

        public List<Account> GetAllMyCMMIAccount()
        {
            return DalInstance.AccountDalInstance.GetAllMyCMMIAccount();
        }

        public List<Account> GetAllEShoppingAccount()
        {
            return DalInstance.AccountDalInstance.GetAllEShoppingAccount();
        }

        public Account GetAccountByMobileNum(string mobileNum)
        {
            return DalInstance.AccountDalInstance.GetAccountByMobileNum(mobileNum);
        }

        public List<Account> GetAccountByCondition(string nameLike, int? deptId, int? positionId, bool? visible)
        {
            return DalInstance.AccountDalInstance.GetAccountByCondition(nameLike, deptId, positionId, null,visible);
        }

        public List<Account> GetAccountByCondition(string nameLike, int? deptId, int? positionId, VisibleType visibleType)
        {
            List<Account> result = new List<Account>();

            List<Account> list = DalInstance.AccountDalInstance.GetAccountByCondition(nameLike, deptId, positionId);
            foreach (Account account in list)
            {
                if ((account.AccountType & visibleType) == visibleType)
                    result.Add(account);
            }
            return result;
        }

        public List<Account> GetAccountByBaseCondition(string nameLike, int deptId, int positionId, int? gradesId, bool recursionDepartment, bool? visible)
        {
            int? argDeptId = null;
            if (deptId != -1)
                argDeptId = deptId;

            int? argPositionId = null;
            if (positionId != -1)
                argPositionId = positionId;

            if (!recursionDepartment || !argDeptId.HasValue)
                return DalInstance.AccountDalInstance.GetAccountByCondition(nameLike, argDeptId, argPositionId, gradesId, visible);

            List<Account> accounts = DalInstance.AccountDalInstance.GetAccountByCondition(nameLike, null, argPositionId, gradesId, visible);
            if (accounts.Count != 0)
            {
                Department department = DalInstance.DeptDalInstance.GetDepartmentById(argDeptId.Value);
                for (int i = accounts.Count - 1; i >= 0; i--)
                {
                    if (!department.IsExistDept(accounts[i].Dept.Id))
                        accounts.RemoveAt(i);
                }
            }
            return accounts;
        }

        public List<Account> GetSubordinates(int leaderId)
        {
            List<Account> accounts = new List<Account>();

            List<Department> allDepts = DalInstance.DeptDalInstance.GetDepartmentTree();
            List<Department> mangeDepts = DalInstance.DeptDalInstance.GetDepartmentByLeaderId(leaderId);

            List<Department> mangeDeptTree = new List<Department>();
            foreach (Department dept in mangeDepts)
            {
                foreach (Department allDept in allDepts)
                {
                    Department temp = allDept.FindDept(dept.Id);
                    if (temp != null)
                        mangeDeptTree.Add(temp);
                }
            }

            foreach (Department department in mangeDeptTree)
            {
                FindSubordinates(accounts, department);
            }

            return accounts;
        }

        public List<Account> GetDirectSubordinates(int leaderId)
        {
            List<Account> accounts = new List<Account>();

            List<Department> allDepts = DalInstance.DeptDalInstance.GetDepartmentTree();
            List<Department> mangeDepts = DalInstance.DeptDalInstance.GetDepartmentByLeaderId(leaderId);

            List<Department> mangeDeptTree = new List<Department>();
            foreach (Department dept in mangeDepts)
            {
                foreach (Department allDept in allDepts)
                {
                    Department temp = allDept.FindDept(dept.Id);
                    if (temp != null)
                        mangeDeptTree.Add(temp);
                }
            }

            foreach (Department department in mangeDeptTree)
            {
                List<Account> members = DalInstance.AccountDalInstance.GetAccountByCondition(null, department.Id, null, null,null);
                foreach (Account account in members)
                {
                    if (HasAccount(accounts, account.Id))
                        continue;
                    if (account.Id == leaderId)
                        continue;

                    accounts.Add(account);
                }
                foreach (Department child in department.ChildDept)
                {
                    Account leader = DalInstance.AccountDalInstance.GetAccountById(child.Leader.Id);

                    if (HasAccount(accounts, leader.Id))
                        continue;
                    if (leader.Id == leaderId)
                        continue;

                    accounts.Add(leader);
                }
            }

            return accounts;
        }

        /// <summary>
        /// 获取员工姓名
        /// </summary>
        public List<String> GetAllEmployeeName()
        {
            if (EmployeeNames != null)
                return EmployeeNames;

            EmployeeNames = new List<string>();
            foreach (Account account in GetAllAccount())
            {
                if (!String.IsNullOrEmpty(account.Name))
                    EmployeeNames.Add(account.Name);
            }
            return EmployeeNames;
        }

        public List<Account> GetEmployeeByBasicConditionAndFirstLetter(string employeeName, int positionId, int departmentId,
                                                                bool recursionDepartment, string firstLetter)
        {
            List<Account> result = new List<Account>();
            List<Account> accounts = GetAccountByBaseCondition(employeeName, departmentId, positionId,null,
                                                               recursionDepartment, null);
            foreach (Account account in accounts)
            {
                //note modify by liudan
                try
                {
                    if (firstLetter.ToUpper() == CHS2PinYin.FirstCHSCap(account.Name))
                        result.Add(account);
                }
                catch
                {

                }

            }
            return result;
        }

        /// <summary>
        /// 通过用户Id获取主管信息(仅有主管Id)
        /// </summary>
        public Account GetLeaderByAccountId(int accountId)
        {
            Department department = DalInstance.DeptDalInstance.GetDepartmentByEmployeeId(accountId);
            RecursionDeptLeader(ref department, accountId);
            return department.Leader;
        }

        #endregion

        private static List<String> EmployeeNames;

        private void RecursionDeptLeader(ref Department dept, int accountId)
        {
            if (dept.Leader.Id != accountId)
                return;

            Department parentDept = DalInstance.DeptDalInstance.GetParentDepartment(dept.Id);
            if (parentDept == null)
                return;
            dept = parentDept;
            RecursionDeptLeader(ref dept, accountId);
        }

        private bool HasAccount(List<Account> accounts, int accountId)
        {
            bool temp = false;
            foreach (Account account in accounts)
            {
                temp = account.Id == accountId;
                if (temp)
                    break;
            }
            return temp;
        }

        private void FindSubordinates(List<Account> accounts, Department dept)
        {
            List<Account> members = DalInstance.AccountDalInstance.GetAccountByCondition(null, dept.Id, null,null, null);
            foreach (Account account in members)
            {
                if (HasAccount(accounts, account.Id))
                    continue;

                accounts.Add(account);
            }

            foreach (Department childDept in dept.ChildDept)
            {
                FindSubordinates(accounts, childDept);
            }
        }

        public List<Account> GetChargeAccountByNameAndDeptString(string name, string dept, Account Leader)
        {
            dept = dept.Trim();
            List<Account> retAccount = GetAccountByCondition(name, null, null, true);
            List<Department> depts = new DepartmentBll().GetDepartmentAndChildrenDeptByLeaderID(Leader.Id);
            for (int i = 0; i < retAccount.Count; i++)
            {
                if (Department.FindDepartment(depts, retAccount[i].Dept.Id) == null)
                {
                    retAccount.RemoveAt(i);
                    i--;
                    continue;
                }
                if (!retAccount[i].Dept.Name.Contains(dept))
                {
                    retAccount.RemoveAt(i);
                    i--;
                    continue;
                }
            }
            return retAccount;
        }
        public List<Account> GetAccountByNameString(string sendAccount, out string errorname)
        {
            IAccountDal IAccountDal = DalInstance.AccountDalInstance;
            errorname = string.Empty;
            List<Account> retaccounts = new List<Account>();

            sendAccount = sendAccount.Replace(" ", "");
            sendAccount = sendAccount.Replace("　", "");
            sendAccount = sendAccount.Replace('（', '(');
            sendAccount = sendAccount.Replace('）', ')');
            sendAccount = sendAccount.Replace('；', ';');
            string[] accounts = sendAccount.Split(';');
            for (int i = 0; i < accounts.Length; i++)
            {
                accounts[i] = accounts[i].Trim();

                Account account = IAccountDal.GetAccountByName(accounts[i]);
                if (account == null)
                {
                    errorname += string.IsNullOrEmpty(errorname) ? accounts[i] : "，" + accounts[i];
                }
                else
                {
                    if (Model.Utility.Tools.FindAccountById(retaccounts, account.Id) == null)
                    {
                        account = IAccountDal.GetAccountById(account.Id);
                        retaccounts.Add(account);
                    }
                }
            }
            return retaccounts;
        }

        #region 电子签名
        /// <summary>
        /// 获取电子签名
        /// </summary>
        public byte[] GetElectronIdiographByAccountID(Account loginUser)
        {
            return DalInstance.AccountDalInstance.GetElectronIdiographByAccountID(loginUser.Id);
        }

        /// <summary>
        /// 增加电子签名
        /// </summary>
        public void InsertElectronIdiograph(Account loginUser, byte[] photo)
        {
            DalInstance.AccountDalInstance.InsertElectronIdiograph(loginUser.Id, photo);
        }

        /// <summary>
        /// 更新电子签名
        /// </summary>
        public void UpdateElectronIdiograph(Account loginUser, byte[] photo)
        {
            DalInstance.AccountDalInstance.DeleteElectronIdiographByAccountID(loginUser.Id);
            DalInstance.AccountDalInstance.InsertElectronIdiograph(loginUser.Id, photo);
        }

        public void DeleteElectronIdiograph(Account loginUser)
        {
            DalInstance.AccountDalInstance.DeleteElectronIdiographByAccountID(loginUser.Id);
        }

        #endregion

    }
}
