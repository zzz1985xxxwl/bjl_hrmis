
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model.Adjusts;
using SEP.HRMIS.SqlServerDal;

namespace SEP.HRMIS.Bll.EmployeeAdjustRules
{
    /// <summary>
    /// 
    /// </summary>
    public class EditEmployeeAdjustRule : Transaction
    {
        private readonly IEmployeeAdjustRule _EmployeeAdjustRuleDal = new EmployeeAdjustRuleDal();
        private readonly AdjustRule _AdjustRule;
        private readonly int _AccountID;

        /// <summary>
        /// 
        /// </summary>
        public EditEmployeeAdjustRule(int accountid, AdjustRule rule)
        {
            _AdjustRule = rule;
            _AccountID = accountid;
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            if (_EmployeeAdjustRuleDal.GetAdjustRuleByAccountID(_AccountID) != null)
            {
                if (_AdjustRule.AdjustRuleID > 0)
                {
                    _EmployeeAdjustRuleDal.UpdateEmployeeAdjustRuleByAccountID(_AccountID, _AdjustRule.AdjustRuleID);
                }
                else
                {
                    _EmployeeAdjustRuleDal.DeleteEmployeeAdjustRuleByAccountID(_AccountID);
                }
            }
            else
            {
                if (_AdjustRule.AdjustRuleID > 0)
                {
                    _EmployeeAdjustRuleDal.Insert(_AccountID, _AdjustRule.AdjustRuleID);
                }
            }
        }
    }
}