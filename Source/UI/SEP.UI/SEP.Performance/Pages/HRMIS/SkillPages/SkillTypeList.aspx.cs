using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.Parameter.SkillType;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages
{
    public partial class SkillTypeList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A103))
            {
                throw new ApplicationException("没有权限访问");
            }
            SkillTypePresenter thePresenter = new SkillTypePresenter(SkillTypeInfoView1);
            thePresenter.InitView(Page.IsPostBack);
        }
    }
}
