using System;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages
{
    public partial class EmplyeeHistoryList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A401))
            {
                throw new ApplicationException("没有权限访问");
            }

            EmployeeHistoryListPresenter ap = new EmployeeHistoryListPresenter(EmployeeHistoryListView1, SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.EmployeeId]));
            ap.btnViewClick += View_Command;
            ap.Init(Page.IsPostBack);
        }

        private void View_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("EmplyeeHistoryDetail.aspx?EmployeeHistoryID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }
    }
}
