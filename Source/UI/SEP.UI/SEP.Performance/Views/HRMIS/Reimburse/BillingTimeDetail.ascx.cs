using System;
using System.Web.UI;
using SEP.HRMIS.Presenter;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.Reimburse
{
    public partial class BillingTimeDetail : UserControl, IBillingTimeDetailView
    {
        #region IBillingTimeDetailView 成员

        public string Message
        {
            set
            {
                lblResultMessage.Text = value;
                tbMessage.Style["display"] = string.IsNullOrEmpty(value) ? "none" : "block";
            }
        }

        public string BillingTimeMessage
        {
            get { return MsgBillingTime.Text; }
            set { MsgBillingTime.Text = value; }
        }

        public string BillingTime
        {
            get { return txtBillingTime.Text; }
            set { txtBillingTime.Text = value; }
        }

        public string OperationTitle
        {
            get { return lblOperationInfo.Text; }
            set { lblOperationInfo.Text = value; }
        }

        public event DelegateNoParameter ActionButtonEvent;

        private bool actionSuccess;
        public bool ActionSuccess
        {
            get { return actionSuccess; }
            set { actionSuccess = value; }
        }

        public string OperationType
        {
            get { return lblOperation.Value; }
            set { lblOperation.Value = value; }
        }

        #endregion

        protected void btnOK_Click(object sender, EventArgs e)
        {
            ActionButtonEvent();
        }

        #region IBillingTimeDetailView 成员


        public string ReimburseID
        {
            get { return lblReimburseId.Text; }
            set { lblReimburseId.Text = value; }
        }

        #endregion
    }
}