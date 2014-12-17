using System;
using SEP.HRMIS.Presenter.IPresenter.IEmployee;

namespace SEP.Performance.Views.Employee
{
    public partial class EmployeeUpdatePasswordView : System.Web.UI.UserControl,IEmployeeUpdatePasswordView
    {
        private string _EmployeeId;
        public string EmployeeID
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
                   tbMessage.Style["display"] = "none";
               }
               else
               {
                   tbMessage.Style["display"] = "block";
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
            set { txtEmployeeName.Text= value; }
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

        public int UsbKeyCount
        {
            get
            {
                if (String.IsNullOrEmpty(lbUsbKeyCount.Value))
                    return 0;
                else
                    return Convert.ToInt32(lbUsbKeyCount.Value.Trim());
            }
        }

        public string UsbKey
        {
            get
            {
                return lbUsbKey.Value.Trim();
            }
            set
            {
                lbUsbKey.Value = value;
            }
        }

        public string OldUsbKey
        {
            get
            {
                return tbUsbKey.Text.Trim();
            }
            set
            {
                tbUsbKey.Text = value;
            }
        }

        public bool ResetUsbKey
        {
            set
            {
                if (value)
                {
                    tbResetUsbKey.Style["display"] = "block";
                }
                else
                {
                    tbResetUsbKey.Style["display"] = "none";
                }
            }
        }

        public event EventHandler btnOKClick;
        protected void btnOK_Click(object sender, EventArgs e)
        {
            btnOKClick(sender, e);
        }

        public event EventHandler btnResetUSBClick;
        protected void btnResetUSB_Click(object sender, EventArgs e)
        {
            btnResetUSBClick(sender, e);
        }
    }
}