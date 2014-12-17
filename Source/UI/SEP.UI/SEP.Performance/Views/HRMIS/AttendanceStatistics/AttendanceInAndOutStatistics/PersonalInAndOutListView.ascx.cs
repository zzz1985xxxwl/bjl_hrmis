//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PersonalInAndOutListView.cs
// 创建者:刘丹
// 创建日期: 2008-10-21
// 概述: PersonalInAndOutListView 列表
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.Presenter;
using SEP.Model.Departments;
using SEP.Presenter.Core;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceInAndOutStatistics
{
    public partial class PersonalInAndOutListView : UserControl, IPersonalInAndOutListView
    {
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
            if (BtnSearchEvent != null)
                BtnSearchEvent();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (BtnAddEvent != null)
                BtnAddEvent();
        }

        protected void gvInAndOutStatistics_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInAndOutStatistics.PageIndex = e.NewPageIndex;
            btnSearch_Click(sender, e);
        }

        protected void gvInAndOutStatistics_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int employeeid;
            if (int.TryParse(e.CommandName, out employeeid))
            {
                Response.Redirect("InAndOutDetailListView.aspx?" + 
                    ConstParameters.EmployeeId + "=" + SecurityUtil.DECEncrypt(e.CommandName) + "&" + 
                    ConstParameters.DepartmentID + "=" + SecurityUtil.DECEncrypt("-1") + "&" + 
                    ConstParameters.SearchFrom + "=" + SecurityUtil.DECEncrypt(getTimeFrom()) + "&" + 
                    ConstParameters.SearchTo + "=" + SecurityUtil.DECEncrypt(getTimeTo())
                   );
            }
            else
            {
                switch (e.CommandName)
                {
                    case "HiddenPostButtonCommand":
                        if (BtnDetailEvent != null)
                            BtnDetailEvent(e.CommandArgument.ToString());
                        break;
                    default:
                        break;
                }
            }
        }

        protected void gvLeaveRequestType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetTheGridHandStyle(e, sender);
        }

        protected void btnModify_Click(object sender, CommandEventArgs e)
        {
            if (BtnUpdateEvent != null)
                BtnUpdateEvent(e.CommandArgument.ToString());
        }

        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            if (BtnDeleteEvent != null)
                BtnDeleteEvent(e.CommandArgument.ToString());
        }

        /// <summary>
        /// 得到选择的查询开始时间
        /// </summary>
        /// <returns></returns>
        private string getTimeFrom()
        {
            string from;
            if (string.IsNullOrEmpty(dtpScopeFrom.Text.Trim()))
            {
                from = string.Empty;
            }
            else
            {
                from = dtpScopeFrom.Text + " " + listHourFrom.Text + ":" + listMinutesFrom.Text;
            }
            return from;
        }

        /// <summary>
        /// 得到选择的查询结束时间
        /// </summary>
        /// <returns></returns>
        private string getTimeTo()
        {
            string to;
            if (string.IsNullOrEmpty(dtpScopeTo.Text.Trim()))
            {
                to = string.Empty;
            }
            else
            {
                to = dtpScopeTo.Text + " " + listHourTo.Text + ":" + listMinutesTo.Text;
            }
            return to;
        }

        #region  IPersonalInAndOutListView

        public string Message
        {
            set { lblMessage.Text = value; }
        }

        public string ErrorMessage
        {
            set { lblErrorMessage.Text = value; }
        }

        public string EmployeeId
        {
            get { return HfemployeeId.Value; }
            set { HfemployeeId.Value = value; }
        }

        public string EmployeeName
        {
            get { return txtEmployeeName.Text; }
            set { txtEmployeeName.Text = value; }
        }

        public int Department
        {
            get { return Convert.ToInt32(listDepartment.SelectedValue); }
            set
            {
                listDepartment.SelectedValue = value.ToString();
            }
        }

        public string TimeFrom
        {
            get
            {
                return getTimeFrom();
            }
            set
            {
                DateTime temp = Convert.ToDateTime(value);
                dtpScopeFrom.Text = temp.ToShortDateString();
                if (dtpScopeFrom.Text.Equals("1900-1-1"))
                {
                    dtpScopeFrom.Text = string.Empty;
                }
                string[] t1 = temp.ToShortTimeString().Split(':');
                listHourFrom.Text = t1[0];
                listMinutesFrom.Text = t1[1];
            }
        }

        public string TimeTo
        {
            get
            {
                return getTimeTo();
            }
            set
            {
                DateTime temp2 = Convert.ToDateTime(value);
                dtpScopeTo.Text = temp2.ToShortDateString();
                if (dtpScopeTo.Text.Equals("2999-12-31"))
                {
                    dtpScopeTo.Text = string.Empty;
                }
                string[] t2 = temp2.ToShortTimeString().Split(':');
                listHourTo.Text = t2[0];
                listMinutesTo.Text = t2[1];
            }
        }

        public string TempTimeFrom
        {
            get { return HftempTimeFrom.Value; }
            set { HftempTimeFrom.Value = value; }
        }

        public string TempTimeTo
        {
            get { return HftempTimeTo.Value; }
            set { HftempTimeTo.Value = value; }
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

        public string IOStatusId
        {
            get { return listStatus.SelectedValue; }
        }

        public Dictionary<string, string> IOStatusSource
        {
            set
            {
                listStatus.Items.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    listStatus.Items.Add(item);
                }
            }
        }

        public string OperateStatusId
        {
            get { return listOperator.SelectedValue; }
        }

        public Dictionary<string, string> OperateStatusSource
        {
            set
            {
                listOperator.Items.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    listOperator.Items.Add(item);
                }
            }
        }
        
        public List<AttendanceInAndOutRecord> InAndOutRecords
        {
            set
            {
                gvInAndOutStatistics.DataSource = value;
                gvInAndOutStatistics.DataBind();
                if (value == null || value.Count == 0)
                {
                    tbInAndOutStatistics.Style["display"] = "none";
                    lblMessage.Text = "0";
                }
                else
                {
                    tbInAndOutStatistics.Style["display"] = "block";
                    lblMessage.Text = value.Count.ToString();
                }
                InformationDisplay();
                Session[SessionKeys.PersionInAndOutDataTable] = value;
            }
        }

        public event DelegateNoParameter BtnAddEvent;
        public event DelegateID BtnUpdateEvent;
        public event DelegateID BtnDetailEvent;
        public event DelegateID BtnDeleteEvent;
        public event DelegateNoParameter BtnSearchEvent;

        public bool SetButtonVisible
        {
            set
            {
                btnAdd.Visible = value;
                btnAdd.Enabled = value;
                gvInAndOutStatistics.Columns[6].Visible = value;
                gvInAndOutStatistics.Columns[7].Visible = value;
                txtEmployeeName.Enabled = !value;
                listDepartment.Enabled = !value;
                FindOperateButton(value);
            }
        }

        public List<string> HoursSource
        {
            set
            {
                listHourFrom.Items.Clear();
                listHourTo.Items.Clear();
                foreach (string s in value)
                {
                    listHourFrom.Items.Add(s);
                    listHourTo.Items.Add(s);
                }
            }
        }

        public List<string> MinutesSource
        {
            set
            {
                listMinutesFrom.Items.Clear();
                listMinutesTo.Items.Clear();
                foreach (string s in value)
                {
                    listMinutesFrom.Items.Add(s);
                    listMinutesTo.Items.Add(s);
                }
            }
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


        #endregion

        private void InformationDisplay()
        {
            foreach (GridViewRow row in gvInAndOutStatistics.Rows)
            {
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
            }
        }

        private void FindOperateButton(bool value)
        {
            foreach (GridViewRow row in gvInAndOutStatistics.Rows)
            {
                LinkButton btnModify = (LinkButton)row.FindControl("btnModify");
                LinkButton btnDelete = (LinkButton)row.FindControl("btnDelete");
                LinkButton btnHiddenPostButton = (LinkButton)row.FindControl("btnHiddenPostButton");
                btnModify.Enabled = value;
                btnDelete.Enabled = value;
                if (value)
                {
                    btnHiddenPostButton.CommandName = "HiddenPostButtonCommand";
                }
            }
        }
    }
}