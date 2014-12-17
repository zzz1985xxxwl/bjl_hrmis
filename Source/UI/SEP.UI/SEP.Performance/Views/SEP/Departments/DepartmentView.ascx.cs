using System;
using System.Web.UI;
using SEP.Presenter.IPresenter.IDepartments;
using SEP.Presenter;

namespace SEP.Performance.Views.Departments
{
    public partial class DepartmentView : UserControl, IDepartmentView
    {
        #region IDepartmentView≥…‘±

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

        public string DepNameMsg
        {
            get { return lblDepNameMsg.Text; }
            set { lblDepNameMsg.Text = value; }
        }
        public string LeaderNameMsg
        {
            get { return lblLeaderNameMsg.Text; }
            set { lblLeaderNameMsg.Text = value; }
        }

        public string ParentID
        {
            get { return hfParentID.Value; }
            set { hfParentID.Value = value; }
        }

        public string OperationTitle
        {
            set { lblOperation.Text = value; }
            get { return lblOperation.Text; }
        }
        //public string Operator
        //{
        //    set { hf_Operator.Value = value; }
        //    get { return hf_Operator.Value; }
        //}
        //public string OperatorID
        //{
        //    set { hf_OperatorID.Value = value; }
        //    get { return hf_OperatorID.Value; }
        //}  
        public string DepartmentID
        {
            get { return txtDepID.Text.Trim(); }
            set { txtDepID.Text = value; }
        }

        public string DepartmentName
        {
            get { return txtDepName.Text.Trim(); }
            set { txtDepName.Text = value; }
        }

        public string LeaderName
        {
            get { return txtLeaderName.Text.Trim(); }
            set { txtLeaderName.Text = value; }
        }

        public string Address
        {
            get { return txtAddress.Text.Trim(); }
            set { txtAddress.Text=value; }
        }

        public string Phone
        {
            get { return txtPhone.Text.Trim(); }
            set { txtPhone.Text=value; }
        }

        public string Fax
        {
            get { return txtFax.Text.Trim(); }
            set { txtFax.Text=value; }
        }

        public string Others
        {
            get { return txtOthers.Text.Trim(); }
            set { txtOthers.Text = value; }
        }

        public string FoundationTime
        {
            get { return txtFoundationTime.Text.Trim(); }
            set { txtFoundationTime.Text = value; }
        }

        public string Description
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text=value; }
        }

        public bool SetReadonly
        {
            set
            {
                txtDepName.ReadOnly = value;
                txtLeaderName.ReadOnly = value;
            }
        }

        public string CancelButtonClientEvent
        {
            set { btnCancel.OnClientClick = value; }
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
        #endregion

        public string TimeErrorMsg
        {
            set { lblTimeError.Text = value; }
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