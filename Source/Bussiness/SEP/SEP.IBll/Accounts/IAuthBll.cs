//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: IAuthBll.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 权限业务接口
// ----------------------------------------------------------------
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.IBll.Accounts
{
    /// <summary>
    /// 权限业务接口
    /// </summary>
    public interface IAuthBll
    {
        List<Auth> GetAllAuth();
        /// <summary>
        /// 获取所有权限
        /// </summary>
        List<Auth> GetAllAuth(Account loginUser);

        /// <summary>
        /// 获取用户所有权限
        /// </summary>
        List<Auth> GetAccountAllAuth(int accountId, Account loginUser);

        /// <summary>
        /// 获取用户所有权限
        /// </summary>
        List<Auth> GetAccountAllAuthList(int accountId, Account loginUser);

        /// <summary>
        /// 设置用户权限
        /// </summary>
        void SetAccountAuths(List<Auth> newAuths, Account user, Account loginUser);
    }
}
