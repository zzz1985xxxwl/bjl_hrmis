using System;
using System.Collections.Generic;
using System.Data;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using ReimburseIPresenter = SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;
using PresenterCore = SEP.Presenter.Core;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseStatistics
{
    public class DepartmentStatisticsTablePresenter
    {
        private readonly ReimburseIPresenter.IDepartmentStatisticsTableView _IDepartmentStatisticsTableView;
        private readonly ReimburseIPresenter.IStatisticsConditionView _IStatisticsConditionView;
        private readonly Account _LoginUser;

        public DepartmentStatisticsTablePresenter(ReimburseIPresenter.IDepartmentStatisticsTableView iDepartmentStatisticsTableView,
            ReimburseIPresenter.IStatisticsConditionView iStatisticsConditionView, Account loginUser)
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
                IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();

                List<EmployeeReimburseStatistics> employeeSalaryStatistics =
                    _IReimburseFacade.DepartmentStatistics(
                        Convert.ToDateTime(_IStatisticsConditionView.FromDate),
                        Convert.ToDateTime(_IStatisticsConditionView.ToDate),
                        _IStatisticsConditionView.DepartmentID,
                        _IStatisticsConditionView.CompanyID,
                        _IStatisticsConditionView.IsAccumulated, _LoginUser);

                DataTable dt = UtilityPresenter.TurnToEmployeeReimburseStatisticsDataTable(employeeSalaryStatistics,
                                                                                        UtilityPresenter.
                                                                                            StatisticsTableTypeEnum.
                                                                                            Department);
                UtilityPresenter.RemoveRowsByCondition(dt, "ÈËÊý", "0");
                _IDepartmentStatisticsTableView.gvDepartmentStatisticsTableSource = dt;
            }
        }
    }
}
