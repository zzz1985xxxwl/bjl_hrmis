using System;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.Request
{
    /// <summary>
    /// 请假流程
    /// </summary>
    public class LeaveRequestFlow
    {
        private int _LeaveRequestFlowID;
        private LeaveRequestItem _LeaveRequestItem;
        private Account _Account;
        private DateTime _OperationTime;
        private string _Remark;
        private RequestStatus _LeaveRequestStatus;

        #region 属性

        /// <summary>
        /// 请假流程编号
        /// </summary>
        public int LeaveRequestFlowID
        {
            get
            {
                return _LeaveRequestFlowID;
            }
            set
            {
                _LeaveRequestFlowID = value;
            }
        }

        /// <summary>
        /// 请假单
        /// </summary>
        public LeaveRequestItem LeaveRequestItem
        {
            get
            {
                return _LeaveRequestItem;
            }
            set
            {
                _LeaveRequestItem = value;
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
        /// 请假类型
        /// </summary>
        public RequestStatus LeaveRequestStatus
        {
            get
            {
                return _LeaveRequestStatus;
            }
            set
            {
                _LeaveRequestStatus = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 请假类型
        /// </summary>
        public bool IsApprovePass()
        {
            if ((LeaveRequestStatus.Equals(RequestStatus.ApprovePass))
                || (LeaveRequestStatus.Equals(RequestStatus.ApproveCancelPass)))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RequestStatus"></param>
        /// <returns></returns>
        public bool IsEqualByRequestStatus(RequestStatus RequestStatus)
        {
            if (RequestStatus.Id == _LeaveRequestStatus.Id)
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
