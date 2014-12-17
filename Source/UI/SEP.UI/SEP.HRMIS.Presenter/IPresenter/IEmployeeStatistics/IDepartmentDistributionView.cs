using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Model;
using SEP.Model.Departments;

namespace SEP.HRMIS.Presenter
{
    public interface IDepartmentDistributionView
    {
        List<Department> DepartmentDistribution{ set;}
    }
}
