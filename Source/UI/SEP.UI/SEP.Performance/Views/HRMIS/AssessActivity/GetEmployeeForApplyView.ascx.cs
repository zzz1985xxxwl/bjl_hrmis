using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Departments;
using SEP.Model.Positions;
using ShiXin.Security;
using hrmisModel = SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.Performance.Views.HRMIS.AssessActivity
{
    public partial class GetEmployeeForApplyView : UserControl, IGetEmployeeForApplyView
    {
        private const string _NoEventError = "没有按钮事件的响应，请联系管理员";
        private readonly int _All = -1;
        #region IGetEmployeeForApplyView 成员

        private string _RedirectPage;
        public string RedirectPage
        {
            set { _RedirectPage = value; }
        }

        public string EmployeeName
        {
            get { return txtEmployeeName.Text; }
        }

        private List<Account> _Employees;
        public List<Account> Employees
        {
            get
            {
                return _Employees;
            }
            set
            {
                _Employees = value;
                gvEmployeeForApply.DataSource = value;
                gvEmployeeForApply.DataBind();
                lblMessage.Text = value.Count.ToString();
                if (value.Count > 0)
                {
                    tbSearch.Style["display"] = "block";
                }
                else
                {
                    tbSearch.Style["display"] = "none";
                }
            }
        }
        public bool IsSearch
        {
            set
            {
                trSearch.Visible = value;
                trEmployee.Visible = value;
                trSearchBtn.Visible = value;
            }
        }
        public event EventHandler BindAssessActivity;

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
            get { return Convert.ToInt32(listPossition.SelectedValue); }
        }

        public int DepartmentId
        {
            get { return Convert.ToInt32(listDepartment.SelectedValue); }
        }

        public bool RecursionDepartment
        {
            get { return cbRecursionDepartment.Checked; }
        }

        public EmployeeTypeEnum EmployeeType
        {
            get { return (EmployeeTypeEnum)Convert.ToInt32(listEmployeeType.SelectedValue); }
            set { listEmployeeType.SelectedValue = ((int)value).ToString(); }
        }

        public Dictionary<string, string> EmployeeTypeSource
        {
            set
            {
                listEmployeeType.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, "-1", true);
                listEmployeeType.Items.Add(itemAll);
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    listEmployeeType.Items.Add(item);
                }
            }
        }

        #endregion

        protected void gvEmployeeForApply_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindAssessActivity(null, null);
            gvEmployeeForApply.PageIndex = e.NewPageIndex;
            gvEmployeeForApply.DataSource = _Employees;
            gvEmployeeForApply.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (BindAssessActivity == null)
            {
                throw new ArgumentNullException(_NoEventError);
            }
            BindAssessActivity(sender, e);
        }

        protected void btnApply_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("" + _RedirectPage + "?" + ConstParameters.EmployeeId + "=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
            
        }

        protected void gvEmployeeForApply_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Default);

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvEmployeeForApply, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            BindAssessActivity(null, null);
            gvEmployeeForApply.PageIndex = pageindex;
            gvEmployeeForApply.DataSource = _Employees;
            gvEmployeeForApply.DataBind();
        }
    }
}