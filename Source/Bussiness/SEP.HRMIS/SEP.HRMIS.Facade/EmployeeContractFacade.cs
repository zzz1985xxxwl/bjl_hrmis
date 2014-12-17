using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.EmployeeContract;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    public class EmployeeContractFacade : IEmployeeContractFacade
    {
        public void AddEmployeeContract(Contract contract, Employee employee)
        {
            AddEmployeeContract AddEmployeeContract = new AddEmployeeContract(contract, employee);
            AddEmployeeContract.Excute();
        }

        public void UpdateEmployeeContract(Contract contract, Employee employee)
        {
            UpdateEmployeeContract UpdateEmployeeContract = new UpdateEmployeeContract(contract, employee);
            UpdateEmployeeContract.Excute();
        }

        public void DeleteEmployeeContract(int contractID, int accountID)
        {
            DeleteEmployeeContract DeleteEmployeeContract = new DeleteEmployeeContract(contractID, accountID);
            DeleteEmployeeContract.Excute();
        }

        public Contract GetEmployeeContractByContractId(int contractId)
        {
            GetEmployeeContract GetEmployeeContract = new GetEmployeeContract();
            return GetEmployeeContract.GetEmployeeContractByContractId(contractId);
        }

        public List<Contract> GetEmployeeContractByAccountID(int accountID)
        {
            GetEmployeeContract GetEmployeeContract = new GetEmployeeContract();
            return GetEmployeeContract.GetEmployeeContractByAccountID(accountID);
        }

        public List<Contract> GetLastContractByAccountID(int accountID)
        {
            GetEmployeeContract GetEmployeeContract = new GetEmployeeContract();
            return GetEmployeeContract.GetLastContractByAccountID(accountID);
        }

        public List<Contract> GetEmployeeContractByCondition(string employeeName, DateTime StratTimeFrom, DateTime StratTimeTo, DateTime EndTimeFrom,
            DateTime EndTimeTo, int ContractTypeId, Account Operator)
        {
            GetEmployeeContract GetEmployeeContract = new GetEmployeeContract();
            return
                GetEmployeeContract.GetEmployeeContractByCondition(employeeName, StratTimeFrom, StratTimeTo, EndTimeFrom,
                                                                   EndTimeTo, ContractTypeId, Operator);
        }

        public List<EmployeeContractBookMark> GetRealEmployeeContractBookMarkByContractID(int contractID)
        {
            GetEmployeeContract GetEmployeeContract = new GetEmployeeContract();
            return GetEmployeeContract.GetRealEmployeeContractBookMarkByContractID(contractID);
        }

        public List<EmployeeContractBookMark> GetEmployeeContractBookMarkByContractTypeID(int ContractTypeId, int accountID)
        {
            GetEmployeeContract GetEmployeeContract = new GetEmployeeContract();
            return GetEmployeeContract.GetEmployeeContractBookMarkByContractTypeID(ContractTypeId, accountID);
        }

        public string ExportEmployeeContract(int contractID)
        {
            ExportEmployeeContract ExportEmployeeContract = new ExportEmployeeContract(contractID);
            return ExportEmployeeContract.Excute();
        }

        public List<Contract> GetEmployeeContractByCondition(string employeeName, DateTime StratTimeFrom, DateTime StratTimeTo, DateTime EndTimeFrom,
DateTime EndTimeTo, int ContractTypeId, Account Operator, int employeeStatus)
        {
            GetEmployeeContract GetEmployeeContract = new GetEmployeeContract();
            return
                GetEmployeeContract.GetEmployeeContractByCondition(employeeName, StratTimeFrom, StratTimeTo, EndTimeFrom,
                                                                   EndTimeTo, ContractTypeId, Operator, employeeStatus);
        }
 
    }
}