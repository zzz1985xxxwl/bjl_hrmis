using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class AdjustSalaryHistoryList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A604))
            {
                throw new ApplicationException("没有权限访问");
            }
            int employeeID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["EmployeeID"]));
            AdjustHistoryListPresenter adjustHistoryListPresenter =
                new AdjustHistoryListPresenter(AdjustHistoryListView1);
            adjustHistoryListPresenter.InitPresenter(employeeID);

            AdjustHistoryListView1.GoToBackPage += CancelCommand;
            AdjustHistoryListView1.GoToAdjustHistoryDetailPage += Detail_Command;
        }

        private void CancelCommand(object sender, EventArgs e)
        {
            Response.Redirect("SetEmployeeAccountSetList.aspx", false);
        }

        private void Detail_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("AdjustHistoryDetail.aspx?AdjustHistoryID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }

    }
}
