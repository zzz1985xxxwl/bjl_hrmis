//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: Share.cs
// Creater:  Xue.wenlong
// Date:  2010-04-08
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.Model.Accounts;

namespace SEP.Notes
{
    /// <summary>
    /// </summary>
    public class Share
    {
        private List<Account> _Accounts;
        private int _NoteID;

        public List<Account> Accounts
        {
            get { return _Accounts; }
            set { _Accounts = value; }
        }

        public int NoteID
        {
            get { return _NoteID; }
            set { _NoteID = value; }
        }


        public string toAccountString()
        {
            StringBuilder builder = new StringBuilder();
            if (_Accounts != null&&_Accounts.Count>0)
            {
                foreach (Account account in _Accounts)
                {
                    builder.AppendFormat("{0};", account.Name);
                }
                builder.Remove(builder.Length-1, 1);
            }


            return builder.ToString();
        }

        public static List<Account> toAccountList(string s)
        {
            List<Account> accounts = new List<Account>();
            if(!string.IsNullOrEmpty(s))
            {
                s.Replace(":", ";");
                s.Replace("£»", ";");
                s.Replace("£º", ";");
                string[] names = s.Split(';');
                if (names.Length > 0)
                {
                    IAccountBll accountBll = BllInstance.AccountBllInstance;
                    List<string> temp = new List<string>();
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (!temp.Contains(names[i]))
                        {
                            temp.Add(names[i]);
                        }
                    }
                    foreach (string name in temp)
                    {
                        Account account = accountBll.GetAccountByName(name);
                        if (account == null)
                        {
                            throw new ApplicationException(string.Format("{0}²»´æÔÚ", name));
                        }
                        if (account.Id != Utility.LoginUser.Id)
                        {
                            accounts.Add(account);
                        }
                    }
                }
            }
            return accounts;
        }

        public static Share GetShare(int pkid)
        {
            return SqlGetShare(pkid);
        }

        public void Save()
        {
            SqlSave();
        }

        public void Update()
        {
            if (SqlGetShare(NoteID).toAccountString() != toAccountString())
            {
                SqlDelete();
                SqlSave();
            }
        }

        public void Delete()
        {
            SqlDelete();
        }

        public static void Quite(int noteID)
        {
            SqlQuite(Utility.LoginUser.Id,noteID);
        }

        #region Dal

        private void SqlDelete()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(Params.NoteID, SqlDbType.Int).Value = NoteID;
            SqlHelper.ExecuteNonQuery("ShareDelete", cmd);
        }

        private void SqlSave()
        {
            foreach (Account account in _Accounts)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(Params.PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(Params.NoteID, SqlDbType.Int).Value = NoteID;
                cmd.Parameters.Add(Params.AccountID, SqlDbType.Int).Value = account.Id;
                int pkid;
                SqlHelper.ExecuteNonQueryReturnPKID("ShareInsert", cmd, out pkid);
            }
        }

        private static void SqlQuite(int accountid,int noteID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(Params.NoteID, SqlDbType.Int).Value = noteID;
            cmd.Parameters.Add(Params.AccountID, SqlDbType.Int).Value = accountid;
            SqlHelper.ExecuteNonQuery("QuitShare", cmd);
        }

        private static Share SqlGetShare(int pkid)
        {
            Share share = new Share();
            share.NoteID = pkid;
            share.Accounts = new List<Account>();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(Params.NoteID, SqlDbType.Int).Value = pkid;
            IAccountBll accountBll = BllInstance.AccountBllInstance;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetShare", cmd))
            {
                while (sdr.Read())
                {
                    share.Accounts.Add(accountBll.GetAccountById(Convert.ToInt32(sdr[Params.DBAccountID])));
                }
            }
            return share;
        }

        #endregion

    }
}