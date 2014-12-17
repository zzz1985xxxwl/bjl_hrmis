//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: EmployeeSkillView.cs
// 创建者: 顾艳娟
// 创建日期: 2008-11-06
// 概述: 员工技能总界面的Presenter
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model;
using SEP.HRMIS.Presenter;
using SEP.HRMIS.Presenter.IPresenter.IEmployeeInformation;
using SEP.Presenter.Core;
using HRMISModel = SEP.HRMIS.Model;

namespace SEP.Performance.Views.EmployeeInformation.SkillInfomation
{
    public partial class EmployeeSkillView : UserControl, IEmpSkillView
    {
        private bool _ActionSuccess;

        public event DelegateNoParameter btnOKClick;
        public event DelegateNoParameter btnCancelClick;
        public event DelegateNoParameter SkillTypeSelectChangeEvent;

        public string Score
        {
            get { return txtScore.Text.Trim(); }
            set { txtScore.Text = value; }
        }

        public string Remark
        {
            get { return txtRemark.Text.Trim(); }
            set { txtRemark.Text = value; }
        }

        public string ScoreMsg
        {
            get { return lblScoreMsg.Text.Trim(); }
            set { lblScoreMsg.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('divMPE');";
        }

        protected void btnOK_ServerClick(object sender, EventArgs e)
        {
            btnOKClick();
        }

        protected void btnCancel_ServerClick(object sender, EventArgs e)
        {
            btnCancelClick();
        }

        #region ISkillInfoView 成员

        public string Title
        {
            get{return lblTitle.Text;}
            set{lblTitle.Text = value;}
        }

        public string Skill
        {
            get { return ddlSkill.SelectedValue; }
            set{ ddlSkill.SelectedValue = value;}
        }

        string IEmpSkillView.SkillMsg
        {
            get { return SkillMsg.Text; }
            set { SkillMsg.Text = value; }
        }

        public string SkillType
        {
            get { return ddlSkillType.SelectedValue; }
            set { ddlSkillType.SelectedValue = value; }
        }

        string IEmpSkillView.SkillTypeMsg
        {
            get { return SkillTypeMsg.Text; }
            set { SkillTypeMsg.Text = value; }
        }

        public string SkillLevel
        {
            get { return ddlSkillLevel.SelectedItem.Value; }
            set { ddlSkillLevel.SelectedValue = value; }
        }

        string IEmpSkillView.SkillLevelMsg
        {
            get { return SkillLevelMsg.Text; }
            set { SkillLevelMsg.Text = value; }
        }

        public List<HRMISModel.Skill> SkillSource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                ddlSkill.Items.Clear();
                foreach (HRMISModel.Skill skill in value)
                {
                    ddlSkill.Items.Add(new ListItem(skill.SkillName, skill.SkillID.ToString(), true));
                }
            }
        }

        public List<HRMISModel.SkillType> SkillTypeSource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                ddlSkillType.Items.Clear();
                foreach (HRMISModel.SkillType skillType in value)
                {
                    ddlSkillType.Items.Add(new ListItem(skillType.Name, skillType.ParameterID.ToString(), true));
                }
            }
        }

        public List<SkillLevelType> SkillLevelTypeSource
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                ddlSkillLevel.Items.Clear();
                foreach (SkillLevelType skillLevel in value)
                {
                    ddlSkillLevel.Items.Add(new ListItem(skillLevel.Name, skillLevel.Id.ToString(), true));
                }
            }
        }

        public bool ActionSuccess
        {
            get{return _ActionSuccess;}
            set{_ActionSuccess = value;}
        }

        public string Id
        {
            get { return lblID.Text; }
            set { lblID.Text = value; }
        }

        public List<EmployeeSkill> EmployeeSkillSource
        {
            get
            {
                return (List<EmployeeSkill>)ViewState["EmployeeSkill"];
                //return Session["EmployeeSkill"] as List<EmployeeSkill>;
            }
            set
            {
                ViewState["EmployeeSkill"] = value;
                //Session["EmployeeSkill"] = value;
            }
        }
        #endregion

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SkillTypeSelectChangeEvent();
        }


   

    }
}