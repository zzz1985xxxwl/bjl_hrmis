using System;
using System.Web.UI;
using SEP.Presenter.IPresenter.IAccounts;

namespace SEP.Performance.Views.SEP.Accounts
{
    public partial class AssignSEPAuthInfoView : UserControl, IAssignAuthInfoView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.Page.GetType(), "init", "BinGoogledown();", true);
        }

        public IAssignAuthView AssignAuthView
        {
            get { return AssignAuthView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public IAssignAuthDepartmentTree DepartmentTreeView
        {
            get { return DepartmentTreeView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public bool AssignAuthDepartmentTreeVisible
        {
            get { return mpeDepartment.Visible; }
            set
            {
                if (value)
                {
                    mpeDepartment.Show();
                }
                else
                {
                    mpeDepartment.Hide();
                }
            }
        }
    }
}