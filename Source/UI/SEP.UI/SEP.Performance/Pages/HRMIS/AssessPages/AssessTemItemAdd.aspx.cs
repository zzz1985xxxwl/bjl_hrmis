using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class AssessTemItemAdd : BasePage
    {
        private AddTemplateItemPresenter _Presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A701))
            {
                throw new ApplicationException("没有权限访问");
            }

            _Presenter = new AddTemplateItemPresenter(AddTemplateItemView1);
            AddTemplateItemView1.btnOkClickEvent += _Presenter.ExectEvent;
            AddTemplateItemView1.btnCancleClickEvent += _Presenter.Cancle;
            _Presenter.ToTemlateItemListPageEvent += HandleToTemlateItemListPageEvent;
            _Presenter.InitView(Page.IsPostBack);
        }

        private void HandleToTemlateItemListPageEvent(object sender, EventArgs e)
        {
            Response.Redirect("TemplateItemList.aspx", false);
        }
    }
}
