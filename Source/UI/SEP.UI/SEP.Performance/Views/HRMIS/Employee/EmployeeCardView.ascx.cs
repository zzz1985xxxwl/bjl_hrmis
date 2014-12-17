using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter;
using ShiXin.Security;
using HRMISModel = SEP.HRMIS.Model;


namespace SEP.Performance.Views.Employee
{
    public partial class EmployeeCardView : UserControl, IEmployeeCardView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fill();
            }
        }

        protected void Page_Command(object sender,CommandEventArgs e)
        {
            switch(e.CommandArgument.ToString())
            {
                case "Prev":
                    lblCurrent.Text = (Convert.ToInt32(lblCurrent.Text) - 1).ToString();
                    fill();
                    break;
                case "Next":
                    lblCurrent.Text = (Convert.ToInt32(lblCurrent.Text) + 1).ToString();
                    fill();
                    break;
                case "First":
                    lblCurrent.Text = 0.ToString();
                    fill();
                    break;
                case "Last":
                    lblCurrent.Text = (Convert.ToInt32(lblPageCount.Text) - 1).ToString();
                    fill();
                    break;
                default:
                    break;

            }
        }

        private void fill()
        {
            if (Request.Cookies["EmployeeListShowPattern"] == null 
                || Request.Cookies["EmployeeListShowPattern"].Value!="Card")
            {
                tbEmployeeCard.Style["display"] = "none";
                return;
            }
            tbEmployeeCard.Style["display"] = "block";
            PagedDataSource pds = new PagedDataSource();
            List<HRMISModel.Employee> employees;
            pds.DataSource = employees = Session["Employess"] as List<HRMISModel.Employee>;//卡片与列表之间的切换 viewstate不用
            pds.AllowPaging = true;
            pds.PageSize = 9;
            int currpage = Convert.ToInt32(lblCurrent.Text);
            currpage = currpage < pds.PageCount ? currpage : pds.PageCount - 1;
            pds.CurrentPageIndex = currpage;
            listEmployee.DataSource = pds;
            listEmployee.DataBind();
            //设置共n页第n页
            lblPageCount.Text = pds.PageCount.ToString();
            lblPageIndex.Text = (pds.CurrentPageIndex + 1).ToString();
            //设置上一页下一页enable
            LinkButtonPreviousPage.Enabled = !pds.IsFirstPage;
            LinkButtonFirstPage.Enabled = !pds.IsFirstPage;
            LinkButtonNextPage.Enabled = !pds.IsLastPage;
            LinkButtonLastPage.Enabled = !pds.IsLastPage;
            if (employees != null && pds.PageCount > 1)
            {
                tbPage.Style["display"] = "block";
            }
            else
            {
                tbPage.Style["display"] = "none";
            }
        }


        protected void EmplyeeHistoryCommand(object sender, CommandEventArgs e)
        {
            lblCurrent.Text = "0";
            Response.Redirect("EmplyeeHistoryList.aspx?employeeID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        protected void UpdateEmplyeeCommand(object sender, CommandEventArgs e)
        {
            lblCurrent.Text = "0";
            Response.Redirect("EmployeeUpdate.aspx?employeeID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        //public EventHandler btnSearchEvent;
        //modify by liudan ,delete letter condition
        public void btnSearch_Click()
        {
            //btnSearchEvent(sender, e);
            lblCurrent.Text = "0";
            fill();
        }

        public CommandEventHandler ViewVacation;

        protected void Vacation_Command(object sender, CommandEventArgs e)
        {
            ViewVacation(sender, e);
        }

        public CommandEventHandler ResetPassword;
        protected void Reset_Command(object sender, CommandEventArgs e)
        {
            ResetPassword(sender, e);
        }

        public CommandEventHandler ContractEvent;
        protected void Contract_Command(object sender, CommandEventArgs e)
        {
            ContractEvent(sender, e);
        }

        public void Letter_Search(string letter)
        {
            
            lblCurrent.Text = "0";
            fill();
        }

        #region

        public List<HRMISModel.Employee> Employees
        {
            set
            {
                Session["Employess"] = value;
                //ViewState["_Employee"] = value;
            }
        }

        #endregion

        protected void LinkButtonGoPage_Click(object sender, EventArgs e)
        {
            int index;
            if (int.TryParse(txtGoPage.Text.Trim(), out index))
            {
                index = index < 1 ? 1 : index;
                lblCurrent.Text = (index - 1).ToString();
                fill();
                txtGoPage.Text = string.Empty;
            }
        }
    }
}