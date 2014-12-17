//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ShowCalendarDetail.cs
// 创建者: 王玥琦
// 创建日期: 2008-08-28
// 概述: 查看考勤详情
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.Presenter;
using SEP.Presenter.IPresenter.ICalendar;
using ShiXin.Security;

namespace SEP.Performance.Views.SEP.Calendar
{
    public partial class ShowCalendarDetail : UserControl, IShowCalendarDetail
    {
        private List<LeaveRequest> _LeaveRequestList;
        private List<OutApplication> _OutApplicationList;
        private List<OverWork> _OverWorkList;
        private List<AttendanceBase> _AttendanceBaseList;
        private List<string> _RemindList;
        private List<string> _CalendarEventList;

        private readonly string _LeaveRequestActiveImage = "../../../Pages/image/LeaveRequestActive.jpg";
        private readonly string _LeaveRequestNotActiveImage = "../../../Pages/image/LeaveRequestNotActive.jpg";
        private readonly string _OverTimeActiveImage = "../../../Pages/image/OverTimeActive.jpg";
        private readonly string _OverTimeNotActiveImage = "../../../Pages/image/OverTimeNotActive.jpg";
        private readonly string _OutWorkActiveImage = "../../../Pages/image/OutWorkActive.jpg";
        private readonly string _OutWorkNotActiveImage = "../../../Pages/image/OutWorkNotActive.jpg";
        private readonly string _AbsenterActiveImage = "../../../Pages/image/AbsenterActive.jpg";
        private readonly string _AbsenterNotActiveImage = "../../../Pages/image/AbsenterNotActive.jpg";
        private readonly string _EarlyActiveImage = "../../../Pages/image/EarlyActive.jpg";
        private readonly string _EarlyNotActiveImage = "../../../Pages/image/EarlyNotActive.jpg";
        private readonly string _LateActiveImage = "../../../Pages/image/LateActive.jpg";
        private readonly string _LateNotActiveImage = "../../../Pages/image/LateNotActive.jpg";


        private readonly string _RemindActiveImage = "../../../Pages/image/RemindActive.jpg";
        private readonly string _RemindNotActiveImage = "../../../Pages/image/RemindNotActive.jpg";
        private readonly string _CalendarEventActiveImage = "../../../Pages/image/CalendarEventActive.jpg";
        private readonly string _CalendarEventNotActiveImage = "../../../Pages/image/CalendarEventNotActive.jpg";


        private readonly string _AttendanceActiveImage = "../../../Pages/image/AttendanceActive.jpg";
        private readonly string _AttendanceNotActiveImage = "../../../Pages/image/AttendanceNotActive.jpg";

        private bool isLeaveRequest = false;
        private bool isOutWork = false;
        private bool isOverTime = false;
        private bool isEarly = false;
        private bool isLate = false;
        private bool isAbsent = false;
        private bool isRemind = false;
        private bool isCalendarEvent = false;

        #region IShowCalendarDetail

        public string EmployeeInfo
        {
            get { return lblEmployeeID.Value; }
            set
            {
                lblEmployeeID.Value = value;
            }
        }

        public string Date
        {
            get { return selectdate.Value; }
            set { selectdate.Value = value; }
        }

        public string ResultMessage
        {
            get { return lblResultMessage.Text; }
            set { lblResultMessage.Text = value; }
        }

        public bool IsShowInOut
        {
            set { btnViewInOut.Visible = value; }
        }
        public bool IsShowSendEmail
        {
            set { btnSendEmail.Visible = value; }
        }
        
        public bool IsShowRemind
        {
            set { btnViewRemind.Visible = value; }
        }

        public bool IsShowCalendar
        {
            set { btnViewCalendar.Visible = value; }
        }

        public List<LeaveRequest> LeaveRequestList
        {
            get { return _LeaveRequestList; }
            set
            {
                _LeaveRequestList = value;
                for (int i = 0; i < _LeaveRequestList.Count; i++)
                {
                    string employee = "员工：" + EmployeeInfo.Split(';')[1];
                    string type = "请假类型：" + _LeaveRequestList[i].LeaveRequestType.Name;
                    string date = string.Format("请假时段：{0}--{1}",
                                                _LeaveRequestList[i].FromDate, _LeaveRequestList[i].ToDate);
                    string time = "请假时间（小时）：" + _LeaveRequestList[i].CostTime;
                    string reason = "请假理由：" + _LeaveRequestList[i].Reason;
                    string location = "";
                    AddNewMenuItem(ShowDetailViewLeaveRequest, employee, type, date, time, reason, location);
                }
                isLeaveRequest = _LeaveRequestList.Count > 0;
            }
        }

