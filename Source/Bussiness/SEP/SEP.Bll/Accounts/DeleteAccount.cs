//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: DeleteAccount.cs
// ������: colbert
// ��������: 2009-02-02
// ����: ɾ���˺�ҵ��ʵ��
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
