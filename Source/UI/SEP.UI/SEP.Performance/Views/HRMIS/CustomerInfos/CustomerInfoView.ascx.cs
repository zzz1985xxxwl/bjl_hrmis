using System;
using SEP.Presenter.Core;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IParamter.ICustomerInfo;

namespace SEP.Performance.Views.HRMIS.CustomerInfos
{
    public partial class CustomerInfoView : UserControl, ICustomerInfoView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('divMPE');";
        }

        public string Message
        {
            set
            {
                lblMessage.Text = value;
                tbMessage.Visible = !string.IsNullOrEmpty(value);
            }
        }

        public string NameMsg
        {
            set { lblNameMessage.Text = value; }
        }

        public string CustomerInfoID
        {
            get
            {
                return hfCustomerInfoID.Value;
            }
            set { hfCustomerInfoID.Value = value; }
        }

        public string CompanyName
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value; }
        }

        public event DelegateNoParameter ActionButtonEvent;
        public event DelegateNoParameter CancelButtonEvent;
        public string OperationTitle
        {
            get { return lblOperation.Text; }
            set { lblOperation.Text = value; }
        }

        public string OperationType
        {
            get { return hfOperation.Value; }
            set { hfOperation.Value = value; }
        }
        private bool actionSuccess;
        public bool ActionSuccess
        {
            get { return actionSuccess; }
            set { actionSuccess = value; }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (ActionButtonEvent != null)
            {
                ActionButtonEvent();
            }
        }
    }
}