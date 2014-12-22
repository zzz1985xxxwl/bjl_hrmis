using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede.PayModule;
using PayModuleIPresenter = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;
using PresenterCore = SEP.Presenter.Core;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.SummaryStatistics
{
    public class PositionStatisticsTablePresenter
    {
        private readonly PayModuleIPresenter.IPositionStatisticsTableView _IPositionStatisticsTableView;
        private readonly PayModuleIPresenter.IStatisticsConditionView _IStatisticsConditionView;
        private readonly Account _LoginUser;

        public PositionStatisticsTablePresenter(PayModuleIPresenter.IPositionStatisticsTableView iPositionStatisticsTableView,
            PayModuleIPresenter.IStatisticsConditionView iStatisticsConditionView,Account loginUser)
        {
            _LoginUser = loginUser;
            _IPositionStatisticsTableView = iPositionStatisticsTableView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }
        public void InitView()
        {
            _IPositionStatisticsTableView.gvPositionStatisticsTableSource = null;
        }
        public void DrawChart()
        {
            if (_IPositionStatisticsTableView.gvPositionStatisticsTableSource == null)
            {
                IEmployeeSalaryStatisticsFacade _IEmployeeSalaryStatisticsFacade =InstanceFactory.CreateEmployeeSalaryStatisticsFacade();
                List<Model.PayModule.EmployeeSalaryStatistics> employeeSalaryStatistics =
                    _IEmployeeSalaryStatisticsFacade.PositionStatistics(
                        Convert.ToDateTime(_IStatisticsConditionView.FromDate),
                        Convert.ToDateTime(_IStatisticsConditionView.ToDate),
                        _IStatisticsConditionView.DepartmentID,
                        _IStatisticsConditionView.SelectedAccountSetPara, _IStatisticsConditionView.CompanyID,
                        _LoginUser);
                _IPositionStatisticsTableView.gvPositionStatisticsTableSource =
                    UtilityPresenter.TurnToEmployeeSalaryStatisticsDataTable(employeeSalaryStatistics,
                                                                             UtilityPresenter.StatisticsTableTypeEnum.
                                                                                 Position);
            }
        }
    }
}
