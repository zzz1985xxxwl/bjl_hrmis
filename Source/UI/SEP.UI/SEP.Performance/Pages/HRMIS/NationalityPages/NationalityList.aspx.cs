using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.Nationalitys;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.NationalityPages
{
    public partial class NationalityList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A107))
            {
                throw new ApplicationException("没有权限访问");
            }
            NationalityPresenter thePresenter = new NationalityPresenter(NationalityInfoView1);
            thePresenter.InitView(Page.IsPostBack);
        }
    }
}
