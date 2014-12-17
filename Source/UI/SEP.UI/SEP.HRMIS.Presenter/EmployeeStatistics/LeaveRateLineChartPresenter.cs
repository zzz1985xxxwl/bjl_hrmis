using System;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class LeaveRateLineChartPresenter
    {
        private readonly Account _Operator;
        private readonly ILeaveRateLineChartView _ILeaveRateLineChartView;
        private readonly IStatisticsConditionView _IStatisticsConditionView;
        private readonly IEmployeeStatisticsFacade _IEmployeeStatisticsFacade = InstanceFactory.CreateEmployeeStatisticsFacade();
        public LeaveRateLineChartPresenter(ILeaveRateLineChartView iLeaveRateLineChartView, IStatisticsConditionView iStatisticsConditionView, Account _operator)
        {
            _Operator = _operator;
            _ILeaveRateLineChartView = iLeaveRateLineChartView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }

        public void DrawChart()
        {
            if (_ILeaveRateLineChartView.EmployeeComeAndLeaveList == null)
            {
                _ILeaveRateLineChartView.EmployeeComeAndLeaveList =
                    _IEmployeeStatisticsFacade.ComeAndLeaveStatistics(
                        Convert.ToDateTime(_IStatisticsConditionView.StatisticsTime),
                        _IStatisticsConditionView.DepartmentID, _Operator);
            }
        }    
    }
}
