using System;

namespace SEP.Performance.Pages.SEP.WorkTaskPages
{
    public partial class WorkTaskManage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLoginAccountName.Text = LoginUser.Name;
            lblLoginAccountID.Text = LoginUser.Id.ToString();
        }
    }
}
