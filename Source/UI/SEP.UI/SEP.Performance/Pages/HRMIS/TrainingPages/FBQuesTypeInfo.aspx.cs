using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.Parameter.FBQuesType;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.TrainingPages
{
    public partial class FBQuesTypeInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A803))
            {
                throw new ApplicationException("没有权限访问");
            }
            FBQuesTypepresenter presenter = new FBQuesTypepresenter(FBQuesTypeInfoView1);
            presenter.InitView(Page.IsPostBack);
        }
    }
}
