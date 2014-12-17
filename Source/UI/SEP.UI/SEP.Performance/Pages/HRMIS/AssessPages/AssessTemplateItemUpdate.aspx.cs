using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class AssessTemplateItemUpdate : BasePage
    {
        private UpdateTemplateItemPresenter _Presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A701))
            {
                throw new ApplicationException("没有权限访问");
            }
          
            _Presenter = new UpdateTemplateItemPresenter(AddTemplateItemView1);
            AddTemplateItemView1.btnOkClickEvent += _Presenter.ExectEvent;
            AddTemplateItemView1.btnCancleClickEvent += _Presenter.Cancle;
            _Presenter.ToTemlateItemListPageEvent += HandleToTemlateItemListPageEvent;
            _Presenter.InitView(Page.IsPostBack, SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.ItemID]));
        }

        private void HandleToTemlateItemListPageEvent(object sender, EventArgs e)
        {
            Response.Redirect("TemplateItemList.aspx", false);
        }
    }
}
