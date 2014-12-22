using System.Collections.Generic;
using AdvancedCondition;
using SEP.HRMIS.Model;
using SEP.Model.Accounts;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// �߼���ѯ
    /// </summary>
    public interface IAdvanceSearchFacade
    {
        /// <summary>
        /// �߼���ѯԱ��
        /// </summary>
        /// <param name="employeeSearchField"></param>
        /// <returns></returns>
        /// <param name="operatorAccount"></param>
        List<Employee> AdvanceSearchEmployeeFacade(List<SearchField> employeeSearchField, Account operatorAccount);
        /// <summary>
        /// �󶨱Ƚ�ֵ��googledown����
        /// </summary>
        /// <param name="fieldParaBaseId"></param>
        /// <returns></returns>
        /// <param name="operatorAccount"></param>
        string BindEmployeeSearchExpression(string fieldParaBaseId, Account operatorAccount);
        /// <summary>
        /// �߼���ѯ��ͬ
        /// </summary>
        /// <param name="contractSearchField"></param>
        /// <returns></returns>
        /// <param name="operatorAccount"></param>
        List<Contract> AdvanceSearchContractFacade(List<SearchField> contractSearchField, Account operatorAccount);
        /// <summary>
        /// �󶨱Ƚ�ֵ��googledown����
        /// </summary>
        /// <param name="fieldParaBaseId"></param>
        /// <returns></returns>
        /// <param name="operatorAccount"></param>
        string BindContractSearchExpression(string fieldParaBaseId, Account operatorAccount);
    }
}
