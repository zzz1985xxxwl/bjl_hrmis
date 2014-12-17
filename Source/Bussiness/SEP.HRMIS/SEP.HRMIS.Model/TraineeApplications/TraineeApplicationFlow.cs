using System;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.TraineeApplications
{
    public class TraineeApplicationFlow
    {
        private int _TraineeApplicationFlowID;
        private Account _Account;
        private DateTime _OperationTime;
        private string _Remark;
        private TraineeApplicationStatus _TraineeApplicationStatus;

        public TraineeApplicationFlow(Account account, DateTime time, TraineeApplicationStatus statuss)
        {
            _Account = account;
            _OperationTime = time;
            _TraineeApplicationStatus = statuss;
        }

        #region 属性

        /// <summary>
        /// 流程编号
        /// </summary>
        public int TraineeApplicationFlowID
        {
            get
            {
                return _TraineeApplicationFlowID;
            }
            set
            {
                _TraineeApplicationFlowID = value;
            }
        }

        /// <summary>
        /// 操作人
        /// </summary>
        public Account Account
        {
            get
            {
                return _Account;
            }
            set
            {
                _Account = value;
            }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
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

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }

        /// <summary>
        /// 类型
        /// </summary>
        public TraineeApplicationStatus TraineeApplicationStatus
        {
            get
            {
                return _TraineeApplicationStatus;
            }
            set
            {
                _TraineeApplicationStatus = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 是否审核通过
        /// </summary>
        public bool IsApprovePass()
        {
            if (TraineeApplicationStatus.Equals(TraineeApplicationStatus.ApprovePass))
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
