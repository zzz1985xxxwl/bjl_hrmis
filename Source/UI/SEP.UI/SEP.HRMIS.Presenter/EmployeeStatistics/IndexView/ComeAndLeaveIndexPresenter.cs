using System;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class ComeAndLeaveIndexPresenter
    {
        private readonly IComeAndLeaveIndexView _IComeAndLeaveIndexView;
        private readonly Account _Operator;
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public ComeAndLeaveIndexPresenter(IComeAndLeaveIndexView iComeAndLeaveIndexView, Account _operator)
        {
            _Operator = _operator;
            _IComeAndLeaveIndexView = iComeAndLeaveIndexView;
        }
        private void Attachment()
        {
            _IComeAndLeaveIndexView.IStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployee;

        }

        public void InitPresent(bool isPostBack)
        {
            Attachment();
            if (!isPostBack)
            {
                StatisticsConditionPresenter statisticsConditionFontPresenter =
                    new StatisticsConditionPresenter(_IComeAndLeaveIndexView.IStatisticsConditionView, _Operator);
                statisticsConditionFontPresenter.InitPresent(isPostBack);
                _IComeAndLeaveIndexView.IStatisticsConditionView.btnExportVisible = false;
                //StatisticsEmployee(null, null);
            }
        }
        public void StatisticsEmployee(object source, EventArgs e)
        {
            if (new StatisticsConditionPresenter(_IComeAndLeaveIndexView.IStatisticsConditionView, _Operator).CheckValid())
            {
                try
                {
                    ComeAndLeaveTablePresenter ComeAndLeaveTablePresenter =
                        new ComeAndLeaveTablePresenter(_IComeAndLeaveIndexView.IComeAndLeaveTableView,
                                                       _IComeAndLeaveIndexView.IStatisticsConditionView, _Operator);
                    ComeAndLeaveTablePresenter.DrawChart();

                    _IComeAndLeaveIndexView.IComeAndLeaveBarChartView.EmployeeComeAndLeaveList =
                        _IComeAndLeaveIndexView.IComeAndLeaveTableView.EmployeeComeAndLeaveList;
                    _IComeAndLeaveIndexView.ILeaveRateLineChartView.EmployeeComeAndLeaveList =
                        _IComeAndLeaveIndexView.IComeAndLeaveTableView.EmployeeComeAndLeaveList;

                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

    }
}
