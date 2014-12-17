using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.EmployeeAdjustRest;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.EmployeeAdjustRestPages
{
    public partial class EmployeeAdjustRestList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A404))
            {
                throw new ApplicationException("没有权限访问");
            }
            EmployeeAdjustRestListPresenter thePresenter =
                new EmployeeAdjustRestListPresenter(EmployeeAdjustRestListView1, LoginUser);
            thePresenter.InitView(Page.IsPostBack);
            EmployeeAdjustRestListView1.BtnDetailEvent += BtnDetailEvent;
        }

        private void BtnDetailEvent(string accountID)
        {
            Response.Redirect("EmployeeAdjustRestDetail.aspx?" + ConstParameters.EmployeeId + "=" +
                              SecurityUtil.DECEncrypt(accountID));
        }
    }
}
