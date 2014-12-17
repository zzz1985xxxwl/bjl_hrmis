using System;
using System.Collections.Generic;
using System.Text;

namespace SEP.HRMIS.Presenter.IPresenter.IEmployeeAttendance
{
    public interface IEmployeeAttendanceView
    {
        bool ShowTheRecordView { get; set;}
        IAttendaceSearchView theSearchView { get; set;}
        IRecordAttendanceView theRecordView { get; set;}
    }
}
