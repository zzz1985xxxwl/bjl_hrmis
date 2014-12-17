//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: TableFilterTemplate.cs
// 创建者: 倪豪
// 创建日期: 2009-06-08
// 概述: 扩展接口的一个模板，主要用于一对多、一对一的扩展表的删选
//       从未考虑过多对多模式如何在此模板中运用，不要在多对多的情
//       形下继承该模板
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using TransferDatas;

namespace TransferDatas
{
    public abstract class TableFilterTemplate : ITableFilter
    {
        /// <summary>
        /// 定义是否需要时间参数
        /// </summary>
        public abstract bool GetNeedTimeFilter();
        /// <summary>
        /// 给出当前类的一个新对象
        /// </summary>
        protected abstract TableFilterTemplate DefineNewObj();
        /// <summary>
        /// 定义主表的过滤的语句，定义的是在备份之时， 需要删除的拷贝数据库的行数据，比如delete from [_MainTable] where applicationFrom < '[fromDay]' or applicationFrom > '[toDay]'
        /// </summary>
        /// <param name="fromDay">时间起始</param>
        /// <param name="toDay">时间结束</param>
        /// <returns>Sql命令的字符串</returns>
        protected abstract string DefineTheMainTableFilterCommand(DateTime? fromDay, DateTime? toDay);
        /// <summary>
        /// 定义主表选择的语句,定义的是在还原之前，需要在待还原数据库中选择的行数据,注意,通常情况下,此语句与DefineTheMainTableFilterCommand条件应该完全相反
        /// </summary>
        protected abstract string DefineTheMainTableSelectCommand(DateTime? fromDay, DateTime? toDay);
        /// <summary>
        /// 定义保护表的外键的列名,例如,TApplicationEmployee与TApplication的外键列名是:applicationId
        /// </summary>
        /// <returns>Key应当定义成保护表的名字，而Value定义成列名</returns>
        protected abstract Dictionary<string, string> DefineProtectedTableFkColumnName();
        /// <summary>
        /// 定义本次操作会处理的任务
        /// </summary>
        protected abstract string DefineOperationString();
        /// <summary>
        /// 定义在本次导出工作主要任务运行之后可以进行的次要运行任务
        /// </summary>
        /// <param name="tablesAndIds">本次运行完毕后主表以及保护表的[表名][主键]的对</param>
        /// <param name="startDay">本次运行的参数</param>
        /// <param name="endDay">本次运行的参数</param>
        /// <returns>本次运行需要打印的信息</returns>
        protected abstract string AfterBackUpMainProcess(Dictionary<string, List<int>> tablesAndIds,DateTime? startDay,DateTime? endDay);
        /// <summary>
        /// 定义在本次导入主要任务运行之后可以进行的次要运行任务
        /// </summary>
        /// <param name="orginTablesAndIds">待还原的数据库根据条件筛选出来的主表以及保护表的[表名][主键]的对</param>
        /// <param name="startDay">运行的参数</param>
        /// <param name="endDay">运行的参数</param>
        /// <returns>本次运行需要打印的信息</returns>
        protected abstract string BeforeRestoreMainProcess(Dictionary<string, List<int>> orginTablesAndIds, DateTime? startDay, DateTime? endDay);
        /// <summary>
        /// 在配置过滤器之后可以定义的事件
        /// </summary>
        public abstract void AfterConfigTheFilter(TransferRule theRule, string orginDbName, string orginCopyDbName, string restoreDbName, string forRestoreCopyDbName);

        /// <summary>
        /// 规则的引用
        /// </summary>
        protected TransferRule _TheRule;
        /// <summary>
        ///  主表名
        /// </summary>
        protected string _MainTable;
        /// <summary>
        /// 数据源的数据库名(主系统的数据库名)
        /// </summary>
        protected string _OrginDbName;
        /// <summary>
        /// 数据源源的拷贝数据库名(拷贝主系统的数据库名)
        /// </summary>
        protected string _OrginCopyDbName;
        /// <summary>
        /// 需要迁移的数据库名(从系统的数据库名)
        /// </summary>
        protected string _RestoreDbName;
        /// <summary>
        /// 主系统拷贝数据库在从系统上的拷贝
        /// </summary>
        protected string _ForRestoreCopyDbName;

