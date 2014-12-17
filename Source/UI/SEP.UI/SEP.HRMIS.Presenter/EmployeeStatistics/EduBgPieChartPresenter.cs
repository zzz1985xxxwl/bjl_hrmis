using System;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class EduBgPieChartPresenter
    {
        private readonly IEduBgPieChartView _IEduBgPieChartView;
        private readonly IStatisticsConditionView _IStatisticsConditionView;
        private readonly Account _Operator;
        private readonly IEmployeeStatisticsFacade _IEmployeeStatisticsFacade = InstanceFactory.CreateEmployeeStatisticsFacade();
        public EduBgPieChartPresenter(IEduBgPieChartView iEduBgPieChartView, IStatisticsConditionView iStatisticsConditionView,Account _operator)
        {
            _Operator = _operator;
            _IEduBgPieChartView = iEduBgPieChartView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }

        public void DrawChart()
        {
            _IEduBgPieChartView.EmployeeStatistics =
                _IEmployeeStatisticsFacade.BindEmployeeStatistics(DateTime.Now,
                                                                  _IStatisticsConditionView.DepartmentID, _Operator,
                                                                  null);
        }
    }
}
