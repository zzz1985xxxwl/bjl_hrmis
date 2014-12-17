namespace SEP.HRMIS.Presenter.IPresenter.ILeaveRequest
{
    public interface IMyLeaveRequestInfoView
    {
        IMyLeaveRequestListView MyLeaveRequestListView { get;}

        ILeaveRequestOperationView LeaveRequestOperationView{ get;}

        IMyLeaveRequestConfirmListView MyLeaveRequestConfirmListView { get;}

        IMyLeaveRequestConfirmHistoryListView MyLeaveRequestConfirmHistoryListView{ get;}

        bool LeaveRequestOperationViewVisible{ set;}

        string LeaveRequestConfirmCount { get; set;}

        string MyLeaveRequestCount { get; set;}

        string MyLeaveRequestConfirmHistoryCount { get; set;}

        string ResultMessage { get; set;}
    }
}
