

using SEP.IBll;
using SEP.IBll.Departments;

namespace SEP.HRMIS.Presenter
{
    public class DepartmentDistributionPresenter
    { 
        private readonly IDepartmentDistributionView _IDepartmentDistributionView;

        public DepartmentDistributionPresenter(IDepartmentDistributionView iDepartmentDistributionView)
        {
            _IDepartmentDistributionView = iDepartmentDistributionView;
        }

        private IDepartmentBll _IDepartmentBll = BllInstance.DepartmentBllInstance;
        public void InitDepartmentTree(bool IsPostBack)
        {
            if (!IsPostBack)
            {
                _IDepartmentDistributionView.DepartmentDistribution = _IDepartmentBll.GetAllDepartment();
            }
        }
    }
}
