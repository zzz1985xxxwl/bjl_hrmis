using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using SEP.Performance;
using SEP.HRMIS.Model.PayModule;

namespace SEP.Performance.Views.HRMIS.PayModuleViews
{
    public partial class EmployeeSalaryHistoryListView : UserControl, IEmployeeSalaryHistoryListPresenter
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            grv.PageIndex = pageindex;
            grv.DataSource = _EmployeeSalaryHistoryList;
            grv.DataBind();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grv, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void grv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv.PageIndex = e.NewPageIndex;
            grv.DataSource = _EmployeeSalaryHistoryList;
            grv.DataBind();
        }

        protected void grv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }

        public event CommandEventHandler GoToEmployeeSalaryHistoryDetailPage;
        protected void Detail_Command(object sender, CommandEventArgs e)
        {
            GoToEmployeeSalaryHistoryDetailPage(sender, e);
        }

        public string ResultMessage
        {
            set
            {
                lblMessage.Text = value;
            }
        }

        public string EmployeeName
        {
            set
            {
                lbEmployeeName.Text = value;
            }
        }

        private List<EmployeeSalaryHistory> _EmployeeSalaryHistoryList;
        public List<EmployeeSalaryHistory> EmployeeSalaryHistoryList
        {
            set
            {
                _EmployeeSalaryHistoryList = value;
                grv.DataSource = value;
                grv.DataBind();
                if (value.Count > 0)
                {
                    tbEmployeeGridView.Style["display"] = "block";
                }
                else
                {
                    tbEmployeeGridView.Style["display"] = "none";
                }
            }
        }

        public event EventHandler GoToBackPage;
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            GoToBackPage(sender, e);
        }
    }
}