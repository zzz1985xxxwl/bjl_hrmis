using System;
using SEP.HRMIS.Presenter.ChoseEmployee;
using SEP.HRMIS.Presenter.Train.TrainCourse;
using SEP.HRMIS.Model.AccountAuth;
using ShiXin.Security;

namespace SEP.Performance.Pages.HRMIS.TrainingPages
{
    public partial class AddTrainCourse : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //PowerUser.UserHasPower(PowerUser._SearchCourseList);
            AddCoursePresenter presenter = new AddCoursePresenter(CourseView1,LoginUser);
            CourseView1.ChoseEmployeeView.AccountRightViewStateName = "ChoosedEmployeeRight";
            CourseView1.ChoseEmployeeView.AccountLeftViewStateName = "ChoosedEmployeeLeft";
            CourseView1.ChooseSkillView.SkillRightSessionName = "ChoosedSkillRight";
            CourseView1.ChooseSkillView.SkillLeftSessionName = "ChoosedSkillLeft";
            ChoseEmployeePresenter Mailpresenter = new ChoseEmployeePresenter(CourseView1.ChoseEmployeeView,LoginUser);
            Mailpresenter.PowerID = HrmisPowers.A801;
            if (!IsPostBack)
            {
                Mailpresenter.Init(this, EventArgs.Empty);
            }
            ChooseSkillPresenter Skillpresenter = new ChooseSkillPresenter(CourseView1.ChooseSkillView);
            if (!IsPostBack)
            {
                Skillpresenter.Init(this, EventArgs.Empty);
            }

            presenter.InitView(Page.IsPostBack, false);
            if (!IsPostBack)
            {
            if(Request.QueryString["ApplicationId"]!=null)
            {
                presenter.SetApplicationBind(SecurityUtil.DECDecrypt(Request.QueryString["ApplicationId"]));
            }
            }
        }
    }
}
