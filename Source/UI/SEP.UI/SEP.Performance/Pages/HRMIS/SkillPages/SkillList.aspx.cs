using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages
{
    public partial class SkillList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A104))
            {
                throw new ApplicationException("没有权限访问");
            }
            SkillPresenter thePresenter = new SkillPresenter(SkillInfoView1);
            thePresenter.InitView(Page.IsPostBack);
        }
    }
}