using System;
using SEP.Presenter.Employees;

namespace SEP.Performance.Pages.SEP.EmployeePages
{
    public partial class CreateEmployee : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CreateEmployeePresenter presenter = new CreateEmployeePresenter(EmployeeDetailView1, LoginUser);
            
            presenter.Initialize(IsPostBack);

            presenter.GoToListPage += ToListPage;
            EmployeeDetailView1.BtnCancelEvent += ToListPage;
        }
        private void ToListPage()
        {
            Response.Redirect("../EmployeePages/EmployeeManage.aspx", false);
        }
    }
}
