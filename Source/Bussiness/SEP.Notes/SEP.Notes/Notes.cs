//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: Notes.cs
// Creater:  Xue.wenlong
// Date:  2010-04-08
// Resume:
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Notes.RepeatTypes;

namespace SEP.Notes
{
    /// <summary>
    /// </summary>
    public class Notes
    {
        private int _PKID;
        private DateTime _Start;
        private DateTime _End;
        private string _Content;
        private Share _Share;
        private Account _Owner;
        private IRepeat _RepeatType;

        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        public Share ShareSet
        {
            get { return _Share; }
            set { _Share = value; }
        }

        public DateTime Start
        {
            get { return _Start; }
            set { _Start = value; }
        }

        public DateTime End
        {
            get { return _End; }
            set { _End = value; }
        }

        public Account Owner
        {
            get
            {
                if(_Owner==null)
                {
                    _Owner = Utility.LoginUser;
                }
                return _Owner;
            }
            set { _Owner = value; }
        }

        private bool _IsMine;

        public bool IsMine
        {
            get { return _IsMine; }
            set { _IsMine = value; }
        }

        public bool FindMine;
        public IRepeat RepeatType
        {
            get { return _RepeatType; }
            set { _RepeatType = value; }
        }

        public static Notes GetByID(int pkid)
        {
            return SqlGetByID(pkid);
        }
        public void Valide()
        {
            if (End < Start)
            {
                throw new ApplicationException("开始时间大于结束时间");
            }
            if(string.IsNullOrEmpty(Content))
            {
                throw new ApplicationException("内容为空");
            }
            RepeatType.Valide();
        }

        public void Save()
        {
            Valide();
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlSave();
                if (ShareSet != null)
                {
                    ShareSet.Save();
                }
                ts.Complete();
            }
        }

        public void Delete()
        {
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlDelete();
                if (ShareSet != null)
                {
                    ShareSet.Delete();
                }
                ts.Complete();
            }
        }

        public void Update()
        {
            Valide();
            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlUpdate();
                if (ShareSet != null)
                {
                    ShareSet.Update();
                }
                ts.Complete();
            }
        }

        public static List<Notes> GetNotesByDate(DateTime start, DateTime end, int accountid)
        {
            return SqlGetNotesByDate(start, end, accountid);
        }

        #region sql

        private static Notes SqlGetByID(int pkid)
        {
            Notes notes = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(Params.PKID, SqlDbType.Int).Value = pkid;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetNoteByID", cmd))
            {
                while (sdr.Read())
                {
                    notes = new Notes();
                    notes.ShareSet = Share.GetShare(pkid);
                    notes.PKID = pkid;
                    notes.Content = sdr[Params.DBContent].ToString();
                    notes.End = Convert.ToDateTime(sdr[Params.DBEnd]);
                    notes.Start = Convert.ToDateTime(sdr[Params.DBStart]);
                    notes.Owner =
                        BllInstance.AccountBllInstance.GetAccountById(Convert.ToInt32(sdr[Params.DBAccountID]));
                    notes.RepeatType = RepeatUtility.GetRepeatType(Convert.ToInt32(sdr[Params.DBType])).SqlGetByID(sdr);
                }
            }
            return notes;
        }

        private static List<Notes> SqlGetNotesByDate(DateTime start, DateTime end, int accountid)
        {
            List<Notes> notesList = new List<Notes>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(Params.Start, SqlDbType.DateTime).Value = start;
            cmd.Parameters.Add(Params.End, SqlDbType.DateTime).Value = end;
            cmd.Parameters.Add(Params.AccountID, SqlDbType.Int).Value = accountid;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetNotesByDate", cmd))
            {
                while (sdr.Read())
                {
                    Notes notes = new Notes();
                    notes.PKID = Convert.ToInt32(sdr[Params.DBPKID]);
                    notes.Content = sdr[Params.DBContent].ToString();
                    notes.End = Convert.ToDateTime(sdr[Params.DBEnd]);
                    notes.Start = Convert.ToDateTime(sdr[Params.DBStart]);
                    notes.Owner =
                        BllInstance.AccountBllInstance.GetAccountById(Convert.ToInt32(sdr[Params.DBAccountID]));
                    notes.RepeatType = RepeatUtility.GetRepeatType(Convert.ToInt32(sdr[Params.DBType])).SqlGetByID(sdr);
                    notes.IsMine = notes.Owner.Id==accountid;
                    notes.FindMine = accountid == Utility.LoginUser.Id;
                    notesList.Add(notes);

                }
            }
            return notesList;
        }

        private void SqlSave()
        {
            int pkid;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(Params.PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(Params.Content, SqlDbType.NVarChar, 2000).Value = Content;
            cmd.Parameters.Add(Params.Type, SqlDbType.Int).Value = RepeatUtility.GetTypeIndex(RepeatType);
            cmd.Parameters.Add(Params.Start, SqlDbType.DateTime).Value = Start;
            cmd.Parameters.Add(Params.End, SqlDbType.DateTime).Value = End;
            cmd.Parameters.Add(Params.AccountID, SqlDbType.Int).Value = Owner.Id;
            RepeatType.SqlSave(cmd);
            SqlHelper.ExecuteNonQueryReturnPKID("NotesInsert", cmd, out pkid);
            _PKID = pkid;
            if (ShareSet != null)
            {
                ShareSet.NoteID = pkid;
            }
        }

        private void SqlUpdate()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(Params.PKID, SqlDbType.Int).Value = PKID;
            cmd.Parameters.Add(Params.Content, SqlDbType.NVarChar, 2000).Value = Content;
            cmd.Parameters.Add(Params.Type, SqlDbType.Int).Value = RepeatUtility.GetTypeIndex(RepeatType);
            cmd.Parameters.Add(Params.Start, SqlDbType.DateTime).Value = Start;
            cmd.Parameters.Add(Params.End, SqlDbType.DateTime).Value = End;
            RepeatType.SqlUpdate(cmd);
            SqlHelper.ExecuteNonQuery("NotesUpdate", cmd);
        }

        private void SqlDelete()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(Params.PKID, SqlDbType.Int).Value = PKID;
            SqlHelper.ExecuteNonQuery("NotesDelete", cmd);
        }

        #endregion
    }
}