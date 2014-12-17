using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll;
using SEP.HRMIS.Bll.EmployeeContract;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Facade
{
    /// <summary>
    /// IApplyAssessConditionFacade µœ÷¿‡
    /// </summary>
    public class ApplyAssessConditionFacade : IApplyAssessConditionFacade
    {
        public void AddApplyAssessCondition(List<ApplyAssessCondition> applyAssessConditions,
                ApplyAssessCondition applyAssessCondition)
        {
            AddApplyAssessCondition AddApplyAssessCondition =
                new AddApplyAssessCondition(applyAssessConditions, applyAssessCondition);
            AddApplyAssessCondition.Excute();
        }

        public void UpdateApplyAssessCondition(List<ApplyAssessCondition> applyAssessConditions,
                ApplyAssessCondition applyAssessCondition)
        {
            UpdateApplyAssessCondition UpdateApplyAssessCondition =
                new UpdateApplyAssessCondition(applyAssessConditions, applyAssessCondition);
            UpdateApplyAssessCondition.Excute();
        }

        public void DeleteApplyAssessCondition(List<ApplyAssessCondition> applyAssessConditions,
                int conditionID)
        {
            DeleteApplyAssessCondition DeleteApplyAssessCondition =
                new DeleteApplyAssessCondition(applyAssessConditions, conditionID);
            DeleteApplyAssessCondition.Excute();
        }


        public void SystemSetApplyAssessCondition(List<ApplyAssessCondition> applyAssessConditions, int contractTypeId,
            DateTime contractStartTime, DateTime contractEndTime, int employeeID)
        {
            SystemSetApplyAssessCondition SystemSetApplyAssessCondition =
                new SystemSetApplyAssessCondition(applyAssessConditions, contractTypeId,
                                                                               contractStartTime, contractEndTime, employeeID);
            SystemSetApplyAssessCondition.Excute();
        }

        public List<ApplyAssessCondition> GetApplyAssessConditionByEmployeeContractID(int employeeContractID)
        {
            GetEmployeeContract GetEmployeeContract = new GetEmployeeContract();
            return GetEmployeeContract.GetApplyAssessConditionByEmployeeContractID(employeeContractID);
        }
    }
}