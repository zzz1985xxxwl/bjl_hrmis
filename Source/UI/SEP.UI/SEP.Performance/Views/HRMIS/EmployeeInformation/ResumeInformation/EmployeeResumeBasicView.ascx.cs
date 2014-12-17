//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeResumeBasicView.ascx.cs
// 创建者: 倪豪
// 创建日期: 2008-10-09
// 概述: 简历信息的基本信息界面
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation.ResumeViews;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.EmployeeInformation.ResumeInformation
{
    public partial class EmployeeResumeBasicView : System.Web.UI.UserControl,IResumeBasicInfoView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPageWork_Click(int pageindex)
        {
            grvworklist.PageIndex = pageindex;
            WorkExperienceView = WorkExperienceDataSource;
        }

        protected void LinkButtonGoPageEdu_Click(int pageindex)
        {
            grveducationlist.PageIndex = pageindex;
            EducationExperienceView = EducationExperienceDataSource;
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplateWork = ViewUtility.GetPageTemplate(grvworklist, "PageTemplateWork");
            PageTemplate PageTemplateEdu = ViewUtility.GetPageTemplate(grveducationlist, "PageTemplateEdu");

            if (PageTemplateWork != null)
            {
                PageTemplateWork.LinkButtonGoPageClickdelegate += LinkButtonGoPageWork_Click;
            }
            if (PageTemplateEdu != null)
            {
                PageTemplateEdu.LinkButtonGoPageClickdelegate += LinkButtonGoPageEdu_Click;
            }
        }

        //add by colbert
        public DlgEduExperiences SendEduExperiences;
        public DlgWorkExperiences SendWorkExperiences;

        public event DelegateNoParameter BtnAddWorkExperienceEvent;
        public event DelegateNoParameter BtnAddEducationExperienceEvent;
        public event DelegateID BtnUpdateWorkExperienceEvent;
        public event DelegateID BtnUpdateEducationExperienceEvent;
        public event DelegateID BtnDeleteWorkExperienceEvent;
        public event DelegateID BtnDeleteEducationExperienceEvent;

        protected void btnAddEdu_Click(object sender, EventArgs e)
        {
            BtnAddEducationExperienceEvent();
        }

        protected void btnUpdateEdu_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateEducationExperienceEvent(e.CommandArgument.ToString());
        }

        protected void btnDeleteEdu_Click(object sender, CommandEventArgs e)
        {
            BtnDeleteEducationExperienceEvent(e.CommandArgument.ToString());
        }

        protected void btnAddwork_Click(object sender, EventArgs e)
        {
            BtnAddWorkExperienceEvent();
        }

        protected void btnUpdateWork_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateWorkExperienceEvent(e.CommandArgument.ToString());
        }

        protected void btnDelete1Work_Click(object sender, CommandEventArgs e)
        {
            BtnDeleteWorkExperienceEvent(e.CommandArgument.ToString());
        }

        protected void grvWorkList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvworklist.PageIndex = e.NewPageIndex;
            WorkExperienceView = WorkExperienceDataSource;
        }

        protected void grvworklist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        protected void grveducationlist_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        protected void grvEduList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grveducationlist.PageIndex = e.NewPageIndex;
            EducationExperienceView = EducationExperienceDataSource;
        }

        #region IResumeBasicInfoView成员

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

        public string Title
        {
            get
            {
               return txtWorkTitle.Text;
            }
            set
            {
               txtWorkTitle.Text = value;
            }
        }

        public string ForeignLanguageAbility
        {
            get
            {
                return TxtFLanguageAbility.Text;
            }
            set
            {
                TxtFLanguageAbility.Text = value;
            }
        }

        public string Certificates
        {
            get
            {
               return TxtCertificates.Text;
            }
            set
            {
               TxtCertificates.Text = value;
            }
        }

        public bool BtnAddWorkExperienceVisible
        {
            get
            {
                return btnAddWork.Visible;
            }
            set
            {
                btnAddWork.Visible = value;
            }
        }


        public bool BtnAddEducationExperienceVisible
        {
            get
            {
                return btnAddEducation.Visible;
            }
            set
            {
                btnAddEducation.Visible = value;
            }
        }

        public bool BtnUpdateWorkExperienceVisible
        {
            get
            {
                return true;
            }
            set
            {
                grvworklist.Columns[7].Visible = value;
            }
        }

        public bool BtnUpdateEducationExperienceVisible
        {
            get
            {
                return true;
            }
            set
            {
                grveducationlist.Columns[7].Visible = value;
            }
        }

        public bool BtnDeleteWorkExperienceVisible
        {
            get
            {
                return true;
            }
            set
            {

                grvworklist.Columns[8].Visible = value;
            }
        }


        public bool BtnDeleteEducationExperienceVisible
        {
            get
            {
                return true;
            }
            set
            {
                grveducationlist.Columns[6].Visible = value;
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
                if (SendWorkExperiences != null)
                    SendWorkExperiences(value);
            }
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
                if (SendEduExperiences != null)
                    SendEduExperiences(value);
            }
        }

        public List<WorkExperience> WorkExperienceView
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
               grvworklist.DataSource = value;
               grvworklist.DataBind();
               if(value!=null&&value.Count!=0)
               {
                   listWork.Visible = true;
               }
               else 
               {
                   listWork.Visible = false;
               }
            }
        }

        public List<EducationExperience> EducationExperienceView
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                grveducationlist.DataSource = value;
                grveducationlist.DataBind();
                if (value != null && value.Count != 0)
                {
                    listEducation.Visible = true;
                }
                else
                {
                    listEducation.Visible = false;
                }
            }
        }

        #endregion
    }
}