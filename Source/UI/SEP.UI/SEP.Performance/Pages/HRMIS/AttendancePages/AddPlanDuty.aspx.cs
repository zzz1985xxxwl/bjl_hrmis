using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.AttendanceStatistics.PlanDutyPresenter;
using SEP.IBll;
using SEP.Model;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class AddPlanDuty : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A502))
            {
                throw new ApplicationException("没有权限访问");
            }
            SetPlanDutyInfoView1.LoginUser = LoginUser;
            PlanDutyAddPresenter setPlanDutyPresenter =
                new PlanDutyAddPresenter(SetPlanDutyInfoView1, LoginUser);
            setPlanDutyPresenter.InitView(IsPostBack, DateTime.Now);
            if (!string.IsNullOrEmpty(Request.QueryString["employeeID"]) && !IsPostBack)
            {
                Account account =
                    BllInstance.AccountBllInstance.GetAccountById(
                        Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["employeeID"])));
                List<Account> accountlist = new List<Account>();
                accountlist.Add(account);
                SetPlanDutyInfoView1.EmployeeList = accountlist;
                SetPlanDutyInfoView1.SetPlanDutyView.EmployeeList = RequestUtility.GetEmployeeNames(accountlist);
            }
        }
    }
}
