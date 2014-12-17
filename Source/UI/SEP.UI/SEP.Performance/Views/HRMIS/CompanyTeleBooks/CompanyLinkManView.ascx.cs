using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.ICompanyLinkMan;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.CompanyTeleBooks
{
    public partial class CompanyLinkManView : UserControl, ICompnayLinkManView
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

        public Guid LinkManId
        {
            get { return new Guid(ViewState["linkmanid"].ToString()); }
            set { ViewState["linkmanid"] = value; }
        }

        public string LinkManName
        {
            get { return txtName.Text; }
            set { txtName.Text=value; }
        }

        public string MobileNo
        {
            get { return txtMobil.Text; }
            set { txtMobil.Text=value; }
        }

        public string HomeNo
        {
            get { return txtHome.Text; }
            set { txtHome.Text = value; }
        }

        public string OfficeNo
        {
            get { return txtOffice.Text; }
            set { txtOffice.Text=value; }
        }

        public string EmailAddr
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text=value; }
        }

        public event DelegateNoParameter ActionButtonEvent;
        public event DelegateNoParameter CancelButtonEvent;
        public string OperationTitle
        {
            set { lblOperation.Text = value; }
            get { return lblOperation.Text; }
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

        public bool SetReadonly
        {
            set
            {
                txtEmail.ReadOnly = value;
                txtHome.ReadOnly = value;
                txtMobil.ReadOnly = value;
                txtName.ReadOnly = value;
                txtOffice.ReadOnly = value;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            ActionButtonEvent();
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CancelButtonEvent();
        }
    }
}