using System;
using System.Collections.Generic;
using System.Text;

namespace TransferDatas
{
    public class TransferRule:ICloneable
    {
        private const string _DefaultBackUpDbName = "DataBackUp";
        //�����ļ��б��ֵ������ļ�������
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

        #region ����

        /// <summary>
        /// �����Ч��
        /// </summary>
        /// <param name="ruleName">��������</param>
        /// <param name="ruleString">������ַ���</param>
        public void Check(string ruleName, string ruleString)
        {
            //���ȼ��ǿյ��ֶ�
            Utility.AssertStringNotEmpty(_RuleName, Utility._Error_XmlConfig_TransferRule_KeyEmpty);
            foreach(DbTransfer aDbTransfer in _DbsToTransfer)
            {
                aDbTransfer.Check(_RuleName);
            }
            //�ټ������������ַ����Ƿ�һ��
            Utility.AssertAreSame(ruleString, MakeString(), string.Format("{0}\nԭʼ�ַ���{1}\n��ȡ�Ĺ����ַ���{2}", Utility._Error_XmlConfig_Read_NotFit, ruleString, MakeString()));
        }

        /// <summary>
        /// ����ǰ����תΪ�����ַ���
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
        /// ���������Ĺ���,������ҪѰ����Ӧ��dll�У�ʵ������Ӧ�Ľӿڣ�����Ҫ�Ķ�����װ����
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
        /// ��ȡ�ù����Ƿ���Ҫʱ�����
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
                //д��Ǩ�������ļ�
                TransferService.StartLittleProcess(theRuningStatusInSession, TransferConfig.WriteConfigToString());
                TransferConfig.WriteConfig(this, fromDay, toDay);

                //�������й�����
                TransferService.StartLittleProcess(theRuningStatusInSession, Utility._Process_ConfigFilter);
                ConfigAllRuleFitler();
                
                //ÿ�����ݿ�ִ�в���
                foreach(DbTransfer dt in _DbsToTransfer)
                {
                    dt.BackUpData(fromDay, toDay, theRuningStatusInSession);
                }

                //��������ļ�
                TransferService.StartLittleProcess(theRuningStatusInSession, Utility._Process_RarBackUpFile);
                string theBackUpSimpleName = string.Format("{0}{1}.rar", _DefaultBackUpDbName, Utility.GetTimeStamp());
                string theBackUpFullPath = string.Format("{0}{1}", DiskOperations.DownLoadDirectory, theBackUpSimpleName);
                CommandRunner.RarDirectoryToFile(theBackUpFullPath, DiskOperations.DataTemp_ForBackUpDirectory);
                theRuningStatusInSession.SuccessFileName = theBackUpSimpleName;
                theRuningStatusInSession.SuccessFullFileName = theBackUpFullPath;

                //�������õ�����
                TransferService.StartLittleProcess(theRuningStatusInSession, Utility._Process_CleanNonUseData);
                CommandRunner.CleanUpDirectory(DiskOperations.DataTemp_ForBackUpDirectory);
                theRuningStatusInSession.AddInformationLine(DiskOperations.DelFilesFromDirectory(DiskOperations.DownLoadDirectory, _DefaultBackUpDbName, theBackUpFullPath, _DefaultDownloadFiles));

                //�ɹ�����
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
                //�������й�����
                TransferService.StartLittleProcess(theRuningStatusInSession, Utility._Process_ConfigFilter);
                ConfigAllRuleFitler();

                //����������ݿⱸ��
                TransferService.StartLittleProcess(theRuningStatusInSession, Utility._Process_CheckAllDbBackUp);
                CheckAllDbBackUp();

                //ÿ�����ݿ�ִ�в���
                foreach (DbTransfer dt in _DbsToTransfer)
                {
                    dt.RestoreData(fromDay, toDay, theRuningStatusInSession);
                }

                //�������õ�����
                TransferService.StartLittleProcess(theRuningStatusInSession, Utility._Process_CleanNonUseData);
                CommandRunner.CleanUpDirectory(DiskOperations.DataTemp_ForRestoreDirectory);

                //�ɹ�����
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

        #region ˽�з���

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

        #region ICloneable ��Ա

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
            theExplain.AppendLine("����˵��");
            foreach (DbTransfer dt in _DbsToTransfer)
            {
                theExplain.Append(dt.ToString());
            }
            return theExplain.ToString();
        }

        #endregion
    }
}