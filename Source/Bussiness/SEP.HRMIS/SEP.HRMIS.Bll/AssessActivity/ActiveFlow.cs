//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: ActiveFlow.cs
// ������: �ߺ�
// ��������: 2008-05-23
// ����: �������̣�һ�����̸ı䣬��Ҫ���������
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

        #region ����

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
        /// �������ü����ֵ�Ĳ�ͬʵ��
        /// </summary>
        public ICalculateScore SetCalculateScore
        {
            set
            {
                _ICalculateScore = value;
            }
        }

        /// <summary>
        /// �Ƿ��ύ
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
        /// ����������״̬������ͬ������
        /// </summary>
        public void ExcuteFlow()
        {
            ConvertFlowToStatus();

            switch (_AssessStatus)
            {
                case (AssessStatus.HRComfirming):
                    //������
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
        /// ������
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
            //�˴���else��ԭ������Ҫ�ȱ�����ʼ�,�������������������д������ϣ��ύ����Ϣ
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
            //�˴���else��ԭ������Ҫ�ȱ�����ʼ�,�������������Ǹ����ύ����Ϣ
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
                mailBody.Subject = "һ����Ч�������̽���";

                StringBuilder sbMailBody = new StringBuilder("Ա��");
                sbMailBody.Append(_AssessActivity.ItsEmployee.Account.Name);
                sbMailBody.Append("�ļ�Ч�������̽����ˡ�");
                if (_AssessActivity != null &&
                    _AssessActivity.ItsAssessActivityPaper != null &&
                    _AssessActivity.ItsAssessActivityPaper.SubmitInfoes != null && _AssessActivity.IfHasEmployeeFlow)
                {
                    foreach (SubmitInfo info in _AssessActivity.ItsAssessActivityPaper.SubmitInfoes)
                    {
                        if (info.SubmitInfoType.Id == SubmitInfoType.SummarizeCommment.Id)
                        {
                            sbMailBody.Append("�ս����");
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
                        mailBody.Subject = "��ȷ�ϼ�Ч����";

                        StringBuilder sbMailBody = new StringBuilder(_AssessActivity.AssessProposerName);
                        sbMailBody.Append("Ϊ");
                        sbMailBody.Append(_AssessActivity.ItsEmployee.Account.Name);
                        sbMailBody.Append("����һ��");
                        sbMailBody.Append(
                            AssessActivityUtility.GetCharacterNameByType(_AssessActivity.AssessCharacterType));
                        mailBody.Body = sbMailBody.ToString();

                        GetMailToCc(mailBody);
                    }
                    break;
                case AssessStatus.HRFilling:
                    {
                        mailBody = new MailBody();
                        mailBody.Subject = "��������Դ����";
                        mailBody.Body = "����һ���������ļ�Ч��������";

                        GetMailToCc(mailBody);
                    }
                    break;
                case (AssessStatus.PersonalFilling):
                    {
                        mailBody = new MailBody();
                        mailBody.Subject = "����������";

                        StringBuilder sbMailBody = new StringBuilder("����һ�������������ļ�Ч�������̣�����");
                        sbMailBody.Append(_AssessActivity.PersonalExpectedFinish.ToShortDateString());
                        sbMailBody.Append("��֮ǰ��д���");
                        mailBody.Body = sbMailBody.ToString();

                        GetMailToCc(mailBody);
                    }
                    break;
                case (AssessStatus.ManagerFilling):
                    {
                        mailBody = new MailBody();
                        mailBody.Subject = "����������";

                        StringBuilder sbMailBody = new StringBuilder("����һ������д�ļ�Ч�������̣�����");
                        sbMailBody.Append(_AssessActivity.ManagerExpectedFinish.ToShortDateString());
                        sbMailBody.Append("��֮ǰ��д���");
                        mailBody.Body = sbMailBody.ToString();

                        GetMailToCc(mailBody);
                    }
                    break;
                case (AssessStatus.ApproveFilling):
                    {
                        mailBody = new MailBody();
                        mailBody.Subject = "��������Ч��������";
                        mailBody.Body = "����һ���������ļ�Ч��������";

                        GetMailToCc(mailBody);
                    }
                    break;
                case (AssessStatus.Finish):
                    {
                        mailBody = new MailBody();
                        mailBody.Subject = "һ����Ч�������̽���";

                        StringBuilder sbMailBody = new StringBuilder("Ա��");
                        sbMailBody.Append(_AssessActivity.ItsEmployee.Account.Name);
                        sbMailBody.Append("�ļ�Ч�������̽�����");
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
