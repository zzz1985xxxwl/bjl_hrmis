using System;
using System.Collections.Generic;
using SEP.HRMIS.IFacede;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Presenter
{
    public class ApplyAssessConditionListInContractPresenter
    {
        private IApplyAssessConditionFacade _IApplyAssessConditionFacade =
            InstanceFactory.CreateApplyAssessConditionFacade();
        private readonly IApplyAssessConditionView _ApplyAssessConditionView;
        private readonly IEmployeeContractView _View;
        public ApplyAssessConditionListInContractPresenter(IEmployeeContractView view, IApplyAssessConditionView applyAssessConditionView)
        {
            _View = view;
            _ApplyAssessConditionView = applyAssessConditionView;
        }

        public bool CheckValidListData(ApplyAssessCondition condition, List<ApplyAssessCondition> conditions)
        {
            conditions = _View.ConditionSource;
            for (int i = 0; i < conditions.Count; i++)
            {
                if (conditions[i].ApplyDate == condition.ApplyDate &&
                    conditions[i].AssessScopeFrom == condition.AssessScopeFrom &&
                    conditions[i].AssessScopeTo == condition.AssessScopeTo &&
                    conditions[i].ApplyAssessCharacterType == condition.ApplyAssessCharacterType &&
                    conditions[i].ConditionID != condition.ConditionID)
                {
                    _ApplyAssessConditionView.Message = "已存在相同的设置";
                    return false;
                }
            }
            return true;
        }

        public void AddApplyAssessConditionInContractView(ApplyAssessCondition condition)
        {
            if (condition == null)
            {
                _View.ResultMessage = "<span class='fontred'>" + "系统设置信息获取失败" + "</span>";
                return;
            }
            condition.ConditionID = -1;
            List<ApplyAssessCondition> applyAssessConditions = _View.ConditionSource;
            if (!CheckValidListData(condition, applyAssessConditions))
            {
                return;
            }
            _IApplyAssessConditionFacade.AddApplyAssessCondition(applyAssessConditions, condition);
            _View.ConditionSource = applyAssessConditions;
        }

        public void UpdateApplyAssessConditionInContractView(ApplyAssessCondition condition)
        {
            if (condition == null)
            {
                _View.ResultMessage = "<span class='fontred'>" + "系统设置信息获取失败" + "</span>";
                return;
            }
            List<ApplyAssessCondition> applyAssessConditions = _View.ConditionSource;
            if (!CheckValidListData(condition, applyAssessConditions))
            {
                return;
            }

            _IApplyAssessConditionFacade.UpdateApplyAssessCondition(applyAssessConditions, condition);

            _View.ConditionSource = applyAssessConditions;
        }

        public void DeleteApplyAssessConditionInContractView(int ConditionID)
        {
            List<ApplyAssessCondition> applyAssessConditions = _View.ConditionSource;
            _IApplyAssessConditionFacade.DeleteApplyAssessCondition(applyAssessConditions, ConditionID);
            _View.ConditionSource = applyAssessConditions;
        }

        public void GetSystemSet()
        {
            EmployeeContractBasePresenter employeeContractBasePresenter = new EmployeeContractBasePresenter(_View);
            if (!employeeContractBasePresenter.Validate())
            {
                return;
            }
            int contractTypeID = Convert.ToInt32(_View.ContractTypeId);
            int employeeID = Convert.ToInt32(_View.EmployeeId);
            List<ApplyAssessCondition> conditions = new List<ApplyAssessCondition>();
            _IApplyAssessConditionFacade.SystemSetApplyAssessCondition(conditions, contractTypeID,
                                                  Convert.ToDateTime(_View.ContractStartTime),
                                                  Convert.ToDateTime(_View.ContractEndTime), employeeID);
            _View.ConditionSource = conditions;
        }


    }
}
