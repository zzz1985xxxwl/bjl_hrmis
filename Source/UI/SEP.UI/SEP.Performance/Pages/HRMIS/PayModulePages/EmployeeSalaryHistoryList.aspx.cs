using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;
using SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class EmployeeSalaryHistoryList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A604))
            {
                throw new ApplicationException("没有权限访问");
            }
            EmployeeSalaryHistoryListPresenter presenter = new EmployeeSalaryHistoryListPresenter(EmployeeSalaryHistoryListView1);
            presenter.InitPresenter(Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["EmployeeID"])));
            EmployeeSalaryHistoryListView1.GoToEmployeeSalaryHistoryDetailPage += Detail_Command;
            EmployeeSalaryHistoryListView1.GoToBackPage += CancelCommand;
        }

        private void CancelCommand(object sender, EventArgs e)
        {
            Response.Redirect("SetEmployeeAccountSetList.aspx", false);
        }
        private void Detail_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("EmployeeSalaryHistoryDetail.aspx?EmployeeSalaryHistoryID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }
    }
}