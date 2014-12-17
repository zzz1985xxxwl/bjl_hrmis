using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Presenter.IPresenter.ILeaveRequest
{
    public interface IMyLeaveRequestConfirmHistoryListView
    {
        int ListCount{ get;}

        string EmployeeName { get;}

        string FromDate { get; set;}

        string ToDate { get; set;}

        string DateMsg { get; set;}

        bool DisplaySearchCondition { set;}

        List<LeaveRequest> LeaveRequestSource { get;set;}

        event CommandEventHandler btnViewClick;

        event EventHandler BindLeaveRequestSource;
    }
}
