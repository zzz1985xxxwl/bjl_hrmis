using System;
using System.Collections.Generic;
using SEP.IDal;
using SEP.IDal.Accounts;
using SEP.Model.Accounts;

namespace SEP.Bll.Accounts
{
    public class CreateAccountGroup: Transaction
    {
        readonly IAccountGroupDal IAccountGroupDal = DalInstance.AccountGroupDalInstance;
        private readonly AccountGroup _AccountGroup;
        private readonly string _AccountMember;
        public CreateAccountGroup(AccountGroup AccountGroup, string accountMember)
        {
            _AccountGroup = AccountGroup;
            _AccountMember = accountMember;

            _AccountMember = _AccountMember.Replace(" ", "");
            _AccountMember = _AccountMember.Replace("　", "");
            _AccountMember = _AccountMember.Replace('（', '(');
            _AccountMember = _AccountMember.Replace('）', ')');
            _AccountMember = _AccountMember.Replace('；', ';');
        }
        protected override void Validation()
        {
            if (IAccountGroupDal.GetAccountGroupByName(_AccountGroup.GroupName) != null)
            {
                throw new Exception("已有相同命名的组");
            }
        }

        protected override void ExcuteSelf()
        {
            _AccountGroup.AccountList = new List<Account>();
            IAccountDal IAccountDal = DalInstance.AccountDalInstance;
            foreach (string s in _AccountMember.Split(';'))
            {
                Account account = IAccountDal.GetAccountByName(s);
                if (account != null)
                {
                    _AccountGroup.AccountList.Add(account);
                }
            }
            DalInstance.AccountGroupDalInstance.Add(_AccountGroup);
        }
    }
}
