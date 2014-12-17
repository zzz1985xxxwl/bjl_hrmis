//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkConfirmPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-04-22
// Resume:
// ---------------------------------------------------------------

using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.OverWorks
{
    public class OverWorkConfirmPresenter
    {
        private readonly IOverWorkFacade _OverWorkFacade = InstanceFactory.CreateOverWorkFacade();
        private readonly IOverWorkConfirmView _View;
        private readonly Account _LoginUser;

        public OverWorkConfirmPresenter(IOverWorkConfirmView view, Account loginUser, bool isPostBack)
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
                BindOverWorkSource(null, null);
            }
        }

        private void AttachViewEvent()
        {
            _View.BindOverWorkSource += BindOverWorkSource;
            _View.QuickPassEvent += QuickPass;
        }

        private void BindOverWorkSource(object sender, EventArgs e)
        {
            _View.OverWorkSource = _OverWorkFacade.GetConfirmOverWorkByNextOperatorID(_LoginUser.Id);
        }

        public void QuickPass(object sender, CommandEventArgs e)
        {
            try
            {
                _OverWorkFacade.ApproveWholeOverWork(Convert.ToInt32(e.CommandArgument), _LoginUser.Id, true, "快速通过");
            }
            catch{}
        }
    }
}