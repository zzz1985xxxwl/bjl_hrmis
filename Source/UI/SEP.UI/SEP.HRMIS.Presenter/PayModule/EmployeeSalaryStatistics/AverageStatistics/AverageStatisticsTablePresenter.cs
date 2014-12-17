using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using PayModuleIPresenter = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.AverageStatistics
{
    public class AverageStatisticsTablePresenter
    {
        private readonly PayModuleIPresenter.IAverageStatisticsTableView _IAverageStatisticsTableView;
        private readonly PayModuleIPresenter.IStatisticsConditionView _IStatisticsConditionView;
        private readonly Account _LoginUser;

        public AverageStatisticsTablePresenter(PayModuleIPresenter.IAverageStatisticsTableView iAverageStatisticsTableView,
            PayModuleIPresenter.IStatisticsConditionView iStatisticsConditionView, Account loginUser)
        {
            _LoginUser = loginUser;
            _IAverageStatisticsTableView = iAverageStatisticsTableView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }
        public void InitView()
        {
            _IAverageStatisticsTableView.gvAverageStatisticsTableSource = null;
        }

        public void DrawChart()
        {
            if (_IAverageStatisticsTableView.gvAverageStatisticsTableSource == null)
            {
                IEmployeeSalaryStatisticsFacade _IEmployeeSalaryStatisticsFacade =PayModuleInstanceFactory.CreateEmployeeSalaryStatisticsFacade();
                List<EmployeeSalaryAverageStatistics> employeeSalaryAverageStatistics =
                    _IEmployeeSalaryStatisticsFacade.AverageStatistics(
                        Convert.ToDateTime(_IStatisticsConditionView.FromDate),
                        Convert.ToDateTime(_IStatisticsConditionView.ToDate),
                        _IStatisticsConditionView.DepartmentID, _IStatisticsConditionView.SelectedAccountSetPara,
                        _IStatisticsConditionView.CompanyID,
                        _IStatisticsConditionView.IsAccumulated, _LoginUser);
                _IAverageStatisticsTableView.gvAverageStatisticsTableSource =
                    UtilityPresenter.TurnToEmployeeSalaryAverageStatisticsDataTable(employeeSalaryAverageStatistics);
            }
        }
    }
}
