//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWorkItem.cs
// Creater:  Xue.wenlong
// Date:  2009-05-08
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.Request;

namespace SEP.HRMIS.Model.OverWork
{
    /// <summary>
    /// </summary>
    [Serializable]
    public class OverWorkItem
    {
        private int _ItemID;
        private DateTime _FromDate;
        private DateTime _ToDate;
        private Decimal _CostTime;
        private RequestStatus _Status;
        private List<OverWorkFlow> _OverWorkFlow;
        private OverWorkType _OverWorkType;
        private bool _Adjuset;
        private decimal _AdjustHour;
        private int _OverWorkID;
        /// <summary>
        /// �Ӱ���
        /// </summary>
        public OverWorkItem(int itemID, DateTime fromDate, DateTime toDate, Decimal costTime, RequestStatus status,
                            OverWorkType overWorkType, bool adjust,decimal adjustHour)
        {
            _ItemID = itemID;
            _FromDate = fromDate;
            _ToDate = toDate;
            _CostTime = costTime;
            _Status = status;
            _OverWorkType = overWorkType;
            _Adjuset = adjust;
            _AdjustHour = adjustHour;
        }

        /// <summary>
        /// </summary>
        public OverWorkItem(int itemID)
        {
            _ItemID = itemID;
        }

        /// <summary>
        /// �������
        /// </summary>
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }

        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public DateTime FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }

        /// <summary>
        /// ʱ��Σ���Сʱ��
        /// </summary>
        public Decimal CostTime
        {
            get { return _CostTime; }
            set { _CostTime = value; }
        }

        /// <summary>
        /// ״̬
        /// </summary>
        public RequestStatus Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public List<OverWorkFlow> OverWorkFlow
        {
            get { return _OverWorkFlow; }
            set { _OverWorkFlow = value; }
        }


        /// <summary>
        /// �Ӱ�����
        /// </summary>
        public OverWorkType OverWorkType
        {
            get { return _OverWorkType; }
            set { _OverWorkType = value; }
        }

        /// <summary>
        /// �Ƿ������
        /// </summary>
        public bool Adjust
        {
            get { return _Adjuset; }
            set { _Adjuset = value; }
        }

        /// <summary>
        /// �Ӱ���������
        /// </summary>
        public string OverWorkTypeName
        {
            get { return OverWorkUtility.GetOverWorkTypeName(OverWorkType); }
        }

        /// <summary>
        /// ��intת�ɵ���
        /// </summary>
        public static bool IntToAdjust(int i)
        {
            return i == 1;
        }

        /// <summary>
        /// ������ת��int
        /// </summary>
        public static int AdjustToInt(bool adjust)
        {
            return adjust ? 1 : 0;
        }
        
        /// <summary> 
        /// </summary>
        public decimal AdjustHour
        {
            get { return _AdjustHour; }
            set { _AdjustHour = value; }
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
        public int OverWorkID
        {
            get { return _OverWorkID; }
            set { _OverWorkID = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="OverWorkItems"></param>
        /// <param name="itemid"></param>
        /// <returns></returns>
        public static OverWorkItem FindOverWorkItemByID(List<OverWorkItem> OverWorkItems, int itemid)
        {
            foreach (OverWorkItem item in OverWorkItems)
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
        public bool IsContainOverWorkFlowByRequestStatus(RequestStatus RequestStatus)
        {
            if (_OverWorkFlow == null)
            {
                return false;
            }

            foreach (OverWorkFlow flow in _OverWorkFlow)
            {
                if (RequestStatus.Id == flow.Operation.Id)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// �жϵ���
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(OverWorkItem obj)
        {
            return obj.FromDate == _FromDate
                   && obj.ToDate == _ToDate
                   && obj.CostTime == _CostTime;
        }
    }
}