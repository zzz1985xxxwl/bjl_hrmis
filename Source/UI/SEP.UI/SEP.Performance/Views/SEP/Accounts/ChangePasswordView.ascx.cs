using System;
using System.Web.UI;
using SEP.Presenter.IPresenter.IAccounts;

namespace SEP.Performance.Views.SEP.Accounts
{
    public partial class ChangePasswordView : UserControl, IEmployeeUpdatePasswordView
    {
        private string _EmployeeId;
        public string EmplyeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }

        public string MyID
        {
            get { return lblMyID.Text; }
            set { lblMyID.Text = value; }
        }

        public string MyName
        {
            get { return lblMyName.Text; }
            set { lblMyName.Text = value; }
        }

        public string Message
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    divMessage.Style["display"] = "none";
                }
                else
                {
                    divMessage.Style["display"] = "block";
                    lblMessage.Text = value;
                }
            }
        }

        public string OldPasswordMsg
        {
            set { lblOldPasswordMsg.Text = value; }
        }

        public string ValidatPasswordMsg
        {
            set { lblValidatPasswordMsg.Text = value; }
        }

        public string ConfirmPasswordMsg
        {
            set { lblConfirmPasswordMsg.Text = value; }
        }

        public string EmployeeName
        {
            get { return txtEmployeeName.Text; }
            set { txtEmployeeName.Text = value; }
        }

        public string EmployeeOldPassword
        {
            get { return txtOldPassword.Text; }
            set { txtOldPassword.Text = value; }
        }

        public string EmployeeNewPassword
        {
            get { return TxtNewPassword.Text; }
            set { TxtNewPassword.Text = value; }
        }

        public string EmployeeConfirmPassword
        {
            get { return TxtConfirmPassword.Text; }
            set { TxtConfirmPassword.Text = value; }
        }

        public event EventHandler btnOKClick;
        protected void btnOK_Click(object sender, EventArgs e)
        {

            btnOKClick(sender, e);
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("../IndexPages/Index.aspx");
        }
    }
}