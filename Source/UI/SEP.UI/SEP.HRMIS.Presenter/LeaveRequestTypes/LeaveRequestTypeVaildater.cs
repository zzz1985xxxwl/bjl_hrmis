using SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType;

namespace SEP.HRMIS.Presenter.LeaveRequestTypes
{
    public class LeaveRequestTypeVaildater
    {
        private readonly ILeaveRequestTypeView _ItsView;

        public LeaveRequestTypeVaildater(ILeaveRequestTypeView itsView)
        {
            _ItsView = itsView;
        }

        public bool Vaildate()
        {
            _ItsView.NameMsg = string.Empty;
            _ItsView.LeastHourMsg = string.Empty;
            bool vaildate = true;
            decimal leastHour;
            if (string.IsNullOrEmpty(_ItsView.LeaveRequestTypeName))
            {
                _ItsView.NameMsg = LeaveRequestTypeUtility._NameIsEmpty;
                vaildate = false;
            }
            if (string.IsNullOrEmpty(_ItsView.LeastHour))
            {
                _ItsView.LeastHourMsg = LeaveRequestTypeUtility._ErrorNullLeastHour;
                vaildate = false;
            }
            else if (!decimal.TryParse(_ItsView.LeastHour, out leastHour))
            {
                _ItsView.LeastHourMsg = LeaveRequestTypeUtility._ErrorLeastHourData;
                vaildate = false;
            }
            else if (leastHour < 0)
            {
                _ItsView.LeastHourMsg = LeaveRequestTypeUtility._ErrorLeastHourData;
                vaildate = false;
            }
            else if (leastHour%0.5m != 0)
            {
                _ItsView.LeastHourMsg = LeaveRequestTypeUtility._ErrorLeastHourData;
                vaildate = false;
            }
            return vaildate;
        }
    }
}