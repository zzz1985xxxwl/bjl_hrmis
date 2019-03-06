using System;
using System.Collections.Generic;
using System.Transactions;
using SEP.HRMIS.IDal;
using SEP.HRMIS.Model;
using SEP.HRMIS.SqlServerDal;
using SEP.IBll;
using SEP.IBll.Positions;
using SEP.Model.Accounts;
using SEP.Model.Positions;

namespace SEP.HRMIS.Bll
{
    /// <summary>
    /// 新增职位历史
    /// </summary>
    public class AddPositionHistory : Transaction
    {
        private readonly Account _OperatorAccount;
        private readonly Position _Position;
        private IPositionHistory _DalPositionHistory = new PositionHistoryDal();
        private IEmployeeHistory _DalEmployeeHistory = new EmployeeHistoryDal();
        private GetEmployee _GetEmployee = new GetEmployee();
        private IPositionBll _IPositionBll = BllInstance.PositionBllInstance;
        private readonly DateTime _DtNow = DateTime.Now;
        /// <summary>
        /// 构造函数,当修改职位等级时调用
        /// </summary>
        public AddPositionHistory(Account operatorAccount)
        {
            _OperatorAccount = operatorAccount;
        }
        /// <summary>
        /// 构造函数,当修改某个职位时调用
        /// </summary>
        public AddPositionHistory(Account operatorAccount, Position position)
        {
            _OperatorAccount = operatorAccount;
            _Position = position;
        }
        /// <summary>
        /// 测试 员工
        /// </summary>
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
        }
        /// <summary>
        /// 测试 职位
        /// </summary>
        public IPositionBll MockIPositionBll
        {
            set { _IPositionBll = value; }
        }
        /// <summary>
        /// 测试 职位历史
        /// </summary>
        public IPositionHistory MockIPositionHistory
        {
            set { _DalPositionHistory = value; }
        }
        /// <summary>
        /// 测试 员工历史
        /// </summary>
        public IEmployeeHistory MockIEmployeeHistory
        {
            set { _DalEmployeeHistory = value; }
        }
        protected override void Validation()
        {
            //throw new NotImplementedException();
        }

        protected override void ExcuteSelf()
        {
            //using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required))
            //{
            BackUpPosition();
            if (_Position != null)
            {
                BackUpEmployee();
            }
            //    ts.Complete();
            //}
        }

        private void BackUpPosition()
        {
            List<Position> positionList = _IPositionBll.GetAllPosition();
            foreach (Position position in positionList)
            {
                PositionHistory positionHistory = new PositionHistory();
                positionHistory.Operator = _OperatorAccount;
                positionHistory.Position = _IPositionBll.GetPositionById(position.Id, null);
                positionHistory.Position.Grade = new PositionGrade(0, "", "");
                positionHistory.Position.Grade.Sequence = 0;
                positionHistory.OperationTime = _DtNow;
                _DalPositionHistory.CreatePositionHistory(positionHistory);
            }
        }
        private void BackUpEmployee()
        {
            List<Employee> employeelist =
                _GetEmployee.GetEmployeeByBasicCondition("", EmployeeTypeEnum.All, _Position.ParameterID, -1, false);
            foreach (Employee employee in employeelist)
            {
                EmployeeHistory employeeHistory =
                    new EmployeeHistory(employee, _DtNow, _OperatorAccount, "职位修改生成员工历史");
                _DalEmployeeHistory.CreateEmployeeHistory(employeeHistory);
            }

        }
    }
}
