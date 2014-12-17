using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.Request
{
    /// <summary>
    /// 请假
    /// </summary>
    [Serializable]
    public class LeaveRequest
    {
        #region 私有变量

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

        #region 构造函数

        /// <summary>
        /// 请假
        /// </summary>
        public LeaveRequest()
        {
            _LeaveRequestItems = new List<LeaveRequestItem>();
        }

        /// <summary>
        /// 请假
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

        #region 属性

        /// <summary>
        /// 请假单编号
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
        /// 递交日期
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
        /// 原因
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
        /// 请假项
        /// </summary>
        public List<LeaveRequestItem> LeaveRequestItems
        {
            get { return _LeaveRequestItems; }
            set { _LeaveRequestItems = value; }
        }

        /// <summary>
        /// 请假类型
        /// </summary>
        public LeaveRequestType LeaveRequestType
        {
            get { return _LeaveRequestType; }
            set { _LeaveRequestType = value; }
        }

        /// <summary>
        /// 账号
        /// </summary>
        public Account Account
        {
            get { return _Account; }
            set { _Account = value; }
        }

        /// <summary>
        /// 开始时间
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
        /// 结束时间
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
        /// 时间段，按小时计
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
        /// 自定义流程
        /// </summary>
        public DiyProcess DiyProcess
        {
            get { return _DiyProcess; }
            set { _DiyProcess = value; }
        }

        #endregion

        #region 其他属性

        private bool _IfEdit;
        /// <summary>
        /// 是否可以编辑，如果已经被审核过则不能被编辑
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
        /// 是否可以取消，以下情况可以被取消
        /// 1 Item状态是提交
        /// 2 Item状态是审核通过
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
        /// 是否可以整张操作，有且只有所有item的状态相同时，才能对整张请假单进行同一个操作
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
        /// 为了界面显示Item
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
                    ret = string.Format("{4}<tr><td>{0}~{1} {2}小时 {3} </td></tr>",
                                        RequestUtility.GetDateWithOutYear(item.FromDate),
                                        RequestUtility.GetDateWithOutYear(item.ToDate), item.CostTime,
                                        RequestStatus.FindRequestStatus(item.Status.Id).Name, ret);

                    //ret = ret + "<tr><td>" + item.FromDate + "</td>"
                    //    + "<td align='left' width='5%'>" + " ～ " + "</td>"
                    //    + "<td align='left' width='25%'>" + item.ToDate + "</td>"
                    //    + "<td align='left' width='20%'>&nbsp;&nbsp;共" + item.CostTime + "小时&nbsp;&nbsp;</td>"
                    //    + "<td align='left' width='20%'>" + status + "</td></tr>";
                }
                return ret;
            }
        }
        /// <summary>
        /// 除了新增状态直接删除，其他都可以被自动取消
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
