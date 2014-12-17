//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SkillTypeView.ascx.cs
// 创建者: ZZ
// 创建日期: 2008-11-10
// 概述: 技能类型的小界面
// ----------------------------------------------------------------
using System;
using System.Web.UI;
using SEP.HRMIS.Presenter;
using SEP.Presenter.Core;


namespace SEP.Performance.Views.SkillType
{
    public partial class SkillTypeView : UserControl, ISkillTypeView
    {
        #region ISkillTypeView 成员

        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('divSkillType');";
        }

        public string Message
        {
            get { return lblMessage.Text; }
            set
            {
                lblMessage.Text = value;
                if (string.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
            }
        }

        public string NameMsg
        {
            set { lblNameMsg.Text = value; }
        }

        public string SkillTypeID
        {
            get { return txtID.Text; }
            set { txtID.Text = value; }
        }

        public string SkillTypeName
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value; }
        }

       

        public string OperationTitle
        {
            get { return lblOperation.Text; }
            set { lblOperation.Text = value; }
        }

        public string OperationType
        {
            get { return Operation.Value; }
            set { Operation.Value = value; }
        }
        private bool actionSuccess;
        public bool ActionSuccess
        {
            get { return actionSuccess; }
            set { actionSuccess = value; }
        }
        
        #endregion
        public event DelegateNoParameter ActionButtonEvent;
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ActionButtonEvent();
        }

        public event DelegateNoParameter CancelButtonEvent;
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CancelButtonEvent();
        }
    }
}