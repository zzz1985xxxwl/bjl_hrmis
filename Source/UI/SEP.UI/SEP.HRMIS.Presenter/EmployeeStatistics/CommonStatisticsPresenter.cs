using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter
{
    public class CommonStatisticsPresenter
    {
        public readonly ICommonStatisticsView _ICommonStatisticsView;
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        private readonly IEmployeeHistoryFacade _IEmployeeHistoryFacade = InstanceFactory.CreateEmployeeHistoryFacade();
        private readonly IEmployeeStatisticsFacade _IEmployeeStatisticsFacade = InstanceFactory.CreateEmployeeStatisticsFacade();
        private readonly Account _Operator;
        public CommonStatisticsPresenter(ICommonStatisticsView iCommonStatisticsView, Account _operator)
        {
            _Operator = _operator;
            _ICommonStatisticsView = iCommonStatisticsView;
        }
        private void Attachment()
        {
            _ICommonStatisticsView.IStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployee;
        }

        public void InitPresent(bool isPostBack)
        {
            Attachment();
            if (!isPostBack)
            {
                InitStatisticsCondition(isPostBack);
                StatisticsEmployee(null, null);
            }
        }

        public void StatisticsEmployee(object source, EventArgs e)
        {
            if (CheckValid())
            {
                try
                {
                    //在此收集数据源以防底层查询很多次
                    List<Employee> employeesource =
                        _IEmployeeHistoryFacade.GetEmployeeOnDutyByDepartmentAndDateTime(
                            _ICommonStatisticsView.IStatisticsConditionView.DepartmentID,
                            Convert.ToDateTime(_ICommonStatisticsView.IStatisticsConditionView.StatisticsTime),
                            true, _Operator, HrmisPowers.A405, null);
                    EmployeeStatistics EmployeeStatistics =
                        _IEmployeeStatisticsFacade.BindEmployeeStatistics(DateTime.Now,
                                                                          _ICommonStatisticsView.
                                                                              IStatisticsConditionView.
                                                                              DepartmentID, _Operator, employeesource);
                    _ICommonStatisticsView.IAgePieChartView.EmployeeStatistics = EmployeeStatistics;
                    _ICommonStatisticsView.IGenderPieChartView.EmployeeStatistics = EmployeeStatistics;
                    _ICommonStatisticsView.IEduBgPieChartView.EmployeeStatistics = EmployeeStatistics;
                    _ICommonStatisticsView.IWorkTypePieChartView.EmployeeStatistics = EmployeeStatistics;
                    _ICommonStatisticsView.IWorkAgePieChartView.EmployeeStatistics = EmployeeStatistics;

                    ComeAndLeaveTablePresenter ComeAndLeaveTablePresenter =
                        new ComeAndLeaveTablePresenter(_ICommonStatisticsView.IComeAndLeaveTableView,
                                                       _ICommonStatisticsView.IStatisticsConditionView, _Operator);
                    ComeAndLeaveTablePresenter.DrawChart();

                    _ICommonStatisticsView.IComeAndLeaveBarChartView.EmployeeComeAndLeaveList =
                        _ICommonStatisticsView.IComeAndLeaveTableView.EmployeeComeAndLeaveList;
                    _ICommonStatisticsView.ILeaveRateLineChartView.EmployeeComeAndLeaveList =
                        _ICommonStatisticsView.IComeAndLeaveTableView.EmployeeComeAndLeaveList;

                    PositionGradeTowerTablePresenter PositionGradeTowerTablePresenter =
                        new PositionGradeTowerTablePresenter(_ICommonStatisticsView.IPositionGradeTowerTableView,
                                                             _ICommonStatisticsView.IStatisticsConditionView, _Operator);
                    PositionGradeTowerTablePresenter.DrawChart(employeesource);

                    OtherStatisticsDataPresenter OtherStatisticsDataPresenter =
                        new OtherStatisticsDataPresenter(_ICommonStatisticsView.IOtherStatisticsDataView,
                                                         _ICommonStatisticsView.IStatisticsConditionView, _Operator);
                    OtherStatisticsDataPresenter.BindData(employeesource, _ICommonStatisticsView.IComeAndLeaveTableView.EmployeeComeAndLeaveList[11]);
                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

        public void InitStatisticsCondition(bool isPostBack)
        {
            StatisticsConditionPresenter statisticsConditionBackPresenter =
                new StatisticsConditionPresenter(_ICommonStatisticsView.IStatisticsConditionView, _Operator);
            statisticsConditionBackPresenter.InitPresent(isPostBack);
        }

        public bool CheckValid()
        {
            return new StatisticsConditionPresenter(_ICommonStatisticsView.IStatisticsConditionView, _Operator).CheckValid();
        }
    }
}
