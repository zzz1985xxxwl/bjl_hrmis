using System;
using System.Web.UI;
using SEP.Presenter.Employees;
using ShiXin.Security;

namespace SEP.Performance.Pages.SEP.EmployeePages
{
    public partial class EmployeeManage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EmployeeDatagridListPresenter presenter = new EmployeeDatagridListPresenter(EmployeeDatagridListView1, LoginUser);
            presenter.Initialize(IsPostBack);
            EmployeeDatagridListView1.BtnUpdateEvent += Update_Command;
            EmployeeDatagridListView1.BtnAddEvent += ToCreateEmployeePage;
        }
        private void ToCreateEmployeePage()
        {
            Response.Redirect("../EmployeePages/CreateEmployee.aspx", false);
        }
        private void Update_Command(string id)
        {
            Response.Redirect("../EmployeePages/UpdateEmployee.aspx?EmployeeID=" + SecurityUtil.DECEncrypt(id), false);
        }
    }
}
