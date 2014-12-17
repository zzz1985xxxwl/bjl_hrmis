using System;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.Performance.Views.EmployeeInformation.ResumeInformation
{
    public partial class EmployeeResumeView : System.Web.UI.UserControl, IResumeInfoView
    {
        //add by colbert
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            EmployeeResumeBasicView1.SendEduExperiences = SendEduExperiences;
            EmployeeResumeBasicView1.SendWorkExperiences = SendWorkExperiences;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IResumeBasicInfoView ResumeBasicInfoView
        {
            get
            {
                return EmployeeResumeBasicView1;
            }
            set
            {
            }
        }

        public bool ResumeBasicInfoViewVisible
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        public IResumeEducationExperienceView ResumeEducationExperienceView
        {
            get
            {
                return EducationExperienceView1;
            }
            set
            {
            }
        }

        public bool ResumeEducationExperienceViewVisible
        {
            get
            {
                return true;
            }
            set
            {
                if (value)
                {
                    ModalPopupExtender1.Show();
                }
                else
                {
                    ModalPopupExtender1.Hide();
                }
            }
        }

        public IResumeWorkExperienceView ResumeWorkExperienceView
        {
            get
            {
                return WorkExperienceView1;
            }
            set
            {
            }
        }

        public bool ResumeWorkExperienceViewVisible
        {
            get
            {
                return true;
            }
            set
            {
                if (value)
                {
                    ModalPopupExtender2.Show();
                }
                else
                {
                    ModalPopupExtender2.Hide();
                }
            }
        }

        //add by colbert
        private void SendEduExperiences(List<EducationExperience> eduExperiences)
        {
            foreach (EducationExperience item in eduExperiences)
            {
                item.HashCode = item.GetHashCode();
            }
            EducationExperienceView1.EducationExperienceDataSource = eduExperiences;
        }

        //add by colbert
        private void SendWorkExperiences(List<WorkExperience> workExperiences)
        {
            foreach (WorkExperience item in workExperiences)
            {
                item.HashCode = item.GetHashCode();
            }
            WorkExperienceView1.WorkExperienceDataSource = workExperiences;
        }

    }
}