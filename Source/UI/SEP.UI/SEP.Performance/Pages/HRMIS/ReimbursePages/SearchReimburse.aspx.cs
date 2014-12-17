using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.EmployeeReimburse;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class SearchReimburse : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A901))
            {
                throw new ApplicationException("没有权限访问");
            }

            SearchReimburseInfoPresenter presenter = new SearchReimburseInfoPresenter(SearchReimburseInfoView1, LoginUser);
            presenter.btnViewClick += btnViewClickEvent;
            presenter.Initialize(IsPostBack);
        }

        private void btnViewClickEvent(object sender, CommandEventArgs e)
        {
            Response.Redirect(
                "ReimburseDetailBack.aspx?ReimburseID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString().Split('|')[0]) +
                "&EmployeeID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString().Split('|')[1]), false);
        }
    }
}
