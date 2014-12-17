using System;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.SEP.PositionPages
{
    public partial class PositionManage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.SEP, Powers.A202))
            {
                throw new ApplicationException("没有权限访问");
            }
        }
    }
}