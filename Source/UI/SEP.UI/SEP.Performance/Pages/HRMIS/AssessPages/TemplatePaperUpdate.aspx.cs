using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class TemplatePaperUpdate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A702))
            {
                throw new ApplicationException("没有权限访问");
            }

            TemplatePaperUpdatePresenter presenter =
                new TemplatePaperUpdatePresenter(
                    Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["TemplatePaperID"])), TemplatePaperView1,
                    LoginUser);
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
