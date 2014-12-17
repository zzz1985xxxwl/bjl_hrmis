using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.INationality;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.Nationalitys
{
    public partial class NationalityView  : UserControl, INationalityView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.OnClientClick = "return CloseModalPopupExtender('divMPE');";
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set
            {
                lblMessage.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
            }
        }

        public string NameMsg
        {
            get { return lblNameMsg.Text; }
            set { lblNameMsg.Text = value; }
        }

        public string OperationTitle
        {
            set { lblOperation.Text = value; }
            get { return lblOperation.Text; }
        }

        public string NationalityID
        {
            get { return hfNationalityID.Value; }
            set { hfNationalityID.Value = value; }
        }

        public string NationalityName
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value; }
        }

        public string NationalityDescription
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        public bool SetReadonly
        {
            set
            {
                txtName.ReadOnly = value;
                txtDescription.ReadOnly = value;
            }
        }

        public string ActionButtonTxt
        {
            get { return btnOK.Text; }
            set { btnOK.Text = value; }
        }

        public bool ActionButtonEnable
        {
            get { return btnOK.Enabled; }
            set { btnOK.Enabled = value; }
        }

        public string OperationType
        {
            get { return Operation.Value; }
            set { Operation.Value = value; }
        }

        private bool actionSuccess;

        public bool ActionSuccess
        {
            get { return actionSuccess; }
            set { actionSuccess = value; }
        }

        public event DelegateNoParameter ActionButtonEvent;
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ActionButtonEvent();
        }

        public event DelegateNoParameter CancelButtonEvent;
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CancelButtonEvent();
        }
    }
}
