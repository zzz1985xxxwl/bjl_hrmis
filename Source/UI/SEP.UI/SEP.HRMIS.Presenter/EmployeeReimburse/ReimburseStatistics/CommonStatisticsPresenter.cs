using System;
using ReimburseIPresenter = SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseStatistics
{
    public abstract class CommonStatisticsPresenter
    {
        private readonly Account _Operator;
        public readonly ReimburseIPresenter.ICommonStatisticsView _ICommonStatisticsView;
        public CommonStatisticsPresenter(ReimburseIPresenter.ICommonStatisticsView iCommonStatisticsView, Account _operator)
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
            new DepartmentStatisticsTablePresenter(_ICommonStatisticsView.IDepartmentStatisticsTableView,
                                            _ICommonStatisticsView.IStatisticsConditionView, _Operator).InitView();

            _ICommonStatisticsView.IDepartmentStatisticsBarChartView.gvDepartmentStatisticsSource =
                _ICommonStatisticsView.IDepartmentStatisticsTableView.gvDepartmentStatisticsTableSource;
        }

        protected abstract void InitStatisticsCondition(bool isPostBack);

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
