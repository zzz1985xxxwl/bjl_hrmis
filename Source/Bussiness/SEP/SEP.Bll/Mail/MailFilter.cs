//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: MailFilter.cs
// Creater:  Xue.wenlong
// Date:  2009-03-20
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using SEP.IDal;
using SEP.IDal.Accounts;
using SEP.Model.Accounts;

namespace SEP.Bll.Mail
{
    public class MailFilter
    {
        private static readonly IAccountDal _AccountDal = DalInstance.AccountDalInstance;
        //存放需要过滤的Mail的Cache,处于该mail的地址都不会发送
        private List<string> _NeedIgnoreAddress = new List<string>();

        public MailFilter()
        {
            NeedIgnoreAddress();
        }

        private  void  NeedIgnoreAddress()
        {
            _NeedIgnoreAddress = new List<string>();
            List<Account> visibleTypeNone = _AccountDal.GetAllAccount();
            foreach (Account account in visibleTypeNone)
            {
                if (account.AccountType == VisibleType.None||!account.IsAcceptEmail)
                {
                    if (!string.IsNullOrEmpty(account.Email1))
                    {
                        _NeedIgnoreAddress.Add(account.Email1);
                    }
                    if (!string.IsNullOrEmpty(account.Email2))
                    {
                        _NeedIgnoreAddress.Add(account.Email2);
                    }
                }
            }
        }

        public bool IsInBlackList(string theAddress)
        {
            foreach (string ma in _NeedIgnoreAddress)
            {
                if (ma.Equals(theAddress))
                {
                    return true;
                }
            }
            return false;
        }
    }
}