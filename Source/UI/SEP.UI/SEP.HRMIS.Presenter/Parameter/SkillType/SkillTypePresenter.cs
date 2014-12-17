namespace SEP.HRMIS.Presenter.Parameter.SkillType
{
    public class SkillTypePresenter
    {
         private readonly ISkillTypeInfoView _ItsView;
        private readonly SkillTypeListPresenter _SearchPresenter;

        public SkillTypePresenter(ISkillTypeInfoView itsView)
        {
            _ItsView = itsView;
            _SearchPresenter = new SkillTypeListPresenter(_ItsView.SkillTypeListView);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            switch (_ItsView.SkillTypeView.OperationType)
            {
                case "Add":
                    new AddSkillTypePresenter(_ItsView.SkillTypeView);
                    break;
                case "Update":
                    new UpdateSkillTypePresenter(_ItsView.SkillTypeView);
                    break;
                case "Delete":
                    new DeleteSkillTypePresenter(_ItsView.SkillTypeListView);
                    break;
            }
        }

        public void AttachViewEvent()
        {
            //处理查询界面中涉及主界面布局的事件
            _ItsView.SkillTypeListView.BtnAddEvent += HandleSearchViewAddEvent;
            _ItsView.SkillTypeListView.BtnDeleteEvent += HandleSearchViewDeleteEvent;
            _ItsView.SkillTypeListView.BtnUpdateEvent += HandleSearchViewUpdateEvent;
            //处理新增界面中涉及主界面布局的事件
            _ItsView.SkillTypeView.ActionButtonEvent += HandleSkillTypeViewAddEvent;
            _ItsView.SkillTypeView.CancelButtonEvent += HandleSkillTypeViewCancelEvent;

        }

        public void InitView(bool pageIsPostBack)
        {
            _SearchPresenter.InitView(pageIsPostBack);

        }

        private void HandleSkillTypeViewAddEvent()
        {
            if (_ItsView.SkillTypeView.ActionSuccess)
            {
                HideTheView();
                _SearchPresenter.SearchEvent();
            }
            else
            {
                ShowTheView();
            }
        }

        private void HandleSearchViewAddEvent()
        {
            new AddSkillTypePresenter(_ItsView.SkillTypeView).InitView(false);
            _ItsView.ShowSkillTypeViewVisible = true;
        }

        private void HandleSearchViewDeleteEvent(string id)
        {
            new DeleteSkillTypePresenter(_ItsView.SkillTypeListView).DeleteEvent(id);
            _ItsView.ShowSkillTypeViewVisible = false;
            _SearchPresenter.SearchEvent();
        }

        private void HandleSearchViewUpdateEvent(string id)
        {
            new UpdateSkillTypePresenter(_ItsView.SkillTypeView).InitView(id);
            _ItsView.ShowSkillTypeViewVisible = true;
        }

        private void HandleSkillTypeViewCancelEvent()
        {
            HideTheView();
        }

        private void ShowTheView()
        {
            _ItsView.ShowSkillTypeViewVisible = true;
        }

        private void HideTheView()
        {
            _ItsView.ShowSkillTypeViewVisible = false;
        }

      
    }
}
