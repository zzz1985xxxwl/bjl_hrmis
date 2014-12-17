//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: ApplicationItem.cs
// Creater:  Xue.wenlong
// Date:  2009-04-13
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Model.OutApplication
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class OutApplicationItem
    {
        private int _ItemID;
        private DateTime _FromDate;
        private DateTime _ToDate;
        private Decimal _CostTime;
        private RequestStatus _Status;
        private List<OutApplicationFlow> _OutApplicationFlow;
        private bool _Adjuset;
        private decimal _AdjustHour;
        private int _OutApplicationID;
        /// <summary>
        /// 外出项
        /// </summary>
        public OutApplicationItem(int itemID, DateTime fromDate, DateTime toDate, Decimal costTime, RequestStatus status, bool adjust, decimal adjustHour)
        {
            _ItemID = itemID;
            _FromDate = fromDate;
            _ToDate = toDate;
            _CostTime = costTime;
            _Status = status;
            _Adjuset = adjust;
            _AdjustHour = adjustHour;
        }
        /// <summary>
        /// 
        /// </summary>
        public OutApplicationItem(int itemID)
        {
            _ItemID = itemID;
        }

        /// <summary>
        /// 请假项编号
        /// </summary>
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
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
        /// 流程
        /// </summary>
        public List<OutApplicationFlow> OutApplicationFlow
        {
            get { return _OutApplicationFlow; }
            set { _OutApplicationFlow = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int OutApplicationID
        {
            get { return _OutApplicationID; }
            set { _OutApplicationID = value; }
        }
        /// <summary> 
        /// </summary>
        public decimal AdjustHour
        {
            get { return _AdjustHour; }
            set { _AdjustHour = value; }
        }
        /// <summary>
        /// 是否给调休
        /// </summary>
        public bool Adjust
        {
            get { return _Adjuset; }
            set { _Adjuset = value; }
        }

        private bool _CanChangeAdjust;

        /// <summary> 
        /// </summary>
        public bool CanChangeAdjust
        {
            get { return _CanChangeAdjust; }
            set { _CanChangeAdjust = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="OutApplicationItems"></param>
        /// <param name="itemid"></param>
        /// <returns></returns>
        public static OutApplicationItem FindOutApplicationItemByID(List<OutApplicationItem> OutApplicationItems, int itemid)
        {
            foreach (OutApplicationItem item in OutApplicationItems)
            {
                if (item.ItemID == itemid)
                {
                    return item;
                }
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RequestStatus"></param>
        /// <returns></returns>
        public bool IsContainOutApplicationFlowByRequestStatus(RequestStatus RequestStatus)
        {
            if (_OutApplicationFlow == null)
            {
                return false;
            }

            foreach (OutApplicationFlow flow in _OutApplicationFlow)
            {
                if(RequestStatus.Id==flow.Operation.Id)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 判断等于
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(OutApplicationItem obj)
        {
            return obj.FromDate == _FromDate
                   && obj.ToDate == _ToDate
                   && obj.CostTime == _CostTime;
        }
    }
}