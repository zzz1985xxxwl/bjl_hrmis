using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.AssessActivity;
using SEP.HRMIS.Bll.EmployeeContract;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// ϵͳ�Զ����ɷ�����������ʵϰ����
    /// </summary>
    public class AddSystemSetConditionForPractice : IAddSystemSetCondition
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
            //����Э��
            DateTime? dtRealPracticeI = null;
            DateTime dtForPracticeI =
                Convert.ToDateTime(startTime.Year + "-" + AAUtility._CheckPracticeI_Month + "-" +
                                   AAUtility._CheckPracticeI_Day);

            if (DateTime.Compare(endTime, dtForPracticeI) > 0 && DateTime.Compare(dtForPracticeI, startTime) > 0)
            {
                dtRealPracticeI = dtForPracticeI;
            }
            else
            {
                dtForPracticeI =
                    Convert.ToDateTime(startTime.Year + 1 + "-" + AAUtility._CheckPracticeI_Month + "-" +
                                       AAUtility._CheckPracticeI_Day);
                if (DateTime.Compare(endTime, dtForPracticeI) > 0 && DateTime.Compare(dtForPracticeI, startTime) > 0)
                {
                    dtRealPracticeI = dtForPracticeI;
                }

            }
            if (dtRealPracticeI != null)
            {
                ApplyAssessCondition conditionItemPracticeI = new ApplyAssessCondition(0);
                conditionItemPracticeI.ApplyDate = dtForPracticeI;
                conditionItemPracticeI.ApplyAssessCharacterType = AssessCharacterType.PracticeI;
                conditionItemPracticeI.AssessScopeFrom = startTime;
                conditionItemPracticeI.AssessScopeTo = dtForPracticeI.AddDays(26);
                conditions.Add(conditionItemPracticeI);
            }

            //ʵϰ�ڵ���
            ApplyAssessCondition conditionItemPracticeII = new ApplyAssessCondition(0);
            conditionItemPracticeII.ApplyDate = endTime.AddDays(-AAUtility._CheckPracticeII_Day);
            conditionItemPracticeII.ApplyAssessCharacterType = AssessCharacterType.PracticeII;
            conditionItemPracticeII.AssessScopeFrom = startTime;
            conditionItemPracticeII.AssessScopeTo = endTime;
            conditions.Add(conditionItemPracticeII);
            //�������տ���
            ApplyAssessConditionUtility.CreateAnnualConditions(conditions, startTime, endTime, employeeComeDate);
        }

    }
}
