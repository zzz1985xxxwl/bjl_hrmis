using System;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class AgePieChartIndexPresenter
    {
        private readonly Account _Operator; 
        private readonly IAgePieChartIndexView _IAgePieChartIndexView;
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public AgePieChartIndexPresenter(IAgePieChartIndexView iAgePieChartIndexView, Account _operator)
        {
            _Operator = _operator;
            _IAgePieChartIndexView = iAgePieChartIndexView;
        }
        private void Attachment()
        {
            _IAgePieChartIndexView.IStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployee;

        }

        public void InitPresent(bool isPostBack)
        {
            Attachment();
            if (!isPostBack)
            {
                StatisticsConditionPresenter statisticsConditionFontPresenter =
                    new StatisticsConditionPresenter(_IAgePieChartIndexView.IStatisticsConditionView, _Operator);
                statisticsConditionFontPresenter.InitPresent(isPostBack);
                _IAgePieChartIndexView.IStatisticsConditionView.btnExportVisible = false;
                //StatisticsEmployee(null, null);
            }
        }
        public void StatisticsEmployee(object source, EventArgs e)
        {
            if (new StatisticsConditionPresenter(_IAgePieChartIndexView.IStatisticsConditionView, _Operator).CheckValid())
            {
                try
                {

                    AgePieChartPresenter AgePieChartPresenter =
                        new AgePieChartPresenter(_IAgePieChartIndexView.IAgePieChartView,
                                                 _IAgePieChartIndexView.IStatisticsConditionView, _Operator);
                    AgePieChartPresenter.DrawChart();

                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

    }
}
