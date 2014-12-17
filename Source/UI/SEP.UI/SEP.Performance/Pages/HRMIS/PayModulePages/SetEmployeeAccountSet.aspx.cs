using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;
using SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet;
namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class SetEmployeeAccountSet : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A604))
            {
                throw new ApplicationException("没有权限访问");
            }
            Account account = Session[SessionKeys.LOGININFO] as Account;
            string backname = account != null ? account.Name : string.Empty;
            SetEmployeeAccountSetPresenter presenter = new SetEmployeeAccountSetPresenter(SetEmployeeAccountSet1);
            presenter.InitView(IsPostBack, Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["EmployeeID"])), backname);
            SetEmployeeAccountSet1.BtnCancelEvent += CancelCommand;
        }

        private void CancelCommand(object sender, EventArgs e)
        {
            Response.Redirect("SetEmployeeAccountSetList.aspx", false);
        }
    }
}