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
    /// ����ְλ��ʷ
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
        /// ���캯��,���޸�ְλ�ȼ�ʱ����
        /// </summary>
        public AddPositionHistory(Account operatorAccount)
        {
            _OperatorAccount = operatorAccount;
        }
        /// <summary>
        /// ���캯��,���޸�ĳ��ְλʱ����
        /// </summary>
        public AddPositionHistory(Account operatorAccount, Position position)
        {
            _OperatorAccount = operatorAccount;
            _Position = position;
        }
        /// <summary>
        /// ���� Ա��
        /// </summary>
        public GetEmployee MockGetEmployee
        {
            set { _GetEmployee = value; }
        }
        /// <summary>
        /// ���� ְλ
        /// </summary>
        public IPositionBll MockIPositionBll
        {
            set { _IPositionBll = value; }
        }
        /// <summary>
        /// ���� ְλ��ʷ
        /// </summary>
        public IPositionHistory MockIPositionHistory
        {
            set { _DalPositionHistory = value; }
        }
        /// <summary>
        /// ���� Ա����ʷ
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
                    new EmployeeHistory(employee, _DtNow, _OperatorAccount, "ְλ�޸�����Ա����ʷ");
                _DalEmployeeHistory.CreateEmployeeHistory(employeeHistory);
            }

        }
    }
}
