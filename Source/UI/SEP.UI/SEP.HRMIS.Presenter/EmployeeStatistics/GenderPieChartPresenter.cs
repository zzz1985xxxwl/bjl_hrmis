using System;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class GenderPieChartPresenter
    {
        private readonly IGenderPieChartView _IGenderPieChartView;
        private readonly IStatisticsConditionView _IStatisticsConditionView;
        private readonly IEmployeeStatisticsFacade _IEmployeeStatisticsFacade = InstanceFactory.CreateEmployeeStatisticsFacade();
        private readonly Account _Operator;
        public GenderPieChartPresenter(IGenderPieChartView iGenderPieChartView, IStatisticsConditionView iStatisticsConditionView, Account _operator)
        {
            _Operator = _operator;
            _IGenderPieChartView = iGenderPieChartView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }

        public void DrawChart()
        {
            _IGenderPieChartView.EmployeeStatistics =
                _IEmployeeStatisticsFacade.BindEmployeeStatistics(DateTime.Now,
                                                                  _IStatisticsConditionView.DepartmentID, _Operator,
                                                                  null);
        }
    }
}
