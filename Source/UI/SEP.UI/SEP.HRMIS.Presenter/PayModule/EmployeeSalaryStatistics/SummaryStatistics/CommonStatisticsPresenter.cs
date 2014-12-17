using System;
using SEP.IBll;
using SEP.IBll.Departments;
using PayModuleIPresenter = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.SummaryStatistics
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

        public void InitStatisticsCondition(bool isPostBack)
        {
            StatisticsConditionPresenter statisticsConditionBackPresenter =
                new StatisticsConditionPresenter(_ICommonStatisticsView.IStatisticsConditionView, _Operator);
            statisticsConditionBackPresenter.InitPresent(isPostBack);
        }

        public bool CheckValid()
        {
            return new StatisticsConditionPresenter(_ICommonStatisticsView.IStatisticsConditionView, _Operator).CheckValid();
        }
        private void InitChildPresenter()
        {
            new DepartmentStatisticsTablePresenter(_ICommonStatisticsView.IDepartmentStatisticsTableView,
                                            _ICommonStatisticsView.IStatisticsConditionView, _Operator).InitView();

            _ICommonStatisticsView.IDepartmentStatisticsBarChartView.gvDepartmentStatisticsSource =
                _ICommonStatisticsView.IDepartmentStatisticsTableView.gvDepartmentStatisticsTableSource;

            new PositionStatisticsTablePresenter(_ICommonStatisticsView.IPositionStatisticsTableView,
                                            _ICommonStatisticsView.IStatisticsConditionView, _Operator).InitView();

            _ICommonStatisticsView.IPositionStatisticsBarChartView.gvPositionStatisticsSource =
                _ICommonStatisticsView.IPositionStatisticsTableView.gvPositionStatisticsTableSource;

            new TimeSpanStatisticsGroupByParaTablePresenter(_ICommonStatisticsView.ITimeSpanStatisticsGroupByParaTableView,
                                                    _ICommonStatisticsView.IStatisticsConditionView, _Operator).InitView();
            _ICommonStatisticsView.ITimeSpanStatisticsGroupByParaLineChartView.gvTimeSpanStatisticsGroupByParaSource
                 =
                _ICommonStatisticsView.ITimeSpanStatisticsGroupByParaTableView.gvTimeSpanStatisticsGroupByParaSource;
        }

        public void StatisticsEmployeeSalary(object source, EventArgs e)
        {
            if (CheckValid())
            {
                try
                {
                    DepartmentStatisticsTablePresenter departmentStatisticsTablePresenter =
                        new DepartmentStatisticsTablePresenter(_ICommonStatisticsView.IDepartmentStatisticsTableView,
                                                    _ICommonStatisticsView.IStatisticsConditionView, _Operator);
                    departmentStatisticsTablePresenter.DrawChart();

                    _ICommonStatisticsView.IDepartmentStatisticsBarChartView.gvDepartmentStatisticsSource =
                        _ICommonStatisticsView.IDepartmentStatisticsTableView.gvDepartmentStatisticsTableSource;

                    PositionStatisticsTablePresenter positionStatisticsTablePresenter =
                        new PositionStatisticsTablePresenter(_ICommonStatisticsView.IPositionStatisticsTableView,
                                                    _ICommonStatisticsView.IStatisticsConditionView, _Operator);
                    positionStatisticsTablePresenter.DrawChart();

                    _ICommonStatisticsView.IPositionStatisticsBarChartView.gvPositionStatisticsSource =
                        _ICommonStatisticsView.IPositionStatisticsTableView.gvPositionStatisticsTableSource;

                    TimeSpanStatisticsGroupByParaTablePresenter timeSpanStatisticsGroupByParaTablePresenter =
                        new TimeSpanStatisticsGroupByParaTablePresenter(_ICommonStatisticsView.ITimeSpanStatisticsGroupByParaTableView,
                                                            _ICommonStatisticsView.IStatisticsConditionView, _Operator);
                    timeSpanStatisticsGroupByParaTablePresenter.DrawChart();
                    _ICommonStatisticsView.ITimeSpanStatisticsGroupByParaLineChartView.gvTimeSpanStatisticsGroupByParaSource
                         =
                        _ICommonStatisticsView.ITimeSpanStatisticsGroupByParaTableView.gvTimeSpanStatisticsGroupByParaSource;

                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }
}
}
