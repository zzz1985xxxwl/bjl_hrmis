using System;
using System.Collections.Generic;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet.IAccountSet
{
    public interface IAccountSetListView
    {
        event DelegateNoParameter btnAddClick;
        event DelegateID btnUpdateClick;
        event DelegateID btnDeleteClick;
        event DelegateID btnDetailClick;
        event EventHandler BindAccountSetListSource;
        event DelegateID btnCopyClick;

        List<Model.PayModule.AccountSet> AccountSetListDataSource { get; set; }

        string AccountSetName { get; }

        Model.PayModule.AccountSet SessionCopyAccountSet { get; set; }
    }
}
