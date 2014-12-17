//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: AttendanceSendEmail.cs
// ������: wangyueqi
// ��������: 2008-10-21
// ����: ��Email�������
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
        /// SendEmailForBulletin�Ĺ��캯����רΪ�����ṩ
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
            //��װ���ŵĻ�����Ϣ
            string subject = _EmployeeName + _SearchFrom + "--" +_SearchTo+ "�ڼ�Ŀ�����Ϣ";
            StringBuilder emailContentBuilder = new StringBuilder();
            emailContentBuilder.Append("����ʱ�䣺");
            emailContentBuilder.Append(_InTime == "2999-12-31 0:00:00" ? "�޴򿨼�¼" : _InTime);
            emailContentBuilder.Append(Environment.NewLine);

            emailContentBuilder.Append("�뿪ʱ�䣺");
            emailContentBuilder.Append(_OutTime == "1900-1-1 0:00:00" ? "�޴򿨼�¼" : _OutTime);
            emailContentBuilder.Append(Environment.NewLine);

            emailContentBuilder.Append("���������");
            emailContentBuilder.Append(String.IsNullOrEmpty(_Status)? "��" : _Status);
            emailContentBuilder.Append(Environment.NewLine);

            emailContentBuilder.Append("��˶Դ���Ϣ������������������Ϣ������֪ͨ������Դ�����¼ϵͳ�鿴��");
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

            //��װ���ŵĻ�����Ϣ
            MailBody mailBody = new MailBody();
            mailBody.MailTo = _TO;
            mailBody.Subject = subject;
            mailBody.MailCc = _Cc;
            mailBody.Body = emailContentBuilder.ToString();
            _IMailGateWay.Send(mailBody, true);

        }

    }
}
