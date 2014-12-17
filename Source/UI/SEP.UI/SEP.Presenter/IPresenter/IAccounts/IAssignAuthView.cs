using System;
using System.Collections.Generic;
using SEP.Model.Accounts;

namespace SEP.Presenter.IPresenter.IAccounts
{
    public interface IAssignAuthView
    {
        List<Auth> AccountsBackAuth{ get; set;}

        //List<Account> AccountSource { set;}

        //int AccountsBackID { get; set;}

        string AccountBackName { get;}

        string ResultMessage { get; set;}

        string AccountMsg { get; set;}

        List<Auth> AuthSource { get; set;}

        event EventHandler btnOKClick;
        event Core.DelegateID btnLinkClick;
        event EventHandler drdRoleSelectedIndexChanged;
    }
}