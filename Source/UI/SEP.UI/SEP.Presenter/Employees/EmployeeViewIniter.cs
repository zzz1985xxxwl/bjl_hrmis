using SEP.Presenter.IPresenter.IEmployees;

namespace SEP.Presenter.Employees
{
    public class EmployeeViewIniter
    {
        private readonly IEmployeeDetailPresenter _ItsView;

        public EmployeeViewIniter(IEmployeeDetailPresenter view)
        {
            _ItsView = view;
        }

        public void SetMessageEmpty()
        {
            //_ItsView.Operation = string.Empty;
            _ItsView.ResultMessage = string.Empty;
            _ItsView.DepartmentMsg = string.Empty;
            _ItsView.EmailMsg = string.Empty;
            _ItsView.LoginNameMsg = string.Empty;
            _ItsView.NameMsg = string.Empty;
            _ItsView.PositionMsg = string.Empty;
        }

    }
}
