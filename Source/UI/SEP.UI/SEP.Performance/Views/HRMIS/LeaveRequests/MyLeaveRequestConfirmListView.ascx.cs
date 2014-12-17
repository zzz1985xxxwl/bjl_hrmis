using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.LeaveRequests
{
    public partial class MyLeaveRequestConfirmListView : UserControl, IMyLeaveRequestConfirmListView
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

        private const string _JustForTestError = "仅用于测试";
        public event DelegateID _ShowWindowForConfirmOperation;

        public int ListCount
        {
            get { return Convert.ToInt32(hfCount.Value); }
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
                    tbLeaveRequest.Style["display"] = "none";
                }
                else
                {
                    tbLeaveRequest.Style["display"] = "block";
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
        protected void Detail_Command(object sender, CommandEventArgs e)
        {
            btnViewClick(sender, e);
        }

        public event CommandEventHandler btnApproveClick;
        protected void Approve_Command(object sender, CommandEventArgs e)
        {
            btnApproveClick(sender, e);
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    _ShowWindowForConfirmOperation(e.CommandArgument.ToString());
                    return;
            }
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
                //重写onclick方法
                e.Row.Attributes["onclick"] =
                    String.Format(
                        "javascript:" +
                        "IsNextExecute = false;" +
                        "if(IsImgOnClickExe==false) document.getElementById('{0}').click();" +
                        "else IsImgOnClickExe=false;",
                        btnHiddenPostButton.ClientID);
            }
        }

        //public delegate void UpdateListWindow();
        public event DelegateNoParameter _UpdateListWindow;

        public event CommandEventHandler QuickPassEvent;
        protected void QuickPass_Command(object sender, CommandEventArgs e)
        {
            QuickPassEvent(this, e);
        }

    }
}