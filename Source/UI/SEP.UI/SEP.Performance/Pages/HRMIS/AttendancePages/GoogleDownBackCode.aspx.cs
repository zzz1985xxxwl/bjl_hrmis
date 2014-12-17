using System;
using System.Collections.Generic;
using System.Web.UI;
using SEP.Presenter.Accounts;


namespace SEP.Performance.Pages.HRMIS.AttendancePages
{
    public partial class GoogleDownBackCode : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string key = Request.QueryString["key"];

            EmployeeNameLikePresenter presenter = new EmployeeNameLikePresenter();
            Response.Write(presenter.SearchLikeName(key));
            Response.End();


            //GetEmployee getEmployee = new GetEmployee();
            //List<string> names = getEmployee.GetEmployeeNamesByFisrt(key);

            //foreach (string name in names)
            //{
            //    result += name + "$";
            //}
            //result = result.TrimEnd('$');
            //Response.Write(result);
            //Response.End();
        }
    }
}
