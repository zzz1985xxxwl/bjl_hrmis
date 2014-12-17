using System;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class LeaveRequestDataCollector
    {
        private readonly ILeaveRequestInfoView _ItsView;
        public LeaveRequestDataCollector(ILeaveRequestInfoView view)
        {
            _ItsView = view;
        }

        public void CompleteTheObject(ref LeaveRequest theObjectToComplete)
        {
            theObjectToComplete = new LeaveRequest();
            theObjectToComplete.PKID = string.IsNullOrEmpty(_ItsView.LeaveRequestID)
                                           ? 0
                                           : Convert.ToInt32(_ItsView.LeaveRequestID);
            theObjectToComplete.Account = new Account(Convert.ToInt32(_ItsView.EmployeeID), "", "");
            theObjectToComplete.Reason = _ItsView.Remark;
            theObjectToComplete.SubmitDate = DateTime.Now;
            theObjectToComplete.LeaveRequestType = _ItsView.LeaveRequestType;
            theObjectToComplete.LeaveRequestItems = _ItsView.LeaveRequestItemList;
            theObjectToComplete.MailCC = _ItsView.MailCC;
        }
    }
}
