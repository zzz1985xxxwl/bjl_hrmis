using System;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.Request
{
    /// <summary>
    /// �������
    /// </summary>
    public class LeaveRequestFlow
    {
        private int _LeaveRequestFlowID;
        private LeaveRequestItem _LeaveRequestItem;
        private Account _Account;
        private DateTime _OperationTime;
        private string _Remark;
        private RequestStatus _LeaveRequestStatus;

        #region ����

        /// <summary>
        /// ������̱��
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
        /// ��ٵ�
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
        /// ������
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
        /// ����ʱ��
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
        /// ��ע
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
        /// �������
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

        #region ����

        /// <summary>
        /// �������
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
