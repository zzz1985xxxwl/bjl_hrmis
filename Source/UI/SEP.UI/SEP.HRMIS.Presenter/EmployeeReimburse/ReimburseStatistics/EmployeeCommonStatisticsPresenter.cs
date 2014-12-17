using System;
using ReimburseIPresenter = SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseStatistics
{
    public abstract class EmployeeCommonStatisticsPresenter
    {
        private readonly Account _Operator;
        public readonly ReimburseIPresenter.IEmployeeCommonStatisticsView _IEmployeeCommonStatisticsView;
        public EmployeeCommonStatisticsPresenter
            (ReimburseIPresenter.IEmployeeCommonStatisticsView iEmployeeCommonStatisticsView, Account _operator)
        {
            _IEmployeeCommonStatisticsView = iEmployeeCommonStatisticsView;
            _Operator = _operator;
        }
        private void Attachment()
        {
            _IEmployeeCommonStatisticsView.IEmployeeStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployeeSalary;
        }

        public void InitPresent(bool isPostBack)
        {
            Attachment();
            InitStatisticsCondition(isPostBack);
            InitChildPresenter();
        }

        private void InitChildPresenter()
        {
            new EmployeeStatisticsTablePresenter(_IEmployeeCommonStatisticsView.IEmployeeStatisticsTableView,
                                            _IEmployeeCommonStatisticsView.IEmployeeStatisticsConditionView, _Operator).InitView();

            _IEmployeeCommonStatisticsView.IEmployeeStatisticsBarChartView.gvEmployeeStatisticsSource =
                _IEmployeeCommonStatisticsView.IEmployeeStatisticsTableView.gvEmployeeStatisticsTableSource;
        }

        protected abstract void InitStatisticsCondition(bool isPostBack);

        public void StatisticsEmployeeSalary(object source, EventArgs e)
        {
            if (CheckValid())
            {
                try
                {
                    EmployeeStatisticsTablePresenter employeeStatisticsTablePresenter =
                        new EmployeeStatisticsTablePresenter
                        (_IEmployeeCommonStatisticsView.IEmployeeStatisticsTableView,
                                                    _IEmployeeCommonStatisticsView.IEmployeeStatisticsConditionView, _Operator);
                    employeeStatisticsTablePresenter.DrawChart();

                    _IEmployeeCommonStatisticsView.IEmployeeStatisticsBarChartView.gvEmployeeStatisticsSource =
                        _IEmployeeCommonStatisticsView.IEmployeeStatisticsTableView.gvEmployeeStatisticsTableSource;

                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        protected abstract bool CheckValid();
    }
}
