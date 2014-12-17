//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OutApplicationConfirmPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-04-22
// Resume:
// ---------------------------------------------------------------

using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IOutApplication;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.OutApplications
{
    public class OutApplicationConfirmPresenter
    {
        private readonly IOutApplicationFacade _OutApplicationFacade = InstanceFactory.CreateOutApplicationFacade();
        private readonly IOutApplicationConfirmView _View;
        private readonly Account _LoginUser;

        public OutApplicationConfirmPresenter(IOutApplicationConfirmView view, Account loginUser, bool isPostBack)
        {
            _View = view;
            _LoginUser = loginUser;
            Initialize(isPostBack);
        }

        private void Initialize(bool isPostBack)
        {
            AttachViewEvent();
            if (!isPostBack)
            {
                BindOutApplicationSource(null, null);
            }
        }

        private void AttachViewEvent()
        {
            _View.BindOutApplicationSource += BindOutApplicationSource;
            _View.QuickPassEvent += QuickPass;
        }

        private void BindOutApplicationSource(object sender, EventArgs e)
        {
            _View.OutApplicationSource = _OutApplicationFacade.GetConfirmOutApplicationByNextOperatorID(_LoginUser.Id);
        }

        public void QuickPass(object sender, CommandEventArgs e)
        {
            try
            {
                _OutApplicationFacade.ApproveWholeOutApplication(Convert.ToInt32(e.CommandArgument), _LoginUser.Id, true, "快速通过");
            }
            catch{}
        }
    }
}