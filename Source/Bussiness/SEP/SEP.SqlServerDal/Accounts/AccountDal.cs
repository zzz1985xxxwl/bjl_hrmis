//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: IGoalDal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 账号持久层实现
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Framework.Common;
using SEP.IDal.Accounts;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;

namespace SEP.SqlServerDal
{
    /// <summary>
    /// 账号持久层实现
    /// </summary>
    public class AccountDal : IAccountDal
    {
        #region
        private const string _AccountId = "@PKID";
        private const string _LoginName = "@LoginName";
        private const string _Password = "@Password";
        private const string _UsbKey = "@UsbKey";
        private const string _AccountType = "@AccountType";
        private const string _EmployeeName = "@EmployeeName";
        private const string _Email1 = "@Email1";
        private const string _Email2 = "@Email2";
        private const string _MobileNum = "@MobileNum";
        private const string _IsAcceptEmail = "@IsAcceptEmail";
        private const string _IsAcceptSMS = "@IsAcceptSMS";
        private const string _IsValidateUsbKey = "@IsValidateUsbKey";
        private const string _DepartmentId = "@DepartmentId";
        private const string _PositionId = "@PositionId";
        private const string _AccountID = "@AccountID";
        private const string _Picture = "@Picture";
        private const string _PositionDescription = "@PositionDescription";
        private const string _GradesID = "@GradesID";

        private const string _DbAccountId = "PKID";
        private const string _DbLoginName = "LoginName";
        private const string _DbPassword = "Password";
        private const string _DbUsbKey = "UsbKey";
        private const string _DbAccountType = "AccountType";
        private const string _DbEmployeeName = "EmployeeName";
        private const string _DbEmail1 = "Email1";
        private const string _DbEmail2 = "Email2";
        private const string _DbMobileNum = "MobileNum";
        private const string _DbIsAcceptEmail = "IsAcceptEmail";
        private const string _DbIsAcceptSMS = "IsAcceptSMS";
        private const string _DbIsValidateUsbKey = "IsValidateUsbKey";
        private const string _DbDepartmentId = "DepartmentId";
        private const string _DbPositionId = "PositionId";
        private const string _DbDepartmentName = "DepartmentName";
        private const string _DbPositionName = "PositionName";
        private const string _DbAccountID = "AccountID";
        private const string _DbPicture = "Picture";
        private const string _DbPositionDescription = "PositionDescription";
        private const string _DbGradesID = "GradesID";
        private const string _DbMainDuties = "MainDuties";
        #endregion

        private Account CreateAccountFromDB(IDataRecord dr)
        {
            Account account = null;

            if (dr == null)
                return account;

            if (dr[_DbAccountId] == DBNull.Value)
                return account;

            account = new Account();

            account.Id = Convert.ToInt32(dr[_DbAccountId]);
            account.LoginName = dr[_DbLoginName].ToString();
            account.Password = dr[_DbPassword].ToString();

            if (dr[_DbUsbKey] != DBNull.Value)
                account.UsbKey = dr[_DbUsbKey].ToString();

            account.AccountType = (VisibleType)Convert.ToInt32(dr[_DbAccountType]);
            account.Name = dr[_DbEmployeeName].ToString();

            if (dr[_DbEmail1] != DBNull.Value)
                account.Email1 = dr[_DbEmail1].ToString();

            if (dr[_DbEmail2] != DBNull.Value)
                account.Email2 = dr[_DbEmail2].ToString();

            if (dr[_DbMobileNum] != DBNull.Value)
                account.MobileNum = dr[_DbMobileNum].ToString();

            account.IsAcceptEmail = Convert.ToBoolean(dr[_DbIsAcceptEmail]);
            account.IsAcceptSMS = Convert.ToBoolean(dr[_DbIsAcceptSMS]);
            account.IsValidateUsbKey = Convert.ToBoolean(dr[_DbIsValidateUsbKey]);
            if (dr[_DbGradesID] != DBNull.Value)
            {
                account.GradesID = Convert.ToInt32(dr[_DbGradesID]);
            }
            if (dr[_DbDepartmentId] != DBNull.Value)
            {
                account.Dept = new Department(Convert.ToInt32(dr[_DbDepartmentId]), dr[_DbDepartmentName].ToString());
            }

            if (dr[_DbPositionId] != DBNull.Value)
            {
                account.Position = new Position();
                account.Position.Id = Convert.ToInt32(dr[_DbPositionId]);
                account.Position.Name = dr[_DbPositionName].ToString();
                account.Position.Description = dr[_DbPositionDescription].ToString();
                account.Position.MainDuties = dr[_DbMainDuties].ToString();
            }
            return account;
        }

