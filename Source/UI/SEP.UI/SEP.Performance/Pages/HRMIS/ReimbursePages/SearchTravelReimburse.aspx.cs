using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.EmployeeReimburse;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.ReimbursePages
{
    public partial class SearchTravelReimburse : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A902))
            {
                throw new ApplicationException("没有权限访问");
            }
            if (Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A904) ||
                Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A109))
            {
                SearchTravelReimburseView1.IsAutoCompleteCoutomer = true;
            }
            else
            {
                SearchTravelReimburseView1.IsAutoCompleteCoutomer = false;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            SearchTravelReimbursePresenter presenter =
                new SearchTravelReimbursePresenter(SearchTravelReimburseView1, LoginUser);
            presenter.Initialize(IsPostBack);
        }
    }
}