using System;
using SEP.HRMIS.Presenter.EmployInformation;
using ShiXin.Security;

namespace SEP.Performance.Pages
{
    public partial class EmployeeViewDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FrontViewEmployeeInfoPresenter fp = new FrontViewEmployeeInfoPresenter(EmployeeView1, SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.EmployeeId]));
            fp.InitView(Page.IsPostBack);
            EmployeeView1.MailToHRVisible = false;
        }
    }
}
