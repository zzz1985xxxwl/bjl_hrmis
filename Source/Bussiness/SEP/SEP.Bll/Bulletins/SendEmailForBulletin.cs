//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SendEmailForBulletin.cs
// 创建者: 王玥琦
// 创建日期: 2008-05-23
// 概述: 因为发布公告发Email给相关人
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Mail.Model;
using SEP.Bll.Mail;
using SEP.IBll.Mail;
using SEP.IDal;
using SEP.IDal.Bulletins;
using SEP.Model;
using SEP.Model.Bulletins;

namespace SEP.Bll.Bulletins
{
    public class SendEmailForBulletin : Transaction
    {
        private static IBulletinDal _BulletinDal = DalInstance.BulletinDalInstance;
        private static readonly IMailGateWay _MailGateWay = new MailGateWay();

        private Bulletin _Bulletin;
        private readonly int _BulletinID;
        private readonly string _To;
        private readonly List<string> _Cc;

        /// <summary>
        /// SendEmailForBulletin的构造函数，专为测试提供
        /// </summary>
        public SendEmailForBulletin(int bulletinID, string to, List<string> cc, IBulletinDal mockDal)
        {
            _BulletinID = bulletinID;
            _To = to;
            _Cc = cc;
            _BulletinDal = mockDal;
        }

        public SendEmailForBulletin(int bulletinID, string to, List<string> cc)
        {
            _BulletinID = bulletinID;
            _To = to;
            _Cc = cc;
        }

        protected override void ExcuteSelf()
        {
            //组装发信的基本信息
            string subject = "发布公告：" + _Bulletin.Title;
            StringBuilder emailContentBuilder = new StringBuilder();
            emailContentBuilder.Append("发布公告时间");
            emailContentBuilder.Append(_Bulletin.PublishTime);
            emailContentBuilder.Append(Environment.NewLine);
            emailContentBuilder.Append("发布公告标题：");
            emailContentBuilder.Append(_Bulletin.Title);
            emailContentBuilder.Append(Environment.NewLine);
            emailContentBuilder.Append(_Bulletin.Content);

            List<Appendix> appendixList = _Bulletin.AppendixList;
            List<MailAttachment> attachments = new List<MailAttachment>();
            //if (appendixList != null)
            //{
            //    for (int i = 0; i < appendixList.Count; i++)
            //    {
            //        string filePath = appendixList[i].Directory;
            //        //根据文件路径读取文件流
            //        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            //        {
            //            byte[] buffer = new byte[fs.Length];
            //            fs.Read(buffer, 0, buffer.Length);
            //            fs.Seek(0, SeekOrigin.Begin);
            //            MailAttachment temp = new MailAttachment(buffer, appendixList[i].Title);
            //            temp.Location = filePath;
            //            attachments.Add(temp);
            //        }
            //    }
            //}
            MailBody mailBody = new MailBody();
            mailBody.IsHtmlBody = true;
            mailBody.MailTo = new List<string>(new string[] { _To });
            mailBody.MailCc = _Cc;
            mailBody.Subject = subject;
            mailBody.Body = emailContentBuilder.ToString();
            mailBody.MailAttachments = attachments;
            _MailGateWay.Send(mailBody);
        }

        protected override void Validation()
        {
            //验证字段：记录存在
            _Bulletin = _BulletinDal.GetBulletinByBulletinID(_BulletinID);
            if (_Bulletin == null)
            {
                throw MessageKeys.AppException(MessageKeys._Bulletin_Not_Exist);
            }
        }
    }
}