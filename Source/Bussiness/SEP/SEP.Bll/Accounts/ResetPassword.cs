using System;
using System.Collections.Generic;
using System.Text;
using SEP.IDal;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Bll.Accounts
{
    internal class ResetPassword : Transaction
    {
        private string _LoginName;
        private Account _LoginUser;

        public ResetPassword(string loginName, Account loginUser)
        {
            _LoginName = loginName;
            _LoginUser = loginUser;
        }


        protected override void Validation()
        {
            if (_LoginName == _LoginUser.LoginName)
                return;

            if (!Powers.HasAuth(_LoginUser.Auths, AuthType.SEP, Powers.A102))
                throw MessageKeys.AppException(MessageKeys._NoAuth);
        }

        protected override void ExcuteSelf()
        {
            DalInstance.AccountDalInstance.ResetPassword(_LoginName,
                                                         SecurityUtil.SymmetricEncrypt(Account.DefaultPassword,
                                                                                       _LoginName));
        }
    }
}
