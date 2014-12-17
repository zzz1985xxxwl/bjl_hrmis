using System;
using System.Collections.Generic;
using System.Text;

namespace TransferDatas
{
    public class TransferRule:ICloneable
    {
        private const string _DefaultBackUpDbName = "DataBackUp";
        //下载文件夹保持的下载文件的数量
        private const int _DefaultDownloadFiles = 5;

        private string _RuleName;
        private List<DbTransfer> _DbsToTransfer = new List<DbTransfer>();

        public string RuleName
        {
            get
            {
                return _RuleName;
            }
            set
            {
                _RuleName = value;
            }
        }

        public List<DbTransfer> DbsToTransfer
        {
            get
            {
                return _DbsToTransfer;
            }
            set
            {
                _DbsToTransfer = value;
            }
        }

        #region 方法

        /// <summary>
        /// 检查有效性
        /// </summary>
        /// <param name="ruleName">规则名字</param>
        /// <param name="ruleString">规则的字符串</param>
        public void Check(string ruleName, string ruleString)
        {
            //首先检查非空的字段
            Utility.AssertStringNotEmpty(_RuleName, Utility._Error_XmlConfig_TransferRule_KeyEmpty);
            foreach(DbTransfer aDbTransfer in _DbsToTransfer)
            {
                aDbTransfer.Check(_RuleName);
            }
            //再检查检测出来的与字符的是否一样
            Utility.AssertAreSame(ruleString, MakeString(), string.Format("{0}\n原始字符串{1}\n读取的规则字符串{2}", Utility._Error_XmlConfig_Read_NotFit, ruleString, MakeString()));
        }

