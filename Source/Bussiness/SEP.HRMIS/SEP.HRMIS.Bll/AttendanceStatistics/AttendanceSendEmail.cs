//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: AttendanceSendEmail.cs
// 创建者: wangyueqi
// 创建日期: 2008-10-21
// 概述: 发Email给相关人
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.IBll.Mail;
using SEP.IBll;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Bll.AttendanceStatistics
{
    ///<summary>
    ///</summary>
    public class AttendanceSendEmail 
    {
        private static IMailGateWay _IMailGateWay =BllInstance.MailGateWayBllInstance;

        /// <summary>
        /// SendEmailForBulletin的构造函数，专为测试提供
        /// </summary>
        public AttendanceSendEmail(IMailGateWay mockMail)
        {
            _IMailGateWay = mockMail;
        }
        ///<summary>
        ///</summary>
        public AttendanceSendEmail()
        {
        }

        ///<summary>
        ///</summary>
        ///<param name="_EmployeeName"></param>
        ///<param name="_InTime"></param>
        ///<param name="_OutTime"></param>
        ///<param name="_Status"></param>
        ///<param name="_SearchFrom"></param>
        ///<param name="_SearchTo"></param>
        ///<param name="_TO"></param>
        ///<param name="_Cc"></param>
        public void AttendanceSendEmailToEmployee(string _EmployeeName, string _InTime,
            string _OutTime, string _Status,
            string _SearchFrom, string _SearchTo, List<string> _TO, List<string> _Cc, Account loginUser)
        {
            //组装发信的基本信息
            string subject = _EmployeeName + _SearchFrom + "--" +_SearchTo+ "期间的考勤信息";
            StringBuilder emailContentBuilder = new StringBuilder();
            emailContentBuilder.Append("进入时间：");
            emailContentBuilder.Append(_InTime == "2999-12-31 0:00:00" ? "无打卡记录" : _InTime);
            emailContentBuilder.Append(Environment.NewLine);

            emailContentBuilder.Append("离开时间：");
            emailContentBuilder.Append(_OutTime == "1900-1-1 0:00:00" ? "无打卡记录" : _OutTime);
            emailContentBuilder.Append(Environment.NewLine);

            emailContentBuilder.Append("考勤情况：");
            emailContentBuilder.Append(String.IsNullOrEmpty(_Status)? "无" : _Status);
            emailContentBuilder.Append(Environment.NewLine);

            emailContentBuilder.Append("请核对打卡信息和外出请假情况，如果信息有误，请通知人力资源部或登录系统查看！");
            MailBody mailBody=new MailBody();
            mailBody.MailTo = _TO;
            mailBody.Subject = subject;
            mailBody.MailCc = _Cc;
            mailBody.Body = emailContentBuilder.ToString();

            _IMailGateWay.Send(mailBody, true);
        }


        ///<summary>
        /// 
        ///</summary>
        ///<param name="subject"></param>
        ///<param name="emailContentBuilder"></param>
        public void AttendanceSendEmailToHR(string subject, StringBuilder emailContentBuilder)
        {
            IMailSource _IMailSource = BllInstance.MailSourceBllInstance;
            List<string> _TO = new List<string>();
            _TO.Add(_IMailSource.GetHrLeaderMail());

            List<string> _Cc = new List<string>();
            _Cc.Add(_IMailSource.GetHrLeaderMail2());
            _Cc.AddRange(_IMailSource.GetHrManagerMails());
            _Cc.AddRange(_IMailSource.GetHrAssistantMails());
            _Cc.AddRange(_IMailSource.GetHrCommissionerMails());

            //组装发信的基本信息
            MailBody mailBody = new MailBody();
            mailBody.MailTo = _TO;
            mailBody.Subject = subject;
            mailBody.MailCc = _Cc;
            mailBody.Body = emailContentBuilder.ToString();
            _IMailGateWay.Send(mailBody, true);

        }

    }
}
