//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ActiveFlow.cs
// 创建者: 倪豪
// 创建日期: 2008-05-23
// 概述: 考评流程，一旦流程改变，需要处理的事务
// ----------------------------------------------------------------

using System.Collections.Generic;
using System.Text;
using Mail.Model;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.AssessFlow;
using SEP.HRMIS.SqlServerDal;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Model;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Departments;

namespace SEP.HRMIS.Bll.AssessActivity
{
    ///<summary>
    ///</summary>
    public class ActiveFlow : IActiveFlow
    {
        private hrmisModel.AssessActivity _AssessActivity;
        private AssessStatus _AssessStatus;
        private static IAssessActivity _AssessActivityDal;
        private ICalculateScore _ICalculateScore;
        private bool _IsSubmit = true;

        ///<summary>
        ///</summary>
        public ActiveFlow()
        {
            _AssessActivityDal = new AssessActivityDal();
            _ICalculateScore = new CalculateScore();
        }

        ///<summary>
        ///</summary>
        public ActiveFlow(IAssessActivity assessActivityDal)
        {
            _AssessActivityDal = assessActivityDal;
        }

        #region 属性

        ///<summary>
        ///</summary>
        public hrmisModel.AssessActivity AssessActivity
        {
            get
            {
                return _AssessActivity;
            }
            set
            {
                _AssessActivity = value;
            }
        }

        ///<summary>
        ///</summary>
        public AssessStatus AssessStatus
        {
            get
            {
                return _AssessStatus;
            }
            set
            {
                _AssessStatus = value;
            }
        }

        /// <summary>
        /// 可以设置计算分值的不同实现
        /// </summary>
        public ICalculateScore SetCalculateScore
        {
            set
            {
                _ICalculateScore = value;
            }
        }

        /// <summary>
        /// 是否提交
        /// </summary>
        public bool IsSubmit
        {
            get
            {
                return _IsSubmit;
            }
            set
            {
                _IsSubmit = value;
            }
        }

        #endregion

        /// <summary>
        /// 根据期望的状态，处理不同的事情
        /// </summary>
        public void ExcuteFlow()
        {
            ConvertFlowToStatus();

            switch (_AssessStatus)
            {
                case (AssessStatus.HRComfirming):
                    //发起考评
                    DoHrConfirming();
                    break;
                case (AssessStatus.HRFilling):
                    DoHrFilling();
                    break;
                case (AssessStatus.PersonalFilling):
                    DoPersonalFilling();
                    break;
                case (AssessStatus.ManagerFilling):
                    DoManagerFilling();
                    break;
                case (AssessStatus.ApproveFilling):
                    DoCEOFilling();
                    break;
                case (AssessStatus.SummarizeCommment):
                    DoSummarizeCommmentFilling();
                    break;
                case (AssessStatus.Finish):
                    DoFinsh();
                    break;
                case (AssessStatus.Interrupt):
                    DoInterrupt();
                    break;
                default:
                    break;
            }
        }

        private void ConvertFlowToStatus()
        {
            if (!_IsSubmit)
                return;

            if (_AssessStatus == AssessStatus.Interrupt)
                return;

            if (_AssessActivity.NextStepIndex == -1)
                return;

            if (_AssessActivity.NextStepIndex >= _AssessActivity.DiyProcess.DiySteps.Count)
            {
                _AssessStatus = AssessStatus.Finish;
                return;
            }

            string nextActivityName = _AssessActivity.DiyProcess.DiySteps[_AssessActivity.NextStepIndex].Status;
            switch (nextActivityName)
            {
                case AssessActivityName.HRAssess:
                    _AssessStatus = AssessStatus.HRFilling;
                    break;
                case AssessActivityName.MyselfAssess:
                    _AssessStatus = AssessStatus.PersonalFilling;
                    break;
                case AssessActivityName.ManagerAssess:
                    _AssessStatus = AssessStatus.ManagerFilling;
                    break;
                case AssessActivityName.Approve:
                    _AssessStatus = AssessStatus.ApproveFilling;
                    break;
                case AssessActivityName.SummarizeCommment:
                    _AssessStatus = AssessStatus.SummarizeCommment;
                    break;
                default:
                    _AssessStatus = AssessStatus.Interrupt;
                    break;
            }
        }

        /// <summary>
        /// 发起考评
        /// </summary>
        private void DoHrConfirming()
        {
            _AssessActivity.ItsAssessStatus = _AssessStatus;
            _AssessActivityDal.InsertAssessActivity(_AssessActivity);

            try
            {
                MailBody mailBody = CreateAssessMailBody();
                if (mailBody != null && (mailBody.MailTo.Count != 0 || mailBody.MailCc.Count != 0))
                    BllInstance.MailGateWayBllInstance.Send(mailBody);
            }
            catch
            {
            }
        }

