using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Performance.Pages;
using SEP.Presenter;
using SEP.Presenter.IPresenter.IEmployees;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.SEP.Employees
{
    public partial class EmployeeDetailView : UserControl, IEmployeeDetailPresenter
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cbHRMIS.Enabled = BasePage.HasHrmisSystem;
            cbMYCMMI.Enabled = BasePage.HasMyCMMISystem;
            cbCRM.Enabled = BasePage.HasCRMSystem;
            cbEShopping.Enabled = BasePage.HasEShoppingSystem;
           
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (BtnOKEvent != null)
                BtnOKEvent(sender, e);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (BtnCancelEvent != null)
                BtnCancelEvent();
        }

        #region IEmployeeDetailPresenter ≥…‘±

        public int EmployeeID
        {
            get
            {
                return Convert.ToInt32(hfOperation.Value);
            }
            set
            {
                tbID.Text = value.ToString();
                hfOperation.Value = value.ToString();
            }
        }

        public string Operation
        {
            get
            {
                return lblOperation.Text;
            }
            set
            {
                lblOperation.Text = value;
            }
        }

        public string LoginNameMsg
        {
            get
            {
                return lblLoginNameMsg.Text;
            }
            set
            {
                lblLoginNameMsg.Text = value;
            }
        }

        public string NameMsg
        {
            get
            {
                return lbNameMsg.Text;
            }
            set
            {
                lbNameMsg.Text = value;
            }
        }

        public string EmailMsg
        {
            get
            {
                return lblEmailMsg.Text;
            }
            set
            {
                lblEmailMsg.Text = value;
            }
        }

        public string EmailMsg2
        {
            get
            {
                return lblEmailMsg2.Text;
            }
            set
            {
                lblEmailMsg2.Text = value;
            }
        }

        public string PositionMsg
        {
            get
            {
                return lbPosition.Text;
            }
            set
            {
                lbPosition.Text = value;
            }
        }

        public string DepartmentMsg
        {
            get
            {
                return lbDepartment.Text;
            }
            set
            {
                lbDepartment.Text = value;
            }
        }

        public string ResultMessage
        {
            get
            {
                return lbResultMessage.Text;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    divResultMessage.Style["display"] = "none";
                }
                else
                {
                    divResultMessage.Style["display"] = "block";
                    lbResultMessage.Text = value;
                }
            }
        }

        public string LoginName
        {
            get
            {
                return tbLoginName.Text;
            }
            set
            {
                tbLoginName.Text = value;
            }
        }

        public string EmployeeName
        {
            get
            {
                return tbName.Text;
            }
            set
            {
                tbName.Text = value;
            }
        }

        public string PhoneNum
        {
            get
            {
                return tbPhone.Text;
            }
            set
            {
                tbPhone.Text = value;
            }
        }

        public string DepartmentID
        {
            get
            {
                return ddlDepartment.SelectedValue;
            }
            set
            {
                ddlDepartment.SelectedValue = value;
            }
        }

        public string PositionName
        {
            get
            {
                return txtPosition.Text.Trim();
            }
            set
            {
                txtPosition.Text = value;
            }
        }

        public int? Grades
        {
            get
            {
                if (string.IsNullOrEmpty(ddGrades.SelectedValue))
                {
                    return null;
                }
                return Convert.ToInt32(ddGrades.SelectedValue);
            }
            set
            {
                if (value == null)
                {
                    ddGrades.SelectedValue = "";
                }
                ddGrades.SelectedValue = value.GetValueOrDefault().ToString();
            }
        }

        public string Email
        {
            get
            {
                return tbEmail.Text;
            }
            set
            {
                tbEmail.Text = value;
            }
        }

        public string Email2
        {
            get
            {
                return tbEmail2.Text;
            }
            set
            {
                tbEmail2.Text = value;
            }
        }

        public int IfValidate
        {
            get
            {
                return rbValidate.SelectedIndex;
            }
            set
            {
                rbValidate.SelectedIndex = value;
            }
        }

        public List<Department> DepartmentSource
        {
            set
            {
                foreach (Department department in value)
                {
                    ListItem item = new ListItem(department.Name, department.Id.ToString(), true);
                    ddlDepartment.Items.Add(item);
                }
            }
        }

        public List<GradesType> GradesTypeSource
        {
            set
            {
                ddGrades.Items.Clear();
                ddGrades.Items.Add(new ListItem("", ""));
                foreach (var g in value)
                {
                    ddGrades.Items.Add(new ListItem(g.Name, g.ID.ToString()));
                }
            }
        }


        public bool IfMyCMMI
        {
            get
            {
                return cbMYCMMI.Checked;
            }
            set
            {
                cbMYCMMI.Checked = value;
            }
        }

        public bool IfCRM
        {
            get
            {
                return cbCRM.Checked;
            }
            set
            {
                cbCRM.Checked = value;
            }
        }

        public bool IfHRMIS
        {
            get
            {
                return cbHRMIS.Checked;
            }
            set
            {
                cbHRMIS.Checked = value;
            }
        }

        public bool IfEShopping
        {
            get
            {
                return cbEShopping.Checked;
            }
            set
            {
                cbEShopping.Checked = value;
            }
        }

        public event EventHandler BtnOKEvent;
        public event DelegateNoParameter BtnCancelEvent;

        #endregion
    }
}