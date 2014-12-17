using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using hrmisModel = SEP.HRMIS.Model;


namespace SEP.Performance.Views.HRMIS.AssessActivity
{
    public partial class ManualAssessView : UserControl, IManualAssessView
    {
        #region IManualAssessView ≥…‘±
        public bool txtEmployeeNameReadOnly
        {
            set
            {
                txtEmployeeName.ReadOnly = value;
            }
        }
        public bool ddlCharacterEnabled
        {
            set
            {
                ddlCharacter.Enabled = value;
            }
        }
        public bool FormReadonly
        {
            set
            {
                txtEmployeeName.ReadOnly = value;
                txtReason.ReadOnly = value;
                dtpScopeFrom.Enabled = !value;
                dtpScopeTo.Enabled = !value;
                ddlCharacter.Enabled = !value;
                btnApply.Visible = !value;
            }
        }

        public string Message
        {
            set
            {
                lblMessage.Text = value;
                if (String.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
            }
        }
        public string ScopeMsg
        {
            set { lblScopeMsg.Text = value; }
        }
        public string ReasonMsg
        {
            set { lblReasonMsg.Text = value; }
        }
        public string ScopeFrom
        {
            get
            {
                return dtpScopeFrom.Text.Trim();
            }

        }
        public string ScopeTo
        {
            get
            {
                return dtpScopeTo.Text.Trim();
            }
        }
        public string Reason
        {
            get
            {
                return txtReason.Text.Trim();
            }
        }

        public hrmisModel.AssessActivity AssessActivityToManual
        {
            get
            {
                hrmisModel.AssessActivity assessActivity = new hrmisModel.AssessActivity();
                assessActivity.AssessCharacterType = (AssessCharacterType)Convert.ToInt32(ddlCharacter.SelectedValue);
                assessActivity.ScopeFrom = Convert.ToDateTime(dtpScopeFrom.Text.Trim());
                assessActivity.ScopeTo = Convert.ToDateTime(dtpScopeTo.Text.Trim());
                assessActivity.Reason = txtReason.Text.Trim();
                assessActivity.ItsEmployee = Employee;

                return assessActivity;
            }
            set
            {
                txtReason.Text = value.Reason;
                txtEmployeeName.Text = value.ItsEmployee.Account.Name;
                dtpScopeFrom.Text = value.ScopeFrom.ToShortDateString();
                dtpScopeTo.Text = value.ScopeTo.ToShortDateString();
                ddlCharacter.SelectedValue = ((int)value.AssessCharacterType).ToString();
            }
        }

        public hrmisModel.Employee Employee
        {
            get
            {
                return _Employee;
            }
            set
            {
                txtEmployeeName.Text = value.Account.Name;
                _Employee = value;
            }
        }
        private hrmisModel.Employee _Employee;
        public Dictionary<string, string> AssessCharacterTypes
        {
            set
            {
                ddlCharacter.Items.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    ddlCharacter.Items.Add(item);
                }
            }
        }
        #endregion
        public EventHandler btnApplyClick;
        protected void btnApply_Click(object sender, EventArgs e)
        {
            btnApplyClick(sender, e);
        }
    }

}