using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using PayModuleIPresenter = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.SummaryStatistics
{
    public class TimeSpanStatisticsGroupByParaLineChartPresenter
    {
        private readonly PayModuleIPresenter.ITimeSpanStatisticsGroupByParaLineChartView _ITimeSpanStatisticsGroupByParaLineChartView;
        private readonly PayModuleIPresenter.IStatisticsConditionView _IStatisticsConditionView;
        private readonly Account _LoginUser;

        public TimeSpanStatisticsGroupByParaLineChartPresenter
            (PayModuleIPresenter.ITimeSpanStatisticsGroupByParaLineChartView iTimeSpanStatisticsGroupByParaLineChartView,
             PayModuleIPresenter.IStatisticsConditionView iStatisticsConditionView, Account loginUser)
        {
            _LoginUser = loginUser;
            _ITimeSpanStatisticsGroupByParaLineChartView = iTimeSpanStatisticsGroupByParaLineChartView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }

        public void InitView()
        {
            _ITimeSpanStatisticsGroupByParaLineChartView.gvTimeSpanStatisticsGroupByParaSource = null;
        }
        public void DrawChart()
        {
            if (_ITimeSpanStatisticsGroupByParaLineChartView.gvTimeSpanStatisticsGroupByParaSource == null)
            {
                IEmployeeSalaryStatisticsFacade _IEmployeeSalaryStatisticsFacade =InstanceFactory.CreateEmployeeSalaryStatisticsFacade();
                List<Model.PayModule.EmployeeSalaryStatistics> employeeSalaryStatistics =
                    _IEmployeeSalaryStatisticsFacade.TimeSpanStatisticsGroupByParameter(
                        Convert.ToDateTime(_IStatisticsConditionView.FromDate),
                        Convert.ToDateTime(_IStatisticsConditionView.ToDate),
                        _IStatisticsConditionView.DepartmentID, _IStatisticsConditionView.SelectedAccountSetPara,
                        _IStatisticsConditionView.CompanyID, _LoginUser);
                _ITimeSpanStatisticsGroupByParaLineChartView.gvTimeSpanStatisticsGroupByParaSource =
                    UtilityPresenter.TurnToEmployeeSalaryStatisticsDataTableTranspose(employeeSalaryStatistics);
            }
        }
    }
}
