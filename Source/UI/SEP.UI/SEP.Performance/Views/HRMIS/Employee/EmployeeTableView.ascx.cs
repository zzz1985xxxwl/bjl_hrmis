using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter;
using ShiXin.Security;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.HRMIS.Employee
{
    public partial class EmployeeTableView : UserControl, IEmployeeCardView
    {
        private List<HRMISModel.Employee> _EmployeeList;

        public List<HRMISModel.Employee> Employees
        {
            set { throw new NotImplementedException(); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fill();
            }  
            BindPageTemplate();
        }


        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvEmployee, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        public CommandEventHandler ViewVacation;

        protected void Vacation_Command(object sender, CommandEventArgs e)
        {
            ViewVacation(sender, e);
        }


        protected void EmplyeeHistoryCommand(object sender, CommandEventArgs e)
        {
            Response.Redirect("EmplyeeHistoryList.aspx?employeeID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }


        public CommandEventHandler ContractEvent;
        protected void Contract_Command(object sender, CommandEventArgs e)
        {
            ContractEvent(sender, e);
        }

        //modify by liudan ,delete letter condition
        public void btnSearch_Click()
        {
            fill();
        }
        public void Letter_Search(string letter)
        {
            fill();
        }
        private void fill()
        {
            if (Request.Cookies["EmployeeListShowPattern"] == null
                || Request.Cookies["EmployeeListShowPattern"].Value != "List")
            {
                tbEmployeeList.Style["display"] = "none";
                return;
            }
            List<HRMISModel.Employee> employees = Session["Employess"] as List<HRMISModel.Employee>;
            if (employees == null)
            {
                return;
            }
            _EmployeeList = employees;
            gvEmployee.DataSource = _EmployeeList;
            gvEmployee.DataBind();
            if (_EmployeeList == null || _EmployeeList.Count == 0)
            {
                tbEmployeeList.Style["display"] = "none";
            }
            else
            {
                tbEmployeeList.Style["display"] = "block";
            }
        }
        protected void gvEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    int index = Convert.ToInt32(e.CommandArgument.ToString());
                    Response.Redirect("EmployeeUpdate.aspx?employeeID=" + SecurityUtil.DECEncrypt(index.ToString()));
                    return;
            }


        }
        protected void gvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployee.PageIndex = e.NewPageIndex;
            gvEmployee.DataSource = Session["Employess"] as List<HRMISModel.Employee>;
            gvEmployee.DataBind();
        }

        protected void gvEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvEmployee.PageIndex = pageindex;
            gvEmployee.DataSource = Session["Employess"] as List<HRMISModel.Employee>;
            gvEmployee.DataBind();
        }

    }
}