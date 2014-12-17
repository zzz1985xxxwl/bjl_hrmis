using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.IBll.Accounts
{
    public interface IAccountGroupBll
    {
        void CreateAccountGroup(AccountGroup accountGroup, string accountMember);
        void UpdateAccountGroup(AccountGroup accountGroup, string accountMember);
        void DeleteAccountGroup(int pkid);
        AccountGroup GetAccountGroupByPKID(int pkid);
        List<AccountGroup> GetAllAccountGroup();
        List<AccountGroup> GetAccountGroupByCondition(string name);
    }
}
