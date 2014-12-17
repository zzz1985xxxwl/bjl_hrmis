using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework.Common.DataAccess;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;
using SEP.Model.Departments;
using ShiXin.Security;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.HRMIS.Reimburse
{
    public partial class ReimburseCustomerSearchView : UserControl, IReimburseCustomerSearchView
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

        public event EventHandler btnSearchClick;

        public int SelectedIsCustomerFilled
        {
            get { return Convert.ToInt32(ddlIsCustomerFilled.SelectedValue); }
        }

        public PagerEntity PagerEntity
        {
            get { return new PagerEntity { PageIndex = gvReimburseList.PageIndex, PageSize = gvReimburseList.PageSize }; }
        }


        public event CommandEventHandler btnViewClick;

        protected void gvReimburseList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
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

        public string SelectedReimburseStatus
        {
            get { return ddlStatus.SelectedValue; }
        }

        public string ApplyDateMsg
        {
            get { throw new NotImplementedException(); }
            set { lblApplyDateMsg.Text = value; }
        }

        public string TotalMsg
        {
            get { throw new NotImplementedException(); }
            set { lblTotalCostMsg.Text = value; }
        }

        public string ApplyDateFrom
        {
            set { dtpApplyDateFrom.Text = value; }
            get { return dtpApplyDateFrom.Text.Trim(); }
        }

        public string ApplyDateTo
        {
            set { dtpApplyDateTo.Text = value; }
            get { return dtpApplyDateTo.Text.Trim(); }
        }

        public string TotalCostFrom
        {
            set { txtTotalCostFrom.Text = value; }
            get { return txtTotalCostFrom.Text.Trim(); }
        }

        public string TotalCostTo
        {
            set { txtTotalCostTo.Text = value; }
            get { return txtTotalCostTo.Text.Trim(); }
        }

        public string TotalCostMsg
        {
            get { throw new NotImplementedException(); }
            set { lblTotalCostMsg.Text = value; }
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

        private List<global::SEP.HRMIS.Model.Reimburse> _ReimburseListSource;

        public List<global::SEP.HRMIS.Model.Reimburse> ReimburseListSource
        {
            get { return _ReimburseListSource; }
            set
            {
                _ReimburseListSource = value;
                gvReimburseList.DataSource = value;
                gvReimburseList.DataBind();
                if (value.Count == 0)
                {
                    tbSearch.Style["display"] = "none";
                }
                else
                {
                    tbSearch.Style["display"] = "block";
                }
            }
        }


        public string EmployeeName
        {
            set { txtEmployeeName.Text = value; }
            get { return txtEmployeeName.Text.Trim(); }
        }

        public string DepartmentID
        {
            get { return ddlDepartment.SelectedValue; }
        }

        public int SelectedFinishStatus
        {
            get { return Convert.ToInt32(ddlFinishStatus.SelectedValue); }
        }

        protected void Approve_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(
                "UpdateReimburseCustomer.aspx?ReimburseID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()),
                false);
        }

        public List<ReimburseCategoriesEnum> ReimburseCategoriesEnumDataSrc
        {
            set
            {
                ddlReimburseCategories.Items.Clear();
                ddlReimburseCategories.Items.Add(new ListItem("", "-1"));
                foreach (ReimburseCategoriesEnum reimburseCategoriesEnum in value)
                {
                    ddlReimburseCategories.Items.Add(
                        new ListItem(reimburseCategoriesEnum.Name, reimburseCategoriesEnum.Id.ToString()));
                }
            }
        }

        public string ReimburseCategoriesEnumID
        {
            get { return ddlReimburseCategories.SelectedItem.Value; }
            set { ddlReimburseCategories.SelectedValue = value; }
        }
    }
}