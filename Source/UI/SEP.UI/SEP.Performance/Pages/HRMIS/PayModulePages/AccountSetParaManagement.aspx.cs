using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.PayModule.AccountSet.AccountSetPara;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class AccountSetParaManagement : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A601))
            {
                throw new ApplicationException("没有权限访问");
            }
            AccountSetParaPresenter thePresenter = new AccountSetParaPresenter(ManageAccountSetParaView1);
            thePresenter.InitView(Page.IsPostBack);
        }
    }
}