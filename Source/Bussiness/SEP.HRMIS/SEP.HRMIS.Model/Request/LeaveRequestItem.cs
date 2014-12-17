using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.Model.Request
{
    /// <summary>
    /// 请假项
    /// </summary>
    [Serializable]
    public class LeaveRequestItem
    {
        private int _LeaveRequestItemID;
        private DateTime _FromDate;
        private DateTime _ToDate;
        private Decimal _CostTime;
        private RequestStatus _Status;
        private bool _IfCancel;
        private bool _IfApprove;
        private string _Remark;
        private DiyStep _CurrentStep;
        private int _LeaveRequestID;

        /// <summary>
        /// 请假项
        /// </summary>
        /// <param name="leaveRequestItemID"></param>
        public LeaveRequestItem(int leaveRequestItemID)
        {
            _LeaveRequestItemID = leaveRequestItemID;
        }

        /// <summary>
        /// 请假项
        /// </summary>
        public LeaveRequestItem(int leaveRequestItemID, DateTime fromDate, DateTime toDate, Decimal costTime,
                                RequestStatus status)
        {
            _LeaveRequestItemID = leaveRequestItemID;
            _FromDate = fromDate;
            _ToDate = toDate;
            _CostTime = costTime;
            _Status = status;
        }

        /// <summary>
        /// 请假项编号
        /// </summary>
        public int LeaveRequestItemID
        {
            get { return _LeaveRequestItemID; }
            set { _LeaveRequestItemID = value; }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        /// <summary>
        /// 时间段，按小时计
        /// </summary>
        public Decimal CostTime
        {
            get { return _CostTime; }
            set { _CostTime = value; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public RequestStatus Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        /// <summary>
        /// 是否可以取消
        /// </summary>
        public bool IfCancel
        {
            get
            {
                if (Status != null)
                {
                    if (Status == RequestStatus.Submit || Status == RequestStatus.ApprovePass)
                    {
                        _IfCancel = true;
                    }
                    else
                    {
                        _IfCancel = false;
                    }
                }
                return _IfCancel;
            }
            set { _IfCancel = value; }
        }

        /// <summary>
        /// 是否可以审核
        /// </summary>
        public bool IfApprove
        {
            get
            {
                if (Status != null)
                {
                    if (Status == RequestStatus.Cancelled || Status == RequestStatus.Submit)
                    {
                        _IfApprove = true;
                    }
                    else
                    {
                        _IfApprove = false;
                    }
                }
                return _IfApprove;
            }
            set { _IfApprove = value; }
        }

        /// <summary>
        /// 用来存储取消、审批理由，为了界面需要
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        /// <summary>
        /// 当前步骤
        /// </summary>
        public DiyStep CurrentStep
        {
            get { return _CurrentStep; }
            set { _CurrentStep = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int LeaveRequestID
        {
            get { return _LeaveRequestID; }
            set { _LeaveRequestID = value; }
        }

        private string _UseList;

        /// <summary>
        /// vacationid,vacationid/使用小时,使用天数 例如 2123,8/4123,16
        /// adjustid ,adjustid/使用小时
        /// </summary>
        public string UseList
        {
            get
            {
                if (!string.IsNullOrEmpty(_UseList))
                {
                    if (_UseList.EndsWith("/"))
                    {
                        _UseList = _UseList.Substring(0, _UseList.Length - 1);
                    }
                }
                return _UseList;
            }
            set { _UseList = value; }
        }
        /// <summary>
        ///  判断LeaveRequestFlows中是否有过RequestStatus的状态
        /// </summary>
        /// <param name="LeaveRequestFlows"></param>
        /// <param name="RequestStatus"></param>
        /// <returns></returns>
        public static bool IsContainByRequestStatus(List<LeaveRequestFlow> LeaveRequestFlows, RequestStatus RequestStatus)
        {
            foreach (LeaveRequestFlow flow in LeaveRequestFlows)
            {
                if (flow.LeaveRequestStatus.Id == RequestStatus.Id)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LeaveRequestItems"></param>
        /// <param name="itemid"></param>
        /// <returns></returns>
        public static LeaveRequestItem FindLeaveRequestItemByID(List<LeaveRequestItem> LeaveRequestItems, int itemid)
        {
            foreach (LeaveRequestItem item in LeaveRequestItems)
            {
                if (item.LeaveRequestItemID == itemid)
                {
                    return item;
                }
            }
            return null;
        }
        /// <summary>
        /// 判断等于
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(LeaveRequestItem obj)
        {
            return obj.FromDate == _FromDate
                   && obj.ToDate == _ToDate
                   && obj.CostTime == _CostTime;
        }
    }
}