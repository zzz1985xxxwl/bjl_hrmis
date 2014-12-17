using System;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics.IndexView;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.SummaryStatistics.IndexView
{
    public class PositionStatisticsIndexPresenter
    {
        private readonly Account _Account;
        private readonly IPositionStatisticsIndexView _IPositionStatisticsIndexView;
        public PositionStatisticsIndexPresenter(IPositionStatisticsIndexView iPositionStatisticsIndexView, Account loginUser)
        {
            _Account = loginUser;
            _IPositionStatisticsIndexView = iPositionStatisticsIndexView;
        }
        private void Attachment()
        {
            _IPositionStatisticsIndexView.IStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployeeSalary;
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
            new PositionStatisticsTablePresenter(_IPositionStatisticsIndexView.IPositionStatisticsTableView,
                             _IPositionStatisticsIndexView.IStatisticsConditionView, _Account).InitView();
            _IPositionStatisticsIndexView.IPositionStatisticsBarChartView.gvPositionStatisticsSource =
                _IPositionStatisticsIndexView.IPositionStatisticsTableView.gvPositionStatisticsTableSource;
        }
        private void InitStatisticsCondition(bool isPostBack)
        {
            StatisticsConditionPresenter statisticsConditionFontPresenter =
                new StatisticsConditionPresenter(_IPositionStatisticsIndexView.IStatisticsConditionView, _Account);
            statisticsConditionFontPresenter.InitPresent(isPostBack);
            _IPositionStatisticsIndexView.IStatisticsConditionView.btnExportVisible = false;
        }


        public void StatisticsEmployeeSalary(object source, EventArgs e)
        {
            if (new StatisticsConditionPresenter(_IPositionStatisticsIndexView.IStatisticsConditionView, _Account).
                    CheckValid())
            {
                try
                {
                    PositionStatisticsTablePresenter positionStatisticsTablePresenter =
                        new PositionStatisticsTablePresenter(_IPositionStatisticsIndexView.IPositionStatisticsTableView,
                                                    _IPositionStatisticsIndexView.IStatisticsConditionView, _Account);
                    positionStatisticsTablePresenter.DrawChart();

                    _IPositionStatisticsIndexView.IPositionStatisticsBarChartView.gvPositionStatisticsSource =
                        _IPositionStatisticsIndexView.IPositionStatisticsTableView.gvPositionStatisticsTableSource;
                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }
    }
}
