using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class TemplateItemList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A701))
            {
                throw new ApplicationException("没有权限访问");
            }

            TemplateItemListPresenter presenter = new TemplateItemListPresenter(TemplateItemListView1);
            TemplateItemListView1.ItemDeleteEvent = presenter.DeleteEvent;
            TemplateItemListView1.btnSearchClick = presenter.ExecuteEvent;
            presenter._ToTemplateItemAddPage += ToTemplateItemAddPage;
            presenter.InitViewList(Page.IsPostBack);
        }

        private void ToTemplateItemAddPage(object sender, EventArgs e)
        {
            Response.Redirect("AssessTemItemAdd.aspx");
        }
    }
}
