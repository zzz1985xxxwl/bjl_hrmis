using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeAccountSet;
using SEP.HRMIS.Model.PayModule;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Presenter.Core;
using SEP.Model.Accounts;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.PayModuleViews
{
    public partial class SetEmployeeSalaryConditionView : System.Web.UI.UserControl, ISetEmployeeSalaryConditionView
    {
        private const int _All = -1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGoToSetEmployeeSalary_Click(object sender, EventArgs e)
        {
            btnGoToSetEmployeeSalaryEvent();
        }


        public List<Position> PositionSource
        {
            set
            {
                listPossition.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, _All.ToString(), true);
                listPossition.Items.Add(itemAll);
                foreach (Position position in value)
                {
                    ListItem item = new ListItem(position.Name, position.ParameterID.ToString(), true);
                    listPossition.Items.Add(item);
                }
            }
        }

        public List<Department> CompanySource
        {
            set
            {
                listCompany.Items.Clear();
                //ListItem itemAll = new ListItem(string.Empty, _All.ToString(), true);
                //listCompany.Items.Add(itemAll);
                foreach (Department department in value)
                {
                    ListItem item = new ListItem(department.DepartmentName, department.DepartmentID.ToString(), true);
                    listCompany.Items.Add(item);
                }
            }
        }

        public int CompanyId
        {
            get { return Convert.ToInt32(listCompany.SelectedValue); }
            set { listCompany.SelectedValue = value.ToString(); }
        }

        public List<Department> DepartmentSource
        {
            set
            {
                listDepartment.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, _All.ToString(), true);
                listDepartment.Items.Add(itemAll);
                foreach (Department department in value)
                {
                    ListItem item = new ListItem(department.DepartmentName, department.DepartmentID.ToString(), true);
                    listDepartment.Items.Add(item);
                }
            }
        }

        public Dictionary<string, string> EmployeeTypeSource
        {
            set
            {
                listEmployeeType.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, _All.ToString(), true);
                listEmployeeType.Items.Add(itemAll);
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    listEmployeeType.Items.Add(item);
                }
            }
        }

        public List<AccountSet> AccountSetSource
        {
            set
            {
                listAccountSet.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, _All.ToString(), true);
                listAccountSet.Items.Add(itemAll);
                foreach (AccountSet accountSet in value)
                {
                    ListItem item = new ListItem(accountSet.AccountSetName, accountSet.AccountSetID.ToString(), true);
                    listAccountSet.Items.Add(item);
                }
            }
        }

        public string SalaryTimeDisplay
        {
            get { return lblSalaryStartTime.Text; }
            set { lblSalaryStartTime.Text = value; }
        }

        //public string SalaryEndTime
        //{
        //    get { return lblSalaryEndTime.Text;  }
        //    set { lblSalaryEndTime.Text = value; }
        //}

        public string SalaryTime
        {
            get { return txtSalaryTime.Text.Trim(); }
            set { txtSalaryTime.Text = value; }
        }

        public string SalaryTimeMsg
        {
            set { lblTimeSalaryMessage.Text = value; }
        }

        public string BackAccountName
        {
            get
            {
                Account account = Session[SessionKeys.LOGININFO] as Account;
                return account != null ? account.Name : string.Empty;
            }
            //get { return Session[SessionUtility.ACCOUNTSNAME].ToString(); }
        }

        public string Message
        {
            set
            {
                lbResultMessage.Text = value;
                tbMessage.Style["display"] = string.IsNullOrEmpty(value) ? "none" : "block";
            }
        }

        public string SetEmployeeSalaryPageURL
        {
            get
            {
                return "SetEmployeeSalary.aspx?"
                       + "salarytime=" + SecurityUtil.DECEncrypt(txtSalaryTime.Text.Trim())
                       + "&departmentid=" + SecurityUtil.DECEncrypt(listDepartment.SelectedValue)
                       + "&positionid=" + SecurityUtil.DECEncrypt(listPossition.SelectedValue)
                       + "&employeetypeid=" + SecurityUtil.DECEncrypt(listEmployeeType.SelectedValue)
                       + "&accountsetid=" + SecurityUtil.DECEncrypt(listAccountSet.SelectedValue)
                       + "&employeename=" + SecurityUtil.DECEncrypt(txtName.Text)
                       + "&companyid=" + SecurityUtil.DECEncrypt(listCompany.SelectedValue)
                       + "&companyname=" + SecurityUtil.DECEncrypt(listCompany.SelectedItem.ToString());
            }
        }

        public event DelegateNoParameter btnGoToSetEmployeeSalaryEvent;
        public event DelegateNoParameter CompanyIndexChangEvent;
        public event EventHandler GoToSetEmployeeSalaryPage;

        protected void listCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompanyIndexChangEvent();
        }
    }
}