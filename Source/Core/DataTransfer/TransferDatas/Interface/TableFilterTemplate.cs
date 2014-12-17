//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: TableFilterTemplate.cs
// ������: �ߺ�
// ��������: 2009-06-08
// ����: ��չ�ӿڵ�һ��ģ�壬��Ҫ����һ�Զࡢһ��һ����չ���ɾѡ
//       ��δ���ǹ���Զ�ģʽ����ڴ�ģ�������ã���Ҫ�ڶ�Զ����
//       ���¼̳и�ģ��
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
        /// �����Ƿ���Ҫʱ�����
        /// </summary>
        public abstract bool GetNeedTimeFilter();
        /// <summary>
        /// ������ǰ���һ���¶���
        /// </summary>
        protected abstract TableFilterTemplate DefineNewObj();
        /// <summary>
        /// ��������Ĺ��˵���䣬��������ڱ���֮ʱ�� ��Ҫɾ���Ŀ������ݿ�������ݣ�����delete from [_MainTable] where applicationFrom < '[fromDay]' or applicationFrom > '[toDay]'
        /// </summary>
        /// <param name="fromDay">ʱ����ʼ</param>
        /// <param name="toDay">ʱ�����</param>
        /// <returns>Sql������ַ���</returns>
        protected abstract string DefineTheMainTableFilterCommand(DateTime? fromDay, DateTime? toDay);
        /// <summary>
        /// ��������ѡ������,��������ڻ�ԭ֮ǰ����Ҫ�ڴ���ԭ���ݿ���ѡ���������,ע��,ͨ�������,�������DefineTheMainTableFilterCommand����Ӧ����ȫ�෴
        /// </summary>
        protected abstract string DefineTheMainTableSelectCommand(DateTime? fromDay, DateTime? toDay);
        /// <summary>
        /// ���屣��������������,����,TApplicationEmployee��TApplication�����������:applicationId
        /// </summary>
        /// <returns>KeyӦ������ɱ���������֣���Value���������</returns>
        protected abstract Dictionary<string, string> DefineProtectedTableFkColumnName();
        /// <summary>
        /// ���屾�β����ᴦ�������
        /// </summary>
        protected abstract string DefineOperationString();
        /// <summary>
        /// �����ڱ��ε���������Ҫ��������֮����Խ��еĴ�Ҫ��������
        /// </summary>
        /// <param name="tablesAndIds">����������Ϻ������Լ��������[����][����]�Ķ�</param>
        /// <param name="startDay">�������еĲ���</param>
        /// <param name="endDay">�������еĲ���</param>
        /// <returns>����������Ҫ��ӡ����Ϣ</returns>
        protected abstract string AfterBackUpMainProcess(Dictionary<string, List<int>> tablesAndIds,DateTime? startDay,DateTime? endDay);
        /// <summary>
        /// �����ڱ��ε�����Ҫ��������֮����Խ��еĴ�Ҫ��������
        /// </summary>
        /// <param name="orginTablesAndIds">����ԭ�����ݿ��������ɸѡ�����������Լ��������[����][����]�Ķ�</param>
        /// <param name="startDay">���еĲ���</param>
        /// <param name="endDay">���еĲ���</param>
        /// <returns>����������Ҫ��ӡ����Ϣ</returns>
        protected abstract string BeforeRestoreMainProcess(Dictionary<string, List<int>> orginTablesAndIds, DateTime? startDay, DateTime? endDay);
        /// <summary>
        /// �����ù�����֮����Զ�����¼�
        /// </summary>
        public abstract void AfterConfigTheFilter(TransferRule theRule, string orginDbName, string orginCopyDbName, string restoreDbName, string forRestoreCopyDbName);

        /// <summary>
        /// ���������
        /// </summary>
        protected TransferRule _TheRule;
        /// <summary>
        ///  ������
        /// </summary>
        protected string _MainTable;
        /// <summary>
        /// ����Դ�����ݿ���(��ϵͳ�����ݿ���)
        /// </summary>
        protected string _OrginDbName;
        /// <summary>
        /// ����ԴԴ�Ŀ������ݿ���(������ϵͳ�����ݿ���)
        /// </summary>
        protected string _OrginCopyDbName;
        /// <summary>
        /// ��ҪǨ�Ƶ����ݿ���(��ϵͳ�����ݿ���)
        /// </summary>
        protected string _RestoreDbName;
        /// <summary>
        /// ��ϵͳ�������ݿ��ڴ�ϵͳ�ϵĿ���
        /// </summary>
        protected string _ForRestoreCopyDbName;

        private string _Error_FilterTable;
        private bool _IgnoreMainTableProcess;
        private const string _Error_Columns_Fetch = "�޷���ȡָ�����ݱ���е��б������ݿ����ֱ�Ϊ��";
        private const string _Error_AddRow = "������ʧ�ܣ��ñ�Ϊ��";
        private const string _Error_TowTable_NotSameColumn = "2�����ݿ�ı��е��в�һ�£�����������2�����ݿ�İ汾��ͬ���£��ñ��ǣ�";
        private const string _Error_RowRead_Failed = "��ȡ���е���ʧ�ܣ��ñ������ȡ�������ֱ��ǣ�";
        private const string _Error_NeedTime = "��Ҫʱ�����ȴδ�ṩ";

        protected TableFilterTemplate()
        {
            _Error_FilterTable = string.Format("��ɸѡ��{0}���ݵ�ʱ�����ԭ���ǣ�", _MainTable);
        }

        #region TableFilter ��Ա

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
            //��������Ĭ�ϴ���֮������Ҫ�ı�����Id�ļ���
            Dictionary<string, List<int>> theOtherTablesAndIds = new Dictionary<string, List<int>>();
            StringBuilder sb = new StringBuilder();
            //���������
            if (!IgnoreMainTableProcess)
            {
                sb.AppendLine(FilterTheMainTable(fromDay, toDay, _OrginCopyDbName));
            }
            List<int> theMainTableIds = FindAllPkids(_MainTable, _OrginCopyDbName);
            theOtherTablesAndIds.Add(_MainTable,theMainTableIds);
            //�󸱱����
            sb.Append(FilterTheOtherTable(theMainTableIds, _OrginCopyDbName,theOtherTablesAndIds));
            sb.Append(AfterBackUpMainProcess(theOtherTablesAndIds, fromDay, toDay));
            return sb.ToString();
        }

        public string RestoreTableData(DateTime? fromDay, DateTime? toDay)
        {
            CheckTimeParameter(fromDay, toDay);
            //��������Ĭ�ϴ���֮������Ҫ�ı�����Id�ļ���
            Dictionary<string, List<int>> theOtherTablesAndIds = new Dictionary<string, List<int>>();
            StringBuilder sb = new StringBuilder();
            List<int> allPkidsInCopyTable = FindAllPkids(_MainTable, _ForRestoreCopyDbName);
            List<int> allPkidsInOrginTable = FindAllPkidsInOrginTable(fromDay, toDay, _RestoreDbName);
            //���ȴ��������չ�Ĵ�����Ϊ�˷�ֹ�����id�仯֮��������Ӱ��
            theOtherTablesAndIds.Add(_MainTable, allPkidsInOrginTable);
            foreach (KeyValuePair<string, string> theColumnn in DefineProtectedTableFkColumnName())
            {
                List<int> allPkidsInOrginTable1 = FindAllPkidsWithMainTableIds(theColumnn.Key,theColumnn.Value, allPkidsInOrginTable, _RestoreDbName);
                theOtherTablesAndIds.Add(theColumnn.Key, allPkidsInOrginTable1);
            }
            sb.Append(BeforeRestoreMainProcess(theOtherTablesAndIds, fromDay, toDay));
            //֮���ٴ���ͬ���ȴ���ӱ�
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
            //û������ζ�����еĶ�������Ҫɾ��
            return "-9998";
        }

        /// <summary>
        /// �����Ƿ���Ҫ������������й��̣����������뻹ԭ��Ĭ��Ϊ�����������ж����ϵ��ʱ��Ӧ�����øò���Ϊtrue
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

        #region ˽�з���

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
            return string.Format("--��{0}���ƣ�����{1}��,����{2}��,ɾ��{3}��", table, addRowCount, coverRowCount, delRowCount);
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
                throw new ApplicationException(string.Format("{0}{1}�������ǣ�{2}��ԭ���ǣ�{3}", _Error_AddRow, tableName, copyId, e.Message));
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
            //�ȱȽ����е��е���Ŀ�Ƿ���ͬ
            int needStoreColumnCount = FindAllColums(_RestoreDbName, tableName).Count;
            int copyDataColumnCount = FindAllColums(_ForRestoreCopyDbName, tableName).Count;
            if (needStoreColumnCount != copyDataColumnCount)
            {
                throw new ApplicationException(string.Format("{0}{1}", _Error_TowTable_NotSameColumn, tableName));
            }
            //����ÿһ��ֵ�Ĺ�ϣֵ�����Ƚ�
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
                throw new ApplicationException(string.Format("{0}{1}{2}��ԭ����:{3}", _Error_RowRead_Failed, tableName, copyId, e.Message));
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
                throw new ApplicationException(string.Format("{0}{1}{2}��ԭ����:{3}", _Error_RowRead_Failed, tableName, copyId, e.Message));
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
                throw new ApplicationException(string.Format("{0}{1}/{2}��ԭ���ǣ�{3}", _Error_Columns_Fetch, dbName, tableName, e.Message));
            }
            if (retVal.Count == 0)
            {
                throw new ApplicationException(string.Format("{0}{1}/{2}��ԭ���ǣ�δ��ɸѡ���κ�����", _Error_Columns_Fetch, dbName, tableName));
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
                    sb.AppendLine(string.Format("--��{0}����:������{1}��ɾ��{2}������", theColumnn.Key,allCount, SqlCommandRunner.ExecuteNonQuery(new SqlCommand(theCommand), dbName)));
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
                throw new ApplicationException(string.Format("{0}{1}/{2}��ԭ���ǣ�δ��ɸѡ���κ�����", _Error_Columns_Fetch, dbName, tableName));
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
            return string.Format("--��{0}����:������{1}��ɾ��{2}������", _MainTable, allCount, delRowCount);
        }

        #endregion

        #region ICloneable ��Ա

        public  object Clone()
        {
            TableFilterTemplate aCloneObj = DefineNewObj();
            aCloneObj._ForRestoreCopyDbName = _ForRestoreCopyDbName;
            aCloneObj._MainTable = _MainTable;
            aCloneObj._OrginCopyDbName = _OrginCopyDbName;
            aCloneObj._OrginDbName = _OrginDbName;
            aCloneObj._RestoreDbName = _RestoreDbName;
            //����Ŀ�¡�е�����,�ڷ���ConfigTheFilter�󣬸ÿ�¡��������ȫ���Ʊ���
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