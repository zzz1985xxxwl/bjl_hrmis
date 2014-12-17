using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Presenter.ChoseEmployee;
using SEP.HRMIS.Presenter.IPresenter.IDiyProcess;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.DiyProcesses
{
    public partial class DiyProcessView : UserControl, IDiyProcessView
    {
        private const string _JustForTestError = "仅用于测试";

        protected void Page_Load(object sender, EventArgs e)
        {
            new ChoseEmployeePresenter(ChoseEmployeeView1, null);
            ChoseEmployeeView1.AttachAccountAjax += ChoseAccountAjax;
            ChoseEmployeeView1.SearchAjax += SearchAccountAjax;
            int i=0;
            if (!string.IsNullOrEmpty(hfRowID.Value))
            {
                 i = Convert.ToInt32(hfRowID.Value);
            }
            ChoseEmployeeView1.AccountLeftViewStateName = "LeftAccount" + i;
            ChoseEmployeeView1.AccountRightViewStateName = "RightAccount" + i;
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

        public string NameMessage
        {
            get { return lbNameMessage.Text.Trim(); }
            set { lbNameMessage.Text = value; }
        }

        public string Name
        {
            get { return tbName.Text.Trim(); }
            set { tbName.Text = value; }
        }

        public string Remark
        {
            get { return tbRemark.Text.Trim(); }
            set { tbRemark.Text = value; }
        }

        public string OperationType
        {
            get { return lbOperationType.Text.Trim(); }
            set { lbOperationType.Text = value; }
        }

        public string DiyProcessID
        {
            get { return lbID.Text.Trim().Split('#')[1]; }
            set { lbID.Text = " # " + value; }
        }

        public ProcessType ProcessType
        {
            get
            {
                ProcessType processType =
                    new ProcessType(Convert.ToInt32(ddlType.SelectedItem.Value), ddlType.SelectedItem.Text);
                return processType;
            }
            set { ddlType.SelectedValue = value.Id.ToString(); }
        }

        public Dictionary<string, string> ProcessTypeSource
        {
            get { throw new ArgumentNullException(_JustForTestError); }
            set
            {
                ddlType.Items.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    ddlType.Items.Add(item);
                }
            }
        }

        public Dictionary<string, string> SystemStatusSource
        {
            get { return (Dictionary<string, string>) ViewState["_SystemStatusSource"]; }
            set { ViewState["_SystemStatusSource"] = value; }
        }

        public Dictionary<string, string> StatusSource
        {
            get { return (Dictionary<string, string>) ViewState["_StatusSource"]; }
            set { ViewState["_StatusSource"] = value; }
        }

        private Dictionary<string, string> _OperatorTypeSource;

        public Dictionary<string, string> OperatorSource
        {
            get { return _OperatorTypeSource; }
            set { _OperatorTypeSource = value; }
        }

        private List<Account> _AccountList;

        public List<Account> AccountList
        {
            get { return _AccountList; }
            set { _AccountList = value; }
        }

        public List<DiyStep> DiyStepList
        {
            get
            {
                List<DiyStep> diySteps =
                    (List<DiyStep>) ViewState["_DiyStepList"];
                GetGridViewValue(diySteps);
                return diySteps;
            }
            set
            {
                ViewState["_DiyStepList"] = value;
                gvDiyStepList.DataSource = value;
                gvDiyStepList.DataBind();

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
                tbName.Enabled = !value;
                ddlType.Enabled = !value;
                tbRemark.ReadOnly = value;
                SetEmunListColumnFalse(value);
            }
            get { return !ddlType.Enabled; }
        }

        private void SetEmunListColumnFalse(bool value)
        {
            for (int i = 0; i < gvDiyStepList.Rows.Count; i++)
            {
                DropDownList ddlStatus = (DropDownList) gvDiyStepList.Rows[i].FindControl("ddlStatus");
                DropDownList ddlOperatorType = (DropDownList) gvDiyStepList.Rows[i].FindControl("ddlOperatorType");
                DropDownList ddlOperatorID = (DropDownList) gvDiyStepList.Rows[i].FindControl("ddlOperatorID");
                TextBox txtMailAccount = (TextBox) gvDiyStepList.Rows[i].FindControl("txtMailAccount");

                if (txtMailAccount != null)
                {
                    txtMailAccount.Enabled = !value;
                }
                if (ddlStatus != null)
                {
                    ddlStatus.Enabled = !value;
                }
                if (ddlOperatorType != null)
                {
                    ddlOperatorType.Enabled = !value;
                }
                if (ddlOperatorID != null)
                {
                    ddlOperatorID.Enabled = !value;
                }
            }
        }

        #endregion

        #region 事件

        public event EventHandler ddlTypeSelected;

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTypeSelected(null, null);
        }

        public event EventHandler btnOKClick;

        protected void BtnOK_Click(object sender, EventArgs e)
        {
            GetGridViewValue(DiyStepList);
            btnOKClick(sender, e);
        }

        public event EventHandler btnSubmitClick;

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            GetGridViewValue(DiyStepList);
            btnSubmitClick(sender, e);
        }

        public event DelegateID DiyStepForDeleteAtEvent;

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
            if (DiyStepForDeleteAtEvent != null)
            {
                DiyStepForDeleteAtEvent(row.RowIndex.ToString());
            }
        }

        public event DelegateID DiyStepForAddAtEvent;

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
            if (DiyStepForAddAtEvent != null)
            {
                DiyStepForAddAtEvent(row.RowIndex.ToString());
            }
        }

        public event DelegateID ddlDiyStepChangedForDownEvent;

        protected void lbDownItem_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbDownItem = sender as LinkButton;
            if (lbDownItem == null)
            {
                return;
            }
            GridViewRow row = lbDownItem.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            if (ddlDiyStepChangedForDownEvent != null)
            {
                ddlDiyStepChangedForDownEvent(row.RowIndex.ToString());
            }
        }

        public event DelegateID ddlDiyStepChangedForUpEvent;

        protected void lbUpItem_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbUpItem = sender as LinkButton;
            if (lbUpItem == null)
            {
                return;
            }
            GridViewRow row = lbUpItem.NamingContainer as GridViewRow;
            if (row == null)
            {
                return;
            }
            if (ddlDiyStepChangedForUpEvent != null)
            {
                ddlDiyStepChangedForUpEvent(row.RowIndex.ToString());
            }
        }

        protected void gvDiyStepList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);
            }
        }

        #endregion

        #region DiyStepList 内部方法

        private void GetGridViewValue(IList<DiyStep> diyStepList)
        {
            for (int i = 0; i < diyStepList.Count; i++)
            {
                DropDownList ddlStatus = (DropDownList) gvDiyStepList.Rows[i].FindControl("ddlStatus");
                DropDownList ddlOperatorType = (DropDownList) gvDiyStepList.Rows[i].FindControl("ddlOperatorType");
                DropDownList ddlOperatorID = (DropDownList) gvDiyStepList.Rows[i].FindControl("ddlOperatorID");
                if (ddlStatus.SelectedItem != null)
                {
                    diyStepList[i].Status = ddlStatus.SelectedItem.Text.Trim();
                }
                if (ddlOperatorType.SelectedItem != null)
                {
                    diyStepList[i].OperatorType =
                        new OperatorType(Convert.ToInt32(ddlOperatorType.SelectedValue),
                                         ddlOperatorType.SelectedItem.Text.Trim());
                }
                if (ddlOperatorID.SelectedItem != null)
                {
                    diyStepList[i].OperatorID = Convert.ToInt32(ddlOperatorID.SelectedValue);
                }
            }
        }

        private void SetGridViewDisplay(List<DiyStep> diyStepList)
        {
            for (int i = 0; i < diyStepList.Count; i++)
            {
                SetGridViewRowddlAccountSetParaDisplay(i, diyStepList);
                SetGridViewRowLinkButtonDisplay(i);
            }
        }

        private void SetGridViewRowddlAccountSetParaDisplay(int rowIndex, List<DiyStep> diyStepList)
        {
            TextBox txtMailAccount = (TextBox) gvDiyStepList.Rows[rowIndex].FindControl("txtMailAccount");
            txtMailAccount.Attributes["onfocus"] = "btnChooseMailCCClick('" + rowIndex + "');";

            #region ddlStatus

            DropDownList ddlStatus =
                (DropDownList) gvDiyStepList.Rows[rowIndex].FindControl("ddlStatus");
            if (ddlStatus == null)
            {
                return;
            }
            ddlStatus.Items.Clear();
            if (diyStepList[rowIndex].IfSystem)
            {
                foreach (KeyValuePair<string, string> pair in SystemStatusSource)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    ddlStatus.Items.Add(item);
                }
            }
            else
            {
                foreach (KeyValuePair<string, string> pair in StatusSource)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    ddlStatus.Items.Add(item);
                }
            }

            #endregion

            #region ddlOperatorType

            DropDownList ddlOperatorType =
                (DropDownList) gvDiyStepList.Rows[rowIndex].FindControl("ddlOperatorType");
            if (ddlOperatorType == null)
            {
                return;
            }
            ddlOperatorType.Items.Clear();
            foreach (KeyValuePair<string, string> pair in OperatorSource)
            {
                ListItem item = new ListItem(pair.Value, pair.Key, true);
                ddlOperatorType.Items.Add(item);
            }

            #endregion

            #region ddlOperatorID

            DropDownList ddlOperatorID =
                (DropDownList) gvDiyStepList.Rows[rowIndex].FindControl("ddlOperatorID");
            if (ddlOperatorID == null)
            {
                return;
            }
            List<Account> accounts = new List<Account>();
            accounts.Add(new Account(0, "", ""));
            foreach (Account account in AccountList)
            {
                accounts.Add(account);
            }
            ddlOperatorID.DataSource = accounts;
            ddlOperatorID.DataValueField = "Id";
            ddlOperatorID.DataTextField = "Name";
            ddlOperatorID.DataBind();

            ddlOperatorID.Enabled = !diyStepList[rowIndex].IfSystem;

            #endregion

            if (diyStepList[rowIndex].Status != null && !string.IsNullOrEmpty(diyStepList[rowIndex].Status))
            {
                ddlStatus.SelectedValue = DDLStatus(ddlStatus, diyStepList[rowIndex].Status).ToString();
            }
            else
            {
                ddlStatus.SelectedIndex = 0;
            }
            if (diyStepList[rowIndex].OperatorType != null)
            {
                ddlOperatorType.SelectedValue = diyStepList[rowIndex].OperatorType.Id.ToString();
            }
            else
            {
                ddlOperatorType.SelectedIndex = 0;
            }

            ddlOperatorID.SelectedValue = diyStepList[rowIndex].OperatorID.ToString();
        }

        private static int DDLStatus(DropDownList ddl, string status)
        {
            foreach (ListItem ddlItem in ddl.Items)
            {
                if (ddlItem.Text == status)
                {
                    return Convert.ToInt32(ddlItem.Value);
                }
            }
            return -1;
        }

        private void SetGridViewRowLinkButtonDisplay(int rowIndex)
        {
            LinkButton lbAddItem = (LinkButton) gvDiyStepList.Rows[rowIndex].FindControl("lbAddItem");
            if (lbAddItem != null)
            {
                lbAddItem.Text = "<img src=../../../Pages/image/file_new.gif border=0>";
            }
            LinkButton lbDeleteItem = (LinkButton) gvDiyStepList.Rows[rowIndex].FindControl("lbDeleteItem");
            if (lbDeleteItem != null)
            {
                lbDeleteItem.Text = "<img src=../../../Pages/image/file_cancel.gif border=0>";
            }
            LinkButton lbUpItem = (LinkButton) gvDiyStepList.Rows[rowIndex].FindControl("lbUpItem");
            if (lbUpItem != null)
            {
                lbUpItem.Text = "<img src=../../image/Up_icon.gif border=0>";
            }
            LinkButton lbDownItem = (LinkButton) gvDiyStepList.Rows[rowIndex].FindControl("lbDownItem");
            if (lbDownItem != null)
            {
                lbDownItem.Text = "<img src=../../image/Down_icon.gif border=0>";
            }
        }

        #endregion

        #region MailCC

        private void ChoseAccountAjax(object sender, EventArgs e)
        {
            try
            {
                int i = Convert.ToInt32(hfRowID.Value);
                DiyStepList[i].MailAccount = MailCC;
                DiyStepList = DiyStepList;
                mpeChooseEmployee.Show();
            }
            catch
            {
            }
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

        protected void btnShowChooseEmployee_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(hfRowID.Value);
            ChoseEmployeeView1.AccountLeftViewStateName = "LeftAccount" + i;
            ChoseEmployeeView1.AccountRightViewStateName = "RightAccount" + i;
            ChoseEmployeeView1.AccountRight = DiyStepList[i].MailAccount;
            mpeChooseEmployee.Show();
        }

        #endregion
    }
}