using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;

namespace SEP.HRMIS.Presenter.LeaveRequests
{
    public class LeaveRequestValidater
    {
        private readonly ILeaveRequestInfoView _ItsView;

        public LeaveRequestValidater(ILeaveRequestInfoView view)
        {
            _ItsView = view;
        }

        public bool Vaildate()
        {
            _ItsView.RemarkMessage = string.Empty;
            _ItsView.TypeMessage = string.Empty;
            _ItsView.ResultMessage = string.Empty;

            bool vaildate = true;
            if (string.IsNullOrEmpty(_ItsView.Remark.Trim()))
            {
                _ItsView.RemarkMessage = LeaveRequestUtility._IsEmpty;
                vaildate = false;
            }
            if (_ItsView.LeaveRequestType.LeaveRequestTypeID == -1)
            {
                _ItsView.TypeMessage = LeaveRequestUtility._IsEmpty;
                vaildate = false;
            }
            if (_ItsView.LeaveRequestItemList.Count == 0)
            {
                _ItsView.ResultMessage = LeaveRequestUtility._LeaveRequestItemNone;
                vaildate = false;
            }
            for (int i = 0; i < _ItsView.LeaveRequestItemList.Count; i++)
            {
                if (_ItsView.LeaveRequestItemList[i].FromDate > _ItsView.LeaveRequestItemList[i].ToDate)
                {
                    vaildate = false;
                    _ItsView.ResultMessage = LeaveRequestUtility._Time;
                    break;
                }
            }
            return vaildate;
        }
    }
}