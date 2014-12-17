using System;
using System.Collections.Generic;
using System.Text;

namespace TransferDatas
{
    public class DbTransfer:ICloneable
    {
        //源数据库拷贝的后缀名
        private const string _OrginCopyDbSuffix = "OrginCopy";
        //从系统上的数据库拷贝的后缀名
        private const string _ForRestoreCopyDbSuffix = "ForRestoreCopy";
        //默认的备份文件夹保留的数据库备份数量
        private const int _DefaultBackUpDbCount = 5;

        private string _DbName;
        private List<TableTransfer> _TablesToTransfer = new List<TableTransfer>();
        private List<string> _ProtectTableNames = new List<string>();

        #region 属性

        public string DbName
        {
            get
            {
                return _DbName;
            }
            set
            {
                _DbName = value;
            }
        }

        public List<TableTransfer> TablesToTransfer
        {
            get
            {
                return _TablesToTransfer;
            }
            set
            {
                _TablesToTransfer = value;
            }
        }

        public List<string> ProtectTableNames
        {
            get
            {
                return _ProtectTableNames;
            }
            set
            {
                _ProtectTableNames = value;
            }
        }

        #endregion

        #region 方法

        public TableTransfer FindTableTransfer(string tableName)
        {
            foreach(TableTransfer tt in _TablesToTransfer)
            {
                if(tableName.Equals(tt.TableName))
                {
                    return tt;
                }
            }
            return null;
        }

        /// <summary>
        /// 保护表指示的是在不会由主程序处理的表，而是由扩展对象自行处理的表
        /// </summary>
        public void AddProtectTable(string tableName)
        {
            if(FindTableTransfer(tableName) == null && FindTableProtected(tableName) == null)
            {
                _ProtectTableNames.Add(tableName);
            }
            else
            {
                throw new ApplicationException(string.Format("{0}{1}、{2}", Utility._Error_DefineTransfer_Exist_Table, _DbName, tableName));
            }
        }

        /// <summary>
        /// 添加TransferTable
        /// </summary>
        public void AddTransferTable(TableTransfer tableTransfer)
        {
            if (FindTableTransfer(tableTransfer.TableName) == null && FindTableProtected(tableTransfer.TableName) == null)
            {
                _TablesToTransfer.Add(tableTransfer);
            }
            else
            {
                throw new ApplicationException(string.Format("{0}{1}、{2}", Utility._Error_DefineTransfer_Exist_Table, _DbName, tableTransfer.TableName));
            }
        }

        /// <summary>
        /// 获取受保护的表，受保护的表将不由程序默认进行处理，而是由扩展对象自行处理的表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public string FindTableProtected(string tableName)
        {
            foreach (string pt in _ProtectTableNames)
            {
                if (tableName.Equals(pt))
                {
                    return pt;
                }
            }
            return null;
        }

        #endregion

        #region 私有方法

        internal void BackUpData(DateTime? fromDay, DateTime? toDay, RunningStatus theRuningStatusInSession)
        {
            //备份源数据库
            TransferService.StartLittleProcess(theRuningStatusInSession, string.Format("{0}{1}", Utility._Process_BackUpDb, _DbName));
            string targetName = string.Format("{0}{1}{2}.bak", DiskOperations.DbBackUp_ForBackUpDirectory, _DbName, Utility.GetTimeStamp());
            SqlCommandRunner.BackUpDb(_DbName, targetName);

            //删减数据库备份
            TransferService.StartLittleProcess(theRuningStatusInSession, string.Format("{0}", Utility._Process_DelNonuseDbBackUp));
            theRuningStatusInSession.AddInformationLine(DiskOperations.DelFilesFromDirectory(DiskOperations.DbBackUp_ForBackUpDirectory, _DbName, targetName, _DefaultBackUpDbCount));

            //拷贝数据库用于数据筛选
            string copyDbName = _DbName + _OrginCopyDbSuffix;
            TransferService.StartLittleProcess(theRuningStatusInSession, string.Format("{0}{1}", Utility._Process_CopyDb, copyDbName));
            SqlCommandRunner.RestoreDbFromFile(copyDbName, DiskOperations.TempDirectory, targetName);

            //删除无用的表
            TransferService.StartLittleProcess(theRuningStatusInSession, Utility._Process_DelNonUseTable);
            theRuningStatusInSession.AddInformationLine(DropNonUseTable(copyDbName));

            //有用表数据筛选
            foreach (TableTransfer tt in _TablesToTransfer)
            {
                tt.BackUpData(fromDay, toDay, theRuningStatusInSession);
            }

            //将筛选完毕的数据库备份到指定地点用于打包压缩
            TransferService.StartLittleProcess(theRuningStatusInSession, string.Format("{0}{1}", Utility._Process_BackUpFiltedTable, copyDbName));
            BackUpFilteredDb(copyDbName);

            //删除无用的数据库拷贝
            TransferService.StartLittleProcess(theRuningStatusInSession, string.Format("{0}{1}", Utility._Process_DelNonUseDb, copyDbName));
            SqlCommandRunner.DeleteDb(copyDbName);
        }

