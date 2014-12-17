using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.ChoseEmployee;
using SEP.HRMIS.Presenter.IPresenter.IChoseEmployee;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.HRMIS.TrainApplication
{
    public partial class TrainApplicationView : UserControl, ITrainApplicationView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 选择员工
            txtTrainee.Attributes.Add("onfocus", "return EmployeeHiddenBtnClick();");
            new ChoseEmployeePresenter(ChoseEmployeeView1, null);

            ChoseEmployeeView1.AttachAccountAjax += ChoseAccountAjax;
            ChoseEmployeeView1.SearchAjax += SearchEmployeeAjax;
        }

        #region ITrainApplicationView成员

        public bool SetEnable
        {
            set
            {
                txtActualET.Enabled = value;
                txtActualHour.Enabled = value;
                txtActualST.Enabled = value;
                txtCourseName.Enabled = value;
                txtExpectedCost.Enabled = value;
                txtPlace.Enabled = value;
                txtSkill.Enabled = value;
                txtTrainee.Enabled = value;
                txtTrainer.Enabled = value;
                txtTrainOrgnazation.Enabled = value;
                txtEduSupCost.Enabled = value;
                listScope.Enabled = value;
                cbCertifiacation.Enabled = value;
                btnOk.Visible = value;
                btnTemperary.Visible = value;
            }
            get { return txtActualET.Enabled; }
        }

        public bool SetApprove
        {
            get { return txtEduSupCost.Enabled; }
            set
            {
                txtEduSupCost.Enabled = value;
                btnFail.Visible = value;
                btnPass.Visible = value;
                divApproveRemark.Visible = value;
            }
        }


        private bool actionSuccess;
        //private string operationTitle;
        private string operationType;

        public string Message
        {
            get { return lblMessage.Text; }
            set
            {
                lblMessage.Text = value;
                tbMessage.Style["display"] = string.IsNullOrEmpty(value) ? "none" : "block";
            }
        }

        public string OrgnationMsg
        {
            get { return lblOrgzation.Text; }
            set { lblOrgzation.Text = value; }
        }

        public string TrainApplicationID
        {
            get { return hf_PKID.Value; }
            set { hf_PKID.Value = value; }
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


        public string Trainer
        {
            get { return txtTrainer.Text; }
            set { txtTrainer.Text = value; }
        }

        public string Orgnation
        {
            get { return txtTrainOrgnazation.Text; }
            set { txtTrainOrgnazation.Text = value; }
        }

        public string Skills
        {
            get { return txtSkill.Text; }
            set { txtSkill.Text = value; }
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
            get { return null; }
            set
            {
                listScope.Items.Clear();
                foreach (TrainScopeType type in value)
                {
                    if (type.Id == -1) continue;
                    ListItem item = new ListItem(type.Name, type.Id.ToString(), true);
                    listScope.Items.Add(item);
                }
            }
        }


        public string StartTime
        {
            get { return txtActualST.Text; }
            set { txtActualST.Text = value; }
        }

        public string EndTime
        {
            get { return txtActualET.Text; }
            set { txtActualET.Text = value; }
        }

        public string Hour
        {
            get { return txtActualHour.Text; }
            set { txtActualHour.Text = value; }
        }

        public string Cost
        {
            get { return txtExpectedCost.Text; }
            set { txtExpectedCost.Text = value; }
        }

        public string CostMsg
        {
            get { return lblExpCostMsg.Text; }
            set { lblExpCostMsg.Text = value; }
        }

        public string EduSpuCost
        {
            get { return txtEduSupCost.Text; }
            set { txtEduSupCost.Text = value; }
        }

        public string EduSpuCostMsg
        {
            get { return lblEduSupCost.Text; }
            set { lblEduSupCost.Text = value; }
        }

        public string SkillsMsg
        {
            get { return lblSkillMsg.Text; }
            set { lblSkillMsg.Text = value; }
        }

        public string STMsg
        {
            get { return lblActualSTMsg.Text; }
            set { lblActualSTMsg.Text = value; }
        }

        public string ETMsg
        {
            get { return lblActualETMsg.Text; }
            set { lblActualETMsg.Text = value; }
        }

        public string HourMsg
        {
            get { return lblActualHourMsg.Text; }
            set { lblActualHourMsg.Text = value; }
        }


        public bool HasCertifaction
        {
            get { return cbCertifiacation.Checked; }
            set { cbCertifiacation.Checked = value; }
        }

        public event DelegateNoParameter CancelButtonEvent;
        public event DelegateNoParameter TempButtonEvent;
        public event DelegateNoParameter PassButtonEvent;
        public event DelegateNoParameter FailButtonEvent;

        public string ApproveRemark
        {
            get { return txtApproveRemark.Text; }
            set { txtApproveRemark.Text = value; }
        }

        public event DelegateNoParameter ActionButtonEvent;

        protected void btnOK_Click(object sender, EventArgs e)
        {
            ActionButtonEvent();
            if (actionSuccess)
            {
                Response.Redirect("MyTrainApplication.aspx");
            }
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

        public IChoseEmployeeView ChoseEmployeeView
        {
            get { return ChoseEmployeeView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public string ApplierInfo
        {
            set { lblApplierInfo.Text = value;  }
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

        protected void btnTemperary_Click(object sender, EventArgs e)
        {
            TempButtonEvent();
            if (actionSuccess)
            {
                Response.Redirect("MyTrainApplication.aspx");
            }
        }

        #endregion

        protected void btnPass_Click(object sender, EventArgs e)
        {
            PassButtonEvent();
        }

        protected void btnFail_Click(object sender, EventArgs e)
        {
            FailButtonEvent();
        }
    }
}