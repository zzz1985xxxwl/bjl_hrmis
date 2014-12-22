using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using PayModuleIPresenter = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.SummaryStatistics
{
    public class DepartmentStatisticsBarChartPresenter
    {
        private readonly PayModuleIPresenter.IDepartmentStatisticsBarChartView _IDepartmentStatisticsBarChartView;
        private readonly PayModuleIPresenter.IStatisticsConditionView _IStatisticsConditionView;
        private readonly Account _LoginUser;

        public DepartmentStatisticsBarChartPresenter
            (PayModuleIPresenter.IDepartmentStatisticsBarChartView iDepartmentStatisticsBarChartView,
             PayModuleIPresenter.IStatisticsConditionView iStatisticsConditionView, Account loginUser)
        {
            _LoginUser = loginUser;
            _IDepartmentStatisticsBarChartView = iDepartmentStatisticsBarChartView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }
        public void InitView()
        {
            _IDepartmentStatisticsBarChartView.gvDepartmentStatisticsSource = null;
        }
        public void DrawChart()
        {
            if (_IDepartmentStatisticsBarChartView.gvDepartmentStatisticsSource == null)
            {
                IEmployeeSalaryStatisticsFacade _IEmployeeSalaryStatisticsFacade =InstanceFactory.CreateEmployeeSalaryStatisticsFacade();
                List<Model.PayModule.EmployeeSalaryStatistics> employeeSalaryStatistics =
                    _IEmployeeSalaryStatisticsFacade.DepartmentStatistics(
                        Convert.ToDateTime(_IStatisticsConditionView.FromDate),
                        Convert.ToDateTime(_IStatisticsConditionView.ToDate),
                        _IStatisticsConditionView.DepartmentID, _IStatisticsConditionView.SelectedAccountSetPara,
                        _IStatisticsConditionView.CompanyID,
                        _IStatisticsConditionView.IsAccumulated, _LoginUser);
                _IDepartmentStatisticsBarChartView.gvDepartmentStatisticsSource =
                    UtilityPresenter.TurnToEmployeeSalaryStatisticsDataTable(employeeSalaryStatistics,
                                                                             UtilityPresenter.StatisticsTableTypeEnum.
                                                                                 Department);
            }
        }
    }
}
