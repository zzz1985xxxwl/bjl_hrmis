using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ɾ����������
    /// </summary>
    public class DeleteApplyAssessCondition : Transaction
    {
        private readonly int _ConditionID;
        private readonly List<ApplyAssessCondition> _ApplyAssessConditions;
        /// <summary>
        /// ɾ�������������캯��
        /// </summary>
        /// <param name="applyAssessConditions"></param>
        /// <param name="conditionID"></param>
        public DeleteApplyAssessCondition(List<ApplyAssessCondition> applyAssessConditions,
                int conditionID)
        {
            _ApplyAssessConditions = applyAssessConditions;
            _ConditionID = conditionID;
        }

        protected override void Validation()
        {
        }

        protected override void ExcuteSelf()
        {
            for (int i = 0; i < _ApplyAssessConditions.Count; i++)
            {
                if (_ConditionID == _ApplyAssessConditions[i].ConditionID)
                {
                    _ApplyAssessConditions.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
