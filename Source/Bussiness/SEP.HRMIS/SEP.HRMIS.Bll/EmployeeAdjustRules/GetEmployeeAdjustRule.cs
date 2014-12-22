using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.EmployeeAdjustRules
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEmployeeAdjustRule
    {
        private readonly IEmployeeAdjustRule _EmployeeAdjustRuleDal = new EmployeeAdjustRuleDal();

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