using System.Collections.Generic;
using System.Linq;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Logic
{
    public class EmployeeLogic
    {
        public static List<EmployeeEntity> GetEmployeeBasicInfoByBasicConditionWithCompanyAge(string employeeName,
                                                                                              EmployeeTypeEnum
                                                                                                  employeeType,
                                                                                              int positionID,
                                                                                              int? gradesID,
                                                                                              int departmentID,
                                                                                              int? CompanyAgeFrom,
                                                                                              int? CompanyAgeTo,
                                                                                              bool recursionDepartment,
                                                                                              int employeeStatus)
        {
            List<int> departmentids = DepartmentLogic.GetDepartmentids(departmentID, recursionDepartment);
            return EmployeeDA.GetEmployeeBasicInfoByBasicConditionWithCompanyAge(employeeName, (int)employeeType,
                                                                                 positionID, gradesID, CompanyAgeFrom,
                                                                                 CompanyAgeTo, departmentids,
                                                                                 employeeStatus);
        }




        public static List<EmployeeEntity> GetEmployeeBasicInfoByBasicCondition(string employeeName,
                                                                                         EmployeeTypeEnum employeeType,
                                                                                         int positionID,
                                                                                         int? gradesID,
                                                                                         int departmentID,
                                                                                         bool recursionDepartment,
                                                                                         int? powerID, int? accountID,
                                                                                         int employeeStatus, List<int> notInEmployeeType)
        {
            return EmployeeDA.GetEmployeeBasicInfoByBasicCondition(employeeName, (int)employeeType,
                                                                                positionID, gradesID,
                                                                                DepartmentLogic.GetDepartmentids(departmentID, recursionDepartment),
                                                                                powerID == null ? null : AccountAuthDA.GetAccountAuthDepartment(accountID.Value, powerID.Value),
                                                                                employeeStatus, notInEmployeeType);
        }
    }
}