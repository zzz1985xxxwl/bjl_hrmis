using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using PayModuleIPresenter = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.IAverageStatistics;
using PresenterCore = SEP.Presenter.Core;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.AverageStatistics
{
    public class TimeSpanStatisticsGroupByDeptTablePresenter
    {
        private readonly PayModuleIPresenter.ITimeSpanStatisticsGroupByDeptTableView _ITimeSpanStatisticsGroupByDeptTableView;
        private readonly PayModuleIPresenter.IStatisticsConditionView _IStatisticsConditionView;
        private readonly Account _LoginUser;

        public TimeSpanStatisticsGroupByDeptTablePresenter(PayModuleIPresenter.ITimeSpanStatisticsGroupByDeptTableView iTimeSpanStatisticsGroupByDeptTableView,
            PayModuleIPresenter.IStatisticsConditionView iStatisticsConditionView, Account loginUser)
        {
            _LoginUser = loginUser;
            _ITimeSpanStatisticsGroupByDeptTableView = iTimeSpanStatisticsGroupByDeptTableView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }
        public void InitView()
        {
            _ITimeSpanStatisticsGroupByDeptTableView.gvTimeSpanStatisticsGroupByDeptSource = null;
        }
        public void DrawChart()
        {
            if (_ITimeSpanStatisticsGroupByDeptTableView.gvTimeSpanStatisticsGroupByDeptSource == null)
            {
                IEmployeeSalaryStatisticsFacade _IEmployeeSalaryStatisticsFacade =PayModuleInstanceFactory.CreateEmployeeSalaryStatisticsFacade();
                List<Model.PayModule.EmployeeSalaryStatistics> employeeSalaryStatistics =
                    _IEmployeeSalaryStatisticsFacade.TimeSpanStatisticsGroupByDepartment(
                        Convert.ToDateTime(_IStatisticsConditionView.FromDate),
                        Convert.ToDateTime(_IStatisticsConditionView.ToDate),
                        _IStatisticsConditionView.DepartmentID, _IStatisticsConditionView.SelectedAccountSetPara,
                        _IStatisticsConditionView.CompanyID,
                        _IStatisticsConditionView.IsAccumulated,_LoginUser);
                _ITimeSpanStatisticsGroupByDeptTableView.gvTimeSpanStatisticsGroupByDeptSource =
                    UtilityPresenter.TurnToEmployeeSalaryStatisticsDataTableTranspose(employeeSalaryStatistics);
            }
        }

    }
}