        public List<OutApplication> OutApplicationDetailList
        {
            get { return _OutApplicationList; }
            set
            {
                _OutApplicationList = value;
                for (int i = 0; i < _OutApplicationList.Count; i++)
                {
                    string employee = "员工：" + EmployeeInfo.Split(';')[1];

                    string type = "申请类型：" + "外出";
                    string date = string.Format("外出时段：{0}--{1}",
                                                _OutApplicationList[i].FromDate, _OutApplicationList[i].ToDate);
                    string time = "外出时间（小时）：" + _OutApplicationList[i].CostTime;
                    string reason = "外出理由：" + _OutApplicationList[i].Reason;
                    string location = "外出地点：" + _OutApplicationList[i].OutLocation;
                    AddNewMenuItem(ShowDetailViewOutApplication, employee, type, date, time, reason, location);
                }
                isOutWork = _OutApplicationList.Count > 0;
            }
        }

        public List<OverWork> OverWorkDetailList
        {
            get { return _OverWorkList; }
            set
            {
                _OverWorkList = value;
                for (int i = 0; i < _OverWorkList.Count; i++)
                {
                    string employee = "员工：" + EmployeeInfo.Split(';')[1];

                    string type = "申请类型：" + "加班";
                    string date = string.Format("加班时段：{0}--{1}",
                                                _OverWorkList[i].FromDate, _OverWorkList[i].ToDate);
                    string time = "加班时间（小时）：" + _OverWorkList[i].CostTime;
                    string reason = "加班理由：" + _OverWorkList[i].Reason;
                    string location = "";
                    AddNewMenuItem(ShowDetailViewOverWork, employee, type, date, time, reason, location);
                }
                isOverTime = _OverWorkList.Count > 0;
            }
        }

        public List<AttendanceBase> AttendanceBaseList
        {
            get { return _AttendanceBaseList; }
            set
            {
                _AttendanceBaseList = value;
                for (int i = 0; i < _AttendanceBaseList.Count; i++)
                {
                    string employee;
                    string type;
                    string date;
                    string time;
                    string reason;
                    string location;
                    employee = "员工：" + EmployeeInfo.Split(';')[1];
                    location = "";
                    reason = "";
                    if (_AttendanceBaseList[i] is EarlyLeaveAttendance)
                    {
                        type = "考勤类型：早退";
                        date = string.Format("早退日期：{0}", _AttendanceBaseList[i].TheDay.ToShortDateString());
                        time = "早退时间（分）：" + ((EarlyLeaveAttendance) _AttendanceBaseList[i]).EarlyLeaveMinutes;
                        AddNewMenuItem(ShowDetailViewEarlyLeave, employee, type, date, time, reason, location);
                        isEarly = true;
                    }
                    else if (_AttendanceBaseList[i] is LaterAttendance)
                    {
                        type = "考勤类型：迟到";
                        date = string.Format("迟到日期：{0}", _AttendanceBaseList[i].TheDay.ToShortDateString());
                        time = "迟到时间（分）：" + ((LaterAttendance) _AttendanceBaseList[i]).LaterMinutes;
                        AddNewMenuItem(ShowDetailViewLate, employee, type, date, time, reason, location);
                        isLate = true;
                    }
                    else
                    {
                        type = "考勤类型：旷工";
                        date = string.Format("旷工日期：{0}", _AttendanceBaseList[i].TheDay.ToShortDateString());
                        time = "旷工时间（天）：" + _AttendanceBaseList[i].Days;
                        AddNewMenuItem(ShowDetailViewAbsent, employee, type, date, time, reason, location);
                        isAbsent = true;
                    }
                }
            }
        }

        public List<AttendanceInAndOutRecord> AttendanceInAndOutRecordList
        {
            set
            {
                ShowDetailViewAttendance.AttendanceInAndOutRecordList = value;
            }
        }

        public List<string> RemindList
        {
            get { return _RemindList; }
            set
            {
                _RemindList = value;
                for (int i = 0; i < _RemindList.Count; i++)
                {
                    ShowDetailViewRemind.Detail = _RemindList[i];
                }
                isRemind = _RemindList.Count > 0;
            }
        }

        public List<string> CalendarEventList
        {
            get { return _CalendarEventList; }
            set
            {
                _CalendarEventList = value;
                for (int i = 0; i < _CalendarEventList.Count; i++)
                {
                    ShowDetailViewCalendarEvent.Detail = _CalendarEventList[i];
                }
                isCalendarEvent = _CalendarEventList.Count > 0;
            }
        }

