
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter
{
    public class DutyClassDetailPresenter
    {
        private readonly IDutyClassView _View;
        private readonly DutyClassUtility _Utility;

        public DutyClassDetailPresenter(IDutyClassView view)
        {
            _View = view;
            _Utility = new DutyClassUtility(_View);
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _View.ActionButtonEvent += DetailEvent;
        }

        public void InitView(string id)
        {
            _Utility.InitTheViewToDefault();
            _View.OperationTitle = "°à±ðÏêÇé";
            _View.OperationType = "Detail";
            _Utility.DataBind(id);
        }

        public void DetailEvent()
        {
            _View.ActionSuccess = true;
        }

    }
}
