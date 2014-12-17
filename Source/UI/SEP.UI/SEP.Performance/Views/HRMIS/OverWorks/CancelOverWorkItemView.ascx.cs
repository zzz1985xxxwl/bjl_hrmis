using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using SEP.HRMIS.Presenter.OutApplications;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.OverWorks
{
    public partial class CancelOverWorkItemView : UserControl, ICancelOverWorkItemView
    {
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

        public string Reason
        {
            get { return tbReason.Text.Trim(); }
            set { tbReason.Text = value; }
        }

        public string OutLocation
        {
            get { return txtOutLoacation.Text.Trim(); }
            set { txtOutLoacation.Text = value; }
        }

        public int EmployeeID
        {
            get { return Convert.ToInt32(hfEmployeeID.Value); }
            set { hfEmployeeID.Value = value.ToString(); }
        }

        public string EmployeeName
        {
            get { return lbEmployeeName.Text.Trim(); }
            set { lbEmployeeName.Text = value; }
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

        public OperationType OperationType
        {
            get { return (OperationType) ViewState["OperationType"]; }
            set
            {
                ViewState["OperationType"] = value;
                ViewState["OperationType"] = value;
                if (value == OperationType.Confirm)
                {
                    lbOperationType.Text = "审核加班";
                }
                else
                {
                    lbOperationType.Text = "取消加班";
                }
            }
        }


        public int ApplicationID
        {
            get
            {
                if (string.IsNullOrEmpty(Request.QueryString["PKID"]))
                {
                    return 0;
                }
                return Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["PKID"]));
            }
            set { }
        }

        private Dictionary<string, string> _ApproveStatusSource;

        public Dictionary<string, string> ApproveStatusSource
        {
            set { _ApproveStatusSource = value; }
        }


        public List<OverWorkItem> ApplicationItemList
        {
            get { return GetGridViewValue(); }
            set
            {
                ViewState["ApplicationItemList"] = value;
                gvOverWork.DataSource = value;
                gvOverWork.DataBind();
                SetGridViewValue(value);
            }
        }

        private void SetGridViewValue(IList<OverWorkItem> items)
        {
            for (int i = 0; i < gvOverWork.Rows.Count; i++)
            {
                DropDownList ddlStatus = (DropDownList) gvOverWork.Rows[i].FindControl("ddlStatus");
                Label tbStatusID = (Label) gvOverWork.Rows[i].FindControl("tbStatusID");
                DropDownList ddlAdjust = (DropDownList) gvOverWork.Rows[i].FindControl("ddlAdjust");
                ddlStatus.Items.Clear();

                //-1 全部;0 新增;1 提交;2 审核不通过;3 审核通过;4 取消请假;5 拒绝取消;6 批准取消;7 审核中;8 取消审核中
                Dictionary<string, string> statusSource = new Dictionary<string, string>();
                if (OperationType == OperationType.Cancel)
                {
                    switch (tbStatusID.Text)
                    {
                        case "1":
                        case "3":
                            statusSource = _ApproveStatusSource;
                            break;
                    }
                }
                else if (OperationType == OperationType.Confirm)
                {
                    switch (tbStatusID.Text)
                    {
                        case "1":
                        case "7":
                        case "4":
                        case "8":
                            statusSource = _ApproveStatusSource;
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
                if (ddlAdjust != null)
                {
                    ddlAdjust.SelectedIndex = items[i].Adjust ? 0 : 1;
                }
            }
        }

        private List<OverWorkItem> GetGridViewValue()
        {
            List<OverWorkItem> iRet = new List<OverWorkItem>();
            for (int i = 0; i < gvOverWork.Rows.Count; i++)
            {
                TextBox txtRemark = (TextBox) gvOverWork.Rows[i].FindControl("txtRemark");
                CheckBox chbId = (CheckBox) gvOverWork.Rows[i].FindControl("chbId");
                DropDownList ddlAdjust = (DropDownList) gvOverWork.Rows[i].FindControl("ddlAdjust");
                DropDownList ddlStatus = (DropDownList) gvOverWork.Rows[i].FindControl("ddlStatus");
                TextBox txtAdjustHour = (TextBox) gvOverWork.Rows[i].FindControl("txtAdjustHour");
                if (chbId.Checked)
                {
                    OverWorkItem item = new OverWorkItem(Convert.ToInt32(chbId.Text));
                    List<OverWorkFlow> OverWorkFlowList = new List<OverWorkFlow>();
                    OverWorkFlowList.Add(new OverWorkFlow(txtRemark.Text.Trim()));
                    item.OverWorkFlow = OverWorkFlowList;
                    item.Status =
                        new RequestStatus(Convert.ToInt32(ddlStatus.SelectedValue), ddlStatus.SelectedItem.Value);
                    item.Adjust = ddlAdjust.SelectedIndex == 0;
                    item.AdjustHour = Convert.ToDecimal(txtAdjustHour.Text);
                    iRet.Add(item);
                }
            }
            return iRet;
        }

        protected void gvItemList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        public event EventHandler btnOKClick;

        public string SurplusAdjustRest
        {
            set { lbAdjustRest.Text = value; }
        }

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            lbResultMessage.Text = string.Empty;
            try
            {
                for (int i = 0; i < gvOverWork.Rows.Count; i++)
                {
                    CheckBox chbId = (CheckBox) gvOverWork.Rows[i].FindControl("chbId");
                    TextBox txtAdjustHour = (TextBox) gvOverWork.Rows[i].FindControl("txtAdjustHour");
                    if (chbId.Checked)
                    {
                        Convert.ToDecimal(txtAdjustHour.Text);
                    }
                }
            }
            catch
            {
                lbResultMessage.Text = "调休小时格式错误";
            }
            if (btnOKClick != null && string.IsNullOrEmpty(lbResultMessage.Text))
            {
                btnOKClick(sender, e);
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../OverWorkPages/OverWorkList.aspx", false);
        }
    }
}