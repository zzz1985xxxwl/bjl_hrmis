//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InAndOutStatisticsView.cs
// 创建者: 王玥琦
// 创建日期: 2008-10-17
// 概述: 进出统计记录
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.IAttendanceInAndOutStatistics;
using SEP.Model.Accounts;
using SEPHRMISModel = SEP.HRMIS.Model;
using SEP.Presenter.Core;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceInAndOutStatistics
{
    public partial class InAndOutStatisticsView : UserControl, IInAndOutStatisticsView
    {
        #region IInAndOutStatisticsView成员

        public List<Model.Departments.Department> DepartmentList
        {
            set
            {
                listDepartment.Items.Clear();
                ListItem item = new ListItem("", "-1", true);
                listDepartment.Items.Add(item);
                foreach (Model.Departments.Department department in value)
                {
                    item = new ListItem(department.DepartmentName, department.DepartmentID.ToString(), true);
                    listDepartment.Items.Add(item);
                }
            }
            get
            {
                return null;
            }
        }

        public List<SEPHRMISModel.OutInTimeConditionEnum> OutInTimeConditionSourse
        {
            set
            {
                ddInOutTimeCondition.Items.Clear();
                foreach (SEPHRMISModel.OutInTimeConditionEnum outInTimeCondition in value)
                {
                    ListItem item = new ListItem(SEPHRMISModel.EmployeeAttendance.AttendanceInAndOutRecord.AttendanceInAndOutStatistics.GetOutInTimeConditionEnumName(outInTimeCondition)
                        , outInTimeCondition.ToString(), true);
                    ddInOutTimeCondition.Items.Add(item);
                }
            }
            get
            {
                return null;
            }
        }


        public List<string> HourFromList
        {
            set
            {
                listHourFrom.DataSource = value;
                listHourFrom.DataBind();
            }
            get
            {
                return null;
            }
        }

        public List<string> HourToList
        {
            set
            {
                listHourTo.DataSource = value;
                listHourTo.DataBind();
            }
            get
            {
                return null;
            }
        }

        public List<string> MinutesFromList
        {
            set
            {
                listMinutesFrom.DataSource = value;
                listMinutesFrom.DataBind();
            }
            get
            {
                return null;
            }
        }

        public List<string> MinutesToList
        {
            set
            {
                listMinutesTo.DataSource = value;
                listMinutesTo.DataBind();
            }
            get
            {
                return null;
            }
        }

        public string EmployeeName
        {
            get
            {
                return txtEmployeeName.Text;
            }
            set
            {
                txtEmployeeName.Text = value;
            }
        }
        public string DepartmentID
        {
            get
            {
                return listDepartment.SelectedValue;
            }
            set
            {
                listDepartment.SelectedValue = value;
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

        public string SearchFrom
        {
            set
            {
                DateTime temp = Convert.ToDateTime(value);
                dtpScopeFrom.Text = temp.ToShortDateString();
                string[] t = temp.ToShortTimeString().Split(':');
                listHourFrom.SelectedValue = t[0];
                listMinutesFrom.SelectedValue = t[1];
            }
            get
            {
                return dtpScopeFrom.Text + " " + listHourFrom.SelectedValue +
        ":" + listMinutesFrom.SelectedValue;
            }
        }

        public string SearchTo
        {
            set
            {
                DateTime temp = Convert.ToDateTime(value);
                //dtpScopeTo.Text = temp.ToShortDateString();
                string[] t = temp.ToShortTimeString().Split(':');
                listHourTo.SelectedValue = t[0];
                listMinutesTo.SelectedValue = t[1];
            }
            get
            {
                return dtpScopeFrom.Text + " " + listHourTo.SelectedValue +
        ":" + listMinutesTo.SelectedValue;
            }
        }

        public string OutInTimeCondition
        {
            get
            {
                return ddInOutTimeCondition.SelectedValue;
            }
            set
            {
                ddInOutTimeCondition.SelectedValue = value;
            }
        }

        public string Message
        {
            set
            {
                lblMessage.Text = value;
            }
            get
            {
                return lblMessage.Text;
            }
        }

        public string ErrorMessage
        {
            set
            {
                lblErrorMessage.Text = value;
                lblErrorMessage.Visible = !string.IsNullOrEmpty(value);
            }
            get
            {
                return lblErrorMessage.Text;
            }
        }


        public List<SEPHRMISModel.Employee> EmployeeList
        {
            set
            {
                gvInAndOutStatistics.DataSource = value;
                gvInAndOutStatistics.DataBind();
                if (value == null || value.Count == 0)
                {
                    tbInAndOutStatistics.Style["display"] = "none";
                }
                else
                {
                    tbInAndOutStatistics.Style["display"] = "block";

                }
                if (value != null) lblMessage.Text = value.Count.ToString();
                SetExportDataTable(value);
            }
            get
            {
                return (List<SEPHRMISModel.Employee>)gvInAndOutStatistics.DataSource;
            }
        }

        private void SetExportDataTable(List<SEPHRMISModel.Employee> employeeList)
        {
            DataTable ret_dt = new DataTable();
            if (employeeList == null || employeeList.Count == 0)
            {
                return;
            }
            ret_dt.Columns.Add("员工姓名");
            ret_dt.Columns.Add("进入时间");
            ret_dt.Columns.Add("离开时间");
            ret_dt.Columns.Add("考勤信息");
            foreach (SEPHRMISModel.Employee employee in employeeList)
            {
                DataRow dr = ret_dt.NewRow();
                dr["员工姓名"] = employee.Account.Name;
                dr["进入时间"] =
                    DateTime.Compare(employee.EmployeeAttendance.AttendanceInAndOutStatistics.InTime.Date, Convert.ToDateTime("2999-12-31")) == 0
                        ? ""
                        : employee.EmployeeAttendance.AttendanceInAndOutStatistics.InTime.ToString();
                dr["离开时间"] =
                    DateTime.Compare(employee.EmployeeAttendance.AttendanceInAndOutStatistics.OutTime.Date, Convert.ToDateTime("1900-1-1")) == 0
                        ? ""
                        : employee.EmployeeAttendance.AttendanceInAndOutStatistics.OutTime.ToString();
                dr["考勤信息"] = employee.EmployeeAttendance.AttendanceInAndOutStatistics.LeaveRequestAndOut;
                ret_dt.Rows.Add(dr);
            }
            Session[SessionKeys.InAndOutStatisticsRecordDataTable] = ret_dt;
        }

        public event DelegateNoParameter BtnSetReadTimeEvent;
        public event DelegateNoParameter BtnReadAccessDataEvent;
        public event DelegateID BtnSendEmailEvent;
        public event DelegateID BtnSendMessageEvent;
        public event DelegateNoParameter BtnSearchEvent;
        public event DelegateNoParameter BtnReadExcelDataEvent;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvInAndOutStatistics, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvInAndOutStatistics.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }

        protected void btnSetReadTime_Click(object sender, EventArgs e)
        {
            BtnSetReadTimeEvent();
        }

        protected void btnReadAccessData_Click(object sender, EventArgs e)
        {
            BtnReadAccessDataEvent();
        }

        protected void gvInAndOutStatistics_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInAndOutStatistics.PageIndex = e.NewPageIndex;
            BtnSearchEvent();
        }
        protected void gvInAndOutStatistics_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect("InAndOutDetailListView.aspx?" + ConstParameters.EmployeeId + "=" +
                  SecurityUtil.DECEncrypt(e.CommandArgument.ToString()) + "&" +
                  ConstParameters.DepartmentID + "=" + SecurityUtil.DECEncrypt(DepartmentID) + "&" +
                   ConstParameters.SearchFrom + "=" + SecurityUtil.DECEncrypt(SearchFrom) + "&" +
                    ConstParameters.SearchTo + "=" + SecurityUtil.DECEncrypt(SearchTo));
                    return;
            }
        }

        protected void gvInAndOutStatistics_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }

        protected void btnSendEmail_Click(object sender, CommandEventArgs e)
        {
            BtnSendEmailEvent(e.CommandArgument.ToString());
        }
        protected void btnSendMessage_Click(object sender, CommandEventArgs e)
        {
            BtnSendMessageEvent(e.CommandArgument.ToString());
        }
        protected void btnReadExcelData_Click(object sender, EventArgs e)
        {
            BtnReadExcelDataEvent();
        }
    }
}