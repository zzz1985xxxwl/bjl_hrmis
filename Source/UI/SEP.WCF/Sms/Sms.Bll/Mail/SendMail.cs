using System;
using System.Collections.Generic;
using Domino;
using Framework.Common;
using Sms.Entity;

namespace Sms.Bll.Mail
{
    public class SendMail
    {
        public static List<MailBody> _RecordList = new List<MailBody>();
        private MailBody _MailBody;
        private MailSettings _MailSet;

        private void InitSettings()
        {
            //_SMTPHost = "cnshan01/shanghai/cn/b&r";

            string isLog = ConfigReader.GetConfig("app", "Mail/Log");
            string systemMailAddress = ConfigReader.GetConfig("app", "Mail/SYSTEMMAILADDRESS");
            string systemMailCommand = ConfigReader.GetConfig("app", "Mail/SYSTEMMAILCOMMAND");
            string smtpHost = ConfigReader.GetConfig("app", "Mail/SMTPHOST");
            string userNameMailAddress = ConfigReader.GetConfig("app", "Mail/USERNAMEMAILADDRESS");
            string userNamePassword = ConfigReader.GetConfig("app", "Mail/USERNAMEPASSWORD");

            _MailSet = new MailSettings(isLog, systemMailAddress, systemMailCommand,
                                        smtpHost, userNameMailAddress,
                                        userNamePassword, true);

        }

        private void Validation()
        {
            if (_MailBody.MailTo == null || _MailBody.MailTo.Count == 0)
            {
                throw new ApplicationException("收信地址不能为空");
            }
            if (string.IsNullOrEmpty(_MailBody.Subject))
            {
                throw new ApplicationException("邮件标题不能为空");
            }
            if (string.IsNullOrEmpty(_MailBody.Body))
            {
                throw new ApplicationException("邮件正文不能为空");
            }
            if (string.IsNullOrEmpty(_MailSet.SMTPHost))
            {
                throw new ApplicationException("服务器不能为空");
            }
        }

        public string Send(MailBody mailBody)
        {
            _MailBody = mailBody;
            InitSettings();
            Validation();
            NotesSession ns;
            NotesDatabase ndb;
            try
            {
                ns = new NotesSession();
                ns.Initialize(_MailSet.Password);
                //初始化NotesDatabase
                ndb = ns.GetDatabase(_MailSet.SMTPHost, "names.nsf", false);

                NotesDocument doc = ndb.CreateDocument();

                doc.ReplaceItemValue("Form", "Memo");

                //收件人信息
                doc.ReplaceItemValue("SendTo", ConvertToString(_MailBody.MailTo));

                if (_MailBody.MailCc != null && _MailBody.MailCc.Count > 0)
                {
                    doc.ReplaceItemValue("CopyTo", ConvertToString(_MailBody.MailCc));
                }

                if (_MailBody.MailBcc != null && _MailBody.MailBcc.Count > 0)
                {
                    doc.ReplaceItemValue("BlindCopyTo", ConvertToString(_MailBody.MailBcc));
                }

                //邮件主题
                doc.ReplaceItemValue("Subject", _MailBody.Subject);

                //邮件正文
                if (_MailBody.IsHtmlBody)
                {
                    NotesStream body = ns.CreateStream();
                    body.WriteText(_MailBody.Body, EOL_TYPE.EOL_PLATFORM);
                    NotesMIMEEntity mime = doc.CreateMIMEEntity("Body");
                    mime.SetContentFromText(body, "text/HTML;charset=gb2312", MIME_ENCODING.ENC_NONE);
                    body.Truncate();
                }
                else
                {
                    NotesRichTextItem rt = doc.CreateRichTextItem("Body");
                    rt.AppendText(_MailBody.Body);
                }

                //发送邮件
                object obj = doc.GetItemValue("SendTo");
                doc.Send(false, ref obj);
                doc = null;
                return "";
            }
            catch (Exception ex)
            {
                Log.Write(ex);
                return "发送邮件失败";
            }
            finally
            {
                ndb = null;
                ns = null;
            }
        }

        public static string[] ConvertToString(IEnumerable<string> strlist)
        {
            int i = 0;
            foreach (string s in strlist)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    i++;
                }
            }
            var ret = new string[i];
            int j = 0;
            foreach (string s in strlist)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    ret[j] = s;
                    j++;
                }
            }
            return ret;
        }

      
    }
}