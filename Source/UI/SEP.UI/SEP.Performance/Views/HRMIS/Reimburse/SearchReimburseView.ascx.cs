using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Framework.Common.DataAccess;
using SEP.HRMIS.Model;
using SEP.Presenter.Core;
using ShiXin.Security;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;
using SEP.Model.Departments;

namespace SEP.Performance.Views.HRMIS.Reimburse
{
    public partial class SearchReimburseView : UserControl, ISearchReimburseView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvReimburseList.PageIndex = pageindex;
            btnSearch_Click(null, null);
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
            btnSearchClick(null, null);
        }

        protected void gvReimburseList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReimburseList.PageIndex = e.NewPageIndex;
            btnSearchClick(null, null);
        }

        protected void gvReimburseList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    btnViewClick(sender, e);
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

        public Dictionary<string, string> ReimburseStatus
        {
            get { throw new NotImplementedException(); }
            set
            {
                ddlStatus.Items.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    ddlStatus.Items.Add(item);
                }
            }
        }

        public string ApplyDateMsg
        {
            get { throw new NotImplementedException(); }
            set
            {
                lblApplyDateMsg.Text = value;
            }
        }

        public string TotalMsg
        {
            get { throw new NotImplementedException(); }
            set
            {
                lblTotalCostMsg.Text = value;
            }
        }

        public string ApplyDateFrom
        {
            set
            {
                dtpApplyDateFrom.Text = value;
            }
            get
            {
                return dtpApplyDateFrom.Text.Trim();
            }
        }

        public string ApplyDateTo
        {
            set
            {
                dtpApplyDateTo.Text = value;
            }
            get
            {
                return dtpApplyDateTo.Text.Trim();
            }
        }

        public string TotalCostFrom
        {
            set
            {
                txtTotalCostFrom.Text = value;
            }
            get
            {
                return txtTotalCostFrom.Text.Trim();
            }
        }

        public string TotalCostTo
        {
            set
            {
                txtTotalCostTo.Text = value;
            }
            get
            {
                return txtTotalCostTo.Text.Trim();
            }
        }

        public string TotalCostMsg
        {
            get { throw new NotImplementedException(); }
            set
            {
                lblTotalCostMsg.Text = value;
            }
        }
        public int CompanyID
        {
            get { return Convert.ToInt32(ddCompany.SelectedValue); }
        }

        public List<Department> CompanySource
        {
            set
            {
                ddCompany.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, "-1", true);
                ddCompany.Items.Add(itemAll);
                foreach (Department department in value)
                {
                    ListItem item = new ListItem(department.DepartmentName, department.DepartmentID.ToString(), true);
                    ddCompany.Items.Add(item);
                }
            }
        }

        public string BillingTimeFrom
        {
            get { return txtBillingFrom.Text.Trim(); }
        }

        public string BillingTimeTo
        {
            get { return txtBillingTo.Text.Trim(); }
        }

        public string BillingTimeMsg
        {
            set { lblBillingMsg.Text = value; }
        }

        public List<Department> DepartmentSource
        {
            get { throw new NotImplementedException(); }
            set
            {
                value.Add(new Department(-1, ""));
                ddlDepartment.DataSource = value;
                ddlDepartment.DataValueField = "DepartmentID";
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataBind();
                ddlDepartment.SelectedValue = "-1";
            }
        }

        private List<hrmisModel.Reimburse> _ReimburseListSource;
        public List<hrmisModel.Reimburse> ReimburseListSource
        {
            get
            {
                return _ReimburseListSource;
            }
            set
            {
                _ReimburseListSource = value;
                gvReimburseList.DataSource = value;
                gvReimburseList.DataBind();
                if (value.Count == 0)
                {
                    tbSearch.Style["display"] = "none";
                    btnReturn.Visible = false;
                    btnWaitAudit.Visible = false;
                    //btnReimbursed.Visible = false;
                }
                else
                {
                    tbSearch.Style["display"] = "block";
                    btnReturn.Visible = true;
                    btnWaitAudit.Visible = true;
                    //btnReimbursed.Visible = true;

                    SetgrdDisplay();
                }
            }
        }

        private void SetgrdDisplay()
        {
            foreach (GridViewRow row in gvReimburseList.Rows)
            {
                Label lblStatus = (Label)row.FindControl("lblStatus");
                LinkButton btnApprove = (LinkButton)row.FindControl("btnApprove");
                LinkButton btnReimburse = (LinkButton)row.FindControl("btnReimburse");

                switch (hrmisModel.Reimburse.GetReimburseStatusByReimburseStatusName(lblStatus.Text))
                {
                    case ReimburseStatusEnum.WaitAudit:
                        btnApprove.Enabled = true;
                        btnApprove.Text = "审核";
                        break;

                    case ReimburseStatusEnum.Auditing:
                        btnReimburse.Enabled = true;
                        btnReimburse.Text = "已报销";
                        break;

                    default:
                        break;
                }
            }
        }


        public string EmployeeName
        {
            set
            {
                txtEmployeeName.Text = value;
            }
            get { return txtEmployeeName.Text.Trim(); }
        }

        public string DepartmentID
        {
            get { return ddlDepartment.SelectedValue; }
        }

        public string SelectedReimburseStatus
        {
            get { return ddlStatus.SelectedValue; }
        }

        public List<string> SelectedReimburses
        {
            get
            {
                List<string> selectedReimbursesID = new List<string>();
                foreach (GridViewRow row in gvReimburseList.Rows)
                {
                    HtmlInputCheckBox cbChooseReimburse = (HtmlInputCheckBox)row.FindControl("cbChooseReimburse");
                    if (cbChooseReimburse.Checked)
                    {
                        HiddenField hfReimburseID = (HiddenField)row.FindControl("hfReimburseID");
                        selectedReimbursesID.Add(hfReimburseID.Value);
                    }
                }
                return selectedReimbursesID;
            }
        }
        public bool SelectAllReimburses
        {
            set
            {
                foreach (GridViewRow row in gvReimburseList.Rows)
                {
                    HtmlInputCheckBox cbChooseReimburse = (HtmlInputCheckBox)row.FindControl("cbChooseReimburse");
                    cbChooseReimburse.Checked = value;
                }
            }
        }

        public int SelectedFinishStatus
        {
            get { return Convert.ToInt32(ddlFinishStatus.SelectedValue); }
        }

        public PagerEntity PagerEntity
        {
            get
            {
                return new PagerEntity{PageIndex = gvReimburseList.PageIndex,PageSize = gvReimburseList.PageSize};
            }
        }

        public event EventHandler btnSearchClick;
        public event EventHandler btnReimbursedClick;
        public event EventHandler btnReturnClick;
        public event EventHandler btnWaitAuditClick;

        protected void btnReimbursed_Click(object sender, EventArgs e)
        {
            btnReimbursedClick(null, null);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            btnReturnClick(null, null);
        }

        protected void btnWaitAudit_Click(object sender, EventArgs e)
        {
            btnWaitAuditClick(null, null);
        }

        protected void lbClearAll_Click(object sender, EventArgs e)
        {
            SelectAllReimburses = false;
        }

        protected void lbChooseAll_Click(object sender, EventArgs e)
        {
            SelectAllReimburses = true;
        }

        protected void Approve_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("ReimburseAuditing.aspx?ReimburseID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }

        protected void btnReimburse_Click(object sender, CommandEventArgs e)
        {
            BtnReimbursedEvent(e.CommandArgument.ToString());
        }

        #region ISearchReimburseView 成员


        public event DelegateID BtnReimbursedEvent;

        #endregion

        #region ISearchReimburseView 成员

        public List<ReimburseCategoriesEnum> ReimburseCategoriesEnumDataSrc
        {
            set
            {
                ddlReimburseCategories.Items.Clear();
                ddlReimburseCategories.Items.Add(new ListItem("", "-1"));
                foreach (ReimburseCategoriesEnum reimburseCategoriesEnum in value)
                {
                    ddlReimburseCategories.Items.Add(new ListItem(reimburseCategoriesEnum.Name, reimburseCategoriesEnum.Id.ToString()));
                }
            }
        }

        public string ReimburseCategoriesEnumID
        {
            get { return ddlReimburseCategories.SelectedItem.Value; }
            set { ddlReimburseCategories.SelectedValue = value; }
        }

        #endregion
    }
}