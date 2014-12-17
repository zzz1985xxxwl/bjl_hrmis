using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.DiyProcesses;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.DiyProcessPages
{
    public partial class AddDiyProcess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A105))
            {
                throw new ApplicationException("没有权限访问");
            }
            AddDiyProcessPresenter presenter = new AddDiyProcessPresenter(DiyProcessView1);
            presenter.InitView(IsPostBack);
            presenter.GoToListPage += ToListPage;
        }

        private void ToListPage()
        {
            Response.Redirect("../DiyProcessPages/DiyProcessList.aspx", false);
        }
    }
}
