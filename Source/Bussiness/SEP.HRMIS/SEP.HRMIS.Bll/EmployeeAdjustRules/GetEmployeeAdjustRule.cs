using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Adjusts;

namespace SEP.HRMIS.Bll.EmployeeAdjustRules
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEmployeeAdjustRule
    {
        private readonly IEmployeeAdjustRule _EmployeeAdjustRuleDal = DalFactory.DataAccess.CreateEmployeeAdjustRule();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AdjustRule GetAdjustRuleByAccountID(int id)
        {
            return _EmployeeAdjustRuleDal.GetAdjustRuleByAccountID(id);
        }
    }
}