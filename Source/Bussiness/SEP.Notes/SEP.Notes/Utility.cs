//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: Utility.cs
// Creater:  Xue.wenlong
// Date:  2010-04-08
// Resume:
// ----------------------------------------------------------------

using System.Web;
using SEP.Model.Accounts;

namespace SEP.Notes
{
    /// <summary>
    /// </summary>
    public class Utility
    {
        public static Account LoginUser
        {
            get
            {
                return HttpContext.Current.Session["LoginInfo"] as Account;
            }
        }


    }
}