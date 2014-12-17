using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.ITrainApplication;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.TraineeApplications;
using SEP.Presenter.Core;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.TrainApplication
{
    public partial class SearchTrainApplicationView : UserControl, ISearchTrainApplicationView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvReimburseList.PageIndex = pageindex;
            ApplicationDataBind();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvReimburseList, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ApplicationDataBind();
        }

        protected void gvReimburseList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReimburseList.PageIndex = e.NewPageIndex;
            ApplicationDataBind();
        }

        protected void gvReimburseList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect("DetailTrainApplication.aspx?TrainApplicationID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString())); 
                    return;
            }
        }
        public event CommandEventHandler btnViewClick;

        protected void gvReimburseList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }


        public string Trainee
        {
            get { return txtEmployeeName.Text; }
        }

        public string TimeErrorMessage
        {
            set { lblApplyDateMsg.Text = value; }
        }

        public int HasCertification
        {
            get { return Convert.ToInt32(ddlCertifacation.SelectedValue); }
        }

        public List<TrainScopeType> ScopeSource
        {
            set
            {
                ddlType.Items.Clear();
                foreach (TrainScopeType type in value)
                {
                    ListItem item = new ListItem(type.Name, type.Id.ToString(), true);
                    ddlType.Items.Add(item);
                }
            }
        }

        public List<TraineeApplicationStatus> StatusSource
        {
            set
            {
                ddlStatus.Items.Clear();
                foreach (TraineeApplicationStatus type in value)
                {
                    ListItem item = new ListItem(type.Name, type.Id.ToString(), true);
                    ddlStatus.Items.Add(item);
                }
            }
        }

        private List<TraineeApplication> applications;
        public List<TraineeApplication> ApplicationSource
        {
            set
            {
                applications = value;
                gvReimburseList.DataSource = value;
                gvReimburseList.DataBind();
                if (applications == null || applications.Count == 0)
                {
                    tbSearch.Style["display"] = "none";
                }
                else
                {
                    tbSearch.Style["display"] = "block";

                }
                SetBtnCreateCousrseVisble();
                lblMessage.Text = value.Count.ToString();
            }
        }

        public event DelegateNoParameter ApplicationDataBind;

        public string DateFrom
        {
            get
            {
                return dtpDateFrom.Text.Trim();
            }
        }

        public string DateTo
        {
            get
            {
                return dtpDateTo.Text.Trim();
            }
        }


        public string EmployeeName
        {
            get { return txtEmployeeName.Text.Trim(); }
        }


        public string ErrorMessage
        {
            set { lblMessage.Text = value; }
        }

        public string CourseName
        {
            get { return txtCourseName.Text; }
        }

        public string Trainer
        {
            get { return txtTrainer.Text; }
        }

        public string Scope
        {
            get { return ddlType.SelectedValue; }
        }


        public string SelectedStatus
        {
            get { return ddlStatus.SelectedValue; }
        }

        protected void btnCreateCourse_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("../TrainingPages/AddTrainCourse.aspx?ApplicationId=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        private void SetBtnCreateCousrseVisble()
        {
            foreach (GridViewRow row in gvReimburseList.Rows)
            {
                Label lblstatus = row.FindControl("lblStatus") as Label;
                LinkButton btnCreate = row.FindControl("btnCreateCourse") as LinkButton;
                if (lblstatus != null)
                    if (lblstatus.Text.Equals(TraineeApplicationStatus.ApprovePass.Name))
                    {
                        if (btnCreate != null) btnCreate.Enabled = true;
                    }
            }
        }
    }
}