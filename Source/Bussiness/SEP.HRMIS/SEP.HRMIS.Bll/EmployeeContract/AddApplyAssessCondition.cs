using System.Collections.Generic;
using SEP.HRMIS.Bll.EmployeeContract;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// �������𿼺�����
    /// </summary>
    public class AddApplyAssessCondition : Transaction
    {
        private readonly List<ApplyAssessCondition> _ApplyAssessConditions;
        private readonly ApplyAssessCondition _ApplyAssessCondition;
        /// <summary>
        /// AddApplyAssessCondition���캯��
        /// </summary>
        /// <param name="applyAssessConditions"></param>
        /// <param name="applyAssessCondition"></param>
        public AddApplyAssessCondition(List<ApplyAssessCondition> applyAssessConditions,
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
            _ApplyAssessConditions.Add(_ApplyAssessCondition);
            ApplyAssessConditionUtility.GenerateConditions(_ApplyAssessConditions);
        }
    }
}
