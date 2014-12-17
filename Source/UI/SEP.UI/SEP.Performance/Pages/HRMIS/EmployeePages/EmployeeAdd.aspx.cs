using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.EmployInformation;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Performance.Views;

namespace SEP.Performance.Pages
{
    public partial class EmployeeAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A401))
            {
                throw new ApplicationException("没有权限访问");
            }

            AddEmployeeInfoPresenter ap = new AddEmployeeInfoPresenter(EmployeeView1,LoginUser);
            ap.InitView(Page.IsPostBack);
            EmployeeView1.BackAccountsID = LoginUser.Id.ToString();
            //ap = new AddEmployeePresenter(EmployeeMessageDisplayView1);
            //EmployeeMessageDisplayView1.btnConfrimEvent=ap.AddEmployeeEvent;
            //ap.InitView(Page.IsPostBack);
        }
    }
}
