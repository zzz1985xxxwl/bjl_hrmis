using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.LeaveRequestTypes;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.LeaveRequestTypePages
{
    public partial class LeaveRequestTypeList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A102))
            {
                throw new ApplicationException("没有权限访问");
            }
            LeaveRequestTypePresenter thePresenter = new LeaveRequestTypePresenter(LeaveRequestTypeInfoView1);
            thePresenter.InitView(Page.IsPostBack);
        }
    }
}