using System;
using System.Web.UI;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.EmployInformation;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages
{
    public partial class EmployeeDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A401))
            {
                throw new ApplicationException("没有权限访问");
            }

            BackViewEmployeeInfoPresenter bp = new BackViewEmployeeInfoPresenter(this.EmployeeView1, SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.EmployeeId]));
            bp.InitView(Page.IsPostBack);
            //ViewEmployeePresenter ap = new ViewEmployeePresenter(EmployeeMessageDisplayView1, SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.EmployeeId]));
            //ap.InitView(SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.EmployeeId]), Page.IsPostBack);
            //ap.InitView(11.ToString(), Page.IsPostBack);
        }
    }
}
