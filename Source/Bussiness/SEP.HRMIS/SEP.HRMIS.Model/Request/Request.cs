//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: Request.cs
// ������: xue.wenlong
// ��������: 2008-11-25
// ����: ���ڼӰ࣬�������ٶ�Ҫ��ѯʱ��ͳһ�Ķ���model
// ----------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.OutApplication;
using SEP.HRMIS.Model.OverWork;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.Request
{
    /// <summary>
    /// </summary>
    public class Request
    {
        private readonly LeaveRequest _LeaveRequest;
        private readonly OutApplication.OutApplication _OutApplication;
        private readonly OverWork.OverWork _OverWork;
        private string _ItemsShow;

        /// <summary>
        /// </summary>
        public Request(LeaveRequest request)
        {
            _LeaveRequest = request;
        }

        /// <summary>
        /// </summary>
        public Request(OutApplication.OutApplication request)
        {
            _OutApplication = request;
        }

        /// <summary>
        /// </summary>
        public Request(OverWork.OverWork request)
        {
            _OverWork = request;
        }

        /// <summary>
        /// 
        /// </summary>
        public int PKID
        {
            get
            {
                if (_LeaveRequest != null)
                {
                    return _LeaveRequest.PKID;
                }
                else if (_OverWork != null)
                {
                    return _OverWork.PKID;
                }
                else
                {
                    return _OutApplication.PKID;
                }
            }
        }

        /// <summary>
        /// ������
        /// </summary>
        public Account Account
        {
            get
            {
                if (_LeaveRequest != null)
                {
                    return _LeaveRequest.Account;
                }
                else if (_OverWork != null)
                {
                    return _OverWork.Account;
                }
                else
                {
                    return _OutApplication.Account;
                }
            }
        }

        /// <summary>
        /// </summary>
        public List<RequestItem> Item
        {
            get
            {
                List<RequestItem> requestitems = new List<RequestItem>();
                if (_LeaveRequest != null)
                {
                    requestitems.Clear();
                    foreach (LeaveRequestItem item in _LeaveRequest.LeaveRequestItems)
                    {
                        requestitems.Add(new RequestItem(item.FromDate, item.ToDate, item.Status, item.CostTime));
                    }
                }
                else if (_OverWork != null)
                {
                    requestitems.Clear();
                    foreach (OverWorkItem item in _OverWork.Item)
                    {
                        requestitems.Add(new RequestItem(item.FromDate, item.ToDate, item.Status, item.CostTime));
                    }
                }
                else
                {
                    requestitems.Clear();
                    foreach (OutApplicationItem item in _OutApplication.Item)
                    {
                        requestitems.Add(new RequestItem(item.FromDate, item.ToDate, item.Status, item.CostTime));
                    }
                }
                return requestitems;
            }
        }

        /// <summary>
        /// </summary>
        public RequestType RequestType
        {
            get
            {
                if (_LeaveRequest != null)
                {
                    return RequestType.Leave;
                }
                else if (_OverWork != null)
                {
                    return RequestType.OverWork;
                }
                else
                {
                    return RequestType.Out;
                }
            }
        }

        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public DateTime? FromDate
        {
            get
            {
                if (_LeaveRequest != null)
                {
                    return _LeaveRequest.FromDate;
                }
                else if (_OverWork != null)
                {
                    return _OverWork.FromDate;
                }
                else
                {
                    return _OutApplication.FromDate;
                }
            }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? ToDate
        {
            get
            {
                if (_LeaveRequest != null)
                {
                    return _LeaveRequest.ToDate;
                }
                else if (_OverWork != null)
                {
                    return _OverWork.ToDate;
                }
                else
                {
                    return _OutApplication.ToDate;
                }
            }
        }

        /// <summary>
        /// ����Сʱ
        /// </summary>
        public decimal RequestTime
        {
            get
            {
                if (_LeaveRequest != null)
                {
                    return _LeaveRequest.CostTime;
                }
                else if (_OverWork != null)
                {
                    return _OverWork.CostTime;
                }
                else
                {
                    return _OutApplication.CostTime;
                }
            }
        }

        /// <summary>
        /// ����Ϊ������ʾ
        /// </summary>
        public string RequestTypeShow
        {
            get
            {
                if (_LeaveRequest != null)
                {
                    return _LeaveRequest.LeaveRequestType.Name;
                }
                else if (_OverWork != null)
                {
                    return "�Ӱ�";
                }
                else if (_OutApplication != null)
                {
                    if (_OutApplication.OutType.ID == OutType.OutCity.ID)
                    {
                        return "����";
                    }
                    else if (_OutApplication.OutType.ID == OutType.InCity.ID)
                    {
                        return "�������";
                    }
                    else
                    {
                        return "��ѵ���";
                    }
                }
                return "";
            }
        }


        ///<summary>
        /// Ϊ������ʾ
        ///</summary>
        public string ItemsShow
        {
            get
            {
                _ItemsShow = "";
                if (Item == null)
                {
                    return _ItemsShow;
                }
                foreach (RequestItem item in Item)
                {
                    switch (RequestType)
                    {
                        case RequestType.Leave:
                            _ItemsShow = string.Format("{4}<tr><td>{0}~{1} {2}Сʱ {3}</td></tr>",
                                                       RequestUtility.GetDateWithOutYear(item.FromDate),
                                                       RequestUtility.GetDateWithOutYear(item.ToDate), item.CostTime,
                                                       RequestStatus.FindRequestStatus(item.RequestStatuss.Id).Name,
                                                       _ItemsShow);

                            break;
                        case RequestType.Out:
                            _ItemsShow = string.Format("{4}<tr><td>{0}~{1} {2}Сʱ {3}</td></tr>",
                                                       RequestUtility.GetDateWithOutYear(item.FromDate),
                                                       RequestUtility.GetDateWithOutYear(item.ToDate), item.CostTime,
                                                       RequestStatus.FindRequestStatus(item.RequestStatuss.Id).Name,
                                                       _ItemsShow);
                            break;
                        case RequestType.OverWork:
                            _ItemsShow = string.Format("{4}<tr><td>{0}~{1} {2}Сʱ {3}</td></tr>",
                                                       RequestUtility.GetDateWithOutYear(item.FromDate),
                                                       RequestUtility.GetDateWithOutYear(item.ToDate), item.CostTime,
                                                       RequestStatus.FindRequestStatus(item.RequestStatuss.Id).Name,
                                                       _ItemsShow);
                            break;
                        default:
                            _ItemsShow = "";
                            break;
                    }
                }
                return _ItemsShow;
            }
        }

        ///<summary>
        /// Ϊ������ʾ
        ///</summary>
        public string ItemsExcel
        {
            get
            {
                _ItemsShow = "";
                if (Item == null)
                {
                    return _ItemsShow;
                }
                foreach (RequestItem item in Item)
                {
                    switch (RequestType)
                    {
                        case RequestType.Leave:
                            _ItemsShow = string.Format("{4}{0}~{1} {2}Сʱ {3}��",
                                                       RequestUtility.GetDateWithOutYear(item.FromDate),
                                                       RequestUtility.GetDateWithOutYear(item.ToDate), item.CostTime,
                                                       RequestStatus.FindRequestStatus(item.RequestStatuss.Id).Name,
                                                       _ItemsShow);

                            break;
                        case RequestType.Out:
                            _ItemsShow = string.Format("{4}{0}~{1} {2}Сʱ {3}��",
                                                       RequestUtility.GetDateWithOutYear(item.FromDate),
                                                       RequestUtility.GetDateWithOutYear(item.ToDate), item.CostTime,
                                                       RequestStatus.FindRequestStatus(item.RequestStatuss.Id).Name,
                                                       _ItemsShow);
                            break;
                        case RequestType.OverWork:
                            _ItemsShow = string.Format("{4}{0}~{1} {2}Сʱ {3}��",
                                                       RequestUtility.GetDateWithOutYear(item.FromDate),
                                                       RequestUtility.GetDateWithOutYear(item.ToDate), item.CostTime,
                                                       RequestStatus.FindRequestStatus(item.RequestStatuss.Id).Name,
                                                       _ItemsShow);
                            break;
                        default:
                            _ItemsShow = "";
                            break;
                    }
                }
                return _ItemsShow;
            }
        }
        /// <summary>
        /// ������Ϣ��ʾ
        /// </summary>
        public string MoreDetailExcel
        {
            get
            {
                string retString = string.Empty;
                if (_LeaveRequest != null)
                {
                    retString += "������ͣ�" + _LeaveRequest.LeaveRequestType.Name;
                    retString += "�� " + "����ԭ��" + _LeaveRequest.Reason;
                }
                else if (_OverWork != null)
                {
                    retString += "�Ӱ���Ŀ��" + _OverWork.ProjectName;
                    retString += "�� " + "����ԭ��" + _OverWork.Reason;
                }
                else
                {
                    retString += "����ص㣺" + _OutApplication.OutLocation;
                    retString += "�� " + "����ԭ��" + _OutApplication.Reason;
                }
                return retString.Replace("\r\n", "").Replace("\n", "");
            }
        }
        /// <summary>
        /// ������Ϣ��ʾ
        /// </summary>
        public string MoreDetailShow
        {
            get
            {
                string retString = string.Empty;
                if (_LeaveRequest != null)
                {
                    retString += "������ͣ�" + _LeaveRequest.LeaveRequestType.Name;
                    retString += "��</br>" + "����ԭ��" + _LeaveRequest.Reason;
                }
                else if (_OverWork != null)
                {
                    retString += "�Ӱ���Ŀ��" + _OverWork.ProjectName;
                    retString += "��</br>" + "����ԭ��" + _OverWork.Reason;
                }
                else
                {
                    retString += "����ص㣺" + _OutApplication.OutLocation;
                    retString += "��</br>" + "����ԭ��" + _OutApplication.Reason;
                }
                return retString;
            }
        }
    }


    /// <summary>
    /// </summary>
    public enum RequestType
    {
        /// <summary>
        /// </summary>
        OverWork,
        /// <summary>
        /// </summary>
        Out,
        /// <summary>
        /// </summary>
        Leave
    }


    /// <summary>
    /// </summary>
    public class RequestItem
    {
        private DateTime _FromDate;
        private DateTime _ToDate;
        private RequestStatus _RequestStatuss;
        private decimal _CostTime;

        /// <summary>
        /// </summary>
        public RequestItem(DateTime fromDate, DateTime toDate,
                           RequestStatus requestStatuss, decimal costTime)
        {
            _FromDate = fromDate;
            _ToDate = toDate;
            _RequestStatuss = requestStatuss;
            _CostTime = costTime;
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

        ///<summary>
        /// ״̬
        ///</summary>
        public RequestStatus RequestStatuss
        {
            get { return _RequestStatuss; }
            set { _RequestStatuss = value; }
        }

        /// <summary>
        /// ʱ��
        /// </summary>
        public decimal CostTime
        {
            get { return _CostTime; }
            set { _CostTime = value; }
        }
    }
}