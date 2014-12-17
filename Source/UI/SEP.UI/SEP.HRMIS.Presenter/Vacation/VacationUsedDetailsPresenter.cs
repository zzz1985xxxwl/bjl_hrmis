using SEP.HRMIS.IFacede;

namespace SEP.HRMIS.Presenter
{
    public class VacationUsedDetailsPresenter
    {
        private readonly IVacationUsedDetailsView _View;
        private readonly ILeaveRequestFacade _LeaveRequestFacade = InstanceFactory.CreateLeaveRequestFacade();

        public VacationUsedDetailsPresenter(IVacationUsedDetailsView view)
        {
            _View = view;
            Init();
        }

        private void Init()
        {
            _View.LeaveRequestItemList = _LeaveRequestFacade.GetVacationUsedDetailByAccountID(_View.Employee.Account.Id);
        }
    }
}