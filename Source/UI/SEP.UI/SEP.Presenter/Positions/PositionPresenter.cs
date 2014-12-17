using SEP.Presenter.Core;
using SEP.Presenter.IPresenter.IPositions;
using SEP.Model.Accounts;

namespace SEP.Presenter.Positions
{
    public class PositionPresenter : BasePresenter
    {
        private IPositionInfoView _ItsView;

        private PositionListPresenter _ListPresenter;

        public PositionPresenter(IPositionInfoView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;

            _ListPresenter = new PositionListPresenter(itsView.PositionListView, loginUser);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            switch (_ItsView.PositionView.OperationType)
            {
                case "Add":
                    new AddPositionPresenter(_ItsView.PositionView, LoginUser);
                    break;
                case "Update":
                    new UpdatePositionPresenter(_ItsView.PositionView, LoginUser);
                    break;
                case "Delete":
                    new DeletePositionPresenter(_ItsView.PositionView, LoginUser);
                    break;
                case "Detail":
                    new DetailPositionPresenter(_ItsView.PositionView, LoginUser);
                    break;
            }
        }

        private void AttachViewEvent()
        {
            //大界面按钮
            _ItsView.PositionListView.BtnAddEvent += ShowAddView;
            _ItsView.PositionListView.BtnUpdateEvent += ShowUpdateView;
            _ItsView.PositionListView.BtnDeleteEvent += ShowDeleteView;
            _ItsView.PositionListView.BtnDetailEvent += ShowDetailView;
            _ItsView.PositionListView.BtnSearchEvent += ShowSearchView;
            //小界面按钮
            _ItsView.PositionView.ActionButtonEvent += ActionEvent;
            _ItsView.PositionView.CancelButtonClientEvent = "return CloseModalPopupExtender('" + _ItsView.divMPEPositionClientID +
                                         "');";
            _ItsView.PositionView.CancelButtonEvent += CancelEvent;
        }

        private void ShowAddView()
        {
            new AddPositionPresenter(_ItsView.PositionView, LoginUser).InitView();
            _ItsView.PositionViewVisible = true;
        }

        private void ShowUpdateView(string id)
        {
            new UpdatePositionPresenter(_ItsView.PositionView, LoginUser).InitView(id);
            _ItsView.PositionViewVisible = true;
        }

        private void ShowDeleteView(string id)
        {
            new DeletePositionPresenter(_ItsView.PositionView, LoginUser).InitView(id);
            _ItsView.PositionViewVisible = true;
        }
        private void ShowDetailView(string id)
        {
            new DetailPositionPresenter(_ItsView.PositionView, LoginUser).InitView(id);
            _ItsView.PositionViewVisible = true;
        }

        private void ShowSearchView()
        {
            _ItsView.PositionViewVisible = false;
        }

        private void ActionEvent()
        {
            if (_ItsView.PositionView.ActionSuccess)
            {
                _ListPresenter.PositionDataBind();
                _ItsView.PositionViewVisible = false;
            }
            else
            {
                _ItsView.PositionViewVisible = true;
            }
        }

        private void CancelEvent()
        {
            _ItsView.PositionViewVisible = false;
        }

        public void InitView(bool pageIsPostBack)
        {
            _ListPresenter.InitView(pageIsPostBack);
        }

        public override void Initialize(bool isPostBack)
        {
            _ListPresenter.Initialize(isPostBack);
        }
    }
}
