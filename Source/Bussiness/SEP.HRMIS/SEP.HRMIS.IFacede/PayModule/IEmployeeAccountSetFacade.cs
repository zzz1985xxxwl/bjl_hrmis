using System;
using System.Collections.Generic;
using System.Data;
using SEP.HRMIS.Model.PayModule;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede.PayModule
{
    ///<summary>
    ///</summary>
    public interface IEmployeeAccountSetFacade
    {
        /// <summary>
        /// 1 ΪԱ���������ף�����Լ�������
        /// 2 �����׸���ʼֵ�����ü�¼��н��ʷ�Ľ��
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="accountSet"></param>
        /// <param name="backAccountsName"></param>
        /// <param name="changeDate"></param>
        /// <param name="description"></param>
        void CreateEmployeeAccountSetFacade(int employeeID, AccountSet accountSet, string backAccountsName,
                                            DateTime changeDate, string description);

        /// <summary>
        /// ��н���޸Ĺ̶�������ü�¼��н��ʷ�Ľ��
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="accountSet"></param>
        /// <param name="backAccountsName"></param>
        /// <param name="changeDate"></param>
        /// <param name="description"></param>
        void UpdateEmployeeAccountSetFacade(int employeeID, AccountSet accountSet, string backAccountsName,
                                            DateTime changeDate, string description);

        /// <summary>
        /// ����Ա����Ż��Ա��н��
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        EmployeeSalary GetEmployeeAccountSetByEmployeeID(int employeeID);

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="dt">���Ź���ʱ��</param>
        /// <param name="backAcountsName">������</param>
        /// <param name="description">����</param>
        /// <param name="companyId">��˾</param>
        /// <param name="departmentId">����</param>
        void InitialEmployeeSalaryFacade(DateTime dt, string backAcountsName, string description, int companyId,int departmentId);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="dt">����ʱ��</param>
        /// <param name="backAcountsName">������</param>
        /// <param name="description">����</param>       
        /// <param name="companyId">��˾</param>
        /// <param name="isSendEmail"></param>
        string CloseEmployeeSalaryFacade(DateTime dt, string backAcountsName, string description, int companyId, int departmentId, bool isSendEmail);

        /// <summary>
        /// �ݴ�
        /// </summary>
        /// <param name="salaryId">н��id</param>
        /// <param name="employeeID">Ա��id</param>
        /// <param name="dt">��нʱ��</param>
        /// <param name="accountSet">Ա������</param>
        /// <param name="backAcountsName">������</param>
        /// <param name="description"></param>
        /// <param name="versionNumber"></param>
        void TemporarySaveEmployeeAccountSetFacadeFacade(int salaryId, int employeeID, DateTime dt,
                                                         AccountSet accountSet, string backAcountsName,
                                                         string description, int versionNumber);

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="dt">���ʱ��</param>
        /// <param name="backAcountsName">������</param>
        /// <param name="description">����</param>
        /// <param name="companyId">��˾</param>
        void ReopenEmployeeSalaryFacade(DateTime dt, string backAcountsName, string description, int companyId, int departmentId);

        /// <summary>
        /// ����������ѯԱ������
        /// </summary>
        /// <returns></returns>
        List<EmployeeSalary> GetEmployeeAccountSetByCondition(string employeeName, int departmentID, int positionID,
                                                              EmployeeTypeEnum EmployeeTypeEnum, bool recursionDepartment, Account loginUser, int employeeStatus);

        /// <summary>
        /// Ա�������й��ʼ�¼
        /// </summary>
        /// <param name="employeeID">Ա��id</param>
        /// <returns></returns>
        EmployeeSalary GetEmployeeSalaryByEmployeeIDFacade(int employeeID);

        /// <summary>
        /// ��ȡһ��Ա��ĳ�µĹ��ʼ�¼
        /// </summary>
        /// <param name="employeeID">Ա��id</param>
        /// <param name="dt">��ѯʱ��</param>
        /// <returns></returns>
        EmployeeSalaryHistory GetEmployeeSalaryHistoryByEmployeeIdAndDateTimeFacade(int employeeID, DateTime dt);

        /// <summary>
        /// ��ѯ�������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="salaryTime"></param>
        /// <param name="departmentId"></param>
        /// <param name="positionId"></param>
        /// <param name="accountSetId"></param>
        /// <param name="employeeType"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        List<EmployeeSalary> GetEmployeeSalaryByConditionFacade(string name, DateTime salaryTime, int departmentId,
                                                                int positionId, int accountSetId,
                                                                EmployeeTypeEnum employeeType, int companyId);

        /// <summary>
        /// ����Ա������
        /// </summary>
        /// <param name="filePath">Ҫ�����excel�ĵ�·��</param>
        /// <param name="dt">��нʱ��</param>
        /// <param name="backAcountsName">����������</param>
        /// <param name="companyId">��˾</param>
        void ImportEmployeeSalary(string filePath, DateTime dt, string backAcountsName, int companyId);
        /// <summary>
        /// ����Ա��������Ϣ
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="departmentID"></param>
        /// <param name="positionID"></param>
        /// <param name="employeeType"></param>
        /// <param name="isRecursionDepartment"></param>
        /// <param name="accountOperator"></param>
        /// <param name="employeeStatus"></param>
        DataTable ExportEmployeeAccountSetFacade(string employeeName, int departmentID, int positionID,
                                                   EmployeeTypeEnum employeeType,
                                                   bool isRecursionDepartment, Account accountOperator, int employeeStatus);
        /// <summary>
        /// ����Ա��������Ϣ
        /// </summary>
        void ImportEmployeeAccountSetFacade(string filePath, Account _operator);
        ///<summary>
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        EmployeeSalary GetAdjustSalaryHistoryByPKID(int id);

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<returns></returns>
        List<AdjustSalaryHistory> GetAdjustSalaryHistoryByEmployeeID(int employeeID);

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<returns></returns>
        EmployeeSalary GetEmployeeSalaryByEmployeeID(int employeeID);

        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        EmployeeSalaryHistory GetEmployeeSalaryHistoryByPKID(int pkid);

        ///<summary>
        ///</summary>
        ///<param name="historyid"></param>
        ///<returns></returns>
        EmployeeSalary GetEmployeeSalaryByEmployeeSalaryHistoryID(int historyid);

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="dt"></param>
        ///<returns></returns>
        EmployeeSalaryHistory GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(int employeeID, DateTime dt);

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<returns></returns>
        List<EmployeeSalaryHistory> GetEmployeeSalaryHistoryByEmployeeId(int employeeID);

        ///<summary>
        /// ��ȡĳ���ӹ�˾�ķ�н���
        ///</summary>
        ///<param name="salaryTime"></param>
        /// <param name="companyId">��˾</param>
        ///<returns></returns>
        List<EmployeeSalary> GetEmployeeSalaryByCompnay(DateTime salaryTime, int companyId);

        /// <summary>
        /// ��Ա�����͹��ʵ�
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="salaryDate"></param>
        string SendEmployeeEmail(int accountId, DateTime salaryDate);
    }
}