using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IComeAndLeaveTableView
    {
        List<EmployeeComeAndLeave> EmployeeComeAndLeaveList{ get; set; }
    }
}
