using System;

namespace SEP.Performance.Pages.HRMIS.OverWorkPages
{
    public partial class OverWorkList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OverWorkListView1.LoginUser = LoginUser;
        }
    }
}