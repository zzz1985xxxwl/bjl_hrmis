using System;
using SEP.HRMIS.Presenter.Train.TrainCourse;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.TrainingPages
{
    public partial class TrainCourseDetailFront : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CourseDetailPresenter presenter = new CourseDetailPresenter
                (CourseView1, SecurityUtil.DECDecrypt(Request.QueryString["courseID"]));
            CourseView1.ChoseEmployeeView.AccountRightViewStateName = "ChoosedEmployeeRight";
            CourseView1.ChoseEmployeeView.AccountLeftViewStateName = "ChoosedEmployeeLeft";
            CourseView1.ChooseSkillView.SkillRightSessionName = "ChoosedSkillRight";
            CourseView1.ChooseSkillView.SkillLeftSessionName = "ChoosedSkillLeft";
            presenter.InitView(Page.IsPostBack, true);
        }
    }
}
