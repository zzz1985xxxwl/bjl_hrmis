using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.Model.Departments;
using ShiXin.Security;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.HRMIS.Reimburse
{
    public partial class SearchTravelReimburseView : UserControl, ISearchTravelReimburseView
    {
        public bool IsAutoCompleteCoutomer
        {
            set { IsAutoCustomer.Value = value ? "1" : "0"; }
        }

        #region ISearchTravelReimburseView 成员

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        public string EmployeeName
        {
            get { return txtEmployeeName.Text.Trim(); }
        }

        public string Destinations
        {
            get { return txtDestinations.Text.Trim(); }
        }

        public string CustomerName
        {
            get { return txtCustomerName.Text.Trim(); }
        }

        public string ProjectName
        {
            get { return txtProjectName.Text.Trim(); }
        }

        public string ApplyDateMsg
        {
            get { throw new NotImplementedException(); }
            set { lblApplyDateMsg.Text = value; }
        }

        public string ApplyDateFrom
        {
            get { return dtpApplyDateFrom.Text.Trim(); }
        }

        public string ApplyDateTo
        {
            get { return dtpApplyDateTo.Text.Trim(); }
        }
        public int DepartMentID
        {
            get { return Convert.ToInt32(ddDepartment.SelectedValue); }
        }
        public List<Department> DepartmentSource
        {
            set
            {
                ddDepartment.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, "-1", true);
                ddDepartment.Items.Add(itemAll);
                foreach (Department department in value)
                {
                    ListItem item = new ListItem(department.DepartmentName, department.DepartmentID.ToString(), true);
                    ddDepartment.Items.Add(item);
                }
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
            set { txtBillingFrom.Text = value; }
        }

        public string BillingTimeTo
        {
            get { return txtBillingTo.Text.Trim(); }
            set { txtBillingTo.Text = value; }
        }

        public string BillingTimeMsg
        {
            set { lblBillingMsg.Text = value; }
        }

        private List<ReimburseTotal> _ReimburseTotalListSource;

        public List<ReimburseTotal> ReimburseTotalListSource
        {
            get { return _ReimburseTotalListSource; }
            set
            {
                _ReimburseTotalListSource = value;
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

        public string LongTripTotal
        {
            set { lblLongTripTotal.Text = value; }
        }

        public string ShortTripTotal
        {
            set { lblShortTripTotal.Text = value; }
        }

        public string LodgingTotal
        {
            set { lblLodgingTotal.Text = value; }
        }

        public string EntertainmentTotal
        {
            set { lblEntertainmentTotal.Text = value; }
        }

        public string OtherTotal
        {
            set { lblOtherTotal.Text = value; }
        }

        public string MealTotal
        {
            set { lblMeal.Text = value; }
        }

        public string CityTrafficTotalTotal
        {
            set { lblCityTraffic.Text = value; }
        }

        public string Total
        {
            set { lblTotal.Text = value; }
        }

        public string OutCityAllowanceTotal
        {
            set { lblOutCityAllowanceTotal.Text = value; }
        }

        public string Remark
        {
            get { return txtRemark.Text.Trim(); }
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

        public event EventHandler btnSearchClick;

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearchClick(null, null);
        }

        private void Detail_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect(
                "ReimburseIsTravelDetail.aspx?ReimburseID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()),
                false);
        }

        protected void gvReimburseList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Detail_Command(sender, e);
                    return;
            }
        }

        public event CommandEventHandler btnViewClick;

        protected void gvReimburseList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }

        /// <summary>
        /// 导出
        /// </summary>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            btnSearchClick(null, null);
            StringWriter theMemoryWriter = new StringWriter();
            StringBuilder reimburse = new StringBuilder();
            reimburse.Append("月份\t");
            reimburse.Append("员工姓名\t");
            reimburse.Append("报销类型\t");
            reimburse.Append("长途\t");
            reimburse.Append("短途\t");
            reimburse.Append("住宿\t");
            reimburse.Append("交际应酬\t");
            reimburse.Append("市内交通费\t");
            reimburse.Append("餐费\t");
            reimburse.Append("其他\t");
            reimburse.Append("出差补贴\t");
            reimburse.Append("小计\t");
            reimburse.Append("客户名称\t");
            reimburse.Append("说明\t");
            reimburse.Append("备注\t");
            reimburse.Append("出差地点\t");
            reimburse.Append("出差天数\t");
            reimburse.Append("出差项目\t");
            reimburse.Append("出差时间\t");
            theMemoryWriter.WriteLine(reimburse);
            if (ReimburseTotalListSource != null)
            {
                foreach (ReimburseTotal total in _ReimburseTotalListSource)
                {
                    reimburse = new StringBuilder();
                    reimburse.Append(total.Month).Append("\t");
                    reimburse.Append(total.Name).Append("\t");
                    reimburse.Append(total.ReimburseCategories.Name).Append("\t");
                    reimburse.Append(total.LongTripTotal).Append("\t");
                    reimburse.Append(total.ShortTripTotal).Append("\t");
                    reimburse.Append(total.LodgingTotal).Append("\t");
                    reimburse.Append(total.EntertainmentTotal).Append("\t");
                    reimburse.Append(total.CityTrafficTotalCost).Append("\t");
                    reimburse.Append(total.MealTotalCost).Append("\t");
                    reimburse.Append(total.OtherTotal).Append("\t");
                    reimburse.Append(total.OutCityAllowance).Append("\t");
                    reimburse.Append(total.Total).Append("\t");
                    reimburse.Append((total.CustomerName??"").Replace("\r","").Replace("\n","")).Append("\t");
                    reimburse.Append((total.Discription ?? "").Replace("\r", "").Replace("\n", "")).Append("\t");
                    reimburse.Append((total.Remark ?? "").Replace("\r", "").Replace("\n", "")).Append("\t");
                    reimburse.Append((total.Place ?? "").Replace("\r", "").Replace("\n", "")).Append("\t");
                    reimburse.Append(total.OutCityDays).Append("\t");
                    reimburse.Append((total.Projuct ?? "").Replace("\r", "").Replace("\n", "")).Append("\t");
                    reimburse.Append(total.StartTime).Append("--").Append(total.EndTime).Append("\t");
                    theMemoryWriter.WriteLine(reimburse);
                }
            }


            reimburse = new StringBuilder();
            reimburse.Append("\t");
            reimburse.Append("\t");
            reimburse.Append("总计\t");
            reimburse.Append(lblLongTripTotal.Text).Append("\t");
            reimburse.Append(lblShortTripTotal.Text).Append("\t");
            reimburse.Append(lblLodgingTotal.Text).Append("\t");
            reimburse.Append(lblEntertainmentTotal.Text).Append("\t");
            reimburse.Append(lblCityTraffic.Text).Append("\t");
            reimburse.Append(lblMeal.Text).Append("\t");
            reimburse.Append(lblOtherTotal.Text).Append("\t");
            reimburse.Append(lblOutCityAllowanceTotal.Text).Append("\t");
            reimburse.Append(lblTotal.Text).Append("\t");
            theMemoryWriter.WriteLine(reimburse);

            Response.Charset = "GB2312";
            Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            Response.AppendHeader("Content-Disposition",
                                  "attachment;filename=" + HttpUtility.UrlEncode("报销.xls", Encoding.UTF8));
            Response.ContentType = "application/ms-excel";
            EnableViewState = false;
            Response.Write(theMemoryWriter.ToString());
            Response.End();
            theMemoryWriter.Close();
        }

        protected void ddlReimburseCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrTravelDisplay();
        }

        private void TrTravelDisplay()
        {
            trTravel.Style["display"] = ddlReimburseCategories.SelectedValue.Equals("0") ? "block" : "none";
        }

        private DataTable _gvSearchReimburseTableSource;

        public DataTable gvSearchReimburseTableSource
        {
            get { return _gvSearchReimburseTableSource; }
            set
            {
                _gvSearchReimburseTableSource = value;
                if (value == null || value.Rows.Count == 0)
                {
                    tbSearch.Style["display"] = "none";
                }
                else
                {
                    //Session[SessionKeys.gvEmployeeStatisticsTableSource] = value;

                    dgSearchReimburse.DataSource = value;
                    dgSearchReimburse.DataBind();
                    tbSearch.Style["display"] = "block";
                    BindPageIndex(Convert.ToInt32(lblCurrentPageIndex.Text) - 1);
                }
            }
        }

        protected void dgSearchReimburse_RowDataBound(object sender, DataGridItemEventArgs e)
        {
            ViewUtility.DataGridCellCssBind(e, _gvSearchReimburseTableSource.Rows.Count);
            ViewUtility.RowMouseOver(e, ViewUtility.MouseStyle_Default);
            e.Item.Cells[2].Attributes["nowrap"] = "nowrap"; //报销类型
            e.Item.Cells[14].Attributes["nowrap"] = "nowrap"; //出差地点
            e.Item.Cells[17].Attributes["nowrap"] = "nowrap"; //出差时间
            e.Item.Cells[18].Attributes["nowrap"] = "nowrap"; //查看详情
            e.Item.Cells[12].Attributes["width"] = "120px"; //客户名称
            e.Item.Cells[12].Attributes["width"] = "120px"; //备注
        }

        //protected void LinkButtonPreviousPage_Click(object sender, EventArgs e)
        //{
        //    lblCurrentPageIndex.Text = (Convert.ToInt32(lblCurrentPageIndex.Text.Trim()) - 1).ToString();
        //    BindPageIndex(Convert.ToInt32(lblCurrentPageIndex.Text));
        //    btnSearchClick(null, null);
        //}

        //protected void LinkButtonNextPage_Click(object sender, EventArgs e)
        //{
        //    lblCurrentPageIndex.Text = (Convert.ToInt32(lblCurrentPageIndex.Text.Trim()) + 1).ToString();
        //    BindPageIndex(Convert.ToInt32(lblCurrentPageIndex.Text));
        //    btnSearchClick(null, null);
        //}

        private void BindPageIndex(int index)
        {
            dgSearchReimburse.CurrentPageIndex = index;
            lblAllPage.Text = dgSearchReimburse.PageCount.ToString();
            LinkButtonPreviousPage.Enabled = index > 0;
            LinkButtonFirstPage.Enabled = index > 0;
            LinkButtonNextPage.Enabled = index < dgSearchReimburse.PageCount -1;
            LinkButtonLastPage.Enabled = index < dgSearchReimburse.PageCount -1;
        }

        protected void Page_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "Prev")
            {
                lblCurrentPageIndex.Text = (Convert.ToInt32(lblCurrentPageIndex.Text.Trim()) - 1).ToString();
                BindPageIndex(Convert.ToInt32(lblCurrentPageIndex.Text) - 1);
                btnSearchClick(null, null);
            }
            else if (e.CommandArgument.ToString() == "First")
            {
                lblCurrentPageIndex.Text = "1";
                BindPageIndex(Convert.ToInt32(lblCurrentPageIndex.Text) - 1);
                btnSearchClick(null, null);
            }
            else if (e.CommandArgument.ToString() == "Last")
            {
                lblCurrentPageIndex.Text = lblAllPage.Text;
                BindPageIndex(Convert.ToInt32(lblCurrentPageIndex.Text) - 1);
                btnSearchClick(null, null);
            }
            else
            {
                lblCurrentPageIndex.Text = (Convert.ToInt32(lblCurrentPageIndex.Text.Trim()) + 1).ToString();
                BindPageIndex(Convert.ToInt32(lblCurrentPageIndex.Text) - 1);
                btnSearchClick(null, null);
            }
        }

        protected void LinkButtonGoPage_Click(object sender, EventArgs e)
        {
            int index;
            if (int.TryParse(txtGoPage.Text.Trim(), out index))
            {
                index = index < 1 ? 1 : index;
                index = index > Convert.ToInt32(lblAllPage.Text) ? Convert.ToInt32(lblAllPage.Text) : index;
                lblCurrentPageIndex.Text = index.ToString();
                BindPageIndex(Convert.ToInt32(lblCurrentPageIndex.Text) - 1);
                btnSearchClick(null, null);
                txtGoPage.Text = "";
            }
        }
    }
}