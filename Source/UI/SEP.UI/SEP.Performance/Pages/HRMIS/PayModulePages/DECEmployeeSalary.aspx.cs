using System;
using SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class DECEmployeeSalary : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DECEmployeeSalaryPresenter DECEmployeeSalaryPresenter =
                new DECEmployeeSalaryPresenter(DECEmployeeSalaryView1);
            DECEmployeeSalaryPresenter.InitPresent(IsPostBack);
        }
    }
}
