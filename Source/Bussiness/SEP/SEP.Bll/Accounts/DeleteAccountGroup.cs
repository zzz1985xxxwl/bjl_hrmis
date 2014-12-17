using System;
using SEP.IDal;
using SEP.Model;

namespace SEP.Bll.Accounts
{
    public class DeleteAccountGroup : Transaction
    {
        private readonly int _PKID;
        public DeleteAccountGroup(int pkid)
        {
            _PKID = pkid;
        }

        protected override void Validation()
        {
            
        }

        protected override void ExcuteSelf()
        {
            try
            {
                DalInstance.AccountGroupDalInstance.Delete(_PKID);
            }
            catch(Exception ex)
            {
                throw MessageKeys.AppException(ex.Message);
            }
        }
    }
}
