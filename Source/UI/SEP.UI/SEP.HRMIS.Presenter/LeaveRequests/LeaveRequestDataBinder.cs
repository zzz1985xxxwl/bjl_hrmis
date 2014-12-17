using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class LeaveRequestDataBinder
    {
        public ILeaveRequestFacade _ILeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();
        private readonly ILeaveRequestInfoView _ItsView;

        public LeaveRequestDataBinder(ILeaveRequestInfoView itsView)
        {
            _ItsView = itsView;
        }

        public bool DataBind(int leaveRequestTypeId)
        {
            LeaveRequest theDataToBind = _ILeaveRequestFacade.GetLeaveRequestByPKID(leaveRequestTypeId);

            if (theDataToBind != null)
            {
                _ItsView.LeaveRequestID = theDataToBind.PKID.ToString();
                _ItsView.EmployeeID = theDataToBind.Account.Id.ToString();
                _ItsView.EmployeeName = theDataToBind.Account.Name;
                _ItsView.Remark = theDataToBind.Reason;
                _ItsView.LeaveRequestType = theDataToBind.LeaveRequestType;
                _ItsView.CostTime = theDataToBind.CostTime.ToString();
                _ItsView.TimeSpan = theDataToBind.FromDate + " ～ " + theDataToBind.ToDate;
                _ItsView.LeaveRequestItemList = theDataToBind.LeaveRequestItems;
                if (theDataToBind.IfAutoCancel)
                {
                    _ItsView.Remind = "注：当前请假单已有提交记录，如果再次编辑，系统将自动取消之前的所有流程，并以编辑后的信息为准重新进行“暂存”/“提交”操作。";
                }
                return true;
            }
            return false;
        }
    }
}