        private void DoHrFilling()
        {
            SetStatusAndSave();
            CalculateItsScore();
            try
            {

                MailBody mailBody = CreateAssessMailBody();
                if (mailBody != null && (mailBody.MailTo.Count != 0 || mailBody.MailCc.Count != 0))
                    BllInstance.MailGateWayBllInstance.Send(mailBody);
            }
            catch
            {
            }
        }

        private void DoPersonalFilling()
        {
            bool isSubmit = _AssessActivity.ItsAssessStatus != AssessStatus.PersonalFilling;
            SetStatusAndSave();
            CalculateItsScore();
            //此处用else的原因在于要先保存后发邮件,这个条件代表了人事填写考评完毕，提交了信息
            if (isSubmit)
            {
                try
                {

                    MailBody mailBody = CreateAssessMailBody();
                    if (mailBody != null && (mailBody.MailTo.Count != 0 || mailBody.MailCc.Count != 0))
                        BllInstance.MailGateWayBllInstance.Send(mailBody);
                }
                catch
                {
                }
            }
        }

        private void DoManagerFilling()
        {
            bool isSubmit = _AssessActivity.ItsAssessStatus != AssessStatus.ManagerFilling;
            SetStatusAndSave();
            CalculateItsScore();
            //此处用else的原因在于要先保存后发邮件,这个条件代表的是个人提交了信息
            if (isSubmit)
            {
                try
                {
                    MailBody mailBody = CreateAssessMailBody();
                    if (mailBody != null && (mailBody.MailTo.Count != 0 || mailBody.MailCc.Count != 0))
                        BllInstance.MailGateWayBllInstance.Send(mailBody);
                }
                catch
                {
                }
            }
        }

        private void DoCEOFilling()
        {
            SetStatusAndSave();
            CalculateItsScore();
            try
            {
                MailBody mailBody = CreateAssessMailBody();
                if (mailBody != null && (mailBody.MailTo.Count != 0 || mailBody.MailCc.Count != 0))
                    BllInstance.MailGateWayBllInstance.Send(mailBody);
            }
            catch
            {
            }
        }

        private void DoSummarizeCommmentFilling()
        {
            SetStatusAndSave();
            CalculateItsScore();
            try
            {
                MailBody mailBody = CreateAssessMailBody();
                if ((mailBody.MailTo.Count != 0 || mailBody.MailCc.Count != 0))
                    BllInstance.MailGateWayBllInstance.Send(mailBody);
            }
            catch
            {
            }
        }

        private void DoFinsh()
        {
            SetStatusAndSave();
            CalculateItsScore();
            try
            {
                MailBody mailBody = new MailBody();
                mailBody.Subject = "一个绩效考核流程结束";

                StringBuilder sbMailBody = new StringBuilder("员工");
                sbMailBody.Append(_AssessActivity.ItsEmployee.Account.Name);
                sbMailBody.Append("的绩效考核流程结束了。");
                if (_AssessActivity != null &&
                    _AssessActivity.ItsAssessActivityPaper != null &&
                    _AssessActivity.ItsAssessActivityPaper.SubmitInfoes != null && _AssessActivity.IfHasEmployeeFlow)
                {
                    foreach (SubmitInfo info in _AssessActivity.ItsAssessActivityPaper.SubmitInfoes)
                    {
                        if (info.SubmitInfoType.Id == SubmitInfoType.SummarizeCommment.Id)
                        {
                            sbMailBody.Append("终结评语：");
                            sbMailBody.Append(info.Comment);
                        }
                    }
                }
                mailBody.Body = sbMailBody.ToString();

                List<List<string>> emails;
                List<Account> accounts = _AssessActivity.DiyProcess.DiySteps[_AssessActivity.DiyProcess.DiySteps.Count - 1].MailAccount;
                if (_AssessActivity.ItsEmployee != null && _AssessActivity.ItsEmployee.Account != null)
                {
                    accounts.Add(_AssessActivity.ItsEmployee.Account);
                }
                emails = BllUtility.GetEmailsByAccountIds(accounts);
                mailBody.MailTo = emails[0];
                mailBody.MailCc = emails[1];

                if ((mailBody.MailTo.Count != 0 || mailBody.MailCc.Count != 0))
                    BllInstance.MailGateWayBllInstance.Send(mailBody);
            }
            catch
            {
            }
        }

        private void DoInterrupt()
        {
            SetStatusAndSave();
        }

