//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SetReadDataRuleView.cs
// 创建者: 刘丹
// 创建日期: 2008-10-16
// 概述: 设置考勤读取时间
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.ReadDataViews;
using SEP.Presenter.Core;


namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.ReadDataInfo
{
    public partial class SetReadDataRuleView : UserControl,IReadAttendanceRuleView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('divMPESetReadDataRuleView');";
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            BtnConfrimEvent();
        }

        #region IReadAttendanceRuleView
        private bool _IsActionSuccess;
        public bool IsActionSuccess 
        {
            get { return _IsActionSuccess; }
            set { _IsActionSuccess = value; }
        }

        public string Message
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    tbMessage.Style["display"] = "none";
                }
                else
                {
                    tbMessage.Style["display"] = "block";
                }
                lblMessage.Text = "<span class='fontred'>" + value + "</span>";
            }
        }

        public string ReadRuleId
        {
            get { return SetId.Value; }
            set { SetId.Value = value; }
        }

        public string ReadTime
        {
            get { return DateTime.Now.ToShortDateString() + " " + listHour1.Text + ":" + listMinutes1.Text; }
            set
            {
                DateTime temp = Convert.ToDateTime(value);
                string[] t = temp.ToShortTimeString().Split(':');
                listHour1.Text = t[0];
                listMinutes1.Text = t[1];
            }
        }

        public bool IsSendMail
        {
            get { return checkMail.Checked; }
            set { checkMail.Checked = value; }
        }

        public string SendMailRuleId
        {
            get { return listSendMailRule.SelectedValue; }
            set { listSendMailRule.SelectedValue = value; }
        }

        public Dictionary<string, string> SendMailRuleSource
        {
            set
            {
               listSendMailRule.Items.Clear();
                foreach (KeyValuePair<string, string> pair in value)
                {
                    ListItem item = new ListItem(pair.Value, pair.Key, true);
                    listSendMailRule.Items.Add(item);
                }
            }
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

        public event DelegateNoParameter BtnConfrimEvent;
        public event DelegateNoParameter BtnCancelEvent;
        #endregion

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BtnCancelEvent();
        }
    }
}