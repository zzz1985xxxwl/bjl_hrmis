using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;
using SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class EmployeeSalaryHistoryDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A604))
            {
                throw new ApplicationException("没有权限访问");
            }
            int pkid = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["EmployeeSalaryHistoryID"]));
            EmployeeSalaryHistoryDetailPresenter presenter = new EmployeeSalaryHistoryDetailPresenter(EmployeeSalaryHistoryDetailView1);
            presenter.InitView(IsPostBack, pkid);
            EmployeeSalaryHistoryDetailView1.GoToListPage += List_Command;
        }

        private void List_Command(object sender, EventArgs e)
        {
            Response.Redirect("EmployeeSalaryHistoryList.aspx?EmployeeID=" + SecurityUtil.DECEncrypt(EmployeeSalaryHistoryDetailView1.EmployeeID), false);
        }
    }
}