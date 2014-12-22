using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using PayModuleIPresenter = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.AverageStatistics
{
    public class AverageStatisticsBarChartPresenter
    {
        private readonly PayModuleIPresenter.IAverageStatisticsBarChartView _IAverageStatisticsBarChartView;
        private readonly PayModuleIPresenter.IStatisticsConditionView _IStatisticsConditionView;
        private readonly Account _LoginUser;

        public AverageStatisticsBarChartPresenter(PayModuleIPresenter.IAverageStatisticsBarChartView iAverageStatisticsBarChartView,
            PayModuleIPresenter.IStatisticsConditionView iStatisticsConditionView, Account loginUser)
        {
            _LoginUser = loginUser;
            _IAverageStatisticsBarChartView = iAverageStatisticsBarChartView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }
        public void InitView()
        {
            _IAverageStatisticsBarChartView.gvAverageStatisticsSource = null;
        }

        public void DrawChart()
        {
            if (_IAverageStatisticsBarChartView.gvAverageStatisticsSource == null)
            {
                IEmployeeSalaryStatisticsFacade _IEmployeeSalaryStatisticsFacade =
                    InstanceFactory.CreateEmployeeSalaryStatisticsFacade();
                List<EmployeeSalaryAverageStatistics> employeeSalaryAverageStatistics =
                    _IEmployeeSalaryStatisticsFacade.AverageStatistics(
                        Convert.ToDateTime(_IStatisticsConditionView.FromDate),
                        Convert.ToDateTime(_IStatisticsConditionView.ToDate),
                        _IStatisticsConditionView.DepartmentID,
                        _IStatisticsConditionView.SelectedAccountSetPara, _IStatisticsConditionView.CompanyID,
                        _IStatisticsConditionView.IsAccumulated, _LoginUser);

                _IAverageStatisticsBarChartView.gvAverageStatisticsSource =
                    UtilityPresenter.TurnToEmployeeSalaryAverageStatisticsDataTable(employeeSalaryAverageStatistics);
            }
        }

    }
}
