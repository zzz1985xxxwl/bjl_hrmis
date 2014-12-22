using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// ����������ؽӿ�
    /// </summary>
    public interface IApplyAssessConditionFacade
    {
        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="condition"></param>
        void AddApplyAssessCondition(List<ApplyAssessCondition> conditions, ApplyAssessCondition condition);
        /// <summary>
        /// �޸Ŀ�������
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="condition"></param>
        void UpdateApplyAssessCondition(List<ApplyAssessCondition> conditions, ApplyAssessCondition condition);
        /// <summary>
        /// ɾ����������
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="id"></param>
        void DeleteApplyAssessCondition(List<ApplyAssessCondition> conditions, int id);
        /// <summary>
        /// �Զ����ɿ�������
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="id"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeID"></param>
        void SystemSetApplyAssessCondition(List<ApplyAssessCondition> conditions, int id, DateTime startDate, DateTime endDate, int employeeID);
        /// <summary>
        /// ����Ա����ͬID��ÿ�������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<ApplyAssessCondition> GetApplyAssessConditionByEmployeeContractID(int id);
    }
}
