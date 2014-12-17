using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.DiyProcesses;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.DiyProcessPages
{
    public partial class DiyProcessList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A105))
            {
                throw new ApplicationException("没有权限访问");
            }

            DiyProcessListPresenter presenter = new DiyProcessListPresenter(DiyProcessListView1);
            presenter.InitView(IsPostBack);
            presenter.GoToAddPage += ToAddPage;
            presenter.GoToDeletePage += ToDeletePage;
            presenter.GoToDetailPage += ToDetailPage;
            presenter.GoToUpdatePage += ToUpdatePage;
        }

        private void ToAddPage()
        {
            Response.Redirect("../DiyProcessPages/AddDiyProcess.aspx", false);
        }

        private void ToDeletePage(string id)
        {
            Response.Redirect("../DiyProcessPages/DeleteDiyProcess.aspx?DiyProcessID=" + SecurityUtil.DECEncrypt(id), false);
        }

        private void ToDetailPage(string id)
        {
            Response.Redirect("../DiyProcessPages/DiyProcessDetail.aspx?DiyProcessID=" + SecurityUtil.DECEncrypt(id), false);
        }

        private void ToUpdatePage(string id)
        {
            Response.Redirect("../DiyProcessPages/UpdateDiyProcess.aspx?DiyProcessID=" + SecurityUtil.DECEncrypt(id), false);
        }
    }
}
