using SEP.HRMIS.Presenter.PayModule.IPresenter.IAccountSet;

namespace SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSetPara
{
   public class AccountSetParaPresenter
    {
       private readonly IManageAccountSetParaView _ItsView;
       private readonly AccountSetParaListPresenter _TheBasicPresenter;

       public AccountSetParaPresenter(IManageAccountSetParaView itsView)
        {
            _ItsView = itsView;
            _TheBasicPresenter = new AccountSetParaListPresenter(itsView.AccountSetParaListView);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        private void SwitchLittleViewPresenter()
        {
            switch (_ItsView.AccountSetParaView.OperationType)
            {
                case "Add":
                    new CreateAccountSetParaPresenter(_ItsView.AccountSetParaView);
                    break;
                case "Update":
                    new UpdateAccountSetParaPresenter(_ItsView.AccountSetParaView);
                    break;
                case "Delete":
                    new DeleteAccountSetParaPresenter(_ItsView.AccountSetParaView);
                    break;
                case "Detail":
                    new DetailAccountSetParaPresenter(_ItsView.AccountSetParaView);
                    break;
            }
        }

        public void AttachViewEvent()
        {
            //大界面按钮
            _ItsView.AccountSetParaListView.BtnAddEvent += ShowAddView;
            _ItsView.AccountSetParaListView.BtnUpdateEvent += ShowUpdateView;
            _ItsView.AccountSetParaListView.BtnDeleteEvent += ShowDeleteView;
            _ItsView.AccountSetParaListView.BtnDetailEvent += ShowDetailView;
            _ItsView.AccountSetParaListView.btnSearchClick += ShowSearchView;
            //小界面按钮
            _ItsView.AccountSetParaView.ActionButtonEvent += ActionEvent;
            _ItsView.AccountSetParaView.CancelButtonEvent += CancelEvent;
        }

       private void ShowAddView()
       {
           new CreateAccountSetParaPresenter(_ItsView.AccountSetParaView).InitView();
           _ItsView.AccountSetParaViewVisible = true;
       }

       private void ShowUpdateView(string id)
       {
           new UpdateAccountSetParaPresenter(_ItsView.AccountSetParaView).InitView(id);
           _ItsView.AccountSetParaViewVisible = true;
       }

       private void ShowDeleteView(string id)
       {
           new DeleteAccountSetParaPresenter(_ItsView.AccountSetParaView).InitView(id);
           _ItsView.AccountSetParaViewVisible = true;
       }
       private void ShowDetailView(string id)
       {
           new DetailAccountSetParaPresenter(_ItsView.AccountSetParaView).InitView(id);
           _ItsView.AccountSetParaViewVisible = true;
       }
       private void ShowSearchView()
       {
           new AccountSetParaListPresenter(_ItsView.AccountSetParaListView).AccountSetParaDataBind();
           _ItsView.AccountSetParaViewVisible = false;
       }
       
        public void ActionEvent()
        {
            if (_ItsView.AccountSetParaView.ActionSuccess)
            {
                _TheBasicPresenter.AccountSetParaDataBind();
                _ItsView.AccountSetParaViewVisible = false;
            }
            else
            {
                _ItsView.AccountSetParaViewVisible = true;
            }
        }

        public void CancelEvent()
        {
            _ItsView.AccountSetParaViewVisible = false;
        }
        public void InitView(bool pageIsPostBack)
        {
            _TheBasicPresenter.InitView(pageIsPostBack);
        }
    }
}
