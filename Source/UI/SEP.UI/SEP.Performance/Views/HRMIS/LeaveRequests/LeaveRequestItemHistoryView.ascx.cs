using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;

namespace SEP.Performance.Views.HRMIS.LeaveRequests
{
    public partial class LeaveRequestItemHistoryView : UserControl, ILeaveRequestItemHistoryView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            BindLeaveRequestSource(null, null);
            grd.PageIndex = pageindex;
            grd.DataSource = _LeaveRequestSource;
            grd.DataBind();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grd, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        private List<LeaveRequestFlow> _LeaveRequestSource;
        public List<LeaveRequestFlow> LeaveRequestSource
        {
            set
            {
                _LeaveRequestSource = value;
                grd.DataSource = value;
                grd.DataBind();
                if (value.Count == 0)
                {
                    divLeaveRequestItemHistory.Style["display"] = "none";
                }
                else
                {
                    divLeaveRequestItemHistory.Style["display"] = "block";
                }
            }
        }

        public event EventHandler BindLeaveRequestSource;
        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindLeaveRequestSource(null, null);
            grd.PageIndex = e.NewPageIndex;
            grd.DataSource = _LeaveRequestSource;
            grd.DataBind();
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    return;
            }
        }
    }
}