        public void SetNull()
        {
            ShowDetailViewLeaveRequest.Detail = "";
            ShowDetailViewOutApplication.Detail = "";
            ShowDetailViewOverWork.Detail = "";
            ShowDetailViewLate.Detail = "";
            ShowDetailViewEarlyLeave.Detail = "";
            ShowDetailViewAbsent.Detail = "";
            ShowDetailViewRemind.Detail = "";
            ShowDetailViewCalendarEvent.Detail = "";
        }

        public event DelegateID RedirectToRemind;
        public event DelegateID RedirectToCalendar;
        public event DelegateNoParameter BtnSendEmailEvent;
        protected void btnSendEmail_Click(object sender, CommandEventArgs e)
        {
            BtnSendEmailEvent();
        }

        #endregion

        private static void AddNewMenuItem(IShowDetailView showDetailView,
                                           string employee, string type,
                                           string date, string time, string reason, string location)
        {
            showDetailView.Detail = employee + " " + type + " " + date + " " + time + " " + reason + " " + location;
        }

        public void RefreshShow()
        {
            InitImage();
            SetIBVisible(false);
            SetTabVisible(false);
            IBAttendance.Visible = true;
            IBAttendance.ImageUrl = _AttendanceActiveImage;
            TabAttendance.Visible = true;
            IBLate.Visible = isLate;
            IBEarlyLeave.Visible = isEarly;
            IBAbsent.Visible = isAbsent;
            IBOutApplication.Visible = isOutWork;
            IBOverWork.Visible = isOverTime;
            IBLeaveRequest.Visible = isLeaveRequest;
            IBRemind.Visible = isRemind;
            IBCalendarEvent.Visible = isCalendarEvent;
            //int currentIndex = isLeaveRequest
            //                       ? 0
            //                       :
            //                           isOutWork
            //                               ? 1
            //                               :
            //                                   isOverTime
            //                                       ? 2
            //                                       :
            //                                           isLate
            //                                               ? 3
            //                                               :
            //                                                   isEarly
            //                                                       ? 4
            //                                                       :
            //                                                           isAbsent
            //                                                               ? 5
            //                                                               :
            //                                                                   isRemind
            //                                                                       ? 6
            //                                                                       :
            //                                                                           isCalendarEvent ? 7 : -1;

            //switch (currentIndex)
            //{
            //    case 0:
            //        IBLeaveRequest.ImageUrl = _LeaveRequestActiveImage;
            //        TabLeaveRequest.Visible = true;
            //        break;
            //    case 1:
            //        IBOutApplication.ImageUrl = _OutWorkActiveImage;
            //        TabOutApplication.Visible = true;
            //        break;
            //    case 2:
            //        IBOverWork.ImageUrl = _OverTimeActiveImage;
            //        TabOverWork.Visible = true;
            //        break;
            //    case 3:
            //        IBLate.ImageUrl = _LateActiveImage;
            //        TabLate.Visible = true;
            //        break;
            //    case 4:
            //        IBEarlyLeave.ImageUrl = _EarlyActiveImage;
            //        TabEarlyLeave.Visible = true;
            //        break;
            //    case 5:
            //        IBAbsent.ImageUrl = _AbsenterActiveImage;
            //        TabAbsent.Visible = true;
            //        break;
            //    case 6:
            //        IBRemind.ImageUrl = _RemindActiveImage;
            //        TabRemind.Visible = true;
            //        break;
            //    case 7:
            //        IBCalendarEvent.ImageUrl = _CalendarEventActiveImage;
            //        TabCalendarEvent.Visible = true;
            //        break;
            //    default:
            //        break;
            //}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ImageButton1.Attributes["onclick"] = "return CloseModalPopupExtender('divMPEShowCalendarDetail');";
            ShowDetailViewAttendance.ShowPanel += ShowPanel;

        }

        private void InitImage()
        {
            IBLeaveRequest.ImageUrl = _LeaveRequestNotActiveImage;
            IBOverWork.ImageUrl = _OverTimeNotActiveImage;
            IBOutApplication.ImageUrl = _OutWorkNotActiveImage;
            IBAbsent.ImageUrl = _AbsenterNotActiveImage;
            IBEarlyLeave.ImageUrl = _EarlyNotActiveImage;
            IBLate.ImageUrl = _LateNotActiveImage;
            IBRemind.ImageUrl = _RemindNotActiveImage;
            IBCalendarEvent.ImageUrl = _CalendarEventNotActiveImage;
            IBAttendance.ImageUrl = _AttendanceNotActiveImage;
        }

        private void SetIBVisible(bool isVisible)
        {
            IBLeaveRequest.Visible = isVisible;
            IBOverWork.Visible = isVisible;
            IBOutApplication.Visible = isVisible;
            IBAbsent.Visible = isVisible;
            IBEarlyLeave.Visible = isVisible;
            IBLate.Visible = isVisible;
            IBRemind.Visible = isVisible;
            IBCalendarEvent.Visible = isVisible;
        }

