//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: DeleteAccount.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 删除账号业务实现
// ----------------------------------------------------------------
using SEP.Model;
using SEP.Model.Accounts;
using SEP.IDal;

namespace SEP.Bll.Accounts
{
    internal class DeleteAccount : Transaction
    {
        private int _AccountId;
        private Account _LoginUser;

        public DeleteAccount(int accountId)
            : this(accountId, null)
        {
        }

        public DeleteAccount(int accountId, Account loginUser)
        {
            _AccountId = accountId;
            _LoginUser = loginUser;
        }

        protected override void Validation()
        {
            if(_LoginUser == null)
                return;

            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A101))
                throw MessageKeys.AppException(MessageKeys._NoAuth);
        }

        protected override void ExcuteSelf()
        {
            DalInstance.AccountDalInstance.DeleteAccount(_AccountId);
        }
    }
}
