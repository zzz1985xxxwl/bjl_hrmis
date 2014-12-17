using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 自动生成考核条件借口
    /// </summary>
    public interface IAddSystemSetCondition
    {
        /// <summary>
        /// 自动生成考核条件
        /// </summary>
        /// <param name="applyAssessConditions"></param>
        /// <param name="contractStartTime"></param>
        /// <param name="contractEndTime"></param>
        /// <param name="employeeComeDate"></param>
        void AddSystemSetCondition(List<ApplyAssessCondition> applyAssessConditions, DateTime contractStartTime,
                                   DateTime contractEndTime, DateTime employeeComeDate);
    }
}
