using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.ChoseEmployee;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;
using SEP.HRMIS.Presenter.LeaveRequests;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.LeaveRequests
{
    public partial class LeaveRequestView : UserControl, ILeaveRequestInfoView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new ChoseEmployeePresenter(ChoseEmployeeView1, null);
            DefineOutSessionName();
            ChoseEmployeeView1.AttachAccountAjax += ChoseAccountAjax;
            ChoseEmployeeView1.SearchAjax += SearchAccountAjax;
        }

        private const string _JustForTestError = "仅用于测试";

        #region 属性
        public string Remind
        {
            get { return lblRemind.Text; }
            set
            {
                lblRemind.Text = value;
                lblRemind.Visible = !string.IsNullOrEmpty(value);
            }
        }
        public string ResultMessage
        {
            get { return lbResultMessage.Text.Trim(); }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    divResultMessage.Style["display"] = "none";
                }
                else
                {
                    divResultMessage.Style["display"] = "block";
                    lbResultMessage.Text = value;
                }
            }
        }

        public string RemarkMessage
        {
            get { return lbRemarkMessage.Text.Trim(); }
            set { lbRemarkMessage.Text = value; }
        }

        public string TypeMessage
        {
            get { return lbTypeMessage.Text.Trim(); }
            set { lbTypeMessage.Text = value; }
        }

        public string Remark
        {
            get { return tbRemark.Text.Trim(); }
            set { tbRemark.Text = value; }
        }

        public string EmployeeID
        {
            get { return hfEmployeeID.Value; }
            set { hfEmployeeID.Value = value; }
        }

        public string EmployeeName
        {
            get { return lbEmployeeName.Text.Trim(); }
            set { lbEmployeeName.Text = value; }
        }

        public string OperationType
        {
            get { return lbOperationType.Text.Trim(); }
            set { lbOperationType.Text = value; }
        }

        private bool _NotCalculate;
        public bool NotCalculate
        {
            get { return _NotCalculate; }
            set { _NotCalculate = value; }
        }

        public string LeaveRequestID
        {
            get { return lbID.Text.Trim().Split('#')[1]; }
            set { lbID.Text = " # " + value; }
        }

        public string TimeSpan
        {
            get { return lbDate.Text.Trim(); }
            set { lbDate.Text = value; }
        }

        public string CostTime
        {
            get { return lbCostTime.Text.Trim().Split(' ')[0]; }
            set { lbCostTime.Text = value + " 小时"; }
        }

        public LeaveRequestType LeaveRequestType
        {
            get
            {
                LeaveRequestType leaveType =
                    new LeaveRequestType(ddlAbsentType.SelectedItem.Text, "",
                    LegalHoliday.UnInclude, RestDay.UnInclude, 0);
                leaveType.LeaveRequestTypeID = Convert.ToInt32(ddlAbsentType.SelectedItem.Value);
                return leaveType;
            }
            set
            {
                ddlAbsentType.SelectedValue = value.LeaveRequestTypeID.ToString();
                lblTypeTitle.Text = value.Name;
                lblTypeDescription.Text = "最小单位：" + value.LeastHour + "小时。说明：" + value.Description;
            }
        }

        public List<LeaveRequestType> LeaveRequestTypeSource
        {
            get { throw new ArgumentNullException(_JustForTestError); }
            set
            {
                ddlAbsentType.Items.Clear();

                ListItem firstitem = new ListItem("", "-1", true);
                ddlAbsentType.Items.Add(firstitem);

                foreach (LeaveRequestType leaveRequestType in value)
                {
                    ListItem item =
                        new ListItem(leaveRequestType.Name, leaveRequestType.LeaveRequestTypeID.ToString(), true);
                    ddlAbsentType.Items.Add(item);
                }
            }
        }

        public string btnOKText
        {
            get { return BtnOK.Text; }
            set { BtnOK.Text = value; }
        }

        public string btnCancelText
        {
            get { return BtnSubmit.Text; }
            set { BtnSubmit.Text = value; }
        }

        public List<LeaveRequestItem> _LeaveRequests;

        public List<LeaveRequestItem> LeaveRequestItems
        {
            get { return _LeaveRequests; }
            set { _LeaveRequests = value; }
        }

        public List<LeaveRequestItem> LeaveRequestItemList
        {
            get
            {
                List<LeaveRequestItem> leaveRequestItemList =
                    (List<LeaveRequestItem>)ViewState["_LeaveRequestItemList"];
                GetGridViewValue(leaveRequestItemList);
                return leaveRequestItemList;
            }
            set
            {
                ViewState["_LeaveRequestItemList"] = value;
                gvLeaveRequestItemList.DataSource = value;
                gvLeaveRequestItemList.DataBind();

                if (value != null && value.Count != 0)
                {
                    SetGridViewDisplay(value);
                }
                if (value == null || value.Count == 0)
                {
                    tbLeaveRequestItem.Style["display"] = "none";
                }
                else
                {
                    tbLeaveRequestItem.Style["display"] = "block";
                    SetGridViewDisplay(value);
                }
            }
        }

        public bool SetFormReadOnly
        {
            set
            {
                ddlAbsentType.Enabled = !value;
                tbRemark.ReadOnly = value;
                txtMailCC.ReadOnly = value;
                SetEmunListColumnFalse(value);
            }
            get { return !ddlAbsentType.Enabled; }
        }

        private void SetEmunListColumnFalse(bool value)
        {
            for (int i = 0; i < gvLeaveRequestItemList.Rows.Count; i++)
            {
                TextBox tbStart = (TextBox)gvLeaveRequestItemList.Rows[i].FindControl("tbStart");
                DropDownList ddlStartHour = (DropDownList)gvLeaveRequestItemList.Rows[i].FindControl("ddlStartHour");
                DropDownList ddlStartMinute =
                    (DropDownList)gvLeaveRequestItemList.Rows[i].FindControl("ddlStartMinute");

                TextBox tbEnd = (TextBox)gvLeaveRequestItemList.Rows[i].FindControl("tbEnd");
                DropDownList ddlEndHour = (DropDownList)gvLeaveRequestItemList.Rows[i].FindControl("ddlEndHour");
                DropDownList ddlEndMinute = (DropDownList)gvLeaveRequestItemList.Rows[i].FindControl("ddlEndMinute");
                LinkButton btnUpdate = (LinkButton)gvLeaveRequestItemList.Rows[i].FindControl("btnUpdate");
                LinkButton btnDelete = (LinkButton)gvLeaveRequestItemList.Rows[i].FindControl("btnDelete");

                if (tbStart != null)
                {
                    tbStart.Enabled = !value;
                }
                if (tbEnd != null)
                {
                    tbEnd.Enabled = !value;
                }
                if (ddlStartHour != null)
                {
                    ddlStartHour.Enabled = !value;
                }
                if (ddlStartMinute != null)
                {
                    ddlStartMinute.Enabled = !value;
                }
                if (ddlEndHour != null)
                {
                    ddlEndHour.Enabled = !value;
                }
                if (ddlEndMinute != null)
                {
                    ddlEndMinute.Enabled = !value;
                }
                if (btnUpdate != null)
                {
                    btnUpdate.Visible = value;
                }
                if (btnDelete != null)
                {
                    btnDelete.Visible = value;
                }
            }
        }

        //public bool SetFormCancel
        //{
        //    set
        //    {
        //        for (int i = 0; i < gvLeaveRequestItemList.Rows.Count; i++)
        //        {
        //            LinkButton btnUpdate = (LinkButton) gvLeaveRequestItemList.Rows[i].FindControl("btnUpdate");
        //            LinkButton btnDelete = (LinkButton)gvLeaveRequestItemList.Rows[i].FindControl("btnDelete");

        //            if (btnUpdate != null)
        //            {
        //                btnUpdate.Visible = value;
        //            }
        //            if (btnDelete != null)
        //            {
        //                btnDelete.Visible = value;
        //            }
        //        }
        //    }
        //}

        //public AttendanceRule EmployeeAttendanceRule
        //{
        //    get { throw new NotImplementedException(); }
        //    set
        //    {
        //        if (value == null)
        //        {
        //            trRule.Style["display"] = "none";
        //        }
        //        else
        //        {
        //            trRule.Style["display"] = "block";
        //            lblMorningRule.Text = "上午" + value.MorningStartTime.ToShortTimeString() + "---" +
        //                                  value.MorningEndTime.ToShortTimeString();
        //            lblAfternoonTimeRule.Text = "下午" + value.AfternoonStartTime.ToShortTimeString() + "---" +
        //                                        value.AfternoonEndTime.ToShortTimeString();
        //        }
        //    }
        //}

        public decimal? AnnualLeave
        {
            get
            {
                string annualLeave = lbAnnualLeave.Text;
                decimal iRet;
                if (decimal.TryParse(annualLeave, out iRet))
                {
                    return iRet;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                StringBuilder txtAnnualLeave = new StringBuilder();
                txtAnnualLeave.Append("剩余年假");
                txtAnnualLeave.Append(value);
                txtAnnualLeave.Append("小时");
                lbAnnualLeave.Text = txtAnnualLeave.ToString();
                lbAnnualLeave.Visible = !string.IsNullOrEmpty(value.ToString());
            }
        }

        #endregion

        #region MailCC

        private void DefineOutSessionName()
        {
            ChoseEmployeeView1.AccountRightViewStateName = "MailCCRight";
            ChoseEmployeeView1.AccountLeftViewStateName = "MailCCLeft";
        }

        private void ChoseAccountAjax(object sender, EventArgs e)
        {
            txtMailCC.Text = RequestUtility.GetEmployeeNames(ChoseEmployeeView1.AccountRight);
            mpeChooseEmployee.Show();
        }

        private void SearchAccountAjax(object sender, EventArgs e)
        {
            mpeChooseEmployee.Show();
        }

        public List<Account> MailCC
        {
            get { return ChoseEmployeeView1.AccountRight; }
            set { ChoseEmployeeView1.AccountRight = value; }
        }

        #endregion
        #region 事件

        public event EventHandler ddlAbsentTypeSelected;
        protected void ddlAbsentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlAbsentTypeSelected(null, null);
            SetHour(LeaveRequestItemList);
        }

        public event EventHandler btnOKClick;
        protected void BtnOK_Click(object sender, EventArgs e)
        {
            if (GetGridViewValue(LeaveRequestItemList))
            {
                ResultMessage = "<span class='fontred'>时间格式错误</span>";
                return;
            }
            ReCalculateHour(LeaveRequestItemList);
            foreach (LeaveRequestItem item in LeaveRequestItemList)
            {
                if (item.CostTime == 0)
                {
                    ResultMessage = "请假项中有0小时项";
                    return;
                }
            }
            btnOKClick(sender, e);
        }

        public event EventHandler btnSubmitClick;
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (GetGridViewValue(LeaveRequestItemList))
            {
                ResultMessage = "<span class='fontred'>时间格式错误</span>";
                return;
            }
            ReCalculateHour(LeaveRequestItemList);
            foreach (LeaveRequestItem item in LeaveRequestItemList)
            {
                if (item.CostTime == 0)
                {
                    ResultMessage = "请假项中有0小时项";
                    return;
                }
            }
            btnSubmitClick(sender, e);
        }

        public event DelegateID LeaveRequestItemForDeleteAtEvent;
        protected void lbDeleteItem_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbDeleteItem = sender as LinkButton;
            if (lbDeleteItem == null)
            {
                return;
            }
            GridViewRow row = lbDeleteItem.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            if (LeaveRequestItemForDeleteAtEvent != null)
            {
                LeaveRequestItemForDeleteAtEvent(row.RowIndex.ToString());
            }
        }

        public event DelegateID LeaveRequestItemForAddAtEvent;
        protected void lbAddItem_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbAddItem = sender as LinkButton;
            if (lbAddItem == null)
            {
                return;
            }
            GridViewRow row = lbAddItem.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            if (LeaveRequestItemForAddAtEvent != null)
            {
                LeaveRequestItemForAddAtEvent(row.RowIndex.ToString());
            }
        }

        protected void gvLeaveRequestItemList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }

        #endregion

        #region LeaveRequestItmList 内部方法

        private bool timeerror;
        private bool GetGridViewValue(IList<LeaveRequestItem> leaveRequestItemList)
        {
            timeerror = false;
            for (int i = 0; i < leaveRequestItemList.Count; i++)
            {
                Label lbl = (Label)gvLeaveRequestItemList.Rows[i].FindControl("lbl");
                TextBox tbStart = (TextBox)gvLeaveRequestItemList.Rows[i].FindControl("tbStart");
                DropDownList ddlStartHour = (DropDownList)gvLeaveRequestItemList.Rows[i].FindControl("ddlStartHour");
                DropDownList ddlStartMinute =
                    (DropDownList)gvLeaveRequestItemList.Rows[i].FindControl("ddlStartMinute");

                TextBox tbEnd = (TextBox)gvLeaveRequestItemList.Rows[i].FindControl("tbEnd");
                DropDownList ddlEndHour = (DropDownList)gvLeaveRequestItemList.Rows[i].FindControl("ddlEndHour");
                DropDownList ddlEndMinute = (DropDownList)gvLeaveRequestItemList.Rows[i].FindControl("ddlEndMinute");

                if (lbl != null)
                {
                    try
                    {
                        leaveRequestItemList[i].LeaveRequestItemID = Convert.ToInt32(lbl.Text.Trim());
                    }
                    catch
                    {
                        leaveRequestItemList[i].LeaveRequestItemID = -1;
                    }
                }

                DateTime fromDate;
                if ((tbStart != null && ddlStartHour != null && ddlStartMinute != null)
                    &&
                    (DateTime.TryParse(
                        tbStart.Text + " " + ddlStartHour.SelectedValue + ":" + ddlStartMinute.SelectedValue + ":00",
                        out fromDate)))
                {
                    leaveRequestItemList[i].FromDate = fromDate;
                }
                else
                {
                    timeerror = true;
                }
                DateTime toDate;
                if ((tbEnd != null && ddlEndHour != null && ddlEndMinute != null)
                    &&
                    (DateTime.TryParse(
                        tbEnd.Text + " " + ddlEndHour.SelectedValue + ":" + ddlEndMinute.SelectedValue + ":00",
                        out toDate)))
                {
                    leaveRequestItemList[i].ToDate = toDate;
                }
                else
                {
                    timeerror = true;
                }

                TextBox txtCaculate = (TextBox)gvLeaveRequestItemList.Rows[i].FindControl("txtCaculate");
                if (txtCaculate != null)
                {
                    decimal decimalData;
                    if (decimal.TryParse(txtCaculate.Text.Trim(), out decimalData))
                    {
                        leaveRequestItemList[i].CostTime = Convert.ToDecimal(txtCaculate.Text.Trim());
                    }
                }
            }
            return timeerror;
        }

        private void SetGridViewDisplay(IList<LeaveRequestItem> leaveRequestItemList)
        {
            for (int i = 0; i < leaveRequestItemList.Count; i++)
            {
                SetGridViewRowCaculateDisplay(i, leaveRequestItemList);
                SetGridViewRowFromToDateDisplay(i, leaveRequestItemList);
                SetGridViewRowLinkButtonDisplay(i);
            }
            SetHour(leaveRequestItemList);
        }

        private void SetGridViewRowFromToDateDisplay(int rowIndex, IList<LeaveRequestItem> leaveRequestItemList)
        {
            TextBox tbStart = (TextBox)gvLeaveRequestItemList.Rows[rowIndex].FindControl("tbStart");
            TextBox tbEnd = (TextBox)gvLeaveRequestItemList.Rows[rowIndex].FindControl("tbEnd");
            DropDownList ddlStartHour = (DropDownList)gvLeaveRequestItemList.Rows[rowIndex].FindControl("ddlStartHour");
            DropDownList ddlStartMinute =
                (DropDownList)gvLeaveRequestItemList.Rows[rowIndex].FindControl("ddlStartMinute");
            DropDownList ddlEndHour = (DropDownList)gvLeaveRequestItemList.Rows[rowIndex].FindControl("ddlEndHour");
            DropDownList ddlEndMinute = (DropDownList)gvLeaveRequestItemList.Rows[rowIndex].FindControl("ddlEndMinute");

            if (tbStart == null || tbEnd == null || ddlStartHour == null || ddlStartMinute == null || ddlEndHour == null ||
                ddlEndMinute == null)
            {
                return;
            }

            if (leaveRequestItemList[rowIndex] != null)
            {
                tbStart.Text = leaveRequestItemList[rowIndex].FromDate.Date.ToString();
                ddlStartHour.SelectedValue = leaveRequestItemList[rowIndex].FromDate.Hour.ToString();
                ddlStartMinute.SelectedValue = leaveRequestItemList[rowIndex].FromDate.Minute.ToString();
                tbEnd.Text = leaveRequestItemList[rowIndex].ToDate.Date.ToString();
                ddlEndHour.SelectedValue = leaveRequestItemList[rowIndex].ToDate.Hour.ToString();
                ddlEndMinute.SelectedValue = leaveRequestItemList[rowIndex].ToDate.Minute.ToString();
                tbStart.Attributes["onblur"] = "AjaxCount(this);";
                tbEnd.Attributes["onblur"] = "AjaxCount(this);";
                ddlStartHour.Attributes["onchange"] = "AjaxCount(this);";
                ddlStartMinute.Attributes["onchange"] = "AjaxCount(this);";
                ddlEndHour.Attributes["onchange"] = "AjaxCount(this);";
                ddlEndMinute.Attributes["onchange"] = "AjaxCount(this);";

            }
        }
        /// <summary>
        /// 重新计算小时数
        /// </summary>
        private void ReCalculateHour(IEnumerable<LeaveRequestItem> leaveRequestItemList)
        {
            if (NotCalculate == false)
            {
                int i = 0;
                foreach (LeaveRequestItem item in leaveRequestItemList)
                {
                    TextBox txtCaculate = (TextBox)gvLeaveRequestItemList.Rows[i].FindControl("txtCaculate");
                    string ans = new CalculateLeaveRequestPresenter(item.FromDate.Date.ToString(),
                                                           item.FromDate.Hour.ToString(),
                                                           item.FromDate.Minute.ToString(),
                                                           item.ToDate.Date.ToString(),
                                                           item.ToDate.Hour.ToString(),
                                                           item.ToDate.Minute.ToString(),
                                                           Convert.ToInt32(hfEmployeeID.Value),
                                                           Convert.ToInt32(ddlAbsentType.SelectedItem.Value)).GetHour();
                    if (ans == "error")
                    {
                        txtCaculate.Text = "0";
                        item.CostTime = 0;
                    }
                    else
                    {
                        txtCaculate.Text = ans;
                        item.CostTime = Convert.ToDecimal(ans);
                    }
                    i++;
                }
            }

        }

        /// <summary>
        /// 计算小时
        /// </summary>
        /// <param name="leaveRequestItemList"></param>
        private void SetHour(IList<LeaveRequestItem> leaveRequestItemList)
        {
            if (NotCalculate == false)
            {
                decimal allHour = 0;
                DateTime minFromTime = leaveRequestItemList[0].FromDate;
                DateTime maxToTime = leaveRequestItemList[0].ToDate;
                for (int i = 0; i < leaveRequestItemList.Count; i++)
                {
                    string ans =
                        new CalculateLeaveRequestPresenter(leaveRequestItemList[i].FromDate.Date.ToString(),
                                                           leaveRequestItemList[i].FromDate.Hour.ToString(),
                                                           leaveRequestItemList[i].FromDate.Minute.ToString(),
                                                           leaveRequestItemList[i].ToDate.Date.ToString(),
                                                           leaveRequestItemList[i].ToDate.Hour.ToString(),
                                                           leaveRequestItemList[i].ToDate.Minute.ToString(),
                                                           Convert.ToInt32(hfEmployeeID.Value),
                                                           Convert.ToInt32(ddlAbsentType.SelectedItem.Value)).GetHour();
                    TextBox txtCaculate = (TextBox)gvLeaveRequestItemList.Rows[i].FindControl("txtCaculate");
                    HtmlImage imgResultCaculate =
                        (HtmlImage)gvLeaveRequestItemList.Rows[i].FindControl("imgResultCaculate");
                    if (ans == "error")
                    {
                        txtCaculate.Text = "0";
                        imgResultCaculate.Src = "../../../Pages/image/wrong_icon.gif";
                        imgResultCaculate.Style["display"] = "block";
                    }
                    else
                    {
                        txtCaculate.Text = ans;
                        imgResultCaculate.Style["display"] = "none";
                    }
                    allHour += Convert.ToDecimal(txtCaculate.Text);
                    if (minFromTime > leaveRequestItemList[i].FromDate)
                    {
                        minFromTime = leaveRequestItemList[i].FromDate;
                    }
                    if (maxToTime < leaveRequestItemList[i].ToDate)
                    {
                        maxToTime = leaveRequestItemList[i].ToDate;
                    }
                }
                lbCostTime.Text = string.Format("{0}小时", allHour);
                lbDate.Text = string.Format("{0} ～ {1}", minFromTime, maxToTime);
            }
        }

        private void SetGridViewRowCaculateDisplay(int rowIndex, IList<LeaveRequestItem> leaveRequestItemList)
        {
            TextBox txtCaculate = (TextBox)gvLeaveRequestItemList.Rows[rowIndex].FindControl("txtCaculate");
            HtmlImage imgResultCaculate =
                (HtmlImage)gvLeaveRequestItemList.Rows[rowIndex].FindControl("imgResultCaculate");
            if (txtCaculate == null)
            {
                return;
            }

            txtCaculate.Style["display"] = "none";

            if (leaveRequestItemList[rowIndex] != null)
            {
                txtCaculate.Text = leaveRequestItemList[rowIndex].CostTime.ToString();
                txtCaculate.Style["display"] = "block";

                txtCaculate.Attributes["onblur"] = "postRequestServer1('" + imgResultCaculate.ClientID + "','" +
                                                   leaveRequestItemList[rowIndex].CostTime + "',this.value);";
            }
        }

        private void SetGridViewRowLinkButtonDisplay(int rowIndex)
        {
            LinkButton lbAddItem = (LinkButton)gvLeaveRequestItemList.Rows[rowIndex].FindControl("lbAddItem");
            if (lbAddItem != null)
            {
                lbAddItem.Text = "<img src=../../../Pages/image/file_new.gif border=0>";
            }
            LinkButton lbDeleteItem = (LinkButton)gvLeaveRequestItemList.Rows[rowIndex].FindControl("lbDeleteItem");
            if (lbDeleteItem != null)
            {
                lbDeleteItem.Text = "<img src=../../../Pages/image/file_cancel.gif border=0>";
            }
        }

        #endregion
    }
}