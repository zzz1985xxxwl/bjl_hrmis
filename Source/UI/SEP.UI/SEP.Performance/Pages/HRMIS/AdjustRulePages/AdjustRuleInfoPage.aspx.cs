using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.AdjustRulePages
{
    public partial class AdjustRuleInfoPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A108))
            {
                throw new ApplicationException("没有权限访问");
            }
        }
    }
}