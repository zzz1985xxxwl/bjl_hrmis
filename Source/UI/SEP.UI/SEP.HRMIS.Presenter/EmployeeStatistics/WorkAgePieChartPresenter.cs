using System;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class WorkAgePieChartPresenter
    {
        private readonly Account _Operator;
        private readonly IWorkAgePieChartView _IWorkAgePieChartView;
        private readonly IStatisticsConditionView _IStatisticsConditionView;
        private readonly IEmployeeStatisticsFacade _IEmployeeStatisticsFacade = InstanceFactory.CreateEmployeeStatisticsFacade();
        public WorkAgePieChartPresenter(IWorkAgePieChartView iWorkAgePieChartView, IStatisticsConditionView iStatisticsConditionView, Account _operator)
        {
            _Operator = _operator;
            _IWorkAgePieChartView = iWorkAgePieChartView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }
        public void DrawChart()
        {
            _IWorkAgePieChartView.EmployeeStatistics =
                _IEmployeeStatisticsFacade.BindEmployeeStatistics(DateTime.Now,
                                                                  _IStatisticsConditionView.DepartmentID, _Operator,
                                                                  null);

        }

    }
}