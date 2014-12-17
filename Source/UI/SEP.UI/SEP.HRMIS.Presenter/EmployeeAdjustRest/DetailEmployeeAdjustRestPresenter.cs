using SEP.HRMIS.Presenter.IPresenter.IEmployeeAdjustRest;

namespace SEP.HRMIS.Presenter.EmployeeAdjustRest
{
    public class DetailEmployeeAdjustRestPresenter
    {
        private readonly IEmployeeAdjustRestView _ItsView;
        private readonly string _AccountID;
        public DetailEmployeeAdjustRestPresenter(IEmployeeAdjustRestView itsView, string accountID)
        {
            _ItsView = itsView;
            _AccountID = accountID;
        }

        public void InitView()
        {
            _ItsView.Message = string.Empty;
            new EmployeeAdjustRestDataBinder(_ItsView).DataBind(_AccountID);
        }
    }
}
