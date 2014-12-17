using System;
using System.Web.UI;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.MainPage
{
    public partial class MainPageView : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(LoginUser.Id == Account.AdminPkid)
            {
                all.Visible = false;
            }
        }

        public Account LoginUser
        {
            get { return  Session[SessionKeys.LOGININFO] as Account; }
        }
    }
}