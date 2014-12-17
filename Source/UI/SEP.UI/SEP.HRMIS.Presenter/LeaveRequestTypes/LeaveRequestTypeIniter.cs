using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType;

namespace SEP.HRMIS.Presenter.LeaveRequestTypes
{
    public class LeaveRequestTypeIniter
    {
        private readonly ILeaveRequestTypeView _ItsView;

        public LeaveRequestTypeIniter(ILeaveRequestTypeView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            _ItsView.LeaveRequestTypeID = string.Empty;
            _ItsView.LeastHour = string.Empty;
            _ItsView.LeaveRequestTypeName = string.Empty;
            _ItsView.LeaveRequestTypeDescription = string.Empty;
            _ItsView.NameMsg = string.Empty;
            _ItsView.LeastHourMsg = string.Empty;
            _ItsView.Message = string.Empty;
            _ItsView.OperationTitle = string.Empty;
            _ItsView.IncludeLegalHoliday = LegalHoliday.UnInclude;
            _ItsView.IncludeRestDay = RestDay.UnInclude;

        }
    }
}