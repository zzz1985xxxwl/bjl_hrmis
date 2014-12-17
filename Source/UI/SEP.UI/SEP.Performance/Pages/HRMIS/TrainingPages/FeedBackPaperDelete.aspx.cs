using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.HRMIS.Presenter.Train;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.TrainingPages
{
    public partial class FeedBackPaperDelete : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A805))
            {
                throw new ApplicationException("没有权限访问");
            }

            FeedBackPaperDeletePresenter presenter = new FeedBackPaperDeletePresenter(Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["PaperID"])), FeedBackPaperView1, LoginUser);
            presenter.CancelEvent += ToAccountSetListPage;
            presenter.ToAccountSetListPage += ToAccountSetListPage;
            presenter.Initialize(IsPostBack);
        }

        private void ToAccountSetListPage()
        {
            Response.Redirect("FeedBackPaperList.aspx", false);
        }
    }
}
