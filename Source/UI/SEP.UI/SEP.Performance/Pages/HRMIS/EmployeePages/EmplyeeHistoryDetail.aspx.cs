using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages
{
    public partial class EmplyeeHistoryDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A401))
            {
                throw new ApplicationException("没有权限访问");
            }

            EmployeeHistoryPresenter presenter = new EmployeeHistoryPresenter(EmployeeHistoryView1, SecurityUtil.DECDecrypt(Request.QueryString["EmployeeHistoryID"]));
            presenter.InitView(IsPostBack);
        }
    }
}
