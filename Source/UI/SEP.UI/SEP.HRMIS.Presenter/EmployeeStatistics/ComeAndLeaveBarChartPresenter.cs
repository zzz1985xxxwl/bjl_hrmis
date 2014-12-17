using System;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class ComeAndLeaveBarChartPresenter
    {
        private readonly Account _Operator;
        private readonly IComeAndLeaveBarChartView _IComeAndLeaveBarChartView;
        private readonly IStatisticsConditionView _IStatisticsConditionView;
        private readonly IEmployeeStatisticsFacade _IEmployeeFacade = InstanceFactory.CreateEmployeeStatisticsFacade();
        public ComeAndLeaveBarChartPresenter(IComeAndLeaveBarChartView iComeAndLeaveBarChartView, IStatisticsConditionView iStatisticsConditionView, Account _operator)
        {
            _Operator = _operator;
            _IComeAndLeaveBarChartView = iComeAndLeaveBarChartView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }

        public void DrawChart()
        {
            if (_IComeAndLeaveBarChartView.EmployeeComeAndLeaveList == null)
            {
                _IComeAndLeaveBarChartView.EmployeeComeAndLeaveList =
                    _IEmployeeFacade.ComeAndLeaveStatistics(
                        Convert.ToDateTime(_IStatisticsConditionView.StatisticsTime),
                        _IStatisticsConditionView.DepartmentID, _Operator);
            }
        }

    }
}
