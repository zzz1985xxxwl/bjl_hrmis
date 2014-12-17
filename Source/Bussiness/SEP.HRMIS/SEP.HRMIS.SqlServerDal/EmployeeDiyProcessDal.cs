using System;
using System.Data;
using System.Data.SqlClient;
using SEP.HRMIS.IDal;
//using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.SqlServerDal
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeDiyProcessDal : IEmployeeDiyProcessDal
    {
        #region 自由变量

        private const string _PKID = "@PKID";
        private const string _Type = "@Type";
        private const string _AccountID = "@AccountID";
        private const string _DiyProcessID = "@DiyProcessID";

        private const string _DBDiyProcessID = "DiyProcessID";
        private const string _DBCount = "counts";

        #endregion

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="employee"></param>
        ///// <returns></returns>
        //public int InsertEmployeeDiyProcess(Employee employee)
        //{
        //    SqlConnection _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
        //    _Conn.Open();
        //    SqlTransaction _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
        //    int pkid;
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Parameters.Add(_Type, SqlDbType.Int).Value = employee.DiyProcessList[0].Type.Id;
        //        cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = employee.Account.Id;
        //        SqlHelper.ExecuteNonQuery("DeleteEmployeeDiyProcessByAccountIDAndType", cmd);

        //        cmd = new SqlCommand();
        //        cmd.Parameters.Add(_DiyProcessID, SqlDbType.Int).Value = employee.DiyProcessList[0].ID;
        //        cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = employee.Account.Id;
        //        cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
        //        SqlHelper.ExecuteNonQueryReturnPKID("InsertEmployeeDiyProcess", cmd, out pkid);
               
        //        _Trans.Commit();
        //    }
        //    catch
        //    {
        //        _Trans.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        _Conn.Close();
        //    }

        //    return pkid;
        //}

        ///<summary>
        ///</summary>
        ///<param name="accountID"></param>
        ///<param name="diyProcess"></param>
        ///<returns></returns>
        public int InsertEmployeeDiyProcess(int accountID, DiyProcess diyProcess)
        {
            SqlConnection _Conn = new SqlConnection(SqlHelper._ConnectionStringProfile);
            _Conn.Open();
            SqlTransaction _Trans = _Conn.BeginTransaction(IsolationLevel.ReadUncommitted);
            int pkid;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add(_Type, SqlDbType.Int).Value = diyProcess.Type.Id;
                cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
                SqlHelper.ExecuteNonQuery("DeleteEmployeeDiyProcessByAccountIDAndType", cmd);

                cmd = new SqlCommand();
                cmd.Parameters.Add(_DiyProcessID, SqlDbType.Int).Value = diyProcess.ID;
                cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
                cmd.Parameters.Add(_PKID, SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQueryReturnPKID("InsertEmployeeDiyProcess", cmd, out pkid);

                _Trans.Commit();
            }
            catch
            {
                _Trans.Rollback();
                throw;
            }
            finally
            {
                _Conn.Close();
            }

            return pkid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public int DeleteEmployeeDiyProcessByAccountID(int employeeID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = employeeID;
            return SqlHelper.ExecuteNonQuery("DeleteEmployeeDiyProcessByAccountID", cmd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public DiyProcess GetDiyProcessByProcessTypeAndAccountID(ProcessType type, int accountID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_Type, SqlDbType.Int).Value = type.Id;
            cmd.Parameters.Add(_AccountID, SqlDbType.Int).Value = accountID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("GetEmployeeDiyProcessByEmployeeIDAndTypeID", cmd))
            {
                while (sdr.Read())
                {
                    DiyProcessDal diyProcessDal = new DiyProcessDal();
                    return diyProcessDal.GetDiyProcessByPKID((int)sdr[_DBDiyProcessID]);
                }
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diyProcessID"></param>
        /// <returns></returns>
        public int CountAccountByDiyProcessID(int diyProcessID)
        {
            int retVal = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add(_DiyProcessID, SqlDbType.Int).Value = diyProcessID;
            using (SqlDataReader sdr = SqlHelper.ExecuteReader("CountAccountByDiyProcessID", cmd))
            {
                while (sdr.Read())
                {
                    retVal = Convert.ToInt32(sdr[_DBCount]);
                }
            }
            return retVal;
        }
    }
}
