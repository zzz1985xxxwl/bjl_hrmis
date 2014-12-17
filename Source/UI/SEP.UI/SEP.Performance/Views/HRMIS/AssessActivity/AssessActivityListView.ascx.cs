//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: AssessActivityListView.cs
// 创建者: 顾艳娟
// 创建日期: 2008-06-23
// 概述: 查询考评活动
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework.Common.DataAccess;
using SEP.HRMIS.Presenter.IPresenter.IAssessActivity;
using SEP.Model.Departments;
using SEP.Presenter.Core;
using hrmisModel = SEP.HRMIS.Model;
using ShiXin.Security;

namespace SEP.Performance.Views.HRMIS.AssessActivity
{
    public partial class AssessActivityListView : UserControl, IAssessActivityListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvAssessActivityList, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvAssessActivityList.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        private const string _NoEventError = "没有按钮事件的响应，请联系管理员";
        private object _AssessActivityId;
        public object AssessActivityId
        {
            get
            {
                return _AssessActivityId;
            }
        }

        public EventHandler btnSearchEvent;
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearchEvent(sender, e);
        }

        public EventHandler BindAssessActivity;
        protected void gvAssessActivityList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindAssessActivity(null, null);
            gvAssessActivityList.PageIndex = e.NewPageIndex;
            gvAssessActivityList.DataSource = _AssessActivitysToList;
            gvAssessActivityList.DataBind();
            SetEmunListColumnTest();
        }

        #region IAssessActivityListView 成员

        public bool btnExportAnnualAssessVisible
        {
            set { btnExportAnnualAssess.Visible = value; }
        }

        public string Message
        {
            set { lblMessage.Text = value; }
        }

        public string EmployeeName
        {
            get { return txtEmployeeName.Text.Trim(); }
        }

        public string CharacterType
        {
            get { return ddlCharacter.SelectedValue; }
        }

        public string StatusType
        {
            get { return ddlStatus.SelectedValue; }
        }

        public string HRSubmitTimeMsg
        {
            set { lblHRSubmitTimeMsg.Text = value; }
        }

        public string HRSubmitTimeFrom
        {
            get { return dtpHRSubmitTimeFrom.Text; }
        }

        public string HRSubmitTimeTo
        {
            get { return dtpHRSubmitTimeTo.Text; }
        }

        private List<hrmisModel.AssessActivity> _AssessActivitysToList;
        public List<hrmisModel.AssessActivity> AssessActivitysToList
        {
            get
            {
                return _AssessActivitysToList;
            }
            set
            {
                _AssessActivitysToList = value;
                gvAssessActivityList.DataSource = value;
                gvAssessActivityList.DataBind();
                SetEmunListColumnTest();
                if (value.Count > 0)
                {
                    tbSearch.Style["display"] = "block";
                }
                else
                {
                    tbSearch.Style["display"] = "none";
                }
            }
        }

        public string ScopeTimeFrom
        {
            get { return txtScopeFrom.Text.Trim(); }
        }

        public string ScopeTimeTo
        {
            get { return txtScopeTo.Text.Trim(); }
        }

        public string ScopeTimeMsg
        {
            set { lblScopeMsg.Text = value; }
        }

        public int FinishStatus
        {
            get { return Convert.ToInt32(ddlFinishStatus.SelectedValue); }
        }

        public int DepartmentID
        {
            get { return Convert.ToInt32(ddlDepartment.SelectedValue); }
        }

        public PagerEntity pagerEntity
        {
            get { return new PagerEntity() { PageIndex = gvAssessActivityList.PageIndex, PageSize = gvAssessActivityList.PageSize }; }
        }

        public List<Department> DepartmentSource
        {
            set
            {
                ddlDepartment.Items.Clear();
                ListItem itemAll = new ListItem(string.Empty, "-1", true);
                ddlDepartment.Items.Add(itemAll);
                foreach (Department department in value)
                {
                    ListItem item = new ListItem(department.DepartmentName, department.DepartmentID.ToString(), true);
                    ddlDepartment.Items.Add(item);
                }
            }
        }

        private void SetEmunListColumnTest()
        {
            for (int i = 0; i < gvAssessActivityList.Rows.Count; i++)
            {
                LinkButton btnEmployeeVisible =
                    (LinkButton)gvAssessActivityList.Rows[i].FindControl("btnEmployeeVisible");
                if (btnEmployeeVisible != null)
                {
                    if (AssessActivitysToList[i].IfEmployeeVisible)
                    {
                        btnEmployeeVisible.Text = "撤销员工可见";
                    }
                    else
                    {
                        btnEmployeeVisible.Text = "设置员工可见";
                    }
                }
            }
        }

        public hrmisModel.Employee Employee
        {
            get
            {
                return _Employee;
            }
            set
            {
                txtEmployeeName.Text = value.Account.Name;
                _Employee = value;
            }
        }
        private hrmisModel.Employee _Employee;

        #endregion

        public Dictionary<string, string> CharacterTypeSource
        {
            set
            {
                ddlCharacter.Items.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    ddlCharacter.Items.Add(item);
                }

            }
        }

        public Dictionary<string, string> StatusTypeSource
        {
            set
            {
                ddlStatus.Items.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    ddlStatus.Items.Add(item);
                }
            }
        }

        public EventHandler btnInterruptClick;
        protected void btnInterrupt_Click(object sender, CommandEventArgs e)
        {
            if (btnInterruptClick == null)
            {
                throw new ArgumentNullException(_NoEventError);
            }
            _AssessActivityId = e.CommandArgument;
            btnInterruptClick(sender, e);
        }

        protected void btnManualDetail_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("ManualAssessBackDetail.aspx?" + ConstParameters.AssessActivityID + "=" + SecurityUtil.DECEncrypt(e.CommandArgument.ToString()));
        }

        protected void gvAssessActivityList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnHiddenPostButton = e.Row.FindControl("btnHiddenPostButton") as Button;
            if (btnHiddenPostButton != null)
            {
                ViewUtility.RowDataBound(sender, e, btnHiddenPostButton, ViewUtility.MouseStyle_Hand);
            }
        }

        protected void gvAssessActivityList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    Response.Redirect(string.Format("AssessBasicInfoBack.aspx?assessActivityID={0}", SecurityUtil.DECEncrypt(e.CommandArgument.ToString())));
                    return;
            }
        }

        public event DelegateID btnExportSelfClick;
        protected void btnExportSelf_Click(object sender, CommandEventArgs e)
        {
            _AssessActivityId = e.CommandArgument;
            btnExportSelfClick(_AssessActivityId.ToString());
        }

        public event DelegateID btnExportLeaderClick;
        protected void btnExportLeader_Click(object sender, CommandEventArgs e)
        {
            _AssessActivityId = e.CommandArgument;
            btnExportLeaderClick(_AssessActivityId.ToString());
        }

        public event Delegate2Parameter btnEmployeeVisibleClick;
        protected void btnEmployeeVisible_Click(object sender, CommandEventArgs e)
        {
            LinkButton btnEmployeeVisible = (LinkButton)sender;
            btnEmployeeVisibleClick(e.CommandArgument.ToString(), btnEmployeeVisible.Text);
        }

        public event DelegateID btnExportEmployeeSummaryClick;
        protected void btnExportEmployeeSummary_Click(object sender, CommandEventArgs e)
        {
            _AssessActivityId = e.CommandArgument;
            btnExportEmployeeSummaryClick(_AssessActivityId.ToString());
        }

        public event DelegateID btnExportAssessFormClick;
        protected void btnExportAssessForm_Click(object sender, CommandEventArgs e)
        {
            _AssessActivityId = e.CommandArgument;
            btnExportAssessFormClick(_AssessActivityId.ToString());
        }

        public event DelegateNoParameter btnExportAnnualAssessClick;
        protected void btnExportAnnualAssess_Click(object sender, EventArgs e)
        {
            btnExportAnnualAssessClick();
        }

        public event DelegateID btnDeleteClick;
        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            _AssessActivityId = e.CommandArgument;
            btnDeleteClick(_AssessActivityId.ToString());
        }
    }
}