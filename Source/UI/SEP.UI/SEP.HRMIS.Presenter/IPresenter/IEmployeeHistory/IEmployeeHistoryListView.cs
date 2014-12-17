using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeHistory
{
    public interface IEmployeeHistoryListView
    {
        int EmployeeID { get;set;}

        List<EmployeeHistory> EmployeeHistorySource { get;set;}

        event CommandEventHandler btnViewClick;

        event EventHandler BindEmployeeHistorySource;
    }
}