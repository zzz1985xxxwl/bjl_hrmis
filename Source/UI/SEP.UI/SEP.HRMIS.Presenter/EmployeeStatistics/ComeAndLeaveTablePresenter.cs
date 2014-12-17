using System;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class ComeAndLeaveTablePresenter
    {
        private readonly Account _Operator;
        private readonly IComeAndLeaveTableView _IComeAndLeaveTableView;
        private readonly IStatisticsConditionView _IStatisticsConditionView;
        private readonly IEmployeeStatisticsFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeStatisticsFacade();
        public ComeAndLeaveTablePresenter(IComeAndLeaveTableView iComeAndLeaveTableView, IStatisticsConditionView iStatisticsConditionView,Account _operator)
        {
            _Operator = _operator;
            _IComeAndLeaveTableView = iComeAndLeaveTableView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }

        public void DrawChart()
        {
            if (_IComeAndLeaveTableView.EmployeeComeAndLeaveList == null)
            {
                _IComeAndLeaveTableView.EmployeeComeAndLeaveList =
                    _IEmployeeFacade.ComeAndLeaveStatistics(
                        Convert.ToDateTime(_IStatisticsConditionView.StatisticsTime),
                        _IStatisticsConditionView.DepartmentID, _Operator);
            }
        }

    }
}
