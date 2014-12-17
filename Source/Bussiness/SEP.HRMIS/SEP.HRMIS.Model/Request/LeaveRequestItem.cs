using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;

namespace SEP.HRMIS.Model.Request
{
    /// <summary>
    /// �����
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
        /// �����
        /// </summary>
        /// <param name="leaveRequestItemID"></param>
        public LeaveRequestItem(int leaveRequestItemID)
        {
            _LeaveRequestItemID = leaveRequestItemID;
        }

        /// <summary>
        /// �����
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
        /// �������
        /// </summary>
        public int LeaveRequestItemID
        {
            get { return _LeaveRequestItemID; }
            set { _LeaveRequestItemID = value; }
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
        /// �Ƿ����ȡ��
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
        /// �Ƿ�������
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
        /// �����洢ȡ�����������ɣ�Ϊ�˽�����Ҫ
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        /// <summary>
        /// ��ǰ����
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
        /// vacationid,vacationid/ʹ��Сʱ,ʹ������ ���� 2123,8/4123,16
        /// adjustid ,adjustid/ʹ��Сʱ
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
        ///  �ж�LeaveRequestFlows���Ƿ��й�RequestStatus��״̬
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
        /// �жϵ���
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