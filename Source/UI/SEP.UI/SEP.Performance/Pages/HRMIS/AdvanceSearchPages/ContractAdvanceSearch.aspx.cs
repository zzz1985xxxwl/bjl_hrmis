using System;
using SEP.HRMIS.Presenter.AdvanceSearch;

namespace SEP.Performance.Pages.HRMIS.AdvanceSearchPages
{
    public partial class ContractAdvanceSearch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContractAdvancedSearchListPresenter ContractAdvancedSearchListPresenter =
                new ContractAdvancedSearchListPresenter(ContractAdvanceSearchList1);
            ContractAdvancedSearchListPresenter.InitView(Page.IsPostBack);
        }
    }
}
