//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: SystemReadDataServer.cs
// 创建者:wang.yueqi
// 创建日期: 2008-10-23
// 概述: 系统自动读取数据事件
// ----------------------------------------------------------------
using System;
using System.Configuration;
using System.ServiceProcess;
using System.Timers;
using SEP.HRMIS.Facade;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;
using SEP.Model.Utility;

namespace SEP.ReadExternalAttendanceData
{
    public partial class SystemReadDataServer : ServiceBase
    {
        private static string strErrorMsg;
        public SystemReadDataServer()
        {
            InitializeComponent();
            CompanyConfig.FileName = AppDomain.CurrentDomain.BaseDirectory;

        }
        //每隔一分钟
        private void tTrack_Elapsed(object sender, ElapsedEventArgs e)
        {
            strErrorMsg = "";
            tTrack.Stop();
            try
            {
                AutoSystemRead();
                AutoSystemReadFromSetTime();
                if (!String.IsNullOrEmpty(strErrorMsg))
                {
                    throw new Exception(strErrorMsg);
                }
            }
            catch (Exception ex)
            {
                // 错误信息
                strErrorMsg = "异常：\n" + ex.Message;
                //// 写日志
                TLineEventLog el = new TLineEventLog();
                el.DoWriteEventLog(strErrorMsg, EventType.Error);
            }
            tTrack.Start();
        }

        private static void AutoSystemRead()
        {
            try
            {
                string _IsAutoSystemRead = ConfigurationManager.AppSettings["IsAutoSystemRead"];
                string str_SystemReadTime = ConfigurationManager.AppSettings["SystemReadTime"];
                string[] dt_SystemReadTime = str_SystemReadTime.Split(':');
                DateTime dt_Now = DateTime.Now;
                if (_IsAutoSystemRead == "true" &&
                    dt_SystemReadTime[0].Equals(dt_Now.Hour.ToString()) &&
                    dt_SystemReadTime[1].Equals(dt_Now.Minute.ToString()))
                {
                    ReadDataHistory readNewHistory = new ReadDataHistory(DateTime.Now, ReadDataResultType.Reading,"");
                    (new ReadExternalDataFacade()).SystemReadDataFromAccessToSQL(readNewHistory,new Account());
                }
            }
            catch (Exception ex)
            {
                strErrorMsg += "Execute Error: " + ex.Message + "\n";
            }
        }
        private static void AutoSystemReadFromSetTime()
        {
            try
            {
                string _IsAutoSystemReadFromSetTime =
                    ConfigurationManager.AppSettings["IsAutoSystemReadFromSetTime"];
                if (_IsAutoSystemReadFromSetTime == "true")
                {
                    (new ReadExternalDataFacade()).SystemReadDataFromSetTime(new Account());
                }
            }
            catch (Exception ex)
            {
                strErrorMsg += "Execute Error: " + ex.Message + "\n";
            }
        }
    }
}