using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.Model.Departments;
using SEP.Model.Positions;
using HRMISModel = SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.Employee
{
    public partial class EmployeeListView : UserControl, IEmployeeListView
    {
        private readonly int _All = -1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string ResultMessage
        {
            set
            {
                lblMessage.Text = value;
            }
        }
        public bool RecursionDepartment
        {
            get
            {
                return cbRecursionDepartment.Checked;
            }
        }

        public string CompanyAgeFrom
        {
            get { return txtCompanyAgeFrom.Text; }
        }

        public string CompanyAgeTo
        {
            get { return txtCompanyAgeTo.Text; }
        }

        //public string CompanyAge
        //{
        //    get { return txtCompanyAge.Text; }
        //}

        public string CompanyAgeError
        {
            set { lblCompanyAgeError.Text = value; }
        }

        public string EmployeeName
        {
            get { return txtName.Text.Trim(); }
        }

        public string ErrorMessage
        {
            set
            {
                if (value.Equals("÷ÿ÷√√‹¬Î≥…π¶"))
                {
                    value = "<span class='fontred'>" + value + "</span>";
                }
                else
                {
                }
                lblMessage.Text = value;
            }
        }

        public string EmployeeStatusId
        {
            get
            {
                return ddlEmployeeStatus.SelectedValue;
            }
        }

        public EmployeeTypeEnum EmployeeType
        {
            get
            {
                return (EmployeeTypeEnum) Convert.ToInt32(listEmployeeType.SelectedValue);
            }
            set
            {
                listEmployeeType.SelectedValue = ((int)value).ToString();
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

        public List<GradesType> GradesSource
        {
            set
            {
                ddGrades.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, "", true);
                ddGrades.Items.Add(itemAll);
                foreach (GradesType g in value)
                {
                    ListItem item = new ListItem(g.Name, g.ID.ToString(), true);
                    ddGrades.Items.Add(item);
                }
            }
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

        public int PositionId
        {
            get
            {
                return Convert.ToInt32(listPossition.SelectedValue);
            }
        }

        public int? GradesId
        {
            get
            {
                if (string.IsNullOrEmpty(ddGrades.SelectedValue)) {
                    return null;
                }
                return Convert.ToInt32(ddGrades.SelectedValue);
            }
        }

        public int DepartmentId
        {
            get { return Convert.ToInt32(listDepartment.SelectedValue); }
        }

        public delegate void btnSearchEvent();

        public btnSearchEvent _ToButtonSearch;
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            _ToButtonSearch();
        }

        public CommandEventHandler LetterEvent;
        protected void Letter_Search(object sender, CommandEventArgs e)
        {
            LetterEvent(sender, e);
        }
        public delegate void ChangeShowPattern();
        public ChangeShowPattern _ChangeShowPattern;


        protected void lbListPattern_Click(object sender, EventArgs e)
        {
            Request.Cookies["EmployeeListShowPattern"].Value = "List";
            //Response.Cookies.Remove("EmployeeListShowPattern");
            HttpCookie httpCookie = new HttpCookie("EmployeeListShowPattern", "List");
            Response.Cookies.Add(httpCookie);
            _ChangeShowPattern();
        }

        protected void lbCardPattern_Click(object sender, EventArgs e)
        {
            Request.Cookies["EmployeeListShowPattern"].Value = "Card";
            //Response.Cookies.Remove("EmployeeListShowPattern");
            HttpCookie httpCookie = new HttpCookie("EmployeeListShowPattern", "Card");
            Response.Cookies.Add(httpCookie);
            _ChangeShowPattern();
        }


    }
}