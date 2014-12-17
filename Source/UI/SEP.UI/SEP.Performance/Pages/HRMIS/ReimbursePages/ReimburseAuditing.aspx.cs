using System;
using SEP.HRMIS.Presenter.EmployeeReimburse.Reimburse;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class ReimburseAuditing : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReimburseAuditingPresenter auditingPresenter = new ReimburseAuditingPresenter(
                Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["ReimburseID"])), LoginUser,
                EmployeeReimburseView1);
            auditingPresenter.Init(IsPostBack);
        }
    }
}
