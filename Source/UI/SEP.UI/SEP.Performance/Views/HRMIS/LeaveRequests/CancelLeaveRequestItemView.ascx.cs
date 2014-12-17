using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequest;

namespace SEP.Performance.Views.HRMIS.LeaveRequests
{
    public partial class CancelLeaveRequestItemView : UserControl, ICancelLeaveRequestItemView
    {
        private const string _JustForTestError = "仅用于测试";

        #region 属性

        public int OperationID
        {
            get
            {
                return Convert.ToInt32(hfOperatorID.Value);
            }
            set
            {
                hfOperatorID.Value = value.ToString();
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

        public List<LeaveRequestItem> LeaveRequestItemList
        {
            get
            {
                return GetGridViewValue();
            }
            set
            {
                ViewState["_LeaveRequestItemList"] = value;
                gvLeaveRequestItemList.DataSource = value;
                gvLeaveRequestItemList.DataBind();
                SetGridViewValue(value);
                if (value != null && value.Count != 0)
                {
                    tbLeaveRequestItem.Style["display"] = "block";
                }
                else
                {
                    tbLeaveRequestItem.Style["display"] = "none";
                }
            }
        }

        private void SetGridViewValue(List<LeaveRequestItem> items)
        {
            for (int i = 0; i < gvLeaveRequestItemList.Rows.Count; i++)
            {
                DropDownList ddlStatus = (DropDownList) gvLeaveRequestItemList.Rows[i].FindControl("ddlStatus");
                Label tbStatusID = (Label) gvLeaveRequestItemList.Rows[i].FindControl("tbStatusID");
                ddlStatus.Items.Clear();

                //-1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消假期;6 批准取消假期;7 审核中;8 取消审核中
                Dictionary<string, string> statusSource = new Dictionary<string, string>();
                if (OperationType == "取消请假")
                {
                    switch (tbStatusID.Text)
                    {
                        case "1":
                        case "3":
                        case "7":
                            statusSource = _ApproveCancelStatusSource;
                            break;
                    }
                }
                else if (OperationType == "审核请假")
                {
                    switch (tbStatusID.Text)
                    {
                        case "1":
                        case "7":
                            statusSource = _ApproveSubmitStatusSource;
                            break;
                        case "4":
                        case "8":
                            statusSource = _ApproveCancelStatusSource;
                            break;
                    }
                }
                if (statusSource != null && statusSource.Count > 0)
                {
                    foreach (KeyValuePair<string, string> pair in statusSource)
                    {
                        ListItem item = new ListItem(pair.Value, pair.Key, true);
                        ddlStatus.Items.Add(item);
                    }
                    ddlStatus.SelectedValue = items[i].Status.Name;
                }
            }
        }

        private List<LeaveRequestItem> GetGridViewValue()
        {
            List<LeaveRequestItem> iRet = new List<LeaveRequestItem>();
            for (int i = 0; i < gvLeaveRequestItemList.Rows.Count; i++)
            {
                TextBox txtRemark = (TextBox) gvLeaveRequestItemList.Rows[i].FindControl("txtRemark");
                CheckBox chbId = (CheckBox)gvLeaveRequestItemList.Rows[i].FindControl("chbId");

                DropDownList ddlStatus = (DropDownList)gvLeaveRequestItemList.Rows[i].FindControl("ddlStatus");

                if (chbId.Checked)
                {
                    LeaveRequestItem item = new LeaveRequestItem(Convert.ToInt32(chbId.Text));
                    item.Remark = txtRemark.Text.Trim();
                    item.Status = new RequestStatus(Convert.ToInt32(ddlStatus.SelectedValue), ddlStatus.SelectedItem.Text);
                    iRet.Add(item);
                }
            }
            return iRet;
        }

        public bool SetFormReadOnly
        {
            set
            {
                ddlAbsentType.Enabled = !value;
                tbRemark.ReadOnly = value;
            }
            get
            {
                return !ddlAbsentType.Enabled;
            }
        }

        public bool SetFormCancel
        {
            set
            {
                for (int i = 0; i < gvLeaveRequestItemList.Rows.Count; i++)
                {
                    LinkButton btnUpdate = (LinkButton)gvLeaveRequestItemList.Rows[i].FindControl("btnUpdate");
                    LinkButton btnDelete = (LinkButton)gvLeaveRequestItemList.Rows[i].FindControl("btnDelete");

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
        }

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

        private Dictionary<string, string> _ApproveSubmitStatusSource;
        public Dictionary<string, string> ApproveSubmitStatusSource
        {
            set
            {
                _ApproveSubmitStatusSource = value;
            }
        }

        private Dictionary<string, string> _ApproveCancelStatusSource;
        public Dictionary<string, string> ApproveCancelStatusSource
        {
            set
            {
                _ApproveCancelStatusSource = value;
            }
        }

        #endregion

        public event EventHandler btnOKClick;
        protected void BtnOK_Click(object sender, EventArgs e)
        {
            btnOKClick(sender, e);
        }

        public event EventHandler btnCancelClick;
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            btnCancelClick(sender, e);
        }

        protected void gvLeaveRequestItemList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }


    }
}