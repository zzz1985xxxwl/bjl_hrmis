using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.LeaveRequests
{
    public partial class MyLeaveRequestListView : UserControl, IMyLeaveRequestListView
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

        public int ListCount
        {
            get { return Convert.ToInt32(hfCount.Value); }
        }

        public int EmployeeID
        {
            get
            {
                return Convert.ToInt32(hfEmployeeID.Value);
            }
            set
            {
                hfEmployeeID.Value = value.ToString();
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
                //LeaveRequestStatusDisplay();
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

        //private void LeaveRequestStatusDisplay()
        //{
        //    foreach (GridViewRow row in grd.Rows)
        //    {
        //        LinkButton btnUpdate = (LinkButton) row.FindControl("btnUpdate");
        //        LinkButton btnDelete = (LinkButton) row.FindControl("btnDelete");
        //        if (btnUpdate.Enabled)
        //        {
        //            btnUpdate.Text = "<img src=../../image/icon04.gif border=0>编辑";
        //            btnDelete.Text = "<img src=../../image/icon05.gif border=0>删除";
        //        }

        //        LinkButton btnCancel = (LinkButton) row.FindControl("btnCancel");
        //        if (btnCancel.Enabled)
        //        {
        //            btnCancel.Text = "<img src=../../image/icon08.gif border=0>快速取消";
        //        }
        //    }
        //}

        public event EventHandler BindLeaveRequestSource;
        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindLeaveRequestSource(null, null);
            grd.PageIndex = e.NewPageIndex;
            grd.DataSource = _LeaveRequestSource;
            grd.DataBind();
            //LeaveRequestStatusDisplay();
        }

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
                    btnViewClick(e.CommandArgument.ToString());
                    return;
            }

        }

        public event DelegateID btnViewClick;
        protected void View_Command(object sender, CommandEventArgs e)
        {
            btnViewClick(e.CommandArgument.ToString());
        }

        public event DelegateID btnUpdateClick;
        protected void Update_Command(object sender, CommandEventArgs e)
        {
            btnUpdateClick(e.CommandArgument.ToString());
        }

        public event DelegateID btnDeleteClick;
        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            btnDeleteClick(e.CommandArgument.ToString());
        }

        public event DelegateNoParameter btnAddClick;
        protected void Add_Command(object sender, EventArgs e)
        {
            btnAddClick();
        }

        public event DelegateID btnCancelClick;
        protected void Cancel_Command(object sender, CommandEventArgs e)
        {
            btnCancelClick(e.CommandArgument.ToString());
        }

        public event DelegateID btnCancelItemClick;
        protected void CancelItem_Command(object sender, CommandEventArgs e)
        {
            btnCancelItemClick(e.CommandArgument.ToString());
        }
    }
}