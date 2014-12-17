
using ReimburseStatisticsIPresenter = SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseStatistics
{
    public class EmployeeCommonStatisticsBackPresenter : EmployeeCommonStatisticsPresenter
    {
        private readonly Account _Operator;
        public EmployeeCommonStatisticsBackPresenter
            (ReimburseStatisticsIPresenter.IEmployeeCommonStatisticsView iEmployeeCommonStatisticsView, 
            Account loginUser)
            : base(iEmployeeCommonStatisticsView, loginUser)
        {
            _Operator = loginUser;
        }

        protected override void InitStatisticsCondition(bool isPostBack)
        {
            EmployeeStatisticsConditionBackPresenter employeeStatisticsConditionBackPresenter =
                new EmployeeStatisticsConditionBackPresenter(_IEmployeeCommonStatisticsView.IEmployeeStatisticsConditionView, _Operator);
            employeeStatisticsConditionBackPresenter.InitPresent(isPostBack);
        }

        protected override bool CheckValid()
        {
            return new EmployeeStatisticsConditionBackPresenter(_IEmployeeCommonStatisticsView.IEmployeeStatisticsConditionView, _Operator).CheckValid();
        }
    }
}
