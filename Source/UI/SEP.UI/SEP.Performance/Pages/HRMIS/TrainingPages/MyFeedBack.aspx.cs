using System;
using SEP.HRMIS.Presenter.Train.TrainCourse;

namespace SEP.Performance.Pages.HRMIS.TrainingPages
{
    public partial class MyFeedBack : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyFeedBackPresenter presenter = new MyFeedBackPresenter(MyFeedBackView1, LoginUser.Id.ToString(),LoginUser);
            presenter.SetIfFrontPage(true);
            presenter.InitView(IsPostBack);
        }
    }
}
