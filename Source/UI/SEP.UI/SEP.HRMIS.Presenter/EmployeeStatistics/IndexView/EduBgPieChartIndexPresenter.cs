using System;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class EduBgPieChartIndexPresenter
    {
        private readonly IEduBgPieChartIndexView _IEduBgPieChartIndexView;
        private readonly Account _Operator;
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public EduBgPieChartIndexPresenter(IEduBgPieChartIndexView iEduBgPieChartIndexView, Account _operator)
        {
            _Operator = _operator;
            _IEduBgPieChartIndexView = iEduBgPieChartIndexView;
        }
        private void Attachment()
        {
            _IEduBgPieChartIndexView.IStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployee;

        }

        public void InitPresent(bool isPostBack)
        {
            Attachment();
            if (!isPostBack)
            {
                StatisticsConditionPresenter statisticsConditionFontPresenter =
                    new StatisticsConditionPresenter(_IEduBgPieChartIndexView.IStatisticsConditionView, _Operator);
                statisticsConditionFontPresenter.InitPresent(isPostBack);
                _IEduBgPieChartIndexView.IStatisticsConditionView.btnExportVisible = false;
                //StatisticsEmployee(null, null);
            }
        }
        public void StatisticsEmployee(object source, EventArgs e)
        {
            if (new StatisticsConditionPresenter(_IEduBgPieChartIndexView.IStatisticsConditionView, _Operator).CheckValid())
            {
                try
                {
                    EduBgPieChartPresenter EduBgPieChartPresenter =
                        new EduBgPieChartPresenter(
                            _IEduBgPieChartIndexView.IEduBgPieChartView,
                            _IEduBgPieChartIndexView.IStatisticsConditionView, _Operator);
                    EduBgPieChartPresenter.DrawChart();

                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

    }
}