        /// <summary>
        /// 将当前对象转为规则字符串
        /// </summary>
        public string MakeString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(DbTransfer dt in _DbsToTransfer)
            {
                sb.Append(dt.MakeString());
                sb.Append(";");
            }
            if(sb.Length >0)
            {
                return sb.ToString().Substring(0, sb.Length - 1);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 构建完整的规则,包括需要寻找相应的dll中，实例化相应的接口，将需要的对象都组装起来
        /// </summary>
        public void Construct()
        {
            foreach (DbTransfer dt in _DbsToTransfer)
            {
                dt.Construct();
            }
        }

        public DbTransfer FindDbTransferByName(string dbName)
        {
            foreach(DbTransfer dt in _DbsToTransfer)
            {
                if(dt.DbName.Equals(dbName))
                {
                    return dt;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取该规则是否需要时间参数
        /// </summary>
        public bool GetNeedTimeFilter()
        {
            foreach (DbTransfer dt in _DbsToTransfer)
            {
                if(dt.GetNeedTimeFilter(this))
                {
                    return true;
                }
            }
            return false;
        }

        public void BackUpData(DateTime? fromDay, DateTime? toDay, BackUpStatus theRuningStatusInSession)
        {
            try
            {
                //写入迁移配置文件
                TransferService.StartLittleProcess(theRuningStatusInSession, TransferConfig.WriteConfigToString());
                TransferConfig.WriteConfig(this, fromDay, toDay);

                //配置所有过滤器
                TransferService.StartLittleProcess(theRuningStatusInSession, Utility._Process_ConfigFilter);
                ConfigAllRuleFitler();
                
                //每个数据库执行操作
                foreach(DbTransfer dt in _DbsToTransfer)
                {
                    dt.BackUpData(fromDay, toDay, theRuningStatusInSession);
                }

                //打包下载文件
                TransferService.StartLittleProcess(theRuningStatusInSession, Utility._Process_RarBackUpFile);
                string theBackUpSimpleName = string.Format("{0}{1}.rar", _DefaultBackUpDbName, Utility.GetTimeStamp());
                string theBackUpFullPath = string.Format("{0}{1}", DiskOperations.DownLoadDirectory, theBackUpSimpleName);
                CommandRunner.RarDirectoryToFile(theBackUpFullPath, DiskOperations.DataTemp_ForBackUpDirectory);
                theRuningStatusInSession.SuccessFileName = theBackUpSimpleName;
                theRuningStatusInSession.SuccessFullFileName = theBackUpFullPath;

                //清理无用的数据
                TransferService.StartLittleProcess(theRuningStatusInSession, Utility._Process_CleanNonUseData);
                CommandRunner.CleanUpDirectory(DiskOperations.DataTemp_ForBackUpDirectory);
                theRuningStatusInSession.AddInformationLine(DiskOperations.DelFilesFromDirectory(DiskOperations.DownLoadDirectory, _DefaultBackUpDbName, theBackUpFullPath, _DefaultDownloadFiles));

                //成功运行
                TransferService.SuccessFlag(theRuningStatusInSession);
            }
            catch(ApplicationException ae)
            {
                TryBackUpErrorClean();
                TransferService.FailedFlag(theRuningStatusInSession, ae.Message);
            }
            catch(Exception e)
            {
                TryBackUpErrorClean();
                TransferService.ErrorFlag(theRuningStatusInSession,e.Message);
            }
        }

        public void RestoreData(DateTime? fromDay, DateTime? toDay, RestoreStatus theRuningStatusInSession)
        {
            try
            {
                //配置所有过滤器
                TransferService.StartLittleProcess(theRuningStatusInSession, Utility._Process_ConfigFilter);
                ConfigAllRuleFitler();

                //检查所有数据库备份
                TransferService.StartLittleProcess(theRuningStatusInSession, Utility._Process_CheckAllDbBackUp);
                CheckAllDbBackUp();

                //每个数据库执行操作
                foreach (DbTransfer dt in _DbsToTransfer)
                {
                    dt.RestoreData(fromDay, toDay, theRuningStatusInSession);
                }

                //清理无用的数据
                TransferService.StartLittleProcess(theRuningStatusInSession, Utility._Process_CleanNonUseData);
                CommandRunner.CleanUpDirectory(DiskOperations.DataTemp_ForRestoreDirectory);

                //成功运行
                TransferService.SuccessFlag(theRuningStatusInSession);
            }
            catch(ApplicationException ae)
            {
                TryRestoreErrorClean();
                TransferService.FailedFlag(theRuningStatusInSession, ae.Message);
            }
            catch (Exception e)
            {
                TryRestoreErrorClean();
                TransferService.ErrorFlag(theRuningStatusInSession, e.Message);
            }
        }

        #endregion

        #region 私有方法

        private void CheckAllDbBackUp()
        {
            foreach (DbTransfer dt in _DbsToTransfer)
            {
                dt.CheckDbBackUpExist();
            }
        }

        private void ConfigAllRuleFitler()
        {
            foreach (DbTransfer dt in _DbsToTransfer)
            {
                dt.ConfigAllRuleFitler(this);
            }
        }

        private void TryRestoreErrorClean()
        {
            foreach (DbTransfer dt in _DbsToTransfer)
            {
                try
                {
                    dt.TryRestoreErrorClean();
                }
                catch (Exception ae)
                {
                    TransferDataLogManager.GetLogInstance.AddWarn(string.Format("{0}{1}/{2}", Utility._Error_CleanUpRestoreData, _RuleName, ae.Message));
                }
            }
            try
            {
                CommandRunner.CleanUpDirectory(DiskOperations.DataTemp_ForRestoreDirectory);
                CommandRunner.CleanUpDirectory(DiskOperations.TempDirectory);
            }
            catch (Exception ae)
            {
                TransferDataLogManager.GetLogInstance.AddWarn(string.Format("{0}{1}/{2}", Utility._Error_CleanUpRestoreData, _RuleName, ae.Message));
            }
        }

        private void TryBackUpErrorClean()
        {
            foreach (DbTransfer dt in _DbsToTransfer)
            {
                try
                {
                    dt.TryBackUpErrorClean();
                }
                catch (Exception ae)
                {
                    TransferDataLogManager.GetLogInstance.AddWarn(string.Format("{0}{1}/{2}", Utility._Error_CleanUpBackUpData, _RuleName, ae.Message));
                }
            }
            try
            {
                CommandRunner.CleanUpDirectory(DiskOperations.DataTemp_ForBackUpDirectory);
                CommandRunner.CleanUpDirectory(DiskOperations.TempDirectory);
            }
            catch (Exception ae)
            {
                TransferDataLogManager.GetLogInstance.AddWarn(string.Format("{0}{1}/{2}", Utility._Error_CleanUpBackUpData, _RuleName, ae.Message));
            }
        }

        #endregion

        #region ICloneable 成员

        public object Clone()
        {
            TransferRule aCloneObj = new TransferRule();
            aCloneObj._RuleName = _RuleName;
            foreach(DbTransfer dt in _DbsToTransfer)
            {
                aCloneObj._DbsToTransfer.Add(dt.Clone() as DbTransfer);
            }
            return aCloneObj;
        }

        public override string ToString()
        {
            StringBuilder theExplain = new StringBuilder();
            theExplain.AppendLine("规则说明");
            foreach (DbTransfer dt in _DbsToTransfer)
            {
                theExplain.Append(dt.ToString());
            }
            return theExplain.ToString();
        }

        #endregion
    }
}