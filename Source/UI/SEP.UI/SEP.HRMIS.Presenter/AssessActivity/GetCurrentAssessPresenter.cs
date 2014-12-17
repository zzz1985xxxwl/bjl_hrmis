//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: GetConfirmAssessesPresenter.cs
// 创建者: 倪豪
// 创建日期: 2008-06-20
// 概述: 获取当前登录人的待填写的考评活动
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class GetCurrentAssessPresenter : SEP.Presenter.Core.BasePresenter
    {
        private readonly IGetCurrentAssessView _ItsView;

        /// <summary>
        /// 构造函数需要将当前操作人的employeeId传入
        /// </summary>
        public GetCurrentAssessPresenter(IGetCurrentAssessView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;

            _ItsView.BindSelfAssessActivity += GetAndPassSelfSource;
            _ItsView.BindManagerAssessActivity += GetAndPassManagerSource;
            _ItsView.BindCeoAssessActivity += GetAndPassCeoSource;
            _ItsView.BindHrAssessActivity += GetAndPassHrSource;
            _ItsView.BindSummarizeCommmentAssessActivity += GetAndPassSummarizeCommmentSource;

            _ItsView.CaculateCount += CaculateCount;
        }

        public override void Initialize(bool isPostBack)
        {
            if (!isPostBack)
            {
                GetAndPassSelfSource(null, null);
                GetAndPassManagerSource(null, null);
                GetAndPassCeoSource(null, null);
                GetAndPassHrSource(null, null);
                GetAndPassSummarizeCommmentSource(null, null);

                CaculateCount(null, null);
            }
        }

        private void CaculateCount(object sender, EventArgs e)
        {
            _ItsView.Message =
                (_ItsView.SelfCount + _ItsView.ManagerCount +
                 _ItsView.CEOCount + _ItsView.HrCount + _ItsView.SummarizeCommmentCount).ToString();
        }

        private void GetAndPassSelfSource(object sender, EventArgs e)
        {
            _ItsView.SelfSource = InstanceFactory.AssessActivityFacade.GetEmployeeFillActivitys(LoginUser.Id);
        }

        private void GetAndPassManagerSource(object sender, EventArgs e)
        {
            _ItsView.ManagerSource = InstanceFactory.AssessActivityFacade.GetManagerFillActivitys(LoginUser.Id);
        }

        private void GetAndPassCeoSource(object sender, EventArgs e)
        {
            _ItsView.CeoSource = InstanceFactory.AssessActivityFacade.GetCeoFillActivitys(LoginUser.Id);
        }

        private void GetAndPassHrSource(object sender, EventArgs e)
        {
            List<Model.AssessActivity> list =
                AssessActivityLogic.GetAssessActivityByEmployeeStatus(-1, AssessStatus.HRFilling);
            for (int i = list.Count - 1; i >= 0; i--)
            {
                Account operAccount =
                    InstanceFactory.AssessActivityFacade.GetDiyStepAccount(list[i].ItsEmployee.Account.Id,
                                                                           list[i].DiyProcess.DiySteps[
                                                                               list[i].NextStepIndex]);
                if (operAccount == null)
                {
                    InstanceFactory.AssessActivityFacade.InterruptActivity(list[i].AssessActivityID);
                    list.RemoveAt(i);
                }
                else if (operAccount.Id != LoginUser.Id)
                {
                    list.RemoveAt(i);
                }
            }
            _ItsView.HrSource = list;
        }

        private void GetAndPassSummarizeCommmentSource(object sender, EventArgs e)
        {
            _ItsView.SummarizeCommmentSource = InstanceFactory.AssessActivityFacade.GetSummarizeCommmentFillActivitys(LoginUser.Id);
        }
    }
}