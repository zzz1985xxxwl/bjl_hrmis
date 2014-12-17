//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: UpdatePassword.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 更新账号密码业务实现
// ----------------------------------------------------------------
using SEP.Model.Accounts;
using SEP.Model;
using ShiXin.Security;
using SEP.IDal;

namespace SEP.Bll.Accounts
{
    internal class UpdatePassword : Transaction
    {
        private string _LoginName;
        private string _OldPassword;
        private string _NewPassword;
        private Account _LoginUser;

        public UpdatePassword(string loginName, string oldPassword, string newPassword, Account loginUser)
        {
            _LoginName = loginName;
            _LoginUser = loginUser;
            _OldPassword = oldPassword;
            _NewPassword = newPassword;
        }

        //public UpdatePassword(string loginName, Account loginUser)
        //{
        //    _LoginName = loginName;
        //    _LoginUser = loginUser;
        //    _NewPassword = Account.DefaultPassword;
        //}

        protected override void Validation()
        {
            if (_LoginName != _LoginUser.LoginName)
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            if (SecurityUtil.SymmetricEncrypt(_OldPassword, _LoginName) != _LoginUser.Password)
                throw MessageKeys.AppException(MessageKeys._OldPassword_Wrong);
        }

        protected override void ExcuteSelf()
        {
            DalInstance.AccountDalInstance.ChangePassword(_LoginName,
                                                          SecurityUtil.SymmetricEncrypt(_NewPassword, _LoginName));
        }
    }
}
