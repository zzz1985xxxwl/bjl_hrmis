using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.PayModule.IPresenter.IEmployeeWelfares;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Presenter.Core;
using TextBox=System.Web.UI.WebControls.TextBox;

namespace SEP.Performance.Views.HRMIS.PayModuleViews.EmployeeWelfares
{
    public partial class EmployeeWelfareSearchList : UserControl, IEmployeeWelfareListView
    {
        private readonly int _All = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            GetValueFromGridView();
            gvEmployeeWelfare.PageIndex = pageindex;
            GVDataBind();

            //gvEmployeeWelfare.PageIndex = pageindex;
            //btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvEmployeeWelfare, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEvent();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetValueFromGridView();
            SaveEvent();
        }

        protected void gvEmployeeWelfare_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GetValueFromGridView();
            gvEmployeeWelfare.PageIndex = e.NewPageIndex;
            GVDataBind();
        }

        public List<EmployeeWelfare> EmployeeWelfareList
        {
            get { return EmployeeWelfareListViewState; }
            set
            {
                EmployeeWelfareListViewState = value;
                gvEmployeeWelfare.PageIndex = 0;
                GVDataBind();
            }
        }

        public void GVDataBind()
        {
            gvEmployeeWelfare.DataSource = EmployeeWelfareListViewState;
            gvEmployeeWelfare.DataBind();
            PageIndex = gvEmployeeWelfare.PageIndex;
            SetGridViewValue();
        }

        private List<EmployeeWelfare> EmployeeWelfareListViewState
        {
            get { return ViewState["EmployeeWelfare"] as List<EmployeeWelfare>; }
            set { ViewState["EmployeeWelfare"] = value; }
        }
        public string EmployeeStatusId
        {
            get
            {
                return ddlEmployeeStatus.SelectedValue;
            }
        }

        public List<Department> CompanySource
        {
            set 
            {                 
                ddlCompany.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, _All.ToString(), true);
                ddlCompany.Items.Add(itemAll);
                foreach (Department department in value)
                {
                    ListItem item = new ListItem(department.DepartmentName, department.DepartmentID.ToString(), true);
                    ddlCompany.Items.Add(item);
                }
            }
        }

        public int CompanyId
        {
            get { return Convert.ToInt32(ddlCompany.SelectedValue); }
            set { ddlCompany.SelectedValue = value.ToString(); }
        }


        private void SetGridViewValue()
        {
            for (int i = 0; i < gvEmployeeWelfare.Rows.Count; i++)
            {
                SetGridViewRowddSocialSecurityTypeDisplay(i);
                SetGridViewRowDateDisplay(i);
            }
        }

        private void SetGridViewRowddSocialSecurityTypeDisplay(int rowIndex)
        {
            DropDownList ddSocialSecurityType =
                (DropDownList) gvEmployeeWelfare.Rows[rowIndex].FindControl("ddSocialSecurityType");
            if (ddSocialSecurityType != null)
            {
                ddSocialSecurityType.DataSource = SocialSecurityTypeEnum.GetAll();
                ddSocialSecurityType.DataValueField = "Id";
                ddSocialSecurityType.DataTextField = "Name";
                ddSocialSecurityType.DataBind();
                ddSocialSecurityType.SelectedValue =
                    EmployeeWelfareList[rowIndex + PageIndex*gvEmployeeWelfare.PageSize].SocialSecurity.Type.Id.ToString
                        ();
            }
        }

        private void SetGridViewRowDateDisplay(int rowIndex)
        {
            TextBox txtSocialSecurityYear =
                (TextBox) gvEmployeeWelfare.Rows[rowIndex].FindControl("txtSocialSecurityYear");
            TextBox txtSocialSecurityMonth =
                (TextBox) gvEmployeeWelfare.Rows[rowIndex].FindControl("txtSocialSecurityMonth");
            TextBox txtAccumulationFundYear =
                (TextBox) gvEmployeeWelfare.Rows[rowIndex].FindControl("txtAccumulationFundYear");
            TextBox txtAccumulationFundMonth =
                (TextBox) gvEmployeeWelfare.Rows[rowIndex].FindControl("txtAccumulationFundMonth");
            if (txtSocialSecurityYear != null && txtSocialSecurityMonth != null)
            {
                List<string> SocialSecurityYearMonthTemp =
                    EmployeeWelfareList[rowIndex + PageIndex*gvEmployeeWelfare.PageSize].SocialSecurity.
                        EffectiveYearMonthTemp;
                txtSocialSecurityYear.Text = SocialSecurityYearMonthTemp[0];
                txtSocialSecurityMonth.Text = SocialSecurityYearMonthTemp[1];
            }
            if (txtAccumulationFundYear != null && txtAccumulationFundMonth != null)
            {
                List<string> AccumulationFundYearMonthTemp =
                    EmployeeWelfareList[rowIndex + PageIndex*gvEmployeeWelfare.PageSize].AccumulationFund.
                        EffectiveYearMonthTemp;
                txtAccumulationFundYear.Text = AccumulationFundYearMonthTemp[0];
                txtAccumulationFundMonth.Text = AccumulationFundYearMonthTemp[1];
            }
        }

        private void GetValueFromGridView()
        {
            for (int i = 0; i < gvEmployeeWelfare.Rows.Count; i++)
            {
                DropDownList ddSocialSecurityType =
                    (DropDownList) gvEmployeeWelfare.Rows[i].FindControl("ddSocialSecurityType");
                if (ddSocialSecurityType != null)
                {
                    EmployeeWelfareListViewState[i + PageIndex*gvEmployeeWelfare.PageSize].SocialSecurity.Type =
                        SocialSecurityTypeEnum.GetById(Convert.ToInt32(ddSocialSecurityType.SelectedValue));
                }

                TextBox txtSocialSecurityYear =
                    (TextBox) gvEmployeeWelfare.Rows[i].FindControl("txtSocialSecurityYear");
                TextBox txtSocialSecurityMonth =
                    (TextBox) gvEmployeeWelfare.Rows[i].FindControl("txtSocialSecurityMonth");
                TextBox txtAccumulationFundYear =
                    (TextBox) gvEmployeeWelfare.Rows[i].FindControl("txtAccumulationFundYear");
                TextBox txtAccumulationFundMonth =
                    (TextBox) gvEmployeeWelfare.Rows[i].FindControl("txtAccumulationFundMonth");
                TextBox txtSocialSecurityBase =
                    (TextBox) gvEmployeeWelfare.Rows[i].FindControl("txtSocialSecurityBase");
                TextBox txtAccumulationFundAccount =
                    (TextBox) gvEmployeeWelfare.Rows[i].FindControl("txtAccumulationFundAccount");
                TextBox txtAccumulationFundBase =
                    (TextBox) gvEmployeeWelfare.Rows[i].FindControl("txtAccumulationFundBase");
                TextBox txtSupplyAccount =
                    (TextBox) gvEmployeeWelfare.Rows[i].FindControl("txtSupplyAccount");
                TextBox txtSupplyBase =
                    (TextBox) gvEmployeeWelfare.Rows[i].FindControl("txtSupplyBase");
                TextBox txtYangLaoBase =
                    (TextBox) gvEmployeeWelfare.Rows[i].FindControl("txtYangLaoBase");
                TextBox txtShiYeBase =
                    (TextBox) gvEmployeeWelfare.Rows[i].FindControl("txtShiYeBase");
                TextBox txtYiLiaoBase =
                    (TextBox) gvEmployeeWelfare.Rows[i].FindControl("txtYiLiaoBase");
                if (txtSocialSecurityYear != null && txtSocialSecurityMonth != null)
                {
                    EmployeeWelfareListViewState[i + PageIndex*gvEmployeeWelfare.PageSize].SocialSecurity.
                        EffectiveYearMonthTemp =
                        new List<string>(
                            new string[2] {txtSocialSecurityYear.Text.Trim(), txtSocialSecurityMonth.Text.Trim()});
                }
                if (txtAccumulationFundYear != null && txtAccumulationFundMonth != null)
                {
                    EmployeeWelfareListViewState[i + PageIndex*gvEmployeeWelfare.PageSize].AccumulationFund.
                        EffectiveYearMonthTemp =
                        new List<string>(
                            new string[2] {txtAccumulationFundYear.Text.Trim(), txtAccumulationFundMonth.Text.Trim()});
                }
                if (txtSocialSecurityBase != null)
                {
                    EmployeeWelfareListViewState[i + PageIndex*gvEmployeeWelfare.PageSize].SocialSecurity.BaseTemp =
                        txtSocialSecurityBase.Text.Trim();
                }
                if (txtAccumulationFundAccount != null)
                {
                    EmployeeWelfareListViewState[i + PageIndex*gvEmployeeWelfare.PageSize].AccumulationFund.Account =
                        txtAccumulationFundAccount.Text.Trim();
                }
                if (txtAccumulationFundBase != null)
                {
                    EmployeeWelfareListViewState[i + PageIndex*gvEmployeeWelfare.PageSize].AccumulationFund.BaseTemp =
                        txtAccumulationFundBase.Text.Trim();
                }
                if (txtSupplyAccount != null)
                {
                    EmployeeWelfareListViewState[i + PageIndex*gvEmployeeWelfare.PageSize].AccumulationFund.
                        SupplyAccount =
                        txtSupplyAccount.Text.Trim();
                }
                if (txtSupplyBase != null)
                {
                    EmployeeWelfareListViewState[i + PageIndex*gvEmployeeWelfare.PageSize].AccumulationFund.
                        SupplyBaseTemp =
                        txtSupplyBase.Text.Trim();
                }
                if (txtYangLaoBase != null)
                {
                    EmployeeWelfareListViewState[i + PageIndex*gvEmployeeWelfare.PageSize].SocialSecurity.
                        YangLaoBaseTemp =
                        txtYangLaoBase.Text.Trim();
                }
                if (txtShiYeBase != null)
                {
                    EmployeeWelfareListViewState[i + PageIndex*gvEmployeeWelfare.PageSize].SocialSecurity.ShiYeBaseTemp
                        =
                        txtShiYeBase.Text.Trim();
                }
                if (txtYiLiaoBase != null)
                {
                    EmployeeWelfareListViewState[i + PageIndex*gvEmployeeWelfare.PageSize].SocialSecurity.YiLiaoBaseTemp
                        =
                        txtYiLiaoBase.Text.Trim();
                }
            }
        }

        private int PageIndex
        {
            get { return Convert.ToInt32(ViewState["PageIndex"]); }
            set { ViewState["PageIndex"] = value; }
        }

        protected void gvEmployeeWelfare_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        #region 查询相关

        public event DelegateNoParameter SearchEvent;
        public event DelegateNoParameter SaveEvent;

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

        public string EmployeeName
        {
            get { return txtName.Text.Trim(); }
        }

        public EmployeeTypeEnum EmployeeType
        {
            get { return (EmployeeTypeEnum) Convert.ToInt32(listEmployeeType.SelectedValue); }
            set { listEmployeeType.SelectedValue = ((int) value).ToString(); }
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

        public string Message
        {
            set { lblMessage.Text = value; }
        }

        #endregion

        #region 导入导出

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Export("员工福利表.xls");
        }

        private void Export(string FileName)
        {
            GC.Collect();
            string tempdirectory = ConfigurationManager.AppSettings["EmployeeExportLocation"];
            if (!Directory.Exists(tempdirectory))
            {
                Directory.CreateDirectory(tempdirectory);
            }
            string templocation = tempdirectory + "\\" + FileName;
            Application excel = new Application();
            _Workbook xBk = excel.Workbooks.Add(Type.Missing);
            _Worksheet xSt = (_Worksheet) xBk.ActiveSheet;

            try
            {
                TemplateBuildStringWriter(excel);
                object nothing = Type.Missing;
                object fileFormat = XlFileFormat.xlExcel8;
                object file1 = templocation;
                if (File.Exists(file1.ToString()))
                {
                    File.Delete(file1.ToString());
                }
                xBk.SaveAs(file1, fileFormat, nothing, nothing, nothing, nothing, XlSaveAsAccessMode.xlNoChange, nothing,
                           nothing, nothing, nothing, nothing);
            }
            finally
            {
                xBk.Close(false, null, null);
                excel.Quit();
                Marshal.ReleaseComObject(xBk);
                Marshal.ReleaseComObject(excel);
                Marshal.ReleaseComObject(xSt);
                GC.Collect();
            }
            FileInfo file = new FileInfo(templocation);
            if (file.Exists)
            {
                Response.Clear();
                Response.Charset = "GB2312";
                Response.ContentEncoding = Encoding.UTF8;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(file.Name));
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/ms-excel";
                Response.WriteFile(file.FullName);
                Response.End();
            }
        }

        private void TemplateBuildStringWriter(Application excel)
        {
            excel.Cells[1, 1] = EmployeeWelfare.ConstParemeter.Name;
            excel.Cells[1, 2] = EmployeeWelfare.ConstParemeter.SocialType;
            excel.Cells[1, 3] = EmployeeWelfare.ConstParemeter.SocialBase;
            excel.Cells[1, 4] = EmployeeWelfare.ConstParemeter.SocialYM;
            excel.Cells[1, 5] = EmployeeWelfare.ConstParemeter.FundAccount;
            excel.Cells[1, 6] = EmployeeWelfare.ConstParemeter.FundBase;
            excel.Cells[1, 7] = EmployeeWelfare.ConstParemeter.FundYM;
            excel.Cells[1, 8] = EmployeeWelfare.ConstParemeter.SupplyAccount;
            excel.Cells[1, 9] = EmployeeWelfare.ConstParemeter.SupplyBase;
            excel.Cells[1, 10] = EmployeeWelfare.ConstParemeter.YangLaoBase;
            excel.Cells[1, 11] = EmployeeWelfare.ConstParemeter.ShiYeBase;
            excel.Cells[1, 12] = EmployeeWelfare.ConstParemeter.YiLiaoBase;

            for (int i = 0; i < EmployeeWelfareListViewState.Count; i++)
            {
                int j = i + 2;
                excel.Cells[j, 1] = EmployeeWelfareListViewState[i].Owner.Name;
                excel.Cells[j, 2] = EmployeeWelfareListViewState[i].SocialSecurity.Type.Name;
                excel.Cells[j, 3] = EmployeeWelfareListViewState[i].SocialSecurity.Base;
                if (EmployeeWelfareListViewState[i].SocialSecurity.EffectiveYearMonth != null)
                {
                    List<string> SocialSecurityYearMonth =
                        EmployeeWelfare.YearAndMonth(EmployeeWelfareListViewState[i].SocialSecurity.EffectiveYearMonth);
                    excel.Cells[j, 4] =
                        string.Format("{0}年{1}月", SocialSecurityYearMonth[0], SocialSecurityYearMonth[1]);
                }

                excel.Cells[j, 5] = "'" + EmployeeWelfareListViewState[i].AccumulationFund.Account;
                excel.Cells[j, 6] = EmployeeWelfareListViewState[i].AccumulationFund.Base;

                if (EmployeeWelfareListViewState[i].AccumulationFund.EffectiveYearMonth != null)
                {
                    List<string> AccumulationFundYearMonth =
                        EmployeeWelfare.YearAndMonth(EmployeeWelfareListViewState[i].AccumulationFund.EffectiveYearMonth);
                    excel.Cells[j, 7] =
                        string.Format("{0}年{1}月", AccumulationFundYearMonth[0], AccumulationFundYearMonth[1]);
                }

                excel.Cells[j, 8] = "'" + EmployeeWelfareListViewState[i].AccumulationFund.SupplyAccount;
                excel.Cells[j, 9] = EmployeeWelfareListViewState[i].AccumulationFund.SupplyBase;
                excel.Cells[j, 10] = EmployeeWelfareListViewState[i].SocialSecurity.YangLaoBase;
                excel.Cells[j, 11] = EmployeeWelfareListViewState[i].SocialSecurity.ShiYeBase;
                excel.Cells[j, 12] = EmployeeWelfareListViewState[i].SocialSecurity.YiLiaoBase;
            }
        }

        protected void btnInport_Click(object sender, EventArgs e)
        {
            Import();
        }

        public event DelegateID ImportEvent;

        private void Import()
        {
            string uploadFileLocation = ConfigurationManager.AppSettings["EmployeeExportLocation"];
            if (!Directory.Exists(uploadFileLocation))
            {
                Directory.CreateDirectory(uploadFileLocation);
            }
            HttpPostedFile hpf = fuExcel.PostedFile;
            if (hpf != null)
            {
                string filename = Path.GetFileName(hpf.FileName);
                string fileExt = Path.GetExtension(hpf.FileName);
                string filePath = uploadFileLocation + "\\员工福利.xls";
                if (Validation(filename, fileExt))
                {
                    hpf.SaveAs(filePath);
                    if (ImportEvent != null)
                    {
                        ImportEvent(filePath);
                    }
                }
            }
        }

        private bool Validation(string filename, string fileExt)
        {
            if (!string.IsNullOrEmpty(filename.Trim()))
            {
                if (fileExt == ".xls" || fileExt == ".xlsx")
                {
                    return true;
                }
                lblMessage.Text = "<span class='fontred'>导入的文件格式错误</span>";
                return false;
            }
            lblMessage.Text = "<span class='fontred'>没有要导入的文件</span>";
            return false;
        }

        #endregion
    }
}