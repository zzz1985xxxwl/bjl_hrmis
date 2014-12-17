using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.PayModule.EmployeeAccountSet;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade.PayModule
{
    ///<summary>
    ///</summary>
    public class EmployeeSalaryStatisticsFacade : IEmployeeSalaryStatisticsFacade
    {
        public List<EmployeeSalaryStatistics> DepartmentStatistics(DateTime startDt, DateTime endDt, int departmentID,
            List<AccountSetPara> items, int companyID, bool isIncludeChildDeptMember, Account loginUser)
        {
            GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics();
            return
                target.DepartmentStatistics(startDt, endDt, departmentID, items, companyID, isIncludeChildDeptMember,
                                            loginUser);
        }

        public List<EmployeeSalaryStatistics> PositionStatistics(DateTime startDt, DateTime endDt, int departmentID,
            List<AccountSetPara> items, int companyID, Account loginUser)
        {
            GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics();
            return target.PositionStatistics(startDt, endDt, departmentID, items, companyID, loginUser);
        }

        public List<EmployeeSalaryAverageStatistics> AverageStatistics(DateTime startDt, DateTime endDt,
            int departmentID, AccountSetPara item, int companyID, bool isIncludeChildDeptMember, Account loginUser)
        {
            GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics();
            return
                target.AverageStatistics(startDt, endDt, departmentID, item, companyID, isIncludeChildDeptMember,
                                         loginUser);
        }

        public List<EmployeeSalaryStatistics> TimeSpanStatisticsGroupByParameter(DateTime startDt, DateTime endDt, 
            int departmentID, List<AccountSetPara> items, int companyID, Account loginUser)
        {
            GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics();
            return target.TimeSpanStatisticsGroupByParameter(startDt, endDt, departmentID, items, companyID, loginUser);
        }

        public List<EmployeeSalaryStatistics> TimeSpanStatisticsGroupByDepartment(DateTime startDt, DateTime endDt, 
            int departmentID, AccountSetPara item, int companyID, bool isIncludeChildDeptMember, Account loginUser)
        {
            GetEmployeeSalaryStatistics target = new GetEmployeeSalaryStatistics();
            return
                target.TimeSpanStatisticsGroupByDepartment(startDt, endDt, departmentID, item, companyID,
                                                           isIncludeChildDeptMember, loginUser);
        }
    }
}