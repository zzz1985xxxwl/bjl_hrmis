using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface ILeaveRateLineChartView
    {
        List<EmployeeComeAndLeave> EmployeeComeAndLeaveList { get; set;}

    }
}
