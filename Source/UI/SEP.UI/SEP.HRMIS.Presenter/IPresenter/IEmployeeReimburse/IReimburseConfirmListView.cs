using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse
{
    public interface IReimburseConfirmListView
    {
        Employee EmployeeReimbursingSource { set; }
        event EventHandler BindEmployeeReimbursingSource;
        event CommandEventHandler btnViewClick;
        event CommandEventHandler QuickPassEvent;
        event DelegateNoParameter UpdateView;
    }
}
