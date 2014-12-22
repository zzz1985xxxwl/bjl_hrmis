//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ConfirmAssessPresenter.cs
// 创建者: 唐曼丽
// 创建日期: 2008-06-16
// 概述: 添加确认考评活动
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.IBll;
using SEP.IBll.Accounts;
using SEP.IBll.Positions;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class ConfirmAssessPresenter : BasePresenter
    {
        private readonly IConfirmAssessView _View;
        private readonly IAssessActivityFacade _AssessActivityFacade = InstanceFactory.AssessActivityFacade();
        private readonly IAccountBll _AccountBll = BllInstance.AccountBllInstance;
        private readonly IAssessManagementFacade _AssessManagementFacade =
            InstanceFactory.CreateAssessManagementFacade();

        private readonly string _StrAssessActivityId;

        public ConfirmAssessPresenter(string strAssessActivityID, IConfirmAssessView view, Account loginUser)
            : base(loginUser)
        {
            if (view == null)
            {
                throw new Exception("view may not be null");
            }

            _StrAssessActivityId = strAssessActivityID;
            _View = view;
        }

        public override void Initialize(bool isPostBack)
        {
            _View.Message = string.Empty;
            int assessActivityID;
            if (!int.TryParse(_StrAssessActivityId, out assessActivityID))
            {
                _View.Message = "绩效考核活动信息传入错误";
                return;
            }
            List<AssessTemplatePaper> allTemplatePaper =
                InstanceFactory.CreateAssessManagementFacade().GetAllTemplatePaper();
            if (!isPostBack)
            {
                _View.AssessTempletPaperNames = allTemplatePaper;
                _View.PersonalExpectedTime = DateTime.Now.Date.AddDays(7).ToShortDateString();
                _View.ManagerExpectedFinish = DateTime.Now.Date.AddDays(14).ToShortDateString();
                Model.AssessActivity assessActivity =
                    _AssessActivityFacade.GetAssessActivityByAssessActivityID(assessActivityID);
                if (assessActivity.AssessCharacterType == AssessCharacterType.Annual)
                {
                    int id =
                        _AssessManagementFacade.GetTempletPaperIDByEmployeePositionID(
                           _AccountBll.GetAccountById(assessActivity.ItsEmployee.Account.Id).Position.Id);
                    if (id > 0)
                    {
                        _View.AssessTempletPaperID = id;
                    }
                }
            }
        }

        public bool Validation()
        {
            _View.PersonalExpectedMsg = string.Empty;
            _View.ManagerExpectedMsg = string.Empty;
            _View.Message = string.Empty;
            bool ret = true;
            if (String.IsNullOrEmpty(_View.PersonalExpectedTime))
            {
                _View.PersonalExpectedMsg = "期望员工自评截止时间不可为空";
                ret = false;
            }
            else
            {
                DateTime dtPersonalExpectedTime;
                if (!DateTime.TryParse(_View.PersonalExpectedTime, out dtPersonalExpectedTime))
                {
                    _View.PersonalExpectedMsg = "期望员工自评截止时间格式不正确";
                    ret = false;
                }
            }

            if (String.IsNullOrEmpty(_View.ManagerExpectedFinish))
            {
                _View.ManagerExpectedMsg = "期望主管评定截止时间不可为空";
                ret = false;
            }
            else
            {
                DateTime dtManagerExpectedFinish;
                if (!DateTime.TryParse(_View.ManagerExpectedFinish, out dtManagerExpectedFinish))
                {
                    _View.ManagerExpectedMsg = "期望主管评定截止时间格式不正确";
                    ret = false;
                }
            }
            if (ret &&
                DateTime.Compare(Convert.ToDateTime(_View.PersonalExpectedTime),
                                 Convert.ToDateTime(_View.ManagerExpectedFinish)) > 0)
            {
                _View.PersonalExpectedMsg = "期望员工自评截止时间不可晚于期望主管评定截止时间";
                ret = false;
            }

            return ret;
        }

        public void btnConfirmClick(object sender, EventArgs e)
        {
            int assessActivityID;
            if (!int.TryParse(_StrAssessActivityId, out assessActivityID))
            {
                _View.Message = "绩效考核活动信息传入错误";
                return;
            }

            if (!Validation())
            {
                return;
            }

            try
            {
                InstanceFactory.AssessActivityFacade().ConfirmActivityExcute(assessActivityID, _View.AssessTempletPaperID,
                                                                           Convert.ToDateTime(
                                                                               _View.ManagerExpectedFinish),
                                                                           Convert.ToDateTime(_View.PersonalExpectedTime),
                                                                           LoginUser.Name);
                Model.AssessActivity assessActivity =
                    _AssessActivityFacade.GetAssessActivityByAssessActivityID(assessActivityID);

                _View.SubmitID = assessActivity.ItsAssessActivityPaper.SubmitInfoes[0].SubmitInfoID.ToString();
                NextPageRedirect(assessActivityID);
            }
            catch (Exception ex)
            {
                _View.Message = ex.Message;
            }
        }

        private void NextPageRedirect(int assessActivityID)
        {
            Model.AssessActivity assessActivity =
                _AssessActivityFacade.GetAssessActivityByAssessActivityID(assessActivityID);
            Account operAccount = _AssessActivityFacade.GetDiyStepAccount(assessActivity.ItsEmployee.Account.Id,
                                                                          assessActivity.DiyProcess.DiySteps[
                                                                              assessActivity.NextStepIndex]);
            ;
            if (operAccount.Id == LoginUser.Id
                &&
                assessActivity.DiyProcess.DiySteps[assessActivity.NextStepIndex].Status == AssessActivityName.HRAssess)
            {
                ToFillAssessPage("HRFillAssess.aspx?", null);
            }
            else
            {
                ToFillAssessPage("GetConfirmAssesses.aspx", null);
            }
        }

        public EventHandler ToFillAssessPage;
    }
}