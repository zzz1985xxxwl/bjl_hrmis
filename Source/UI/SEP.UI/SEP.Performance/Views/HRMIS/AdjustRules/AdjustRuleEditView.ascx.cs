using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IAdjustRule;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.AdjustRules
{
    public partial class AdjustRuleEditView : UserControl, IAdjustRuleEditView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('divMPE');";
        }

        public string OverWorkPuTongRate
        {
            get { return txtOverWorkPuTongRate.Text.Trim(); }
            set { txtOverWorkPuTongRate.Text = value; }
        }

        public string OverWorkJieRiRate
        {
            get { return txtOverWorkJieRiRate.Text.Trim(); }
            set { txtOverWorkJieRiRate.Text = value; }
        }

        public string OverWorkShuangXiuRate
        {
            get { return txtOverWorkShuangXiuRate.Text.Trim(); }
            set { txtOverWorkShuangXiuRate.Text = value; }
        }

        public string OutCityPuTongRate
        {
            get { return txtOutCityPuTongRate.Text.Trim(); }
            set { txtOutCityPuTongRate.Text = value; }
        }

        public string OutCityJieRiRate
        {
            get { return txtOutCityJieRiRate.Text.Trim(); }
            set { txtOutCityJieRiRate.Text = value; }
        }

        public string OutCityShuangXiuRate
        {
            get { return txtOutCityShuangXiuRate.Text.Trim(); }
            set { txtOutCityShuangXiuRate.Text = value; }
        }

        public string OverWorkPuTongRateMessage
        {
            set { lblOverWorkPuTongRateMessage.Text = value; }
        }

        public string OverWorkJieRiRateMessage
        {
            set { lblOverWorkJieRiRateMessage.Text = value; }
        }

        public string OverWorkShuangXiuRateMessage
        {
            set { lblOverWorkShuangXiuRateMessage.Text = value; }
        }

        public string OutCityPuTongRateMessage
        {
            set { lblOutCityPuTongRateMessage.Text = value; }
        }

        public string OutCityJieRiRateMessage
        {
            set { lblOutCityJieRiRateMessage.Text = value; }
        }

        public string OutCityShuangXiuRateMessage
        {
            set { lblOutCityShuangXiuRateMessage.Text = value; }
        }

        public string NameMessage
        {
            set { lblNameMessage.Text = value; }
        }

        public string Message
        {
            set
            {
                lblMessage.Text = value;
                tbMessage.Visible = !string.IsNullOrEmpty(value);
            }
        }

        public string Name
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value; }
        }

        public string Operation
        {
            get { return lblOperation.Text; }
            set { lblOperation.Text = value; }
        }

        public string OpreationType
        {
            get { return hfOperation.Value; }
            set { hfOperation.Value = value; }
        }

        public bool ReadOnly
        {
            set
            {
                txtOutCityJieRiRate.Enabled = !value;
                txtOutCityShuangXiuRate.Enabled = !value;
                txtOutCityPuTongRate.Enabled = !value;
                txtOverWorkJieRiRate.Enabled = !value;
                txtOverWorkPuTongRate.Enabled = !value;
                txtOverWorkShuangXiuRate.Enabled = !value;
            }
        }

        public bool AcctionSussess
        {
            get
            {
                return
                    string.IsNullOrEmpty(lblMessage.Text.Trim()) &&
                    string.IsNullOrEmpty(lblNameMessage.Text.Trim()) &&
                    string.IsNullOrEmpty(lblOutCityJieRiRateMessage.Text.Trim()) &&
                    string.IsNullOrEmpty(lblOutCityPuTongRateMessage.Text.Trim()) &&
                    string.IsNullOrEmpty(lblOutCityShuangXiuRateMessage.Text.Trim()) &&
                    string.IsNullOrEmpty(lblOverWorkJieRiRateMessage.Text.Trim()) &&
                    string.IsNullOrEmpty(lblOverWorkPuTongRateMessage.Text.Trim()) &&
                    string.IsNullOrEmpty(lblOverWorkShuangXiuRateMessage.Text.Trim());
            }
        }

        public int AdjustRuleID
        {
            get
            {
                if (string.IsNullOrEmpty(hfadjustRuleID.Value))
                {
                    return 0;
                }
                return Convert.ToInt32(hfadjustRuleID.Value);
            }
            set { hfadjustRuleID.Value = value.ToString(); }
        }

        public event DelegateNoParameter ActionButtonEvent;

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (ActionButtonEvent != null)
            {
                ActionButtonEvent();
            }
        }
    }
}