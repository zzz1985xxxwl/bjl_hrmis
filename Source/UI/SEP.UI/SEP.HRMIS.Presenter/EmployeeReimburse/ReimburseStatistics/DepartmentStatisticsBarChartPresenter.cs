using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using ReimburseStatisticsIPresenter=SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse.ReimburseStatistics;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.EmployeeReimburse.ReimburseStatistics
{
    public class DepartmentStatisticsBarChartPresenter
    {
        private readonly ReimburseStatisticsIPresenter.IDepartmentStatisticsBarChartView _IDepartmentStatisticsBarChartView;
        private readonly ReimburseStatisticsIPresenter.IStatisticsConditionView _IStatisticsConditionView;
        private readonly Account _LoginUser;

        public DepartmentStatisticsBarChartPresenter
            (ReimburseStatisticsIPresenter.IDepartmentStatisticsBarChartView iDepartmentStatisticsBarChartView,
             ReimburseStatisticsIPresenter.IStatisticsConditionView iStatisticsConditionView, Account loginUser)
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
                IReimburseFacade _IReimburseFacade = InstanceFactory.CreateReimburseFacade();

                List<EmployeeReimburseStatistics> employeeSalaryStatistics =
                    _IReimburseFacade.DepartmentStatistics(
                        Convert.ToDateTime(_IStatisticsConditionView.FromDate),
                        Convert.ToDateTime(_IStatisticsConditionView.ToDate),
                        _IStatisticsConditionView.DepartmentID, _IStatisticsConditionView.CompanyID,
                        _IStatisticsConditionView.IsAccumulated, _LoginUser);
                _IDepartmentStatisticsBarChartView.gvDepartmentStatisticsSource =
                    UtilityPresenter.TurnToEmployeeReimburseStatisticsDataTable(employeeSalaryStatistics,
                                                                             UtilityPresenter.StatisticsTableTypeEnum.
                                                                                 Department);
            }
        }
    }
}