        private void SetTabVisible(bool isVisible)
        {
            TabLeaveRequest.Visible = isVisible;
            TabOutApplication.Visible = isVisible;
            TabOverWork.Visible = isVisible;
            TabLate.Visible = isVisible;
            TabEarlyLeave.Visible = isVisible;
            TabAbsent.Visible = isVisible;
            TabRemind.Visible = isVisible;
            TabCalendarEvent.Visible = isVisible;
            TabAttendance.Visible = isVisible;
        }

        public event EventHandler ShowPanel;
        //public event EventHandler InitMultiView;

        public EventHandler btnCancelClick;

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            btnCancelClick(sender, e);
        }

        protected void btnViewInOut_Click(object sender, EventArgs e)
        {
            string employeeID = EmployeeInfo.Split(';')[0];
            Response.Redirect("InAndOutDetailListView.aspx?" + ConstParameters.EmployeeId + "=" +
                              SecurityUtil.DECEncrypt(employeeID) + "&" +
                              ConstParameters.DepartmentID + "=" + SecurityUtil.DECEncrypt("-1") + "&" +
                              ConstParameters.SearchFrom + "=" + SecurityUtil.DECEncrypt(Date + " 0:00:00") + "&" +
                              ConstParameters.SearchTo + "=" + SecurityUtil.DECEncrypt(Date + " 23:59:59"));
        }

        protected void IBLeaveRequest_Click(object sender, ImageClickEventArgs e)
        {
            SetTabVisible(false);
            TabLeaveRequest.Visible = true;
            InitImage();
            IBLeaveRequest.ImageUrl = _LeaveRequestActiveImage;
            ShowPanel(sender, EventArgs.Empty);
        }

        protected void IBOverWork_Click(object sender, ImageClickEventArgs e)
        {
            SetTabVisible(false);
            TabOverWork.Visible = true;
            InitImage();
            IBOverWork.ImageUrl = _OverTimeActiveImage;
            ShowPanel(sender, EventArgs.Empty);
        }

        protected void IBOutApplication_Click(object sender, ImageClickEventArgs e)
        {
            SetTabVisible(false);
            TabOutApplication.Visible = true;
            InitImage();
            IBOutApplication.ImageUrl = _OutWorkActiveImage;
            ShowPanel(sender, EventArgs.Empty);
        }

        protected void IBAbsent_Click(object sender, ImageClickEventArgs e)
        {
            SetTabVisible(false);
            TabAbsent.Visible = true;
            InitImage();
            IBAbsent.ImageUrl = _AbsenterActiveImage;
            ShowPanel(sender, EventArgs.Empty);
        }

        protected void IBEarlyLeave_Click(object sender, ImageClickEventArgs e)
        {
            SetTabVisible(false);
            TabEarlyLeave.Visible = true;
            InitImage();
            IBEarlyLeave.ImageUrl = _EarlyActiveImage;
            ShowPanel(sender, EventArgs.Empty);
        }

        protected void IBLate_Click(object sender, ImageClickEventArgs e)
        {
            SetTabVisible(false);
            TabLate.Visible = true;
            InitImage();
            IBLate.ImageUrl = _LateActiveImage;
            ShowPanel(sender, EventArgs.Empty);
        }

        protected void IBRemind_Click(object sender, ImageClickEventArgs e)
        {
            SetTabVisible(false);
            TabRemind.Visible = true;
            InitImage();
            IBRemind.ImageUrl = _RemindActiveImage;
            ShowPanel(sender, EventArgs.Empty);
        }

        protected void IBCalendarEvent_Click(object sender, ImageClickEventArgs e)
        {
            SetTabVisible(false);
            TabCalendarEvent.Visible = true;
            InitImage();
            IBCalendarEvent.ImageUrl = _CalendarEventActiveImage;
            ShowPanel(sender, EventArgs.Empty);
        }

        protected void IBAttendance_Click(object sender, ImageClickEventArgs e)
        {
            SetTabVisible(false);
            TabAttendance.Visible = true;
            InitImage();
            IBAttendance.ImageUrl = _AttendanceActiveImage;
            ShowPanel(sender, EventArgs.Empty);
        }
        protected void btnViewRemind_Click(object sender, EventArgs e)
        {
            if (RedirectToRemind != null)
            {
                RedirectToRemind(SecurityUtil.DECEncrypt(Date));
            }
        }

        protected void btnViewCalendar_Click(object sender, EventArgs e)
        {
            if (RedirectToCalendar != null)
            {
                RedirectToCalendar(SecurityUtil.DECEncrypt(Date));
            }
        }
    }
}