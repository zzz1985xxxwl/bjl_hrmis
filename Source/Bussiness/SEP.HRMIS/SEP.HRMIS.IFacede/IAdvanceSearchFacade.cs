using System.Collections.Generic;
using AdvancedCondition;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 高级查询
    /// </summary>
    public interface IAdvanceSearchFacade
    {
        /// <summary>
        /// 高级查询员工
        /// </summary>
        /// <param name="employeeSearchField"></param>
        /// <returns></returns>
        /// <param name="operatorAccount"></param>
        List<Employee> AdvanceSearchEmployeeFacade(List<SearchField> employeeSearchField, Account operatorAccount);
        /// <summary>
        /// 绑定比较值的googledown数据
        /// </summary>
        /// <param name="fieldParaBaseId"></param>
        /// <returns></returns>
        /// <param name="operatorAccount"></param>
        string BindEmployeeSearchExpression(string fieldParaBaseId, Account operatorAccount);
        /// <summary>
        /// 高级查询合同
        /// </summary>
        /// <param name="contractSearchField"></param>
        /// <returns></returns>
        /// <param name="operatorAccount"></param>
        List<Contract> AdvanceSearchContractFacade(List<SearchField> contractSearchField, Account operatorAccount);
        /// <summary>
        /// 绑定比较值的googledown数据
        /// </summary>
        /// <param name="fieldParaBaseId"></param>
        /// <returns></returns>
        /// <param name="operatorAccount"></param>
        string BindContractSearchExpression(string fieldParaBaseId, Account operatorAccount);
    }
}
