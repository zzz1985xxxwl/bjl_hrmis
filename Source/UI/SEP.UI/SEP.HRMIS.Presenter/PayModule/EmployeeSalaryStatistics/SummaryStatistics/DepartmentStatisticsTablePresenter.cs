using System;
using System.Collections.Generic;
using System.Data;
using SEP.HRMIS.IFacede.PayModule;
using PayModuleIPresenter = SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeSalaryStatistics.ISummaryStatistics;
using PresenterCore = SEP.Presenter.Core;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.PayModule.EmployeeSalaryStatistics.SummaryStatistics
{
    public class DepartmentStatisticsTablePresenter
    {
        private readonly PayModuleIPresenter.IDepartmentStatisticsTableView _IDepartmentStatisticsTableView;
        private readonly PayModuleIPresenter.IStatisticsConditionView _IStatisticsConditionView;
        private readonly Account _LoginUser;

        public DepartmentStatisticsTablePresenter(PayModuleIPresenter.IDepartmentStatisticsTableView iDepartmentStatisticsTableView,
            PayModuleIPresenter.IStatisticsConditionView iStatisticsConditionView, Account loginUser)
        {
            _LoginUser = loginUser;
            _IDepartmentStatisticsTableView = iDepartmentStatisticsTableView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }
        public void InitView()
        {
            _IDepartmentStatisticsTableView.gvDepartmentStatisticsTableSource = null;
        }
        public void DrawChart()
        {
            if (_IDepartmentStatisticsTableView.gvDepartmentStatisticsTableSource == null)
            {
                IEmployeeSalaryStatisticsFacade _IEmployeeSalaryStatisticsFacade =
                    PayModuleInstanceFactory.CreateEmployeeSalaryStatisticsFacade();
                List<Model.PayModule.EmployeeSalaryStatistics> employeeSalaryStatistics =
                    _IEmployeeSalaryStatisticsFacade.DepartmentStatistics(
                        Convert.ToDateTime(_IStatisticsConditionView.FromDate),
                        Convert.ToDateTime(_IStatisticsConditionView.ToDate),
                        _IStatisticsConditionView.DepartmentID,
                        _IStatisticsConditionView.SelectedAccountSetPara, _IStatisticsConditionView.CompanyID,
                        _IStatisticsConditionView.IsAccumulated, _LoginUser);

                DataTable dt = UtilityPresenter.TurnToEmployeeSalaryStatisticsDataTable(employeeSalaryStatistics,
                                                                                        UtilityPresenter.
                                                                                            StatisticsTableTypeEnum.
                                                                                            Department);
                UtilityPresenter.RemoveRowsByCondition(dt, "ÈËÊý", "0");
                _IDepartmentStatisticsTableView.gvDepartmentStatisticsTableSource = dt;
            }
        }
    }
}
