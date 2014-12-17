using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.Model.Accounts;
using SEP.Model;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class EmployeeWelfareList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A605))
            {
                throw new ApplicationException("没有权限访问");
            }
            new EmployeeWelfareSearchListPresenter(EmployeeWelfareSearchList1,LoginUser,IsPostBack);
        }
    }
}