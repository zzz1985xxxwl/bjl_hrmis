using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.DiyProcesses;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.DiyProcessPages
{
    public partial class DeleteDiyProcess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A105))
            {
                throw new ApplicationException("没有权限访问");
            }
            DeteleDiyProcessPresenter presenter = new DeteleDiyProcessPresenter(DiyProcessView1);
            presenter.DiyProcessID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["DiyProcessID"]));
            presenter.InitView(IsPostBack);
            presenter.GoToListPage += ToListPage;
        }

        private void ToListPage()
        {
            Response.Redirect("../DiyProcessPages/DiyProcessList.aspx", false);
        }
    }
}
