//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SendMailCommon.cs
// Creater:  Xue.wenlong
// Date:  2009-03-19
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Domino;
using Mail.Model;

namespace Mail
{
    public class SendMailCommon
    {
        //邮件内容
        private MailBody _MailBody;

        //在本机无法发送成功Mail时可以将LogWay设置成HardDisk在硬盘得到邮件发送的内容
        //在测试邮件的时候，可以将LogWay设置成Memory，在内存中直接读取发送的邮件
        public static List<MailBody> _RecordList = new List<MailBody>();
        public static LogWays _Logway = LogWays.NoLogs;
        //记录发生错误的log，aspnet需要有写的权限
        private string _LogForMail;
        // private string _SystemMailAddress;
        // private string _SystemMailCommand;
        private string _SMTPHost;
        //private string _UserName;
        private string _Password;

        private void InitSettings(MailSettings mailSettings)
        {
            _LogForMail = mailSettings.LogForMail;
            // _SystemMailAddress = mailSettings.SystemMailAddress;
            // _SystemMailCommand = mailSettings.SystemMailCommand;
            _SMTPHost = "cnshan01/shanghai/cn/b&r";
            // _UserName = mailSettings.UserName;
            _Password = mailSettings.Password;//"7AsHs9wD";
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
            if (string.IsNullOrEmpty(_SMTPHost))
            {
                throw new ApplicationException("服务器不能为空");
            }
        }

        public string SendMail(MailBody mailBody, MailSettings mailSettings)
        {
            _MailBody = mailBody;
            InitSettings(mailSettings);

            Validation();
            NotesSession ns;
            NotesDatabase ndb;
            try
            {
                ns = new NotesSession();
                ns.Initialize(_Password);
                //初始化NotesDatabase
                ndb = ns.GetDatabase(_SMTPHost, "names.nsf", false);

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

                //NotesRichTextItem rt = doc.CreateRichTextItem("Body");
                //if (_MailBody.IsHtmlBody)
                //{
                //    NotesRichTextStyle richtextStyle = ns.CreateRichTextStyle();
                //    richtextStyle.PassThruHTML = 1;
                //    rt.AppendStyle(richtextStyle);
                //}
                //rt.AppendText(_MailBody.Body);

                //附件
                //if (_MailBody.MailAttachments != null)
                //{
                //    NotesRichTextItem attachment = doc.CreateRichTextItem("attachment");
                //    foreach (MailAttachment a in _MailBody.MailAttachments)
                //    {
                //        if (!string.IsNullOrEmpty(a.Location))
                //        {
                //            attachment.EmbedObject(EMBED_TYPE.EMBED_ATTACHMENT, "", a.Location, "attachment");
                //        }
                //    }
                //}
                //发送邮件
                object obj = doc.GetItemValue("SendTo");
                doc.Send(false, ref obj);
                doc = null;
                return "";
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    HandleMailLogs(ex.Message + "内部错误信息为：null");
                }
                else
                {
                    HandleMailLogs(ex.Message + "内部错误信息为：" + ex.InnerException.Message);
                }
                return "发送邮件失败";
            }
            finally
            {
                ndb = null;
                ns = null;
                RecordTheMail();
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
            string[] ret = new string[i];
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

        #region 日志记录

        private void RecordTheMail()
        {
            switch (_Logway)
            {
                case LogWays.NoLogs:
                    break;
                case LogWays.HardDisk:
                    RecordTheMessageToHardDisk();
                    break;
                case LogWays.Memory:
                    RecordTheMessageToMemory();
                    break;
                case LogWays.HardDiskAndMemory:
                    RecordTheMessageToHardDisk();
                    RecordTheMessageToMemory();
                    break;
                default:
                    break;
            }
        }

        private void RecordTheMessageToHardDisk()
        {
            const string fileName = @"C:\mail.txt";
            try
            {
                StreamWriter sw = new StreamWriter(fileName, true);
                sw.WriteLine(ThisMessageToText);
                sw.WriteLine("--------------------------------");
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        private void RecordTheMessageToMemory()
        {
            _RecordList.Add(_MailBody);
        }

        private string ThisMessageToText
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (_MailBody.MailCc!=null)
                {
                    foreach (string ma in _MailBody.MailCc)
                    {
                        sb.Append(ma).Append("，");
                    }
                }
                StringBuilder st = new StringBuilder();
                foreach (string s in _MailBody.MailTo)
                {
                    st.Append(s).Append("，");
                }
                return
                    string.Format("发给：{0}\r抄送给：{1}\r主题是：{2}\r内容为：{3}\r时间是：{4}", st, sb,
                                  _MailBody.Subject, _MailBody.Body, DateTime.Now);
            }
        }

        private void HandleMailLogs(string errorMessage)
        {
            bool needLog;
            if (bool.TryParse(_LogForMail, out needLog))
            {
                if (needLog)
                {
                    StringBuilder theComboMessage = new StringBuilder(ThisMessageToText);
                    theComboMessage.AppendLine().Append("错误信息是：").Append(errorMessage).AppendLine().Append(
                        "---------------------------").AppendLine();

                    try
                    {
                        StreamWriter sw = new StreamWriter(@"c:\faildMails.txt", true);
                        sw.WriteLine(theComboMessage.ToString());
                        sw.Flush();
                        sw.Close();
                    }
                    catch
                    {
                    }
                }
            }
        }

        /// <summary>
        /// 定义记录Email的几种方式
        /// </summary>
        public enum LogWays
        {
            //不需要记录邮件发送内容，正常发送
            NoLogs,
            //记录在硬盘上的C:\mail.txt文件内
            HardDisk,
            //记录在内存中，通过MailGateWay.RecordList访问
            Memory,
            //记录在硬盘与内存
            HardDiskAndMemory,
        }

        #endregion
    }
}