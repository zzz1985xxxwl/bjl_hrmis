using System;
using System.Collections.Generic;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.Performance.Views.SEP.WorkTasks
{
    public partial class NavigateView : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Account _Operator = Session[SessionKeys.LOGININFO] as Account;
            List<Department> depts =
                BllInstance.DepartmentBllInstance.GetDepartmentAndChildrenDeptByLeaderID(_Operator.Id);
            if(depts.Count>0)
            {
                divTeamTask.Style["display"] = "block";
            }
            else
            {
                divTeamTask.Style["display"] = "none";
            }
        }
    }
}