//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ReadHistoryListView.cs
// 创建者: 刘丹
// 创建日期: 2008-10-16
// 概述: 读取数据历史列表
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.EmployeeAttendance.ReadData;
using SEP.HRMIS.Presenter.IPresenter.IAttendanceStatistics.ReadDataViews;
using SEP.Presenter.Core;

namespace SEP.Performance.Views.HRMIS.AttendanceStatistics.ReadDataInfo
{
    public partial class ReadHistoryListView :UserControl,IReadHistoryListView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCancel.Attributes["onclick"] = "return CloseModalPopupExtender('divMPEReadHistoryListView');";
            BindPageTemplate();
        }

        protected void LinkButtonGoPage_Click(int pageindex)
        {
            gvReadHistory.PageIndex = pageindex;
            BindDataEvent();
        }

        public void BindPageTemplate()
        {
            PageTemplate PageTemplate1 = ViewUtility.GetPageTemplate(gvReadHistory, "PageTemplate1");

            if (PageTemplate1 != null)
            {
                PageTemplate1.LinkButtonGoPageClickdelegate += LinkButtonGoPage_Click;
            }
        }

        protected void gvLeaveRequestType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvReadHistory.PageIndex = e.NewPageIndex;
            BindDataEvent();
        }

        #region IReadHistoryListView
        private bool _IsReadSuccess;
        public bool IsReadSuccess
        {
            get { return _IsReadSuccess; }
            set { _IsReadSuccess = value; }
        }
        public string Message
        {
            set { lblMessage.Text = value; }
        }

        public string ErrorMessage
        {
            set { lbl_ImportResult.Text = value; }
        }

        private List<ReadDataHistory> historys=new  List<ReadDataHistory>();
        public List<ReadDataHistory> ReadHistorys
        {
            set
            {
                historys = value;
                gvReadHistory.DataSource = value;
                gvReadHistory.DataBind();
                if (historys == null || historys.Count == 0)
                {
                    tbReadHistory.Style["display"] = "none";
                }
                else
                {
                    tbReadHistory.Style["display"] = "block";
                }
                lblMessage.Text = historys.Count.ToString();
                MessageDisplay();
            }
        }

        /// <summary>
        /// 上午上班时间范围
        /// </summary>
        public string ReadFromTime
        {
            get { return string.IsNullOrEmpty(txtDay1.Text.Trim()) ? string.Empty : string.Format("{0} {1}:{2}:{3}", txtDay1.Text, listHour1.Text, listMinutes1.Text, listSecond2.Text); }
        }

        /// <summary>
        /// 上午上班时间范围
        /// </summary>
        public string ReadToTime
        {
            get
            {
                return string.IsNullOrEmpty(txtDay2.Text.Trim()) ? string.Empty : string.Format("{0} {1}:{2}:{3}", txtDay2.Text, listHour2.Text, listMinutes2.Text,
                                                                                                listSecond2.Text);
            }
        }

        public List<string> HoursSource
        {
            set
            {
                listHour1.Items.Clear();
                listHour2.Items.Clear();
                foreach (string s in value)
                {
                    listHour1.Items.Add(s);
                    listHour2.Items.Add(s);
                }
            }
        }

        public List<string> MinutesSource
        {
            set
            {
                listMinutes1.Items.Clear();
                listMinutes2.Items.Clear();
                listSecond1.Items.Clear();
                listSecond2.Items.Clear();


                foreach (string s in value)
                {
                    listMinutes1.Items.Add(s);
                    listMinutes2.Items.Add(s);
                    listSecond1.Items.Add(s);
                    listSecond2.Items.Add(s);

                }
            }
        }

        public event DelegateNoParameter BtnReadEvent;
        public event DelegateNoParameter BindDataEvent;
        public event DelegateNoParameter BtnCancelEvent;

        #endregion

        protected void btnRead_Click(object sender, EventArgs e)
        {
            lbl_ImportResult.Text = "";
            BtnReadEvent();
        }

        private void MessageDisplay()
        {
            foreach (GridViewRow row in gvReadHistory.Rows)
            {
                Label lblReadResult = (Label)row.FindControl("lblReadResult");
                switch (lblReadResult.Text)
                {
                    case "Reading":
                        lblReadResult.Text = "读取中";
                        break;
                    case "ReadSuccess":
                        lblReadResult.Text = "读取成功";
                        break;
                    case "ReadFail":
                        lblReadResult.Text = "读取失败";
                        break;
                    default:
                        lblReadResult.Text = "";
                        break;
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BtnCancelEvent();
        }

        
    }
}