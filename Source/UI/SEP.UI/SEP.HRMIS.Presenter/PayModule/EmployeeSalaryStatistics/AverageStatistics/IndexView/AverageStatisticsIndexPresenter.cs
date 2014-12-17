using System;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics.IndexView;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.AverageStatistics.IndexView
{
    public class AverageStatisticsIndexPresenter
    {
        private readonly Account _Account;
        private readonly IAverageStatisticsIndexView _IAverageStatisticsIndexView;
        public AverageStatisticsIndexPresenter(IAverageStatisticsIndexView iAverageStatisticsIndexView, Account loginUser)
        {
            _Account = loginUser;
            _IAverageStatisticsIndexView = iAverageStatisticsIndexView;
        }
        private void Attachment()
        {
            _IAverageStatisticsIndexView.IStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployeeSalary;
        }

        public void InitPresent(bool isPostBack)
        {
            Attachment();

            if (!isPostBack)
            {
                InitStatisticsCondition(isPostBack);
                //StatisticsEmployeeSalary(null, null);
            }
            InitChildPresenter();

        }

        private void InitChildPresenter()
        {
            new AverageStatisticsTablePresenter(_IAverageStatisticsIndexView.IAverageStatisticsTableView,
                                        _IAverageStatisticsIndexView.IStatisticsConditionView, _Account).InitView();
            _IAverageStatisticsIndexView.IAverageStatisticsBarChartView.gvAverageStatisticsSource =
                _IAverageStatisticsIndexView.IAverageStatisticsTableView.gvAverageStatisticsTableSource;
        }

        private void InitStatisticsCondition(bool isPostBack)
        {
            StatisticsConditionPresenter statisticsConditionFontPresenter =
                new StatisticsConditionPresenter(_IAverageStatisticsIndexView.IStatisticsConditionView, _Account);
            statisticsConditionFontPresenter.InitPresent(isPostBack);
            _IAverageStatisticsIndexView.IStatisticsConditionView.btnExportVisible = false;
        }


        public void StatisticsEmployeeSalary(object source, EventArgs e)
        {
            if (new StatisticsConditionPresenter(_IAverageStatisticsIndexView.IStatisticsConditionView, _Account).
                    CheckValid())
            {
                try
                {
                    AverageStatisticsTablePresenter averageStatisticsTablePresenter =
                        new AverageStatisticsTablePresenter(_IAverageStatisticsIndexView.IAverageStatisticsTableView,
                                                            _IAverageStatisticsIndexView.IStatisticsConditionView, _Account);
                    averageStatisticsTablePresenter.DrawChart();
                    _IAverageStatisticsIndexView.IAverageStatisticsBarChartView.gvAverageStatisticsSource =
                        _IAverageStatisticsIndexView.IAverageStatisticsTableView.gvAverageStatisticsTableSource;
                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

    }
}
