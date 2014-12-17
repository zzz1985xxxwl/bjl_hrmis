using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class TemplatePaperAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A702))
            {
                throw new ApplicationException("没有权限访问");
            }

            TemplatePaperAddPresenter presenter = new TemplatePaperAddPresenter(TemplatePaperView1, LoginUser);
            presenter.CancelEvent += ToAccountSetListPage;
            presenter.ToAccountSetListPage += ToAccountSetListPage;
            presenter.Initialize(IsPostBack);
        }

        private void ToAccountSetListPage()
        {
            Response.Redirect("TemplatePaperList.aspx", false);
        }
    }
}
