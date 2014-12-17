using System;
using SEP.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;
using SEP.HRMIS.Presenter.Parameter.CustomerInfos;

namespace SEP.Performance.Pages.HRMIS.CustomerInfoPages
{
    public partial class CustomerInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A109))
            {
                throw new ApplicationException("û��Ȩ�޷���");
            }
            CustomerInfoPresenter prestenter = new CustomerInfoPresenter(CustomerInfoAllView1);
            prestenter.InitView(Page.IsPostBack);
        }
    }
}
