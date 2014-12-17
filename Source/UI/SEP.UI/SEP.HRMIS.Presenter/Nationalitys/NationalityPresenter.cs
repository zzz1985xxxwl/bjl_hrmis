using SEP.HRMIS.Presenter.IPresenter.INationality;

namespace SEP.HRMIS.Presenter.Nationalitys
{
    public class NationalityPresenter
    {
        private readonly INationalityInfoView _ItsView;
        private readonly NationalityListPresenter _TheBasicPresenter;

        public NationalityPresenter(INationalityInfoView itsView)
        {
            _ItsView = itsView;
            _TheBasicPresenter = new NationalityListPresenter(itsView.NationalityListView);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            switch (_ItsView.NationalityView.OperationType)
            {
                case "Add":
                    new AddNationalityPresenter(_ItsView.NationalityView);
                    break;
                case "Update":
                    new UpdateNationalityPresenter(_ItsView.NationalityView);
                    break;
                case "Delete":
                    new DeleteNationalityPresenter(_ItsView.NationalityView);
                    break;
                case "Detail":
                    new DetailNationalityPresenter(_ItsView.NationalityView);
                    break;
            }
        }

        public void AttachViewEvent()
        {
            //大界面按钮
            _ItsView.NationalityListView.BtnAddEvent += ShowAddView;
            _ItsView.NationalityListView.BtnUpdateEvent += ShowUpdateView;
            _ItsView.NationalityListView.BtnDeleteEvent += ShowDeleteView;
            _ItsView.NationalityListView.BtnDetailEvent += ShowDetailView;
            //_ItsView.NationalityListView.BtnSearchEvent += ShowSearchView;
            //小界面按钮
            _ItsView.NationalityView.ActionButtonEvent += ActionEvent;
            _ItsView.NationalityView.CancelButtonEvent += CancelEvent;
        }

        private void ShowAddView()
        {
            new AddNationalityPresenter(_ItsView.NationalityView).InitView();
            _ItsView.NationalityViewVisible = true;
        }

        private void ShowUpdateView(string id)
        {
            new UpdateNationalityPresenter(_ItsView.NationalityView).InitView(id);
            _ItsView.NationalityViewVisible = true;
        }

        private void ShowDeleteView(string id)
        {
            new DeleteNationalityPresenter(_ItsView.NationalityView).InitView(id);
            _ItsView.NationalityViewVisible = true;
        }

        private void ShowDetailView(string id)
        {
            new DetailNationalityPresenter(_ItsView.NationalityView).InitView(id);
            _ItsView.NationalityViewVisible = true;
        }

        public void ActionEvent()
        {
            if (_ItsView.NationalityView.ActionSuccess)
            {
                _TheBasicPresenter.NationalityDataBind();
                _ItsView.NationalityViewVisible = false;
            }
            else
            {
                _ItsView.NationalityViewVisible = true;
            }
        }

        public void CancelEvent()
        {
            _ItsView.NationalityViewVisible = false;
        }

        public void InitView(bool pageIsPostBack)
        {
            _TheBasicPresenter.InitView(pageIsPostBack);
        }
    }
}