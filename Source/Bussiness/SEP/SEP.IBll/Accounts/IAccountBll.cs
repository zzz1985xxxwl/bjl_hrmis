//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: IAccountBll.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 账号业务接口
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.Accounts;
using System;

namespace SEP.IBll.Accounts
{
    public interface IAccountBll
    {
        #region 用户登录

        /// <summary>
        /// 登录验证
        /// </summary>
        Account LoginVerify(string loginName, string password);

        /// <summary>
        /// 登录验证
        /// </summary>
        Account LoginVerify(string loginName, string password, string usbKey, int usbKeyCount);

        #endregion

        #region 新增用户

        /// <summary>
        /// 创建账号
        /// </summary>
        void CreateAccount(Account account, Account loginUser);

        #endregion

        #region 修改用户

        /// <summary>
        /// 创建账号
        /// </summary>
        void UpdateAccount(Account account, Account loginUser);

        #endregion

        #region 删除用户

        /// <summary>
        /// 删除账号
        /// </summary>
        void DeleteAccount(int accountId);
        /// <summary>
        /// 删除账号，含权限验证
        /// </summary>
        void DeleteAccount(int accountId, Account loginUser);

        /// <summary>
        /// 设置账号类型
        /// </summary>
        void SetAccountType(int accountId, VisibleType visibleType, Account loginUser);

        /// <summary>
        /// 移出账号类型
        /// </summary>
        void RemoveAccountType(int accountId, VisibleType visibleType, Account loginUser);

        #endregion

        #region 密码，UsbKey管理

        /// <summary>
        /// 修改密码
        /// </summary>
        void ChangePassword(string loginName, string oldPassword, string newPassword, Account loginUser);
        /// <summary>
        /// 重置密码
        /// </summary>
        void SetDefaultPassword(string loginName, Account loginUser);
        /// <summary>
        /// 设置UsbKey
        /// </summary>
        void SetUsbKey(string loginName, string usbKey, Account loginUser);

        //void SetAcceptEmail(int accountId, bool isAcceptEmail);
        //void SetAcceptSMS(int accountId, bool isAcceptSMS);
        //void SetValidateUsbKey(int accountId, bool isValidateUsbKey);
        /// <summary>
        /// 个人设置保存
        /// </summary>
        /// <param name="loginUser"></param>
        /// <param name="electronIdiograph"></param>
        void SavePersonalConfig(Account loginUser, byte[] electronIdiograph);
        #endregion

        #region 获取用户信息
        List<Account> GetChargeAccountByNameAndDeptString(string name, string dept, Account Leader);
        List<Account> GetAccountByNameString(string sendAccount, out string errorname);
        Account GetAccountByName(string name);
        /// <summary>
        /// 根据用户Id获取用户信息
        /// </summary>
        Account GetAccountById(int accountId);
        /// <summary>
        /// 获取所有用户
        ///     Admin除外
        /// </summary>
        List<Account> GetAllAccount();
        /// <summary>
        /// 获取所有用户
        ///     Admin除外
        /// </summary>
        List<Account> GetAllAccount(Account loginUser);
        /// <summary>
        /// 获取所有有效用户
        ///     即为能登录的用户
        ///     Admin除外
        /// </summary>
        List<Account> GetAllValidAccount();
        /// <summary>
        /// 获取所有有效用户
        ///     即为能登录的用户
        ///     Admin除外
        /// </summary>
        List<Account> GetAllValidAccount(Account loginUser);
        /// <summary>
        /// 获取所有HRMis有效用户
        ///     即为能登录HRMis的用户
        ///     Admin除外
        /// </summary>
        List<Account> GetAllHRMisAccount();
        /// <summary>
        /// 获取所有CRM有效用户
        ///     即为能登录CRM的用户
        ///     Admin除外
        /// </summary>
        List<Account> GetAllCRMAccount();
        /// <summary>
        /// 获取所有MyCMMI有效用户
        ///     即为能登录MyCMMI的用户
        ///     Admin除外
        /// </summary>
        List<Account> GetAllMyCMMIAccount();

        /// <summary>
        /// 获取所有MyCMMI有效用户
        ///     即为能登录MyCMMI的用户
        ///     Admin除外
        /// </summary>
        List<Account> GetAllEShoppingAccount();

        /// <summary>
        /// 根据电话号码查询用户
        /// </summary>
        Account GetAccountByMobileNum(string mobileNum);
        /// <summary>
        /// 查找用户
        /// </summary>
        List<Account> GetAccountByCondition(string nameLike, int? deptId, int? positionId, bool? visible);

        /// <summary>
        /// 查找用户
        /// </summary>
        List<Account> GetAccountByCondition(string nameLike, int? deptId, int? positionId, VisibleType visibleType);

        /// <summary>
        /// 按姓名（模糊查询），部门ID(-1表示全部)，职位ID（-1表示全部）查找用户；
        /// 如果recursionDepartment=true,需要加载部门下所有子部门的员工；否则不需要
        /// </summary>
        List<Account> GetAccountByBaseCondition(string nameLike, int deptId, int positionId,int? gradesId, bool recursionDepartment, bool? visible);

        /// <summary>
        /// 根据领导者Id获取其所有下属
        /// </summary>
        List<Account> GetSubordinates(int leaderId);
        //List<Account> GetManageDeptStaffs(int leaderId);

        /// <summary>
        /// 根据领导者Id获取其直属下属
        /// </summary>
        List<Account> GetDirectSubordinates(int leaderId);

        /// <summary>
        /// 获取员工姓名
        /// </summary>
        List<String> GetAllEmployeeName();

        List<Account> GetEmployeeByBasicConditionAndFirstLetter(string employeeName, int positionId, int departmentId,
                                                                bool recursionDepartment, string firstLetter);
        /// <summary>
        /// 通过用户Id获取主管信息(仅有主管Id)
        /// </summary>
        Account GetLeaderByAccountId(int accountId);
        #endregion

        #region 电子签名

        /// <summary>
        /// 获取电子签名
        /// </summary>
        byte[] GetElectronIdiographByAccountID(Account loginUser);

        /// <summary>
        /// 增加电子签名
        /// </summary>
        void InsertElectronIdiograph(Account loginUser, byte[] photo);

        /// <summary>
        /// 更新电子签名
        /// </summary>
        void UpdateElectronIdiograph(Account loginUser, byte[] photo);

        /// <summary>
        /// 更新电子签名
        /// </summary>
        void DeleteElectronIdiograph(Account loginUser);


        #endregion
    }
}
