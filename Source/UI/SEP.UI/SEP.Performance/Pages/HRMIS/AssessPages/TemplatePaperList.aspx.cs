using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;


namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class TemplatePaperList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A702))
            {
                throw new ApplicationException("没有权限访问");
            }

            TemplatePaperListPresenter presenter = new TemplatePaperListPresenter(TemplatePaperListView1, LoginUser);
            presenter.btnAddClick += btnAdd_Click;
            presenter.btnUpdateClick += btnUpdate_Click;
            presenter.btnDeleteClick += btnDelete_Click;
            presenter.btnDetailClick += btnDetail_Click;
            presenter.Initialize(Page.IsPostBack);
        }

        private void btnAdd_Click()
        {
            Response.Redirect("TemplatePaperAdd.aspx", false);
        }
        private void btnUpdate_Click(string id)
        {
            Response.Redirect("TemplatePaperUpdate.aspx?TemplatePaperID=" + SecurityUtil.DECEncrypt(id), false);
        }
        private void btnDelete_Click(string id)
        {
            Response.Redirect("TemplatePaperDelete.aspx?TemplatePaperID=" + SecurityUtil.DECEncrypt(id), false);
        }
        private void btnDetail_Click(string id)
        {
            Response.Redirect("TemplatePaperDetail.aspx?TemplatePaperID=" + SecurityUtil.DECEncrypt(id), false);
        }
    }
}
