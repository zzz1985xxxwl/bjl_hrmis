using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Performance.Pages;


namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class PlanDutyList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A502))
            {
                throw new ApplicationException("没有权限访问");
            }
            PlanDutyListPresenter planDutyListPresenter = new PlanDutyListPresenter(PlanDutyListView1,LoginUser);

            planDutyListPresenter.Initialize(IsPostBack);
        }
    }
}