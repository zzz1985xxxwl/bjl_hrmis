//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SkillTypeListView.ascx.cs
// 创建者: ZZ
// 创建日期: 2008-11-10
// 概述: 技能类型的查询界面
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter;
using SEP.Presenter.Core;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.SkillType
{
    public partial class SkillTypeListView : UserControl,ISkillTypeListView
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvSkill.PageIndex = pageindex;
            btnSearch_Click(null, null);
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvSkill, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        private List<HRMISModel.SkillType> _SkillTypes;

        
        public string SkillTypeName
        {
            get { return txtName.Text.Trim(); }
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set { lblMessage.Text = value; }
        }

        public string ErrorMessage
        {
            get { return lblErrorMsg.Text; }
            set { lblErrorMsg.Text = value; }
        }

        public List<HRMISModel.SkillType> SkillTypes
        {
            get
            {
                return _SkillTypes;
            }
            set
            {
                _SkillTypes = value;
                gvSkill.DataSource = value;
                gvSkill.DataBind();
                if (_SkillTypes == null || _SkillTypes.Count == 0)
                {
                    tbSkill.Style["display"] = "none";
                }
                else
                {
                    tbSkill.Style["display"] = "block";

                }
                lblMessage.Text = value.Count.ToString();
            }
        }

        public event DelegateNoParameter BtnAddEvent;
        public event DelegateID BtnDeleteEvent;
        public event DelegateID BtnUpdateEvent;
        public event DelegateNoParameter BtnSearchEvent;

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BtnAddEvent();
        }

        protected void btnUpdate_Click(object sender, CommandEventArgs e)
        {
            BtnUpdateEvent(e.CommandArgument.ToString());
        }

        protected void btnDelete_Click(object sender, CommandEventArgs e)
        {
            BtnDeleteEvent(e.CommandArgument.ToString());
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BtnSearchEvent();
        }

        protected void gvSkillType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSkill.PageIndex = e.NewPageIndex;
            //gvLeaveRequestType.DataSource = _LeaveRequestTypes;
            //gvLeaveRequestType.DataBind();
            btnSearch_Click(sender, e);
        }

        protected void gvSkillType_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "HiddenPostButtonCommand":
                    return;
            }
        }

        protected void gvSkillType_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ViewUtility.SetGridViewDefaultStyle(e);
        }
    }
}