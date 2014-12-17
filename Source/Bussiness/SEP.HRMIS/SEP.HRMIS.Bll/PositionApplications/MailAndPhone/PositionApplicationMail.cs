using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.PositionApp;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using ShiXin.Security;

namespace SEP.HRMIS.Bll.PositionApplications.MailAndPhone
{
    public class PositionApplicationMail
    {
        #region �����ύ�ʼ�

        private delegate void DelSendSubmitMail(
            int positionApplicationID, List<Account> cclist, List<string> diyProcesslist, DiyStep nextStep);

        /// <summary>
        /// �����ύ�ʼ�
        /// </summary>
        public void SendSubmitMail(int positionApplicationID, List<Account> cclist, List<string> diyProcesslist, DiyStep nextStep)
        {
            DelSendSubmitMail sendMailDelegate = SendSubmitMailF;
            sendMailDelegate.BeginInvoke(positionApplicationID, cclist, diyProcesslist, nextStep, null, null);
        }

        private static void SendSubmitMailF(int positionApplicationID, List<Account> cclist, List<string> diyProcesslist, DiyStep nextStep)
        {
            new PositionApplicationSubmitMail(positionApplicationID, cclist, diyProcesslist, nextStep).SendMail();
        }

        #endregion

        #region ����ȡ���ʼ�

        private delegate void DelSendCancelMailUseID(
            int positionApplicationID, List<string> diyProcessAccountlist, DiyStep nextStep);

        /// <summary>
        /// ����ȡ���ʼ�
        /// </summary>
        public void SendCancelMail(int positionApplicationID, List<string> currentStepAccountlist, DiyStep nextStep)
        {
            DelSendCancelMailUseID sendMailDelegate = SendCancelMailF;
            sendMailDelegate.BeginInvoke(positionApplicationID, currentStepAccountlist, nextStep, null, null);
        }

        private static void SendCancelMailF(int positionApplicationID, List<string> currentStepAccountlist, DiyStep nextStep)
        {
            new PositionApplicationCancelMail(positionApplicationID, currentStepAccountlist, nextStep).SendMail();
        }
        #endregion

        #region �����ʼ�����һ��������
        private delegate void DelSendMailToNextOperator(int positionApplicationID, Account nextOperator);

        /// <summary>
        /// �����ʼ�����һ��������
        /// </summary>
        public void SendMailToNextOperator(int positionApplicationID, Account nextOperator)
        {
            DelSendMailToNextOperator sendMailDelegate = SendMailToNextOperatorF;
            sendMailDelegate.BeginInvoke(positionApplicationID, nextOperator, null, null);
        }

        private static void SendMailToNextOperatorF(int positionApplicationID, Account nextOperator)
        {
            new PositionApplicationConfirmMail(positionApplicationID).SendMailToNextOperator(nextOperator);
        }
        #endregion

        #region ������˽����ʼ�

        private delegate void DelSendOverMailUseID(int positionApplicationID, DiyStep nextStep);

        /// <summary>
        /// ������˽����ʼ�
        /// </summary>
        /// <param name="positionApplicationID"></param>
        /// <param name="currentStep"></param>
        public void SendConfirmOverMail(int positionApplicationID, DiyStep currentStep)
        {
            DelSendOverMailUseID sendMailDelegate = SendConfirmOverMailF;
            sendMailDelegate.BeginInvoke(positionApplicationID, currentStep, null, null);
        }

