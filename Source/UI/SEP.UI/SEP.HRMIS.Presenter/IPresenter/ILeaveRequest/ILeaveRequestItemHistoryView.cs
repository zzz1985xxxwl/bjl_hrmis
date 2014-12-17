using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Presenter.IPresenter.ILeaveRequest
{
    public interface ILeaveRequestItemHistoryView
    {
        List<LeaveRequestFlow> LeaveRequestSource{ set;}

        event EventHandler BindLeaveRequestSource;
    }
}
