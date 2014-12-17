using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.EmployeeInformation.ResumeInformation
{
    public partial class EducationExperienceView : System.Web.UI.UserControl, IResumeEducationExperienceView
    {
        private bool _ActionSuccess;
        public event DelegateNoParameter BtnActionEvent;
        public event DelegateNoParameter BtnCancelEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancle.Attributes["onclick"] = "return CloseModalPopupExtender('divMPE');";
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            BtnActionEvent();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BtnCancelEvent();
        }

        public string School
        {
            get
            {
                return txtSchool.Text;
            }
            set
            {
                txtSchool.Text = value;
            }
        }

        public string ExperiencePeriod
        {
            get
            {
                return txtPeriod.Text;
            }
            set
            {
                txtPeriod.Text = value;

            }
        }

        public string Contect
        {
            get
            {
                return txtContent.Text;
            }
            set
            {
                txtContent.Text = value;
            }
        }

        public string Remark
        {
            get
            {
                return txtremark.Text;
            }
            set
            {
                txtremark.Text = value;
            }
        }

        public string Message
        {
            get
            {
                return lblMessage.Text;
            }
            set
            {
                lblMessage.Text = value;

            }
        }

        public string SchoolMessage
        {
            get { return msgSchool.Text; }
            set { msgSchool.Text = value; }
        }

        public string ExperiencePeriodMessage
        {
            get { return msgPeriod.Text; }
            set { msgPeriod.Text = value; }
        }

        public string ContectMessage
        {
            get { return msgcontent.Text; }
            set { msgcontent.Text = value; }
        }

        public List<EducationExperience> EducationExperienceDataSource
        {
            get
            {
                //Session changed to ViewState modify by colbert
                //return Session["EducationExperience"] as List<EducationExperience>;
                return ViewState["EducationExperience"] as List<EducationExperience>;
            }
            set
            {
                //Session changed to ViewState modify by colbert
                //Session["EducationExperience"] = value;
                ViewState["EducationExperience"] = value;
            }
        }

        public bool ActionSuccess
        {
            get
            {
                return _ActionSuccess;
            }
            set
            {
                _ActionSuccess = value;
            }
        }

        public string Id
        {
            get
            {
                return lblId.Text;
            }
            set
            {
                lblId.Text = value;
            }
        }

    }
}