//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: LeaveRequestTypeView.cs
// 创建者: wangshlai
// 创建日期: 2008-08-04
// 概述: 假期类型界面
// ----------------------------------------------------------------
using System;
using System.Web.UI;
using SEP.HRMIS.Model.Request;
using SEP.HRMIS.Presenter.IPresenter.ILeaveRequestType;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.LeaveRequestTypes
{
    public partial class LeaveRequestTypeView : UserControl, ILeaveRequestTypeView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.OnClientClick = "return CloseModalPopupExtender('divMPE');";
        }

        #region ILeaveRequestTypeView成员

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
            get { return lblNameMsg.Text; }
            set { lblNameMsg.Text = value; }
        }

        public string LeastHourMsg
        {
            get { return lbLeastHourMsg.Text; }
            set { lbLeastHourMsg.Text = value; }
        }

        public string LeastHour
        {
            get { return txtLeastHour.Text.Trim(); }
            set { txtLeastHour.Text = value; }
        }

        public string OperationTitle
        {
            set { lblOperation.Text = value; }
            get { return lblOperation.Text; }
        }

        public string LeaveRequestTypeID
        {
            get { return txtID.Text.Trim(); }
            set { txtID.Text = value; }
        }

        public string LeaveRequestTypeName
        {
            get { return txtName.Text.Trim(); }
            set { txtName.Text = value; }
        }

        public string LeaveRequestTypeDescription
        {
            get { return txtDescription.Text.Trim(); }
            set { txtDescription.Text = value; }
        }

        public bool SetReadonly
        {
            set
            {
                txtID.ReadOnly = value;
                txtName.ReadOnly = value;
                txtDescription.ReadOnly = value;
                chIncludeRestDay.Enabled = !value;
                chIncludeLegalHoliday.Enabled = !value;
            }
        }

        public bool SetIDReadonly
        {
            set { txtID.ReadOnly = value; }
        }

        public string ActionButtonTxt
        {
            get { return btnOK.Text; }
            set { btnOK.Text = value; }
        }

        public bool ActionButtonEnable
        {
            get { return btnOK.Enabled; }
            set { btnOK.Enabled = value; }
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

        #region ILeaveRequestTypeView 成员

        public LegalHoliday IncludeLegalHoliday
        {
            get { return chIncludeLegalHoliday.Checked ? LegalHoliday.Include : LegalHoliday.UnInclude; }

            set { chIncludeLegalHoliday.Checked = value == LegalHoliday.Include; }
        }

        public RestDay IncludeRestDay
        {
            get { return chIncludeRestDay.Checked ? RestDay.Include : RestDay.UnInclude; }

            set { chIncludeRestDay.Checked = value == RestDay.Include; }
        }

        #endregion
    }
}