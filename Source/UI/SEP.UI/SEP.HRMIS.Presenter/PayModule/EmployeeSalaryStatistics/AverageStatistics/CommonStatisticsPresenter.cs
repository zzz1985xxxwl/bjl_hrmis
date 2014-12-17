using System;
using SEP.IBll;
using SEP.IBll.Departments;
using PayModuleIPresenter = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.AverageStatistics
{
    public class CommonStatisticsPresenter
    {
        private readonly Account _Operator;
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public readonly PayModuleIPresenter.ICommonStatisticsView _ICommonStatisticsView;
        public CommonStatisticsPresenter(PayModuleIPresenter.ICommonStatisticsView iCommonStatisticsView, Account _operator)
        {
            _ICommonStatisticsView = iCommonStatisticsView;
            _Operator = _operator;
        }

        private void Attachment()
        {
            _ICommonStatisticsView.IStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployeeSalary;
        }

        public void InitPresent(bool isPostBack)
        {
            Attachment();
            InitStatisticsCondition(isPostBack);
            InitChildPresenter();
        }

        private void InitChildPresenter()
        {
            new AverageStatisticsTablePresenter(_ICommonStatisticsView.IAverageStatisticsTableView,
                                                _ICommonStatisticsView.IStatisticsConditionView, _Operator).InitView();
            _ICommonStatisticsView.IAverageStatisticsBarChartView.gvAverageStatisticsSource =
                _ICommonStatisticsView.IAverageStatisticsTableView.gvAverageStatisticsTableSource;

            new TimeSpanStatisticsGroupByDeptTablePresenter(
                _ICommonStatisticsView.ITimeSpanStatisticsGroupByDeptTableView,
                _ICommonStatisticsView.IStatisticsConditionView, _Operator).InitView();
            _ICommonStatisticsView.ITimeSpanStatisticsGroupByDeptLineChartView.
                gvTimeSpanStatisticsGroupByDeptSource =
                _ICommonStatisticsView.ITimeSpanStatisticsGroupByDeptTableView.gvTimeSpanStatisticsGroupByDeptSource;
        }

        public void StatisticsEmployeeSalary(object source, EventArgs e)
        {
            if (CheckValid())
            {
                try
                {
                    AverageStatisticsTablePresenter averageStatisticsTablePresenter =
                        new AverageStatisticsTablePresenter(_ICommonStatisticsView.IAverageStatisticsTableView,
                                                            _ICommonStatisticsView.IStatisticsConditionView, _Operator);
                    averageStatisticsTablePresenter.DrawChart();
                    _ICommonStatisticsView.IAverageStatisticsBarChartView.gvAverageStatisticsSource =
                        _ICommonStatisticsView.IAverageStatisticsTableView.gvAverageStatisticsTableSource;

                    TimeSpanStatisticsGroupByDeptTablePresenter timeSpanStatisticsGroupByDeptTablePresenter =
                        new TimeSpanStatisticsGroupByDeptTablePresenter(_ICommonStatisticsView.ITimeSpanStatisticsGroupByDeptTableView,
                                                            _ICommonStatisticsView.IStatisticsConditionView, _Operator);
                    timeSpanStatisticsGroupByDeptTablePresenter.DrawChart();
                    _ICommonStatisticsView.ITimeSpanStatisticsGroupByDeptLineChartView.
                        gvTimeSpanStatisticsGroupByDeptSource =
                        _ICommonStatisticsView.ITimeSpanStatisticsGroupByDeptTableView.gvTimeSpanStatisticsGroupByDeptSource;

                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        public void InitStatisticsCondition(bool isPostBack)
        {
            StatisticsConditionPresenter statisticsConditionBackPresenter =
                new StatisticsConditionPresenter(_ICommonStatisticsView.IStatisticsConditionView, _Operator);
            statisticsConditionBackPresenter.InitPresent(isPostBack);
        }

        public bool CheckValid()
        {
            return
                new StatisticsConditionPresenter(_ICommonStatisticsView.IStatisticsConditionView, _Operator).
                    CheckValid();
        }
    }
}
