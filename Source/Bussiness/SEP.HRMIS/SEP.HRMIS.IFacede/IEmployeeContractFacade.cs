using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    public interface IEmployeeContractFacade
    {
        /// <summary>
        /// ����Ա����ͬ
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="employee"></param>
        void AddEmployeeContract(Contract contract, Employee employee);
        /// <summary>
        /// �޸�Ա����ͬ
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="employee"></param>
        void UpdateEmployeeContract(Contract contract, Employee employee);
        /// <summary>
        /// ɾ��Ա����ͬ
        /// </summary>
        /// <param name="contractID"></param>
        /// <param name="accountID"></param>
        void DeleteEmployeeContract(int contractID, int accountID);
        /// <summary>
        /// ���ݺ�ͬID��ú�ͬ��Ϣ
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        Contract GetEmployeeContractByContractId(int contractId);
        /// <summary>
        /// ����Ա���ʺ�ID���Ա����ͬ��Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<Contract> GetEmployeeContractByAccountID(int accountID);
        /// <summary>
        /// ���Ա�����µ����º�ͬ��Ϣ
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<Contract> GetLastContractByAccountID(int accountID);
        /// <summary>
        /// ����������ȡԱ����ͬ
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
        /// ���ݺ�ͬ���ͣ����Ա���ĺ�ͬ��ǩ��Ϣ
        /// </summary>
        /// <param name="contractTypeId"></param>
        /// <param name="accountID"></param>
        /// <returns></returns>
        List<EmployeeContractBookMark> GetEmployeeContractBookMarkByContractTypeID(int contractTypeId, int accountID);
        /// <summary>
        /// ���ݺ�ͬ�����Ա���ĺ�ͬ��ǩ��Ϣ
        /// </summary>
        /// <param name="contractID"></param>
        /// <returns></returns>
        List<EmployeeContractBookMark> GetRealEmployeeContractBookMarkByContractID(int contractID);
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        string ExportEmployeeContract(int accountID);

        ///<summary>
        /// ��Ա��״̬�Ĳ�ѯ
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
