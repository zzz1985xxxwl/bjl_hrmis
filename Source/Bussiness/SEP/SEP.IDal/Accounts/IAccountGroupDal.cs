using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.IDal.Accounts
{
    public interface IAccountGroupDal
    {
        int Add(AccountGroup model);
        void Update(AccountGroup model);
        void Delete(int PKID);
        AccountGroup GetAccountGroupByPKID(int PKID);
        List<AccountGroup> GetAllAccountGroup();
        AccountGroup GetAccountGroupByName(string name);
        List<AccountGroup> GetAccountGroupByCondition(string name);
    }
}
