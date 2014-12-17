using SEP.HRMIS.Bll.EmployeeAdjustRules;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model.Adjusts;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeAdjustRuleFacade : IEmployeeAdjustRuleFacade
    {
        public AdjustRule GetAdjustRuleByAccountID(int id)
        {
            return new GetEmployeeAdjustRule().GetAdjustRuleByAccountID(id);
        }
    }
}