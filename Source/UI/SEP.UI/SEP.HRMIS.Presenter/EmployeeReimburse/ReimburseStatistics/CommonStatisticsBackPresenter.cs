
using ReimburseStatisticsIPresenter = SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseStatistics
{
    public class CommonStatisticsBackPresenter : CommonStatisticsPresenter
    {
        private readonly Account _Operator;
        public CommonStatisticsBackPresenter(ReimburseStatisticsIPresenter.ICommonStatisticsView iCommonStatisticsView, Account loginUser)
            : base(iCommonStatisticsView,loginUser)
        {
            _Operator = loginUser;
        }

        protected override void InitStatisticsCondition(bool isPostBack)
        {
            StatisticsConditionBackPresenter statisticsConditionBackPresenter =
                new StatisticsConditionBackPresenter(_ICommonStatisticsView.IStatisticsConditionView, _Operator);
            statisticsConditionBackPresenter.InitPresent(isPostBack);
        }

        protected override bool CheckValid()
        {
            return new StatisticsConditionBackPresenter(_ICommonStatisticsView.IStatisticsConditionView, _Operator).CheckValid();
        }
    }
}
