using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet
{
    public interface IManageAccountSetParaView
    {
        IAccountSetParaListView AccountSetParaListView { get; set;}

        IAccountSetParaView AccountSetParaView { get; set;}

        bool AccountSetParaViewVisible { get; set; }
    }
}
