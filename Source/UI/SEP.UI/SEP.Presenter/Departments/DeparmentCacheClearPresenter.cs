using SEP.IBll;
using SEP.IBll.Departments;

namespace SEP.Presenter.Departments
{
    public class DeparmentCacheClearPresenter
    {
        private IDepartmentBll _DepartmentBll = BllInstance.DepartmentBllInstance;

        public void ClearDepartmentCache()
        {
            _DepartmentBll.ClearCache();
        }
    }
}