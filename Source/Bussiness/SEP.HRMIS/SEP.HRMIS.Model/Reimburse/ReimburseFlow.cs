using System;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class ReimburseFlow
    {
        private int _ReimburseFlowID;
        private Employee _Operator;
        private DateTime _OperationTime;
        private ReimburseStatusEnum _ReimburseStatusEnum;

        public ReimburseFlow(Employee _operator, DateTime operatorTime, ReimburseStatusEnum reimburseStatusEnum)
        {
            _Operator = _operator;
            _OperationTime = operatorTime;
            _ReimburseStatusEnum = reimburseStatusEnum;
        }
        public int ReimburseID { get; set; }
        public int ReimburseFlowID
        {
            get
            {
                return _ReimburseFlowID;
            }
            set
            {
                _ReimburseFlowID = value;
            }

        }
        public Employee Operator
        {
            get
            {
                return _Operator;
            }
            set
            {
                _Operator = value;
            }

        }
        public DateTime OperationTime
        {
            get
            {
                return _OperationTime;
            }
            set
            {
                _OperationTime = value;
            }

        }
        public ReimburseStatusEnum ReimburseStatusEnum
        {
            get
            {
                return _ReimburseStatusEnum;
            }
            set
            {
                _ReimburseStatusEnum = value;
            }

        }
    }
}
