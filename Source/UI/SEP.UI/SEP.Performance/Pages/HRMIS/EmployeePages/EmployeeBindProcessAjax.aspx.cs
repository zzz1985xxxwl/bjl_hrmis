using System;
using System.Web.UI;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Presenter;

namespace SEP.Performance.Pages.HRMIS.EmployeePages
{
    public partial class EmployeeBindProcessAjax : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IDiyProcessFacade _DiyProcessFacade = InstanceFactory.CreateDiyProcessFacade();
            string ans = _DiyProcessFacade.GetDiyProcessStepString(Convert.ToInt32(Request.QueryString["AccountID"]),
                                                      Convert.ToInt32(Request.QueryString["DiyProcessID"]));
            Response.Write(ans);
            Response.End();
        }
    }
}