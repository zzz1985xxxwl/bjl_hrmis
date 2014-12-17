using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.ChoseEmployee;
using SEP.HRMIS.Presenter.IPresenter.IOutApplication;
using SEP.HRMIS.Presenter.OutApplications;
using SEP.Model.Accounts;
using SEP.Presenter.Core;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.OutApplications
{
    public partial class OutApplicationEditView : UserControl, IOutApplicationEditView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            new ChoseEmployeePresenter(ChoseEmployeeView1, null);
            DefineOutSessionName();
            ChoseEmployeeView1.AttachAccountAjax += ChoseAccountAjax;
            ChoseEmployeeView1.SearchAjax += SearchAccountAjax;
        }

        #region 属性

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

        public string OutLocation
        {
            get { return txtOutLoacation.Text.Trim(); }
            set { txtOutLoacation.Text = value; }
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

        public string OutLocationMessage
        {
            get { return lbOutLocationMessage.Text.Trim(); }
            set { lbOutLocationMessage.Text = value; }
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

        public string Remind
        {
            get { return lblRemind.Text; }
            set
            {
                lblRemind.Text = value;
                lblRemind.Visible = !string.IsNullOrEmpty(value);
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

        public List<OutApplicationItem> ApplicationItemList
        {
            get
            {
                List<OutApplicationItem> applicationItemList =
                    (List<OutApplicationItem>) ViewState["ApplicationItemList"];
                GetGridViewValue(applicationItemList);
                return applicationItemList;
            }
            set
            {
                ViewState["ApplicationItemList"] = value;
                gvOutApplication.DataSource = value;
                gvOutApplication.DataBind();
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
                txtOutLoacation.Enabled = !value;
                ddlOutType.Enabled = !value;
                tbReason.ReadOnly = value;
                txtMailCC.ReadOnly = value;

                gvOutApplication.Columns[11].Visible = OutType == OutType.OutCity && value;
                gvOutApplication.Columns[12].Visible = OutType == OutType.OutCity && value;
                gvOutApplication.Columns[13].Visible = !value;
                gvOutApplication.Columns[14].Visible = !value;
                gvOutApplication.Columns[15].Visible = !value;
                SetEmunListColumnFalse(value);
            }
            get { return tbReason.ReadOnly; }
        }

        private void SetEmunListColumnFalse(bool value)
        {
            for (int i = 0; i < gvOutApplication.Rows.Count; i++)
            {
                TextBox tbStart = (TextBox) gvOutApplication.Rows[i].FindControl("tbStart");
                DropDownList ddlStartHour = (DropDownList) gvOutApplication.Rows[i].FindControl("ddlStartHour");
                DropDownList ddlStartMinute =
                    (DropDownList) gvOutApplication.Rows[i].FindControl("ddlStartMinute");

                TextBox tbEnd = (TextBox) gvOutApplication.Rows[i].FindControl("tbEnd");
                DropDownList ddlEndHour = (DropDownList) gvOutApplication.Rows[i].FindControl("ddlEndHour");
                DropDownList ddlEndMinute = (DropDownList) gvOutApplication.Rows[i].FindControl("ddlEndMinute");

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
                ResultMessage = "时间计算错误，请检查是否有排班";
                return false;
            }
            foreach (OutApplicationItem item in ApplicationItemList)
            {
                if (item.CostTime == 0)
                {
                    ResultMessage = "外出项中有0小时项";
                    return false;
                }
            }
            return true;
        }

        public event DelegateID ApplicationItemForAddAtEvent;
        public event DelegateID ApplicationItemForDeleteAtEvent;
        public event DelegateNoParameter OutTypeSelectChange;

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

        private bool GetGridViewValue(IList<OutApplicationItem> applicationItemList)
        {
            timeerror = false;
            for (int i = 0; i < applicationItemList.Count; i++)
            {
                Label lbl = (Label) gvOutApplication.Rows[i].FindControl("lbl");
                TextBox tbStart = (TextBox) gvOutApplication.Rows[i].FindControl("tbStart");
                DropDownList ddlStartHour = (DropDownList) gvOutApplication.Rows[i].FindControl("ddlStartHour");
                DropDownList ddlStartMinute =
                    (DropDownList) gvOutApplication.Rows[i].FindControl("ddlStartMinute");

                TextBox tbEnd = (TextBox) gvOutApplication.Rows[i].FindControl("tbEnd");
                DropDownList ddlEndHour = (DropDownList) gvOutApplication.Rows[i].FindControl("ddlEndHour");
                DropDownList ddlEndMinute = (DropDownList) gvOutApplication.Rows[i].FindControl("ddlEndMinute");
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

                TextBox txtCostTime = (TextBox) gvOutApplication.Rows[i].FindControl("txtCostTime");
                if (txtCostTime != null)
                {
                    decimal decimalData;
                    if (decimal.TryParse(txtCostTime.Text.Trim(), out decimalData))
                    {
                        applicationItemList[i].CostTime = Convert.ToDecimal(txtCostTime.Text.Trim());
                    }
                }
            }
            return timeerror;
        }

        private void SetGridViewDisplay(IList<OutApplicationItem> outApplicationItemList)
        {
            for (int i = 0; i < outApplicationItemList.Count; i++)
            {
                SetGridViewRowFromToDateDisplay(i, outApplicationItemList);
                //SetGridViewRowLinkButtonDisplay(i);
            }
            SetHour(outApplicationItemList);
        }

        private void SetGridViewRowFromToDateDisplay(int rowIndex, IList<OutApplicationItem> outApplicationList)
        {
            TextBox tbStart = (TextBox) gvOutApplication.Rows[rowIndex].FindControl("tbStart");
            TextBox tbEnd = (TextBox) gvOutApplication.Rows[rowIndex].FindControl("tbEnd");
            DropDownList ddlStartHour = (DropDownList) gvOutApplication.Rows[rowIndex].FindControl("ddlStartHour");
            DropDownList ddlStartMinute =
                (DropDownList) gvOutApplication.Rows[rowIndex].FindControl("ddlStartMinute");
            DropDownList ddlEndHour = (DropDownList) gvOutApplication.Rows[rowIndex].FindControl("ddlEndHour");
            DropDownList ddlEndMinute = (DropDownList) gvOutApplication.Rows[rowIndex].FindControl("ddlEndMinute");

            if (tbStart == null || tbEnd == null || ddlStartHour == null || ddlStartMinute == null || ddlEndHour == null ||
                ddlEndMinute == null)
            {
                return;
            }

            if (outApplicationList[rowIndex] != null)
            {
                tbStart.Text = outApplicationList[rowIndex].FromDate.Date.ToString();
                ddlStartHour.SelectedValue = outApplicationList[rowIndex].FromDate.Hour.ToString();
                ddlStartMinute.SelectedValue = outApplicationList[rowIndex].FromDate.Minute.ToString();
                tbEnd.Text = outApplicationList[rowIndex].ToDate.Date.ToString();
                ddlEndHour.SelectedValue = outApplicationList[rowIndex].ToDate.Hour.ToString();
                ddlEndMinute.SelectedValue = outApplicationList[rowIndex].ToDate.Minute.ToString();
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
        private string ReCalculateHour(IEnumerable<OutApplicationItem> OutApplicationItemList)
        {
            string error = string.Empty;
            if (NotCalculate == false)
            {
                int i = 0;
                foreach (OutApplicationItem item in OutApplicationItemList)
                {
                    TextBox txtCostTime = (TextBox) gvOutApplication.Rows[i].FindControl("txtCostTime");
                    string ans = new CalculateOutHourPresenter(item.FromDate.Date.ToString(),
                                                               item.FromDate.Hour.ToString(),
                                                               item.FromDate.Minute.ToString(),
                                                               item.ToDate.Date.ToString(),
                                                               item.ToDate.Hour.ToString(),
                                                               item.ToDate.Minute.ToString(),
                                                               Convert.ToInt32(hfEmployeeID.Value), OutType).GetHour();
                    if (ans == "error")
                    {
                        error = "error";
                        item.CostTime = 0;
                        txtCostTime.Text = "0";
                    }
                    else
                    {
                        txtCostTime.Text = ans;
                        item.CostTime = Convert.ToDecimal(ans);
                    }
                    i++;
                }
            }
            return error;
        }

        /// <summary>
        /// 计算小时
        /// </summary>
        private void SetHour(IList<OutApplicationItem> outApplicationItemList)
        {
            if (NotCalculate == false)
            {
                decimal allHour = 0;
                DateTime minFromTime = outApplicationItemList[0].FromDate;
                DateTime maxToTime = outApplicationItemList[0].ToDate;
                for (int i = 0; i < outApplicationItemList.Count; i++)
                {
                    string ans =
                        new CalculateOutHourPresenter(outApplicationItemList[i].FromDate.Date.ToString(),
                                                      outApplicationItemList[i].FromDate.Hour.ToString(),
                                                      outApplicationItemList[i].FromDate.Minute.ToString(),
                                                      outApplicationItemList[i].ToDate.Date.ToString(),
                                                      outApplicationItemList[i].ToDate.Hour.ToString(),
                                                      outApplicationItemList[i].ToDate.Minute.ToString(),
                                                      Convert.ToInt32(hfEmployeeID.Value), OutType).GetHour();
                    TextBox txtCostTime = (TextBox) gvOutApplication.Rows[i].FindControl("txtCostTime");
                    HtmlImage imgResultCaculate =
                        (HtmlImage) gvOutApplication.Rows[i].FindControl("imgResultCaculate");
                    if (ans == "error")
                    {
                        txtCostTime.Text = "0";
                        imgResultCaculate.Src = "../../../Pages/image/wrong_icon.gif";
                        imgResultCaculate.Style["display"] = "block";
                    }
                    else
                    {
                        txtCostTime.Text = ans;
                        imgResultCaculate.Style["display"] = "none";
                    }
                    allHour += Convert.ToDecimal(txtCostTime.Text);
                    if (minFromTime > outApplicationItemList[i].FromDate)
                    {
                        minFromTime = outApplicationItemList[i].FromDate;
                    }
                    if (maxToTime < outApplicationItemList[i].ToDate)
                    {
                        maxToTime = outApplicationItemList[i].ToDate;
                    }
                }
                lbCostTime.Text = string.Format("{0}小时", allHour);
                lbDate.Text = string.Format("{0} ～ {1}", minFromTime, maxToTime);
            }
        }

        //private void SetGridViewRowLinkButtonDisplay(int rowIndex)
        //{
        //    LinkButton lbAddItem = (LinkButton)gvOutApplication.Rows[rowIndex].FindControl("lbAddItem");
        //    if (lbAddItem != null)
        //    {
        //        lbAddItem.Text = "<img src=../../../Pages/image/file_new.gif border=0>";
        //    }
        //    LinkButton lbDeleteItem = (LinkButton)gvOutApplication.Rows[rowIndex].FindControl("lbDeleteItem");
        //    if (lbDeleteItem != null)
        //    {
        //        lbDeleteItem.Text = "<img src=../../../Pages/image/file_cancel.gif border=0>";
        //    }
        //}

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

        protected void ddlOutType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OutTypeSelectChange != null)
            {
                OutTypeSelectChange();
            }
        }
    }
}