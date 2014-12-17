using System;

namespace SEP.HRMIS.Model.EmployeeAttendance.AttendanceStatistics
{
    public interface ICalendarNeedInfo
    {
        Employee EmployeeForCalendar { get; set;}
        string TypeName { get; set;}
        decimal Days { get; }
        decimal Hours { get; }
        decimal Minutes { get; set;}
        string Reason { get; set;}
        CalendarType CalendarType { get; set;}
        DateTime FromDate { get; set;}
        DateTime ToDate { get; set;}
    }
}
