using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Presenter;
using SEP.Presenter.IPresenter.IEmployees;

namespace SEP.Performance.Views.SEP.Employees
{
    public partial class EmployeeDatagridListView : UserControl, IEmployeeDatagridListPresenter
    {
        private readonly int _All = -1;

        protected void Page_Load(object sender, EventArgs e)
        {

            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            BtnSearchEvent();
            grvEmployee.PageIndex = pageindex;
            grvEmployee.DataSource = _AccountList;
            grvEmployee.DataBind();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(grvEmployee, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        public event DelegateNoParameter BtnSearchEvent;
        public bool RecursionDepartment
        {
            get { return cbRecursionDepartment.Checked; }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }

        protected void grvEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            //if (btnHiddenPostButton != null)
            //{
            //    ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            //}
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        public event DelegateID EmployeeDetailEvent;
        protected void grvEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    if (EmployeeDetailEvent != null)
                    {
                        EmployeeDetailEvent(e.CommandArgument.ToString());
                    }
                    return;
            }
        }

        protected void grvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BtnSearchEvent();
            grvEmployee.PageIndex = e.NewPageIndex;
            grvEmployee.DataSource = _AccountList;
            grvEmployee.DataBind();
        }

        public event DelegateID BtnUpdateEvent;
        protected void Update_Command(object sender, CommandEventArgs e)
        {
            BtnUpdateEvent(e.CommandArgument.ToString());
        }

        public event DelegateID BtnResetPasswordEvent;
        protected void ResetPassword_Command(object sender, CommandEventArgs e)
        {
            if (BtnResetPasswordEvent != null)
                BtnResetPasswordEvent(e.CommandArgument.ToString());
        }

        public event DelegateNoParameter BtnAddEvent;
        protected void Add_Command(object sender, EventArgs e)
        {
            BtnAddEvent();
        }

        private List<Account> _AccountList;
        public List<Account> AccountList
        {
            set
            {
                _AccountList = value;
                grvEmployee.DataSource = value;
                grvEmployee.DataBind();
                if (value.Count > 0)
                {
                    tbEmployeeGridView.Style["display"] = "block";
                }
                else
                {
                    tbEmployeeGridView.Style["display"] = "none";
                }
            }
        }

        public string ResultMessage
        {
            get
            {
                return lblMessage.Text;
            }
            set
            {
                lblMessage.Text = value;
            }
        }

        public string EmployeeName
        {
            get
            {
                return txtName.Text.Trim();
            }
            set
            {
                txtName.Text = value;
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

        public string PositionID
        {
            get
            {
                return ddlPosition.SelectedValue;
            }
            set
            {
                ddlPosition.SelectedValue = value;
            }
        }

        public string GradesID
        {
            get
            {
                return ddlGrades.SelectedValue;
            }
            set
            {
                ddlGrades.SelectedValue = value;
            }
        }

        public string IfValidate
        {
            get
            {
                return ddlValidate.SelectedValue;
            }
            set
            {
                ddlValidate.SelectedValue = value;
            }
        }

        public List<Department> DepartmentSource
        {
            set
            {
                ddlDepartment.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, _All.ToString(), true);
                ddlDepartment.Items.Add(itemAll);
                foreach (Department pair in value)
                {
                    ListItem item = new ListItem(pair.Name, pair.Id.ToString(), true);
                    ddlDepartment.Items.Add(item);
                }
            }
        }

        public List<Position> PositionSource
        {
            set
            {
                ddlPosition.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, _All.ToString(), true);
                ddlPosition.Items.Add(itemAll);
                foreach (Position pair in value)
                {
                    ListItem item = new ListItem(pair.Name, pair.Id.ToString(), true);
                    ddlPosition.Items.Add(item);
                }
            }
        }
        public List<GradesType> GradesTypeSource
        {
            set
            {
                ddlGrades.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, "", true);
                ddlGrades.Items.Add(itemAll);
                foreach (var g in value)
                {
                    ListItem item = new ListItem(g.Name, g.ID.ToString(), true);
                    ddlGrades.Items.Add(item);
                }
            }
        }
    }
}