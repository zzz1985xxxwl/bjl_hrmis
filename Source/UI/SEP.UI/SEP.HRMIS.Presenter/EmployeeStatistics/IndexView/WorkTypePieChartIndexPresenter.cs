using System;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Presenter
{
    public class WorkTypePieChartIndexPresenter
    {
        private readonly IWorkTypePieChartIndexView _IWorkTypePieChartIndexView;
        private readonly Account _Operator;
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public WorkTypePieChartIndexPresenter(IWorkTypePieChartIndexView iWorkTypePieChartIndexView, Account _operator)
        {

            _Operator = _operator;

            _IWorkTypePieChartIndexView = iWorkTypePieChartIndexView;
        }
        private void Attachment()
        {
            _IWorkTypePieChartIndexView.IStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployee;

        }

        public void InitPresent(bool isPostBack)
        {
            Attachment();
            if (!isPostBack)
            {
                StatisticsConditionPresenter statisticsConditionFontPresenter =
                    new StatisticsConditionPresenter(_IWorkTypePieChartIndexView.IStatisticsConditionView, _Operator);
                statisticsConditionFontPresenter.InitPresent(isPostBack);
                _IWorkTypePieChartIndexView.IStatisticsConditionView.btnExportVisible = false;
                //StatisticsEmployee(null, null);
            }
        }
        public void StatisticsEmployee(object source, EventArgs e)
        {
            if (new StatisticsConditionPresenter(_IWorkTypePieChartIndexView.IStatisticsConditionView, _Operator).CheckValid())
            {
                try
                {
                    WorkTypePieChartPresenter WorkTypePieChartPresenter =
                        new WorkTypePieChartPresenter(_IWorkTypePieChartIndexView.IWorkTypePieChartView,
                                                      _IWorkTypePieChartIndexView.IStatisticsConditionView, _Operator);
                    WorkTypePieChartPresenter.DrawChart();
                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

    }
}
