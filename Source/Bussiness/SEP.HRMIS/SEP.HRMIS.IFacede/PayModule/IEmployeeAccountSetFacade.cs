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
        /// 1 为员工设置帐套，获得自己的帐套
        /// 2 给帐套赋初始值，并得记录调薪历史的结果
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="accountSet"></param>
        /// <param name="backAccountsName"></param>
        /// <param name="changeDate"></param>
        /// <param name="description"></param>
        void CreateEmployeeAccountSetFacade(int employeeID, AccountSet accountSet, string backAccountsName,
                                            DateTime changeDate, string description);

        /// <summary>
        /// 调薪（修改固定项），并得记录调薪历史的结果
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="accountSet"></param>
        /// <param name="backAccountsName"></param>
        /// <param name="changeDate"></param>
        /// <param name="description"></param>
        void UpdateEmployeeAccountSetFacade(int employeeID, AccountSet accountSet, string backAccountsName,
                                            DateTime changeDate, string description);

        /// <summary>
        /// 根据员工编号获得员工薪资
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        EmployeeSalary GetEmployeeAccountSetByEmployeeID(int employeeID);

        /// <summary>
        /// 初始化工资
        /// </summary>
        /// <param name="dt">发放工资时间</param>
        /// <param name="backAcountsName">操作人</param>
        /// <param name="description">描述</param>
        /// <param name="companyId">公司</param>
        /// <param name="departmentId">部门</param>
        void InitialEmployeeSalaryFacade(DateTime dt, string backAcountsName, string description, int companyId,int departmentId);

        /// <summary>
        /// 封账
        /// </summary>
        /// <param name="dt">封帐时间</param>
        /// <param name="backAcountsName">操作人</param>
        /// <param name="description">描述</param>       
        /// <param name="companyId">公司</param>
        /// <param name="isSendEmail"></param>
        string CloseEmployeeSalaryFacade(DateTime dt, string backAcountsName, string description, int companyId, int departmentId, bool isSendEmail);

        /// <summary>
        /// 暂存
        /// </summary>
        /// <param name="salaryId">薪资id</param>
        /// <param name="employeeID">员工id</param>
        /// <param name="dt">发薪时间</param>
        /// <param name="accountSet">员工帐套</param>
        /// <param name="backAcountsName">操作人</param>
        /// <param name="description"></param>
        /// <param name="versionNumber"></param>
        void TemporarySaveEmployeeAccountSetFacadeFacade(int salaryId, int employeeID, DateTime dt,
                                                         AccountSet accountSet, string backAcountsName,
                                                         string description, int versionNumber);

        /// <summary>
        /// 解封
        /// </summary>
        /// <param name="dt">解封时间</param>
        /// <param name="backAcountsName">操作人</param>
        /// <param name="description">描述</param>
        /// <param name="companyId">公司</param>
        void ReopenEmployeeSalaryFacade(DateTime dt, string backAcountsName, string description, int companyId, int departmentId);

        /// <summary>
        /// 根据条件查询员工帐套
        /// </summary>
        /// <returns></returns>
        List<EmployeeSalary> GetEmployeeAccountSetByCondition(string employeeName, int departmentID, int positionID,
                                                              EmployeeTypeEnum EmployeeTypeEnum, bool recursionDepartment, Account loginUser, int employeeStatus);

        /// <summary>
        /// 员工的所有工资记录
        /// </summary>
        /// <param name="employeeID">员工id</param>
        /// <returns></returns>
        EmployeeSalary GetEmployeeSalaryByEmployeeIDFacade(int employeeID);

        /// <summary>
        /// 获取一个员工某月的工资记录
        /// </summary>
        /// <param name="employeeID">员工id</param>
        /// <param name="dt">查询时间</param>
        /// <returns></returns>
        EmployeeSalaryHistory GetEmployeeSalaryHistoryByEmployeeIdAndDateTimeFacade(int employeeID, DateTime dt);

        /// <summary>
        /// 查询工资情况
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
        /// 导入员工工资
        /// </summary>
        /// <param name="filePath">要导入的excel文档路径</param>
        /// <param name="dt">发薪时间</param>
        /// <param name="backAcountsName">操作人姓名</param>
        /// <param name="companyId">公司</param>
        void ImportEmployeeSalary(string filePath, DateTime dt, string backAcountsName, int companyId);
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
        DataTable ExportEmployeeAccountSetFacade(string employeeName, int departmentID, int positionID,
                                                   EmployeeTypeEnum employeeType,
                                                   bool isRecursionDepartment, Account accountOperator, int employeeStatus);
        /// <summary>
        /// 导入员工帐套信息
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
        /// 获取某个子公司的发薪情况
        ///</summary>
        ///<param name="salaryTime"></param>
        /// <param name="companyId">公司</param>
        ///<returns></returns>
        List<EmployeeSalary> GetEmployeeSalaryByCompnay(DateTime salaryTime, int companyId);

        /// <summary>
        /// 给员工发送工资单
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="salaryDate"></param>
        string SendEmployeeEmail(int accountId, DateTime salaryDate);
    }
}