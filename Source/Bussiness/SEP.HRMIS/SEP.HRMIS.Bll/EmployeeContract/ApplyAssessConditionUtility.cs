using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.AssessActivity;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll.EmployeeContract
{
    /// <summary>
    /// �Զ����𿼺˹�������
    /// </summary>
    public class ApplyAssessConditionUtility
    {
        /// <summary>
        /// ��conditions�������򣬸��ݷ���ʱ������
        /// </summary>
        /// <param name="conditions"></param>
        public static void GenerateConditions(List<ApplyAssessCondition> conditions)
        {
            if (conditions.Count == 0)
            {
                return;
            }
            for (int i = 0; i < conditions.Count - 1; i++)
            {
                conditions[i].ConditionID = i;
                for (int j = i + 1; j < conditions.Count; j++)
                {
                    if (DateTime.Compare(conditions[j].ApplyDate, conditions[i].ApplyDate) < 0)
                    {
                        conditions[j].ConditionID = conditions[i].ConditionID;
                        ApplyAssessCondition conditionTmp = conditions[i];
                        conditions[i] = conditions[j];
                        conditions[j] = conditionTmp;
                    }
                }
            }
            conditions[conditions.Count - 1].ConditionID = conditions.Count - 1;

        }
        /// <summary>
        /// �Ƴ�����
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        public static void RemoveUnvalidConditions(List<ApplyAssessCondition> conditions, DateTime startTime, DateTime endTime)
        {
            if (conditions.Count == 0)
            {
                return;
            }
            for (int i = 0; i < conditions.Count; i++)
            {
                if (DateTime.Compare(conditions[i].ApplyDate, startTime) < 0 ||
                    DateTime.Compare(endTime, conditions[i].ApplyDate) < 0)
                {
                    conditions.Remove(conditions[i]);
                    i--;
                }
            }
        }
        /// <summary>
        /// �������տ���
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="employeeComeDate"></param>
        public static void CreateAnnualConditions(List<ApplyAssessCondition> conditions, DateTime startTime, DateTime endTime, DateTime employeeComeDate)
        {
            if (conditions == null)
            {
                conditions = new List<ApplyAssessCondition>();
            }
            DateTime dtStartTime = new DateTime(startTime.Year, 1, 1);
            for (int i = 1; DateTime.Compare(endTime, dtStartTime.AddYears(1).AddDays(-1)) >= 0; i++)
            {
                ApplyAssessCondition conditionItemAnnual = new ApplyAssessCondition(0);
                conditionItemAnnual.ApplyAssessCharacterType = AssessCharacterType.Annual;
                conditionItemAnnual.ApplyDate =
                    new DateTime(dtStartTime.Year, AAUtility._AnnualApplyMonth, AAUtility._AnnualApplyDay);
                conditionItemAnnual.AssessScopeFrom = DateTime.Compare(employeeComeDate, dtStartTime) > 0
                                                          ? employeeComeDate
                                                          : dtStartTime;
                conditionItemAnnual.AssessScopeTo = dtStartTime.AddYears(1).AddDays(-1);
                conditions.Add(conditionItemAnnual);
                dtStartTime = dtStartTime.AddYears(1);
            }
        }
    }
}
