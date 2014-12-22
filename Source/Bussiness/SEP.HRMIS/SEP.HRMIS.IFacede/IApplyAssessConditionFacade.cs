using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.IFacede
{
    /// <summary>
    /// 考核条件相关接口
    /// </summary>
    public interface IApplyAssessConditionFacade
    {
        /// <summary>
        /// 新增考核条件
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="condition"></param>
        void AddApplyAssessCondition(List<ApplyAssessCondition> conditions, ApplyAssessCondition condition);
        /// <summary>
        /// 修改考核条件
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="condition"></param>
        void UpdateApplyAssessCondition(List<ApplyAssessCondition> conditions, ApplyAssessCondition condition);
        /// <summary>
        /// 删除考核条件
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="id"></param>
        void DeleteApplyAssessCondition(List<ApplyAssessCondition> conditions, int id);
        /// <summary>
        /// 自动生成考核条件
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="id"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="employeeID"></param>
        void SystemSetApplyAssessCondition(List<ApplyAssessCondition> conditions, int id, DateTime startDate, DateTime endDate, int employeeID);
        /// <summary>
        /// 根据员工合同ID获得考核条件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<ApplyAssessCondition> GetApplyAssessConditionByEmployeeContractID(int id);
    }
}