        private string _Error_FilterTable;
        private bool _IgnoreMainTableProcess;
        private const string _Error_Columns_Fetch = "无法读取指定数据表的列的列表，该数据库与表分别为：";
        private const string _Error_AddRow = "新增行失败，该表为：";
        private const string _Error_TowTable_NotSameColumn = "2个数据库的表中的列不一致，可能是由于2个数据库的版本不同所致，该表是：";
        private const string _Error_RowRead_Failed = "读取表中的行失败，该表与待读取的主键分别是：";
        private const string _Error_NeedTime = "需要时间参数却未提供";

        protected TableFilterTemplate()
        {
            _Error_FilterTable = string.Format("在筛选表{0}数据的时候出错，原因是：", _MainTable);
        }

        #region TableFilter 成员

        public void ConfigTheFilter(TransferRule theRule, string mainTableName, string orginDbName, string orginCopyDbName, string restoreDbName, string forRestoreCopyDbName)
        {
            _MainTable = mainTableName;
            _TheRule = theRule;
            _OrginDbName = orginDbName;
            _OrginCopyDbName = orginCopyDbName;
            _RestoreDbName = restoreDbName;
            _ForRestoreCopyDbName = forRestoreCopyDbName;

            DbTransfer theDt = theRule.FindDbTransferByName(orginDbName);
            foreach (KeyValuePair<string, string> theColumnn in DefineProtectedTableFkColumnName())
            {
                theDt.AddProtectTable(theColumnn.Key);
            }

            AfterConfigTheFilter(theRule, orginDbName, orginCopyDbName, restoreDbName,forRestoreCopyDbName);
        }

        public string FilterTableData(DateTime? fromDay, DateTime? toDay)
        {
            CheckTimeParameter(fromDay, toDay);
            //定义了在默认处理之后处理需要的表名与Id的集合
            Dictionary<string, List<int>> theOtherTablesAndIds = new Dictionary<string, List<int>>();
            StringBuilder sb = new StringBuilder();
            //先主表过滤
            if (!IgnoreMainTableProcess)
            {
                sb.AppendLine(FilterTheMainTable(fromDay, toDay, _OrginCopyDbName));
            }
            List<int> theMainTableIds = FindAllPkids(_MainTable, _OrginCopyDbName);
            theOtherTablesAndIds.Add(_MainTable,theMainTableIds);
            //后副表过滤
            sb.Append(FilterTheOtherTable(theMainTableIds, _OrginCopyDbName,theOtherTablesAndIds));
            sb.Append(AfterBackUpMainProcess(theOtherTablesAndIds, fromDay, toDay));
            return sb.ToString();
        }

        public string RestoreTableData(DateTime? fromDay, DateTime? toDay)
        {
            CheckTimeParameter(fromDay, toDay);
            //定义了在默认处理之后处理需要的表名与Id的集合
            Dictionary<string, List<int>> theOtherTablesAndIds = new Dictionary<string, List<int>>();
            StringBuilder sb = new StringBuilder();
            List<int> allPkidsInCopyTable = FindAllPkids(_MainTable, _ForRestoreCopyDbName);
            List<int> allPkidsInOrginTable = FindAllPkidsInOrginTable(fromDay, toDay, _RestoreDbName);
            //首先处理的是扩展的处理方法为了防止主表的id变化之后对其产生影响
            theOtherTablesAndIds.Add(_MainTable, allPkidsInOrginTable);
            foreach (KeyValuePair<string, string> theColumnn in DefineProtectedTableFkColumnName())
            {
                List<int> allPkidsInOrginTable1 = FindAllPkidsWithMainTableIds(theColumnn.Key,theColumnn.Value, allPkidsInOrginTable, _RestoreDbName);
                theOtherTablesAndIds.Add(theColumnn.Key, allPkidsInOrginTable1);
            }
            sb.Append(BeforeRestoreMainProcess(theOtherTablesAndIds, fromDay, toDay));
            //之后再处理，同样先处理从表
            foreach (KeyValuePair<string, string> theColumnn in DefineProtectedTableFkColumnName())
            {
                List<int> allPkidsInCopyTable1 = FindAllPkids(theColumnn.Key, _ForRestoreCopyDbName);
                List<int> allPkidsInOrginTable1 = FindAllPkidsWithMainTableIds(theColumnn.Key, theColumnn.Value, allPkidsInOrginTable, _RestoreDbName);
                sb.AppendLine(TransferDataBasePkid(allPkidsInCopyTable1, allPkidsInOrginTable1, theColumnn.Key));
            }
            if (!IgnoreMainTableProcess)
            {
                sb.Append(TransferDataBasePkid(allPkidsInCopyTable, allPkidsInOrginTable, _MainTable));
            }

            return sb.ToString();
        }