        private void SetStatusAndSave()
        {
            _AssessActivity.ItsAssessStatus = _AssessStatus;
            _AssessActivityDal.UpdateAssessActivity(_AssessActivity);
            for (int i = 0; i < _AssessActivity.ItsAssessActivityPaper.SubmitInfoes.Count; i++)
            {
                _AssessActivityDal.UpdateAssessActivityPaper(_AssessActivity.ItsAssessActivityPaper.SubmitInfoes[i],
                                                             _AssessActivity.AssessActivityID);
            }
        }

        private void CalculateItsScore()
        {
            _AssessActivity.ItsAssessActivityPaper.Score = _ICalculateScore.CalculateScores(_AssessActivity);
        }

        private MailBody CreateAssessMailBody()
        {
            MailBody mailBody = null;

            switch (_AssessStatus)
            {
                case (AssessStatus.HRComfirming):
                    {
                        mailBody = new MailBody();
                        mailBody.Subject = "待确认绩效考核";

                        StringBuilder sbMailBody = new StringBuilder(_AssessActivity.AssessProposerName);
                        sbMailBody.Append("为");
                        sbMailBody.Append(_AssessActivity.ItsEmployee.Account.Name);
                        sbMailBody.Append("发起一次");
                        sbMailBody.Append(
                            AssessActivityUtility.GetCharacterNameByType(_AssessActivity.AssessCharacterType));
                        mailBody.Body = sbMailBody.ToString();

                        GetMailToCc(mailBody);
                    }
                    break;
                case AssessStatus.HRFilling:
                    {
                        mailBody = new MailBody();
                        mailBody.Subject = "待人力资源评定";
                        mailBody.Body = "您有一个待评定的绩效考核流程";

                        GetMailToCc(mailBody);
                    }
                    break;
                case (AssessStatus.PersonalFilling):
                    {
                        mailBody = new MailBody();
                        mailBody.Subject = "待自我评定";

                        StringBuilder sbMailBody = new StringBuilder("您有一个待自我评定的绩效考核流程，请在");
                        sbMailBody.Append(_AssessActivity.PersonalExpectedFinish.ToShortDateString());
                        sbMailBody.Append("日之前填写完毕");
                        mailBody.Body = sbMailBody.ToString();

                        GetMailToCc(mailBody);
                    }
                    break;
                case (AssessStatus.ManagerFilling):
                    {
                        mailBody = new MailBody();
                        mailBody.Subject = "待主管评定";

                        StringBuilder sbMailBody = new StringBuilder("您有一个待填写的绩效考核流程，请在");
                        sbMailBody.Append(_AssessActivity.ManagerExpectedFinish.ToShortDateString());
                        sbMailBody.Append("日之前填写完毕");
                        mailBody.Body = sbMailBody.ToString();

                        GetMailToCc(mailBody);
                    }
                    break;
                case (AssessStatus.ApproveFilling):
                    {
                        mailBody = new MailBody();
                        mailBody.Subject = "待审批绩效考核流程";
                        mailBody.Body = "您有一个待审批的绩效考核流程";

                        GetMailToCc(mailBody);
                    }
                    break;
                case (AssessStatus.Finish):
                    {
                        mailBody = new MailBody();
                        mailBody.Subject = "一个绩效考核流程结束";

                        StringBuilder sbMailBody = new StringBuilder("员工");
                        sbMailBody.Append(_AssessActivity.ItsEmployee.Account.Name);
                        sbMailBody.Append("的绩效考核流程结束了");
                        mailBody.Body = sbMailBody.ToString();

                        GetMailToCc(mailBody);
                    }
                    break;
                default:
                    break;
            }

            return mailBody;
        }

        private void GetMailToCc(MailBody mailBody)
        {
            if (mailBody == null)
                return;

            List<List<string>> emails;
            List<Account> accounts;
            if (_AssessActivity.NextStepIndex != -1)
            {
                accounts = _AssessActivity.DiyProcess.DiySteps[_AssessActivity.NextStepIndex].MailAccount;
                Account nextOperator =
                    new GetAssessActivity().GetDiyStepAccount(_AssessActivity.ItsEmployee.Account.Id,
                                                              _AssessActivity.DiyProcess.DiySteps[
                                                                  _AssessActivity.NextStepIndex]);
                if (nextOperator != null)
                { accounts.Add(nextOperator); }
            }
            else
            {
                Department dept = BllInstance.DepartmentBllInstance.GetDept(_AssessActivity.ItsEmployee.Account.Id,
                                                                            new Account(Account.AdminPkid, "", ""));
                accounts = new AuthDal().GetAccountsByAuthIdAndDeptId(HrmisPowers.A704, dept.Id);
            }
            emails = BllUtility.GetEmailsByAccountIds(accounts);
            mailBody.MailTo = emails[0];
            mailBody.MailCc = emails[1];
            return;
        }
    }
}
