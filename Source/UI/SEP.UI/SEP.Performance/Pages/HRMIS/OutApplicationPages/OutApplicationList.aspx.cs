using System;

namespace SEP.Performance.Pages.HRMIS.OutApplicationPages
{
    public partial class OutApplicationList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OutApplicationListView1.LoginUser = LoginUser;
        }
    }
}