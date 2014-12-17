using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using SEP.HRMIS.Model;
using HRMISModel=SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAdjustRest;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeAdjustRest;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Presenter;
using TextBox=System.Web.UI.WebControls.TextBox;

namespace SEP.Performance.Views.HRMIS.EmployeeAdjustRest
{
    public partial class EmployeeAdjustRestListView : UserControl, IEmployeeAdjustRestListView
    {

        public string EmployeeStatusId
        {
            get
            {
                return ddlEmployeeStatus.SelectedValue;
            }
        }

        protected void LinkButtonGoPage_Click(object sender, EventArgs e)
        {
            TextBox txtGoPage = gvEmployeeAdjustRest.BottomPagerRow.FindControl("txtGoPage") as TextBox;
            if (txtGoPage != null)
            {
                int index;
                if (int.TryParse(txtGoPage.Text.Trim(), out index))
                {
                    index = index < 1 ? 1 : index;
                    index = index > gvEmployeeAdjustRest.PageCount ? gvEmployeeAdjustRest.PageCount : index;
                    gvEmployeeAdjustRest.PageIndex = index - 1;
                    BtnSearchEvent();
                    txtGoPage.Text = "";
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }

        protected void gvEmployeeAdjustRest_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeAdjustRest.PageIndex = e.NewPageIndex;
            BtnSearchEvent();
        }

        protected void gvEmployeeAdjustRest_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        public string EmployeeName
        {
            get { return txtName.Text.Trim(); }
        }

        public EmployeeTypeEnum EmployeeType
        {
            get
            {
                return (EmployeeTypeEnum)Convert.ToInt32(listEmployeeType.SelectedValue);
            }
            set
            {
                listEmployeeType.SelectedValue = ((int)value).ToString();
            }
        }

        private readonly int _All = -1;
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
        public bool CheckValidResult
        {
            get { return CheckValid(); }
        }
        private bool CheckValid()
        {
            ResultMsg = string.Empty;
            bool ret = true;
            for (int i = 0; i < gvEmployeeAdjustRest.Rows.Count; i++)
            {
                HiddenField hfOldSurplusHours =
                    (HiddenField)gvEmployeeAdjustRest.Rows[i].FindControl("hfOldSurplusHours");
                TextBox txtSurplusHours =
                    (TextBox)gvEmployeeAdjustRest.Rows[i].FindControl("txtSurplusHours");
                TextBox txtReason =
                    (TextBox)gvEmployeeAdjustRest.Rows[i].FindControl("txtReason");
                if (hfOldSurplusHours == null || txtSurplusHours == null || txtReason == null)
                {
                    ret = false;
                    ResultMsg = "控件丢失，无法操作";
                    break;
                }
                txtSurplusHours.CssClass = "input1";
                txtReason.CssClass = "input1";
                //验证格式
                decimal decimalAdjustRest;
                if (!decimal.TryParse(txtSurplusHours.Text.Trim(), out decimalAdjustRest))
                {
                    txtSurplusHours.CssClass = "inputred1";
                    ret = false;
                }
                //验证是否填写原因，如果SurplusHours发生改变，则必须填写原因
                else if (string.IsNullOrEmpty(txtReason.Text.Trim()) && Convert.ToDecimal(hfOldSurplusHours.Value) != decimalAdjustRest)
                {
                    txtReason.CssClass = "inputred1";
                    ret = false;
                }
            }
            return ret;
        }

        private List<AdjustRest> GetChangeValueFromGridView()
        {
            List<AdjustRest> _retAdjustRestList = new List<AdjustRest>();
            for (int i = 0; i < gvEmployeeAdjustRest.Rows.Count; i++)
            {
                AdjustRest itemAdjustRest = new AdjustRest();
                HiddenField hfAccountID = (HiddenField)gvEmployeeAdjustRest.Rows[i].FindControl("hfAccountID");
                HiddenField hfAdjustRestID = (HiddenField)gvEmployeeAdjustRest.Rows[i].FindControl("hfAdjustRestID");
                HiddenField hfOldSurplusHours =
                    (HiddenField)gvEmployeeAdjustRest.Rows[i].FindControl("hfOldSurplusHours");
                TextBox txtSurplusHours =
                    (TextBox)gvEmployeeAdjustRest.Rows[i].FindControl("txtSurplusHours");
                TextBox txtReason =
                    (TextBox)gvEmployeeAdjustRest.Rows[i].FindControl("txtReason");

                if (Convert.ToDecimal(txtSurplusHours.Text.Trim()) == Convert.ToDecimal(hfOldSurplusHours.Value)
                    && string.IsNullOrEmpty(txtReason.Text.Trim()))
                {
                    continue;
                }
                itemAdjustRest.Employee =
                    new HRMISModel.Employee(Convert.ToInt32(hfAccountID.Value), EmployeeTypeEnum.All);
                itemAdjustRest.AdjustRestID = Convert.ToInt32(hfAdjustRestID.Value);
                decimal decimalAdjustRest;
                if (!decimal.TryParse(txtSurplusHours.Text.Trim(), out decimalAdjustRest))
                {
                    txtSurplusHours.CssClass = "inputred1";
                    throw new Exception("格式错误");
                }
                itemAdjustRest.SurplusHours = decimalAdjustRest;

                itemAdjustRest.AdjustRestHistoryList = new List<AdjustRestHistory>();
                itemAdjustRest.AdjustRestHistoryList.Add(new AdjustRestHistory());
                itemAdjustRest.AdjustRestHistoryList[0].Remark = txtReason.Text.Trim();

                _retAdjustRestList.Add(itemAdjustRest);
            }
            return _retAdjustRestList;
        }

        public List<AdjustRest> AdjustRestChangeValueSource
        {
            get { return GetChangeValueFromGridView(); }
        }

        private List<AdjustRest> AdjustRestSourceViewState
        {
            get { return ViewState["AdjustRestSource"] as List<AdjustRest>; }
            set { ViewState["AdjustRestSource"] = value; }
        }

        public List<AdjustRest> AdjustRestSource
        {
            set
            {
                AdjustRestSourceViewState = value;
                gvEmployeeAdjustRest.DataSource = value;
                gvEmployeeAdjustRest.DataBind();
                lblMessage.Text = value.Count.ToString();
                if (value.Count == 0)
                {
                    Result.Visible = false;
                }
                else
                {
                    Result.Visible = true;
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

        public int DepartmentId
        {
            get { return Convert.ToInt32(listDepartment.SelectedValue); }
        }
        public bool RecursionDepartment
        {
            get
            {
                return cbRecursionDepartment.Checked;
            }
        }

        public event DelegateNoParameter BtnSaveEvent;
        public event DelegateID BtnDetailEvent;
        public event DelegateNoParameter BtnSearchEvent;

        public string ResultMsg
        {
            get
            {
                return lblResult.Text;
            }
            set
            {
                lblResult.Text = value;
                divResult.Visible = !string.IsNullOrEmpty(value);
            }
        }


        public void OperationResultColorSet(int adjustID, OperationResult operationResult, decimal newSurplusAdjustRest)
        {
            for (int i = 0; i < gvEmployeeAdjustRest.Rows.Count; i++)
            {
                HiddenField hfAdjustRestID = (HiddenField)gvEmployeeAdjustRest.Rows[i].FindControl("hfAdjustRestID");
                if (hfAdjustRestID.Value != adjustID.ToString())
                {
                    continue;
                }
                HiddenField hfOldSurplusHours =
                    (HiddenField)gvEmployeeAdjustRest.Rows[i].FindControl("hfOldSurplusHours");
                TextBox txtSurplusHours =
                    (TextBox)gvEmployeeAdjustRest.Rows[i].FindControl("txtSurplusHours");
                TextBox txtReason =
                    (TextBox)gvEmployeeAdjustRest.Rows[i].FindControl("txtReason");

                switch (operationResult)
                {
                    case OperationResult.Fail:
                        txtSurplusHours.CssClass = "inputred1";
                        txtReason.CssClass = "inputred1";
                        break;
                    case OperationResult.OutOfDate:
                        hfOldSurplusHours.Value = newSurplusAdjustRest.ToString();
                        txtSurplusHours.CssClass = "inputblue1";
                        txtReason.CssClass = "inputblue1";
                        break;
                    case OperationResult.Success:
                        hfOldSurplusHours.Value = txtSurplusHours.Text.Trim();
                        txtSurplusHours.CssClass = "inputgreen1";
                        txtReason.CssClass = "inputgreen1";
                        txtReason.Text = string.Empty;
                        break;
                    default:
                        break;
                }
            }
        }

        public decimal GetOldSurplusHours(int adjustID)
        {
            for (int i = 0; i < gvEmployeeAdjustRest.Rows.Count; i++)
            {
                HiddenField hfAdjustRestID = (HiddenField)gvEmployeeAdjustRest.Rows[i].FindControl("hfAdjustRestID");
                if (hfAdjustRestID.Value != adjustID.ToString())
                {
                    continue;
                }
                HiddenField hfOldSurplusHours =
                    (HiddenField)gvEmployeeAdjustRest.Rows[i].FindControl("hfOldSurplusHours");
                return Convert.ToDecimal(hfOldSurplusHours.Value);
            }
            return 0;
        }

        protected void lbDetail_Click(object sender, CommandEventArgs e)
        {
            BtnDetailEvent(e.CommandArgument.ToString());
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BtnSaveEvent();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExcelExportUtility.ExportContent ExportContentImplement = TemplateBuildStringWriter;
            FileInfo file = ExcelExportUtility.NormalExport("员工调休.xls", ExportContentImplement);
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

        #region Export

        private void TemplateBuildStringWriter(Application excel)
        {
            int cols = 1;
            excel.Cells[1, cols++] = "员工姓名";
            excel.Cells[1, cols++] = "所属部门";
            excel.Cells[1, cols++] = "所属公司";
            excel.Cells[1, cols++] = "职位";
            excel.Cells[1, cols++] = "入职时间";
            excel.Cells[1, cols++] = "年度";
            excel.Cells[1, cols++] = "剩余调休";

            for (int i = 0; i < AdjustRestSourceViewState.Count; i++)
            {
                cols = 1;
                excel.Cells[i + 2, cols++] = AdjustRestSourceViewState[i] != null &&
                                         AdjustRestSourceViewState[i].Employee != null &&
                                         AdjustRestSourceViewState[i].Employee.Account != null &&
                                         AdjustRestSourceViewState[i].Employee.Account.Name != null
                                             ? AdjustRestSourceViewState[i].Employee.Account.Name
                                             : "";
                excel.Cells[i + 2, cols++] = AdjustRestSourceViewState[i] != null &&
                                         AdjustRestSourceViewState[i].Employee != null &&
                                         AdjustRestSourceViewState[i].Employee.Account != null &&
                                         AdjustRestSourceViewState[i].Employee.Account.Dept != null &&
                                         AdjustRestSourceViewState[i].Employee.Account.Dept.Name != null
                                             ? AdjustRestSourceViewState[i].Employee.Account.Dept.Name
                                             : "";
                excel.Cells[i + 2, cols++] = AdjustRestSourceViewState[i] != null &&
                                         AdjustRestSourceViewState[i].Employee != null &&
                                         AdjustRestSourceViewState[i].Employee.EmployeeDetails != null &&
                                         AdjustRestSourceViewState[i].Employee.EmployeeDetails.Work != null &&
                                         AdjustRestSourceViewState[i].Employee.EmployeeDetails.Work.Company != null &&
                                         AdjustRestSourceViewState[i].Employee.EmployeeDetails.Work.Company.Name != null
                                             ? AdjustRestSourceViewState[i].Employee.EmployeeDetails.Work.Company.Name
                                             : "";
                excel.Cells[i + 2, cols++] = AdjustRestSourceViewState[i] != null &&
                                         AdjustRestSourceViewState[i].Employee != null &&
                                         AdjustRestSourceViewState[i].Employee.Account != null &&
                                         AdjustRestSourceViewState[i].Employee.Account.Position != null &&
                                         AdjustRestSourceViewState[i].Employee.Account.Position.Name != null
                                             ? AdjustRestSourceViewState[i].Employee.Account.Position.Name
                                             : "";
                excel.Cells[i + 2, cols++] = AdjustRestSourceViewState[i] != null &&
                                         AdjustRestSourceViewState[i].Employee != null &&
                                         AdjustRestSourceViewState[i].Employee.EmployeeDetails != null &&
                                         AdjustRestSourceViewState[i].Employee.EmployeeDetails.Work != null
                                             ? AdjustRestSourceViewState[i].Employee.EmployeeDetails.Work.ComeDate.
                                                   ToShortDateString()
                                             : "";
                excel.Cells[i + 2, cols++] = AdjustRestSourceViewState[i].AdjustYear.Year;
                excel.Cells[i + 2, cols++] = AdjustRestSourceViewState[i].SurplusHours;
            }
        }

        #endregion
    }
}