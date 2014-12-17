using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;

namespace SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter
{
    public class DutyClassInfoPresenter
    {
        private readonly IDutyClassInfoView _InfoView;
        private readonly DutyClassListPresenter _ListPresenter;

        public DutyClassInfoPresenter(IDutyClassInfoView infoView)
        {
            _InfoView = infoView;
            _ListPresenter = new DutyClassListPresenter(_InfoView.DutyClassListView);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            switch (_InfoView.DutyClassView.OperationType)
            {
                case "Add":
                    new DutyClassAddPresenter(_InfoView.DutyClassView);
                    break;
                case "Update":
                    new DutyClassUpdatePresenter(_InfoView.DutyClassView);
                    break;
                case "Detail":
                    new DutyClassDetailPresenter(_InfoView.DutyClassView);
                    break;

            }
        }

        public void AttachViewEvent()
        {
            //大界面按钮
            _InfoView.DutyClassListView.BtnAddEvent += ShowAddView;
            _InfoView.DutyClassListView.BtnUpdateEvent += ShowUpdateView;

            _InfoView.DutyClassListView.BtnDetailEvent += ShowDetailView;
   
            //小界面按钮
            _InfoView.DutyClassView.ActionButtonEvent += ActionEvent;
            _InfoView.DutyClassView.CancelButtonEvent += CancelEvent;
        }

        private void ShowAddView()
        {
            new DutyClassAddPresenter(_InfoView.DutyClassView).InitView();
            _InfoView.DutyClassViewVisible = true;
        }

        private void ShowUpdateView(string id)
        {
            new DutyClassUpdatePresenter(_InfoView.DutyClassView).InitView(id);
            _InfoView.DutyClassViewVisible = true;
        }


        private void ShowDetailView(string id)
        {
            new DutyClassDetailPresenter(_InfoView.DutyClassView).InitView(id);
            _InfoView.DutyClassViewVisible = true;
        }

        public void ActionEvent()
        {
            if (_InfoView.DutyClassView.ActionSuccess)
            {
                _ListPresenter.RuleDataBind();
                _InfoView.DutyClassViewVisible = false;
            }
            else
            {
                _InfoView.DutyClassViewVisible = true;
            }
        }

        public void CancelEvent()
        {
            _InfoView.DutyClassViewVisible = false;
        }
        public void InitView(bool pageIsPostBack)
        {
            _ListPresenter.InitView(pageIsPostBack);
        }
    }
}
