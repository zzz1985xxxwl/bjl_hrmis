using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.Request
{
    /// <summary>
    /// ���
    /// </summary>
    [Serializable]
    public class LeaveRequest
    {
        #region ˽�б���

        private Account _Account;
        private int _PKID;
        private DateTime _SubmitDate;
        private string _Reason;
        private List<LeaveRequestItem> _LeaveRequestItems;
        private LeaveRequestType _LeaveRequestType;
        private DateTime? _FromDate;
        private DateTime? _ToDate;
        private Decimal _CostTime;
        private DiyProcess _DiyProcess;
        #endregion

        #region ���캯��

        /// <summary>
        /// ���
        /// </summary>
        public LeaveRequest()
        {
            _LeaveRequestItems = new List<LeaveRequestItem>();
        }

        /// <summary>
        /// ���
        /// </summary>
        public LeaveRequest(int id, Account account, LeaveRequestType leaveRequestType, DateTime submitDate, string reason)
        {
            _PKID = id;
            _SubmitDate = submitDate;
            _Reason = reason;
            _Account = account;
            _LeaveRequestType = leaveRequestType;
            _LeaveRequestItems = new List<LeaveRequestItem>();
        }

        #endregion

        #region ����

        /// <summary>
        /// ��ٵ����
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
        /// �ݽ�����
        /// </summary>
        public DateTime SubmitDate
        {
            get
            {
                return _SubmitDate;
            }
            set
            {
                _SubmitDate = value;
            }
        }

        /// <summary>
        /// ԭ��
        /// </summary>
        public string Reason
        {
            get
            {
                return _Reason;
            }
            set
            {
                _Reason = value;
            }
        }

        /// <summary>
        /// �����
        /// </summary>
        public List<LeaveRequestItem> LeaveRequestItems
        {
            get { return _LeaveRequestItems; }
            set { _LeaveRequestItems = value; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public LeaveRequestType LeaveRequestType
        {
            get { return _LeaveRequestType; }
            set { _LeaveRequestType = value; }
        }

        /// <summary>
        /// �˺�
        /// </summary>
        public Account Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public DateTime? FromDate
        {
            get
            {
                if (_LeaveRequestItems != null && _LeaveRequestItems.Count > 0)
                {
                    DateTime? fromDate =  _LeaveRequestItems[0].FromDate;
                    foreach (LeaveRequestItem item in _LeaveRequestItems)
                    {
                        if (item.FromDate.CompareTo(fromDate) < 0)
                        {
                            fromDate = item.FromDate;
                        }
                    }
                    return fromDate;
                }
                return _FromDate;
            }
            set
            {
                _FromDate = value;
            }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? ToDate
        {
            get
            {
                if (_LeaveRequestItems != null && _LeaveRequestItems.Count > 0)
                {
                    DateTime? toDate = _LeaveRequestItems[0].ToDate;
                    foreach (LeaveRequestItem item in _LeaveRequestItems)
                    {
                        if (item.ToDate.CompareTo(toDate) > 0)
                        {
                            toDate = item.ToDate;
                        }
                    }
                    return toDate;
                }
                return _ToDate;
            }
            set
            {
                _ToDate = value;
            }
        }

        /// <summary>
        /// ʱ��Σ���Сʱ��
        /// </summary>
        public Decimal CostTime
        {
            get
            {
                if (_LeaveRequestItems != null && _LeaveRequestItems.Count > 0)
                {
                    decimal costTime = 0;
                    foreach (LeaveRequestItem item in _LeaveRequestItems)
                    {
                        costTime += item.CostTime;
                    }
                    return costTime;
                }
                return _CostTime;
            }
            set
            {
                _CostTime = value;
            }
        }

        /// <summary>
        /// �Զ�������
        /// </summary>
        public DiyProcess DiyProcess
        {
            get { return _DiyProcess; }
            set { _DiyProcess = value; }
        }

        #endregion

        #region ��������

        private bool _IfEdit;
        /// <summary>
        /// �Ƿ���Ա༭������Ѿ�����˹����ܱ��༭
        /// </summary>
        public bool IfEdit
        {
            get
            {
                if (_LeaveRequestItems != null && _LeaveRequestItems.Count > 0)
                {
                    foreach (LeaveRequestItem item in _LeaveRequestItems)
                    {
                        if(item.Status!= RequestStatus.New)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return _IfEdit;
            }
            set
            {
                _IfEdit = value;
            }
        }

        private bool _IfCancel;
        /// <summary>
        /// �Ƿ����ȡ��������������Ա�ȡ��
        /// 1 Item״̬���ύ
        /// 2 Item״̬�����ͨ��
        /// </summary>
        public bool IfCancel
        {
            get
            {
                if (_LeaveRequestItems != null && _LeaveRequestItems.Count > 0)
                {
                    foreach (LeaveRequestItem item in _LeaveRequestItems)
                    {
                        if (item.Status == RequestStatus.Submit || item.Status == RequestStatus.ApprovePass 
                            || item.Status == RequestStatus.Approving)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                return _IfCancel;
            }
            set
            {
                _IfCancel = value;
            }
        }

        private bool _IfWholeApprove;
        /// <summary>
        /// �Ƿ�������Ų���������ֻ������item��״̬��ͬʱ�����ܶ�������ٵ�����ͬһ������
        /// </summary>
        public bool IfWholeApprove
        {
            get
            {
                if (_LeaveRequestItems != null && _LeaveRequestItems.Count > 0)
                {
                    RequestStatus status = _LeaveRequestItems[0].Status;
                    foreach (LeaveRequestItem item in _LeaveRequestItems)
                    {
                        if (item.Status != status)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return _IfWholeApprove;
            }
            set
            {
                _IfWholeApprove = value;
            }
        }

        /// <summary>
        /// Ϊ�˽�����ʾItem
        /// </summary>
        public string LeaveRequestItemsShow
        {
            get
            {
                string ret = "";
                if (LeaveRequestItems == null)
                {
                    return ret;
                }
                foreach (LeaveRequestItem item in LeaveRequestItems)
                {
                    //string status = RequestStatus.LeaveRequestStatusDisplay(item.Status);
                    ret = string.Format("{4}<tr><td>{0}~{1} {2}Сʱ {3} </td></tr>",
                                        RequestUtility.GetDateWithOutYear(item.FromDate),
                                        RequestUtility.GetDateWithOutYear(item.ToDate), item.CostTime,
                                        RequestStatus.FindRequestStatus(item.Status.Id).Name, ret);

                    //ret = ret + "<tr><td>" + item.FromDate + "</td>"
                    //    + "<td align='left' width='5%'>" + " �� " + "</td>"
                    //    + "<td align='left' width='25%'>" + item.ToDate + "</td>"
                    //    + "<td align='left' width='20%'>&nbsp;&nbsp;��" + item.CostTime + "Сʱ&nbsp;&nbsp;</td>"
                    //    + "<td align='left' width='20%'>" + status + "</td></tr>";
                }
                return ret;
            }
        }
        /// <summary>
        /// ��������״ֱ̬��ɾ�������������Ա��Զ�ȡ��
        /// </summary>
        public bool IfAutoCancel
        {
            get
            {
                if (_LeaveRequestItems != null && _LeaveRequestItems.Count > 0)
                {
                    foreach (LeaveRequestItem item in _LeaveRequestItems)
                    {
                        if (item.Status != RequestStatus.New)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                return false;
            }

        }
        public bool IsContainLeaveRequestItemByItemID(int itemid)
        {
            if (_LeaveRequestItems == null)
            {
                return false;
            }
            foreach (LeaveRequestItem item in _LeaveRequestItems)
            {
                if (item.LeaveRequestItemID == itemid)
                {
                    return true;
                }
            }
            return false;
        }
        public LeaveRequestItem FindLeaveRequestItemByItemID(int itemid)
        {
            if (_LeaveRequestItems == null)
            {
                return null;
            }
            return LeaveRequestItem.FindLeaveRequestItemByID(_LeaveRequestItems, itemid);
        }

        public List<Account> MailCC { get; set; }
        #endregion
    }
}