        #region IAccountDal 成员
        /// <summary>
        /// 根据登录名获取账号信息
        /// </summary>
        public Account GetAccountInfo(string loginName)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_LoginName, SqlDbType.NVarChar, 50).Value = loginName;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccount", cmd))
            {
                while (sdr.Read())
                {
                    return CreateAccountFromDB(sdr);
                }
            }
            return null;
        }

        public void CreateAccount(Account account)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.Parameters.Add(_LoginName, SqlDbType.NVarChar, 50).Value = account.LoginName;
            cmd.Parameters.Add(_Password, SqlDbType.NVarChar, 2000).Value = account.Password;
            cmd.Parameters.Add(_UsbKey, SqlDbType.NVarChar, 2000).Value = account.UsbKey;
            cmd.Parameters.Add(_AccountType, SqlDbType.Int).Value = account.AccountType;
            cmd.Parameters.Add(_EmployeeName, SqlDbType.NVarChar, 50).Value = account.Name;
            cmd.Parameters.Add(_Email1, SqlDbType.NVarChar, 255).Value = account.Email1;
            cmd.Parameters.Add(_Email2, SqlDbType.NVarChar, 255).Value = account.Email2;
            cmd.Parameters.Add(_MobileNum, SqlDbType.NVarChar, 50).Value = account.MobileNum;
            cmd.Parameters.Add(_IsAcceptEmail, SqlDbType.Int).Value = account.IsAcceptEmail;
            cmd.Parameters.Add(_IsAcceptSMS, SqlDbType.Int).Value = account.IsAcceptSMS;
            cmd.Parameters.Add(_IsValidateUsbKey, SqlDbType.Int).Value = account.IsValidateUsbKey;

            if (account.Dept != null)
                cmd.Parameters.Add(_DepartmentId, SqlDbType.Int).Value = account.Dept.Id;

            if (account.Position != null)
                cmd.Parameters.Add(_PositionId, SqlDbType.Int).Value = account.Position.Id;

            if (account.GradesID != null)
                cmd.Parameters.Add(_GradesID, SqlDbType.Int).Value = account.GradesID;
            int pkid;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertAccount", cmd, out pkid);
            account.Id = pkid;
        }

        public bool ValidationLoginName(string loginName)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_LoginName, SqlDbType.NVarChar, 50).Value = loginName;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("ValidationName", cmd))
            {
                return sdr.HasRows;
            }
        }

        public bool ValidationLoginName(int accountId, string loginName)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Value = accountId;
            cmd.Parameters.Add(_LoginName, SqlDbType.NVarChar, 50).Value = loginName;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("ValidationName", cmd))
            {
                return sdr.HasRows;
            }
        }

        public bool ValidationName(string name)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_EmployeeName, SqlDbType.NVarChar, 50).Value = name;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("ValidationName", cmd))
            {
                return sdr.HasRows;
            }
        }

        public bool ValidationName(int accountId, string name)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Value = accountId;
            cmd.Parameters.Add(_EmployeeName, SqlDbType.NVarChar, 50).Value = name;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("ValidationName", cmd))
            {
                return sdr.HasRows;
            }
        }

        public void UpdateAccount(Account account)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Value = account.Id;
            cmd.Parameters.Add(_LoginName, SqlDbType.NVarChar, 50).Value = account.LoginName;
            //cmd.Parameters.Add(_Password, SqlDbType.NVarChar, 2000).Value = account.Password;
            //cmd.Parameters.Add(_UsbKey, SqlDbType.NVarChar, 2000).Value = account.UsbKey;
            cmd.Parameters.Add(_AccountType, SqlDbType.Int).Value = account.AccountType;
            cmd.Parameters.Add(_EmployeeName, SqlDbType.NVarChar, 50).Value = account.Name;
            cmd.Parameters.Add(_Email1, SqlDbType.NVarChar, 255).Value = account.Email1;
            cmd.Parameters.Add(_Email2, SqlDbType.NVarChar, 255).Value = account.Email2;
            cmd.Parameters.Add(_MobileNum, SqlDbType.NVarChar, 50).Value = account.MobileNum;
            cmd.Parameters.Add(_IsAcceptEmail, SqlDbType.Int).Value = account.IsAcceptEmail;
            cmd.Parameters.Add(_IsAcceptSMS, SqlDbType.Int).Value = account.IsAcceptSMS;
            cmd.Parameters.Add(_IsValidateUsbKey, SqlDbType.Int).Value = account.IsValidateUsbKey;

            if (account.Dept != null)
                cmd.Parameters.Add(_DepartmentId, SqlDbType.Int).Value = account.Dept.Id;

            if (account.Position != null)
                cmd.Parameters.Add(_PositionId, SqlDbType.Int).Value = account.Position.Id;

            if (account.GradesID != null)
                cmd.Parameters.Add(_GradesID, SqlDbType.Int).Value = account.GradesID;

            SqlHelper.ExecuteNonQuery("UpdateAccount", cmd);
        }

        public void DeleteAccount(int accountId)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Value = accountId;
            cmd.Parameters.Add(_AccountType, SqlDbType.Int).Value = VisibleType.None;

            SqlHelper.ExecuteNonQuery("DeleteAccount", cmd);
        }

        public void ChangeAccountType(int accountId, VisibleType visibleType)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Value = accountId;
            cmd.Parameters.Add(_AccountType, SqlDbType.Int).Value = visibleType;

            SqlHelper.ExecuteNonQuery("DeleteAccount", cmd);
        }

        public void ChangePassword(string loginName, string newPassword)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_LoginName, SqlDbType.NVarChar, 50).Value = loginName;
            cmd.Parameters.Add(_Password, SqlDbType.NVarChar, 2000).Value = newPassword;

            SqlHelper.ExecuteNonQuery("ChangePassword", cmd);
        }

        public void ResetPassword(string loginName, string defaultPassword)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_LoginName, SqlDbType.NVarChar, 50).Value = loginName;
            cmd.Parameters.Add(_Password, SqlDbType.NVarChar, 2000).Value = defaultPassword;
            cmd.Parameters.Add(_IsValidateUsbKey, SqlDbType.Int).Value = false;

            SqlHelper.ExecuteNonQuery("ResetPassword", cmd);
        }

        public void SetUsbKey(string loginName, string usbKey)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_LoginName, SqlDbType.NVarChar, 50).Value = loginName;
            cmd.Parameters.Add(_UsbKey, SqlDbType.NVarChar, 2000).Value = usbKey;

            SqlHelper.ExecuteNonQuery("ChangeUsbKey", cmd);
        }

        public Account GetAccountById(int accountId)
        {
            Account account = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Value = accountId;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccount", cmd))
            {
                while (sdr.Read())
                {
                    account = CreateAccountFromDB(sdr);
                }
            }
            return account;
        }

        public Account GetAccountByName(string name)
        {
            Account accountEntity = null;
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_EmployeeName, SqlDbType.NVarChar, 50).Value = name;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("ValidationName", cmd))
            {
                while (sdr.Read())
                {
                    accountEntity = new Account();
                    accountEntity.Id = Convert.ToInt32(sdr[_DbAccountId]);
                    accountEntity.LoginName = sdr[_DbLoginName].ToString();
                    accountEntity.Password = sdr[_DbPassword].ToString();

                    if (sdr[_DbUsbKey] != DBNull.Value)
                        accountEntity.UsbKey = sdr[_DbUsbKey].ToString();

                    accountEntity.AccountType = (VisibleType)Convert.ToInt32(sdr[_DbAccountType]);
                    accountEntity.Name = sdr[_DbEmployeeName].ToString();

                    if (sdr[_DbEmail1] != DBNull.Value)
                        accountEntity.Email1 = sdr[_DbEmail1].ToString();

                    if (sdr[_DbEmail2] != DBNull.Value)
                        accountEntity.Email2 = sdr[_DbEmail2].ToString();

                    if (sdr[_DbMobileNum] != DBNull.Value)
                        accountEntity.MobileNum = sdr[_DbMobileNum].ToString();

                    if (sdr[_DbGradesID] != DBNull.Value)
                    {
                        accountEntity.GradesID = Convert.ToInt32(sdr[_DbGradesID]);
                    }
                    accountEntity.IsAcceptEmail = Convert.ToBoolean(sdr[_DbIsAcceptEmail]);
                    accountEntity.IsAcceptSMS = Convert.ToBoolean(sdr[_DbIsAcceptSMS]);
                    accountEntity.IsValidateUsbKey = Convert.ToBoolean(sdr[_DbIsValidateUsbKey]);

                }
            }
            return accountEntity;
        }

        public Account GetAccountByMobileNum(string mobileNum)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_MobileNum, SqlDbType.NVarChar).Value = mobileNum;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("ValidationName", cmd))
            {
                while (sdr.Read())
                {
                    Account account = new Account();
                    account.Id = Convert.ToInt32(sdr[_DbAccountId]);
                    account.LoginName = sdr[_DbLoginName].ToString();
                    account.Password = sdr[_DbPassword].ToString();

                    if (sdr[_DbUsbKey] != DBNull.Value)
                        account.UsbKey = sdr[_DbUsbKey].ToString();

                    account.AccountType = (VisibleType)Convert.ToInt32(sdr[_DbAccountType]);
                    account.Name = sdr[_DbEmployeeName].ToString();

                    if (sdr[_DbEmail1] != DBNull.Value)
                        account.Email1 = sdr[_DbEmail1].ToString();

                    if (sdr[_DbEmail2] != DBNull.Value)
                        account.Email2 = sdr[_DbEmail2].ToString();

                    if (sdr[_DbMobileNum] != DBNull.Value)
                        account.MobileNum = sdr[_DbMobileNum].ToString();
                    if (sdr[_DbGradesID] != DBNull.Value)
                    {
                        account.GradesID = Convert.ToInt32(sdr[_DbGradesID]);
                    }
                    account.IsAcceptEmail = Convert.ToBoolean(sdr[_DbIsAcceptEmail]);
                    account.IsAcceptSMS = Convert.ToBoolean(sdr[_DbIsAcceptSMS]);
                    account.IsValidateUsbKey = Convert.ToBoolean(sdr[_DbIsValidateUsbKey]);

                    return account;
                }
            }
            return null;
        }

        public List<Account> GetAllAccount()
        {
            List<Account> accounts = new List<Account>();

            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccount", cmd))
            {
                while (sdr.Read())
                {
                    if (Convert.ToInt32(sdr[_DbAccountId]) == Account.AdminPkid)
                        continue;

                    Account temp = CreateAccountFromDB(sdr);
                    if (temp != null)
                        accounts.Add(temp);
                }
            }
            return accounts;
        }

        public List<Account> GetAllValidAccount()
        {
            List<Account> accounts = new List<Account>();

            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccount", cmd))
            {
                while (sdr.Read())
                {
                    if (Convert.ToInt32(sdr[_DbAccountId]) == Account.AdminPkid)
                        continue;

                    if (Convert.ToInt32(sdr[_DbAccountType]) == (int)VisibleType.None)
                        continue;

                    Account temp = CreateAccountFromDB(sdr);
                    if (temp != null)
                        accounts.Add(temp);
                }
            }
            return accounts;
        }

        public List<Account> GetAllHRMisAccount()
        {
            List<Account> accounts = new List<Account>();

            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccount", cmd))
            {
                while (sdr.Read())
                {
                    if (Convert.ToInt32(sdr[_DbAccountId]) == Account.AdminPkid)
                        continue;

                    Account temp = CreateAccountFromDB(sdr);
                    if (temp != null && temp.IsHRAccount)
                        accounts.Add(temp);
                }
            }
            return accounts;
        }

        public List<Account> GetAllCRMAccount()
        {
            List<Account> accounts = new List<Account>();

            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccount", cmd))
            {
                while (sdr.Read())
                {
                    if (Convert.ToInt32(sdr[_DbAccountId]) == Account.AdminPkid)
                        continue;

                    Account temp = CreateAccountFromDB(sdr);
                    if (temp != null && temp.IsCRMAccount)
                        accounts.Add(temp);
                }
            }
            return accounts;
        }

        public List<Account> GetAllMyCMMIAccount()
        {
            List<Account> accounts = new List<Account>();

            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccount", cmd))
            {
                while (sdr.Read())
                {
                    if (Convert.ToInt32(sdr[_DbAccountId]) == Account.AdminPkid)
                        continue;

                    Account temp = CreateAccountFromDB(sdr);
                    if (temp != null && temp.IsMyCMMIAccount)
                        accounts.Add(temp);
                }
            }
            return accounts;
        }

        public List<Account> GetAllEShoppingAccount()
        {
            List<Account> accounts = new List<Account>();

            SqlCommand cmd = new SqlCommand();

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccount", cmd))
            {
                while (sdr.Read())
                {
                    if (Convert.ToInt32(sdr[_DbAccountId]) == Account.AdminPkid)
                        continue;

                    Account temp = CreateAccountFromDB(sdr);
                    if (temp != null && temp.IsEShoppingAccount)
                        accounts.Add(temp);
                }
            }
            return accounts;
        }

        public List<Account> GetAccountByCondition(string nameLike, int? deptId, int? positionId, int? gradesId, bool? visible)
        {
            var accountEntities = new List<Account>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_EmployeeName, SqlDbType.NVarChar, 50).Value = nameLike;
            if (deptId.HasValue)
            { cmd.Parameters.Add(_DepartmentId, SqlDbType.Int).Value = deptId.Value; }
            if (positionId.HasValue)
            { cmd.Parameters.Add(_PositionId, SqlDbType.Int).Value = positionId.Value; }
            if (gradesId.HasValue)
            { cmd.Parameters.Add(_GradesID, SqlDbType.Int).Value = gradesId.Value; }
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccount", cmd))
            {
                while (sdr.Read())
                {
                    if (Convert.ToInt32(sdr[_DbAccountId]) == Account.AdminPkid)
                        continue;

                    if (visible.HasValue && visible.Value && Convert.ToInt32(sdr[_DbAccountType]) == (int)VisibleType.None)
                        continue;

                    if (visible.HasValue && !visible.Value && Convert.ToInt32(sdr[_DbAccountType]) != (int)VisibleType.None)
                        continue;

                    Account temp = CreateAccountFromDB(sdr);
                    if (temp != null)
                    {
                        accountEntities.Add(temp);
                    }
                }
            }
            return accountEntities;
        }

        public List<Account> GetAccountByCondition(string nameLike, int? deptId, int? positionId)
        {

            List<Account> accountEntities = new List<Account>();
            accountEntities = new List<Account>();
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_EmployeeName, SqlDbType.NVarChar, 50).Value = nameLike;
            if (deptId.HasValue)
                cmd.Parameters.Add(_DepartmentId, SqlDbType.Int).Value = deptId.Value;
            if (positionId.HasValue)
                cmd.Parameters.Add(_PositionId, SqlDbType.Int).Value = positionId.Value;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetAccount", cmd))
            {
                while (sdr.Read())
                {
                    if (Convert.ToInt32(sdr[_DbAccountId]) == Account.AdminPkid)
                        continue;

                    Account temp = CreateAccountFromDB(sdr);
                    if (temp != null)
                        accountEntities.Add(temp);
                }
            }
            return accountEntities;

        }
        #region 电子签名
        public byte[] GetElectronIdiographByAccountID(int loginUserID)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = loginUserID;

            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetElectronIdiographByAccountID", cmd))
            {
                while (sdr.Read())
                {
                    //string temp = Encoding.BigEndianUnicode.GetString(sdr[_DbPicture] as byte[]);
                    //return Encoding.BigEndianUnicode.GetBytes(temp);
                    return sdr[_DbPicture] as byte[];
                }
            }
            return null;
        }

        public void InsertElectronIdiograph(int loginUserID, byte[] photo)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountId, SqlDbType.Int).Value = ParameterDirection.Output;
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = loginUserID;
            if (photo != null)
            {
                cmd.Parameters.Add(_Picture, SqlDbType.Image).Value = photo;
            }
            else
            {
                cmd.Parameters.Add(_Picture, SqlDbType.Image).Value = DBNull.Value;
            }
            int pkid;
            SqlHelper.ExecuteNonQueryReturnPKID("InsertElectronIdiograph", cmd, out pkid);
        }

        //public void UpdateElectronIdiograph(int loginUserID, byte[] photo)
        //{
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = loginUserID;
        //    if (photo != null)
        //    {
        //        cmd.Parameters.Add(_Picture, SqlDbType.Image).Value = photo;
        //    }
        //    else
        //    {
        //        cmd.Parameters.Add(_Picture, SqlDbType.Image).Value = DBNull.Value;
        //    }
        //    SqlHelper.ExecuteNonQuery("UpdateElectronIdiograph", cmd);
        //}

        public void DeleteElectronIdiographByAccountID(int loginUserID)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = loginUserID;

            SqlHelper.ExecuteNonQuery("DeleteElectronIdiographByAccountID", cmd);
        }
        #endregion
        #endregion
    }
}
