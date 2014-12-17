using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using ReimburseStatisticsIPresenter=SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseStatistics
{
    public class EmployeeStatisticsBarChartPresenter
    {
        private readonly ReimburseStatisticsIPresenter.IEmployeeStatisticsBarChartView _IEmployeeStatisticsBarChartView;
        private readonly ReimburseStatisticsIPresenter.IEmployeeStatisticsConditionView _IEmployeeStatisticsConditionView;
        private readonly Account _LoginUser;

        public EmployeeStatisticsBarChartPresenter
            (ReimburseStatisticsIPresenter.IEmployeeStatisticsBarChartView iEmployeeStatisticsBarChartView,
             ReimburseStatisticsIPresenter.IEmployeeStatisticsConditionView iEmployeeStatisticsConditionView, Account loginUser)
        {
            _LoginUser = loginUser;
            _IEmployeeStatisticsBarChartView = iEmployeeStatisticsBarChartView;
            _IEmployeeStatisticsConditionView = iEmployeeStatisticsConditionView;
        }
        public void InitView()
        {
            _IEmployeeStatisticsBarChartView.gvEmployeeStatisticsSource = null;
        }
        public void DrawChart()
        {
            if (_IEmployeeStatisticsBarChartView.gvEmployeeStatisticsSource == null)
            {
                IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();

                List<EmployeeReimburseStatistics> employeeSalaryStatistics =
                    _IReimburseFacade.EmployeeStatistics(
                        Convert.ToDateTime(_IEmployeeStatisticsConditionView.FromDate),
                        Convert.ToDateTime(_IEmployeeStatisticsConditionView.ToDate),
                        _IEmployeeStatisticsConditionView.DepartmentID, _IEmployeeStatisticsConditionView.CompanyID,
                        _IEmployeeStatisticsConditionView.EmployeeName, _LoginUser);
                _IEmployeeStatisticsBarChartView.gvEmployeeStatisticsSource =
                    UtilityPresenter.TurnToEmployeeReimburseStatisticsDataTable(employeeSalaryStatistics,
                                                                             UtilityPresenter.StatisticsTableTypeEnum.
                                                                                 Employee);
            }
        }
    }
}
