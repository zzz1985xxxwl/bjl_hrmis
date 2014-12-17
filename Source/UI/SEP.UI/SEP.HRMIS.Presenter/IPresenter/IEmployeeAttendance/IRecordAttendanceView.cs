using System;
using System.Collections.Generic;
using System.Text;
using SEP.Presenter.Core;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeAttendance
{
    public interface IRecordAttendanceView
    {
        string Message { set; get;}

        string EmployeeName { get; set;}
        string EmployeeNameMessage { get; set;}
        string TheDay { get; set;}
        string TheDayMessage { get; set;}
        string InfluenceTime { get; set;}
        string InfluenceTimeMessage { get; set;}
        bool MinutesVisable { get; set;}

        List<string> AttendanceTypes { get; set;}
        string SelectedType { get; set;}
        string AttendanceTypeMessage { get; set;}

        string OperationType { get; set;}

        bool IsAddSuccess { get; set;}
        event DelegateNoParameter ActionButtonEvent;
        event DelegateNoParameter OnSelectTypeChange;
        event DelegateNoParameter CancelButtonEvent;
    }
}
