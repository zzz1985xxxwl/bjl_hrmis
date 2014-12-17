using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.EmployeeReimburse;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class UpdateReimburseCustomer : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A904))
            {
                throw new ApplicationException("没有权限访问");
            }
            UpdateReimburseCustomerPresenter presenter = new UpdateReimburseCustomerPresenter(
                Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["ReimburseID"])), LoginUser, ReimburseCustomerView1);
            presenter.ToMyReimbursePage += ToSearchReimbursePage;
            presenter.Init(IsPostBack);
        }

        private void ToSearchReimbursePage(object sender, EventArgs e)
        {
            Response.Redirect("ReimburseCustomerSearch.aspx", false);
        }
    }
}
