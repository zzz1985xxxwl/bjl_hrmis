//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: DayAttendanceSearchView.cs
// 创建者: 王玥琦
// 创建日期: 2009-6-1
// 概述: 考勤查询
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics;
using SEP.Model.Accounts;
using SEP.Model.Departments;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics
{
    public partial class ApplicationSearchView : UserControl, IApplicationSearchView
    {
        #region IInAndOutStatisticsView成员

        public List<Department> DepartmentList
        {
            set
            {
                listDepartment.Items.Clear();
                ListItem item = new ListItem("", "-1", true);
                listDepartment.Items.Add(item);
                foreach (Department department in value)
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

        public List<ApplicationTypeEnum> ApplicationTypeEnumSourse 
        {
            set
            {
                ddApplicationType.Items.Clear();
                foreach (ApplicationTypeEnum applicationTypeEnum in value)
                {
                    ListItem item =
                        new ListItem(RequestUtility.GetTypeName(applicationTypeEnum),
                                     ((int) applicationTypeEnum).ToString(), true);
                    ddApplicationType.Items.Add(item);
                } 
            }
            get
            {
                return null;
            }
        }

        public List<RequestStatus> RequestStatusSourse
        {
            set
            {
                ddStatus.Items.Clear();
                foreach (RequestStatus applicationStatusEnum in value)
                {
                    ListItem item = new ListItem(RequestStatus.FindRequestStatus(applicationStatusEnum.Id).Name
                        , applicationStatusEnum.Id.ToString(), true);
                    ddStatus.Items.Add(item);
                }
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

        public string SearchFrom
        {
            set
            {
                dtpScopeFrom.Text = value;
            }
            get
            {
                return dtpScopeFrom.Text ;
            }
        }

        public string SearchTo
        {
            set
            {
                dtpScopeTo.Text = value;
            }
            get
            {
                return dtpScopeTo.Text ;
            }
        }

        public string Status
        {
            get
            {
                return ddStatus.SelectedValue;
            }
            set
            {
                ddStatus.SelectedValue = value;
            }
        }

        public string ApplicationType
        {
            get
            {
                return ddApplicationType.SelectedValue;
            }
            set
            {
                ddApplicationType.SelectedValue = value;
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

        public string ErrorValidateTime
        {
            set
            {
                lblValidateTime.Text = value;
                lblValidateTime.Visible = !string.IsNullOrEmpty(value);
            }
            get
            {
                return lblValidateTime.Text;
            }
        } 

        public List<Request> RequestList
        {
            set 
            {
                gvApplicationList.DataSource = value;
                gvApplicationList.DataBind();
                if (value == null || value.Count == 0)
                {
                    tbInAndOutStatistics.Style["display"] = "none";
                }
                else
                {
                    tbInAndOutStatistics.Style["display"] = "block";

                }
                if (value != null) lblMessage.Text = value.Count.ToString();
            }
            get
            {
                return (List<Request>)gvApplicationList.DataSource;
            }
        }

        public event DelegateNoParameter BtnSearchEvent;
        public event DelegateID btnViewClick;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvApplicationList.PageIndex = pageindex;
            btnSearch_Click(null,null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvApplicationList, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }

        protected void gvApplicationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvApplicationList.PageIndex = e.NewPageIndex;
            BtnSearchEvent();
        }

        protected void gvApplicationList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }
        protected void gvApplicationList_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    btnViewClick(e.CommandArgument.ToString());
                    return;
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
            StringWriter theMemoryWriter = new StringWriter();
            StringBuilder application = new StringBuilder();
            application.Append("申请人\t");
            application.Append("起始日期\t");
            application.Append("结束日期\t");
            application.Append("申请小时\t");
            application.Append("申请类型\t");
            application.Append("详细项\t");
            application.Append("其他信息\t");

            theMemoryWriter.WriteLine(application);
            if (RequestList != null)
            {
                foreach (Request request in RequestList)
                {
                    application = new StringBuilder();
                    application.Append(request.Account.Name).Append("\t");
                    application.Append(request.FromDate).Append("\t");
                    application.Append(request.ToDate).Append("\t");
                    application.Append(request.RequestTime).Append("\t");
                    application.Append(request.RequestTypeShow).Append("\t");
                    application.Append(request.ItemsExcel).Append("\t");
                    application.Append(request.MoreDetailExcel).Append("\t");
                    theMemoryWriter.WriteLine(application);
                }
            }


            Response.Charset = "GB2312";
            Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            Response.AppendHeader("Content-Disposition",
                                  "attachment;filename=" + HttpUtility.UrlEncode("申请记录.xls", Encoding.UTF8));
            Response.ContentType = "application/ms-excel";
            EnableViewState = false;
            Response.Write(theMemoryWriter.ToString());
            Response.End();
            theMemoryWriter.Close();
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
    }
}
