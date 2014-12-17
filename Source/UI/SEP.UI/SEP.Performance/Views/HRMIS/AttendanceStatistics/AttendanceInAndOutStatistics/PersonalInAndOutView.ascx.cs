//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: PersonalInAndOutView.cs
// 创建者:刘丹
// 创建日期: 2008-10-21
// 概述: PersonalInAndOutView 列表
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.AttendanceInAndOutStatistics
{
    public partial class PersonalInAndOutView : UserControl,IPersonalInAndOutView
    {
        protected void btnOK_Click(object sender, EventArgs e)
        {
            ActionButtonEvent();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CancelButtonEvent();
        }

        #region IPersonalInAndOutView

        public string Message
        {
            set { lblMessage.Text = value;
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

        public string EmployeeName
        {
            get { return txtEmoloyeeName.Text; }
            set { txtEmoloyeeName.Text = value; }
        }

        public string EmployeeId
        {
            get { return HfemployeeId.Value; }
            set { HfemployeeId.Value = value; }
        }

        public string DoorCardNo
        {
            get { return txtCardNo.Text; }
            set { txtCardNo.Text = value; }
        }

        public string RecordId
        {
            get { return HfrecordId.Value; }
            set { HfrecordId.Value = value; }
        }

        public string IOTime
        {
            get { return txtIoTime.Text + " " + listHour1.Text + ":" + listMinutes1.Text; }
            set
            {
                DateTime temp = Convert.ToDateTime(value);
                txtIoTime.Text = temp.ToShortDateString();
                string[] t = temp.ToShortTimeString().Split(':');
                listHour1.Text = t[0];
                listMinutes1.Text = t[1];
            }
        }

        public string TimeMessage
        {
            set { lblTimeMessage.Text = value; }
        }

        public string IOStatusId
        {
            get { return listStatus.SelectedValue; }
            set { listStatus.SelectedValue = value; }
        }

        public Dictionary<string, string> IOStatusSource
        {
            set
            {
                listStatus.Items.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    if (!string.IsNullOrEmpty(pair.Value))
                    {
                        ListItem item = new ListItem(pair.Value, pair.Key, true);
                        listStatus.Items.Add(item);
                    }
                }
            }
        }

        public string Reason
        {
            get { return txtReason.Text; }
            set { txtReason.Text = value; }
        }

        public string ReasonMessage
        {
            get { return lblReasonMsg.Text; }
            set { lblReasonMsg.Text = value; }
        }

        public string OperationTitle
        {
            get { return lblOperation.Text; }
            set { lblOperation.Text = value; }
        }

        public event DelegateNoParameter ActionButtonEvent;
        public event DelegateNoParameter CancelButtonEvent;

        private bool actionSuccess;
        public bool ActionSuccess
        {
            get { return actionSuccess; }
            set { actionSuccess = value; }
        }

        public string OperationType
        {
            get { return Operation.Value; }
            set { Operation.Value = value; }
        }

        public List<string> HoursSource
        {
            set
            {
                listHour1.Items.Clear();
                foreach (string s in value)
                {
                    listHour1.Items.Add(s);
                }
            }
        }

        public List<string> MinutesSource
        {
            set
            {
                listMinutes1.Items.Clear();
                foreach (string s in value)
                {
                    listMinutes1.Items.Add(s);
                }
            }
        }

        public bool SetReadOnly
        {
            set
            {
                txtIoTime.Enabled = value;
                listHour1.Enabled = value;
                listMinutes1.Enabled = value;
                listStatus.Enabled = value;
            }
        }

        public bool SetReasonReadOnly
        {
            set
            {
                txtReason.Enabled = value;
            }
        }

        #endregion
    }
}