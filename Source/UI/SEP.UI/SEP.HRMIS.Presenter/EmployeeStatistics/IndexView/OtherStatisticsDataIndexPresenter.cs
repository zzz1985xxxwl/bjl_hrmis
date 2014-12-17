using System;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;


namespace SEP.HRMIS.Presenter
{
    public class OtherStatisticsDataIndexPresenter
    {
        private readonly IOtherStatisticsDataIndexView _IOtherStatisticsDataIndexView;
        private readonly Account _Operator;
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public OtherStatisticsDataIndexPresenter(IOtherStatisticsDataIndexView iOtherStatisticsDataIndexView, Account _operator)
        {
            _Operator = _operator;

            _IOtherStatisticsDataIndexView = iOtherStatisticsDataIndexView;
        }
        private void Attachment()
        {
            _IOtherStatisticsDataIndexView.IStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployee;

        }

        public void InitPresent(bool isPostBack)
        {
            Attachment();
            if (!isPostBack)
            {
                StatisticsConditionPresenter statisticsConditionFontPresenter =
                    new StatisticsConditionPresenter(_IOtherStatisticsDataIndexView.IStatisticsConditionView, _Operator);
                statisticsConditionFontPresenter.InitPresent(isPostBack);
                _IOtherStatisticsDataIndexView.IStatisticsConditionView.btnExportVisible = false;
                //StatisticsEmployee(null, null);
            }
        }
        public void StatisticsEmployee(object source, EventArgs e)
        {
            if (new StatisticsConditionPresenter(_IOtherStatisticsDataIndexView.IStatisticsConditionView, _Operator).CheckValid())
            {
                try
                {
                    OtherStatisticsDataPresenter OtherStatisticsDataPresenter =
                        new OtherStatisticsDataPresenter(_IOtherStatisticsDataIndexView.IOtherStatisticsDataView,
                                                         _IOtherStatisticsDataIndexView.IStatisticsConditionView,
                                                         _Operator);
                    OtherStatisticsDataPresenter.BindData(null, null);
                    _IOtherStatisticsDataIndexView.IOtherStatisticsDataView.IsEdit = false;
                    _IOtherStatisticsDataIndexView.IStatisticsConditionView.IsStatisticsTime = false;
                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

    }
}
