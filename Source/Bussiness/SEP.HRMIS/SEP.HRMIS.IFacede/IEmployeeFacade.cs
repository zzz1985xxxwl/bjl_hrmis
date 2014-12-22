using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// Ա��ҵ��
    /// </summary>
    public interface IEmployeeFacade
    {
        /// <summary>
        /// ��ʼ��Ա����Ϣ
        /// </summary>
        /// <param name="newEmployeeAccountID"></param>
        /// <param name="operatoraccount"></param>
        void InitEmployeeProxy(int newEmployeeAccountID, Account operatoraccount);
        /// <summary>
        /// ����Ա��
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="operatoraccount"></param>
        void AddEmployeeProxy(Employee employee, Account operatoraccount);
        /// <summary>
        /// �޸�Ա��
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="operatoraccount"></param>
        void UpdateEmployeeProxy(Employee employee, Account operatoraccount);
        /// <summary>
        /// ����Ա���ʺ�ID���Ա��������Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Employee GetEmployeeByAccountID(int accountID);
        /// <summary>
        /// ����Ա���ʺ�ID���Ա��������Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Employee GetEmployeeBasicInfoByAccountID(int accountID);
        /// <summary>
        /// ����Ա���ʺ�ID��ȡ����Ա��������Ϣ��Ա��������Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Employee GetEmployeeSkillInfoByAccountID(int accountID);
        /// <summary>
        /// ����Ա���ʺ�ID���Ա��������Ϣ�����ڹ������飬�Ž�����
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        Employee GetEmployeeAttendenceInfoByAccountID(int accountID);
        /// <summary>
        /// �����������Ա��������Ϣ
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
        /// �����������Ա��������Ϣ
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
        /// �����������Ա��������Ϣ�����Ƴ�employeeType��Ա��
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
        /// ����������ȡԱ��������Ϣ������������Ա�����ַ�ɸѡ
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
        /// ����������ȡԱ��������Ϣ������������Ա�����ַ�ɸѡ
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
        /// ����Ա��������ϢWord
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        string ExportEmployeeInfo(int accountID, string location);

        /// <summary>
        /// </summary>
        byte[] GetEmployeePhotoByAccountID(int accountID);

        /// <summary>
        /// ����˾���Ա����ѯ
        /// </summary>
        List<Employee> GetEmployeeBasicInfoByBasicConditionWithCompanyAge(string employeeName,
                                                                          EmployeeTypeEnum employeeType, int positionID,int? gradesID,
                                                                          int departmentID, int? CompanyAgeFrom,
                                                                          int? CompanyAgeTo,
                                                                          bool recursionDepartment,int employeeStatus);

        ///<summary>
        /// ����������ȡԱ��������Ϣ������������Ա�����ַ�����˾����ɸѡ
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
        /// �����������Ա��������Ϣ�б�
        /// </summary>
        /// <returns></returns>
        List<Employee> GetEmployeeBasicInfoByBasicCondition(string employeeName,
                                                            EmployeeTypeEnum employeeType, int positionID,
                                                            int departmentID,
                                                            bool recursionDepartment, int employeestatus, int companyID);

    }
}
