using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;
using SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class AdjustHistoryDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A604))
            {
                throw new ApplicationException("没有权限访问");
            }
            int adjustHistoryID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["AdjustHistoryID"]));

            AdjustHistoryDetailPresenter presenter = new AdjustHistoryDetailPresenter(AdjustHistoryDetailView1);

            presenter.InitView(IsPostBack, adjustHistoryID);
            AdjustHistoryDetailView1.GoToListPage += GoToListPage;
        }

        private void GoToListPage(object sender, EventArgs e)
        {
            Response.Redirect("AdjustSalaryHistoryList.aspx?EmployeeID=" + SecurityUtil.DECEncrypt(AdjustHistoryDetailView1.EmployeeID), false);
        }
    }
}