using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics;
using SEP.Model.Accounts;
using SEP.Model.Departments;

using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceStatistcsView
{
    public partial class MonthAttendanceView : UserControl, IMonthAttendanceView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvMonthAttendanceList.PageIndex = pageindex;
            gvMonthAttendanceList.DataSource = Session["TheEmployeeMonthAttendance"];
            gvMonthAttendanceList.DataBind();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvMonthAttendanceList, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        public delegate void ShowEmployeeDayAttendanceWindow(string employeeID);
        public ShowEmployeeDayAttendanceWindow _ShowEmployeeDayAttendanceWindow;
        protected void gvMonthAttendanceList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //StatisticsAttendance(null, null);
            gvMonthAttendanceList.PageIndex = e.NewPageIndex;
            gvMonthAttendanceList.DataSource = Session["TheEmployeeMonthAttendance"];
            gvMonthAttendanceList.DataBind();
        }

        protected void gvMonthAttendanceList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    _ShowEmployeeDayAttendanceWindow(e.CommandArgument.ToString());
                    return;
            }
        }

        protected void gvMonthAttendanceList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        public List<HRMISModel.Employee> EmployeeMonthAttendanceList
        {
            get { return (List<HRMISModel.Employee>)Session["TheEmployeeMonthAttendance"]; }
            set
            {
                Session["TheEmployeeMonthAttendance"] = value;
                //_EmployeeMonthAttendanceList = value;
                gvMonthAttendanceList.DataSource = value;
                gvMonthAttendanceList.DataBind();
                if (value.Count > 0)
                {
                    trSearch.Style["display"] = "block";
                    if (btnExportClientVisible)
                    {
                        tdExport.Style["display"] = "block";
                    }
                }
                else
                {
                    trSearch.Style["display"] = "none";
                    if (btnExportClientVisible)
                    {
                        tdExport.Style["display"] = "none";
                    }
                }

            }
        }

        public string EmployeeName
        {
            get { return txtEmployeeName.Text.Trim(); }
            set { txtEmployeeName.Text = value; }
        }

        public List<Department> DepartmentList
        {
            set
            {
                ddlDepartment.DataSource = value;
                ddlDepartment.DataValueField = "DepartmentID";
                ddlDepartment.DataTextField = "DepartmentName";
                ddlDepartment.DataBind();
            }
        }
        public int? GradesId
        {
            get
            {
                if (string.IsNullOrEmpty(ddGrades.SelectedValue))
                {
                    return null;
                }
                return Convert.ToInt32(ddGrades.SelectedValue);
            }
        }

        public List<GradesType> GradesSource
        {
            set
            {
                ddGrades.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, "", true);
                ddGrades.Items.Add(itemAll);
                foreach (GradesType g in value)
                {
                    ListItem item = new ListItem(g.Name, g.ID.ToString(), true);
                    ddGrades.Items.Add(item);
                }
            }
        }
        public int SelectedDepartment
        {
            get { return Convert.ToInt32(ddlDepartment.SelectedValue); }
        }
        public string FromDate
        {
            get { return dtpScopeFrom.Text.Trim(); }
            set { dtpScopeFrom.Text = value; }
        }

        public string ToDate
        {
            get { return dtpScopeTo.Text.Trim(); }
            set { dtpScopeTo.Text = value; }
        }

        public string ScopeDateFrom
        {
            get { return lblScopeDateFrom.Text; }
            set
            {
                lblScopeDateFrom.Text = value;
            }
        }
        public string ScopeDateTo
        {
            get { return lblScopeDateTo.Text; }
            set
            {
                lblScopeDateTo.Text = value;
            }
        }

        public string ScopeMsg
        {
            set
            {
                lblScopeMsg.Text = value;
            }
        }

        public event EventHandler StatisticsAttendance;

        public string Message
        {
            set { lblMessage.Text = value; }
        }

        public bool EmployeeNameReadOnly
        {
            set { txtEmployeeName.ReadOnly = value; }
        }

        public event EventHandler ddlDepartmentSelectedIndexChanged;

        public bool AdjustRestRemainedDaysVisible
        {
            set
            {
                gvMonthAttendanceList.Columns[12].Visible = value;
                gvMonthAttendanceList.Columns[23].Visible = value;
            }
        }

        private bool _btnExportClientVisible;
        public bool btnExportClientVisible
        {
            get
            {
                return _btnExportClientVisible;
            }
            set
            {
                _btnExportClientVisible = value;
                if (value)
                {
                    tdExport.Style["display"] = "block";
                }
                else
                {
                    tdExport.Style["display"] = "none";
                }
            }
        }

        protected void btnStatistics_Click(object sender, EventArgs e)
        {
            SetDefaultSortStyle();
            StatisticsAttendance(null, null);
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDepartmentSelectedIndexChanged != null)
            {
                ddlDepartmentSelectedIndexChanged(sender, e);
            }
        }

        #region 排序
        protected void gvMonthAttendanceList_Sorting(object sender, GridViewSortEventArgs e)
        {
            SetDefaultSortStyle();
            List<HRMISModel.Employee> employees = (List<HRMISModel.Employee>)Session["TheEmployeeMonthAttendance"];
            switch (e.SortExpression)
            {
                case "RateofOnDuty":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_RateofOnDuty, 31, "出勤率",
                                           SortOrderEnum.Ascending);
                    break;
                case "DaysofOvertime":
                case "HoursofOvertime":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_DaysofOvertime, 11, "加班(天)",
                                           SortOrderEnum.Descending);
                    AlternatingSortAccordingToField(
                        HRMISModel.Employee.EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofOvertime, 25,
                        "加班(时)");
                    break;
                case "HoursofCommonOvertime":
                case "DaysofCommonOvertime":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_DaysofCommonOvertime, 12, "普通加班(天)",
                                           SortOrderEnum.Descending);
                    AlternatingSortAccordingToField(
                        HRMISModel.Employee.EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofCommonOvertime, 26,
                        "普通加班(时)");
                    break;
                case "HoursofWeekendOvertime":
                case "DaysofWeekendOvertime":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_DaysofWeekendOvertime, 13, "双休日加班(天)",
                                           SortOrderEnum.Descending);
                    AlternatingSortAccordingToField(
                        HRMISModel.Employee.EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofWeekendOvertime, 27,
                        "双休日加班(时)");
                    break;
                case "HoursofHolidayOvertime":
                case "DaysofHolidayOvertime":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_DaysofHolidayOvertime, 14, "法定加班(天)",
                                           SortOrderEnum.Descending);
                    AlternatingSortAccordingToField(
                        HRMISModel.Employee.EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofHolidayOvertime, 28,
                        "法定加班(时)");
                    break;
                case "DaysofLunarPeriodLeave":
                case "HoursofLunarPeriodLeave":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_DaysofLunarPeriodLeave, 3, "年假(天)",
                                           SortOrderEnum.Descending);
                    AlternatingSortAccordingToField(
                        HRMISModel.Employee.EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofLunarPeriodLeave,
                        17, "年假(时)");
                    break;
                case "DaysofPersonalReasonLeave":
                case "HoursofPersonalReasonLeave":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_DaysofPersonalReasonLeave, 4, "事假(天)",
                                           SortOrderEnum.Descending);
                    AlternatingSortAccordingToField(
                        HRMISModel.Employee.EmployeeSortField.
                            EmployeeAttendance_MonthAttendance_DaysofPersonalReasonLeave, 18, "事假(时)");
                    break;
                case "DaysofSickLeave":
                case "HoursofSickLeave":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_DaysofSickLeave, 5, "病假(天)",
                                           SortOrderEnum.Descending);
                    AlternatingSortAccordingToField(
                        HRMISModel.Employee.EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofSickLeave, 19,
                        "病假(时)");
                    break;
                case "DaysofAdjustRestLeave":
                case "HoursofAdjustRestLeave":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_DaysofAdjustRestLeave, 6, "调休(天)",
                                           SortOrderEnum.Descending);
                    AlternatingSortAccordingToField(
                        HRMISModel.Employee.EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofAdjustRestLeave,
                        20, "调休(时)");
                    break;
                case "DaysofOtherLeave":
                case "HoursofOtherLeave":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_DaysofOtherLeave, 7, "其他(天)",
                                           SortOrderEnum.Descending);
                    AlternatingSortAccordingToField(
                        HRMISModel.Employee.EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofOtherLeave, 21,
                        "其他(时)");
                    break;
                case "Name":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.Name, 0, "员工姓名",
                                           SortOrderEnum.Ascending);
                    break;
                case "DaysofAdjustRestRemained":
                case "HoursofAdjustRestRemained":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_DaysofAdjustRestRemained, 15,
                                           "剩余调休(天)", SortOrderEnum.Descending);
                    AlternatingSortAccordingToField(
                        HRMISModel.Employee.EmployeeSortField.
                            EmployeeAttendance_MonthAttendance_DaysofAdjustRestRemained, 29, "剩余调休(时)");
                    break;
                case "SurplusDayNum":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_Vacation_SurplusDayNum, 16, "剩余年假(天)",
                                           SortOrderEnum.Descending);
                    AlternatingSortAccordingToField(
                        HRMISModel.Employee.EmployeeSortField.EmployeeAttendance_Vacation_SurplusDayNum, 30, "剩余年假(时)");
                    break;
                case "DaysofNoReasonLeave":
                case "HoursofNoReasonLeave":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_DaysofNoReasonLeave, 8, "旷工(天)",
                                           SortOrderEnum.Descending);
                    AlternatingSortAccordingToField(
                        HRMISModel.Employee.EmployeeSortField.EmployeeAttendance_MonthAttendance_DaysofNoReasonLeave, 22,
                        "旷工(时)");
                    break;
                case "ArriveLate":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_ArriveLate_TotalData, 9, "迟到",
                                           SortOrderEnum.Descending);
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_ArriveLate_Count, 9, "迟到",
                                           SortOrderEnum.Descending);
                    AlternatingSortAccordingToField(
                        HRMISModel.Employee.EmployeeSortField.EmployeeAttendance_MonthAttendance_ArriveLate_Count, 23,
                        "迟到");
                    break;
                case "LeaveEarly":
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_LeaveEarly_TotalData, 10, "早退",
                                           SortOrderEnum.Descending);
                    AlternatingSortByField(employees,
                                           HRMISModel.Employee.EmployeeSortField.
                                               EmployeeAttendance_MonthAttendance_LeaveEarly_Count, 10, "早退",
                                           SortOrderEnum.Descending);
                    AlternatingSortAccordingToField(
                        HRMISModel.Employee.EmployeeSortField.EmployeeAttendance_MonthAttendance_LeaveEarly_Count, 24,
                        "早退");
                    break;
                default:
                    break;
            }
            EmployeeMonthAttendanceList = employees;

        }
        private void AlternatingSortAccordingToField(HRMISModel.Employee.EmployeeSortField employeeSortField,
                                                     int columnNum, string columnTitle)
        {
            SortOrderEnum sortOrder;
            if (ViewState[employeeSortField.ToString()] == null)
            {
                return;
            }
            sortOrder = ViewState[employeeSortField.ToString()].ToString() == SortOrderEnum.Descending.ToString()
                            ? SortOrderEnum.Descending
                            : SortOrderEnum.Ascending;

            if (sortOrder == SortOrderEnum.Descending)
            {
                //倒序
                gvMonthAttendanceList.Columns[columnNum].HeaderText = columnTitle +
                                                                      "<img src='../../image/down.gif' border='0'/>";
            }
            else
            {
                //正序
                gvMonthAttendanceList.Columns[columnNum].HeaderText = columnTitle +
                                                                      "<img src='../../image/up.gif' border='0'/>";
            }
        }

        private void AlternatingSortByField(List<HRMISModel.Employee> employees, HRMISModel.Employee.EmployeeSortField employeeSortField,
                                            int columnNum, string columnTitle, SortOrderEnum defaultSortOrder)
        {
            SortOrderEnum sortOrder;
            if (ViewState[employeeSortField.ToString()] != null)
            {
                sortOrder = ViewState[employeeSortField.ToString()].ToString() == SortOrderEnum.Descending.ToString()
                                ? SortOrderEnum.Ascending
                                : SortOrderEnum.Descending;
            }
            else
            {
                sortOrder = defaultSortOrder.ToString() == SortOrderEnum.Descending.ToString()
                                ? SortOrderEnum.Descending
                                : SortOrderEnum.Ascending;
            }
            if (sortOrder == SortOrderEnum.Descending)
            {
                //倒序
                gvMonthAttendanceList.Columns[columnNum].HeaderText = columnTitle +
                                                                      "<img src='../../image/down.gif' border='0'/>";
                ViewState[employeeSortField.ToString()] = SortOrderEnum.Descending.ToString();
                SortBase.InsertionSort(employees,
                                       new EmployeeComparer(employeeSortField, SortOrderEnum.Descending).Compare);
            }
            else
            {
                //正序
                gvMonthAttendanceList.Columns[columnNum].HeaderText = columnTitle +
                                                                      "<img src='../../image/up.gif' border='0'/>";
                ViewState[employeeSortField.ToString()] = SortOrderEnum.Ascending.ToString();
                SortBase.InsertionSort(employees,
                                       new EmployeeComparer(employeeSortField, SortOrderEnum.Ascending).Compare);
            }
        }

        private void SetDefaultSortStyle()
        {
            for (int i = 0; i < gvMonthAttendanceList.Columns.Count; i++)
            {
                gvMonthAttendanceList.Columns[i].HeaderText = gvMonthAttendanceList.Columns[i].HeaderText.Split('<')[0];

            }
        }

        #endregion

        protected void ibHour_Click(object sender, ImageClickEventArgs e)
        {
            IsHours = true;
        }

        protected void ibDay_Click(object sender, ImageClickEventArgs e)
        {
            IsHours = false;
        }
        public bool IsHours
        {
            set
            {
                ViewState["_IsHours"] = value;
                Session["TheEmployeeMonthAttendance_IsHours"] = value;
                gvMonthAttendanceList.Columns[3].Visible = !value;
                gvMonthAttendanceList.Columns[4].Visible = !value;
                gvMonthAttendanceList.Columns[5].Visible = !value;
                gvMonthAttendanceList.Columns[6].Visible = !value;
                gvMonthAttendanceList.Columns[7].Visible = !value;
                gvMonthAttendanceList.Columns[8].Visible = !value;
                gvMonthAttendanceList.Columns[9].Visible = !value;
                gvMonthAttendanceList.Columns[10].Visible = !value;
                gvMonthAttendanceList.Columns[11].Visible = !value;
                gvMonthAttendanceList.Columns[12].Visible = !value;
                gvMonthAttendanceList.Columns[13].Visible = !value;
                gvMonthAttendanceList.Columns[14].Visible = !value;
                gvMonthAttendanceList.Columns[15].Visible = !value;
                gvMonthAttendanceList.Columns[16].Visible = !value;


                gvMonthAttendanceList.Columns[17].Visible = value;
                gvMonthAttendanceList.Columns[18].Visible = value;
                gvMonthAttendanceList.Columns[19].Visible = value;
                gvMonthAttendanceList.Columns[20].Visible = value;
                gvMonthAttendanceList.Columns[21].Visible = value;
                gvMonthAttendanceList.Columns[22].Visible = value;
                gvMonthAttendanceList.Columns[23].Visible = value;
                gvMonthAttendanceList.Columns[24].Visible = value;
                gvMonthAttendanceList.Columns[25].Visible = value;
                gvMonthAttendanceList.Columns[26].Visible = value;
                gvMonthAttendanceList.Columns[27].Visible = value;
                gvMonthAttendanceList.Columns[28].Visible = value;
                gvMonthAttendanceList.Columns[29].Visible = value;
                gvMonthAttendanceList.Columns[30].Visible = value;
            }
        }
    }
}