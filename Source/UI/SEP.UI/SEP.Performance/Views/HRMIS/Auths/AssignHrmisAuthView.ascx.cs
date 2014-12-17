using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.IPresenter.IAuth;
using SEP.Model.Accounts;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.Auths
{
    public partial class AssignHrmisAuthView : UserControl, IAssignHrmisAuthView
    {
        public event EventHandler btnOKClick;
        public event DelegateID btnLinkClick;
        public event EventHandler drdRoleSelectedIndexChanged;

        private const string _NoEventError = "没有按钮事件的响应，请联系管理员";

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnOKClick == null)
            {
                throw new ArgumentNullException(_NoEventError);
            }
            btnOKClick(sender, e);
        }

        protected void drdRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drdRoleSelectedIndexChanged == null)
            {
                throw new ArgumentNullException(_NoEventError);
            }
            drdRoleSelectedIndexChanged(sender, e);
        }

        public string AccountBackName
        {
            get { return txtAccount.Text.Trim(); }
        }


        public string ResultMessage
        {
            get
            {
                //测试需要
                throw new Exception("The method or operation is not implemented.");
            }
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

        public List<Auth> AccountsBackAuth
        {
            get
            {
                return GetBackAccountsAuth();
            }
            set
            {
                SetBackAccountsAuth(value);
            }
        }

        private List<Auth> GetBackAccountsAuth()
        {
            List<Auth> backAccountsAuth = new List<Auth>();
            foreach (Control control in Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    CheckBox checkBox = (CheckBox)control;
                    if (checkBox.Checked)
                    {
                        int authID = Convert.ToInt32(checkBox.ID.Substring(2));
                        backAccountsAuth.Add(new Auth(authID, ""));
                    }
                }
            }
            return backAccountsAuth;
        }

        private void SetBackAccountsAuth(List<Auth> auths)
        {
            foreach (Control control in Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                    foreach (Auth auth in auths)
                    {
                        if (checkBox.ID == "cb" + auth.Id)
                        {
                            checkBox.Checked = true;
                        }
                    }
                }
            }
        }

        public List<Auth> AuthSource
        {
            get
            {
                return (List<Auth>)Session["_BackAccountsAuth"];
            }
            set
            {
                Session["_BackAccountsAuth"] = value;
            }
        }

        protected void ib402_Click(object sender, ImageClickEventArgs e)
        {
            btnLinkClick(((Control)(sender)).ID.Substring(2));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (drdRoleSelectedIndexChanged == null)
            {
                throw new ArgumentNullException(_NoEventError);
            }
            drdRoleSelectedIndexChanged(sender, e);
        }
    }
}