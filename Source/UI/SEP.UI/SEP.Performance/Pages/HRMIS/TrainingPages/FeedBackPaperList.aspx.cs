using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;
using SEP.HRMIS.Presenter.Train;

namespace SEP.Performance.Pages.HRMIS.TrainingPages
{
    public partial class FeedBackPaperList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A805))
            {
                throw new ApplicationException("没有权限访问");
            }

            FeedBackPaperListPresenter presenter = new FeedBackPaperListPresenter(FeedBackPaperListView1, LoginUser);
            presenter.btnAddClick += btnAdd_Click;
            presenter.btnUpdateClick += btnUpdate_Click;
            presenter.btnDeleteClick += btnDelete_Click;
            presenter.btnDetailClick += btnDetail_Click;
            presenter.Initialize(Page.IsPostBack);
        }

        private void btnAdd_Click()
        {
            Response.Redirect("FeedBackPaperAdd.aspx", false);
        }
        private void btnUpdate_Click(string id)
        {
            Response.Redirect("FeedBackPaperUpdate.aspx?PaperID=" + SecurityUtil.DECEncrypt(id), false);
        }
        private void btnDelete_Click(string id)
        {
            Response.Redirect("FeedBackPaperDelete.aspx?PaperID=" + SecurityUtil.DECEncrypt(id), false);
        }
        private void btnDetail_Click(string id)
        {
            Response.Redirect("FeedBackPaperDetail.aspx?PaperID=" + SecurityUtil.DECEncrypt(id), false);
        }
    }
}
