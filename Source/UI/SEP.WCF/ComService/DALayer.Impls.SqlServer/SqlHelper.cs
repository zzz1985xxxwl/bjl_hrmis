using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ComService.DALayer.Impls.SqlServer
{
    public static class SqlHelper
    {
        public static string ConnectionStringProfile = ConfigurationManager.AppSettings["ConnectionString"];

        public static int ExecuteNonQuery(string procName, SqlCommand cmd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringProfile))
                {
                    PrepareProcedureCommand(procName, cmd, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    int iRet = (int)cmd.Parameters["@ReturnValue"].Value;
                    cmd.Parameters.Clear();
                    return iRet;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static SqlDataReader ExecuteReader(string procName, SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(ConnectionStringProfile);
            PrepareProcedureCommand(procName, cmd, conn);
            try
            {
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                
                return rdr;
            }
            catch(Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }

        /// <summary>
        /// ����ִ��SqlCommand����
        /// </summary>
        /// <param name="cmd">��Ҫ��װCmd�Ĳ���������</param>
        public static int ExecuteNonQuery(SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionStringProfile))
            {
                cmd.Connection = conn;
                conn.Open();
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// ����ִ��SqlCommand�����Ҫ����Reader
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(ConnectionStringProfile);
            cmd.Connection = conn;
            conn.Open();
            try
            {
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// ����ִ�����ݿ�transcation,��Ҫ����ص�connection����
        /// </summary>
        public static int TransExecuteNonQuery(string procName, SqlCommand cmd, SqlConnection conn, SqlTransaction trans)
        {
            PrepareTransSqlCommand(procName, cmd, conn, trans);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }



        private static void PrepareTransSqlCommand(string procName, SqlCommand cmd, SqlConnection conn, SqlTransaction trans)
        {
            cmd.Transaction = trans;
            cmd.Connection = conn;
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
        }

        private static void PrepareProcedureCommand(string procName, SqlCommand cmd, SqlConnection conn)
        {
            cmd.Connection = conn;
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
        }
    }
}
