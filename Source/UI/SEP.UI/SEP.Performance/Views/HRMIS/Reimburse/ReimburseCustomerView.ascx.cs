using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using hrmisModel = SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeReimburse;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.Reimburse
{

    public partial class ReimburseCustomerView : UserControl, IReimburseCustomerView
    {
  
        protected void gvReimburseItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReimburseItem.PageIndex = e.NewPageIndex;
            //Session changed to ViewState modify by colbert
            ReimburseItemSource = (List<ReimburseItem>)ViewState["_ReimburseItem"];
        }


        protected void gvReimburseItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }


        public hrmisModel.Reimburse Reimburse
        {
            get
            {
                hrmisModel.Reimburse reimburse =
                    new hrmisModel.Reimburse(DateTime.Now, ReimburseStatusEnum.Added);
                reimburse.ReimburseItems = ReimburseItemSource;
                return reimburse;
            }
            set
            {
                ApplyDate = value.ApplyDate.ToShortDateString();
                txtID.Text = value.ReimburseID.ToString();
            }
        }

        public string ApplierName
        {
            set { txtApplierName.Text = value; }
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
                    tbMessage.Style["display"] = "block";
                }
            }
        }

        private hrmisModel.Employee _Employee;
        public hrmisModel.Employee Employee
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
                List<ReimburseItem> reimburseItemList = (List<ReimburseItem>) ViewState["_ReimburseItem"];
                GetGridViewValue(reimburseItemList);
                return reimburseItemList;
            }
            set
            {
                ViewState["_ReimburseItem"] = value;
                gvReimburseItem.DataSource = value;
                gvReimburseItem.DataBind();
                if (value == null || value.Count == 0)
                {
                    tbReimburseItem.Style["display"] = "none";

                    ddlReimburseCategories.Enabled = true;
                }
                else
                {
                    tbReimburseItem.Style["display"] = "block";
                    ddlReimburseCategories.Enabled = false;
                    SetGridViewDisplay(value);
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
            decimal ret = 0;
            if (items == null)
            {
                return ret;
            }
            foreach (ReimburseItem item in items)
            {
                ret = ret + item.TotalCost;
            }
            return ret;
        }

        public string Operation
        {
            get { throw new NotImplementedException(); }
            set { lblOperation.Text = value; }
        }


        public string PaperCount
        {
            get
            {
                return txtPaperCount.Text.Trim();
            }
            set
            {
                txtPaperCount.Text = value;
            }
        }

        public string Destinations
        {
            get
            {
                return txtDestinations.Text.Trim();
            }
            set
            {
                txtDestinations.Text = value;
            }
        }

        public string ProjectName
        {
            get
            {
                return txtProject.Text.Trim();
            }
            set
            {
                txtProject.Text = value;
            }
        }

        public event EventHandler btnOKClick;

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ReimbursePages/ReimburseCustomerSearch.aspx", false);
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            btnOKClick(null, null);
        }

        protected void gvReimburseFlow_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }

        public event DelegateNoParameter BindReimburseHistorySource;

        #region IReimburseView 成员


        public string ConsumeDateFrom
        {
            get
            {
                return dtpConsumeDateFrom.Text.Trim();
            }
            set
            {
                dtpConsumeDateFrom.Text = value;
            }
        }

        public string ConsumeDateTo
        {
            get
            {
                return dtpConsumeDateTo.Text.Trim();
            }
            set
            {
                dtpConsumeDateTo.Text = value;
            }
        }

        public List<ReimburseCategoriesEnum> ReimburseCategoriesEnumDataSrc
        {
            set
            {
                ddlReimburseCategories.Items.Clear();
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




        private bool isTravelReimburse;
        public bool IsTravelReimburse
        {
            get
            {
                return isTravelReimburse;
            }
            set
            {
                if (!value)
                {
                    trDestinations.Style["display"] = "none";
                    trProject.Style["display"] = "none";
                    trremark.Style["display"] = "none";
                    isTravelReimburse = false;
                    lblTimeName.Text = "消费时间";
                    gvReimburseItem.Columns[2].Visible = true;
                }
                else
                {
                    trDestinations.Style["display"] = "block";
                    trProject.Style["display"] = "block";
                    trremark.Style["display"] = "block";
                    isTravelReimburse = true;
                    lblTimeName.Text = "出差时间";
                    gvReimburseItem.Columns[2].Visible = false;
                }
            }
        }











        public string OutCityAllowance
        {
            get { return txtOutCityAllowance.Text.Trim(); }
            set { txtOutCityAllowance.Text = value; }
        }


        public string OutCityDays
        {
            get { return txtOutCityDays.Text.Trim(); }
            set { txtOutCityDays.Text = value; }
        }


        public string Remark
        {
            get { return txtRemak.Text.Trim(); }
            set { txtRemak.Text = value; }
        }

        #endregion

        private void GetGridViewValue(List<ReimburseItem> reimburseItemList)
        {
            for (int i = 0; i < reimburseItemList.Count; i++)
            {
                TextBox txtCaculate =
                    (TextBox)gvReimburseItem.Rows[i].FindControl("txtCustomerInfo");
                if (txtCaculate != null)
                {
                    reimburseItemList[i].CustomerName = txtCaculate.Text.Trim();
                }
            }
        }

        private void SetGridViewDisplay(List<ReimburseItem> reimburseItemList)
        {
            for (int i = 0; i < reimburseItemList.Count; i++)
            {
                TextBox txtCaculate = (TextBox)gvReimburseItem.Rows[i].FindControl("txtCustomerInfo");
                txtCaculate.Text = reimburseItemList[i].CustomerName;
            }
        }
    }
}