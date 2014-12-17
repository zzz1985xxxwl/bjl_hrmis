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
        #region 发送提交邮件

        private delegate void DelSendSubmitMail(
            int positionApplicationID, List<Account> cclist, List<string> diyProcesslist, DiyStep nextStep);

        /// <summary>
        /// 发送提交邮件
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

        #region 发送取消邮件

        private delegate void DelSendCancelMailUseID(
            int positionApplicationID, List<string> diyProcessAccountlist, DiyStep nextStep);

        /// <summary>
        /// 发送取消邮件
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

        #region 发送邮件给下一步处理人
        private delegate void DelSendMailToNextOperator(int positionApplicationID, Account nextOperator);

        /// <summary>
        /// 发送邮件给下一步处理人
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

        #region 发送审核结束邮件

        private delegate void DelSendOverMailUseID(int positionApplicationID, DiyStep nextStep);

        /// <summary>
        /// 发送审核结束邮件
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
            mailContent.AppendFormat("<strong>职位申请人：</strong>{0}<br>", positionApplication.Account.Name);
            mailContent.AppendFormat("<strong>职位名称：</strong>{0}        ",
                                     positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.Name
                                         : "");
            mailContent.AppendFormat("<strong>职位等级：</strong>{0}<br>",
                                     positionApplication.Position != null && positionApplication.Position.Grade != null
                                     && positionApplication.Position.Grade.Name != null
                                         ? positionApplication.Position.Grade.Name
                                         : "");
            mailContent.AppendFormat("<strong>岗位性质：</strong>{0}<br>", positionApplication.Position != null
                                         ? NatureName(positionApplication.Position)
                                         : "");
            mailContent.AppendFormat("<strong>描述：</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Description != null
                                         ? positionApplication.Position.Description.Replace("\n","<br/>")
                                         : "");
            mailContent.AppendFormat("<strong>适用部门：</strong>{0}<br>", positionApplication.Position != null
                                         ? DeptName(positionApplication.Position)
                                         : "");
            mailContent.AppendFormat("<strong>适用员工：</strong>{0}<br>", positionApplication.Position != null
                                         ? MemberName(positionApplication.Position)
                                         : "");
            mailContent.AppendFormat("<br><strong>工作概要：</strong><br>{0}<br>", positionApplication.Position != null && positionApplication.Position.Summary != null
                                         ? positionApplication.Position.Summary.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("<strong>主要职责：</strong><br>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.MainDuties.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("<br><strong>工作关系</strong><br>");
            mailContent.AppendFormat("    <strong>报告范围：</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.ReportScope.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("    <strong>控制范围：</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.ControlScope.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("    <strong>内外协调关系：</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.Coordination.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("<br><strong>权限：</strong><br>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.Authority.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("<br><strong>上岗条件</strong><br>");
            mailContent.AppendFormat("   <strong>学历：</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.Education.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>专业背景：</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.ProfessionalBackground.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>工作经验：</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.WorkExperience.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>资质要求：</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.Qualification.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>胜任能力：</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.Competence.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>其他要求：</strong>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.OtherRequirements.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("<br><strong>知识与技能要求</strong><br>");
            mailContent.AppendFormat("   <strong>1. 岗位知识与技能：</strong><br>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.KnowledgeAndSkills.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>2. 相关流程：</strong><br>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.RelatedProcesses.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>3. 个人管理技能：</strong><br>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
                                         ? positionApplication.Position.ManagementSkills.Replace("\n", "<br/>")
                                         : "");
            mailContent.AppendFormat("   <strong>4. 辅助技能：</strong><br>{0}<br>", positionApplication.Position != null && positionApplication.Position.Name != null
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
                "您可点击 <a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>同意</a> 快速审批<br/>");
            mailContent.Append("您也可以点击以下链接快速审批通过：<br/>");
            mailContent.Append("<a href='" + url + "' style='color:#0000FF;text-decoration:underline;'>" + url +
                               "</a><br/>");
            mailContent.Append("如果您不通过此申请，可登录以下网址进行审批<br/>");
        }
    }
}
