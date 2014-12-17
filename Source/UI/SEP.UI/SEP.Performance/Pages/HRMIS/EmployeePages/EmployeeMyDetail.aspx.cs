using System;
using SEP.HRMIS.Presenter.EmployInformation;

namespace SEP.Performance.Pages
{
    public partial class EmployeeMyDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FrontViewEmployeeInfoPresenter fp = new FrontViewEmployeeInfoPresenter(EmployeeView1, LoginUser.Id.ToString());
            fp.InitView(Page.IsPostBack);
            
        }
    }
}
