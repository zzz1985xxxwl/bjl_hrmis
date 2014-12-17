using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TransferDatas
{
    public class SqlCommandRunner
    {
        #region ��������

        public static int ExecuteNonQuery(SqlCommand cmd, string dbName)
        {
            string dbConnection = StaticConfigTable.ConnectionString.Replace("@DbName@", dbName);
            using (SqlConnection conn = new SqlConnection(dbConnection))
            {
                cmd.Connection = conn;
                conn.Open();
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                conn.Close();
                return val;
            }
        }

        public static SqlDataReader ExecuteReader(SqlCommand cmd, string dbName)
        {
            string dbConnection = StaticConfigTable.ConnectionString.Replace("@DbName@", dbName);
            SqlConnection conn = new SqlConnection(dbConnection);
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

        #endregion

        #region ʵ�÷���(�����Ѿ���װ)

        /// <summary>
        /// ����һ�������ļ���ԭһ�����ݿ�
        /// </summary>
        /// <param name="newDbName">�����ݿ����֣�����ABC</param>
        /// <param name="dbDataDirPath">�����ݿ���Ŀ¼������c:\</param>
        /// <param name="soureBackFilePath">�����ļ�������c:\xyz.bak</param>
        public static void RestoreDbFromFile(string newDbName, string dbDataDirPath, string soureBackFilePath)
        {
            string sourceDbLogicName = FindDbLogicName(soureBackFilePath);
            Utility.AssertStringNotEmpty(sourceDbLogicName, Utility._Error_ReadLogicName_Failed);
            BuildRestoreDbSql(newDbName, dbDataDirPath, soureBackFilePath, sourceDbLogicName);
        }

        /// <summary>
        /// ɾ�����ݿ�
        /// </summary>
        /// <param name="dbName">���ݿ���</param>
        public static void DeleteDb(string dbName)
        {
            //�������ݿ����ӿ��ܴ��ڣ���Ҫʹ��SINGLE_USERģʽȡ�����ݿ��ռȨ
            string SqlCommand = string.Format(@"ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE 
                                                DROP DATABASE {0}", dbName);
            try
            {
                ExecuteNonQuery(new SqlCommand(SqlCommand), string.Empty);
                SqlConnection.ClearPool(new SqlConnection(StaticConfigTable.ConnectionString.Replace("@DbName@", dbName)));
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}��ԭ����:{2}", Utility._Error_DropDb_Failed, dbName, e.Message));
            }
        }

        /// <summary>
        /// ��ӡ�����Ϣ��������СId�����Id,������
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public static string GetTableInfo(string tableName,string dbName)
        {
            StringBuilder retVal = new StringBuilder();
            string sqlCommand = string.Format("select '{0}' as 'TableName',min(pkid) as 'MinID',max(pkid) as 'MaxID',count(*) as 'RowCount' from {0}", tableName);

            try
            {
                //������ʾ��������Ҫһ��ָ�������ݿ��������и�����
                using (SqlDataReader sdr = ExecuteReader(new SqlCommand(sqlCommand), dbName))
                {
                    while (sdr.Read())
                    {
                        retVal.Append("������").Append(sdr["TableName"].ToString()).Append(",");
                        retVal.Append("��СID��").Append(sdr["MinID"].ToString()).Append(",");
                        retVal.Append("���ID��").Append(sdr["MaxID"].ToString()).Append(",");
                        retVal.Append("��������").Append(sdr["RowCount"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}/{2}��ԭ���ǣ�{3}", Utility._Error_ReadTable_Failed, dbName, tableName,e.Message));
            }
            return retVal.ToString();
        }

        /// <summary>
        /// ��ȡ�������������
        /// </summary>
        /// <param name="tableName">����</param>
        /// <param name="dbName">���ݿ���</param>
        /// <returns>ָ�����ݿ��еı����������</returns>
        public static int GetTableRowCount(string tableName, string dbName)
        {
            StringBuilder retVal = new StringBuilder();
            string sqlCommand = string.Format("select count(*) as 'RowCount' from {0}", tableName);

            try
            {
                using (SqlDataReader sdr = ExecuteReader(new SqlCommand(sqlCommand), dbName))
                {
                    while (sdr.Read())
                    {
                        return int.Parse(sdr["RowCount"].ToString());
                    }
                    throw new ApplicationException(string.Format("{0}{1}/{2}��ԭ���ǣ�δ�ܶ�ȡ��ָ��������Ϣ", Utility._Error_ReadTable_Failed, dbName, tableName));
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}/{2}��ԭ���ǣ�{3}", Utility._Error_ReadTable_Failed, dbName, tableName, e.Message));
            }
        }

        /// <summary>
        /// ��ȡָ�����ݿ��б������Լ��
        /// </summary>
        /// <param name="tableName">ָ����</param>
        /// <param name="dbName">ָ�����ݿ�</param>
        public static List<ConstraintInfo> GetConstraintInfo(string tableName,string dbName)
        {
            List<ConstraintInfo> retVal = new List<ConstraintInfo>();
            string sqlCommand = string.Format(@"select a.COLUMN_NAME,a.CONSTRAINT_NAME,b.CONSTRAINT_TYPE from 
                                                INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE as a 
		                                        join INFORMATION_SCHEMA.TABLE_CONSTRAINTS as b 
		                                        on a.Constraint_name = b.Constraint_name
                                                where a.table_name = '{0}'", tableName);
            try
            {
                using (SqlDataReader sdr = ExecuteReader(new SqlCommand(sqlCommand), dbName))
                {
                    while (sdr.Read())
                    {
                        ConstraintInfo aNewObj = new ConstraintInfo();
                        aNewObj.ReadFromData(sdr, tableName);
                        retVal.Add(aNewObj);
                    }
                }
                return retVal;
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1},ԭ����:{2}", Utility._Error_ReadConstraint_Failed, tableName, e.Message));
            }
        }

        /// <summary>
        /// �ָ�ָ�����ݿ���е�Լ����Ϣ(��֧�����������ָ�����֧������ָ�)
        /// </summary>
        /// <param name="theConstraintInfos">����Լ����Ϣ�Ĵ洢</param>
        /// <param name="tableName">ָ����</param>
        /// <param name="dbName">ָ�����ݿ�</param>
        public static void RestoreConstraintInfo(List<ConstraintInfo> theConstraintInfos,string tableName,string dbName)
        {
            //������������ʱ��������
            foreach(ConstraintInfo ci in theConstraintInfos)
            {
                foreach(ConstraintInfo ci1 in theConstraintInfos)
                {
                 
                    if (ci.ConstraintNameValue == ci1.ConstraintNameValue && !ci.Equals(ci1))
                    {
                        throw new ApplicationException(string.Format("{0}{1}", Utility._Error_ReConstraint_PkFailed, tableName));
                    }
                }
            }
            //������ԭ����
            StringBuilder sb = new StringBuilder();
            foreach(ConstraintInfo ci2 in theConstraintInfos)
            {
                sb.AppendLine(ci2.MakeRestoreConstraintCommand(tableName));
            }
            try
            {
                ExecuteNonQuery(new SqlCommand(sb.ToString()), dbName);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1},ԭ���ǣ�{2}", Utility._Error_ReConstraint_Failed,tableName, e.Message));
            }
        }

        /// <summary>
        /// ����ָ�����ݿ���е�Լ����Ϣ(֧�����)
        /// </summary>
        /// <param name="theConstraintInfos">����Լ����Ϣ�Ĵ洢</param>
        /// <param name="tableName">ָ����</param>
        /// <param name="dbName">ָ�����ݿ�</param>
        public static void DropConstraintInfo(List<ConstraintInfo> theConstraintInfos,string tableName,string dbName)
        {
            //������ԭ����
            StringBuilder sb = new StringBuilder();
            foreach (ConstraintInfo ci2 in theConstraintInfos)
            {
                sb.AppendLine(ci2.MakeDropConstraintCommand(tableName));
            }
            try
            {
                ExecuteNonQuery(new SqlCommand(sb.ToString()), dbName);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1},ԭ���ǣ�{2}", Utility._Error_DropConstraint_Failed, tableName, e.Message));
            }
        }

        /// <summary>
        /// ɾ��ָ�����ݿ��ָ����
        /// </summary>
        /// <param name="tableName">ָ������</param>
        /// <param name="dbName">ָ�����ݿ���</param>
        public static void DropTable(string tableName, string dbName)
        {
            string sqlCommand = string.Format("DROP TABLE {0}", tableName);
            try
            {
                ExecuteNonQuery(new SqlCommand(sqlCommand), dbName);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}��ԭ���ǣ�{2}", Utility._Error_DropTable_Failed, tableName,e.Message));
            }
        }

        /// <summary>
        /// ��һ�����ݿ���ȫ����һ��������һ�����ݿ�
        /// </summary>
        /// <param name="tableName">������</param>
        /// <param name="fromDb">Դ�����ڵ����ݿ���(Ӧ������ָ���ı�)</param>
        /// <param name="toDb">Ŀ�����ݿ�(Ӧ��������ָ���ı�)</param>
        public static void CopyTable(string tableName, string fromDb, string toDb)
        {
            string copyTableCommand = string.Format(@"SELECT * INTO {0} FROM {1}.dbo.{0}", tableName, fromDb);
            try
            {
                ExecuteNonQuery(new SqlCommand(copyTableCommand), toDb);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}��ԭ����:{2}", Utility._Error_CopyTable_Failed, tableName, e.Message));
            }
        }

        /// <summary>
        /// �������ݿ�
        /// </summary>
        /// <param name="dbName">���ݿ���</param>
        /// <param name="toCompleteName">ָ����ȫ������·��������</param>
        public static void BackUpDb(string dbName,string toCompleteName)
        {
            string backUpDbCommand = string.Format("BACKUP DATABASE {0} TO DISK = '{1}'", dbName, toCompleteName);
            try
            {
                ExecuteNonQuery(new SqlCommand(backUpDbCommand),string.Empty);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format(@"{0}{1}/{2}��ԭ���ǣ�{3}", Utility._Error_BackUpDb_Failed, dbName, toCompleteName,e.Message));
            }
        }

        /// <summary>
        /// ��ȡָ�����ݿ������еı�
        /// </summary>
        /// <param name="dbName">ָ�����ݿ�</param>
        public static List<string> GetAllTables(string dbName)
        {
            List<string> retVal = new List<string>();
            SqlCommand queryAllTables = new SqlCommand(@"select * from information_schema.tables where TABLE_TYPE='Base table'");
            try
            {
                using (SqlDataReader sdr = ExecuteReader(queryAllTables, dbName))
                {
                    while (sdr.Read())
                    {
                        retVal.Add(sdr["TABLE_NAME"].ToString());
                    }
                    return retVal;
                }
            }
            catch(Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}��ԭ����{2}", Utility._Error_GetAllTable_Failed, dbName, e.Message));
            }
        }

        /// <summary>
        /// ɾ��ָ�����е��������
        /// </summary>
        /// <param name="dbName">ָ�����ݿ���</param>
        public static void DelAllFks(string dbName)
        {
            SqlCommand queryAllFk = new SqlCommand(string.Format(@"select * from {0}.INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'FOREIGN KEY'", dbName));
            StringBuilder deleteFks = new StringBuilder();
            try
            {
                using (SqlDataReader sdr = ExecuteReader(queryAllFk, string.Empty))
                {
                    while (sdr.Read())
                    {
                        deleteFks.Append(string.Format("ALTER TABLE {0} drop CONSTRAINT {1}", sdr["TABLE_NAME"],
                                                       sdr["CONSTRAINT_NAME"])).AppendLine();
                    }
                }
                if (!string.IsNullOrEmpty(deleteFks.ToString()))
                {
                    ExecuteNonQuery(new SqlCommand(deleteFks.ToString()), dbName);
                }
            }
            catch(Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}{2}",Utility._Error_DelAllFk_Failed, dbName, e.Message));
            }
        }

        #endregion

        #region ˽�з���

        private static void BuildRestoreDbSql(string newDbName, string dbDataDirPath, string soureBackFilePath, string sourceDbLogicName)
        {
            string sqlCommand = string.Format(
                            @"CREATE DATABASE {0}  
                            ON (name= '{0}_Data',filename='{1}{0}_Data.mdf',SIZE = 3MB,FILEGROWTH = 15%)
                            LOG ON(name='{0}_Log',filename='{1}{0}_Log.LDF',SIZE = 5MB,MAXSIZE = 25MB,FILEGROWTH = 5MB)
                            RESTORE DATABASE {0} from disk='{2}' 
                            WITH MOVE '{3}' TO '{1}{0}_Data.mdf',
                            MOVE '{3}_Log' TO '{1}{0}_Log.LDF',
                            STATS = 10, REPLACE", newDbName, dbDataDirPath, soureBackFilePath, sourceDbLogicName);
            try
            {
                //������ʾ��������Ҫһ��ָ�������ݿ��������и�����
                ExecuteNonQuery(new SqlCommand(sqlCommand), string.Empty);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}", Utility._Error_CopyDB_Failed, e.Message));
            }
        }

        private static string FindDbLogicName(string thebackUpDbPath)
        {
            SqlCommand queryDbConfig = new SqlCommand(String.Format(@"RESTORE FILELISTONLY FROM DISK='{0}'", thebackUpDbPath));
            try
            {
                //������ʾ��������Ҫһ��ָ�������ݿ��������и�����
                using (SqlDataReader sdr = ExecuteReader(queryDbConfig, string.Empty))
                {
                    while (sdr.Read())
                    {
                        if (sdr["Type"].ToString() == "D")
                        {
                            return sdr["LogicalName"].ToString();
                        }
                    }
                }
            }
            catch(Exception e)
            {
                throw new ApplicationException(string.Format("{0}��ԭ���ǣ�{1}", Utility._Error_ReadLogicName_Failed, e.Message));
            }
            return null;
        }

        #endregion

    }
}