//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: InAndOutLogListView.cs
// 创建者: 刘丹
// 创建日期: 2008-10-23
// 概述: 日志信息列表VIEW
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.Presenter;
using SEP.Model.Departments;
using SEP.Presenter.Core;


namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceInAndOutStatistics
{
    public partial class InAndOutLogListView : UserControl, IInAndOutLogListView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvInAndOutLog, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvInAndOutLog.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (BtnSearchEvent != null)
                BtnSearchEvent();
        }

        protected void gvInAndOutLog_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInAndOutLog.PageIndex = e.NewPageIndex;
            btnSearch_Click(sender, e);
        }

        protected void gvInAndOutLog_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }

        private void InformationDisplay()
        {
            foreach (GridViewRow row in gvInAndOutLog.Rows)
            {
                Label lblOperateStatus = row.FindControl("lblOperateStatus") as Label;
                if (lblOperateStatus != null)
                {
                    switch (lblOperateStatus.Text)
                    {
                        case "AddByOperator":
                            lblOperateStatus.Text = "新增";
                            break;
                        case "ModifyByOperator":
                            lblOperateStatus.Text = "修改";
                            break;
                        case "DeleteByOperator":
                            lblOperateStatus.Text = "删除";
                            break;
                        case "ReadFromDataBase":
                            lblOperateStatus.Text = "从ACCESS导入";
                            break;
                        case "ImportByOperator":
                            lblOperateStatus.Text = "从EXCEL导入";
                            break;
                        default:
                            lblOperateStatus.Text = "";
                            break;
                    }
                }

                Label lblIoStatus = row.FindControl("lblIoStatus") as Label;
                if (lblIoStatus != null)
                {
                    switch (lblIoStatus.Text)
                    {
                        case "In":
                            lblIoStatus.Text = "进入";
                            break;
                        case "Out":
                            lblIoStatus.Text = "离开";
                            break;
                        default:
                            lblIoStatus.Text = "";
                            break;
                    }
                }

                Label lblNewIoStatus = row.FindControl("lblNewIoStatus") as Label;
                if (lblNewIoStatus != null)
                {
                    switch (lblNewIoStatus.Text)
                    {
                        case "In":
                            lblNewIoStatus.Text = "进入";
                            break;
                        case "Out":
                            lblNewIoStatus.Text = "离开";
                            break;
                        default:
                            lblNewIoStatus.Text = "";
                            break;
                    }
                }
            }
        }

        #region IInAndOutLogListView 成员

        public string Message
        {
            set { lblMessage.Text = value; }
        }

        public string ErrorMessage
        {
            set { lblErrorMessage.Text = value; }
        }

        public string EmployeeName
        {
            get { return txtEmployeeName.Text; }
            set { txtEmployeeName.Text = value; }
        }

        public int DepartmentId
        {
            get { return Convert.ToInt32(listDepartment.SelectedValue); }
        }

        public List<Department> departmentSource
        {
            set
            {
                listDepartment.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, "-1", true);
                listDepartment.Items.Add(itemAll);
                foreach (Department department in value)
                {
                    ListItem item = new ListItem(department.Name, department.Id.ToString(), true);
                    listDepartment.Items.Add(item);
                }
            }
        }

        public string TimeFrom
        {
            get { return dtpScopeFrom.Text; }
        }

        public string TimeTo
        {
            get { return dtpScopeTo.Text; }
        }

        public string OperatTime
        {
            get { return txtOperatimeFrom.Text; }
        }

        public string OperatTo
        {
            get { return txtOperatimeTo.Text; }
        }

        public string TimeErrorMessage
        {
            set { lblTimeError.Text = value; }
        }

        public string operatorName
        {
            get { return txtOperator.Text; }
        }

        public List<AttendanceInAndOutRecordLog> InAndOutLogs
        {
            set
            {
                gvInAndOutLog.DataSource = value;
                gvInAndOutLog.DataBind();
                if (value == null || value.Count == 0)
                {
                    tbInAndOutLog.Style["display"] = "none";
                    lblMessage.Text = "0";
                }
                else
                {
                    tbInAndOutLog.Style["display"] = "block";
                    lblMessage.Text = value.Count.ToString();
                }

                InformationDisplay();
            }
        }

        public event DelegateNoParameter BtnSearchEvent;

        #endregion
    }
}
    
