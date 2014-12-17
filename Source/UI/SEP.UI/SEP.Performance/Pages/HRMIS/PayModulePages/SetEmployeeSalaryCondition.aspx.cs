using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class SetEmployeeSalaryCondition : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A606))
            {
                throw new ApplicationException("没有权限访问");
            }

            SetEmployeeSalaryConditionPresenter setEmployeeSalaryConditionPresenter =
                new SetEmployeeSalaryConditionPresenter(SetEmployeeSalaryConditionView1, LoginUser);
            setEmployeeSalaryConditionPresenter.GoToSetEmployeeSalaryPage += GoToSetEmployeeSalaryPage;
            setEmployeeSalaryConditionPresenter.InitView(IsPostBack);
        }

        private void GoToSetEmployeeSalaryPage(object sender, EventArgs e)
        {
            Response.Redirect(SetEmployeeSalaryConditionView1.SetEmployeeSalaryPageURL);
        }
    }
}