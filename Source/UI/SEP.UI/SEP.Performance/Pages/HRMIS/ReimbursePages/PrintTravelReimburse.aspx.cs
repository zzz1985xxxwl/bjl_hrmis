using System;
using SEP.HRMIS.Presenter.EmployeeReimburse;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class PrintTravelReimburse : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PrintReimbursePresenter printReimbursePresenter = new PrintReimbursePresenter(
                Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["ReimburseID"])),
                LoginUser, PrintTravelReimburseView1);
            printReimbursePresenter.Init(IsPostBack);
        }
    }
}
