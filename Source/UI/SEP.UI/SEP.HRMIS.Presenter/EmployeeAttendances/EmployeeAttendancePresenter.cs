using SEP.HRMIS.Presenter.IPresenter.IEmployeeAttendance;
using SEP.HRMIS.Presenter.EmployeeAttendances.LittleViewPresenter;
using SEP.Model.Accounts;
using PresenterCore = SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.EmployeeAttendances
{
    public class EmployeeAttendancePresenter : PresenterCore.BasePresenter
    {

        private readonly IEmployeeAttendanceView _ItsView;
        private readonly AttendanceSearchPresenter _SearchPresenter;

        public EmployeeAttendancePresenter(IEmployeeAttendanceView itsView,Account loginUser): base(loginUser)
        {
            _ItsView = itsView;
            _SearchPresenter = new AttendanceSearchPresenter(_ItsView.theSearchView, loginUser);
            SwitchLittleViewPresenter();
            AttachViewEvent();
        }

        public override void Initialize(bool isPostBack)
        {
            //_SearchPresenter.Initialize(isPostBack);
        }

        private void SwitchLittleViewPresenter()
        {
            switch (_ItsView.theRecordView.OperationType)
            {
                case "Add":
                    new AddAttendancePresenter(_ItsView.theRecordView, LoginUser);
                    break;
                case "Delete":
                    new DeleteAttendancePresenter(_ItsView.theSearchView, LoginUser);
                    break;


            }
        }

        public void AttachViewEvent()
        {
            //处理查询界面中涉及主界面布局的事件
            _ItsView.theSearchView.OnAdd += HandleSearchViewAddEvent;
            _ItsView.theSearchView.OnAttendanceDelete += HandleSearchViewDeleteEvent;
            //处理新增界面中涉及主界面布局的事件
            _ItsView.theRecordView.ActionButtonEvent += HandleRecordViewAddEvent;
            _ItsView.theRecordView.CancelButtonEvent += HandleRecordViewCancelEvent;
            _ItsView.theRecordView.OnSelectTypeChange += HandleRecordViewTypeChangeEvent;

        }

        public void InitView(bool pageIsPostBack)
        {
            _SearchPresenter.Initialize(pageIsPostBack);

        }

        private void HandleRecordViewAddEvent()
        {
            if (_ItsView.theRecordView.IsAddSuccess)
            {
                HideTheRecordView();
                _SearchPresenter.SearchEvent();
            }
            else
            {
                ShowTheRecordView();
            }
        }

        private void HandleSearchViewAddEvent()
        {
            new AddAttendancePresenter(_ItsView.theRecordView, LoginUser).Initialize(false);
            _ItsView.ShowTheRecordView = true;
        }

        private void HandleSearchViewDeleteEvent(string id)
        {
            new DeleteAttendancePresenter(_ItsView.theSearchView, LoginUser).DeleteEvent(id);
            _ItsView.ShowTheRecordView = false;
            _SearchPresenter.SearchEvent();
        }

        private void HandleRecordViewCancelEvent()
        {
            HideTheRecordView();
        }

        private void HandleRecordViewTypeChangeEvent()
        {
            ShowTheRecordView();
        }

        private void ShowTheRecordView()
        {
            _ItsView.ShowTheRecordView = true;
        }

        private void HideTheRecordView()
        {
            _ItsView.ShowTheRecordView = false;
        }

    }
}
