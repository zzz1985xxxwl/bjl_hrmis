using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class OtherStatisticsDataPresenter
    {
        private readonly Account _Operator;
        private readonly IOtherStatisticsDataView _IOtherStatisticsDataView;
        private readonly IStatisticsConditionView _IStatisticsConditionView;
        private readonly IEmployeeStatisticsFacade _IEmployeeStatisticsFacade = InstanceFactory.CreateEmployeeStatisticsFacade();

        public OtherStatisticsDataPresenter(IOtherStatisticsDataView iOtherStatisticsDataView, IStatisticsConditionView iStatisticsConditionView, Account _operator)
        {
            _Operator = _operator;
            _IOtherStatisticsDataView = iOtherStatisticsDataView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }

        public void BindData(List<Employee> employeesource, EmployeeComeAndLeave employeeComeAndLeave)
        {
            _IOtherStatisticsDataView.EmployeeComeAndLeave = employeeComeAndLeave ??
                                                             _IEmployeeStatisticsFacade.
                                                                 ComeAndLeaveStatisticsOnlyOneMonth(
                                                                 Convert.ToDateTime(
                                                                     _IStatisticsConditionView.StatisticsTime),
                                                                 _IStatisticsConditionView.DepartmentID, _Operator);
            _IOtherStatisticsDataView.EmployeeResidencePermitStatistics =
                _IEmployeeStatisticsFacade.ResidenceStatistics(
                    Convert.ToDateTime(_IStatisticsConditionView.StatisticsTime),
                    _IStatisticsConditionView.DepartmentID, _Operator, employeesource);
            _IOtherStatisticsDataView.EmployeeVacationStatistics =
                _IEmployeeStatisticsFacade.VocationStatistics(
                    Convert.ToDateTime(_IStatisticsConditionView.StatisticsTime),
                    _IStatisticsConditionView.DepartmentID, _Operator, employeesource);
        }
    }
}