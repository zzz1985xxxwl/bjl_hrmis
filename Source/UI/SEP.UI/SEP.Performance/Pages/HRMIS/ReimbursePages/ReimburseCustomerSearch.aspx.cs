using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.EmployeeReimburse;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class ReimburseCustomerSearch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A904))
            {
                throw new ApplicationException("没有权限访问");
            }

            ReimburseCustomerSearchPresenter presenter = new ReimburseCustomerSearchPresenter(ReimburseCustomerSearchView1, LoginUser);
            presenter.Initialize(IsPostBack);
        }
    }
}
