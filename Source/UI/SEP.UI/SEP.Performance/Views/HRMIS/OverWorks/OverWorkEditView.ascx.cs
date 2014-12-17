using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.ChoseEmployee;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;
using SEP.HRMIS.Presenter.OverWorks;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using ShiXin.Security;
using OverWorkUtility=SEP.HRMIS.Model.OverWork.OverWorkUtility;

namespace SEP.Performance.Views.HRMIS.OverWorks
{
    public partial class OverWorkEditView : UserControl, IOverWorkEditView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new ChoseEmployeePresenter(ChoseEmployeeView1, null);
            DefineOutSessionName();
            ChoseEmployeeView1.AttachAccountAjax += ChoseAccountAjax;
            ChoseEmployeeView1.SearchAjax += SearchAccountAjax;
        }

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

        public string ReasonMessage
        {
            get { return lbReasonMessage.Text.Trim(); }
            set { lbReasonMessage.Text = value; }
        }

        public string Reason
        {
            get { return tbReason.Text.Trim(); }
            set { tbReason.Text = value; }
        }

        public string ProjectName
        {
            get { return txtProjectName.Text.Trim(); }
            set { txtProjectName.Text = value; }
        }

        public string ProjectNameMessage
        {
            get { return lbProjectNameMessage.Text.Trim(); }
            set { lbProjectNameMessage.Text = value; }
        }

        public DateTime SubmitDate
        {
            get
            {
                if (ViewState["SubmitDate"] == null)
                {
                    return DateTime.Now;
                }
                return Convert.ToDateTime(ViewState["SubmitDate"]);
            }
            set { ViewState["SubmitDate"] = value; }
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

        public string OperationType
        {
            get { return lbOperationType.Text.Trim(); }
            set { lbOperationType.Text = value; }
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

        private bool _NotCalculate;

        public bool NotCalculate
        {
            get { return _NotCalculate; }
            set { _NotCalculate = value; }
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

        public List<OverWorkItem> ApplicationItemList
        {
            get
            {
                List<OverWorkItem> applicationItemList =
                    (List<OverWorkItem>) ViewState["ApplicationItemList"];
                GetGridViewValue(applicationItemList);
                return applicationItemList;
            }
            set
            {
                ViewState["ApplicationItemList"] = value;
                gvOverWork.DataSource = value;
                gvOverWork.DataBind();
                if (value != null && value.Count != 0)
                {
                    SetGridViewDisplay(value);
                }
            }
        }

        public bool SetReadOnly
        {
            set
            {
                txtProjectName.Enabled = !value;
                tbReason.ReadOnly = value;
                txtMailCC.ReadOnly = value;
                gvOverWork.Columns[13].Visible =  value;
                gvOverWork.Columns[14].Visible = !value;
                gvOverWork.Columns[15].Visible = !value;
                gvOverWork.Columns[16].Visible = !value;
                SetEmunListColumnFalse(value);
            }
            get { return tbReason.ReadOnly; }
        }

        private void SetEmunListColumnFalse(bool value)
        {
            for (int i = 0; i < gvOverWork.Rows.Count; i++)
            {
                TextBox tbStart = (TextBox) gvOverWork.Rows[i].FindControl("tbStart");
                DropDownList ddlStartHour = (DropDownList) gvOverWork.Rows[i].FindControl("ddlStartHour");
                DropDownList ddlStartMinute =
                    (DropDownList) gvOverWork.Rows[i].FindControl("ddlStartMinute");

                TextBox tbEnd = (TextBox) gvOverWork.Rows[i].FindControl("tbEnd");
                DropDownList ddlEndHour = (DropDownList) gvOverWork.Rows[i].FindControl("ddlEndHour");
                DropDownList ddlEndMinute = (DropDownList) gvOverWork.Rows[i].FindControl("ddlEndMinute");
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
            }
        }

        #endregion

        #region 事件

        public event EventHandler btnOKClick;

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            if (JudgeError())
            {
                btnOKClick(sender, e);
            }
        }

        public event EventHandler btnSubmitClick;

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (JudgeError())
            {
                btnSubmitClick(sender, e);
            }
        }

        private bool JudgeError()
        {
            if (GetGridViewValue(ApplicationItemList))
            {
                ResultMessage = "时间格式错误";
                return false;
            }
            if (ReCalculateHour(ApplicationItemList) == "error")
            {
                ResultMessage = "时间计算错误，请检查每项是否跨天或没有考勤规则";
                return false;
            }
            foreach (OverWorkItem item in ApplicationItemList)
            {
                if (item.CostTime == 0)
                {
                    ResultMessage = "加班项中有0小时项";
                    return false;
                }
            }
            return true;
        }

        public event DelegateID ApplicationItemForAddAtEvent;
        public event DelegateID ApplicationItemForDeleteAtEvent;

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
            if (ApplicationItemForDeleteAtEvent != null)
            {
                ApplicationItemForDeleteAtEvent(row.RowIndex.ToString());
            }
        }

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
            if (ApplicationItemForAddAtEvent != null)
            {
                ApplicationItemForAddAtEvent(row.RowIndex.ToString());
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

        #region ItmList 内部方法

        private bool timeerror;

        private bool GetGridViewValue(IList<OverWorkItem> applicationItemList)
        {
            timeerror = false;
            for (int i = 0; i < applicationItemList.Count; i++)
            {
                Label lbl = (Label) gvOverWork.Rows[i].FindControl("lbl");
                TextBox tbStart = (TextBox) gvOverWork.Rows[i].FindControl("tbStart");
                DropDownList ddlStartHour = (DropDownList) gvOverWork.Rows[i].FindControl("ddlStartHour");
                DropDownList ddlStartMinute =
                    (DropDownList) gvOverWork.Rows[i].FindControl("ddlStartMinute");

                TextBox tbEnd = (TextBox) gvOverWork.Rows[i].FindControl("tbEnd");
                DropDownList ddlEndHour = (DropDownList) gvOverWork.Rows[i].FindControl("ddlEndHour");
                DropDownList ddlEndMinute = (DropDownList) gvOverWork.Rows[i].FindControl("ddlEndMinute");
                DropDownList ddlAdjust = (DropDownList) gvOverWork.Rows[i].FindControl("ddlAdjust");
                //Label lbOverWorkTypeName = (Label) gvOverWork.Rows[i].FindControl("lbOverWorkTypeName");
                if (lbl != null)
                {
                    try
                    {
                        applicationItemList[i].ItemID = Convert.ToInt32(lbl.Text.Trim());
                    }
                    catch
                    {
                        applicationItemList[i].ItemID = -1;
                    }
                }

                DateTime fromDate;
                if ((tbStart != null && ddlStartHour != null && ddlStartMinute != null)
                    &&
                    (DateTime.TryParse(
                        tbStart.Text + " " + ddlStartHour.SelectedValue + ":" + ddlStartMinute.SelectedValue + ":00",
                        out fromDate)))
                {
                    applicationItemList[i].FromDate = fromDate;
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
                    applicationItemList[i].ToDate = toDate;
                }
                else
                {
                    timeerror = true;
                }

                TextBox txtCostTime = (TextBox) gvOverWork.Rows[i].FindControl("txtCostTime");
                if (txtCostTime != null)
                {
                    decimal decimalData;
                    if (decimal.TryParse(txtCostTime.Text.Trim(), out decimalData))
                    {
                        applicationItemList[i].CostTime = Convert.ToDecimal(txtCostTime.Text.Trim());
                    }
                }
                if (ddlAdjust != null)
                {
                    applicationItemList[i].Adjust = ddlAdjust.SelectedIndex == 0;
                }
                //if (lbOverWorkTypeName != null)
                //{
                //    applicationItemList[i].OverWorkType = OverWorkUtility.GetOverWorkTypeByName(lbOverWorkTypeName.Text);
                //}
            }
            return timeerror;
        }

        private void SetGridViewDisplay(IList<OverWorkItem> OverWorkItemList)
        {
            for (int i = 0; i < OverWorkItemList.Count; i++)
            {
                SetGridViewRowFromToDateDisplay(i, OverWorkItemList);
            }
            SetHour(OverWorkItemList);
        }

        private void SetGridViewRowFromToDateDisplay(int rowIndex, IList<OverWorkItem> OverWorkList)
        {
            TextBox tbStart = (TextBox) gvOverWork.Rows[rowIndex].FindControl("tbStart");
            TextBox tbEnd = (TextBox) gvOverWork.Rows[rowIndex].FindControl("tbEnd");
            DropDownList ddlStartHour = (DropDownList) gvOverWork.Rows[rowIndex].FindControl("ddlStartHour");
            DropDownList ddlStartMinute =
                (DropDownList) gvOverWork.Rows[rowIndex].FindControl("ddlStartMinute");
            DropDownList ddlEndHour = (DropDownList) gvOverWork.Rows[rowIndex].FindControl("ddlEndHour");
            DropDownList ddlEndMinute = (DropDownList) gvOverWork.Rows[rowIndex].FindControl("ddlEndMinute");
            DropDownList ddlAdjust = (DropDownList) gvOverWork.Rows[rowIndex].FindControl("ddlAdjust");
            if (tbStart == null || tbEnd == null || ddlStartHour == null || ddlStartMinute == null || ddlEndHour == null ||
                ddlEndMinute == null)
            {
                return;
            }

            if (OverWorkList[rowIndex] != null)
            {
                tbStart.Text = OverWorkList[rowIndex].FromDate.Date.ToString();
                ddlStartHour.SelectedValue = OverWorkList[rowIndex].FromDate.Hour.ToString();
                ddlStartMinute.SelectedValue = OverWorkList[rowIndex].FromDate.Minute.ToString();
                tbEnd.Text = OverWorkList[rowIndex].ToDate.Date.ToString();
                ddlEndHour.SelectedValue = OverWorkList[rowIndex].ToDate.Hour.ToString();
                ddlEndMinute.SelectedValue = OverWorkList[rowIndex].ToDate.Minute.ToString();
                ddlAdjust.SelectedIndex = OverWorkList[rowIndex].Adjust ? 0 : 1;
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
        private string ReCalculateHour(IEnumerable<OverWorkItem> OverWorkItemList)
        {
            string str = string.Empty;
            if (NotCalculate == false)
            {
                int i = 0;
                foreach (OverWorkItem item in OverWorkItemList)
                {
                    TextBox txtCostTime = (TextBox) gvOverWork.Rows[i].FindControl("txtCostTime");
                    OverWorkType type;
                    string ans = new CalculateOverWorkHourPresenter(item.FromDate.Date.ToString(),
                                                                    item.FromDate.Hour.ToString(),
                                                                    item.FromDate.Minute.ToString(),
                                                                    item.ToDate.Date.ToString(),
                                                                    item.ToDate.Hour.ToString(),
                                                                    item.ToDate.Minute.ToString(),
                                                                    Convert.ToInt32(hfEmployeeID.Value)).GetHour(
                        out type);
                    if (ans == "error")
                    {
                        str = "error";
                        txtCostTime.Text = "0";
                        item.CostTime = 0;
                    }
                    else
                    {
                        txtCostTime.Text = ans;
                        item.OverWorkType = type;
                        item.CostTime = Convert.ToDecimal(ans);
                    }
                    i++;
                }
            }

            return str;
        }

        /// <summary>
        /// 计算小时
        /// </summary>
        private void SetHour(IList<OverWorkItem> OverWorkItemList)
        {
            if (NotCalculate == false)
            {
                decimal allHour = 0;
                DateTime minFromTime = OverWorkItemList[0].FromDate;
                DateTime maxToTime = OverWorkItemList[0].ToDate;
                for (int i = 0; i < OverWorkItemList.Count; i++)
                {
                    OverWorkType type;
                    string ans =
                        new CalculateOverWorkHourPresenter(OverWorkItemList[i].FromDate.Date.ToString(),
                                                           OverWorkItemList[i].FromDate.Hour.ToString(),
                                                           OverWorkItemList[i].FromDate.Minute.ToString(),
                                                           OverWorkItemList[i].ToDate.Date.ToString(),
                                                           OverWorkItemList[i].ToDate.Hour.ToString(),
                                                           OverWorkItemList[i].ToDate.Minute.ToString(),
                                                           Convert.ToInt32(hfEmployeeID.Value)).GetHour(out type);
                    TextBox txtCostTime = (TextBox) gvOverWork.Rows[i].FindControl("txtCostTime");
                    Label lbOverWorkTypeName = (Label) gvOverWork.Rows[i].FindControl("lbOverWorkTypeName");
                    HtmlImage imgResultCaculate =
                        (HtmlImage) gvOverWork.Rows[i].FindControl("imgResultCaculate");
                    if (ans == "error")
                    {
                        txtCostTime.Text = "0";
                        imgResultCaculate.Src = "../../../Pages/image/wrong_icon.gif";
                        imgResultCaculate.Style["display"] = "block";
                    }
                    else
                    {
                        lbOverWorkTypeName.Text = OverWorkUtility.GetOverWorkTypeName(type);
                        txtCostTime.Text = ans;
                        imgResultCaculate.Style["display"] = "none";
                    }
                    allHour += Convert.ToDecimal(txtCostTime.Text);
                    if (minFromTime > OverWorkItemList[i].FromDate)
                    {
                        minFromTime = OverWorkItemList[i].FromDate;
                    }
                    if (maxToTime < OverWorkItemList[i].ToDate)
                    {
                        maxToTime = OverWorkItemList[i].ToDate;
                    }
                }
                lbCostTime.Text = string.Format("{0}小时", allHour);
                lbDate.Text = string.Format("{0} ～ {1}", minFromTime, maxToTime);
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
    }
}