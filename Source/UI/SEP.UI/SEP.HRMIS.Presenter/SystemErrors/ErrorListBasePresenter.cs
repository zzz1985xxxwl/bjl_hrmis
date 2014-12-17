//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ErrorListBasePresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-10-20
// Resume:
// ----------------------------------------------------------------

using System;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.SystemError;
using SEP.HRMIS.Presenter.IPresenter.ISystemError;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.SystemErrors
{
    /// <summary>
    /// </summary>
    public class ErrorListBasePresenter
    {
        protected readonly ISystemErrorListPresenter _View;
        protected readonly Account _LoginUser;
        protected readonly ISystemErrorFacade _ISystemErrorFacade = InstanceFactory.CreateSystemErrorFacade();

        public ErrorListBasePresenter(ISystemErrorListPresenter view, Account loginUser, bool isPostBack)
        {
            _View = view;
            _LoginUser = loginUser;
            AttachEvent();
            Init(isPostBack);
        }

        private void AttachEvent()
        {
            _View.SearchEvent += SearchDiyPrcessError;
            _View.UpdateStatusEvent += IgnoreError;
        }

        private void Init(bool isPostBack)
        {
            if (!isPostBack)
            {
                _View.ShowIgnore = false;
                SearchDiyPrcessError();
            }
        }


        protected virtual void SearchDiyPrcessError()
        {
        }

        private void IgnoreError(string typeid, string markid)
        {
            _ISystemErrorFacade.UpdateErrorStatus(
                new SystemError("", ErrorType.GetErrorTypeByID(Convert.ToInt32(typeid)), Convert.ToInt32(markid)));
        }
    }
}