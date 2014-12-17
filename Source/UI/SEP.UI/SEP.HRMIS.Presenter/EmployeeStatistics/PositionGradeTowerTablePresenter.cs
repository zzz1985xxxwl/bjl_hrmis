using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class PositionGradeTowerTablePresenter
    {
        private readonly Account _Operator;
        private readonly IPositionGradeTowerTableView _IPositionGradeTowerTableView;
        private readonly IStatisticsConditionView _IStatisticsConditionView;
        private readonly IEmployeeStatisticsFacade _IEmployeeStatisticsFacade = InstanceFactory.CreateEmployeeStatisticsFacade();
        public PositionGradeTowerTablePresenter(IPositionGradeTowerTableView iPositionGradeTowerTableView, IStatisticsConditionView iStatisticsConditionView, Account _operator)
        {
            _Operator = _operator;
            _IPositionGradeTowerTableView = iPositionGradeTowerTableView;
            _IStatisticsConditionView = iStatisticsConditionView;
        }

        public void DrawChart(List<Employee> employeesource)
        {
            _IPositionGradeTowerTableView.PositionGradeList =
                _IEmployeeStatisticsFacade.PositionGradeStatistics(
                    Convert.ToDateTime(_IStatisticsConditionView.StatisticsTime),
                    _IStatisticsConditionView.DepartmentID, _Operator, employeesource);
        }    
    }
}
