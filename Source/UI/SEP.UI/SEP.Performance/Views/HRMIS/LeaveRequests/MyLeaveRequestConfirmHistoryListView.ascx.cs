using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;

namespace SEP.Performance.Views.HRMIS.LeaveRequests
{
    public partial class MyLeaveRequestConfirmHistoryListView : UserControl, IMyLeaveRequestConfirmHistoryListView
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

        private const string _JustForTestError = "Ωˆ”√”⁄≤‚ ‘";

        public int ListCount
        {
            get { return Convert.ToInt32(hfCount.Value); }
        }

        public string EmployeeName
        {
            get { return txtEmployeeName.Text.Trim(); }
        }

        public string  FromDate
        {
            get { return txtDateFrom.Text; }
            set { txtDateFrom.Text = value; }
        }

        public string ToDate
        {
            get { return txtDateTo.Text; }
            set { txtDateTo.Text = value; }
        }

        public string DateMsg
        {
            get { return lblDateMsg.Text; }
            set { lblDateMsg.Text=value; }
        }

        public bool DisplaySearchCondition
        {
            set
            {
                divDisplaySearchCondition.Style["display"] = value ?"block":"none" ;
            }
        }

        private List<LeaveRequest> _LeaveRequestSource;
        public List<LeaveRequest> LeaveRequestSource
        {
            get
            {
                throw new ArgumentNullException(_JustForTestError);
            }
            set
            {
                _LeaveRequestSource = value;
                grd.DataSource = value;
                grd.DataBind();
                hfCount.Value = value.Count.ToString();
                if (value.Count == 0)
                {
                    divLeaveRequest.Style["display"] = "none";
                }
                else
                {
                    divLeaveRequest.Style["display"] = "block";
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

        public event CommandEventHandler btnViewClick;
        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    btnViewClick(sender, e);
                    return;
            }
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindLeaveRequestSource(this, EventArgs.Empty);
        }
    }
}