//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: HRFillingAssessPresenter.cs
// ������: ������
// ��������: 2008-06-23
// ����: ��Ӵ�������д������Ľ���
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Accounts;
using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter.AssessActivity
{
    public class HRFillingAssessPresenter : SEP.Presenter.Core.BasePresenter
    { 
        public IHRFillingAssessView _View;
        //public GetAssessActivity _GetAssessActivity;

        public HRFillingAssessPresenter(IHRFillingAssessView view, Account loginUser)
            : base(loginUser)
        {
            if (view == null)
            {
                throw new Exception("view may not be null");
            }
            _View = view;
        }

        public override void Initialize(bool isPostBack)
        {
            if (!isPostBack)
            {
                BindAssessActivity(null, null);
            }
        }

        public void BindAssessActivity(object sender, EventArgs e)
        {
            List<Model.AssessActivity>  list =
                AssessActivityLogic.GetAssessActivityByEmployeeStatus(-1, AssessStatus.HRFilling);
            for (int i = list.Count-1; i >= 0; i--)
            {
                Account operAccount =
                    InstanceFactory.AssessActivityFacade().GetDiyStepAccount(list[i].ItsEmployee.Account.Id,
                                                                           list[i].DiyProcess.DiySteps[
                                                                               list[i].NextStepIndex]);
                if(operAccount == null)
                {
                    InstanceFactory.AssessActivityFacade().InterruptActivity(list[i].AssessActivityID);
                    list.RemoveAt(i);
                }
                else if(operAccount.Id != LoginUser.Id)
                {
                    list.RemoveAt(i);
                }
            }
            _View.AssessActivitys = list;
        }
        public void hrFillingAssessCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "FillAssess")
            {
                try
                {
                    ToHRFillAssessPage(this, e);
                }
                catch (Exception ex)
                {
                    _View.RedirectPage = ex.Message;
                }
            }
        }

        public CommandEventHandler ToHRFillAssessPage;
    }
}

