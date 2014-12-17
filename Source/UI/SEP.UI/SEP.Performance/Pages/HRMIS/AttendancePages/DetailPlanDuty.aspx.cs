using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class DetailPlanDuty : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A502))
            {
                throw new ApplicationException("û��Ȩ�޷���");
            }
            SetPlanDutyInfoView1.LoginUser = LoginUser;
            PlanDutyDetailPresenter setPlanDutyPresenter =
                new PlanDutyDetailPresenter(SetPlanDutyInfoView1, LoginUser);
            setPlanDutyPresenter.InitView(IsPostBack, 
                SecurityUtil.DECDecrypt(Request.QueryString[ConstParameters.PlanDutyID]));
        }
    }
}

