using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse
{
    public interface IReimbursingListView
    {
        Employee EmployeeReimbursingSource { set; }
        event EventHandler btnAddClick;
        event EventHandler BindEmployeeReimbursingSource;
        event CommandEventHandler btnUpdateClick;
        event CommandEventHandler btnDeleteClick;
        event CommandEventHandler btnViewClick;
        event DelegateNoParameter UpdateView;
    }
}
