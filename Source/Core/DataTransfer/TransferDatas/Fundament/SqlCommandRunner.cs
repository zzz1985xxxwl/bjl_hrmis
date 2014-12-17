using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TransferDatas
{
    public class SqlCommandRunner
    {
        #region 基本方法

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

        #region 实用方法(错误都已经封装)

        /// <summary>
        /// 根据一个备份文件还原一个数据库
        /// </summary>
        /// <param name="newDbName">新数据库名字：例如ABC</param>
        /// <param name="dbDataDirPath">新数据库存放目录：例如c:\</param>
        /// <param name="soureBackFilePath">备份文件：例如c:\xyz.bak</param>
        public static void RestoreDbFromFile(string newDbName, string dbDataDirPath, string soureBackFilePath)
        {
            string sourceDbLogicName = FindDbLogicName(soureBackFilePath);
            Utility.AssertStringNotEmpty(sourceDbLogicName, Utility._Error_ReadLogicName_Failed);
            BuildRestoreDbSql(newDbName, dbDataDirPath, soureBackFilePath, sourceDbLogicName);
        }

        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="dbName">数据库名</param>
        public static void DeleteDb(string dbName)
        {
            //由于数据库连接可能存在，需要使用SINGLE_USER模式取得数据库独占权
            string SqlCommand = string.Format(@"ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE 
                                                DROP DATABASE {0}", dbName);
            try
            {
                ExecuteNonQuery(new SqlCommand(SqlCommand), string.Empty);
                SqlConnection.ClearPool(new SqlConnection(StaticConfigTable.ConnectionString.Replace("@DbName@", dbName)));
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}，原因是:{2}", Utility._Error_DropDb_Failed, dbName, e.Message));
            }
        }

        /// <summary>
        /// 打印表的信息，包括最小Id，最大Id,总行数
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
                //测试显示，并不需要一个指定的数据库用于运行该命令
                using (SqlDataReader sdr = ExecuteReader(new SqlCommand(sqlCommand), dbName))
                {
                    while (sdr.Read())
                    {
                        retVal.Append("表名：").Append(sdr["TableName"].ToString()).Append(",");
                        retVal.Append("最小ID：").Append(sdr["MinID"].ToString()).Append(",");
                        retVal.Append("最大ID：").Append(sdr["MaxID"].ToString()).Append(",");
                        retVal.Append("总行数：").Append(sdr["RowCount"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}/{2}，原因是：{3}", Utility._Error_ReadTable_Failed, dbName, tableName,e.Message));
            }
            return retVal.ToString();
        }

        /// <summary>
        /// 读取表的所有行数量
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="dbName">数据库名</param>
        /// <returns>指定数据库中的表的数据行数</returns>
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
                    throw new ApplicationException(string.Format("{0}{1}/{2}，原因是：未能读取到指定的行信息", Utility._Error_ReadTable_Failed, dbName, tableName));
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}/{2}，原因是：{3}", Utility._Error_ReadTable_Failed, dbName, tableName, e.Message));
            }
        }

        /// <summary>
        /// 读取指定数据库中表的所有约束
        /// </summary>
        /// <param name="tableName">指定表</param>
        /// <param name="dbName">指定数据库</param>
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
                throw new ApplicationException(string.Format("{0}{1},原因是:{2}", Utility._Error_ReadConstraint_Failed, tableName, e.Message));
            }
        }

        /// <summary>
        /// 恢复指定数据库表中的约束信息(不支持联合主键恢复，不支持外键恢复)
        /// </summary>
        /// <param name="theConstraintInfos">所有约束信息的存储</param>
        /// <param name="tableName">指定表</param>
        /// <param name="dbName">指定数据库</param>
        public static void RestoreConstraintInfo(List<ConstraintInfo> theConstraintInfos,string tableName,string dbName)
        {
            //联合主键，暂时不做处理
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
            //构建还原命令
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
                throw new ApplicationException(string.Format("{0}{1},原因是：{2}", Utility._Error_ReConstraint_Failed,tableName, e.Message));
            }
        }

        /// <summary>
        /// 放弃指定数据库表中的约束信息(支持外键)
        /// </summary>
        /// <param name="theConstraintInfos">所有约束信息的存储</param>
        /// <param name="tableName">指定表</param>
        /// <param name="dbName">指定数据库</param>
        public static void DropConstraintInfo(List<ConstraintInfo> theConstraintInfos,string tableName,string dbName)
        {
            //构建还原命令
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
                throw new ApplicationException(string.Format("{0}{1},原因是：{2}", Utility._Error_DropConstraint_Failed, tableName, e.Message));
            }
        }

        /// <summary>
        /// 删除指定数据库的指定表
        /// </summary>
        /// <param name="tableName">指定表名</param>
        /// <param name="dbName">指定数据库名</param>
        public static void DropTable(string tableName, string dbName)
        {
            string sqlCommand = string.Format("DROP TABLE {0}", tableName);
            try
            {
                ExecuteNonQuery(new SqlCommand(sqlCommand), dbName);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}，原因是：{2}", Utility._Error_DropTable_Failed, tableName,e.Message));
            }
        }

        /// <summary>
        /// 从一个数据库完全拷贝一个表到另外一个数据库
        /// </summary>
        /// <param name="tableName">表名字</param>
        /// <param name="fromDb">源表所在的数据库名(应当包含指定的表)</param>
        /// <param name="toDb">目标数据库(应当不包含指定的表)</param>
        public static void CopyTable(string tableName, string fromDb, string toDb)
        {
            string copyTableCommand = string.Format(@"SELECT * INTO {0} FROM {1}.dbo.{0}", tableName, fromDb);
            try
            {
                ExecuteNonQuery(new SqlCommand(copyTableCommand), toDb);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}，原因是:{2}", Utility._Error_CopyTable_Failed, tableName, e.Message));
            }
        }

        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="dbName">数据库名</param>
        /// <param name="toCompleteName">指定完全的物理路径备份名</param>
        public static void BackUpDb(string dbName,string toCompleteName)
        {
            string backUpDbCommand = string.Format("BACKUP DATABASE {0} TO DISK = '{1}'", dbName, toCompleteName);
            try
            {
                ExecuteNonQuery(new SqlCommand(backUpDbCommand),string.Empty);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format(@"{0}{1}/{2}，原因是：{3}", Utility._Error_BackUpDb_Failed, dbName, toCompleteName,e.Message));
            }
        }

        /// <summary>
        /// 获取指定数据库中所有的表
        /// </summary>
        /// <param name="dbName">指定数据库</param>
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
                throw new ApplicationException(string.Format("{0}{1}，原因是{2}", Utility._Error_GetAllTable_Failed, dbName, e.Message));
            }
        }

        /// <summary>
        /// 删除指定表中的所有外键
        /// </summary>
        /// <param name="dbName">指定数据库名</param>
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

        #region 私有方法

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
                //测试显示，并不需要一个指定的数据库用于运行该命令
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
                //测试显示，并不需要一个指定的数据库用于运行该命令
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
                throw new ApplicationException(string.Format("{0}，原因是：{1}", Utility._Error_ReadLogicName_Failed, e.Message));
            }
            return null;
        }

        #endregion

    }
}