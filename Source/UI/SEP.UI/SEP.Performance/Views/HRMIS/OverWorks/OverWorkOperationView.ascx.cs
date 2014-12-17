using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.IPresenter.IOverWork;

namespace SEP.Performance.Views.HRMIS.OverWorks
{
    public partial class OverWorkOperationView : UserControl, IOverWorkOperationView
    {

        public string btnCancelOnClientClick
        {
            set { BtnSubmit.OnClientClick = value; }
        }

        public int EmployeeID
        {
            get { return tbName.TabIndex; }
            set { tbName.TabIndex = (short) value; }
        }

        public string EmployeeName
        {
            get { return tbName.Text.Trim(); }
            set { tbName.Text = value; }
        }

        public string OverWorkFlowID
        {
            get { return tbID.Text.Trim(); }
            set { tbID.Text = value; }
        }

        public int OverWorkID
        {
            get { return Convert.ToInt32(tbOverWorkID.Text.Trim()); }
            set { tbOverWorkID.Text = value.ToString(); }
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

        public string Status
        {
            get { return ddlStatus.SelectedValue.Trim(); }
            set { ddlStatus.SelectedValue = value; }
        }

        public Dictionary<string, string> StatusSource
        {
            get { return null;}
            set
            {
                ddlStatus.Items.Clear();

                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    ddlStatus.Items.Add(item);
                }
            }
        }

        public string ResultMessage
        {
            get { return lbResultMessage.Text.Trim(); }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    tbResultMessage.Style["display"] = "none";
                }
                else
                {
                    tbResultMessage.Style["display"] = "block";
                    lbResultMessage.Text = value;
                }
            }
        }

        public string RemarkMessage
        {
            get { return lbRemarkMessage.Text.Trim(); }
            set { lbRemarkMessage.Text = value; }
        }
        public event EventHandler UpdateListWindow;

        public event EventHandler btnOKClick;

        protected void btnOK_Click(object sender, EventArgs e)
        {
            btnOKClick(sender, e);
            UpdateListWindow(sender, e);
        }

        public bool SetFormReadOnly
        {
            set
            {
                tbRemark.ReadOnly = value;
                ddlStatus.Enabled = !value;
            }
            get { return tbRemark.ReadOnly; }
        }

        public bool SetStatusReadOnly
        {
            set { ddlStatus.Enabled = !value; }
            get { return ddlStatus.Enabled; }
        }
    }
}