using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework.Common;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Logic;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;
using SEP.Presenter.Core;
using ShiXin.Security;
using hrmisModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.HRMIS.Reimburse
{
    public partial class ReimburseView : UserControl, IReimburseView
    {
        public DlgReimburseItems SendReimburseItems;

        protected void Page_Load(object sender, EventArgs e)
        {

            //txtCustomer.Attributes.Add("onkeyup", "return addTest(event);");
            //txtCustomer.Attributes.Add("onkeydown", "return keydowndeal(event);");
        }


        protected void lbModifyItem_Click(object sender, CommandEventArgs e)
        {
            btnUpdateClick(e.CommandArgument.ToString());
        }

        protected void gvReimburseItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReimburseItem.PageIndex = e.NewPageIndex;
            //Session changed to ViewState modify by colbert
            ReimburseItemSource = (List<ReimburseItem>)ViewState["_ReimburseItem"];
        }

        protected void gvReimburseItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    btnDetailClick(e.CommandArgument.ToString());
                    return;
            }
        }

        protected void lbDeleteItem_Click(object sender, CommandEventArgs e)
        {
            btnDeleteClick(e.CommandArgument.ToString());
        }

        protected void gvReimburseItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            btnAddClick();
        }

        public global::SEP.HRMIS.Model.Reimburse Reimburse
        {
            get
            {
                DateTime dt;
                if (!DateTime.TryParse(dtpApplyDate.Text.Trim(), out dt))
                {
                    dt = DateTime.Now;
                }
                global::SEP.HRMIS.Model.Reimburse reimburse =
                    new global::SEP.HRMIS.Model.Reimburse(dt, ReimburseStatusEnum.Added);
                reimburse.ReimburseItems = ReimburseItemSource;
                return reimburse;
            }
            set
            {
                ApplyDate = value.ApplyDate.ToShortDateString();
                txtID.Text = value.ReimburseID.ToString();
            }
        }

        public string Message
        {
            get { throw new NotImplementedException(); }
            set
            {
                lblMessage.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "";
                }
            }
        }
        public List<ExchangeRateEntity> ExchangeRateSource
        {
            set
            {
                ddlExchangeRate.Items.Clear();
                foreach (var exchangeRateEntity in value)
                {
                    ddlExchangeRate.Items.Add(new ListItem(exchangeRateEntity.Name, exchangeRateEntity.PKID.ToString()));
                }
            }
        }

        public int ExchangeRateID
        {
            get { return Convert.ToInt32(ddlExchangeRate.SelectedValue); }
            set { ddlExchangeRate.SelectedValue = value.ToString(); }
        }

        private global::SEP.HRMIS.Model.Employee _Employee;

        public global::SEP.HRMIS.Model.Employee Employee
        {
            get { return _Employee; }
            set
            {
                _Employee = value;
                txtApplierName.Text = value.Account.Name;
            }
        }

        public string DepartmentName
        {
            set { txtDepartment.Text = value; }
        }

        public string ApplyDate
        {
            get { return dtpApplyDate.Text.Trim(); }
            set { dtpApplyDate.Text = value; }
        }

        public List<ReimburseItem> ReimburseItemSource
        {
            get
            {
                //Session changed to ViewState modify by colbert
                return (List<ReimburseItem>)ViewState["_ReimburseItem"];
            }
            set
            {
                //Session changed to ViewState modify by colbert
                ViewState["_ReimburseItem"] = value;
                if (SendReimburseItems != null)
                    SendReimburseItems(value);
                gvReimburseItem.DataSource = value;
                gvReimburseItem.DataBind();
                if (value == null || value.Count == 0)
                {
                    tbReimburseItem.Style["display"] = "none";

                    ddlReimburseCategories.Enabled = true;
                }
                else
                {
                    tbReimburseItem.Style["display"] = "";
                    ddlReimburseCategories.Enabled = false;
                }

                decimal total = CaculateTotalCost(value);
                if (!string.IsNullOrEmpty(OutCityAllowance))
                {
                    decimal temp;
                    if (decimal.TryParse(OutCityAllowance, out temp))
                    {
                        total += temp;
                    }
                }
                lblTotalCost.Text = total.ToString();
            }
        }

        private static decimal CaculateTotalCost(IEnumerable<ReimburseItem> items)
        {
            return items == null ? 0 : items.Sum(item => item.TotalCost);
        }

        public string Operation
        {
            get { throw new NotImplementedException(); }
            set { lblOperation.Text = value; }
        }

        public int SetDeleteFormButton
        {
            set
            {
                // 新增页面
                if (value == 1)
                {
                    btnSubmit.Visible = true;
                    btnSave.Visible = true;
                    btnAddItem.Visible = true;
                    btnOK.Visible = false;
                    btnCancel.Visible = false;
                    btnPass.Visible = false;
                    btnIntermit.Visible = false;
                    btnCancel1.Visible = false;
                }
                // 详情页面
                else if (value == 2)
                {
                    btnSubmit.Visible = false;
                    btnSave.Visible = false;
                    btnAddItem.Visible = false;
                    btnOK.Visible = true;
                    btnCancel.Visible = true;
                    btnPass.Visible = false;
                    btnIntermit.Visible = false;
                    btnCancel1.Visible = false;
                }
                // 审核页面
                else if (value == 3)
                {
                    btnSubmit.Visible = false;
                    btnSave.Visible = false;
                    btnAddItem.Visible = false;
                    btnOK.Visible = false;
                    btnCancel.Visible = false;
                    btnPass.Visible = true;
                    btnIntermit.Visible = true;
                    btnCancel1.Visible = true;
                }
            }
        }

        public bool SetFormReadonly
        {
            get { throw new NotImplementedException(); }
            set
            {
                gvReimburseItem.Columns[6].Visible = !value;
                gvReimburseItem.Columns[7].Visible = !value;
                gvReimburseItem.Columns[3].Visible = value;
            }
        }

        //public bool SetUpdateReadonly
        //{
        //    set
        //    {
        //        ddlReimburseCategories.Enabled = !value;
        //    }
        //}

        public bool SetDetailReadonly
        {
            set
            {
                dtpApplyDate.ReadOnly = value;
                ddlReimburseCategories.Enabled = !value;
                txtPaperCount.ReadOnly = value;
                txtDestinations.ReadOnly = value;
                //txtCustomer.ReadOnly = value;
                txtProjectCode.ReadOnly = value;
                dtpConsumeDateFrom.ReadOnly = value;
                ddlConsumeDateFromHour.Enabled = !value;
                ddlConsumeDateFromMinute.Enabled = !value;
                dtpConsumeDateTo.ReadOnly = value;
                ddlConsumeDateToHour.Enabled = !value;
                ddlConsumeDateToMinute.Enabled = !value;
                ddlExchangeRate.Enabled = !value;
                txtDiscription.Enabled = !value;
                if (!string.IsNullOrEmpty(txtRemak.Text.Trim()))
                {
                    trremark.Visible = value;
                }
                if (!string.IsNullOrEmpty(txtOutCityAllowance.Text.Trim()))
                {
                    txtOutCityAllowance.Enabled = value;
                }
                if (!string.IsNullOrEmpty(txtOutCityDays.Text.Trim()))
                {
                    txtOutCityDays.Enabled = value;
                }
            }
        }

        public bool SetComfirmReadonly
        {
            set
            {
                ddlReimburseCategories.Enabled = !value;
                ddlExchangeRate.Enabled = !value;
                trremark.Visible = value;
                txtOutCityAllowance.Enabled = value;
                txtOutCityDays.Enabled = value;
            }
        }

        public bool SetOutCityVisible
        {
            set
            {
                txtOutCityAllowance.Visible = value;
                tdOutCityAllowance.Visible = value;
                txtOutCityDays.Visible = value;
                tdOutCityDays.Visible = value;
            }
        }

        public event DelegateID btnUpdateClick;

        public event DelegateID btnDeleteClick;

        public event DelegateNoParameter btnAddClick;

        string IReimburseView.lblApplyDateMsg
        {
            set { lblApplyDateMsg.Text = value; }
        }

        public event EventHandler btnSaveClick;

        public event EventHandler btnSubmitClick;
        public event EventHandler btnOKClick;
        public event EventHandler btnCancelClick;
        public event DelegateID btnDetailClick;

        public event DelegateID btnPassClick;
        public event DelegateID btnIntermitClick;

        protected void btnSave_Click(object sender, EventArgs e)
        {
            btnSaveClick(null, null);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmitClick(null, null);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancelClick(null, null);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            btnOKClick(null, null);
        }

        protected void btnPass_Click(object sender, EventArgs e)
        {
            btnPassClick(SecurityUtil.DECDecrypt(Request.QueryString["ReimburseID"]));
            if (lblMessage.Text.Trim() == string.Empty &&
                lblPaperCountMsg.Text.Trim() == string.Empty &&
                lblDestinationsMsg.Text.Trim() == string.Empty &&
                //lblCustomer.Text.Trim() == string.Empty &&
                lblProject.Text.Trim() == string.Empty &&
                lblConsumeMsg.Text.Trim() == string.Empty &&
                lbOutCityDays.Text.Trim() == string.Empty &&
                lbOutCityAllowance.Text.Trim() == string.Empty)
            {
                Response.Redirect("SearchReimburse.aspx", false);
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            btnIntermitClick(SecurityUtil.DECDecrypt(Request.QueryString["ReimburseID"]));
            if (lblMessage.Text == string.Empty)
            {
                Response.Redirect("SearchReimburse.aspx", false);
            }
        }

        protected void btnCancel_Click1(object sender, EventArgs e)
        {
            Response.Redirect("SearchReimburse.aspx", false);
        }

        public List<ReimburseFlow> ReimburseHistorySource
        {
            set
            {
                gvReimburseFlow.DataSource = value;
                gvReimburseFlow.DataBind();
                if (value == null || value.Count == 0)
                {
                    //tbReimburseFlow.Style["display"] = "none";
                    Review1.Style["display"] = "none";
                    Review2.Style["display"] = "none";
                }
                else
                {
                    //tbReimburseFlow.Style["display"] = "";
                    Review1.Style["display"] = "";
                    Review2.Style["display"] = "";
                }
            }
        }

        protected void gvReimburseFlow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        protected void gvReimburseFlow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReimburseFlow.PageIndex = e.NewPageIndex;
            BindReimburseHistorySource();
        }

        public event DelegateNoParameter BindReimburseHistorySource;

        #region IReimburseView 成员

        public string ConsumeDateFrom
        {
            get { return dtpConsumeDateFrom.Text.Trim(); }
            set { dtpConsumeDateFrom.Text = value; }
        }

        public string ConsumeDateTo
        {
            get { return dtpConsumeDateTo.Text.Trim(); }
            set { dtpConsumeDateTo.Text = value; }
        }

        public string ConsumeDateFromHour
        {
            get { return ddlConsumeDateFromHour.Text; }
            set { ddlConsumeDateFromHour.Text = value; }
        }

        public string ConsumeDateFromMinute
        {
            get { return ddlConsumeDateFromMinute.Text.Trim(); }
            set { ddlConsumeDateFromMinute.Text = value; }
        }

        public string ConsumeDateToHour
        {
            get { return ddlConsumeDateToHour.Text.Trim(); }
            set { ddlConsumeDateToHour.Text = value; }
        }

        public string ConsumeDateToMinute
        {
            get { return ddlConsumeDateToMinute.Text.Trim(); }
            set { ddlConsumeDateToMinute.Text = value; }
        }

        public string ConsumeDateMsg
        {
            get { throw new NotImplementedException(); }
            set { lblConsumeMsg.Text = value; }
        }


        public List<ReimburseCategoriesEnum> ReimburseCategoriesEnumDataSrc
        {
            set
            {
                ddlReimburseCategories.Items.Clear();
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

        public string PaperCount
        {
            get { return txtPaperCount.Text.Trim(); }
            set { txtPaperCount.Text = value; }
        }

        public string PaperCountMsg
        {
            get { throw new NotImplementedException(); }
            set { lblPaperCountMsg.Text = value; }
        }

        private bool isTravelReimburse;

        public bool IsTravelReimburse
        {
            get { return isTravelReimburse; }
            set
            {
                if (!value)
                {
                    trDestinations.Style["display"] = "none";
                    trProject.Style["display"] = "none";
                    trDate.Style["display"] = "none";
                    trremark.Style["display"] = "none";
                    isTravelReimburse = false;
                    lblTimeName.Text = "消费时间";
                    gvReimburseItem.Columns[2].Visible = true;
                }
                else
                {
                    trDestinations.Style["display"] = "";
                    trProject.Style["display"] = "";
                    trDate.Style["display"] = "";
                    trremark.Style["display"] = "";
                    isTravelReimburse = true;
                    lblTimeName.Text = "出差时间";
                    gvReimburseItem.Columns[2].Visible = false;
                }
            }
        }

        public string Destinations
        {
            get { return txtDestinations.Text.Trim(); }
            set { txtDestinations.Text = value; }
        }

        public string DestinationsMsg
        {
            get { throw new NotImplementedException(); }
            set { lblDestinationsMsg.Text = value; }
        }

        public string ProjectName
        {
            get
            {
                return lblProjectName.Text;
            }
            set
            {
                var index = value.IndexOf(' ');
                if (index > 0)
                {
                    var code = value.Substring(0, index);
                    if (code.IndexOf('-') > 0)
                    {
                        txtProjectCode.Text = code.Split('-')[1];
                    }

                }
                lblProjectName.Text = value;
            }
        }

        public int ProjectID
        {
            get { return txtProjectID.Value.SafeToInt(); }
            set { txtProjectID.Value = value.ToString(); }
        }
        public string ProjectNameMsg
        {
            get { throw new NotImplementedException(); }
            set { lblProject.Text = value; }
        }

        public string OutCityAllowance
        {
            get { return txtOutCityAllowance.Text.Trim(); }
            set { txtOutCityAllowance.Text = value; }
        }

        public string OutCityAllowanceMsg
        {
            get { return lbOutCityAllowance.Text; }
            set { lbOutCityAllowance.Text = value; }
        }

        public string OutCityDays
        {
            get { return txtOutCityDays.Text.Trim(); }
            set { txtOutCityDays.Text = value; }
        }

        public string OutCityDaysMsg
        {
            get { return lbOutCityDays.Text; }
            set { lbOutCityDays.Text = value; }
        }

        public string Remark
        {
            get { return txtRemak.Text.Trim(); }
            set { txtRemak.Text = value; }
        }
        public string Discription
        {
            get { return txtDiscription.Text.Trim(); }
            set { txtDiscription.Text = value; }
        }
        #endregion


        protected void txtProjectCode_TextChanged(object sender, EventArgs e)
        {
            var code = txtProjectCode.Text.Trim();
            lblProject.Text = "";
            lblProjectName.Text = "";
            txtProjectID.Value = "";
            if (!string.IsNullOrEmpty(code))
            {
                var project = ProjectInfoLogic.GetProjectInfoByCode(code);
                if (project != null)
                {
                    lblProjectName.Text = project.ProjectName;
                }
                else
                {
                    lblProject.Text = "不存在该编号";
                    lblProjectName.Text = "";
                }
            }
        }
    }
}