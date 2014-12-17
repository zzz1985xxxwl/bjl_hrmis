//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: TransferService.cs
// ������: �ߺ�
// ��������: 2009-05-6
// ����: ����Ǩ�Ƶķ���ӿ�
// ----------------------------------------------------------------
using System;

namespace TransferDatas
{
    public class TransferService
    {
        private static bool _RunningFlag;
        private delegate void BackUpProcess(TransferRule rule, DateTime? fromDay, DateTime? toDay, BackUpStatus theRuningStatusInSession);
        private delegate void RestoreProcess(TransferRule rule, DateTime? fromDay, DateTime? toDay, RestoreStatus theRuningStatusInSession);

        public static void BackUpData(string ruleName, DateTime? fromDay, DateTime? toDay, BackUpStatus theRuningStatusInSession)
        {
            StartFlag(theRuningStatusInSession);

            try
            {
                //���뾲̬���ñ�
                StartLittleProcess(theRuningStatusInSession, StaticConfigTable.ReadToTableToString());
                StaticConfigTable.ReadToTable();

                //׼�������ļ���
                StartLittleProcess(theRuningStatusInSession, DiskOperations.PrepareForBackUpToString());
                DiskOperations.PrepareForBackUp();

                //���Rarѹ����
                StartLittleProcess(theRuningStatusInSession, CommandRunner.CheckRarReadyToString());
                CommandRunner.CheckRarReady();

                //������־����
                StartLittleProcess(theRuningStatusInSession, TransferDataLogManager.TryConfigLogObjToString());
                TransferDataLogManager.TryConfigLogObj();

                //���ݹ����������߳̿�ʼ����
                StartLittleProcess(theRuningStatusInSession, RulesPool.FindRuleByNameToString());
                //��Ҫ��¡��ԭ������RulesPool�Ǿ�̬�ģ��ϴ����еĶ����Ӱ���´ε�����
                TransferRule tr = RulesPool.FindRuleByName(ruleName);
                BackUpProcess bup = StartBackUp;
                bup.BeginInvoke(tr.Clone() as TransferRule, fromDay, toDay, theRuningStatusInSession, null, null);
            }
            catch (ApplicationException ae)
            {
                FailedFlag(theRuningStatusInSession, ae.Message);
            }
        }

        public static TransferRule AnalyseRarData(string theRarFile, out DateTime? fromDay, out DateTime? toDay)
        {
            StaticConfigTable.ReadToTable();
            DiskOperations.PrepareForBackUp();
            return TransferConfig.AnalyseRarData(theRarFile, out fromDay, out toDay, DiskOperations.TempDirectory, true,true);
        }

        public static void RestoreData(string theRarFile, RestoreStatus theRuningStatusInSession)
        {
            StartFlag(theRuningStatusInSession);

            try
            {
                //���뾲̬���ñ�
                StartLittleProcess(theRuningStatusInSession, StaticConfigTable.ReadToTableToString());
                StaticConfigTable.ReadToTable();

                //׼�������ļ���
                StartLittleProcess(theRuningStatusInSession, DiskOperations.PrepareForRestoreToString());
                DiskOperations.PrepareForRestore();

                //���Rarѹ����
                StartLittleProcess(theRuningStatusInSession, CommandRunner.CheckRarReadyToString());
                CommandRunner.CheckRarReady();

                //������־����
                StartLittleProcess(theRuningStatusInSession, TransferDataLogManager.TryConfigLogObjToString());
                TransferDataLogManager.TryConfigLogObj();

                //����Rar����
                StartLittleProcess(theRuningStatusInSession, TransferConfig.AnalyseRarDataToString());
                DateTime? fromDay;
                DateTime? toDay;
                TransferRule theTransferRule = TransferConfig.AnalyseRarData(theRarFile, out fromDay, out toDay, DiskOperations.DataTemp_ForRestoreDirectory, false,false);

                //���ݹ����������߳̿�ʼ����
                RestoreProcess rp = StartRestore;
                rp.BeginInvoke(theTransferRule, fromDay, toDay, theRuningStatusInSession,null,null);
            }
            catch (ApplicationException ae)
            {
                FailedFlag(theRuningStatusInSession, ae.Message);
            }
        }

        public static void ResetAllRules()
        {
            RulesPool.ResetAllRules();
        }

        #region ˽�з���

        private static void StartBackUp(TransferRule rule, DateTime? fromDay, DateTime? toDay, BackUpStatus theRuningStatusInSession)
        {
            rule.BackUpData(fromDay, toDay, theRuningStatusInSession);
       
        }

        private static void StartRestore(TransferRule rule, DateTime? fromDay, DateTime? toDay, RestoreStatus theRuningStatusInSession)
        {
            rule.RestoreData(fromDay, toDay, theRuningStatusInSession);
        }

        public static void StartFlag(RunningStatus theRuningStatusInSession)
        {
            if (_RunningFlag)
            {
                throw new ApplicationException(Utility._Error_RunningFlag_NotFit);
            }

            _RunningFlag = true;
            theRuningStatusInSession.Status = Status.Running;
            theRuningStatusInSession.StartTime = DateTime.Now.ToString();
            theRuningStatusInSession.AddInformationLine(Utility._Process_Start);

            TransferDataLogManager.GetLogInstance.AddInfo(string.Format("��ʼִ�У�{0}", theRuningStatusInSession.OperationDescription));
        }

        public static void FailedFlag(RunningStatus theRuningStatusInSession, string errorMessage)
        {
            _RunningFlag = false;
            theRuningStatusInSession.Status = Status.Failed;
            theRuningStatusInSession.EndTime = DateTime.Now.ToString();
            theRuningStatusInSession.AddInformationLine(Utility.MakeRunningErrorMsg(errorMessage));

            TransferDataLogManager.GetLogInstance.AddError(string.Format("ʧ��ִ�У�{0}{1}��ϸ��Ϣ�ǣ�{2}", theRuningStatusInSession.OperationDescription,Environment.NewLine, theRuningStatusInSession.RunningDetails));
        }

        public static void ErrorFlag(RunningStatus theRuningStatusInSession, string exceptionMessage)
        {
            _RunningFlag = false;
            theRuningStatusInSession.Status = Status.Error;
            theRuningStatusInSession.EndTime = DateTime.Now.ToString();
            theRuningStatusInSession.AddInformationLine(Utility.MakeRunningExceptionMsg(exceptionMessage));

            TransferDataLogManager.GetLogInstance.AddError(string.Format("������δ�ڿ��Ʒ�Χ�ڵ����ش���{0}{1}��ϸ��Ϣ�ǣ�{2}", theRuningStatusInSession.OperationDescription, Environment.NewLine, theRuningStatusInSession.RunningDetails));
        }

        public static void SuccessFlag(RunningStatus theRuningStatusInSession)
        {
            _RunningFlag = false;
            theRuningStatusInSession.Status = Status.Success;
            theRuningStatusInSession.EndTime = DateTime.Now.ToString();
            theRuningStatusInSession.AddInformationLine(Utility._Process_Success);

            TransferDataLogManager.GetLogInstance.AddInfo(string.Format("�ɹ�ִ�У�{0}{1}��ϸ��Ϣ�ǣ�{2}", theRuningStatusInSession.OperationDescription, Environment.NewLine, theRuningStatusInSession.RunningDetails));
        }

        public static void StartLittleProcess(RunningStatus theRuningStatusInSession, string processName)
        {
            theRuningStatusInSession.AddInformationLine(string.Format("��ʼ����{0}", processName));
        }

        #endregion
    }
}
