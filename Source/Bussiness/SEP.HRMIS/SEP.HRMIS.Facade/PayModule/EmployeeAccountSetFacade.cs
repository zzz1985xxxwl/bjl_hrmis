using System;
using System.Collections.Generic;
using System.Data;
using SEP.HRMIS.Model;
using SEP.HRMIS.Bll.PayModule.EmployeeAccountSet;
using SEP.HRMIS.IFacede.PayModule;
using SEP.HRMIS.Model.PayModule;

namespace SEP.HRMIS.Facade.PayModule
{
    using SEP.Model.Accounts;

    ///<summary>
    ///</summary>
    public class EmployeeAccountSetFacade : IEmployeeAccountSetFacade
    {
        public void CreateEmployeeAccountSetFacade(int employeeID, AccountSet accountSet,
                                                   string backAccountsName, DateTime changeDate, string description)
        {
            CreateEmployeeAccountSet createEmployeeAccountSet =
                new CreateEmployeeAccountSet(employeeID, accountSet, backAccountsName, changeDate, description);
            createEmployeeAccountSet.Excute();
        }

        public void UpdateEmployeeAccountSetFacade(int employeeID, AccountSet accountSet,
                                                   string backAccountsName, DateTime changeDate, string description)
        {
            UpdateEmployeeAccountSet updateEmployeeAccountSet =
                new UpdateEmployeeAccountSet(employeeID, accountSet, backAccountsName, changeDate, description);
            updateEmployeeAccountSet.Excute();
        }

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<returns></returns>
        public EmployeeSalary GetEmployeeAccountSetByEmployeeID(int employeeID)
        {
            GetEmployeeAccountSet getEmployeeAccountSet = new GetEmployeeAccountSet();
            return getEmployeeAccountSet.GetEmployeeAccountSetByEmployeeID(employeeID);
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="dt">���Ź���ʱ��</param>
        /// <param name="backAcountsName">������</param>
        /// <param name="description">����</param>
        /// <param name="companyId">��˾</param>
        public void InitialEmployeeSalaryFacade(DateTime dt, string backAcountsName, string description, int companyId,int departmentId)
        {
            InitialEmployeeSalary initial = new InitialEmployeeSalary(dt, backAcountsName, description, companyId, departmentId);
            initial.Excute();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="dt">����ʱ��</param>
        /// <param name="backAcountsName">������</param>
        /// <param name="description">����</param>
        /// <param name="companyId">��˾</param>
        /// <param name="isSendEmail"></param>
        public string CloseEmployeeSalaryFacade(DateTime dt, string backAcountsName, string description, int companyId,int departmentId, bool isSendEmail)
        {
            CloseEmployeeSalary close =
                new CloseEmployeeSalary(dt, backAcountsName, description, companyId,departmentId, isSendEmail);
            close.Excute();
            return close.NameMessge;
        }

        /// <summary>
        /// �ݴ�
        /// </summary>
        /// <param name="salaryId">н��id</param>
        /// <param name="employeeID">Ա��id</param>
        /// <param name="dt">��нʱ��</param>
        /// <param name="accountSet">Ա������</param>
        /// <param name="backAcountsName">������</param>
        /// <param name="description">����</param>
        /// <param name="versionNumber">�汾��</param>
        public void TemporarySaveEmployeeAccountSetFacadeFacade(int salaryId, int employeeID, DateTime dt,
                                                                AccountSet accountSet, string backAcountsName,
                                                                string description, int versionNumber)
        {
            TemporarySaveEmployeeAccountSet tempSave =
                new TemporarySaveEmployeeAccountSet(salaryId, employeeID, dt, accountSet, backAcountsName, description,
                                                    versionNumber);
            tempSave.Excute();
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="dt">���ʱ��</param>
        /// <param name="backAcountsName">������</param>
        /// <param name="description">����</param>
        /// <param name="companyId">��˾</param>
        public void ReopenEmployeeSalaryFacade(DateTime dt, string backAcountsName, string description, int companyId,int departmentId)
        {
            ReopenEmployeeSalary reopen = new ReopenEmployeeSalary(dt, backAcountsName, description, companyId, departmentId);
            reopen.Excute();
        }

        ///<summary>
        ///</summary>
        ///<param name="employeeName"></param>
        ///<param name="departmentID"></param>
        ///<param name="positionID"></param>
        ///<param name="EmployeeTypeEnum"></param>
        ///<param name="loginUser"></param>
        ///<returns></returns>
        public List<EmployeeSalary> GetEmployeeAccountSetByCondition(string employeeName, int departmentID, int positionID,
                                                                     EmployeeTypeEnum EmployeeTypeEnum, bool recursionDepartment, Account loginUser, int employeeStatus)
        {
            GetEmployeeAccountSet getEmployeeAccountSet = new GetEmployeeAccountSet();
            return
                getEmployeeAccountSet.GetEmployeeAccountSetByCondition(employeeName, departmentID, positionID,
                                                                       EmployeeTypeEnum, recursionDepartment, loginUser,
                                                                       employeeStatus);
        }

        /// <summary>
        /// Ա�������й��ʼ�¼
        /// </summary>
        /// <param name="employeeID">Ա��id</param>
        /// <returns></returns>
        public EmployeeSalary GetEmployeeSalaryByEmployeeIDFacade(int employeeID)
        {
            GetEmployeeAccountSet get = new GetEmployeeAccountSet();
            return get.GetEmployeeSalaryByEmployeeID(employeeID);
        }

        /// <summary>
        /// ��ȡһ��Ա��ĳ�µĹ��ʼ�¼
        /// </summary>
        /// <param name="employeeID">Ա��id</param>
        /// <param name="dt">��ѯʱ��</param>
        /// <returns></returns>
        public EmployeeSalaryHistory GetEmployeeSalaryHistoryByEmployeeIdAndDateTimeFacade(int employeeID, DateTime dt)
        {
            GetEmployeeAccountSet get = new GetEmployeeAccountSet();
            return get.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(employeeID, dt);
        }

        /// <summary>
        /// ��ѯ�������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="salaryTime"></param>
        /// <param name="departmentId"></param>
        /// <param name="positionId"></param>
        /// <param name="accountSetId"></param>
        /// <param name="employeeType"></param>
        /// <param name="companyId">��˾</param>
        /// <returns></returns>
        public List<EmployeeSalary> GetEmployeeSalaryByConditionFacade(string name, DateTime salaryTime,
                                                                       int departmentId, int positionId,
                                                                       int accountSetId, EmployeeTypeEnum employeeType, int companyId)
        {
            GetEmployeeAccountSet get = new GetEmployeeAccountSet();
            return
                get.GetEmployeeSalaryByCondition(name, salaryTime, departmentId, positionId, accountSetId, employeeType, companyId);
        }
        /// <summary>
        /// ����Ա������
        /// </summary>
        /// <param name="filePath">Ҫ�����excel�ĵ�·��</param>
        /// <param name="dt">��нʱ��</param>
        /// <param name="companyId">��˾</param>
        /// <param name="backAcountsName">����������</param>
        public void ImportEmployeeSalary(string filePath, DateTime dt, string backAcountsName, int companyId)
        {
            new ImportEmployeeSalary(filePath, dt, backAcountsName, companyId).Excute();
        }
        /// <summary>
        /// ����Ա��������Ϣ
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="_operator"></param>
        public void ImportEmployeeAccountSetFacade(string filePath, Account _operator)
        {
            ImportEmployeeAccountSet ImportEmployeeAccountSet = new ImportEmployeeAccountSet(filePath, _operator);
            ImportEmployeeAccountSet.Excute();
        }
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
        public DataTable ExportEmployeeAccountSetFacade(string employeeName, int departmentID, int positionID, EmployeeTypeEnum employeeType,
            bool isRecursionDepartment, Account accountOperator, int employeeStatus)
        {
            ExportEmployeeAccountSet ExportEmployeeAccountSet =
                new ExportEmployeeAccountSet(employeeName, departmentID, positionID, employeeType,
                                             isRecursionDepartment, accountOperator, employeeStatus);
            return ExportEmployeeAccountSet.Excute();
        }

        ///<summary>
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        public EmployeeSalary GetAdjustSalaryHistoryByPKID(int id)
        {
            return new GetEmployeeAccountSet().GetAdjustSalaryHistoryByPKID(id);
        }

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<returns></returns>
        public List<AdjustSalaryHistory> GetAdjustSalaryHistoryByEmployeeID(int employeeID)
        {
            return new GetEmployeeAccountSet().GetAdjustSalaryHistoryByEmployeeID(employeeID);
        }

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<returns></returns>
        public EmployeeSalary GetEmployeeSalaryByEmployeeID(int employeeID)
        {
            return new GetEmployeeAccountSet().GetEmployeeAccountSetByEmployeeID(employeeID);
        }

        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        public EmployeeSalaryHistory GetEmployeeSalaryHistoryByPKID(int pkid)
        {
            return new GetEmployeeAccountSet().GetEmployeeSalaryHistoryByPKID(pkid);
        }

        ///<summary>
        ///</summary>
        ///<param name="pkid"></param>
        ///<returns></returns>
        public EmployeeSalary GetEmployeeSalaryByEmployeeSalaryHistoryID(int historyid)
        {
            return new GetEmployeeAccountSet().GetEmployeeSalaryByEmployeeSalaryHistoryID(historyid);
        }

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<param name="dt"></param>
        ///<returns></returns>
        public EmployeeSalaryHistory GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(int employeeID, DateTime dt)
        {
            return new GetEmployeeAccountSet().GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(employeeID, dt);
        }

        ///<summary>
        ///</summary>
        ///<param name="employeeID"></param>
        ///<returns></returns>
        public List<EmployeeSalaryHistory> GetEmployeeSalaryHistoryByEmployeeId(int employeeID)
        {
            return new GetEmployeeAccountSet().GetEmployeeSalaryHistoryByEmployeeId(employeeID);
        }

        ///<summary>
        ///</summary>
        ///<param name="salaryTime"></param>
        ///<param name="companyId"></param>
        ///<returns></returns>
        public List<EmployeeSalary> GetEmployeeSalaryByCompnay(DateTime salaryTime, int companyId)
        {
            return new GetEmployeeAccountSet().GetEmployeeSalaryByCondition(string.Empty, salaryTime, -1,
                                                                 -1, -1, EmployeeTypeEnum.All, companyId);
        }

        public string SendEmployeeEmail(int accountId, DateTime salaryDate)
        {
            SendEmployeeSalaryToEmployee mail = new SendEmployeeSalaryToEmployee(accountId, salaryDate);
            mail.Excute();
            return mail.MailFailName;
        }
    }
}