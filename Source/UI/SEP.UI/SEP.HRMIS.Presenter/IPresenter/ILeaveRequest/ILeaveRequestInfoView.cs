using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.ILeaveRequest
{
    public interface ILeaveRequestInfoView
    {
        bool NotCalculate { get; set;}

        string LeaveRequestID { get; set;}

        string ResultMessage { get; set;}

        string EmployeeID { get; set;}

        string EmployeeName { get; set;}

        string Remark { get; set;}

        LeaveRequestType LeaveRequestType { get; set;}

        string TypeMessage { get; set;}

        string RemarkMessage { get; set;}

        string OperationType { get; set;}

        List<LeaveRequestType> LeaveRequestTypeSource { get; set;}

        string btnOKText { get; set;}

        string btnCancelText { get; set;}

        string TimeSpan { get; set;}

        string CostTime { get; set;}

        List<LeaveRequestItem> LeaveRequestItemList { get; set;}

        bool SetFormReadOnly { get; set;}

        //AttendanceRule EmployeeAttendanceRule { get; set;}

        decimal? AnnualLeave { get; set;}

        //bool SetFormCancel{ set;}

        event EventHandler ddlAbsentTypeSelected;

        event EventHandler btnOKClick;

        event EventHandler btnSubmitClick;

        event DelegateID LeaveRequestItemForAddAtEvent;

        event DelegateID LeaveRequestItemForDeleteAtEvent;

        string Remind { get; set; }

        List<Account> MailCC { get; set; }
    }
}
