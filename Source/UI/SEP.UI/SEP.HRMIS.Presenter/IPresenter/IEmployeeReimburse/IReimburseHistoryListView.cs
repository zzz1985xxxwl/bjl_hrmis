using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse
{
    public interface IReimburseHistoryListView
    {
        Employee EmployeeReimburseHistorySource { set; }
        event EventHandler BindEmployeeReimburseHistorySource;
        event CommandEventHandler btnViewClick;

    }
}
