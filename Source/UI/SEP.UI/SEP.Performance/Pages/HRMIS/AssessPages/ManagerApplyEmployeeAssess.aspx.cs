using System;
using SEP.HRMIS.Presenter.AssessActivity;

namespace SEP.Performance.Pages.HRMIS.AssessPages
{
    public partial class ManagerApplyEmployeeAssess : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ManagerApplyEmployeeAssessPresenter managerApplyEmployeeAssess = new ManagerApplyEmployeeAssessPresenter(GetEmployeeForApplyView1, LoginUser);
            managerApplyEmployeeAssess.Initialize(IsPostBack);
        }
    }
}
