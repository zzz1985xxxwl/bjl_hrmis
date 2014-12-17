using System;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics.IndexView;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.SummaryStatistics.IndexView
{
    public class TimeSpanStatisticsGroupByParaIndexPresenter
    {
        private readonly Account _Account;
        private readonly ITimeSpanStatisticsGroupByParaIndexView _ITimeSpanStatisticsGroupByParaIndexView;
        public TimeSpanStatisticsGroupByParaIndexPresenter(ITimeSpanStatisticsGroupByParaIndexView iTimeSpanStatisticsGroupByParaIndexView, Account loginUser)
        {
            _Account = loginUser;
            _ITimeSpanStatisticsGroupByParaIndexView = iTimeSpanStatisticsGroupByParaIndexView;
        }
        private void Attachment()
        {
            _ITimeSpanStatisticsGroupByParaIndexView.IStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployeeSalary;
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
            new TimeSpanStatisticsGroupByParaTablePresenter(_ITimeSpanStatisticsGroupByParaIndexView.ITimeSpanStatisticsGroupByParaTableView,
                                        _ITimeSpanStatisticsGroupByParaIndexView.IStatisticsConditionView, _Account).InitView();
            _ITimeSpanStatisticsGroupByParaIndexView.ITimeSpanStatisticsGroupByParaLineChartView.gvTimeSpanStatisticsGroupByParaSource =
                _ITimeSpanStatisticsGroupByParaIndexView.ITimeSpanStatisticsGroupByParaTableView.gvTimeSpanStatisticsGroupByParaSource;
        }

        private void InitStatisticsCondition(bool isPostBack)
        {
            StatisticsConditionPresenter statisticsConditionFontPresenter =
                new StatisticsConditionPresenter(_ITimeSpanStatisticsGroupByParaIndexView.IStatisticsConditionView, _Account);
            statisticsConditionFontPresenter.InitPresent(isPostBack);
            _ITimeSpanStatisticsGroupByParaIndexView.IStatisticsConditionView.btnExportVisible = false;
        }


        public void StatisticsEmployeeSalary(object source, EventArgs e)
        {
            if (new StatisticsConditionPresenter(_ITimeSpanStatisticsGroupByParaIndexView.IStatisticsConditionView, _Account).
                    CheckValid())
            {
                try
                {
                    TimeSpanStatisticsGroupByParaTablePresenter averageStatisticsTablePresenter =
                        new TimeSpanStatisticsGroupByParaTablePresenter(_ITimeSpanStatisticsGroupByParaIndexView.ITimeSpanStatisticsGroupByParaTableView,
                                                            _ITimeSpanStatisticsGroupByParaIndexView.IStatisticsConditionView, _Account);
                    averageStatisticsTablePresenter.DrawChart();
                    _ITimeSpanStatisticsGroupByParaIndexView.ITimeSpanStatisticsGroupByParaLineChartView.gvTimeSpanStatisticsGroupByParaSource =
                        _ITimeSpanStatisticsGroupByParaIndexView.ITimeSpanStatisticsGroupByParaTableView.gvTimeSpanStatisticsGroupByParaSource;
                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }
    }
}
