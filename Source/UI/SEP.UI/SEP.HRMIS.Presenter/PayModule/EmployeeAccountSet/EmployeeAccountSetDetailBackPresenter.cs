using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;
namespace SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet
{
    public class EmployeeAccountSetDetailBackPresenter
    {
        private readonly IEmployeeAccountSetDetailBackPresenter _EmployeeAccountSetDetailBackPresenter;

        public EmployeeAccountSetDetailBackPresenter(IEmployeeAccountSetDetailBackPresenter presenter)
        {
            _EmployeeAccountSetDetailBackPresenter = presenter;
        }

        public void InitView(bool isPostBack, int employeeID)
        {
            AdjustHistoryListPresenter adjustHistoryListPresenter = new AdjustHistoryListPresenter(_EmployeeAccountSetDetailBackPresenter.AdjustHistoryListView);
            adjustHistoryListPresenter.InitPresenter(employeeID);

            EmployeeAccountSetDetailPresenter employeeAccountSetDetailPresenter =
                new EmployeeAccountSetDetailPresenter(
                    _EmployeeAccountSetDetailBackPresenter.EmployeeAccountSetDetailView);
            employeeAccountSetDetailPresenter.InitView(isPostBack,employeeID);
        }
    }
}
