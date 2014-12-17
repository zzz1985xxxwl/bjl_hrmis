using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEP.HRMIS.DataAccess;
using SEP.HRMIS.Entity;
using SEP.HRMIS.Model.AccountAuth;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Logic
{
    public class EmployeeContractLogic
    {
        public static List<EmployeeContractEntity> GetEmployeeContractByCondition(string employeeName, DateTime stratTimeFrom, DateTime stratTimeTo, DateTime endTimeFrom,
           DateTime endTimeTo, int contractTypeId, Account operatorAccount, int employeeStatus)
        {
            return EmployeeContractDA.GetEmployeeContractByCondition(employeeName, stratTimeFrom, stratTimeTo, endTimeFrom,
            endTimeTo, AccountAuthDA.GetAccountAuthDepartment(operatorAccount.Id, HrmisPowers.A402), contractTypeId, employeeStatus);
        }
    }
}
