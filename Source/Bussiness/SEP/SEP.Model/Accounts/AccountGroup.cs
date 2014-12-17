using System.Collections.Generic;

namespace SEP.Model.Accounts
{
    public class AccountGroup
    {
        private int _PKID;
        public int PKID
        {
            set { _PKID = value; }
            get { return _PKID; }
           
        }
        private string _GroupName;
        public string GroupName
        {
            set { _GroupName = value; }
            get { return _GroupName; }
        }
        private List<Account> _AccountList;
        public List<Account> AccountList
        {
            set { _AccountList = value; }
            get { return _AccountList; }
        }
    }
}