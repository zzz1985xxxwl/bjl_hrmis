using System;
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IAuth
{
    public interface IAssignHrmisAuthView
    {
        List<Auth> AccountsBackAuth { get; set;}

        string AccountBackName { get;}

        string ResultMessage { get; set;}

        List<Auth> AuthSource { get; set;}

        event EventHandler btnOKClick;

        event DelegateID btnLinkClick;

        event EventHandler drdRoleSelectedIndexChanged;
    }
}
