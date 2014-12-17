using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IComeAndLeaveBarChartView
    {
        List<EmployeeComeAndLeave> EmployeeComeAndLeaveList { get; set;}

    }
}