        internal void RestoreData(DateTime? fromDay, DateTime? toDay, RestoreStatus theRuningStatusInSession)
        {
            //备份源数据库
            TransferService.StartLittleProcess(theRuningStatusInSession, string.Format("{0}{1}", Utility._Process_BackUpDb, _DbName));
            string targetName = string.Format("{0}{1}{2}.bak", DiskOperations.DbBackUp_ForRestoreDirectory, _DbName, Utility.GetTimeStamp());
            SqlCommandRunner.BackUpDb(_DbName, targetName);

            //删减数据库备份
            TransferService.StartLittleProcess(theRuningStatusInSession, string.Format("{0}", Utility._Process_DelNonuseDbBackUp));
            theRuningStatusInSession.AddInformationLine(DiskOperations.DelFilesFromDirectory(DiskOperations.DbBackUp_ForRestoreDirectory, _DbName, targetName, _DefaultBackUpDbCount));

            //拷贝下载的数据库用于数据还原
            string copyDbName = _DbName + _ForRestoreCopyDbSuffix;
            string downLoadDbBackUpFullName = string.Format("{0}{1}{2}.bak", DiskOperations.DataTemp_ForRestoreDirectory, _DbName, _OrginCopyDbSuffix);
            TransferService.StartLittleProcess(theRuningStatusInSession, string.Format("{0}{1}", Utility._Process_CopyDb, copyDbName));
            SqlCommandRunner.RestoreDbFromFile(copyDbName, DiskOperations.TempDirectory, downLoadDbBackUpFullName);

            //每一个表的数据还原
            foreach (TableTransfer tt in _TablesToTransfer)
            {
                tt.RestoreData(fromDay, toDay, theRuningStatusInSession);
            }

            //删除无用的数据库拷贝
            TransferService.StartLittleProcess(theRuningStatusInSession, string.Format("{0}{1}", Utility._Process_DelNonUseDb, copyDbName));
            SqlCommandRunner.DeleteDb(copyDbName);
        }

        private void BackUpFilteredDb(string copyDbName)
        {
            string targetNameForRar = string.Format("{0}{1}.bak", DiskOperations.DataTemp_ForBackUpDirectory, copyDbName);
            DiskOperations.AssertFileNotExist(targetNameForRar, Utility._Error_ExistTargetBackUpDb);
            SqlCommandRunner.BackUpDb(copyDbName, targetNameForRar);
        }

        private string DropNonUseTable(string theReleatedDb)
        {
            StringBuilder retVal = new StringBuilder("--丢弃表：");
            //先删除所有外键，防止无法删除的表
            SqlCommandRunner.DelAllFks(theReleatedDb);
            //再删除表
            foreach (string aTable in SqlCommandRunner.GetAllTables(_DbName))
            {
                if (FindTableTransfer(aTable) == null && FindTableProtected(aTable) == null)
                {
                    SqlCommandRunner.DropTable(aTable, theReleatedDb);
                    retVal.Append(aTable).Append(",");
                }
            }
            if (retVal.ToString().EndsWith(","))
            {
                return retVal.Remove(retVal.Length - 1, 1).ToString();
            }
            return retVal.ToString();
        }


        internal void CheckDbBackUpExist()
        {
            string dbBackUpFullName = string.Format("{0}{1}{2}.bak", DiskOperations.DataTemp_ForRestoreDirectory, _DbName, _OrginCopyDbSuffix);
            DiskOperations.AssertFileExist(dbBackUpFullName, Utility._Error_ExistTargetBackUpDb);
        }

        internal void Check(string ruleName)
        {
            Utility.AssertStringNotEmpty(_DbName, string.Format("{0}{1}", Utility._Error_XmlConfig_DbName_NotFit, ruleName));
            foreach (TableTransfer aTableTransfer in _TablesToTransfer)
            {
                aTableTransfer.Check(ruleName);
            }
        }

        internal string MakeString()
        {
            StringBuilder sb = new StringBuilder(_DbName);
            sb.Append(":");
            foreach (TableTransfer tt in _TablesToTransfer)
            {
                sb.Append(tt.MakeString());
            }
            return sb.ToString();
        }

        internal void Construct()
        {
            foreach (TableTransfer tt in _TablesToTransfer)
            {
                tt.Construct();
            }
        }

        internal void ConfigAllRuleFitler(TransferRule transferRule)
        {
            foreach (TableTransfer tt in _TablesToTransfer)
            {
                tt.ConfigRuleFitler(transferRule, _DbName, _DbName + _OrginCopyDbSuffix, _DbName, _DbName + _ForRestoreCopyDbSuffix);
            }
        }

        internal bool GetNeedTimeFilter(TransferRule transferRule)
        {
            foreach (TableTransfer tt in _TablesToTransfer)
            {
                if (tt.GetNeedTimeFilter(transferRule))
                {
                    return true;
                }
            }
            return false;
        }

        internal void TryBackUpErrorClean()
        {
            SqlCommandRunner.DeleteDb(_DbName + _OrginCopyDbSuffix);
        }

        internal void TryRestoreErrorClean()
        {
            SqlCommandRunner.DeleteDb(_DbName + _ForRestoreCopyDbSuffix);
        }

        #endregion


        #region ICloneable 成员

        public object Clone()
        {
            DbTransfer aColoneObj = new DbTransfer();
            aColoneObj._DbName = _DbName;
            foreach (string protectTableName in _ProtectTableNames)
            {
                aColoneObj._ProtectTableNames.Add(protectTableName);
            }
            foreach(TableTransfer tt in _TablesToTransfer)
            {
                aColoneObj._TablesToTransfer.Add(tt.Clone() as TableTransfer);
            }
            return aColoneObj;
        }

        public override string ToString()
        {
            StringBuilder retVal = new StringBuilder();
            retVal.AppendLine(string.Format("数据库:{0}将会执行以下操作", _DbName));
            foreach (TableTransfer tt in _TablesToTransfer)
            {
                retVal.AppendLine(tt.ToString());
            }

            return retVal.ToString();
        }

        #endregion
    }
}