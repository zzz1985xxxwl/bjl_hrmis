using System;
using SEP.Presenter.Departments;

namespace SEP.Performance.Pages
{
    public partial class DepartmentShow : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           new DepartmentShowListPresenter(DepartmentShowListView1, LoginUser);
        }
    }
}