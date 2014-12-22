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
using SEPPerformance = SEP.Performance;
using ModelAdvanceSearch = SEP.HRMIS.Model.AdvanceSearch;
namespace SEP.Performance.Pages.HRMIS.AdvanceSearchPages
{
    public partial class ContractAdvanceSearchBackCode : System.Web.UI.Page
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
            List<Contract> resultList = new List<Contract>();
            if (Session["AdvanceSearchContractResult"] != null)
            {
                resultList = Session["AdvanceSearchContractResult"] as List<Contract>;
            }
            s = JsonConvert.SerializeObject(ContractStringValue.Turn(resultList));
            s = s.Replace("null", "\"\"");
            Response.Write(s);
            Response.End();
        }

        private void Search()
        {
            List<SearchField> searchFieldList = new List<SearchField>();
            if (Request.QueryString["condition"] != null)
            {
                searchFieldList =
                    ModelAdvanceSearch.Utility.ConvertStringToSearchFieldList(Request.QueryString["condition"],
                                                                              ContractFieldPara.GetAllContractSearchField());
                ;
            }
            string s;
            try
            {
                Account account = Session[SessionKeys.LOGININFO] as Account;
                List<Contract> resultList =
                    InstanceFactory.CreateAdvanceSearchFacade().AdvanceSearchContractFacade(searchFieldList, account);
                s = JsonConvert.SerializeObject(ContractStringValue.Turn(resultList));
                s = s.Replace("null", "\"\"");
                Session["AdvanceSearchContractColShow"] = Request.QueryString["colshow"];
                Session["AdvanceSearchContractCondition"] = Request.QueryString["condition"];
                Session["AdvanceSearchContractResult"] = resultList;
            }
            catch (Exception ex)
            {
                List<SEPPerformance.Error> error = new List<SEPPerformance.Error>();
                error.Add(new SEPPerformance.Error("doorcardErrorMessage", ex.Message));
                s = JsonConvert.SerializeObject(error);
            }
            Response.Write(s);
            Response.End();
        }
        private void BindExpressionInfo(string fieldParaBaseId)
        {
            Account account = Session[SessionKeys.LOGININFO] as Account;
            IAdvanceSearchFacade IAdvanceSearchFacade = InstanceFactory.CreateAdvanceSearchFacade();
            string result = IAdvanceSearchFacade.BindContractSearchExpression(fieldParaBaseId, account);
            Response.Write(result);
        }

        private void BindSearchFieldInfo(string q)
        {
            string result = String.Empty;
            List<SearchField> allSearchFields = ContractFieldPara.GetAllContractSearchField();

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
            if (Session["AdvanceSearchContractResult"] != null)
            {
                Worksheet excelSheet3 =
                    (Worksheet)excelBook.Sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                excelSheetList.Add(excelSheet3);
                excelSheet3.Name = "员工合同高级查询";
                ExportToExcel(excelSheet3);
            }
            ExcelExportUtility.RemoveBlankWorkSheet(excelBook);
            object nothing = Type.Missing;
            object fileFormat = XlFileFormat.xlExcel8;
            object file = Server.MapPath(".") + "\\员工合同高级查询.xls";
            if (File.Exists(file.ToString()))
            {
                File.Delete(file.ToString());
            }
            excelBook.SaveAs(file, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange,
                             nothing, nothing, nothing, nothing, nothing);

            excelBook.Close(false, null, null);

            ExcelExportUtility.ReleaseComObject(excelApp, excelBook, excelSheetList);
            ExcelExportUtility.KillProcess(excelApp, "Excel");
            ExcelExportUtility.OutputExcel(Server, Response, "员工合同高级查询");
        }

        private void ExportToExcel(_Worksheet excelSheet)
        {
            List<Contract> resultList = new List<Contract>();
            if (Session["AdvanceSearchContractResult"] != null)
            {
                resultList = Session["AdvanceSearchContractResult"] as List<Contract>;
            }
            //二维数组定义是多一个标题行。
            int rowcount = resultList.Count;
            List<SearchField> contractFieldParaList = ContractFieldPara.GetAllContractSearchField();
            int colcount = contractFieldParaList.Count;
            object[,] dataArray = new object[rowcount + 1, colcount];
            string[] colshows = Request.QueryString["colshow"] != null
                                    ? Request.QueryString["colshow"].Split('|')
                                    : null;
            int colIndex = 0;
            for (int j = 0; j < contractFieldParaList.Count; j++)
            {
                if (colshows != null)
                {
                    foreach (string s in colshows)
                    {
                        if (s == j.ToString())
                        {
                            dataArray[0, colIndex] = contractFieldParaList[j].FieldParaBase.FieldName;
                            for (int i = 1; i < rowcount + 1; i++)
                            {
                                dataArray[i, colIndex] = "'" +
                                                  ContractFieldPara.GetSearchFieldValue(resultList[i - 1],
                                                                                        contractFieldParaList[j]);
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
