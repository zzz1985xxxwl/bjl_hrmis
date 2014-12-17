using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.HRMIS.Model.EmployeeAttendance.Attendance;
using SEP.HRMIS.Model.EmployeeAttendance.AttendanceInAndOutRecord;
using SEP.HRMIS.Model.EmployeeAttendance.PlanDutyModel;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.OverWork;
using SEP.HRMIS.Model.Request;
using SEP.IBll;
using SEP.Model.Accounts;
using SEP.Model.CalendarExt;
using SEP.Model.SpecialDates;
using SEP.Model.Utility;
using SEP.Notes.NotesCalendar;
using SEP.Presenter.CalendarExt.TurnToUIModel;
using SEP.Model;
namespace SEP.Presenter.CalendarExt
{
    public class CalendarADayList
    {
        private readonly int _AccountID;
        private readonly DateTime _Start;
        private readonly DateTime _End;
        private readonly List<string> _Types;
        private DateTime _HrmisSystemStart;
        private DateTime _HrmisSystemEnd;
        public CalendarADayList(int accountID, DateTime start, DateTime end, string typelist)
        {
            _AccountID = accountID;
            _Start = start;
            _End = end;
            _HrmisSystemStart = start;
            _HrmisSystemEnd = end;
            _Types = new List<string>(typelist.Split('|'));
        }

        #region hrmis
        private List<AttendanceInAndOutRecord> _AttendanceInAndOutRecordList = null;
        private List<AttendanceInAndOutRecord> AttendanceInAndOutRecordList
        {
            get
            {
                if (!(CompanyConfig.HasHrmisSystem && Account.IsHRAccount))
                {
                    _AttendanceInAndOutRecordList = new List<AttendanceInAndOutRecord>();
                } 
                _AttendanceInAndOutRecordList = _AttendanceInAndOutRecordList ??
                                                InstanceFactory.AttendanceInOutRecordFacade.
                                                    GetSelfAttendanceInAndOutRecordByCondition(_AccountID,
                                                                                               _HrmisSystemStart,
                                                                                               _HrmisSystemEnd);
                return _AttendanceInAndOutRecordList;
            }
        }

        private List<PlanDutyDetail> _PlanDutyDetailList = null;
        private List<PlanDutyDetail> PlanDutyDetailList
        {
            get
            {
                if (!(CompanyConfig.HasHrmisSystem && Account.IsHRAccount))
                {
                    _PlanDutyDetailList = new List<PlanDutyDetail>();
                }
                _PlanDutyDetailList = _PlanDutyDetailList ??
                        InstanceFactory.CreatePlanDutyFacade().GetPlanDutyDetailByAccount(_AccountID,
                                                                                          _HrmisSystemStart, _HrmisSystemEnd);
                return _PlanDutyDetailList;
            }
        }

        private List<AttendanceBase> _AttendanceBaseList = null;
        private List<AttendanceBase> AttendanceBaseList
        {
            get
            {
                if (!(CompanyConfig.HasHrmisSystem && Account.IsHRAccount))
                {
                    _AttendanceBaseList = new List<AttendanceBase>();
                }
                _AttendanceBaseList = _AttendanceBaseList ??
                  InstanceFactory.CreateEmployeeAttendanceFacade().GetAbsentAttendanceByAccountAndRelatedDate(_AccountID,
                                                                                    _HrmisSystemStart, _HrmisSystemEnd);
                return _AttendanceBaseList;

            }
        }

        private List<LeaveRequest> _LeaveRequestList = null;
        private List<LeaveRequest> LeaveRequestList
        {
            get
            {
                if (!(CompanyConfig.HasHrmisSystem && Account.IsHRAccount))
                {
                    _LeaveRequestList = new List<LeaveRequest>();
                }
                _LeaveRequestList = _LeaveRequestList ??
                 InstanceFactory.CreateLeaveRequestFacade().GetLeaveRequestByAccountAndRelatedDate(_AccountID,
                                                                                    _HrmisSystemStart, _HrmisSystemEnd);
                return _LeaveRequestList;

            }
        }


        private List<OverWork> _OverWorkList = null;
        private List<OverWork> OverWorkList
        {
            get
            {
                if (!(CompanyConfig.HasHrmisSystem && Account.IsHRAccount))
                {
                    _OverWorkList = new List<OverWork>();
                }
                _OverWorkList = _OverWorkList ??
                 InstanceFactory.CreateOverWorkFacade().GetOverWorkByAccountAndRelatedDate(_AccountID,
                                                                                    _HrmisSystemStart, _HrmisSystemEnd);
                return _OverWorkList;

            }
        }

        private List<OutApplication> _OutApplicationList = null;
        private List<OutApplication> OutApplicationList
        {
            get
            {
                if (!(CompanyConfig.HasHrmisSystem && Account.IsHRAccount))
                {
                    _OutApplicationList = new List<OutApplication>();
                }
                _OutApplicationList = _OutApplicationList ??
                 InstanceFactory.CreateOutApplicationFacade().GetOutApplicationByAccountAndRelatedDate(_AccountID,
                                                                                    _HrmisSystemStart, _HrmisSystemEnd);
                return _OutApplicationList;

            }
        }
        //private List<SpecialDate> _SpecialDatesList = null;
        //private List<SpecialDate> SpecialDatesList
        //{
        //    get
        //    {
        //        _SpecialDatesList = _SpecialDatesList ?? BllInstance.SpecialDateBllInstance.GetAllSpecialDate(null);
        //        return _SpecialDatesList;

