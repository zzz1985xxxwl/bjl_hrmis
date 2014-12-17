using System;

using SEP.Model.CompanyRegulations;
using SEP.Presenter.CompanyRegulations;

namespace SEP.Performance.Pages.SEP.CompanyRegulationsPages
{
    public partial class NewEmployeeGuide : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new CompanyRegulationPresenter(CompanyRegulationView1, LoginUser);
            
            CompanyRegulationView1.ReguType = ReguType.NewEmployeeGuide;
        }
    }
}
