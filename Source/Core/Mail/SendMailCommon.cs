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
        //�ʼ�����
        private MailBody _MailBody;

        //�ڱ����޷����ͳɹ�Mailʱ���Խ�LogWay���ó�HardDisk��Ӳ�̵õ��ʼ����͵�����
        //�ڲ����ʼ���ʱ�򣬿��Խ�LogWay���ó�Memory�����ڴ���ֱ�Ӷ�ȡ���͵��ʼ�
        public static List<MailBody> _RecordList = new List<MailBody>();
        public static LogWays _Logway = LogWays.NoLogs;
        //��¼���������log��aspnet��Ҫ��д��Ȩ��
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
                throw new ApplicationException("���ŵ�ַ����Ϊ��");
            }
            if (string.IsNullOrEmpty(_MailBody.Subject))
            {
                throw new ApplicationException("�ʼ����ⲻ��Ϊ��");
            }
            if (string.IsNullOrEmpty(_MailBody.Body))
            {
                throw new ApplicationException("�ʼ����Ĳ���Ϊ��");
            }
            if (string.IsNullOrEmpty(_SMTPHost))
            {
                throw new ApplicationException("����������Ϊ��");
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
                //��ʼ��NotesDatabase
                ndb = ns.GetDatabase(_SMTPHost, "names.nsf", false);

                NotesDocument doc = ndb.CreateDocument();

                doc.ReplaceItemValue("Form", "Memo");

                //�ռ�����Ϣ
                doc.ReplaceItemValue("SendTo", ConvertToString(_MailBody.MailTo));

                if (_MailBody.MailCc != null && _MailBody.MailCc.Count > 0)
                {
                    doc.ReplaceItemValue("CopyTo", ConvertToString(_MailBody.MailCc));
                }

                if (_MailBody.MailBcc != null && _MailBody.MailBcc.Count > 0)
                {
                    doc.ReplaceItemValue("BlindCopyTo", ConvertToString(_MailBody.MailBcc));
                }

                //�ʼ�����
                doc.ReplaceItemValue("Subject", _MailBody.Subject);

                //�ʼ�����
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

                //����
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
                //�����ʼ�
                object obj = doc.GetItemValue("SendTo");
                doc.Send(false, ref obj);
                doc = null;
                return "";
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    HandleMailLogs(ex.Message + "�ڲ�������ϢΪ��null");
                }
                else
                {
                    HandleMailLogs(ex.Message + "�ڲ�������ϢΪ��" + ex.InnerException.Message);
                }
                return "�����ʼ�ʧ��";
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

        #region ��־��¼

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
                        sb.Append(ma).Append("��");
                    }
                }
                StringBuilder st = new StringBuilder();
                foreach (string s in _MailBody.MailTo)
                {
                    st.Append(s).Append("��");
                }
                return
                    string.Format("������{0}\r���͸���{1}\r�����ǣ�{2}\r����Ϊ��{3}\rʱ���ǣ�{4}", st, sb,
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
                    theComboMessage.AppendLine().Append("������Ϣ�ǣ�").Append(errorMessage).AppendLine().Append(
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
        /// �����¼Email�ļ��ַ�ʽ
        /// </summary>
        public enum LogWays
        {
            //����Ҫ��¼�ʼ��������ݣ���������
            NoLogs,
            //��¼��Ӳ���ϵ�C:\mail.txt�ļ���
            HardDisk,
            //��¼���ڴ��У�ͨ��MailGateWay.RecordList����
            Memory,
            //��¼��Ӳ�����ڴ�
            HardDiskAndMemory,
        }

        #endregion
    }
}