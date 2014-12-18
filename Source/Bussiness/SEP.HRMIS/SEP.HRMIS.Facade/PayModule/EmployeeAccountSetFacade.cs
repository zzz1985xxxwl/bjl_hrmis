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
        /// 初始化工资
        /// </summary>
        /// <param name="dt">发放工资时间</param>
        /// <param name="backAcountsName">操作人</param>
        /// <param name="description">描述</param>
        /// <param name="companyId">公司</param>
        public void InitialEmployeeSalaryFacade(DateTime dt, string backAcountsName, string description, int companyId,int departmentId)
        {
            InitialEmployeeSalary initial = new InitialEmployeeSalary(dt, backAcountsName, description, companyId, departmentId);
            initial.Excute();
        }

        /// <summary>
        /// 封账
        /// </summary>
        /// <param name="dt">封帐时间</param>
        /// <param name="backAcountsName">操作人</param>
        /// <param name="description">描述</param>
        /// <param name="companyId">公司</param>
        /// <param name="isSendEmail"></param>
        public string CloseEmployeeSalaryFacade(DateTime dt, string backAcountsName, string description, int companyId,int departmentId, bool isSendEmail)
        {
            CloseEmployeeSalary close =
                new CloseEmployeeSalary(dt, backAcountsName, description, companyId,departmentId, isSendEmail);
            close.Excute();
            return close.NameMessge;
        }

        /// <summary>
        /// 暂存
        /// </summary>
        /// <param name="salaryId">薪资id</param>
        /// <param name="employeeID">员工id</param>
        /// <param name="dt">发薪时间</param>
        /// <param name="accountSet">员工帐套</param>
        /// <param name="backAcountsName">操作人</param>
        /// <param name="description">描述</param>
        /// <param name="versionNumber">版本号</param>
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
        /// 解封
        /// </summary>
        /// <param name="dt">解封时间</param>
        /// <param name="backAcountsName">操作人</param>
        /// <param name="description">描述</param>
        /// <param name="companyId">公司</param>
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
        /// 员工的所有工资记录
        /// </summary>
        /// <param name="employeeID">员工id</param>
        /// <returns></returns>
        public EmployeeSalary GetEmployeeSalaryByEmployeeIDFacade(int employeeID)
        {
            GetEmployeeAccountSet get = new GetEmployeeAccountSet();
            return get.GetEmployeeSalaryByEmployeeID(employeeID);
        }

        /// <summary>
        /// 获取一个员工某月的工资记录
        /// </summary>
        /// <param name="employeeID">员工id</param>
        /// <param name="dt">查询时间</param>
        /// <returns></returns>
        public EmployeeSalaryHistory GetEmployeeSalaryHistoryByEmployeeIdAndDateTimeFacade(int employeeID, DateTime dt)
        {
            GetEmployeeAccountSet get = new GetEmployeeAccountSet();
            return get.GetEmployeeSalaryHistoryByEmployeeIdAndDateTime(employeeID, dt);
        }

        /// <summary>
        /// 查询工资情况
        /// </summary>
        /// <param name="name"></param>
        /// <param name="salaryTime"></param>
        /// <param name="departmentId"></param>
        /// <param name="positionId"></param>
        /// <param name="accountSetId"></param>
        /// <param name="employeeType"></param>
        /// <param name="companyId">公司</param>
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
        /// 导入员工工资
        /// </summary>
        /// <param name="filePath">要导入的excel文档路径</param>
        /// <param name="dt">发薪时间</param>
        /// <param name="companyId">公司</param>
        /// <param name="backAcountsName">操作人姓名</param>
        public void ImportEmployeeSalary(string filePath, DateTime dt, string backAcountsName, int companyId)
        {
            new ImportEmployeeSalary(filePath, dt, backAcountsName, companyId).Excute();
        }
        /// <summary>
        /// 导入员工帐套信息
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="_operator"></param>
        public void ImportEmployeeAccountSetFacade(string filePath, Account _operator)
        {
            ImportEmployeeAccountSet ImportEmployeeAccountSet = new ImportEmployeeAccountSet(filePath, _operator);
            ImportEmployeeAccountSet.Excute();
        }
        /// <summary>
        /// 导出员工帐套信息
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