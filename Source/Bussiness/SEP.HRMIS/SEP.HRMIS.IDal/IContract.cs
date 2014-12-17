using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IDal
{
    public interface IContract
    {
        int InsertEmployeeContract(int accountID, Contract obj);
        int UpdateEmployeeContract(Contract obj);
        int DeleteEmployeeContract(int contractId);
        Contract GetEmployeeContractByContractId(int ContractId);

        Contract GetCurrentContractByAccountID(int accountID, DateTime CurrentDate);

        List<Contract> GetEmployeeContractByContractTypeId(int contractTypeId);
        // Contract GetContractTypeByContractId(int contractId);
        List<Contract> GetEmployeeContractByAccountID(int accountID);
        List<Contract> GetEmployeeContractByCondition(int accountID, DateTime StratTimeFrom, DateTime StratTimeTo, DateTime EndTimeFrom,
            DateTime EndTimeTo, int ContractTypeId);

        int InsertApplyAssessCondition(ApplyAssessCondition conditioin);
        int DeleteApplyAssessConditionsByEmployeeContractID(int contractID);
        List<ApplyAssessCondition> GetApplyAssessConditionByCurrDate(DateTime date);
        int DeleteApplyAssessCondition(int conditionID);
        List<ApplyAssessCondition> GetApplyAssessConditionByEmployeeContractID(int employeeContractID);
        ApplyAssessCondition GetApplyAssessConditionByPKID(int pkid);
        List<Contract> GetAllEmployeeContract();
        Contract GetLastContractInAllTypeByAccountID(int accountID, DateTime CurrentDate);
    }
}