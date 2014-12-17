//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: CreateAccount.cs
// ������: colbert
// ��������: 2009-02-02
// ����: �����˺�ҵ��ʵ��
// ----------------------------------------------------------------
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;
using Framework.Core;
using SEP.Bll.WelcomeMails;

namespace SEP.Bll.Accounts
{
    internal class CreateAccount : Transaction
    {
        private Account _NewAccount;
        private Account _LoginUser;

        public CreateAccount(Account newAccount, Account loginUser)
        {
            _NewAccount = newAccount;
            _LoginUser = loginUser;
        }

        protected override void Validation()
        {
            //Ȩ����֤
            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A101))
                throw MessageKeys.AppException(MessageKeys._NoAuth);

            //�û���Ψһ����֤
            if(DalInstance.AccountDalInstance.ValidationLoginName(_NewAccount.LoginName))
                throw MessageKeys.AppException(MessageKeys._Account_Not_Repeat);

            //����Ψһ����֤
            if (DalInstance.AccountDalInstance.ValidationName(_NewAccount.Name))
                throw MessageKeys.AppException(MessageKeys._Employee_Name_Repeat);
        }

        protected override void ExcuteSelf()
        {
            _NewAccount.Password = SecurityUtil.SymmetricEncrypt(Account.DefaultPassword, _NewAccount.LoginName);
            
            //�����û�
            DalInstance.AccountDalInstance.CreateAccount(_NewAccount);

            //�첽���ͻ�ӭ��
            AsyncSendWelcomeMail();
        }

        private delegate void SendWelcomeMailDelegate(Account account);
        private void AsyncSendWelcomeMail()
        {
            if (string.IsNullOrEmpty(_NewAccount.Email1) && string.IsNullOrEmpty(_NewAccount.Email2))
                return;
            if (!Tools.IsEmail(_NewAccount.Email1) && !Tools.IsEmail(_NewAccount.Email2))
                return;

            SendWelcomeMailDelegate theDelegate = RunSendWelcomeMailTranscation;
            theDelegate.BeginInvoke(_NewAccount, null, null);
        }

        private void RunSendWelcomeMailTranscation(Account account)
        {
            SendWelcomeMail theWelcomeMail = new SendWelcomeMail(account);
            theWelcomeMail.Excute();
        }
    }
}
