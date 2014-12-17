using System.Collections.Generic;
using SEP.HRMIS.Bll.EmployeeContract;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 更新考核条件
    /// </summary>
    public class UpdateApplyAssessCondition : Transaction
    {
        private List<ApplyAssessCondition> _ApplyAssessConditions;
        private ApplyAssessCondition _ApplyAssessCondition;
        /// <summary>
        /// 更新考核条件构造函数
        /// </summary>
        /// <param name="applyAssessConditions"></param>
        /// <param name="applyAssessCondition"></param>
        public UpdateApplyAssessCondition(List<ApplyAssessCondition> applyAssessConditions,
                ApplyAssessCondition applyAssessCondition)
        {
            _ApplyAssessConditions = applyAssessConditions;
            _ApplyAssessCondition = applyAssessCondition;
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            for (int i = 0; i < _ApplyAssessConditions.Count; i++)
            {
                if (_ApplyAssessCondition.ConditionID == _ApplyAssessConditions[i].ConditionID)
                {
                    _ApplyAssessConditions[i] = _ApplyAssessCondition;
                    break;
                }
            }
            ApplyAssessConditionUtility.GenerateConditions(_ApplyAssessConditions);
        }
    }
}
