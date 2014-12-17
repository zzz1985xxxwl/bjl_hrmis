using System;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.SEP.ServicesPages
{
    public partial class SmsCenter : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.SEP, Powers.A601))
            {
                throw new Exception("没有权限访问");
            }
        }
    }
}
