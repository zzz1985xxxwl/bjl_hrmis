using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using PayModuleIPresenter = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.SummaryStatistics
{
    public class TimeSpanStatisticsGroupByParaTablePresenter
    {
        private readonly PayModuleIPresenter.ITimeSpanStatisticsGroupByParaTableView _ITimeSpanStatisticsGroupByParaTableView;
        private readonly PayModuleIPresenter.IStatisticsConditionView _IStatisticsConditionView;
        private readonly Account _LoginUser;

        public TimeSpanStatisticsGroupByParaTablePresenter
             (PayModuleIPresenter.ITimeSpanStatisticsGroupByParaTableView iTimeSpanStatisticsGroupByParaTableView,
              PayModuleIPresenter.IStatisticsConditionView iStatisticsConditionView, Account loginUser)
        {
            _LoginUser = loginUser;
            _ITimeSpanStatisticsGroupByParaTableView = iTimeSpanStatisticsGroupByParaTableView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }

        public void InitView()
        {
            _ITimeSpanStatisticsGroupByParaTableView.gvTimeSpanStatisticsGroupByParaSource = null;
        }
        public void DrawChart()
        {
            if (_ITimeSpanStatisticsGroupByParaTableView.gvTimeSpanStatisticsGroupByParaSource == null)
            {
                IEmployeeSalaryStatisticsFacade _IEmployeeSalaryStatisticsFacade =InstanceFactory.CreateEmployeeSalaryStatisticsFacade();
                List<Model.PayModule.EmployeeSalaryStatistics> employeeSalaryStatistics =
                    _IEmployeeSalaryStatisticsFacade.TimeSpanStatisticsGroupByParameter(
                        Convert.ToDateTime(_IStatisticsConditionView.FromDate),
                        Convert.ToDateTime(_IStatisticsConditionView.ToDate),
                        _IStatisticsConditionView.DepartmentID, _IStatisticsConditionView.SelectedAccountSetPara,
                        _IStatisticsConditionView.CompanyID, _LoginUser);
                _ITimeSpanStatisticsGroupByParaTableView.gvTimeSpanStatisticsGroupByParaSource =
                    UtilityPresenter.TurnToEmployeeSalaryStatisticsDataTableTranspose(employeeSalaryStatistics);
                //_ITimeSpanStatisticsGroupByParaTableView.gvTimeSpanStatisticsGroupByParaSource = UtilityPresenter.get();
            }
        }
    }
}
