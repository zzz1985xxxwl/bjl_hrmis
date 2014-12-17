using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet
{
    public interface IAdjustHistoryListPresenter
    {
        string EmployeeName { set;}

        string ResultMessage{ set;}

        List<AdjustSalaryHistory> AdjustSalaryHistoryList { set;}

        event CommandEventHandler GoToAdjustHistoryDetailPage;
        event EventHandler GoToBackPage;
    }
}
