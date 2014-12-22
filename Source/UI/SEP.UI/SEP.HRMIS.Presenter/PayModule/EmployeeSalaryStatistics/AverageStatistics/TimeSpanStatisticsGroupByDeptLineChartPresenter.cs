using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using PayModuleIPresenter = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics;
using PresenterCore = SEP.Presenter.Core;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.AverageStatistics
{
    public class TimeSpanStatisticsGroupByDeptLineChartPresenter
    {
        private readonly PayModuleIPresenter.ITimeSpanStatisticsGroupByDeptLineChartView _ITimeSpanStatisticsGroupByDeptLineChartView;
        private readonly PayModuleIPresenter.IStatisticsConditionView _IStatisticsConditionView;
        private readonly Account _LoginUser;

        public TimeSpanStatisticsGroupByDeptLineChartPresenter(PayModuleIPresenter.ITimeSpanStatisticsGroupByDeptLineChartView iTimeSpanStatisticsGroupByDeptLineChartView,
            PayModuleIPresenter.IStatisticsConditionView iStatisticsConditionView, Account loginUser)
        {
            _LoginUser = loginUser;
            _ITimeSpanStatisticsGroupByDeptLineChartView = iTimeSpanStatisticsGroupByDeptLineChartView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }
        public void InitView()
        {
            _ITimeSpanStatisticsGroupByDeptLineChartView.gvTimeSpanStatisticsGroupByDeptSource = null;
        }
        public void DrawChart()
        {
            if (_ITimeSpanStatisticsGroupByDeptLineChartView.gvTimeSpanStatisticsGroupByDeptSource == null)
            {
                IEmployeeSalaryStatisticsFacade _IEmployeeSalaryStatisticsFacade =InstanceFactory.CreateEmployeeSalaryStatisticsFacade();
                List<Model.PayModule.EmployeeSalaryStatistics> employeeSalaryStatistics =
                    _IEmployeeSalaryStatisticsFacade.TimeSpanStatisticsGroupByDepartment(
                        Convert.ToDateTime(_IStatisticsConditionView.FromDate),
                        Convert.ToDateTime(_IStatisticsConditionView.ToDate),
                        _IStatisticsConditionView.DepartmentID, _IStatisticsConditionView.SelectedAccountSetPara,
                        _IStatisticsConditionView.CompanyID,
                        _IStatisticsConditionView.IsAccumulated, _LoginUser);
                _ITimeSpanStatisticsGroupByDeptLineChartView.gvTimeSpanStatisticsGroupByDeptSource =
                    UtilityPresenter.TurnToEmployeeSalaryStatisticsDataTableTranspose(employeeSalaryStatistics);
            }
        }
    }
}
