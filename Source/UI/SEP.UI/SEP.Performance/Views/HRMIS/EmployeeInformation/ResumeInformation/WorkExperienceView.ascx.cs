using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.EmployeeInformation.ResumeInformation
{
    public partial class WorkExperienceView : System.Web.UI.UserControl, IResumeWorkExperienceView
    {
        private bool _ActionSuccess;
        public event DelegateNoParameter BtnActionEvent;
        public event DelegateNoParameter BtnCancelEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancle.Attributes["onclick"] = "return CloseModalPopupExtender('divMPE1');";
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            BtnActionEvent();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BtnCancelEvent();
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

        public string Company
        {
            get
            {
                return txtcompany.Text;
            }
            set
            {
                txtcompany.Text = value;
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

        public string Content
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

        public string ContactPerson
        {
            get
            {
                return txtcontactperson.Text;
            }
            set
            {
                txtcontactperson.Text = value;
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

        public string CompanyMessage
        {
            get
            {
                return msgcompany.Text;
            }
            set
            {
                msgcompany.Text = value;
            }
        }

        public string ExperiencePeriodMessage
        {
            get
            {
                return msgPeriod.Text;
            }
            set
            {
                msgPeriod.Text = value;
            }
        }

        public string ContentMessage
        {
            get
            {
                return msgcontent.Text;
            }
            set
            {
                msgcontent.Text = value;
            }
        }

        public List<WorkExperience> WorkExperienceDataSource
        {
            get
            {
                //Session changed to ViewState modify by colbert
                //return Session["WorkExperience"] as List<WorkExperience>;
                return ViewState["WorkExperience"] as List<WorkExperience>;
            }
            set
            {
                //Session changed to ViewState modify by colbert
                //Session["WorkExperience"] = value;
                ViewState["WorkExperience"] = value;
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
    }
}