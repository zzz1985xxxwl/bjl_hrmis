//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DiyProcessErrorListPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-10-09
// Resume:
// ----------------------------------------------------------------

using SEP.HRMIS.Model.SystemError;
using SEP.HRMIS.Presenter.IPresenter.ISystemError;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.SystemErrors
{
    /// <summary>
    /// </summary>
    public class DiyProcessErrorListPresenter : ErrorListBasePresenter
    {
        public DiyProcessErrorListPresenter(ISystemErrorListPresenter view, Account loginUser, bool isPostBack)
            : base(view, loginUser, isPostBack)
        {
        }


        protected override void SearchDiyPrcessError()
        {
            _View.SystemErrors = _ISystemErrorFacade.GetDiyProcessError(_View.ShowIgnore, ErrorType.All, _LoginUser);
        }
    }
}