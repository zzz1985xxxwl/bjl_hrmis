using System;
using SEP.HRMIS.Presenter;

namespace SEP.Performance.Pages.SEP.CompanyRegulationsPages
{
    public partial class CompanyFrame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DepartmentHistoryListPresenter thePresenter = new DepartmentHistoryListPresenter(DepartmentHistoryListView1);
            thePresenter.InitView(Page.IsPostBack);
        }
    }
}
