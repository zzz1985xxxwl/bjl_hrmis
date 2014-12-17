using System;
using SEP.Presenter.CompanyRegulations;

namespace SEP.Performance.Pages.SEP.CompanyRegulationsPages
{
    public partial class EditCompanyRegulation : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new CompanyRegulationsPresenter(EditCompanyRegulationsView1, LoginUser);
        }
    }
}
