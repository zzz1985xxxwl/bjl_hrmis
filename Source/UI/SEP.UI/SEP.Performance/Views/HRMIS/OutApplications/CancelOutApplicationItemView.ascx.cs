using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IOutApplication;
using SEP.HRMIS.Presenter.OutApplications;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.OutApplications
{
    public partial class CancelOutApplicationItemView : UserControl, ICancelOutApplicationItemView
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

        public OutType OutType
        {
            get { return OutType.GetOutTypeByID(Convert.ToInt32(ddlOutType.SelectedValue)); }
            set
            {
                SetddlOutTypeDataSource();
                ddlOutType.SelectedValue = value.ID.ToString();
            }
        }

        private void SetddlOutTypeDataSource()
        {
            foreach (OutType type in OutType.GetAllOutType())
            {
                ddlOutType.Items.Add(new ListItem(type.Name, type.ID.ToString()));
            }
        }

        public OperationType OperationType
        {
            get { return (OperationType) ViewState["OperationType"]; }
            set
            {
                ViewState["OperationType"] = value;
                if (value == OperationType.Confirm)
                {
                    lbOperationType.Text = "审核外出";
                }
                else
                {
                    lbOperationType.Text = "取消外出";
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


        public List<OutApplicationItem> ApplicationItemList
        {
            get { return GetGridViewValue(); }
            set
            {
                ViewState["ApplicationItemList"] = value;
                gvOutApplication.DataSource = value;
                gvOutApplication.DataBind();
                SetGridViewValue(value);
            }
        }

        private void SetGridViewValue(IList<OutApplicationItem> items)
        {
            bool AdjustHourVisible = false;
            for (int i = 0; i < gvOutApplication.Rows.Count; i++)
            {
                AdjustHourVisible |= items[i].CanChangeAdjust;
                DropDownList ddlStatus = (DropDownList) gvOutApplication.Rows[i].FindControl("ddlStatus");
                Label tbStatusID = (Label) gvOutApplication.Rows[i].FindControl("tbStatusID");
                DropDownList ddlAdjust = (DropDownList)gvOutApplication.Rows[i].FindControl("ddlAdjust");
                TextBox txtAdjustHour = (TextBox)gvOutApplication.Rows[i].FindControl("txtAdjustHour");
                txtAdjustHour.Text = items[i].AdjustHour.ToString();
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
            gvOutApplication.Columns[8].Visible = AdjustHourVisible;
            gvOutApplication.Columns[9].Visible = AdjustHourVisible;
        }

        private List<OutApplicationItem> GetGridViewValue()
        {
            List<OutApplicationItem> iRet = new List<OutApplicationItem>();
            for (int i = 0; i < gvOutApplication.Rows.Count; i++)
            {
                TextBox txtRemark = (TextBox) gvOutApplication.Rows[i].FindControl("txtRemark");
                CheckBox chbId = (CheckBox) gvOutApplication.Rows[i].FindControl("chbId");

                DropDownList ddlStatus = (DropDownList) gvOutApplication.Rows[i].FindControl("ddlStatus");
                DropDownList ddlAdjust = (DropDownList)gvOutApplication.Rows[i].FindControl("ddlAdjust");
                TextBox txtAdjustHour = (TextBox)gvOutApplication.Rows[i].FindControl("txtAdjustHour");
                if (chbId.Checked)
                {
                    OutApplicationItem item = new OutApplicationItem(Convert.ToInt32(chbId.Text));
                    List<OutApplicationFlow> outApplicationFlowList = new List<OutApplicationFlow>();
                    outApplicationFlowList.Add(new OutApplicationFlow(txtRemark.Text.Trim()));
                    item.OutApplicationFlow = outApplicationFlowList;
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

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            lbResultMessage.Text = string.Empty;
            try
            {
                for (int i = 0; i < gvOutApplication.Rows.Count; i++)
                {
                    CheckBox chbId = (CheckBox)gvOutApplication.Rows[i].FindControl("chbId");
                    TextBox txtAdjustHour = (TextBox)gvOutApplication.Rows[i].FindControl("txtAdjustHour");
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
            Response.Redirect("../OutApplicationPages/OutApplicationList.aspx", false);
        }
    }
}