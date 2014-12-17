using System;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.SqlServerDal
{
    public class MailAccountDal:IMailAccount
    {
        //数据库事务
        private SqlConnection _Conn;
        private SqlTransaction _Trans;
        private const string _ErrorNullObject = "待操作的对象是空的";
        //读入参数
        private const string _EmployeeID = "@EmployeeID";
        private const string _PKID = "@PKID";
        private const string _LoginName = "@LoginName";
        private const string _Password = "@Password";
        private const string _ConfigurationId = "@ConfigurationId";
        //读出参数
        private const string _DBPKID = "PKID";
        private const string _DBLoginName = "LoginName";
        private const string _DBPassword = "Password";
        private const string _DBConfigurationId = "ConfigurationId";

        #region IMailAccount 成员

        public void SaveMailAccountsFor(Employee theEmployee)
        {
            CheckTheObject(theEmployee);

            InitializeTranscation();
            try
            {
                ClearEmployeeMailAccount(theEmployee);
                InsertEveryMailAccountFor(theEmployee);

                _Trans.Commit();
            }
            catch
            {
                _Trans.Rollback();
                throw new ApplicationException(EmployeeDal._DBError);
            }
            finally
            {
                _Conn.Close();
            }
        }


        public void LoadMailAccountsFor(Employee theEmployee)
        {
            CheckTheObject(theEmployee);

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_EmployeeID, SqlDbType.Int).Value = theEmployee.Account.Id;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeMailAccount", cmd))
            {
                while (sdr.Read())
                {
                    MailAccount mailAccount = new MailAccount(sdr[_DBLoginName].ToString(),
                                                              DalUtility.DecryptPassword(sdr[_DBPassword].ToString(),sdr[_DBLoginName].ToString()),
                                                              MailConfiguration.GetMailConfigurationById(int.Parse(sdr[_DBConfigurationId].ToString())));
                    mailAccount.Id = int.Parse(sdr[_DBPKID].ToString());
                    theEmployee.TheMailAccounts.Add(mailAccount);
                }
            }
        }

        #endregion

        #region private method

        private void InsertEveryMailAccountFor(Employee theEmployee)
        {
            foreach (MailAccount ma in theEmployee.TheMailAccounts)
            {
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd1.Parameters.Add(_EmployeeID, SqlDbType.Int).Value = theEmployee.Account.Id;
                cmd1.Parameters.Add(_LoginName, SqlDbType.NVarChar, 255).Value = ma.LoginName;
                cmd1.Parameters.Add(_Password, SqlDbType.NVarChar, 255).Value =
                    DalUtility.EncryptThePassword(ma.Password, ma.LoginName);
                cmd1.Parameters.Add(_ConfigurationId, SqlDbType.Int, 255).Value = ma.TheMailConfiguration.Id;
                
                int pkidOut;
                SqlHelper.TransExecuteNonQueryReturnPKID("InsertAMailAccount", cmd1, _Conn, _Trans, out pkidOut);
                ma.Id = pkidOut;
            }
        }

        private void ClearEmployeeMailAccount(Employee theEmployee)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_EmployeeID, SqlDbType.Int).Value = theEmployee.Account.Id;
            SqlHelper.TransExecuteNonQuery("DeleteEmployeeMailAccount", cmd, _Conn, _Trans);
        }

        private void InitializeTranscation()
        {
            _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        private static void CheckTheObject(Employee theEmployee)
        {
            if (theEmployee == null)
            {
                throw new ApplicationException(_ErrorNullObject);
            }
        }
        
        #endregion
    }
}