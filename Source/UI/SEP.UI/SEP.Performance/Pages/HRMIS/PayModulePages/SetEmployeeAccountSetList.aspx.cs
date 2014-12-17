using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AccountAuth;
using SEP.HRMIS.Presenter.PayModule.EmployeeAccountSet;
using SEP.Model;
using SEP.Model.Accounts;
using SEP.Performance.Views;
using ShiXin.Security;
using DataTable=System.Data.DataTable;

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
                PayModuleInstanceFactory.CreateEmployeeAccountSetFacade().ExportEmployeeAccountSetFacade(
                    Request.QueryString["txtName"].Trim(), Convert.ToInt32(Request.QueryString["listDepartment"]),
                    Convert.ToInt32(Request.QueryString["listPosition"]),
                    EmployeeTypeUtility.GetEmployeeTypeByID(Convert.ToInt32(Request.QueryString["listEmployeeType"])),
                    Convert.ToBoolean(Request.QueryString["cbRecursionDepartment"]), LoginUser, Convert.ToInt32(Request.QueryString["ddlEmployeeStatus"]));
            GC.Collect();
            Application excelApp = new ApplicationClass();
            excelApp.Visible = false;
            List<Worksheet> excelSheetList = new List<Worksheet>();
            Workbook excelBook = excelApp.Workbooks.Add(Type.Missing);
            Worksheet excelSheet1 =
                (Worksheet) excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelSheetList.Add(excelSheet1);
            excelSheet1.Name = "EmployeeAccountSet";

            ExcelExportUtility.DataTableTurnToExcel(dt, excelSheet1);

            object nothing = Type.Missing;
            object fileFormat = XlFileFormat.xlExcel8;
            object file = Server.MapPath(".") + "\\员工帐套.xls";
            if (File.Exists(file.ToString()))
            {
                File.Delete(file.ToString());
            }
            excelBook.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange,
                             nothing, nothing, nothing, nothing, nothing);

            excelBook.Close(false, null, null);

            ExcelExportUtility.ReleaseComObject(excelApp, excelBook, excelSheetList);
            ExcelExportUtility.KillProcess(excelApp, "Excel");
            ExcelExportUtility.OutputExcel(Server, Response, "员工帐套");
        }
    }
}