using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.Request;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ILeaveRequest
{
    public interface IMyLeaveRequestConfirmListView
    {
        int ListCount{ get;}

        List<LeaveRequest> LeaveRequestSource { get;set;}

        event DelegateID _ShowWindowForConfirmOperation;

        event EventHandler BindLeaveRequestSource;

        event CommandEventHandler QuickPassEvent;

        event CommandEventHandler btnApproveClick;

        event CommandEventHandler btnViewClick;
    }
}
