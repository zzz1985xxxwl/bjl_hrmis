using System;
using SEP.HRMIS.Presenter.ChoseEmployee;
using SEP.HRMIS.Presenter.Train.TrainCourse;
using ShiXin.Security;
using SEP.HRMIS.Model.AccountAuth;

namespace SEP.Performance.Pages.HRMIS.TrainingPages
{
    public partial class TrainCourseUpdate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //PowerUser.UserHasPower(PowerUser._SearchCourseList);
            UpdateCoursePresenter presenter = new UpdateCoursePresenter(CourseView1, SecurityUtil.DECDecrypt(Request.QueryString["courseID"]), LoginUser);
            ChoseEmployeePresenter Mailpresenter = new ChoseEmployeePresenter(CourseView1.ChoseEmployeeView,LoginUser);
            CourseView1.ChoseEmployeeView.AccountRightViewStateName = "ChoosedEmployeeRight";
            CourseView1.ChoseEmployeeView.AccountLeftViewStateName = "ChoosedEmployeeLeft";
            CourseView1.ChooseSkillView.SkillRightSessionName = "ChoosedSkillRight";
            CourseView1.ChooseSkillView.SkillLeftSessionName = "ChoosedSkillLeft";
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
            if (Request.QueryString["courseStatus"] == null) return;
            if (!IsPostBack)
            {

                string cousreStatus = SecurityUtil.DECDecrypt(Request.QueryString["courseStatus"]);
                switch (cousreStatus)
                {
                    case ("Plan"):
                        CourseView1.TrainStatus = "0";
                        break;
                    case ("Start"):
                        CourseView1.TrainStatus = "1";
                        break;
                    case ("End"):
                        CourseView1.TrainStatus = "2";
                        break;
                    case ("Interrupt"):
                        CourseView1.TrainStatus = "3";
                        break;
                }
            }
        }
    }
}
