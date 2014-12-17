using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class DutyClassList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A501))
            {
                throw new ApplicationException("没有权限访问");
            }
            DutyClassInfoPresenter thePresenter = new DutyClassInfoPresenter(DutyClassInfoView1);
            thePresenter.InitView(Page.IsPostBack);
        }
    }
}