        public string MakePkidStrings(List<int> allPkids)
        {
            StringBuilder sb = new StringBuilder();

            foreach (int i in allPkids)
            {
                sb.Append(i).Append(",");
            }

            if (sb.Length > 0)
            {
                return sb.ToString().Substring(0, sb.Length - 1);
            }
            //没有项意味着所有的东西都需要删除
            return "-9998";
        }

        /// <summary>
        /// 定义是否需要跳过主表的所有过程，包括过滤与还原，默认为不跳过，当有多层表关系的时候，应当设置该参数为true
        /// </summary>
        public bool IgnoreMainTableProcess
        {
            get
            {
                return _IgnoreMainTableProcess;
            }
            set
            {
                _IgnoreMainTableProcess = value;
            }
        }

        #endregion

        #region 私有方法

        private void CheckTimeParameter(DateTime? fromDay, DateTime? toDay)
        {
            if(GetNeedTimeFilter())
            {
                if (fromDay == null || toDay == null)
                {
                    throw new ApplicationException(_Error_NeedTime);
                }
            }
        }

        private string TransferDataBasePkid(List<int> allPkidsInCopyTable, List<int> allPkidsInOrginTable, string table)
        {
            int addRowCount = 0;
            int coverRowCount = 0;
            int delRowCount = 0;

            foreach (int copyId in allPkidsInCopyTable)
            {
                if (allPkidsInOrginTable.Contains(copyId))
                {
                    if (TryCoverData(copyId, table))
                    {
                        coverRowCount++;
                    }

                }
                else
                {
                    AddData(copyId, table);
                    addRowCount++;
                }
            }
            foreach (int orginId in allPkidsInOrginTable)
            {
                if (!allPkidsInCopyTable.Contains(orginId))
                {
                    DeleteData(orginId, table, _RestoreDbName);
                    delRowCount++;
                }
            }
            return string.Format("--表{0}共计：增加{1}行,覆盖{2}行,删除{3}行", table, addRowCount, coverRowCount, delRowCount);
        }

        private void DeleteData(int orginId, string tableName, string dbName)
        {
            string sqlCommand = string.Format("delete from {0} where pkid = {1}", tableName, orginId);
            try
            {
                SqlCommandRunner.ExecuteNonQuery(new SqlCommand(sqlCommand), dbName);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}", _Error_FilterTable, e.Message));
            }
        }

