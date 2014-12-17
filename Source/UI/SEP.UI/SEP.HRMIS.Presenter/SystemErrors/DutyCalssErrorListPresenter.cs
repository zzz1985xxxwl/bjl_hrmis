//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: DutyCalssErrorListPresenter.cs
// Creater:  Xue.wenlong
// Date:  2009-10-20
// Resume:
// ----------------------------------------------------------------

using SEP.HRMIS.Presenter.IPresenter.ISystemError;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.SystemErrors
{
    /// <summary>
    /// </summary>
    public class DutyCalssErrorListPresenter: ErrorListBasePresenter
    {
        public DutyCalssErrorListPresenter(ISystemErrorListPresenter view, Account loginUser, bool isPostBack)
            : base(view, loginUser, isPostBack)
        {
        }


        protected override void SearchDiyPrcessError()
        {
            _View.SystemErrors = _ISystemErrorFacade.GetDutyCalssError(_View.ShowIgnore, _LoginUser);
        }
    }
}