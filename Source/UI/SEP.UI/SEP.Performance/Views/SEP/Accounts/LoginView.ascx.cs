using System;
using System.Web.Security;
using System.Web.UI;
using SEP.Model.Accounts;
using SEP.Presenter.Accounts;
using SEP.Presenter.IPresenter.IAccounts;
using SEP.Model;

namespace SEP.Performance.Views
{
    public partial class LoginView : UserControl, ILoginView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();

            LoginPresenter presenter = new LoginPresenter(this, IsPostBack);
            presenter.InitLogin();
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (btnOKClick != null)
                btnOKClick(sender, e);

            if (Session[SessionKeys.LOGININFO] == null)
            {
                Session.Clear();
            }
            else
            {
                Account account = (Account)Session[SessionKeys.LOGININFO];
                //FormsAuthentication.SetAuthCookie(account.Id.ToString(), true);
                Response.Redirect("SEP/IndexPages/Index.aspx");
            }
        }

        #region ILoginView ≥…‘±

        public string Message
        {
            get { return lblResultMessage.Text; }
            set { lblResultMessage.Text = value; }
        }

        public string ValidateLoginName
        {
            get { return lblValidateLoginName.Text; }
            set { lblValidateLoginName.Text = value; }
        }

        public string ValidatePassword
        {
            get { return lblValidatePassword.Text; }
            set { lblValidatePassword.Text = value; }
        }

        public string LoginName
        {
            get { return txtLoginName.Text.Trim(); }
            set { txtLoginName.Text = value; }
        }

        public string Password
        {
            get { return txtPassword.Text.Trim(); }
            set { txtPassword.Text = value; }
        }


        public int UsbKeyCount
        {
            get
            {
                if (String.IsNullOrEmpty(lbUsbKeyCount.Value))
                {
                    return 0;
                }

                return Convert.ToInt32(lbUsbKeyCount.Value.Trim());
            }
        }

        public string UsbKey
        {
            get { return lbUsbKey.Value.Trim(); }
            set { lbUsbKey.Value = value; }
        }

        public event EventHandler btnOKClick;

        public Account LoginUser
        {
            set
            {
                Session[SessionKeys.LOGININFO] = value;
            }
        }

        #endregion
    }
}
