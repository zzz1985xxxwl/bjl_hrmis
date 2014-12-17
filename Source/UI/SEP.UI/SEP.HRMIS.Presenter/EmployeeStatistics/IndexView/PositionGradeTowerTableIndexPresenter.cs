using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.IBll;
using SEP.IBll.Departments;
using SEP.Model.Accounts;
using SEP.Model.Utility;


namespace SEP.HRMIS.Presenter
{
    public class PositionGradeTowerTableIndexPresenter
    {
        private readonly Account _Operator;
        private readonly IPositionGradeTowerTableIndexView _IPositionGradeTowerTableIndexView;
        public IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public PositionGradeTowerTableIndexPresenter(IPositionGradeTowerTableIndexView iPositionGradeTowerTableIndexView, Account _operator)
        {
            _Operator = _operator;

            _IPositionGradeTowerTableIndexView = iPositionGradeTowerTableIndexView;
        }
        private void Attachment()
        {
            _IPositionGradeTowerTableIndexView.IStatisticsConditionView.StatisticsButtonEvent += StatisticsEmployee;

        }

        public void InitPresent(bool isPostBack)
        {
            Attachment();
            if (!isPostBack)
            {
                StatisticsConditionPresenter statisticsConditionFontPresenter =
                    new StatisticsConditionPresenter(_IPositionGradeTowerTableIndexView.IStatisticsConditionView, _Operator);
                statisticsConditionFontPresenter.InitPresent(isPostBack);
                _IPositionGradeTowerTableIndexView.IStatisticsConditionView.btnExportVisible = false;
                //StatisticsEmployee(null, null);
            }
        }
        public void StatisticsEmployee(object source, EventArgs e)
        {
            if (new StatisticsConditionPresenter(_IPositionGradeTowerTableIndexView.IStatisticsConditionView, _Operator).CheckValid())
            {
                try
                {
                    PositionGradeTowerTablePresenter PositionGradeTowerTablePresenter =
                        new PositionGradeTowerTablePresenter(_IPositionGradeTowerTableIndexView.IPositionGradeTowerTableView,
                                                             _IPositionGradeTowerTableIndexView.IStatisticsConditionView, _Operator);
                    PositionGradeTowerTablePresenter.DrawChart(null);

                }
                catch (ApplicationException)
                {
                    //_IMonthAttendanceView.Message = "<span class='fontred'>" + ex.Message + "</span>";
                }
            }
        }

    }
}
