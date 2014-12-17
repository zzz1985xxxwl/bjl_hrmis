using System;
using System.Collections.Generic;
using SEP.Model.Departments;

namespace SEP.HRMIS.Presenter
{
    public interface IStatisticsConditionView
    {
        string StatisticsTime { get; set; }

        int DepartmentID { get;}

        List<Department> DepartmentList { set;}

        string StatisticsTimeMsg { get; set; }

        bool IsStatisticsTime { set; }

        event EventHandler StatisticsButtonEvent;
        bool btnExportVisible { set;}
    }
}
