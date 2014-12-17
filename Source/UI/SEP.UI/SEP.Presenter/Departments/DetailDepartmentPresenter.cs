using SEP.Model.Accounts;
using SEP.Presenter.IPresenter.IDepartments;

namespace SEP.Presenter.Departments
{
    public class DetailDepartmentPresenter 
    {
        private readonly IDepartmentView _ItsView;
        private readonly Account _LoginUser;
        public DetailDepartmentPresenter(IDepartmentView itsView, Account loginUser)
        {
            _LoginUser = loginUser;
            _ItsView = itsView;
            AttachViewEvent();
        }

        public void AttachViewEvent()
        {
            _ItsView.ActionButtonEvent += DetailEvent;
        }

        public void InitView(string id)
        {
            new DepartmentIniter(_ItsView).InitTheViewToDefault();
            _ItsView.OperationTitle = DepartmentUtility.DetailPageTitle;
            _ItsView.ActionButtonTxt = DepartmentUtility.DetailActionButtonTxt;
            _ItsView.OperationType = DepartmentUtility.DetailOperationType;
            _ItsView.SetReadonly = true;

            new DepartmentDataBinder(_ItsView, _LoginUser).DataBind(id);
        }

        public void DetailEvent()
        {
            _ItsView.ActionSuccess = true;
        }
    }
}