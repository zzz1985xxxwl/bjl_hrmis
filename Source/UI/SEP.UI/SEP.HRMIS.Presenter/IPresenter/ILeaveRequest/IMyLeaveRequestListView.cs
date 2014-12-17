using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.Request;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ILeaveRequest
{
    public interface IMyLeaveRequestListView
    {
        int ListCount{ get;}

        int EmployeeID { get; set;}

        List<LeaveRequest> LeaveRequestSource{ get; set;}

        event EventHandler BindLeaveRequestSource;

        event DelegateID btnViewClick;

        event DelegateID btnUpdateClick;

        event DelegateID btnDeleteClick;

        event DelegateID btnCancelClick;

        event DelegateID btnCancelItemClick;

        event DelegateNoParameter btnAddClick;
    }
}
