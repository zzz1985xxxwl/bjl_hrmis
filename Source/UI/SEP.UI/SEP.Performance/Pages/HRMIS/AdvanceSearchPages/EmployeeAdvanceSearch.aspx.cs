using System;
using SEP.HRMIS.Presenter.AdvanceSearch;

namespace SEP.Performance.Pages.HRMIS.AdvanceSearchPages
{
    public partial class EmployeeAdvanceSearch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeAdvancedSearchListPresenter EmployeeAdvancedSearchListPresenter =
                new EmployeeAdvancedSearchListPresenter(EmployeeAdvanceSearchList1);
            EmployeeAdvancedSearchListPresenter.InitView(Page.IsPostBack);
        }
    }
}
