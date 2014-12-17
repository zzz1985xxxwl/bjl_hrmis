using System;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.Train.TrainCourse;
using SEP.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Pages.HRMIS.TrainingPages
{
    public partial class FeedBackSearch : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A802))
            {
                throw new ApplicationException("没有权限访问");
            }
            FeedBackBackSearchPresenter presenter = new FeedBackBackSearchPresenter(FeedBackBackSearchView1, LoginUser);
            FeedBackBackSearchView1.SearchEvent += presenter.SearchEvent;
            presenter.SetIfFrontPage(false);
            presenter.InitView(IsPostBack);
        }
    }
}
