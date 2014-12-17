//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: UpdateAccount.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 修改账号业务实现
// ----------------------------------------------------------------
using System.Transactions;
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Bll.Accounts
{
    internal class UpdateAccount : Transaction
    {
        private Account _NewAccount;
        private Account _LoginUser;

        public UpdateAccount(Account newAccount, Account loginUser)
        {
            _NewAccount = newAccount;
            _LoginUser = loginUser;
        }

        protected override void Validation()
        {
            if (_NewAccount.Id == _LoginUser.Id)
                return;

            //权限验证
            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A101))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            //用户名唯一性验证
            if (DalInstance.AccountDalInstance.ValidationLoginName(_NewAccount.Id, _NewAccount.LoginName))
                throw MessageKeys.AppException(MessageKeys._Account_Not_Repeat);

            //姓名唯一性验证
            if (DalInstance.AccountDalInstance.ValidationName(_NewAccount.Id, _NewAccount.Name))
                throw MessageKeys.AppException(MessageKeys._Employee_Name_Repeat);
        }

        protected override void ExcuteSelf()
        {
            //修改用户
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                Account OldAccount = DalInstance.AccountDalInstance.GetAccountById(_NewAccount.Id);
                if (OldAccount != null&&(OldAccount.LoginName!=_NewAccount.LoginName))
                {
                    DalInstance.AccountDalInstance.ChangePassword(OldAccount.LoginName,
                                                                  SecurityUtil.SymmetricEncrypt(
                                                                      SecurityUtil.
                                                                          SymmetricDecrypt(
                                                                          OldAccount.Password,
                                                                          OldAccount.LoginName
                                                                          ), _NewAccount.LoginName));
                    if (!string.IsNullOrEmpty(OldAccount.UsbKey))
                    {
                        DalInstance.AccountDalInstance.SetUsbKey(OldAccount.LoginName,
                                                                 SecurityUtil.SymmetricEncrypt(
                                                                     SecurityUtil.
                                                                         SymmetricDecrypt
                                                                         (OldAccount.UsbKey,
                                                                          OldAccount.LoginName
                                                                         ), _NewAccount.LoginName));
                    }
                }
                DalInstance.AccountDalInstance.UpdateAccount(_NewAccount);


                ts.Complete();
            }
        }
    }
}