using System.Collections.Generic;

using SEP.Model.Accounts;

namespace SEP.IBllTest
{
    internal static class ValidateTools
    {
       public static bool ContainsAccount(List<Account> objs, Account obj)
        {
            foreach (Account item in objs)
            {
                if (item.Id == obj.Id)
                    return true;
            }

            return false;
        }
    }
}