        private static void SendConfirmOverMailF(int positionApplicationID, DiyStep currentStep)
        {
            new PositionApplicationOverMail(positionApplicationID, currentStep).ConfirmOverMail();
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public static string BuildBody(PositionApplication positionApplication)
        {
            StringBuilder mailContent = new StringBuilder();
            mailContent.AppendFormat("<strong>ְλ�����ˣ�</strong>{0}<br>", positionApplication.Account.Name);
            mailContent.AppendFormat("<strong>ְλ���ƣ�</strong>{0}        ",
                                     positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.Name
                                         : "");
            mailContent.AppendFormat("<strong>ְλ�ȼ���</strong>{0}<br>",
                                     positionApplication.Position != null && positionApplication.Position.Grade != null
                                     && positionApplication.Position.Grade.Name != null
                                         ? positionApplication.Position.Grade.Name
                                         : "");
            mailContent.AppendFormat("<strong>��λ���ʣ�</strong>{0}<br>", positionApplication.Position != null
                                         ? NatureName(positionApplication.Position)
                                         : "");
            mailContent.AppendFormat("<strong>������</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Description != null
                                         ? positionApplication.Position.Description.Replace("\n","<br/>")
                                         : "");
            mailContent.AppendFormat("<strong>���ò��ţ�</strong>{0}<br>", positionApplication.Position != null
                                         ? DeptName(positionApplication.Position)
                                         : "");
            mailContent.AppendFormat("<strong>����Ա����</strong>{0}<br>", positionApplication.Position != null
                                         ? MemberName(positionApplication.Position)
                                         : "");
            mailContent.AppendFormat("<br><strong>������Ҫ��</strong><br>{0}<br>", positionApplication.Position != null && positionApplication.Position.Summary != null
                                         ? positionApplication.Position.Summary.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("<strong>��Ҫְ��</strong><br>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.MainDuties.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("<br><strong>������ϵ</strong><br>");
            mailContent.AppendFormat("    <strong>���淶Χ��</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.ReportScope.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("    <strong>���Ʒ�Χ��</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.ControlScope.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("    <strong>����Э����ϵ��</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.Coordination.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("<br><strong>Ȩ�ޣ�</strong><br>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.Authority.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("<br><strong>�ϸ�����</strong><br>");
            mailContent.AppendFormat("   <strong>ѧ����</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.Education.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>רҵ������</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.ProfessionalBackground.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>�������飺</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.WorkExperience.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>����Ҫ��</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.Qualification.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>ʤ��������</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.Competence.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>����Ҫ��</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.OtherRequirements.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("<br><strong>֪ʶ�뼼��Ҫ��</strong><br>");
            mailContent.AppendFormat("   <strong>1. ��λ֪ʶ�뼼�ܣ�</strong><br>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.KnowledgeAndSkills.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>2. ������̣�</strong><br>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.RelatedProcesses.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>3. ���˹����ܣ�</strong><br>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.ManagementSkills.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>4. �������ܣ�</strong><br>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.AuxiliarySkills.Replace("\n", "<br/>")
                                         : "");
            mailContent.Append("<br/>");

            return mailContent.ToString();
        }
        private static string MemberName(Position _Position)
        {
            string ret = "";
            if (_Position.Members != null)
            {
                foreach (Account a in _Position.Members)
                {
                    ret += string.IsNullOrEmpty(ret) ? a.Name : (";" + a.Name);
                }
            }
            return ret;
        }


        private static string DeptName(Position _Position)
        {
            string ret = "";
            if (_Position.Departments != null)
            {
                foreach (Department d in _Position.Departments)
                {
                    ret += string.IsNullOrEmpty(ret) ? d.Name : (";" + d.Name);
                }
            }
            return ret;
        }

        private  static string NatureName(Position _Position)
        {
            string ret = "";
            if (_Position.Nature != null)
            {
                foreach (PositionNature pn in _Position.Nature)
                {
                    ret += string.IsNullOrEmpty(ret) ? pn.Name : (";" + pn.Name);
                }
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void BulidConfirmAddress(StringBuilder mailContent, Account to, int positionApplicationID)
        {
            string url =
                string.Format("{0}?accountId={1}&Id={2}", RequestUtility.PositionApplicationMailConfirmAddress(),
                              SecurityUtil.DECEncrypt(to.Id.ToString()),
                              SecurityUtil.DECEncrypt(positionApplicationID.ToString()));
            mailContent.Append(
                "���ɵ�� <a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>ͬ��</a> ��������<br/>");
            mailContent.Append("��Ҳ���Ե���������ӿ�������ͨ����<br/>");
            mailContent.Append("<a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>" + url +
                               "</a><br/>");
            mailContent.Append("�������ͨ�������룬�ɵ�¼������ַ��������<br/>");
        }
    }
}
