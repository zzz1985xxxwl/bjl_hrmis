using System;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class GenderPieChartIndexPresenter
    {
        private readonly IGenderPieChartIndexView _IGenderPieChartIndexView;
        private readonly Account _Operator;
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public GenderPieChartIndexPresenter(IGenderPieChartIndexView iGenderPieChartIndexView, Account _operator)
        {
            _Operator = _operator;

            _IGenderPieChartIndexView = iGenderPieChartIndexView;
        }
        private void Attachment()
        {
            _IGenderPieChartIndexView.IStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployee;

        }

        public void InitPresent(bool isPostBack)
        {
            Attachment();
            if (!isPostBack)
            {
                StatisticsConditionPresenter statisticsConditionFontPresenter =
                    new StatisticsConditionPresenter(_IGenderPieChartIndexView.IStatisticsConditionView, _Operator);
                statisticsConditionFontPresenter.InitPresent(isPostBack);
                _IGenderPieChartIndexView.IStatisticsConditionView.btnExportVisible = false;
                //StatisticsEmployee(null, null);
            }
        }
        public void StatisticsEmployee(object source, EventArgs e)
        {
            if (new StatisticsConditionPresenter(_IGenderPieChartIndexView.IStatisticsConditionView, _Operator).CheckValid())
            {
                try
                {
                    GenderPieChartPresenter genderPieChartPresenter =
                        new GenderPieChartPresenter(_IGenderPieChartIndexView.IGenderPieChartView,
                                                    _IGenderPieChartIndexView.IStatisticsConditionView, _Operator);
                    genderPieChartPresenter.DrawChart();
                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

    }
}
