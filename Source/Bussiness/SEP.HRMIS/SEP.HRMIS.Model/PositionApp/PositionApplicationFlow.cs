using System;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.PositionApp
{
    [Serializable]
    public class PositionApplicationFlow
    {
        private int _PKID;
        private int _PositionApplicationID;
        private Account _Account;
        private DateTime _OperationTime;
        private string _Remark;
        private RequestStatus _Status;
        private PositionApplication _Detail;

        public PositionApplicationFlow(int pkid, int positionApplicationID, Account account, DateTime time,
            RequestStatus status, string remark, PositionApplication detail)
        {
            _PKID = pkid;
            _PositionApplicationID = positionApplicationID;
            _Account = account;
            _OperationTime = time;
            _Status = status;
            _Remark = remark;
            _Detail = detail;
        }

        #region 属性

        /// <summary>
        /// 在此流程的职位申请快照
        /// </summary>
        public PositionApplication Detail
        {
            get
            {
                return _Detail;
            }
            set
            {
                _Detail = value;
            }
        }

        /// <summary>
        /// 流程编号
        /// </summary>
        public int PKID
        {
            get
            {
                return _PKID;
            }
            set
            {
                _PKID = value;
            }
        }

        /// <summary>
        /// 流程编号
        /// </summary>
        public int PositionApplicationID
        {
            get
            {
                return _PositionApplicationID;
            }
            set
            {
                _PositionApplicationID = value;
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
        public RequestStatus Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 是否审核通过
        /// </summary>
        public bool IsApprovePass()
        {
            if (Status.Equals(RequestStatus.ApprovePass))
            {
                return true;
            }
            return false;
        }

        #endregion
    }
}
