using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using PayModuleIPresenter = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;
using PresenterCore = SEP.Presenter.Core;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.SummaryStatistics
{
    public class PositionStatisticsBarChartPresenter 
    {
        private readonly PayModuleIPresenter.IPositionStatisticsBarChartView _IPositionStatisticsBarChartView;
        private readonly PayModuleIPresenter.IStatisticsConditionView _IStatisticsConditionView;
        private readonly Account _LoginUser;

        public PositionStatisticsBarChartPresenter(PayModuleIPresenter.IPositionStatisticsBarChartView iPositionStatisticsBarChartView,
            PayModuleIPresenter.IStatisticsConditionView iStatisticsConditionView, Account loginUser)
        {
            _LoginUser = loginUser;
            _IPositionStatisticsBarChartView = iPositionStatisticsBarChartView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }
        public void InitView()
        {
            _IPositionStatisticsBarChartView.gvPositionStatisticsSource = null;
        }
        public void DrawChart()
        {
            if (_IPositionStatisticsBarChartView.gvPositionStatisticsSource == null)
            {
                IEmployeeSalaryStatisticsFacade _IEmployeeSalaryStatisticsFacade =PayModuleInstanceFactory.CreateEmployeeSalaryStatisticsFacade();
                List<Model.PayModule.EmployeeSalaryStatistics> employeeSalaryStatistics =
                    _IEmployeeSalaryStatisticsFacade.PositionStatistics(
                        Convert.ToDateTime(_IStatisticsConditionView.FromDate),
                        Convert.ToDateTime(_IStatisticsConditionView.ToDate),
                        _IStatisticsConditionView.DepartmentID,
                        _IStatisticsConditionView.SelectedAccountSetPara, _IStatisticsConditionView.CompanyID,
                        _LoginUser);
                _IPositionStatisticsBarChartView.gvPositionStatisticsSource =
                    UtilityPresenter.TurnToEmployeeSalaryStatisticsDataTable(employeeSalaryStatistics,
                                                                             UtilityPresenter.StatisticsTableTypeEnum.
                                                                                 Position);
            }
        }
    }
}
