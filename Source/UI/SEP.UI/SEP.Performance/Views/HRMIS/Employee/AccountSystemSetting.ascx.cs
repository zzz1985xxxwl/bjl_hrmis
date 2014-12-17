using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IEmployee;

namespace SEP.Performance.Views.Employee
{
    public partial class AccountSystemSetting : UserControl, IAccountSystemSettingView
    {
        public int IfReceiveMessage
        {
            get
            {
                return Convert.ToInt32(rblIfReceiveMessage.SelectedValue);
            }
            set
            {
                rblIfReceiveMessage.SelectedValue = value.ToString();
            }
        }

        public int EmployeeID
        {
            get
            {
                return Convert.ToInt32(hfEmployeeID.Value);
            }
            set
            {
                hfEmployeeID.Value = value.ToString();
            }
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

        public event EventHandler btnOKClick;
        protected void btnOK_Click(object sender, EventArgs e)
        {
            btnOKClick(sender, e);
        }
    }
}