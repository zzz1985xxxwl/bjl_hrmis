using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;

namespace SEP.Performance.Views.Employee
{
    public partial class ApplyAssessConditionView : UserControl, IApplyAssessConditionView
    {
        public delegate void UpdateListWindow();
        public UpdateListWindow _UpdateListWindow;
        public EventHandler btnOKClick;
        protected void btnOK_Click(object sender, EventArgs e)
        {
            btnOKClick(sender, e);
            _UpdateListWindow();
        }

        public EventHandler btnCancelClick;

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnCancelClick(sender, e);
        }
        /// <summary>
        /// 关闭小界面设置
        /// </summary>
        public string btnCancelOnClientClick
        {
            set { btnCancel.OnClientClick = value; }
        }
        public bool FormReadonly
        {
            set
            {
                dtpScopeFrom.ReadOnly = value;
                dtpScopeTo.ReadOnly = value;
                dtpApplyDate.ReadOnly = value;
                ddlCharacter.Enabled = !value;
            }
        }


        public string Message
        {
            get { return lblMessage.Text; }
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
            get { return lblScopeMsg.Text; }
            set { lblScopeMsg.Text = value; }
        }

        public string ApplyDateMsg
        {
            get { return lblApplyDate.Text; }
            set { lblApplyDate.Text = value; }
        }

        public string Title
        {
            set { lblTitle.Text = value; }
        }

        public string ApplyDate
        {
            get { return dtpApplyDate.Text.Trim(); }
            set { dtpApplyDate.Text = value; }
        }

        public string ScopeFrom
        {
            get { return dtpScopeFrom.Text.Trim(); }
            set { dtpScopeFrom.Text = value; }
        }

        public string ScopeTo
        {
            get { return dtpScopeTo.Text.Trim(); }
            set { dtpScopeTo.Text = value; }
        }

        public string ApplyAssessConditionID
        {
            get { return hfConditionID.Value; }
            set { hfConditionID.Value = value; }
        }

        public ApplyAssessCondition ApplyAssessCondition
        {
            get
            {
                ApplyAssessCondition applyAssessCondition = new ApplyAssessCondition(0);
                applyAssessCondition.ApplyAssessCharacterType = (AssessCharacterType)Convert.ToInt32(ddlCharacter.SelectedValue);
                applyAssessCondition.AssessScopeFrom = Convert.ToDateTime(dtpScopeFrom.Text.Trim());
                applyAssessCondition.AssessScopeTo = Convert.ToDateTime(dtpScopeTo.Text.Trim());
                applyAssessCondition.ApplyDate = Convert.ToDateTime(dtpApplyDate.Text.Trim());

                return applyAssessCondition;

            }
            set
            {
                dtpApplyDate.Text = value.ApplyDate.ToShortDateString();
                dtpScopeFrom.Text = value.AssessScopeFrom.ToShortDateString();
                dtpScopeTo.Text = value.AssessScopeTo.ToShortDateString();
                ddlCharacter.SelectedValue = ((int)value.ApplyAssessCharacterType).ToString();

            }
        }

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
    }
}