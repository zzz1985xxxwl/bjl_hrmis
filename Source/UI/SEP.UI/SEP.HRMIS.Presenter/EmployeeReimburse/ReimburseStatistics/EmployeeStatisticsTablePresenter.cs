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
    public class EmployeeStatisticsTablePresenter
    {
        private readonly ReimburseIPresenter.IEmployeeStatisticsTableView _IEmployeeStatisticsTableView;
        private readonly ReimburseIPresenter.IEmployeeStatisticsConditionView _IEmployeeStatisticsConditionView;
        private readonly Account _LoginUser;

        public EmployeeStatisticsTablePresenter(ReimburseIPresenter.IEmployeeStatisticsTableView iEmployeeStatisticsTableView,
            ReimburseIPresenter.IEmployeeStatisticsConditionView iEmployeeStatisticsConditionView, Account loginUser)
        {
            _LoginUser = loginUser;
            _IEmployeeStatisticsTableView = iEmployeeStatisticsTableView;
            _IEmployeeStatisticsConditionView = iEmployeeStatisticsConditionView;
        }
        public void InitView()
        {
            _IEmployeeStatisticsTableView.gvEmployeeStatisticsTableSource = null;
        }
        public void DrawChart()
        {
            if (_IEmployeeStatisticsTableView.gvEmployeeStatisticsTableSource == null)
            {
                IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();

                List<EmployeeReimburseStatistics> employeeSalaryStatistics =
                    _IReimburseFacade.EmployeeStatistics(
                        Convert.ToDateTime(_IEmployeeStatisticsConditionView.FromDate),
                        Convert.ToDateTime(_IEmployeeStatisticsConditionView.ToDate),
                        _IEmployeeStatisticsConditionView.DepartmentID,
                        _IEmployeeStatisticsConditionView.CompanyID,
                        _IEmployeeStatisticsConditionView.EmployeeName, _LoginUser);

                DataTable dt = UtilityPresenter.TurnToEmployeeReimburseStatisticsDataTable(employeeSalaryStatistics,
                                                                                        UtilityPresenter.
                                                                                            StatisticsTableTypeEnum.
                                                                                            Employee);
                _IEmployeeStatisticsTableView.gvEmployeeStatisticsTableSource = dt;
            }
        }
    }
}
