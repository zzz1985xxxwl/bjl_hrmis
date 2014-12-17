using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public interface IOtherStatisticsDataView
    {
        EmployeeOtherStatistics EmployeeResidencePermitStatistics { get; set;}

        EmployeeOtherStatistics EmployeeVacationStatistics { get; set;}

        EmployeeComeAndLeave EmployeeComeAndLeave { get; set;}

        bool IsEdit { set; }
    }
}