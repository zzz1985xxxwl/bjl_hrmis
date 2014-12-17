using SEP.Presenter.IPresenter;
using SEP.Presenter.IPresenter.IDepartments;

namespace SEP.Presenter.Departments
{
    public class DepartmentIniter : IViewIniter
    {
        private readonly IDepartmentView _ItsView;

        public DepartmentIniter(IDepartmentView itsView)
        {
            _ItsView = itsView;
        }

        public void InitTheViewToDefault()
        {
            _ItsView.DepartmentID = string.Empty;
            _ItsView.DepartmentName = string.Empty;
            _ItsView.LeaderName = string.Empty;
            _ItsView.LeaderNameMsg = string.Empty;
            _ItsView.DepNameMsg = string.Empty;
            _ItsView.Message = string.Empty;
            _ItsView.OperationTitle = string.Empty;
            _ItsView.Address = string.Empty;
            _ItsView.Phone = string.Empty;
            _ItsView.Description = string.Empty;
            _ItsView.Others = string.Empty;
            _ItsView.FoundationTime = string.Empty;
            _ItsView.TimeErrorMsg = string.Empty;
            _ItsView.Fax = string.Empty;
        }
    }
}