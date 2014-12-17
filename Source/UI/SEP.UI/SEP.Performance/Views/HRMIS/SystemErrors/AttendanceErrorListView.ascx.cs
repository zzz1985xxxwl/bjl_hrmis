using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.SystemError;
using SEP.HRMIS.Presenter.IPresenter.ISystemError;
using SEP.HRMIS.Presenter.SystemErrors;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.SystemErrors
{
    public partial class AttendanceErrorListView : UserControl, IAttendanceErrorListPresenter
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new AttendanceErrorListPresenter(this, Session[SessionKeys.LOGININFO] as Account, PageIsPostBack);
            BindPageTemplate();
        }

        private bool PageIsPostBack
        {
            get
            {
                if (ViewState["IsFisrt"] == null)
                {
                    ViewState["IsFisrt"] = "added";
                    return false;
                }
                return IsPostBack;
            }
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvSystemError.PageIndex = pageindex;
            SearchEvent();
        }
        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvSystemError, "PageTemplate1");
            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void gvSystemError_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSystemError.PageIndex = e.NewPageIndex;
            SearchEvent();
        }

        protected void gvSystemError_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        public string EmployeeName
        {
            get { return txtEmployeeName.Text.Trim(); }
            set { txtEmployeeName.Text = value; }
        }

        public List<Department> DepartmentSource
        {
            set
            {
                ddlDepartment.DataSource = value;
                ddlDepartment.DataValueField = "DepartmentID";
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataBind();
            }
        }

        public int DepartmentID
        {
            get { return Convert.ToInt32(ddlDepartment.SelectedValue); }
        }

        public string FromDate
        {
            get { return dtpScopeFrom.Text.Trim(); }
            set { dtpScopeFrom.Text = value; }
        }

        public string ToDate
        {
            get { return dtpScopeTo.Text.Trim(); }
            set { dtpScopeTo.Text = value; }
        }

        public string ScopeMsg
        {
            set { lblScopeMsg.Text = value; }
        }

        public List<SystemError> SystemErrors
        {
            set
            {
                gvSystemError.DataSource = value;
                gvSystemError.DataBind();
            }
        }

        public event DelegateNoParameter SearchEvent;

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEvent();
        }
    }
}