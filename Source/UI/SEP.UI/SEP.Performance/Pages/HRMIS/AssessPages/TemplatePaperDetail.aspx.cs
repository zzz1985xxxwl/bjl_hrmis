using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.AssessManagement;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class TemplatePaperDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A702))
            {
                throw new ApplicationException("没有权限访问");
            }

            TemplatePaperDetailPresenter presenter =
                new TemplatePaperDetailPresenter(
                    Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["TemplatePaperID"])), TemplatePaperView1,
                    LoginUser);
            presenter.CancelEvent += ToAccountSetListPage;
            presenter.Initialize(IsPostBack);
        }

        private void ToAccountSetListPage()
        {
            Response.Redirect("TemplatePaperList.aspx", false);
        }
    }
}
