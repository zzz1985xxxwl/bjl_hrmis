using System;
using SEP.HRMIS.Presenter.Train.TrainCourse;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.TrainingPages
{
    public partial class CourseFeedBackList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!PowerUser.IsUserHasPower(PowerUser._SearchCourseList))
            //{
            //    throw new Exception("没有权限访问");
            //}
            CourseFeedBackListPresenter presenter = new CourseFeedBackListPresenter(FeedBackBackSearchView1, SecurityUtil.DECDecrypt(Request.QueryString["courseID"]), LoginUser);
            FeedBackBackSearchView1.SearchEvent += presenter.SearchEvent;
            presenter.SetIfFrontPage(false);
            presenter.InitView(IsPostBack);
        }
    }
}
