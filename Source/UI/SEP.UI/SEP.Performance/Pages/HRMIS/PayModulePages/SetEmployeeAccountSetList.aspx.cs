using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Performance.Views;
using ShiXin.Security;
using DataTable = System.Data.DataTable;
using System.Text;

namespace SEP.Performance.Pages.HRMIS.PayModulePages
{
    public partial class SetEmployeeAccountSetList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["type"] == "Export")
            {
                btnExport();
                return;
            }
            if (!Powers.HasAuth(LoginUser.Auths, AuthType.HRMIS, HrmisPowers.A604))
            {
                throw new ApplicationException("没有权限访问");
            }
            SetEmployeeAccountSetListPresenter presenter = new SetEmployeeAccountSetListPresenter(SetEmployeeAccountSetList1, LoginUser);
            presenter.InitView(IsPostBack);
            SetEmployeeAccountSetList1.BtnUpdateEvent += Update_Command;
            SetEmployeeAccountSetList1.BtnAdjustSalaryHistoryEvent += AdjustSalaryHistory_Command;
            SetEmployeeAccountSetList1.BtnEmployeeSalaryHistoryEvent += EmployeeSalaryHistory_Command;
        }

        private void AdjustSalaryHistory_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("AdjustSalaryHistoryList.aspx?EmployeeID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }

        private void EmployeeSalaryHistory_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("EmployeeSalaryHistoryList.aspx?EmployeeID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }

        private void Update_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("SetEmployeeAccountSet.aspx?EmployeeID=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()), false);
        }


        private void btnExport()
        {
            if (Request.QueryString["txtName"] == null
                || Request.QueryString["listPosition"] == null
                || Request.QueryString["listEmployeeType"] == null
                || Request.QueryString["cbRecursionDepartment"] == null
                || Request.QueryString["listDepartment"] == null
                || Request.QueryString["ddlEmployeeStatus"] == null)
            {
                return;
            }
            DataTable dt =
                InstanceFactory.CreateEmployeeAccountSetFacade().ExportEmployeeAccountSetFacade(
                    Request.QueryString["txtName"].Trim(), Convert.ToInt32(Request.QueryString["listDepartment"]),
                    Convert.ToInt32(Request.QueryString["listPosition"]),
                    EmployeeTypeUtility.GetEmployeeTypeByID(Convert.ToInt32(Request.QueryString["listEmployeeType"])),
                    Convert.ToBoolean(Request.QueryString["cbRecursionDepartment"]), LoginUser, Convert.ToInt32(Request.QueryString["ddlEmployeeStatus"]));
            MemoryStream ms = ExcelExportUtility.DataTableTurnToExcel(dt);
            ExcelExportUtility.OutputExcel(Server, Response, "员工帐套", ms);
        }
    }
}