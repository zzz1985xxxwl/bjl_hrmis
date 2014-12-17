using System;
using SEP.Presenter.IPresenter.IDepartments;

namespace SEP.Performance.Views.Departments
{
    public partial class DepartmentInfoView : System.Web.UI.UserControl, IDepartmentInfoView
    {

        public IDepartmentListView DepartmentListView
        {
            get { return DepartmentListView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public IDepartmentView DepartmentView
        {
            get { return DepartmentView1; }
            set { throw new Exception("The method or operation is not implemented."); }
        }

        public bool DepartmentViewVisible
        {
            get { throw new Exception("The method or operation is not implemented."); }
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

        public string divMPEDepartmentClientID
        {
            get { return divMPEDepartment.ClientID; }
        }
    }
}