using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// IAccountAuthFacade½Ó¿Ú
    /// </summary>
    public interface IAccountAuthFacade
    {
        List<Auth> GetAccountAllAuthList(int accountId, Account loginUser);

        List<Auth> GetAccountAllAuth(int accountId, Account loginUser);

        void SetAccountAuths(List<Auth> newAuths, Account user, Account loginUser);
    }
}
