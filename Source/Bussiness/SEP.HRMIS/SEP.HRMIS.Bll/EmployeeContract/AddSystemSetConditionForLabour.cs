using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.AssessActivity;
using SEP.HRMIS.Bll.EmployeeContract;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ϵͳ�Զ����ɷ�������������ǩ��ͬ��
    /// </summary>
    public class AddSystemSetConditionForLabour : IAddSystemSetCondition
    {
        /// <summary>
        /// ʵ��IAddSystemSetCondition������Ϣ��䵽conditions��
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="employeeComeDate"></param>
        public void AddSystemSetCondition(List<ApplyAssessCondition> conditions, DateTime startTime, DateTime endTime, DateTime employeeComeDate)
        {
            if ((endTime - startTime).Days > 366)
            {
                //����II
                ApplyAssessCondition conditionItemProbationII = new ApplyAssessCondition(0);
                conditionItemProbationII.ApplyDate = startTime.AddDays(AAUtility._CheckProbationII_Days);
                conditionItemProbationII.ApplyAssessCharacterType = AssessCharacterType.ProbationII;
                conditionItemProbationII.AssessScopeFrom = startTime;
                conditionItemProbationII.AssessScopeTo = startTime.AddMonths(6).AddDays(-1);
                conditions.Add(conditionItemProbationII);

                AddConditionForNormalLabour(conditions, startTime, endTime);
            }
            else
            {
                //����II
                ApplyAssessCondition conditionItemProbationII = new ApplyAssessCondition(0);
                conditionItemProbationII.ApplyDate = startTime.AddDays(AAUtility._CheckProbationIIOneYear_Days);
                conditionItemProbationII.ApplyAssessCharacterType = AssessCharacterType.ProbationII;
                conditionItemProbationII.AssessScopeFrom = startTime;
                conditionItemProbationII.AssessScopeTo = startTime.AddMonths(2).AddDays(-1);
                conditions.Add(conditionItemProbationII);

                AddConditionForNormalLabour(conditions, startTime, endTime);
            }
            //�������տ���
            ApplyAssessConditionUtility.CreateAnnualConditions(conditions, startTime, endTime, employeeComeDate);

        }
        private static void AddConditionForNormalLabour(List<ApplyAssessCondition> conditions, DateTime startTime, DateTime endTime)
        {
            //��ͬ����
            //DateTime dtStartTime;
            //for (int i = 1; DateTime.Compare(endTime, startTime.AddYears(i)) >= 0; i++)
            //{
            //    ApplyAssessCondition conditionItemNormal = new ApplyAssessCondition(0);
            //    dtStartTime = startTime.AddYears(i);
            //    conditionItemNormal.ApplyDate = dtStartTime.AddDays(-(AAUtility._CheckNormal_Days + 1));
            //    conditionItemNormal.ApplyAssessCharacterType = AssessCharacterType.Normal;
            //    conditionItemNormal.AssessScopeFrom = dtStartTime.AddYears(-1);
            //    conditionItemNormal.AssessScopeTo = dtStartTime.AddDays(-1);
            //    conditions.Add(conditionItemNormal);
            //}
            //��ͬ����
            ApplyAssessCondition conditionItemNormalForContract = new ApplyAssessCondition(0);
            conditionItemNormalForContract.ApplyDate = endTime.AddDays(-AAUtility._CheckNormal_Days);
            conditionItemNormalForContract.ApplyAssessCharacterType = AssessCharacterType.NormalForContract;
            conditionItemNormalForContract.AssessScopeFrom = startTime;
            conditionItemNormalForContract.AssessScopeTo = endTime;
            conditions.Add(conditionItemNormalForContract);
        }

    }
}
