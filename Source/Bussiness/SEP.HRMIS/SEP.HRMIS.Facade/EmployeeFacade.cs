using System.Collections.Generic;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Model;
using SEP.HRMIS.IFacede;
using SEP.Model.Accounts;
using SEP.HRMIS.Bll.DiyProcesses;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// IEmployeeFacade实现类
    /// </summary>
    public class EmployeeFacade : IEmployeeFacade
    {
        public void InitEmployeeProxy(int newEmployeeAccountID, Account operatoraccount)
        {
            new InitEmployeeProxy(newEmployeeAccountID, operatoraccount).Excute();
        }
        public void AddEmployeeProxy(Employee employee, Account operatoraccount)
        {
            new AddEmployeeProxy(employee, operatoraccount).Excute();
        }

        public void UpdateEmployeeProxy(Employee employee, Account operatoraccount)
        {
            new UpdateEmployeeProxy(employee, operatoraccount).Excute();
        }

        public Employee GetEmployeeByAccountID(int accountID)
        {
            Employee employee = new GetEmployee().GetEmployeeByAccountID(accountID);
            if (employee != null)
            {
                employee.DiyProcessList = new GetDiyProcess().GetEmployeeDiyProcesses(accountID);
            }
            return employee;
        }

        public Employee GetEmployeeBasicInfoByAccountID(int accountID)
        {
            return new GetEmployee().GetEmployeeBasicInfoByAccountID(accountID);
        }
        public Employee GetEmployeeSkillInfoByAccountID(int accountID)
        {
            return new GetEmployee().GetEmployeeSkillInfoByAccountID(accountID);
        }
        public Employee GetEmployeeAttendenceInfoByAccountID(int accountID)
        {
            return new GetEmployee().GetEmployeeAttendenceInfoByAccountID(accountID);
        }

        public List<Employee> GetEmployeeBasicInfoByBasicCondition(string name, EmployeeTypeEnum employeeType, int positionID,
                                                          int departmentID, bool recursionDepartment, int employeestatus)
        {
            return new GetEmployee().GetEmployeeBasicInfoByBasicCondition(name, employeeType, positionID,
                                                           departmentID, recursionDepartment, employeestatus);
        }

        public List<Employee> GetEmployeeByBasicCondition(string name, EmployeeTypeEnum employeeType, int positionID,
                                                          int departmentID, bool recursionDepartment)
        {
            return new GetEmployee().GetEmployeeByBasicCondition(name, employeeType, positionID,
                                                           departmentID, recursionDepartment);
        }

        public List<Employee> GetEmployeeBasicInfoByBasicConditionExceptEmployeeType(string name, EmployeeTypeEnum employeeType,
                                                                            int positionID, int departmentID,
                                                                            bool recursionDepartment)
        {
            return new GetEmployee().GetEmployeeBasicInfoByBasicConditionExceptEmployeeType(name, employeeType,
                                                                                   positionID, departmentID,
                                                                                   recursionDepartment);
        }

        public List<Employee> GetEmployeeBasicInfoByBasicConditionAndFirstLetter(string name, EmployeeTypeEnum employeetype,
                                                                          int positionID, int departmentId, bool recursionDepartment,
                                                                          string firstLetter)
        {
            return new GetEmployee().GetEmployeeBasicInfoByBasicConditionAndFirstLetter(name, employeetype,
                                                                                 positionID, departmentId, recursionDepartment,
                                                                                 firstLetter);
        }

        public List<Employee> GetEmployeeByBasicConditionAndFirstLetter(string name, EmployeeTypeEnum employeetype,
                                                                        int positionID, int departmentId, bool recursionDepartment,
                                                                        string firstLetter)
        {
            return new GetEmployee().GetEmployeeByBasicConditionAndFirstLetter(name, employeetype,
                                                                               positionID, departmentId, recursionDepartment,
                                                                               firstLetter);
        }

        public string ExportEmployeeInfo(int accountID, string location)
        {
            return new ExportEmployeeInfo(accountID, location).ExcuteSelf();
        }

        public byte[] GetEmployeePhotoByAccountID(int accountID)
        {
            return new GetEmployee().GetEmployeePhotoByAccountID(accountID);
        }

        public List<Employee> GetEmployeeBasicInfoByBasicConditionWithCompanyAge(string employeeName, EmployeeTypeEnum employeeType, int positionID, int? gradesID, int departmentID, int? CompanyAgeFrom, int? CompanyAgeTo, bool recursionDepartment, int employeeStatus)
        {
            return new GetEmployee().GetEmployeeBasicInfoByBasicConditionWithCompanyAge(employeeName, employeeType, positionID,gradesID,departmentID, CompanyAgeFrom, CompanyAgeTo,
                                                      recursionDepartment, employeeStatus);
        }

        public List<Employee> GetEmployeeByBasicConditionWithFirstLetterAndCompanyAge(string employeeName, EmployeeTypeEnum employeeType, int positionId, int departmentId, bool recursionDepartment, string firstLetter, int? CompanyAgeFrom, int? CompanyAgeTo, int employeeStatus)
        {
            return new GetEmployee().GetEmployeeByBasicConditionWithFirstLetterAndCompanyAge(employeeName, employeeType, positionId, departmentId, recursionDepartment, firstLetter, CompanyAgeFrom, CompanyAgeTo,employeeStatus);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployeeBasicInfoWithOutLoadAccount()
        {
            return new GetEmployee().GetAllEmployeeBasicInfoWithOutLoadAccount();
        }
        /// <summary>
        /// 根据条件获得员工基本信息列表
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployeeBasicInfoByBasicCondition(string employeeName,
                                                          EmployeeTypeEnum employeeType, int positionID,
                                                          int departmentID,
                                                          bool recursionDepartment, int employeestatus, int companyID)
        {
            return new GetEmployee().GetEmployeeBasicInfoByBasicCondition(employeeName,
                                                                          employeeType, positionID,
                                                                          departmentID,
                                                                          recursionDepartment, employeestatus, companyID);
        }
    }
}
