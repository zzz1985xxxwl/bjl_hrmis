using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AdvancedCondition;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.AdvanceSearch;
using SEP.HRMIS.Presenter;
using SEP.Model.Accounts;
using SEP.Performance.Views;
using Page=System.Web.UI.Page;
using SEPPerformance=SEP.Performance;
using ModelAdvanceSearch =SEP.HRMIS.Model.AdvanceSearch;

namespace SEP.Performance.Pages.HRMIS.AdvanceSearchPages
{
    public partial class EmployeeAdvanceSearchBackCode : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Charset = "utf-8";
            Response.Buffer = true;
            EnableViewState = false;
            Response.ContentEncoding = Encoding.UTF8;
            Response.ContentType = "text/plain";

            if (Request.QueryString["operation"] != null
                && Request.QueryString["operation"] == "Initial")
            {
                Initial();
            }
            if (Request.QueryString["operation"] != null
                && Request.QueryString["operation"] == "Search")
            {
                Search();
            }
            if (Request.QueryString["operation"] != null
                && Request.QueryString["operation"] == "Export")
            {
                Export();
            }
            if (Request.QueryString["operation"] != null
                 && Request.QueryString["operation"] == "ExpressionInfo"
                 && Request.QueryString["FieldParaBaseId"] != null)
            {
                BindExpressionInfo(Request.QueryString["FieldParaBaseId"]);
            }
            if (Request.QueryString["operation"] != null
                && Request.QueryString["operation"] == "SearchFieldInfo"
                && Request.QueryString["q"] != null)
            {
                BindSearchFieldInfo(Request.QueryString["q"]);
            }
            Response.Flush();
            Response.Close();
            Response.End();

        }

        private void Initial()
        {
            string s = string.Empty;
            List<Employee> resultList = new List<Employee>();
            if (Session["AdvanceSearchEmployeeResult"] != null)
            {
                resultList = Session["AdvanceSearchEmployeeResult"] as List<Employee>;
            }
            s = JsonConvert.SerializeObject(EmployeeStringValue.Turn(resultList));
            s = s.Replace("null", "\"\"");
            Response.Write(string.Format("{{itemList:{0}}}", s));
            Response.End();
        }

        private void Search()
        {
            List<SearchField> searchFieldList = new List<SearchField>();
            if (Request.QueryString["condition"] != null)
            {
                searchFieldList =
                    ModelAdvanceSearch.Utility.ConvertStringToSearchFieldList(Request.QueryString["condition"],
                                                                              EmployeeFieldPara.GetAllEmployeeSearchField());
                ;
            }
            string si = "{}", se = "{}";
            try
            {
                Account account = Session[SessionKeys.LOGININFO] as Account;
                List<Employee> resultList =
                    InstanceFactory.CreateAdvanceSearchFacade().AdvanceSearchEmployeeFacade(searchFieldList, account);
                si = JsonConvert.SerializeObject(EmployeeStringValue.Turn(resultList));
                si = si.Replace("null", "\"\"");
                Session["AdvanceSearchEmployeeColShow"] = Request.QueryString["colshow"];
                Session["AdvanceSearchEmployeeCondition"] = Request.QueryString["condition"];
                Session["AdvanceSearchEmployeeResult"] = resultList;
            }
            catch (Exception ex)
            {
                List<SEPPerformance.Error> error = new List<SEPPerformance.Error>();
                error.Add(new SEPPerformance.Error("doorcardErrorMessage", ex.Message));
                se = JsonConvert.SerializeObject(error);
            }
            Response.Write(string.Format("{{itemList:{0},error:{1}}}", si, se));
            Response.End();
        }
        private void BindExpressionInfo(string fieldParaBaseId)
        {
            Account account = Session[SessionKeys.LOGININFO] as Account;
            IAdvanceSearchFacade IAdvanceSearchFacade = InstanceFactory.CreateAdvanceSearchFacade();
            string result = IAdvanceSearchFacade.BindEmployeeSearchExpression(fieldParaBaseId, account);
            Response.Write(result);
        }

        private void BindSearchFieldInfo(string q)
        {
            string result = String.Empty;
            List<SearchField> allSearchFields = EmployeeFieldPara.GetAllEmployeeSearchField();

            foreach (SearchField item in allSearchFields)
            {
                bool isCompareSuccess = false;
                foreach (string abbreviation in item.FieldParaBase.Abbreviations)
                {
                    if (abbreviation.StartsWith(q))
                    {
                        isCompareSuccess = true;
                        break;
                    }
                }
                if (isCompareSuccess)
                {
                    result += string.IsNullOrEmpty(result)
                                  ? item.FieldParaBase.FieldName
                                  : "\n" + item.FieldParaBase.FieldName;
                }
            }
            Response.Write(result);
        }

        private void Export()
        {
            GC.Collect();
            Application excelApp = new ApplicationClass();
            excelApp.Visible = false;
            List<Worksheet> excelSheetList = new List<Worksheet>();
            Workbook excelBook = excelApp.Workbooks.Add(Type.Missing);
            if (Session["AdvanceSearchEmployeeResult"] != null)
            {
                Worksheet excelSheet3 =
                    (Worksheet)excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelSheetList.Add(excelSheet3);
                excelSheet3.Name = "员工高级查询";
                ExportToExcel(excelSheet3);
            }
            ExcelExportUtility.RemoveBlankWorkSheet(excelBook);
            object nothing = Type.Missing;
            object fileFormat = XlFileFormat.xlExcel8;
            object file = Server.MapPath(".") + "\\员工高级查询.xls";
            if (File.Exists(file.ToString()))
            {
                File.Delete(file.ToString());
            }
            excelBook.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange,
                             nothing, nothing, nothing, nothing, nothing);

            excelBook.Close(false, null, null);

            ExcelExportUtility.ReleaseComObject(excelApp, excelBook, excelSheetList);
            ExcelExportUtility.KillProcess(excelApp, "Excel");
            ExcelExportUtility.OutputExcel(Server, Response, "员工高级查询");
        }

        private void ExportToExcel(_Worksheet excelSheet)
        {
            List<Employee> resultList = new List<Employee>();
            if (Session["AdvanceSearchEmployeeResult"] != null)
            {
                resultList = Session["AdvanceSearchEmployeeResult"] as List<Employee>;
            }
            //二维数组定义是多一个标题行。
            int rowcount = resultList.Count;
            List<SearchField> employeeFieldParaList = EmployeeFieldPara.GetAllEmployeeSearchField();
            int colcount = employeeFieldParaList.Count;
            object[,] dataArray = new object[rowcount + 1, colcount];
            string[] colshows = Request.QueryString["colshow"] != null
                                    ? Request.QueryString["colshow"].Split('|')
                                    : null;
            int colIndex = 0;
            for (int j = 0; j < employeeFieldParaList.Count; j++)
            {
                if (colshows != null)
                {
                    foreach (string s in colshows)
                    {
                        if (s == j.ToString())
                        {
                            dataArray[0, colIndex] = employeeFieldParaList[j].FieldParaBase.FieldName;
                            for (int i = 1; i < rowcount + 1; i++)
                            {
                                dataArray[i, colIndex] = "'" +
                                                  EmployeeFieldPara.GetSearchFieldValue(resultList[i - 1],
                                                                                        employeeFieldParaList[j]);
                            }
                            colIndex++;
                            break;
                        }
                    }
                }
            }
            excelSheet.get_Range("A1", excelSheet.Cells[rowcount + 1, colcount]).Value2 = dataArray;
        }
    }
}

