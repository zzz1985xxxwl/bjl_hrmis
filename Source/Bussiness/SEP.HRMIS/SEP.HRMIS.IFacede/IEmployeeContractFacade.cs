using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    public interface IEmployeeContractFacade
    {
        /// <summary>
        /// 新增员工合同
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="employee"></param>
        void AddEmployeeContract(Contract contract, Employee employee);
        /// <summary>
        /// 修改员工合同
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="employee"></param>
        void UpdateEmployeeContract(Contract contract, Employee employee);
        /// <summary>
        /// 删除员工合同
        /// </summary>
        /// <param name="contractID"></param>
        /// <param name="accountID"></param>
        void DeleteEmployeeContract(int contractID, int accountID);
        /// <summary>
        /// 根据合同ID获得合同信息
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        Contract GetEmployeeContractByContractId(int contractId);
        /// <summary>
        /// 根据员工帐号ID获得员工合同信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<Contract> GetEmployeeContractByAccountID(int accountID);
        /// <summary>
        /// 获得员工最新的最新合同信息
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<Contract> GetLastContractByAccountID(int accountID);
        /// <summary>
        /// 根据条件获取员工合同
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="StratTimeFrom"></param>
        /// <param name="StratTimeTo"></param>
        /// <param name="EndTimeFrom"></param>
        /// <param name="EndTimeTo"></param>
        /// <param name="ContractTypeId"></param>
        /// <returns></returns>
        /// <param name="Operator"></param>
        List<Contract> GetEmployeeContractByCondition(string employeeName, DateTime StratTimeFrom, DateTime StratTimeTo,
                                                       DateTime EndTimeFrom,
                                                       DateTime EndTimeTo, int ContractTypeId, Account Operator);
        /// <summary>
        /// 根据合同类型，获得员工的合同标签信息
        /// </summary>
        /// <param name="contractTypeId"></param>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<EmployeeContractBookMark> GetEmployeeContractBookMarkByContractTypeID(int contractTypeId, int accountID);
        /// <summary>
        /// 根据合同，获得员工的合同标签信息
        /// </summary>
        /// <param name="contractID"></param>
        /// <returns></returns>
        List<EmployeeContractBookMark> GetRealEmployeeContractBookMarkByContractID(int contractID);
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        string ExportEmployeeContract(int accountID);

        ///<summary>
        /// 有员工状态的查询
        ///</summary>
        ///<param name="employeeName"></param>
        ///<param name="StratTimeFrom"></param>
        ///<param name="StratTimeTo"></param>
        ///<param name="EndTimeFrom"></param>
        ///<param name="EndTimeTo"></param>
        ///<param name="ContractTypeId"></param>
        ///<param name="Operator"></param>
        ///<param name="employeeStatus"></param>
        ///<returns></returns>
        List<Contract> GetEmployeeContractByCondition(string employeeName, DateTime StratTimeFrom, DateTime StratTimeTo,
                                                      DateTime EndTimeFrom,
                                                      DateTime EndTimeTo, int ContractTypeId, Account Operator,
                                                      int employeeStatus);
    }
}
