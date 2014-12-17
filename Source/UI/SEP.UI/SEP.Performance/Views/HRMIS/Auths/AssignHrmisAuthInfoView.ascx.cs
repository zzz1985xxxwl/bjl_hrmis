using System;
using System.Web.UI;
using SEP.HRMIS.Presenter.IPresenter.IAuth;

namespace SEP.Performance.Views.HRMIS.Auths
{
    public partial class AssignHrmisAuthInfoView : UserControl, IAssignAuthInfoView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.Page.GetType(), "init", "BinGoogledown();", true);
        }

        public IAssignHrmisAuthView AssignHrmisAuthView
        {
            get { return AssignHrmisAuthView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public IAssignAuthDepartmentTree DepartmentTreeView
        {
            get { return DepartmentTreeView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public bool AssignAuthDepartmentTreeVisible
        {
            get
            {
                return mpeDepartment.Visible;
            }
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