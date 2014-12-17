using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IChoseEmployee;
using SEP.HRMIS.Presenter.IPresenter.ITrain.TrainCourse;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.HRMIS.Train
{
    public partial class CourseView : UserControl, ICourseView
    {
        //private readonly int _All = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodinator.Attributes.Add("onkeyup", "return addTest(event);");
            txtCodinator.Attributes.Add("onkeydown", "return keydowndeal(event);");

            // 选择员工
            txtTrainee.Attributes.Add("onfocus", "return EmployeeHiddenBtnClick();");
            //ChoseEmployeePresenter Mailpresenter = new ChoseEmployeePresenter(ChoseEmployeeView1);
            ChoseEmployeeView1.AttachAccountAjax += ChoseAccountAjax;
            ChoseEmployeeView1.SearchAjax += SearchEmployeeAjax;


            //选择技能
            txtSkill.Attributes.Add("onfocus", "return SkillHiddenBtnClick();");
            //ChooseSkillPresenter Skillpresenter = new ChooseSkillPresenter(ChooseSkillView1);
            ChooseSkillView1.AttachSkillAjax += ChoseSkillAjax;
            ChooseSkillView1.SearchAjax += SearchSkillAjax;



        }

        #region ICourseView成员

        private bool actionSuccess;
        //private string operationTitle;
        private string operationType;

        public string Message
        {
            get { return lblMessage.Text; }
            set
            {
                lblMessage.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
            }
        }

        public string CourseName
        {
            get { return txtCourseName.Text; }
            set { txtCourseName.Text = value; }
        }

        public string CourseNameMsg
        {
            get { return lblCourseNameMsg.Text; }
            set { lblCourseNameMsg.Text = value; }
        }

        public string Place
        {
            get { return txtPlace.Text; }
            set { txtPlace.Text = value; }
        }

        public string PlaceMsg
        {
            get { return lblPlaceMsg.Text; }
            set { lblPlaceMsg.Text = value; }
        }

        public string Coordinator
        {
            get { return txtCodinator.Text; }
            set { txtCodinator.Text = value; }
        }

        public string CoordinatorMsg
        {
            get { return lblCodinatorMsg.Text; }
            set { lblCodinatorMsg.Text = value; }
        }

        public string Trainer
        {
            get { return txtTrainer.Text; }
            set { txtTrainer.Text = value; }
        }

        public string TrainersMsg
        {
            get { return lblTrainerMsg.Text; }
            set { lblTrainerMsg.Text = value; }
        }


        public string TrainScope
        {
            get { return listScope.SelectedValue; }
            set { listScope.SelectedValue = value; }
        }



        public List<TrainScopeType> ScopeSource
        {
            get
            { return null; }
            set
            {
                listScope.Items.Clear();
                foreach (TrainScopeType type in value)
                {
                    if (type.Id != -1)
                    {
                        ListItem item = new ListItem(type.Name, type.Id.ToString(), true);
                        listScope.Items.Add(item);
                    }
                }
            }
        }




        public List<TrainStatusType> StatusSource
        {

            get
            { return null; }
            set
            {
                listStatus.Items.Clear();
                foreach (TrainStatusType type in value)
                {
                    if (type.Id != -1)
                    {
                        ListItem item = new ListItem(type.Name, type.Id.ToString(), true);
                        listStatus.Items.Add(item);
                    }
                }
            }
        }

        public List<FeedBackPaper> FeedBackPaperSource
        {
            set
            {
                listPaper.Items.Clear();
                listPaper.Items.Add(new ListItem(string.Empty, "-1", true));
                foreach (FeedBackPaper paper in value)
                {
                    if (paper.FeedBackPaperId != -1)
                    {
                        ListItem item = new ListItem(paper.FeedBackPaperName, paper.FeedBackPaperId.ToString(), true);
                        listPaper.Items.Add(item);
                    }
                }
            }
        }

        public int PaperId
        {
            get { return Convert.ToInt32(listPaper.SelectedValue); }
            set { listPaper.SelectedValue = value.ToString(); }
        }

        public string TrainStatus
        {
            get { return listStatus.SelectedValue; }
            set { listStatus.SelectedValue = value; }
        }

        public string ExpectST
        {
            get { return txtExpectedST.Text; }
            set { txtExpectedST.Text = value; }
        }

        public string ExpectET
        {
            get { return txtExpectedET.Text; }
            set { txtExpectedET.Text = value; }
        }

        public string ActualST
        {
            get { return txtActualST.Text; }
            set { txtActualST.Text = value; }
        }

        public string ActualET
        {
            get { return txtActualET.Text; }
            set { txtActualET.Text = value; }
        }

        public string ExpectHour
        {
            get { return txtExpectedHour.Text; }
            set { txtExpectedHour.Text = value; }
        }

        public string ExpectHourMsg
        {
            get { return lblExpHourMsg.Text; }
            set { lblExpHourMsg.Text = value; }
        }

        public string ActualHour
        {
            get { return txtActualHour.Text; }
            set { txtActualHour.Text = value; }
        }

        public string ExpectCost
        {
            get { return txtExpectedCost.Text; }
            set { txtExpectedCost.Text = value; }
        }

        public string ExpectCostMsg
        {
            get { return lblExpCostMsg.Text; }
            set { lblExpCostMsg.Text = value; }
        }

        public string ExpectSTMsg
        {
            get { return lblExpectedSTMsg.Text; }
            set { lblExpectedSTMsg.Text = value; }
        }

        public string ExpectETMsg
        {
            get { return lblExpectedETMsg.Text; }
            set { lblExpectedETMsg.Text = value; }
        }

        public string ActualSTMsg
        {
            get { return lblActualSTMsg.Text; }
            set { lblActualSTMsg.Text = value; }
        }

        public string ActualETMsg
        {
            get { return lblActualETMsg.Text; }
            set { lblActualETMsg.Text = value; }
        }

        public string ActualHourMsg
        {
            get { return lblActualHourMsg.Text; }
            set { lblActualHourMsg.Text = value; }
        }

        public string ActualCostMsg
        {
            get { return lblActualCostMsg.Text; }
            set { lblActualCostMsg.Text = value; }
        }

        public string ActualCost
        {
            get { return txtActualCost.Text; }
            set { txtActualCost.Text = value; }
        }

        public bool HasCertifaction
        {
            get { return cbCertifiacation.Checked; }
            set { cbCertifiacation.Checked = value; }
        }


        public event DelegateNoParameter ActionButtonEvent;
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ActionButtonEvent();
            if (actionSuccess)
            {
                Response.Redirect("SearchTrainCourseBack.aspx");
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchTrainCourseBack.aspx");
        }

        protected void btnOKFront_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyFeedBack.aspx");
        }

        protected void btnCancelFront_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyFeedBack.aspx");
        }

        public bool ActionSuccess
        {
            get { return actionSuccess; }
            set { actionSuccess = value; }
        }

        public string OperationTitle
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        public string OperationType
        {
            get { return operationType; }
            set { operationType = value; }
        }

        private bool _SetBtnhiden;

        public bool SetBtnhiden
        {
            get { return _SetBtnhiden; }
            set
            {
                _SetBtnhiden = value;
                if (_SetBtnhiden)
                {
                    FrontBtn.Style["display"] = "none";
                    Backbtn.Style["display"] = "block";
                }
                else
                {
                    FrontBtn.Style["display"] = "block";
                    Backbtn.Style["display"] = "none";
                }
            }
        }


        public IChooseSkillView ChooseSkillView
        {
            get { return ChooseSkillView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public IChoseEmployeeView ChoseEmployeeView
        {
            get { return ChoseEmployeeView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public string SkillDisplay
        {
            set { lblSkillDisplay.Text = value; }
        }

        #region 员工
        public string EmployeeMsg
        {
            get { return lblTraineeMsg.Text; }
            set { lblTraineeMsg.Text = value; }
        }

        public string ChoosedEmployees
        {
            get { return txtTrainee.Text.Trim(); }
            set { txtTrainee.Text = value; }
        }
        protected void ChoseAccountAjax(object sender, EventArgs e)
        {
            ChoosedEmployees = RequestUtility.GetEmployeeNames(ChoseEmployeeView1.AccountRight);
            mpeEmployeeList.Show();
        }
        protected void SearchEmployeeAjax(object sender, EventArgs e)
        {
            mpeEmployeeList.Show();
        }

        public List<Account> EmployeeList
        {
            get { return ChoseEmployeeView1.AccountRight; }
            set { ChoseEmployeeView1.AccountRight = value; }
        }

        #endregion

        #region 技能

        public string SkillsMsg
        {
            get { return lblSkillMsg.Text; }
            set { lblSkillMsg.Text = value; }
        }

        public string ChoosedSkills
        {
            get { return txtSkill.Text.Trim(); }
            set { txtSkill.Text = value; }
        }

        protected void ChoseSkillAjax(object sender, EventArgs e)
        {
            ChoosedSkills = GetSkillNames(ChooseSkillView1.SkillRight);
            mpeSkillList.Show();
        }

        public static string GetSkillNames(List<hrmisModel.Skill> skillList)
        {

            StringBuilder skills = new StringBuilder();
            if (skillList != null)
            {
                int count = skillList.Count;
                for (int i = 0; i < count; i++)
                {
                    skills.Append(skillList[i].SkillName);
                    if (i < count - 1) skills.Append("，");
                }
            }
            return skills.ToString();
        }

        protected void SearchSkillAjax(object sender, EventArgs e)
        {
            mpeSkillList.Show();
        }
        public List<hrmisModel.Skill> SkillList
        {
            get { return ChooseSkillView1.SkillRight; }
            set
            {
                ChooseSkillView1.SkillRightSessionName = "ChoosedSkillRight";
                ChooseSkillView1.SkillRight = value;

            }
        }
        #endregion

        #endregion
    }
}