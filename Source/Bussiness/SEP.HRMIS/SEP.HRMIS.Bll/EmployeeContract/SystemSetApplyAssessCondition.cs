using System;
using System.Collections.Generic;
using SEP.HRMIS.Bll.EmployeeContract;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 自动生成考核条件
    /// 调用不同情况的劳动合同，续签劳动合同，实习合同实现类
    /// </summary>
    public class SystemSetApplyAssessCondition : Transaction
    {
        private static IEmployee _DalEmployee = DalFactory.DataAccess.CreateEmployee();
        private readonly int _ContractTypeId;
        private readonly DateTime _ContractStartTime;
        private readonly DateTime _ContractEndTime;
        private readonly List<ApplyAssessCondition> _ApplyAssessConditions;
        private IAddSystemSetCondition _IAddSystemSetCondition;
        private readonly int _EmployeeID;
        /// <summary>
        /// 系统自动生成考核条件构造函数
        /// </summary>
        /// <param name="applyAssessConditions"></param>
        /// <param name="contractTypeId"></param>
        /// <param name="contractStartTime"></param>
        /// <param name="contractEndTime"></param>
        public SystemSetApplyAssessCondition(List<ApplyAssessCondition> applyAssessConditions, int contractTypeId, DateTime contractStartTime, DateTime contractEndTime,int employeeID)
        {
            _ContractTypeId = contractTypeId;
            _ApplyAssessConditions = applyAssessConditions;
            _ContractStartTime = contractStartTime;
            _ContractEndTime = contractEndTime;
            _EmployeeID = employeeID;
        }

        protected override void Validation()
        {
           
        }

        protected override void ExcuteSelf()
        {
            Employee employee = _DalEmployee.GetEmployeeByAccountID(_EmployeeID);
            //劳动合同
            if (_ContractTypeId == 1)
            {
                _IAddSystemSetCondition = new AddSystemSetConditionForLabour();
                _IAddSystemSetCondition.AddSystemSetCondition(_ApplyAssessConditions, _ContractStartTime,
                                                              _ContractEndTime, employee.EmployeeDetails.Work.ComeDate);
            }
            //续签劳动合同
            if (_ContractTypeId == 2)
            {
                _IAddSystemSetCondition = new AddSystemSetConditionForContinuedLabour();
                _IAddSystemSetCondition.AddSystemSetCondition(_ApplyAssessConditions, _ContractStartTime,
                                                              _ContractEndTime, employee.EmployeeDetails.Work.ComeDate);
            }
            //实习合同
            if (_ContractTypeId == 4)
            {
                _IAddSystemSetCondition = new AddSystemSetConditionForPractice();
                _IAddSystemSetCondition.AddSystemSetCondition(_ApplyAssessConditions, _ContractStartTime,
                                                              _ContractEndTime, employee.EmployeeDetails.Work.ComeDate);
            }
            ApplyAssessConditionUtility.RemoveUnvalidConditions(_ApplyAssessConditions, _ContractStartTime,
                                                                _ContractEndTime);
            ApplyAssessConditionUtility.GenerateConditions(_ApplyAssessConditions);
        }
    }
}
