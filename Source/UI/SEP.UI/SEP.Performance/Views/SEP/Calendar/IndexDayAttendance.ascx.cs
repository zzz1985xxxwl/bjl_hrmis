//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ViewCalendar.cs
// 创建者: 王玥琦
// 创建日期: 2008-08-08
// 概述: 显示日期信息
// ----------------------------------------------------------------
using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;

using SEP.Presenter.IPresenter.ICalendar;

namespace SEP.Performance.Views.SEP.Calendar
{
    public partial class IndexDayAttendance : UserControl, IMyDayAttendance
    {
        private const string _WorkText = "工作";
        private const string _RestText = "休息";
        private const string _Id = "Id";
        private const string _SpecialDate = "SpecialDate";
        private const string _SpecialDescription = "SpecialDescription";
        private const string _SpecialHeader = "SpecialHeader";
        private const string _SpecialBackColor = "SpecialBackColor";
        private const string _SpecialForeColor = "SpecialForeColor";
        private const string _SpecialIsWork = "SpecialIsWork";


        protected void Page_Load(object sender, EventArgs e)
        {
            Calendar1.WorkText = _WorkText;
            Calendar1.RestText = _RestText;
            Calendar1.SpecialDateColumnName = _SpecialDate;
            Calendar1.SpecialDescriptionColumnName = _SpecialDescription;
            Calendar1.SpecialHeaderColumnName = _SpecialHeader;
            Calendar1.SpecialBackColorName = _SpecialBackColor;
            Calendar1.SpecialForeColorName = _SpecialForeColor;
            Calendar1.SpecialIsWork = _SpecialIsWork;

            Calendar1.EventStartDateColumnName = "EventStartDate";
            Calendar1.EventEndDateColumnName = "EventEndDate";
            Calendar1.EventDescriptionColumnName = "EventDescription";
            Calendar1.EventHeaderColumnName = "EventHeader";
            Calendar1.EventBackColorName = "EventBackColor";
            Calendar1.EventForeColorName = "EventForeColor";
        }

        public string EmployeeID
        {
            set { lblEmployeeID.Value = value; }
            get { return lblEmployeeID.Value; }
        }

        public string CurrentMonth
        {
            set
            {
                lblCurrentMonth.Value = value;
            }
            get
            {
                return lblCurrentMonth.Value;
            }
        }

        public bool IBtnCloseVisible
        {
            set { IBtnClose.Visible = value; }
        }

        public bool EmployeeNameVisible
        {
            set { lblEmployeeName.Visible = value; }
        }

        public string EmployeeName
        {
            set { lblEmployeeName.Text = value; }
            get { return lblEmployeeName.Text; }
        }

        public string Type
        {
            get
            {
                return "";
            }
            set
            {

            }
        }
        public string ResultMessage
        {
            set { lblResultMessage.Text = value; }
            get { return lblResultMessage.Text; }
        }
        public DataTable CalendarTable
        {
            set
            {
                Calendar1.EventSource = value;
            }
            get
            { return Calendar1.EventSource; }
        }
        private void GetPlanDutyDetailList(IList<PlanDutyDetail> planDutyDetailList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(_Id, System.Type.GetType("System.Int32"));
            dt.Columns.Add(_SpecialDate, System.Type.GetType("System.DateTime"));
            dt.Columns.Add(_SpecialHeader, System.Type.GetType("System.String"));
            dt.Columns.Add(_SpecialDescription, System.Type.GetType("System.String"));
            dt.Columns.Add(_SpecialForeColor, System.Type.GetType("System.String"));
            dt.Columns.Add(_SpecialBackColor, System.Type.GetType("System.String"));
            dt.Columns.Add(_SpecialIsWork, System.Type.GetType("System.String"));
            for (int i = 0; i < planDutyDetailList.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[_Id] = planDutyDetailList[i].PlanDutyDetailID;
                dr[_SpecialDate] = planDutyDetailList[i].Date;
                dr[_SpecialHeader] = planDutyDetailList[i].PlanDutyClass.DutyClassName;
                dr[_SpecialDescription] = planDutyDetailList[i].PlanDutyClass.DutyClassName;
                if (planDutyDetailList[i].PlanDutyClass.DutyClassID == -1)
                {
                    dr[_SpecialForeColor] = "#000000";
                    dr[_SpecialBackColor] = "#ffeded";
                    dr[_SpecialIsWork] = 0;
                }
                else
                {
                    dr[_SpecialForeColor] = "#407f9f";
                    dr[_SpecialBackColor] = "#ffffff";
                    dr[_SpecialIsWork] = 1;
                }
                dt.Rows.Add(dr);
            }
            if (Calendar1.SpecialDateSource != null)
            {
                Calendar1.SpecialDateSource.Clear();
            }
            Calendar1.SpecialDateSource = dt;
        }

        public List<PlanDutyDetail> PlanDutyDetailList
        {
            get
            {
                return new List<PlanDutyDetail>();//Calendar1.SpecialDateSource;
            }
            set
            {
                GetPlanDutyDetailList(value);
            }
        }

        public delegate void DateSlection(string specialDate);
        public DateSlection _DateSlection;



        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Calendar1.SelectedDate;

            if (Calendar1.EventSource == null)
            {
                return;
            }
            //foreach (DataRow drEvent in Calendar1.EventSource.Rows)
            //{
            //    if (selectedDate.Date == (Convert.ToDateTime(drEvent[Calendar1.EventStartDateColumnName])).Date)
            //    {
            //        string specialDate =
            //            (Convert.ToDateTime(drEvent[Calendar1.EventStartDateColumnName])).ToShortDateString();
            _DateSlection(selectedDate.ToShortDateString());
            //        return;
            //    }
            //}
            //if (ShowUpdatePanel != null)
            //{
            //    ShowUpdatePanel(null, null);
            //}

        }
        public event EventHandler ShowUpdatePanel;
        public event EventHandler HideUpdatePanel;

        public delegate void ExecuteSearchEvent(DateTime currentDate);
        public ExecuteSearchEvent _ExecuteSearchEvent;
        protected void IbtnLast_Click(object sender, ImageClickEventArgs e)
        {
            _ExecuteSearchEvent(Calendar1.SelectedDate.AddMonths(-1));
            if (ShowUpdatePanel != null)
            {
                ShowUpdatePanel(null, null);
            }
        }

        protected void IBtnNext_Click(object sender, ImageClickEventArgs e)
        {
            _ExecuteSearchEvent(Calendar1.SelectedDate.AddMonths(1));
            if (ShowUpdatePanel != null)
            {
                ShowUpdatePanel(null, null);
            }
        }

        public DateTime CalendarStatusSet
        {
            set
            {
                Calendar1.VisibleDate = value;
                Calendar1.SelectedDate = value;
                lblYearMonth.Text = value.Year + "-" + value.Month;
                lblCurrentMonth.Value = value.ToString();
            }
        }

        protected void IBtnClose_Click(object sender, ImageClickEventArgs e)
        {
            if (HideUpdatePanel != null)
            {
                HideUpdatePanel(null, null);
            }
        }
    }
}