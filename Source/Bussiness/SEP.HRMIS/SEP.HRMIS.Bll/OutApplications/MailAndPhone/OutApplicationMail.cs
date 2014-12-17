//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutApplicationMail.cs
// Creater:  Xue.wenlong
// Date:  2009-05-11
// Resume:
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.HRMIS.Bll.OutApplications.MailAndPhone
{
    /// <summary>
    /// </summary>
    public class OutApplicationMail
    {
        private delegate void DelSendSubmitMail(int outApplicationId, List<Account> cclist);

        private delegate void DelSendCancelMail(int outApplicationID);

        private delegate void DelSendMailToNextOperator(int outApplicationID, Account nextOperator);

        private delegate void DelErrorMail(int applicationID);

        /// <summary>
        /// �����ύ�ʼ�
        /// </summary>
        public void SendSubmitMail(int outApplicationId, List<Account> cclist)
        {
            DelSendSubmitMail sendMailDelegate = SendSubmitMailF;
            sendMailDelegate.BeginInvoke(outApplicationId, cclist, null, null);
        }

        /// <summary>
        /// ����ȡ���ʼ�
        /// </summary>
        public void SendCancelMail(int outApplicationId)
        {
            DelSendCancelMail sendMailDelegate = SendCancelMailF;
            sendMailDelegate.BeginInvoke(outApplicationId, null, null);
        }

        /// <summary>
        /// �����ʼ�����һ��������
        /// </summary>
        public void SendMailToNextOperator(int outApplicationId, Account nextOperator)
        {

            DelSendMailToNextOperator sendMailDelegate = SendMailToNextOperatorF;
            sendMailDelegate.BeginInvoke(outApplicationId, nextOperator, null, null);
        }

        /// <summary>
        /// ������˽����ʼ�
        /// </summary>
        public void SendConfirmOverMail(int outApplicationID)
        {
            DelSendCancelMail sendMailDelegate = SendConfirmOverMailF;
            sendMailDelegate.BeginInvoke(outApplicationID,  null, null);
        }

        /// <summary>
        /// </summary>
        public void SendErrorMail(int applicationID)
        {
            DelErrorMail sendMailDelegate = SendErrorMailF;
            sendMailDelegate.BeginInvoke( applicationID,  null, null);
        }

        private static void SendSubmitMailF(int outApplicationId, List<Account> cclist)
        {
            new OutSubmitMail(outApplicationId, cclist).SendMail();
        }

        private static void SendCancelMailF(int outApplicationID)
        {
            new OutCancelMail(outApplicationID).SendMail();
        }

        private static void SendMailToNextOperatorF(int outApplicationID, Account nextOperator)
        {
            new OutConfirmMail(outApplicationID).SendMailToNextOperator(nextOperator);
        }

        private static void SendConfirmOverMailF(int outApplicationID)
        {
            new OutOverMail(outApplicationID).ConfirmOverMail();
        }
        private static void SendErrorMailF( int applicationID)
        {
            new OutErrorMail(applicationID).Send();
        }
        #region �ʼ���������

        /// <summary>
        /// 
        /// </summary>
        public static string BuildBody(OutApplication outApplication)
        {
            StringBuilder mailContent = new StringBuilder();
            mailContent.AppendFormat("���Ա����{0}", outApplication.Account.Name);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("����ص㣺{0}", outApplication.OutLocation);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("������ɣ�{0}", outApplication.Reason);
            mailContent.Append("<br/>");
            mailContent.AppendFormat("���");
            mailContent.Append("<br />");
            foreach (OutApplicationItem item in outApplication.Item)
            {
                mailContent.AppendFormat("��{0}��{1}�����{2}Сʱ��״̬Ϊ{3}", item.FromDate, item.ToDate, item.CostTime, RequestStatus.FindRequestStatus(item.Status.Id).Name);
                mailContent.Append("<br />");
            }
            return mailContent.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void BulidConfirmAddress(StringBuilder mailContent, Account to, int outApplicationID)
        {
            string url =
                string.Format("{0}?accountId={1}&Id={2}", RequestUtility.OutMailConfirmAddress(),
                              SecurityUtil.DECEncrypt(to.Id.ToString()),
                              SecurityUtil.DECEncrypt(outApplicationID.ToString()));
            mailContent.Append(
                "���ɵ�� <a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>ͬ��</a> ��������<br/>");
            mailContent.Append("��Ҳ���Ե���������ӿ�������ͨ����<br/>");
            mailContent.Append("<a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>" + url +
                               "</a><br/>");
            mailContent.Append("�������ͨ�������룬�ɵ�¼������ַ��������<br/>");
        }

 

        #endregion

    }
}