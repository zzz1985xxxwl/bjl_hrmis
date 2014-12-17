using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SEP.HRMIS.Presenter;

namespace SEP.Performance.Pages
{
    public partial class DepartmentDistribution : BasePage
    {
        private DepartmentDistributionPresenter departmentDistributionPresenter;
        protected void Page_Load(object sender, EventArgs e)
        {
            departmentDistributionPresenter = new DepartmentDistributionPresenter(DepartmentDistributionView1);
            departmentDistributionPresenter.InitDepartmentTree(IsPostBack);
        }
    }
}
