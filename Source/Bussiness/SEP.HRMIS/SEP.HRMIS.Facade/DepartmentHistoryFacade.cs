using System;
using System.Collections.Generic;
using System.Text;
using SEP.HRMIS.Bll;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 部门历史
    /// </summary>
    public class DepartmentHistoryFacade : IDepartmentHistoryFacade
    {
        public void AddDepartmentHistory(Account operatorAccount)
        {
            AddDepartmentHistory AddDepartmentHistory = new AddDepartmentHistory(operatorAccount);
            AddDepartmentHistory.Excute();
        }

        public List<Department> GetDepartmentNoStructByDateTime(DateTime searchTime)
        {
            return new GetDepartmentHistory().GetDepartmentNoStructByDateTime(searchTime);
        }

        public List<Department> GetDepartmentListStructByDepartmentIDAndDateTime(int deparmentID, DateTime searchTime)
        {
            return new GetDepartmentHistory().GetDepartmentListStructByDepartmentIDAndDateTime(deparmentID, searchTime);
        }

        public List<Department> GetDepartmentTreeStructByDateTime(DateTime dt)
        {
            return new GetDepartmentHistory().GetDepartmentTreeStructByDateTime(dt);
        }
    }
}
