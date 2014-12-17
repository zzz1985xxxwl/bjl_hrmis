using SEP.Model.Accounts;
using SEP.Presenter.IPresenter.IDepartments;
using SEP.Presenter.Core;

namespace SEP.Presenter.Departments
{
    public class DepartmentPresenter : BasePresenter
    {
        private readonly IDepartmentInfoView _ItsView;
        private readonly DepartmentListPresenter _TheBasicPresenter;

        public DepartmentPresenter(IDepartmentInfoView itsView, Account loginUser)
            : base(loginUser)
        {
            _ItsView = itsView;
            _TheBasicPresenter = new DepartmentListPresenter(itsView.DepartmentListView, loginUser);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        public override void Initialize(bool isPostBack)
        {
            _TheBasicPresenter.InitView(isPostBack);
        }

        private void SwitchLittleViewPresenter()
        {
            switch (_ItsView.DepartmentView.OperationType)
            {
                case "Add":
                    new AddDepartmentPresenter(_ItsView.DepartmentView, LoginUser);
                    break;
                case "Update":
                    new UpdateDepartmentPresenter(_ItsView.DepartmentView, LoginUser);
                    break;
                case "Delete":
                    new DeleteDepartmentPresenter(_ItsView.DepartmentView, LoginUser);
                    break;
                case "Detail":
                    new DetailDepartmentPresenter(_ItsView.DepartmentView, LoginUser);
                    break;

            }
        }

        private void AttachViewEvent()
        {
            //大界面按钮
            _ItsView.DepartmentListView.BtnAddEvent += ShowAddView;
            _ItsView.DepartmentListView.BtnUpdateEvent += ShowUpdateView;
            
            _ItsView.DepartmentListView.BtnDeleteEvent += ShowDeleteView;
            _ItsView.DepartmentListView.BtnDetailEvent += ShowDetailView;
            //_ItsView.DepartmentListView.BtnSearchEvent += ShowSearchView;
            //小界面按钮
            _ItsView.DepartmentView.ActionButtonEvent += ActionEvent;
            _ItsView.DepartmentView.CancelButtonClientEvent = "return CloseModalPopupExtender('" + _ItsView.divMPEDepartmentClientID +
                                         "');";
            _ItsView.DepartmentView.CancelButtonEvent += CancelEvent;
        }

        protected void ShowAddView(string id)
        {
            new AddDepartmentPresenter(_ItsView.DepartmentView, LoginUser).InitView(id);
            _ItsView.DepartmentViewVisible = true;
        }

        protected void ShowUpdateView(string id)
        {
            new UpdateDepartmentPresenter(_ItsView.DepartmentView, LoginUser).InitView(id);
            _ItsView.DepartmentViewVisible = true;
        }

        protected void ShowDeleteView(string id)
        {
            new DeleteDepartmentPresenter(_ItsView.DepartmentView, LoginUser).InitView(id);
            _ItsView.DepartmentViewVisible = true;
        }

        protected void ShowDetailView(string id)
        {
            new DetailDepartmentPresenter(_ItsView.DepartmentView, LoginUser).InitView(id);
            _ItsView.DepartmentViewVisible = true;
        }

        protected void ActionEvent()
        {
            if (_ItsView.DepartmentView.ActionSuccess)
            {
                _TheBasicPresenter.DepartmentDataBind();
                _ItsView.DepartmentViewVisible = false;
            }
            else
            {
                _ItsView.DepartmentViewVisible = true;
            }
        }

        protected void CancelEvent()
        {
            _ItsView.DepartmentViewVisible = false;
        }
    }
}
