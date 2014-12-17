//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: TransferService.cs
// 创建者: 倪豪
// 创建日期: 2009-05-6
// 概述: 数据迁移的服务接口
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
                //读入静态配置表
                StartLittleProcess(theRuningStatusInSession, StaticConfigTable.ReadToTableToString());
                StaticConfigTable.ReadToTable();

                //准备所需文件夹
                StartLittleProcess(theRuningStatusInSession, DiskOperations.PrepareForBackUpToString());
                DiskOperations.PrepareForBackUp();

                //检查Rar压缩器
                StartLittleProcess(theRuningStatusInSession, CommandRunner.CheckRarReadyToString());
                CommandRunner.CheckRarReady();

                //配置日志对象
                StartLittleProcess(theRuningStatusInSession, TransferDataLogManager.TryConfigLogObjToString());
                TransferDataLogManager.TryConfigLogObj();

                //根据规则起另外线程开始工作
                StartLittleProcess(theRuningStatusInSession, RulesPool.FindRuleByNameToString());
                //需要克隆的原因在于RulesPool是静态的，上次运行的对象会影响下次的运行
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
                //读入静态配置表
                StartLittleProcess(theRuningStatusInSession, StaticConfigTable.ReadToTableToString());
                StaticConfigTable.ReadToTable();

                //准备所需文件夹
                StartLittleProcess(theRuningStatusInSession, DiskOperations.PrepareForRestoreToString());
                DiskOperations.PrepareForRestore();

                //检查Rar压缩器
                StartLittleProcess(theRuningStatusInSession, CommandRunner.CheckRarReadyToString());
                CommandRunner.CheckRarReady();

                //配置日志对象
                StartLittleProcess(theRuningStatusInSession, TransferDataLogManager.TryConfigLogObjToString());
                TransferDataLogManager.TryConfigLogObj();

                //解析Rar数据
                StartLittleProcess(theRuningStatusInSession, TransferConfig.AnalyseRarDataToString());
                DateTime? fromDay;
                DateTime? toDay;
                TransferRule theTransferRule = TransferConfig.AnalyseRarData(theRarFile, out fromDay, out toDay, DiskOperations.DataTemp_ForRestoreDirectory, false,false);

                //根据规则起另外线程开始工作
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

        #region 私有方法

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

            TransferDataLogManager.GetLogInstance.AddInfo(string.Format("开始执行：{0}", theRuningStatusInSession.OperationDescription));
        }

        public static void FailedFlag(RunningStatus theRuningStatusInSession, string errorMessage)
        {
            _RunningFlag = false;
            theRuningStatusInSession.Status = Status.Failed;
            theRuningStatusInSession.EndTime = DateTime.Now.ToString();
            theRuningStatusInSession.AddInformationLine(Utility.MakeRunningErrorMsg(errorMessage));

            TransferDataLogManager.GetLogInstance.AddError(string.Format("失败执行：{0}{1}详细信息是：{2}", theRuningStatusInSession.OperationDescription,Environment.NewLine, theRuningStatusInSession.RunningDetails));
        }

        public static void ErrorFlag(RunningStatus theRuningStatusInSession, string exceptionMessage)
        {
            _RunningFlag = false;
            theRuningStatusInSession.Status = Status.Error;
            theRuningStatusInSession.EndTime = DateTime.Now.ToString();
            theRuningStatusInSession.AddInformationLine(Utility.MakeRunningExceptionMsg(exceptionMessage));

            TransferDataLogManager.GetLogInstance.AddError(string.Format("出现了未在控制范围内的严重错误：{0}{1}详细信息是：{2}", theRuningStatusInSession.OperationDescription, Environment.NewLine, theRuningStatusInSession.RunningDetails));
        }

        public static void SuccessFlag(RunningStatus theRuningStatusInSession)
        {
            _RunningFlag = false;
            theRuningStatusInSession.Status = Status.Success;
            theRuningStatusInSession.EndTime = DateTime.Now.ToString();
            theRuningStatusInSession.AddInformationLine(Utility._Process_Success);

            TransferDataLogManager.GetLogInstance.AddInfo(string.Format("成功执行：{0}{1}详细信息是：{2}", theRuningStatusInSession.OperationDescription, Environment.NewLine, theRuningStatusInSession.RunningDetails));
        }

        public static void StartLittleProcess(RunningStatus theRuningStatusInSession, string processName)
        {
            theRuningStatusInSession.AddInformationLine(string.Format("开始任务：{0}", processName));
        }

        #endregion
    }
}
