//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: UpdateAccount.cs
// ������: colbert
// ��������: 2009-02-02
// ����: �޸��˺�ҵ��ʵ��
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

            //Ȩ����֤
            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A101))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            //�û���Ψһ����֤
            if (DalInstance.AccountDalInstance.ValidationLoginName(_NewAccount.Id, _NewAccount.LoginName))
                throw MessageKeys.AppException(MessageKeys._Account_Not_Repeat);

            //����Ψһ����֤
            if (DalInstance.AccountDalInstance.ValidationName(_NewAccount.Id, _NewAccount.Name))
                throw MessageKeys.AppException(MessageKeys._Employee_Name_Repeat);
        }

        protected override void ExcuteSelf()
        {
            //�޸��û�
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