        private void AddData(int copyId, string tableName)
        {
            string theColumnsString = MakeColumnsString(FindAllColums(_RestoreDbName, tableName), _RestoreDbName, tableName);
            StringBuilder addCommand = new StringBuilder();
            addCommand.AppendLine(string.Format("SET IDENTITY_INSERT {0} ON", tableName));
            addCommand.AppendLine(string.Format(@"insert into {0}({1}) select * from {2}.dbo.{0} where pkid = {3}", tableName, theColumnsString, _ForRestoreCopyDbName, copyId));
            addCommand.AppendLine(string.Format("SET IDENTITY_INSERT {0} OFF", tableName));

            try
            {
                SqlCommandRunner.ExecuteNonQuery(new SqlCommand(addCommand.ToString()), _RestoreDbName);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}，主键是：{2}，原因是：{3}", _Error_AddRow, tableName, copyId, e.Message));
            }
        }

        private bool TryCoverData(int copyId, string tableName)
        {
            if (RowDataIsSame(copyId, tableName))
            {
                return false;
            }
            else
            {
                DeleteData(copyId, tableName, _RestoreDbName);
                AddData(copyId, tableName);
                return true;
            }
        }

        private bool RowDataIsSame(int copyId, string tableName)
        {
            //先比较所有的列的数目是否相同
            int needStoreColumnCount = FindAllColums(_RestoreDbName, tableName).Count;
            int copyDataColumnCount = FindAllColums(_ForRestoreCopyDbName, tableName).Count;
            if (needStoreColumnCount != copyDataColumnCount)
            {
                throw new ApplicationException(string.Format("{0}{1}", _Error_TowTable_NotSameColumn, tableName));
            }
            //构建每一列值的哈希值，并比较
            int[] hashCodeOfneedStoreData = new int[needStoreColumnCount];
            int[] hashCodeOfneedCopyData = new int[needStoreColumnCount];
            string rowCommand = string.Format("select * from {0} where pkid = {1}", tableName, copyId);
            try
            {
                using (SqlDataReader sdr = SqlCommandRunner.ExecuteReader(new SqlCommand(rowCommand), _RestoreDbName))
                {
                    while (sdr.Read())
                    {
                        for (int i = 0; i < needStoreColumnCount; i++)
                        {
                            hashCodeOfneedStoreData[i] = sdr[i].GetHashCode();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}{2}，原因是:{3}", _Error_RowRead_Failed, tableName, copyId, e.Message));
            }
            try
            {
                using (SqlDataReader sdr = SqlCommandRunner.ExecuteReader(new SqlCommand(rowCommand), _ForRestoreCopyDbName))
                {
                    while (sdr.Read())
                    {
                        for (int i = 0; i < needStoreColumnCount; i++)
                        {
                            hashCodeOfneedCopyData[i] = sdr[i].GetHashCode();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}{2}，原因是:{3}", _Error_RowRead_Failed, tableName, copyId, e.Message));
            }

            for (int i = 0; i < needStoreColumnCount; i++)
            {
                if (hashCodeOfneedStoreData[i] != hashCodeOfneedCopyData[i])
                {
                    return false;
                }
            }
            return true;
        }

        private List<int> FindAllPkidsWithMainTableIds(string tableName,string colunName, List<int> allPkidsInOrginTable, string dbName)
        {
            string command1 = string.Format("select pkid from {0} where {1} in({2})", tableName, colunName, MakePkidStrings(allPkidsInOrginTable));

            List<int> retVal = new List<int>();
            try
            {
                using (SqlDataReader sdr = SqlCommandRunner.ExecuteReader(new SqlCommand(command1), dbName))
                {
                    while (sdr.Read())
                    {
                        retVal.Add(int.Parse(sdr["pkid"].ToString()));
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}", _Error_FilterTable, e.Message));
            }
            return retVal;

        }

        private List<int> FindAllPkidsInOrginTable(DateTime? fromDay, DateTime? toDay, string dbName)
        {
            List<int> retVal = new List<int>();
      
            try
            {
                using (SqlDataReader sdr = SqlCommandRunner.ExecuteReader(new SqlCommand(DefineTheMainTableSelectCommand(fromDay, toDay)), dbName))
                {
                    while (sdr.Read())
                    {
                        retVal.Add(int.Parse(sdr["pkid"].ToString()));
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}", _Error_FilterTable, e.Message));
            }
            return retVal;
        }

     

        private List<string> FindAllColums(string dbName, string tableName)
        {
            List<string> retVal = new List<string>();

            string fetchColumns = string.Format(@"select column_name from {0}.information_schema.columns where table_name = '{1}'", dbName, tableName);
            try
            {
                using (SqlDataReader sdr = SqlCommandRunner.ExecuteReader(new SqlCommand(fetchColumns), dbName))
                {
                    while (sdr.Read())
                    {
                        retVal.Add(sdr["column_name"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}/{2}，原因是：{3}", _Error_Columns_Fetch, dbName, tableName, e.Message));
            }
            if (retVal.Count == 0)
            {
                throw new ApplicationException(string.Format("{0}{1}/{2}，原因是：未能筛选出任何列名", _Error_Columns_Fetch, dbName, tableName));
            }

            return retVal;
        }

        private string FilterTheOtherTable(List<int> theRemainedMainTablePkids, string dbName,Dictionary<string, List<int>> tablesAndIds)
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> theColumnn in DefineProtectedTableFkColumnName())
            {
                int allCount = SqlCommandRunner.GetTableRowCount(theColumnn.Key, dbName);
                try
                {
                    string theCommand = string.Format("delete from {0} where {1} not in({2})", theColumnn.Key, theColumnn.Value, MakePkidStrings(theRemainedMainTablePkids));
                    sb.AppendLine(string.Format("--表{0}共计:总行数{1}，删减{2}行数据", theColumnn.Key,allCount, SqlCommandRunner.ExecuteNonQuery(new SqlCommand(theCommand), dbName)));
                    tablesAndIds.Add(theColumnn.Key, FindAllPkids(theColumnn.Key, dbName));
                }
                catch (Exception e)
                {
                    throw new ApplicationException(string.Format("{0}{1}", _Error_FilterTable, e.Message));
                }
            }
            return sb.ToString();
        }

        private string MakeColumnsString(List<string> allColumns, string dbName, string tableName)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string aColumn in allColumns)
            {
                sb.Append(string.Format("[{0}]", aColumn)).Append(",");
            }

            if (sb.Length > 0)
            {
                return sb.ToString().Substring(0, sb.Length - 1);
            }
            else
            {
                throw new ApplicationException(string.Format("{0}{1}/{2}，原因是：未能筛选出任何列名", _Error_Columns_Fetch, dbName, tableName));
            }
        }

        private List<int> FindAllPkids(string tableName, string theDb)
        {
            List<int> retVal = new List<int>();
            try
            {
                using (SqlDataReader sdr = SqlCommandRunner.ExecuteReader(new SqlCommand(string.Format("select pkid from {0}", tableName)), theDb))
                {
                    while (sdr.Read())
                    {
                        retVal.Add(int.Parse(sdr["pkid"].ToString()));
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}", _Error_FilterTable, e.Message));
            }
            return retVal;
        }

        private string FilterTheMainTable(DateTime? fromDay, DateTime? toDay, string dbName)
        {
            int allCount = SqlCommandRunner.GetTableRowCount(_MainTable, dbName);
            int delRowCount;
            string sqlCommand = DefineTheMainTableFilterCommand(fromDay, toDay);
            try
            {
                delRowCount = SqlCommandRunner.ExecuteNonQuery(new SqlCommand(sqlCommand), dbName);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("{0}{1}", _Error_FilterTable, e.Message));
            }
            return string.Format("--表{0}共计:总行数{1}，删减{2}行数据", _MainTable, allCount, delRowCount);
        }

        #endregion

        #region ICloneable 成员

        public  object Clone()
        {
            TableFilterTemplate aCloneObj = DefineNewObj();
            aCloneObj._ForRestoreCopyDbName = _ForRestoreCopyDbName;
            aCloneObj._MainTable = _MainTable;
            aCloneObj._OrginCopyDbName = _OrginCopyDbName;
            aCloneObj._OrginDbName = _OrginDbName;
            aCloneObj._RestoreDbName = _RestoreDbName;
            //这里的克隆有点特殊,在方法ConfigTheFilter后，该克隆将不会完全复制本身
            aCloneObj._TheRule = null;
            return aCloneObj;
        }

        public override string ToString()
        {
            return DefineOperationString();
        }

        #endregion

    }
}