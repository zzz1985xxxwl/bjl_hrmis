using System;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class AgePieChartPresenter
    {
        private readonly IAgePieChartView _IAgePieChartView;
        private readonly IStatisticsConditionView _IStatisticsConditionView;
        private readonly IEmployeeStatisticsFacade _IEmployeeStatisticsFacade = InstanceFactory.CreateEmployeeStatisticsFacade();
        private readonly Account _Operator;
        public AgePieChartPresenter(IAgePieChartView iAgePieChartView, IStatisticsConditionView iStatisticsConditionView, Account _operator)
        {
            _Operator = _operator;
            _IAgePieChartView = iAgePieChartView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }

        public void DrawChart()
        {
            _IAgePieChartView.EmployeeStatistics = _IEmployeeStatisticsFacade.BindEmployeeStatistics(DateTime.Now,
                                                              _IStatisticsConditionView.DepartmentID, _Operator,
                                                              null);

           
        }

    }
}
