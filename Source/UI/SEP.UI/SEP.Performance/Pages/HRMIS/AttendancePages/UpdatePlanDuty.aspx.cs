using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class UpdatePlanDuty : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A502))
            {
                throw new ApplicationException("没有权限访问");
            }
            SetPlanDutyInfoView1.LoginUser = LoginUser;
            PlanDutyUpdatePresenter setPlanDutyPresenter =
                new PlanDutyUpdatePresenter(SetPlanDutyInfoView1, LoginUser);
            setPlanDutyPresenter.InitView(IsPostBack,
                SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.PlanDutyID]));
        }
    }
}

