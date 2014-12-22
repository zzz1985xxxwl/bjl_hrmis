using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 员工业务
    /// </summary>
    public interface IEmployeeFacade
    {
        /// <summary>
        /// 初始化员工信息
        /// </summary>
        /// <param name="newEmployeeAccountID"></param>
        /// <param name="operatoraccount"></param>
        void InitEmployeeProxy(int newEmployeeAccountID, Account operatoraccount);
        /// <summary>
        /// 新增员工
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="operatoraccount"></param>
        void AddEmployeeProxy(Employee employee, Account operatoraccount);
        /// <summary>
        /// 修改员工
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="operatoraccount"></param>
        void UpdateEmployeeProxy(Employee employee, Account operatoraccount);
        /// <summary>
        /// 根据员工帐号ID获得员工所有信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Employee GetEmployeeByAccountID(int accountID);
        /// <summary>
        /// 根据员工帐号ID获得员工基本信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Employee GetEmployeeBasicInfoByAccountID(int accountID);
        /// <summary>
        /// 根据员工帐号ID获取所有员工基本信息和员工技能信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Employee GetEmployeeSkillInfoByAccountID(int accountID);
        /// <summary>
        /// 根据员工帐号ID获得员工考勤信息，考勤规则详情，门禁卡号
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Employee GetEmployeeAttendenceInfoByAccountID(int accountID);
        /// <summary>
        /// 根据条件获得员工基本信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="employeeType"></param>
        /// <param name="positionID"></param>
        /// <param name="departmentID"></param>
        /// <param name="recursionDepartment"></param>
        /// <returns></returns>
        /// <param name="employeestatus"></param>
        List<Employee> GetEmployeeBasicInfoByBasicCondition(string name, EmployeeTypeEnum employeeType, int positionID,
                                                   int departmentID, bool recursionDepartment, int employeestatus);
        /// <summary>
        /// 根据条件获得员工所有信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="employeeType"></param>
        /// <param name="positionID"></param>
        /// <param name="departmentID"></param>
        /// <param name="recursionDepartment"></param>
        /// <returns></returns>
        List<Employee> GetEmployeeByBasicCondition(string name, EmployeeTypeEnum employeeType, int positionID,
                                                   int departmentID, bool recursionDepartment);
        /// <summary>
        /// 根据条件获得员工基本信息，并移除employeeType的员工
        /// </summary>
        /// <param name="name"></param>
        /// <param name="employeeType"></param>
        /// <param name="positionID"></param>
        /// <param name="departmentID"></param>
        /// <param name="recursionDepartment"></param>
        /// <returns></returns>
        List<Employee> GetEmployeeBasicInfoByBasicConditionExceptEmployeeType
            (string name, EmployeeTypeEnum employeeType, int positionID,
                                                   int departmentID, bool recursionDepartment);

        /// <summary>
        /// 根据条件获取员工基本信息，条件包括：员工首字符筛选
        /// </summary>
        /// <param name="name"></param>
        /// <param name="employeetype"></param>
        /// <param name="positionID"></param>
        /// <param name="departmentId"></param>
        /// <param name="firstLetter"></param>
        /// <returns></returns>
        List<Employee> GetEmployeeBasicInfoByBasicConditionAndFirstLetter
            (string name, EmployeeTypeEnum employeetype, int positionID, int departmentId, bool recursionDepartment, string firstLetter);
        /// <summary>
        /// 根据条件获取员工所有信息，条件包括：员工首字符筛选
        /// </summary>
        /// <param name="name"></param>
        /// <param name="employeetype"></param>
        /// <param name="positionID"></param>
        /// <param name="departmentId"></param>
        /// <param name="firstLetter"></param>
        /// <returns></returns>
        List<Employee> GetEmployeeByBasicConditionAndFirstLetter
            (string name, EmployeeTypeEnum employeetype, int positionID, int departmentId, bool recursionDepartment, string firstLetter);
        /// <summary>
        /// 导出员工基本信息Word
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        string ExportEmployeeInfo(int accountID, string location);

        /// <summary>
        /// </summary>
        byte[] GetEmployeePhotoByAccountID(int accountID);

        /// <summary>
        /// 带有司龄的员工查询
        /// </summary>
        List<Employee> GetEmployeeBasicInfoByBasicConditionWithCompanyAge(string employeeName,
                                                                          EmployeeTypeEnum employeeType, int positionID,int? gradesID,
                                                                          int departmentID, int? CompanyAgeFrom,
                                                                          int? CompanyAgeTo,
                                                                          bool recursionDepartment,int employeeStatus);

        ///<summary>
        /// 根据条件获取员工所有信息，条件包括：员工首字符及公司工龄筛选
        ///</summary>
        ///<param name="employeeName"></param>
        ///<param name="employeeType"></param>
        ///<param name="positionId"></param>
        ///<param name="departmentId"></param>
        ///<param name="recursionDepartment"></param>
        ///<param name="firstLetter"></param>
        ///<param name="CompanyAgeFrom"></param>
        ///<param name="CompanyAgeTo"></param>
        ///<param name="employeeStatus"></param>
        ///<returns></returns>
        List<Employee> GetEmployeeByBasicConditionWithFirstLetterAndCompanyAge(string employeeName,
                                                                               EmployeeTypeEnum employeeType,
                                                                               int positionId, int departmentId,
                                                                               bool recursionDepartment,
                                                                               string firstLetter, int? CompanyAgeFrom,
                                                                               int? CompanyAgeTo,int employeeStatus);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Employee> GetAllEmployeeBasicInfoWithOutLoadAccount();

        /// <summary>
        /// 根据条件获得员工基本信息列表
        /// </summary>
        /// <returns></returns>
        List<Employee> GetEmployeeBasicInfoByBasicCondition(string employeeName,
                                                            EmployeeTypeEnum employeeType, int positionID,
                                                            int departmentID,
                                                            bool recursionDepartment, int employeestatus, int companyID);

    }
}
