//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: SqlHelper.cs
// ������: �����
// ��������: 2008-05-20
// ����: ���ô洢���̵Ĺ�������
// ----------------------------------------------------------------

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SqlServerDal.MessageDal
{
    public class SqlHelper
    {
        public static string _ConnectionStringProfile = ConfigurationManager.AppSettings["ConnectionString"];

        public static int ExecuteNonQuery(string ProcedureName, SqlCommand salesCommand)
        {
            using (SqlConnection conn = new SqlConnection(_ConnectionStringProfile))
            {
                PrepareProcedureCommand(ProcedureName, salesCommand, conn);
                int iRet = salesCommand.ExecuteNonQuery();
                salesCommand.Parameters.Clear();
                conn.Close();
                return iRet;
            }
        }

        public static int ExecuteNonQueryReturnPKID(string ProcedureName, SqlCommand salesCommand, out int PKID)
        {
            using (SqlConnection conn = new SqlConnection(_ConnectionStringProfile))
            {
                PrepareProcedureCommand(ProcedureName, salesCommand, conn);
                int iRet = salesCommand.ExecuteNonQuery();
                PKID = Convert.ToInt32(salesCommand.Parameters["@PKID"].Value);
                salesCommand.Parameters.Clear();
                conn.Close();
                return iRet;
            }
        }

        public static SqlDataReader ExecuteReader(string ProcedureName, SqlCommand salesCommand)
        {
            SqlConnection conn = new SqlConnection(_ConnectionStringProfile);
            PrepareProcedureCommand(ProcedureName, salesCommand, conn);
            try
            {
                SqlDataReader rdr = salesCommand.ExecuteReader(CommandBehavior.CloseConnection);
                salesCommand.Parameters.Clear();
                return rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
        }

        /// <summary>
        /// ����ִ��SqlCommand����
        /// </summary>
        /// <param name="cmd">��Ҫ��װCmd�Ĳ���������</param>
        public static int ExecuteNonQuery(SqlCommand cmd)
        {
            using (SqlConnection conn = new SqlConnection(_ConnectionStringProfile))
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
            SqlConnection conn = new SqlConnection(_ConnectionStringProfile);
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
        public static int TransExecuteNonQuery(string ProcedureName, SqlCommand cmd, SqlConnection conn, SqlTransaction trans)
        {
            PrepareTransSqlCommand(ProcedureName, cmd, conn, trans);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// ����ִ�����ݿ�transcation����Ҫ����ص�connection����
        /// </summary>
        public static void TransExecuteNonQueryReturnPKID(string ProcedureName, SqlCommand cmd, SqlConnection conn, SqlTransaction trans, out int PKID)
        {
            PrepareTransSqlCommand(ProcedureName, cmd, conn, trans);
            cmd.ExecuteNonQuery();
            PKID = Convert.ToInt32(cmd.Parameters["@PKID"].Value);
            cmd.Parameters.Clear();
        }

        private static void PrepareTransSqlCommand(string ProcedureName, SqlCommand cmd, SqlConnection conn, SqlTransaction trans)
        {
            cmd.Transaction = trans;
            cmd.Connection = conn;
            cmd.CommandText = ProcedureName;
            cmd.CommandType = CommandType.StoredProcedure;
        }

        private static void PrepareProcedureCommand(string ProcedureName, SqlCommand salesCommand, SqlConnection conn)
        {
            salesCommand.Connection = conn;
            salesCommand.CommandText = ProcedureName;
            salesCommand.CommandType = CommandType.StoredProcedure;
            conn.Open();
        }
    }
}