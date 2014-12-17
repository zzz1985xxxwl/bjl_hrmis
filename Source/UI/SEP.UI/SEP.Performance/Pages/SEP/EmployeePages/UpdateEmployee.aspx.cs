using System;
using SEP.Presenter.Employees;
using ShiXin.Security;

namespace SEP.Performance.Pages.SEP.EmployeePages
{
    public partial class UpdateEmployee : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateEmployeePresenter presenter = new UpdateEmployeePresenter(EmployeeDetailView1, LoginUser);

            presenter.GoToListPage += ToListPage;
            EmployeeDetailView1.BtnCancelEvent += ToListPage;

            if (!IsPostBack)
                EmployeeDetailView1.EmployeeID = GetAccountId();
            
            presenter.Initialize(IsPostBack);
        }

        private int GetAccountId()
        {
            string param = SecurityUtil.DECDecrypt(Request.QueryString["EmployeeID"]);

            Int32 accountId;
            if(!Int32.TryParse(param, out accountId))
                throw new ArgumentNullException();

            return accountId;
        }

        private void ToListPage()
        {
            Response.Redirect("../EmployeePages/EmployeeManage.aspx", false);
        }
    }
}