        //    }
        //}

        private Employee _Employee;
        private Employee Employee
        {
            get
            {
                if (!(CompanyConfig.HasHrmisSystem && Account.IsHRAccount))
                {
                    _Employee = new Employee();
                }
                _Employee = _Employee ??
                            InstanceFactory.CreateEmployeeFacade().GetEmployeeBasicInfoByAccountID(_AccountID);
                return _Employee;

            }

        }
        #endregion
        private List<SpecialDate> _SpecialDatesList = null;
        private List<SpecialDate> SpecialDatesList
        {
            get
            {
                _SpecialDatesList = _SpecialDatesList ?? BllInstance.SpecialDateBllInstance.GetAllSpecialDate(null);
                return _SpecialDatesList;

            }
        }
        private Account _Account;
        private Account Account
        {
            get
            {
                _Account = _Account ??
                           BllInstance.AccountBllInstance.GetAccountById(_AccountID);
                return _Account;

            }

        }
        private List<WorkTask> _WorkTaskList = null;
        private List<WorkTask> WorkTaskList
        {
            get
            {
                _WorkTaskList = _WorkTaskList ??
                                BllInstance.WorkTaskBllInstance.GetMyWorkTaskByCondition("", _Start, _End, -1, true,
                                                                                         true, true, true, _AccountID);
                return _WorkTaskList;
            }

        }
        public List<CalendarADay> GetList()
        {
            List<CalendarADay> items = new List<CalendarADay>();

            #region HRMIS

            if (CompanyConfig.HasHrmisSystem && Account.IsHRAccount)
            {
                if (Employee != null && Employee.EmployeeDetails != null&& Employee.EmployeeDetails.Work != null)
                {
                    if (DateTime.Compare(Employee.EmployeeDetails.Work.ComeDate.Date, _Start.Date) > 0)
                    {
                        _HrmisSystemStart = Employee.EmployeeDetails.Work.ComeDate;
                    }
                    if (Employee.EmployeeType == EmployeeTypeEnum.DimissionEmployee
                        && Employee.EmployeeDetails.Work.DimissionInfo != null
                        && DateTime.Compare(Employee.EmployeeDetails.Work.DimissionInfo.DimissionDate.Date, _End.Date) < 0)
                    {
                        _HrmisSystemEnd = Employee.EmployeeDetails.Work.DimissionInfo.DimissionDate;
                        _HrmisSystemEnd = _HrmisSystemEnd.AddDays(1).AddSeconds(-1);
                    }
                }
                if (_HrmisSystemStart <= _HrmisSystemEnd)
                {
                    GetHrmisInfo(items);
                }
            }

            #endregion

            GetSEPInfo(items);
            return items;
        }
        private void GetSEPInfo(List<CalendarADay> items)
        {
            if (_Types.Contains(CalendarShowType.Note.ID.ToString()))
            {
                items.AddRange((new NotesCalendarList()).GetByDate(_Start, _End, _AccountID));
            }
            if (_Types.Contains(CalendarShowType.WorkTask.ID.ToString()))
            {
                WorkTasksToCalendarADays.Turn(WorkTaskList, items, PlanDutyDetailList, _AccountID, _Start, _End);
            }
        }

        private void GetHrmisInfo(List<CalendarADay> items)
        {
            foreach (string type in _Types)
            {
                if (type.Equals(CalendarShowType.Attendance.ID.ToString()))
                {
                    AttendanceInAndOutRecordsToCalendarADays.Turn(AttendanceInAndOutRecordList, items,
                                                                  PlanDutyDetailList, _HrmisSystemStart,
                                                                  _HrmisSystemEnd);
                }
                if (type.Equals(CalendarShowType.DutyClass.ID.ToString()))
                {
                    PlanDutyDetailsToCalendarADays.Turn(PlanDutyDetailList, items);
                }
                if (type.Equals(CalendarShowType.Absent.ID.ToString()))
                {
                    AttendanceBasesToCalendarADays.Turn(AttendanceBaseList, items, PlanDutyDetailList,
                                                        OutApplicationList,
                                                        LeaveRequestList, AttendanceInAndOutRecordList);
                }
                if (type.Equals(CalendarShowType.Leave.ID.ToString()))
                {
                    LeaveRequestsToCalendarADays.Turn(LeaveRequestList, PlanDutyDetailList, SpecialDatesList,
                                                      items);
                }
                if (type.Equals(CalendarShowType.Out.ID.ToString()))
                {
                    OutApplicationsToCalendarADays.Turn(OutApplicationList, PlanDutyDetailList, SpecialDatesList,
                                                        items);
                }
                if (type.Equals(CalendarShowType.OverWork.ID.ToString()))
                {
                    OverWorksToCalendarADays.Turn(OverWorkList, PlanDutyDetailList, SpecialDatesList, items);
                }
            }
        }
    }
}
