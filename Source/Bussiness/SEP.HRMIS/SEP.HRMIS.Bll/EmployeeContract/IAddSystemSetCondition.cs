using System;
using System.Collections.Generic;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// �Զ����ɿ����������
    /// </summary>
    public interface IAddSystemSetCondition
    {
        /// <summary>
        /// �Զ����ɿ�������
        /// </summary>
        /// <param name="applyAssessConditions"></param>
        /// <param name="contractStartTime"></param>
        /// <param name="contractEndTime"></param>
        /// <param name="employeeComeDate"></param>
        void AddSystemSetCondition(List<ApplyAssessCondition> applyAssessConditions, DateTime contractStartTime,
                                   DateTime contractEndTime, DateTime employeeComeDate);
    }
}
