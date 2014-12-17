using System;
using System.Web.UI;
using SEP.Presenter;
using SEP.Presenter.IPresenter.ISpecialDate;

namespace SEP.Performance.Views.SEP.SpecialDates
{
    public partial class SpecialDateEditView : UserControl, ISpecialDateEditView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('divMPESpecialDateEditView');";
        }

        public string SpecialDateID
        {
            get { return hf_SpecialDateID.Value; }
            set
            {
                hf_SpecialDateID.Value = value;
            }
        }
        public string SpecialDate
        {
            get { return txtSpecialDate.Text; }
            set
            {
                txtSpecialDate.Text = value;
            }
        }
        public int IsWork
        {
            get
            {
                return rb_Rest.Checked ? 0 :
                       rb_Work.Checked ? 1 : 2;
            }
            set
            {
                rb_Work.Checked = value == 1;
                rb_Rest.Checked = value == 0;
                rb_LegalHoliday.Checked = value == 2;
            }
        }
        public string SpecialHeader
        {
            get { return txtTitle.Text; }
            set
            {
                txtTitle.Text = value;
            }
        }
        public string SpecialDescription
        {
            get { return txtContent.Text; }
            set
            {
                txtContent.Text = value;
            }
        }
        public string SpecialForeColor
        {
            get { return rb_Work.Checked ? "green" : "black"; }
            set { rb_Work.Checked = (value == "green"); }
        }
        public string SpecialBackColor
        {
            get { return rb_Work.Checked ? "white" : "#ffeded"; }
            set { rb_Work.Checked = (value == "white"); }
        }
        public string ValidateTitle
        {
            set
            {
                lblValidateTitle.Text = value;
            }
            get { return lblValidateTitle.Text; }
        }
        public string ResultMessage
        {
            set
            {
                lblResultMessage.Text = value;
                if (lblResultMessage.Text.Length > 0)
                {
                    ShowInfo.Visible = true;
                }
            }
            get
            { return lblResultMessage.Text; }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            ActionButtonEvent(SpecialDate);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CancelButtonEvent();
        }

        public event DelegateID ActionButtonEvent;

        public event DelegateNoParameter CancelButtonEvent;

        private bool _ActionSuccess;
        public bool ActionSuccess
        {
            get
            {
                return _ActionSuccess;
            }
            set
            {
                _ActionSuccess = value;
            }
        }
    }
}