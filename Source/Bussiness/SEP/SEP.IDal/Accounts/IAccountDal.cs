//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: IAccountDal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 账号持久层接口
// ----------------------------------------------------------------
using SEP.Model.Accounts;
using System.Collections.Generic;

namespace SEP.IDal.Accounts
{
    /// <summary>
    /// 账号持久层接口
    /// </summary>
    public interface IAccountDal
    {
        /// <summary>
        /// 根据登录名获取账号信息
        /// </summary>
        Account GetAccountInfo(string loginName);
        /// <summary>
        /// 创建账号
        /// </summary>
        void CreateAccount(Account account);
        /// <summary>
        /// 登录名唯一性验证
        ///     新增时验证
        /// </summary>
        bool ValidationLoginName(string loginName);
        /// <summary>
        /// 登录名唯一性验证
        ///     修改时验证
        /// </summary>
        bool ValidationLoginName(int accountId, string loginName);
        /// <summary>
        /// 姓名唯一性验证
        ///     新增时验证
        /// </summary>
        bool ValidationName(string name);
        /// <summary>
        /// 姓名唯一性验证
        ///     修改时验证
        /// </summary>
        bool ValidationName(int accountId, string name);
        /// <summary>
        /// 修改员工
        /// </summary>
        void UpdateAccount(Account account);
        /// <summary>
        /// 删除账号
        /// </summary>
        void DeleteAccount(int accountId);
        /// <summary>
        /// 修改账号类型
        /// </summary>
        void ChangeAccountType(int accountId, VisibleType visibleType);
        /// <summary>
        /// 修改密码
        /// </summary>
        void ChangePassword(string loginName, string newPassword);
        /// <summary>
        /// 重置密码
        /// </summary>
        void ResetPassword(string loginName, string defaultPassword);
        /// <summary>
        /// 设置UsbKey
        /// </summary>
        void SetUsbKey(string loginName, string usbKey);

        //void SetAcceptEmail(int accountId, bool isAcceptEmail);
        //void SetAcceptSMS(int accountId, bool isAcceptSMS);
        //void SetValidateUsbKey(int accountId, bool isValidateUsbKey);
        
        Account GetAccountByName(string name);
        Account GetAccountByMobileNum(string mobileNum);
        /// <summary>
        /// 根据员工Id获取员工账号信息
        /// </summary>
        Account GetAccountById(int accountId);
        /// <summary>
        /// 获取所有账号
        ///     Admin除外
        /// </summary>
        List<Account> GetAllAccount();
        /// <summary>
        /// 获取所有有效账号
        ///     即为能登录的账号
        ///     Admin除外
        /// </summary>
        List<Account> GetAllValidAccount();
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
        /// 获取所有EShopping有效用户
        ///     即为能登录EShopping的用户
        ///     Admin除外
        /// </summary>
        List<Account> GetAllEShoppingAccount();

        /// <summary>
        /// 查找用户
        /// </summary>
        List<Account> GetAccountByCondition(string nameLike, int? deptId, int? positionId,int? gradeId, bool? visible);
        /// <summary>
        /// 查找用户
        /// </summary>
        List<Account> GetAccountByCondition(string nameLike, int? deptId, int? positionId);

        /// <summary>
        /// 获取电子签名
        /// </summary>
        byte[] GetElectronIdiographByAccountID(int loginUserID);

        /// <summary>
        /// 增加电子签名
        /// </summary>
        void InsertElectronIdiograph(int loginUserID,byte[] photo);

        ///// <summary>
        ///// 更新电子签名
        ///// </summary>
        //void UpdateElectronIdiograph(int loginUserID, byte[] photo);

        /// <summary>
        /// 获取电子签名
        /// </summary>
        void DeleteElectronIdiographByAccountID(int loginUserID);
    }
}
