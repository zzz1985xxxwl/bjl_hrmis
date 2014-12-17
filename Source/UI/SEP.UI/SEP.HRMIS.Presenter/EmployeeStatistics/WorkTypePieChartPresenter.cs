using System;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class WorkTypePieChartPresenter
    {
        private readonly Account _Operator;
        private readonly IWorkTypePieChartView _IWorkTypePieChartView;
        private readonly IStatisticsConditionView _IStatisticsConditionView;
        public WorkTypePieChartPresenter(IWorkTypePieChartView iWorkTypePieChartView, IStatisticsConditionView iStatisticsConditionView, Account _operator)
        {
            _Operator = _operator;
            _IWorkTypePieChartView = iWorkTypePieChartView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }
        private IEmployeeStatisticsFacade _IEmployeeStatisticsFacade = InstanceFactory.CreateEmployeeStatisticsFacade();

        public void DrawChart()
        {
            _IWorkTypePieChartView.EmployeeStatistics =
                _IEmployeeStatisticsFacade.BindEmployeeStatistics(DateTime.Now,
                                                                  _IStatisticsConditionView.DepartmentID, _Operator,
                                                                  null);
        }
    }
}
