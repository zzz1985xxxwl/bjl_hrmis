using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Utility;


namespace SEP.HRMIS.Presenter
{
    public class WorkAgePieChartIndexPresenter
    {
        private readonly IWorkAgePieChartIndexView _IWorkAgePieChartIndexView;
        private readonly Account _Operator;
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public WorkAgePieChartIndexPresenter(IWorkAgePieChartIndexView iWorkAgePieChartIndexView, Account _operator)
        {
            _Operator = _operator;

            _IWorkAgePieChartIndexView = iWorkAgePieChartIndexView;
        }
        private void Attachment()
        {
            _IWorkAgePieChartIndexView.IStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployee;

        }

        public void InitPresent(bool isPostBack)
        {
            Attachment();
            if (!isPostBack)
            {
                StatisticsConditionPresenter statisticsConditionFontPresenter =
                    new StatisticsConditionPresenter(_IWorkAgePieChartIndexView.IStatisticsConditionView, _Operator);
                statisticsConditionFontPresenter.InitPresent(isPostBack);
                _IWorkAgePieChartIndexView.IStatisticsConditionView.btnExportVisible = false;
                //StatisticsEmployee(null, null);
            }
        }
        public void StatisticsEmployee(object source, EventArgs e)
        {
            if (new StatisticsConditionPresenter(_IWorkAgePieChartIndexView.IStatisticsConditionView, _Operator).CheckValid())
            {
                try
                {
                    WorkAgePieChartPresenter WorkAgePieChartPresenter =
                        new WorkAgePieChartPresenter(_IWorkAgePieChartIndexView.IWorkAgePieChartView,
                                                     _IWorkAgePieChartIndexView.IStatisticsConditionView, _Operator);
                    WorkAgePieChartPresenter.DrawChart();

                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

    }
}
