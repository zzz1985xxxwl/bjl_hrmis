using System.Collections.Generic;
using AdvancedCondition;
using SEP.HRMIS.Bll.AdvanceSearch;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// ∏ﬂº∂≤È—Ø
    /// </summary>
    public class AdvanceSearchFacade : IAdvanceSearchFacade
    {
        public List<Employee> AdvanceSearchEmployeeFacade(List<SearchField> employeeSearchField, Account operatorAccount)
        {
            AdvanceSearchEmployee AdvanceSearchEmployee = new AdvanceSearchEmployee(employeeSearchField, operatorAccount);
            return AdvanceSearchEmployee.DoAdvanceSearchEmployee();
        }

        public string BindEmployeeSearchExpression(string fieldParaBaseId, Account operatorAccount)
        {
            BindEmployeeSearchExpression BindEmployeeSearchExpression =
                new BindEmployeeSearchExpression(fieldParaBaseId, operatorAccount);
            return BindEmployeeSearchExpression.ToBind();
        }
        public List<Contract> AdvanceSearchContractFacade(List<SearchField> contractSearchField, Account operatorAccount)
        {
            AdvanceSearchContract AdvanceSearchContract = new AdvanceSearchContract(contractSearchField, operatorAccount);
            return AdvanceSearchContract.DoAdvanceSearchContract();
        }

        public string BindContractSearchExpression(string fieldParaBaseId, Account operatorAccount)
        {
            BindContractSearchExpression BindContractSearchExpression =
                new BindContractSearchExpression(fieldParaBaseId, operatorAccount);
            return BindContractSearchExpression.ToBind();
        }
    }
}
