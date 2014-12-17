using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeHistory;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.EmployeeHistory
{
    public partial class EmployeeHistoryListView : UserControl, IEmployeeHistoryListView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            BindEmployeeHistorySource(null, null);
            grd.PageIndex = pageindex;
            grd.DataSource = _EmployeeHistorySource;
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
        public delegate void ShowWindowForCancelOperation(int leaveRequestID);
        public ShowWindowForCancelOperation _ShowWindowForCancelOperation;

        public int ListCount
        {
            get
            {
                return Convert.ToInt32(hfCount.Value);
            }
        }

        private int _EmployeeID;
        public int EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }

        private List<HRMISModel.EmployeeHistory> _EmployeeHistorySource;
        public List<HRMISModel.EmployeeHistory> EmployeeHistorySource
        {
            get
            {
                throw new ArgumentNullException(_JustForTestError);
            }
            set
            {
                _EmployeeHistorySource = value;
                grd.DataSource = value;
                grd.DataBind();
                hfCount.Value = value.Count.ToString();
                lblMessage.Text = value.Count.ToString();

                if (value.Count == 0)
                {
                    divEmployeeHistory.Style["display"] = "none";
                }
                else
                {
                    lbName.Text = value[0].Employee.Account.Name;
                    divEmployeeHistory.Style["display"] = "block";
                }
            }
        }

        public event EventHandler BindEmployeeHistorySource;
        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindEmployeeHistorySource(null, null);
            grd.PageIndex = e.NewPageIndex;
            grd.DataSource = _EmployeeHistorySource;
            grd.DataBind();
        }

        protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        public event CommandEventHandler btnViewClick;
        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    btnViewClick(sender, e);
                    return;
            }

        }
    }
}