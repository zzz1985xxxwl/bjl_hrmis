using System;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics.IndexView;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.SummaryStatistics.IndexView
{
    public class DepartmentStatisticsIndexPresenter
    {
        private readonly Account _Account;
        private readonly IDepartmentStatisticsIndexView _IDepartmentStatisticsIndexView;
        public DepartmentStatisticsIndexPresenter(IDepartmentStatisticsIndexView iDepartmentStatisticsIndexView, Account loginUser)
        {
            _Account = loginUser;
            _IDepartmentStatisticsIndexView = iDepartmentStatisticsIndexView;
        }
        private void Attachment()
        {
            _IDepartmentStatisticsIndexView.IStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployeeSalary;
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
            new DepartmentStatisticsTablePresenter(_IDepartmentStatisticsIndexView.IDepartmentStatisticsTableView,
                                   _IDepartmentStatisticsIndexView.IStatisticsConditionView, _Account).InitView();
            _IDepartmentStatisticsIndexView.IDepartmentStatisticsBarChartView.gvDepartmentStatisticsSource =
                _IDepartmentStatisticsIndexView.IDepartmentStatisticsTableView.gvDepartmentStatisticsTableSource;
        }
        private void InitStatisticsCondition(bool isPostBack)
        {
            StatisticsConditionPresenter statisticsConditionFontPresenter =
                new StatisticsConditionPresenter(_IDepartmentStatisticsIndexView.IStatisticsConditionView, _Account);
            statisticsConditionFontPresenter.InitPresent(isPostBack);
            _IDepartmentStatisticsIndexView.IStatisticsConditionView.btnExportVisible = false;
        }


        public void StatisticsEmployeeSalary(object source, EventArgs e)
        {
            if (new StatisticsConditionPresenter(_IDepartmentStatisticsIndexView.IStatisticsConditionView, _Account).
                    CheckValid())
            {
                try
                {
                    DepartmentStatisticsTablePresenter departmentStatisticsTablePresenter =
                        new DepartmentStatisticsTablePresenter(_IDepartmentStatisticsIndexView.IDepartmentStatisticsTableView,
                                                    _IDepartmentStatisticsIndexView.IStatisticsConditionView, _Account);
                    departmentStatisticsTablePresenter.DrawChart();

                    _IDepartmentStatisticsIndexView.IDepartmentStatisticsBarChartView.gvDepartmentStatisticsSource =
                        _IDepartmentStatisticsIndexView.IDepartmentStatisticsTableView.gvDepartmentStatisticsTableSource;
                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

    }
}
