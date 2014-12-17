using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.SystemError;
using SEP.HRMIS.Presenter.IPresenter.ISystemError;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.SystemErrors
{
    public partial class SystemErrorListView : UserControl, ISystemErrorListPresenter
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
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

        protected void gvSystemError_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        public List<SystemError> SystemErrors
        {
            get { return null; }
            set
            {
                gvSystemError.DataSource = value;
                gvSystemError.DataBind();
            }
        }

        public bool ShowIgnore
        {
            get { return cbShowIgnore.Checked; }
            set { cbShowIgnore.Checked = value; }
        }

        public event DelegateNoParameter SearchEvent;
        public event Delegate2Parameter UpdateStatusEvent;

        protected void gvSystemError_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSystemError.PageIndex = e.NewPageIndex;
            SearchEvent();
        }

        protected void cbShowIgnore_CheckedChanged(object sender, EventArgs e)
        {
            SearchEvent();
        }

        protected void lbIgnore_Click(object sender, CommandEventArgs e)
        {
            UpdateStatusEvent(e.CommandName,e.CommandArgument.ToString());
            SearchEvent();
        }
    }
}