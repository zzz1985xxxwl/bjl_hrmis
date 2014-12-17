using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.EmployeeReimburse;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class ReimburseDetailBack : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A901))
            {
                throw new ApplicationException("没有权限访问");
            }
            Account loginUser = new Account();
            loginUser.Id = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["EmployeeID"]));
            DetailEmployeeReimbursePresenter detailEmployeeReimbursePresenter = new DetailEmployeeReimbursePresenter(
                Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["ReimburseID"])), EmployeeReimburseView1);
            detailEmployeeReimbursePresenter.ToMyReimbursePage += ToSearchReimbursePage;
            detailEmployeeReimbursePresenter.InitView(IsPostBack);
        }

        private void ToSearchReimbursePage(object sender, EventArgs e)
        {
            Response.Redirect("SearchReimburse.aspx", false);
        }
    }
}
