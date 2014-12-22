using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Presenter;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Model.Utility;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.PayModuleViews
{
    public partial class SetEmployeeSalary : UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Account loginUser = Session[SessionKeys.LOGININFO] as Account;
            int companyID = Convert.ToInt32(SecurityUtil.DECDecrypt(Request.QueryString["companyid"]));
            ICompanyInvolveFacade _ICompanyFacade = InstanceFactory.CreateCompanyInvolveFacade();
            InitDepartmentSource(companyID, loginUser, _ICompanyFacade);
            InitPositionSource(companyID, _ICompanyFacade);
            InitEmployeeTypeSource();
            InitAccountSetSource();
            InitConst();
        }

        private void InitAccountSetSource()
        {
            IAccountSetFacade _IAccountSetFacade =InstanceFactory.CreateAccountSetFacade();
            List<AccountSet> AccountSetSource = _IAccountSetFacade.GetAccountSetByCondition(string.Empty);
            listAccountSet.Items.Clear();
            ListItem itemAll = new ListItem(string.Empty, "-1", true);
            listAccountSet.Items.Add(itemAll);
            foreach (AccountSet accountSet in AccountSetSource)
            {
                ListItem item = new ListItem(accountSet.AccountSetName, accountSet.AccountSetID.ToString(), true);
                listAccountSet.Items.Add(item);
            }
        }

        private void InitConst()
        {
            listDepartment.SelectedValue = SecurityUtil.DECDecrypt(Request.QueryString["departmentid"]);
            DateTime salaryTime = Convert.ToDateTime(SecurityUtil.DECDecrypt(Request.QueryString["salarytime"]));
            txtSalaryTime.Text = new HrmisUtility().StartMonthByYearMonth(salaryTime).ToShortDateString();
            listPossition.SelectedValue = SecurityUtil.DECDecrypt(Request.QueryString["positionid"]);
            txtName.Text = SecurityUtil.DECDecrypt(Request.QueryString["employeename"]);
            listAccountSet.SelectedValue = SecurityUtil.DECDecrypt(Request.QueryString["accountsetid"]);
            listEmployeeType.SelectedValue = SecurityUtil.DECDecrypt(Request.QueryString["employeetypeid"]);
            lblCompanyName.Text = SecurityUtil.DECDecrypt(Request.QueryString["companyname"]);
            hfCompanyID.Value = SecurityUtil.DECDecrypt(Request.QueryString["companyid"]);
            lblSalaryTime.Text = new HrmisUtility().StartMonthByYearMonth(salaryTime).ToShortDateString();
            lblSalaryEndTime.Text = new HrmisUtility().EndMonthByYearMonth(salaryTime).ToShortDateString();
        }

        private void InitEmployeeTypeSource()
        {
            Dictionary<string, string> employeeTypeSource = EmployeeTypeUtility.GetAllEmployeeTypeEnum();
            listEmployeeType.Items.Clear();
            ListItem itemAll = new ListItem(string.Empty, "-1", true);
            listEmployeeType.Items.Add(itemAll);
            foreach (KeyValuePair<string, string> pair in employeeTypeSource)
            {
                ListItem item = new ListItem(pair.Value, pair.Key, true);
                listEmployeeType.Items.Add(item);
            }
        }

        private void InitPositionSource(int companyID, ICompanyInvolveFacade _ICompanyFacade)
        {
            List<Position> positionSource = _ICompanyFacade.GetPositionByCompanyID(companyID);

            listPossition.Items.Clear();
            ListItem itemAll = new ListItem(string.Empty, "-1", true);
            listPossition.Items.Add(itemAll);
            foreach (Position position in positionSource)
            {
                ListItem item = new ListItem(position.Name, position.ParameterID.ToString(), true);
                listPossition.Items.Add(item);
            }
        }

        private void InitDepartmentSource(int companyID, Account loginUser,
                                          ICompanyInvolveFacade _ICompanyFacade)
        {
            List<Department> deptList = _ICompanyFacade.GetDepartmentByCompanyID(companyID);
            List<Department> departmentSource =
                Tools.RemoteUnAuthDeparetment(deptList, AuthType.HRMIS, loginUser, HrmisPowers.A606);
            listDepartment.Items.Clear();
            ListItem itemAll = new ListItem(string.Empty, "-1", true);
            listDepartment.Items.Add(itemAll);
            foreach (Department department in departmentSource)
            {
                ListItem item = new ListItem(department.DepartmentName, department.DepartmentID.ToString(), true);
                listDepartment.Items.Add(item);
            }
        }
    }
}