using System;
using SEP.HRMIS.Presenter.EmployeeReimburse;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class PrintReimburse : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PrintReimbursePresenter printReimbursePresenter = new PrintReimbursePresenter(
                Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["ReimburseID"])),
                LoginUser, PrintReimburseView1);
            printReimbursePresenter.Init(IsPostBack);

        }
    }
}
