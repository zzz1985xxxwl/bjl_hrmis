using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IPlanDutyPresenter;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.PlanDutyViews
{
    public partial class DutyClassListView : System.Web.UI.UserControl, IDutyClassListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvDutyClass.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvDutyClass, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BtnAddEvent();
        }

        protected void btnModify_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateEvent(e.CommandArgument.ToString());
        }

        protected void gvDutyClass_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDutyClass.PageIndex = e.NewPageIndex;
            btnSearch_Click(sender, e);
        }

        protected void gvDutyClass_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    BtnDetailEvent(e.CommandArgument.ToString());
                    return;
            }
        }

        protected void gvDutyClass_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }

        #region IDutyClassListView
        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        public string DutyClassName
        {
            get { return txtName.Text; }
        }

        private List<DutyClass> dutyClasss;
        public List<DutyClass> DutyClasss
        {
            get { return dutyClasss; }
            set
            {
                dutyClasss = value;
                gvDutyClass.DataSource = value;
                gvDutyClass.DataBind();
                if (dutyClasss == null || dutyClasss.Count == 0)
                {
                    tbDutyClass.Style["display"] = "none";
                }
                else
                {
                    tbDutyClass.Style["display"] = "block";

                }
                lblMessage.Text = value.Count.ToString();
            }
        }

        public event DelegateNoParameter BtnAddEvent;
        public event DelegateID BtnUpdateEvent;
        public event DelegateID BtnDetailEvent;
        public event DelegateNoParameter BtnSearchEvent;

        #endregion
    }
}