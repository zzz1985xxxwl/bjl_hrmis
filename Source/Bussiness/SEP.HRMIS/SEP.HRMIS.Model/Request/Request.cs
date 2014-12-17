//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: Request.cs
// 创建者: xue.wenlong
// 创建日期: 2008-11-25
// 概述: 对于加班，外出和请假都要查询时的统一的对外model
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
        /// 申请人
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
        /// 开始时间
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
        /// 结束时间
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
        /// 申请小时
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
        /// 类型为界面显示
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
                    return "加班";
                }
                else if (_OutApplication != null)
                {
                    if (_OutApplication.OutType.ID == OutType.OutCity.ID)
                    {
                        return "出差";
                    }
                    else if (_OutApplication.OutType.ID == OutType.InCity.ID)
                    {
                        return "市内外出";
                    }
                    else
                    {
                        return "培训外出";
                    }
                }
                return "";
            }
        }


        ///<summary>
        /// 为界面显示
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
                            _ItemsShow = string.Format("{4}<tr><td>{0}~{1} {2}小时 {3}</td></tr>",
                                                       RequestUtility.GetDateWithOutYear(item.FromDate),
                                                       RequestUtility.GetDateWithOutYear(item.ToDate), item.CostTime,
                                                       RequestStatus.FindRequestStatus(item.RequestStatuss.Id).Name,
                                                       _ItemsShow);

                            break;
                        case RequestType.Out:
                            _ItemsShow = string.Format("{4}<tr><td>{0}~{1} {2}小时 {3}</td></tr>",
                                                       RequestUtility.GetDateWithOutYear(item.FromDate),
                                                       RequestUtility.GetDateWithOutYear(item.ToDate), item.CostTime,
                                                       RequestStatus.FindRequestStatus(item.RequestStatuss.Id).Name,
                                                       _ItemsShow);
                            break;
                        case RequestType.OverWork:
                            _ItemsShow = string.Format("{4}<tr><td>{0}~{1} {2}小时 {3}</td></tr>",
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
        /// 为界面显示
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
                            _ItemsShow = string.Format("{4}{0}~{1} {2}小时 {3}；",
                                                       RequestUtility.GetDateWithOutYear(item.FromDate),
                                                       RequestUtility.GetDateWithOutYear(item.ToDate), item.CostTime,
                                                       RequestStatus.FindRequestStatus(item.RequestStatuss.Id).Name,
                                                       _ItemsShow);

                            break;
                        case RequestType.Out:
                            _ItemsShow = string.Format("{4}{0}~{1} {2}小时 {3}；",
                                                       RequestUtility.GetDateWithOutYear(item.FromDate),
                                                       RequestUtility.GetDateWithOutYear(item.ToDate), item.CostTime,
                                                       RequestStatus.FindRequestStatus(item.RequestStatuss.Id).Name,
                                                       _ItemsShow);
                            break;
                        case RequestType.OverWork:
                            _ItemsShow = string.Format("{4}{0}~{1} {2}小时 {3}；",
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
        /// 其他信息显示
        /// </summary>
        public string MoreDetailExcel
        {
            get
            {
                string retString = string.Empty;
                if (_LeaveRequest != null)
                {
                    retString += "请假类型：" + _LeaveRequest.LeaveRequestType.Name;
                    retString += "； " + "申请原因：" + _LeaveRequest.Reason;
                }
                else if (_OverWork != null)
                {
                    retString += "加班项目：" + _OverWork.ProjectName;
                    retString += "； " + "申请原因：" + _OverWork.Reason;
                }
                else
                {
                    retString += "外出地点：" + _OutApplication.OutLocation;
                    retString += "； " + "申请原因：" + _OutApplication.Reason;
                }
                return retString.Replace("\r\n", "").Replace("\n", "");
            }
        }
        /// <summary>
        /// 其他信息显示
        /// </summary>
        public string MoreDetailShow
        {
            get
            {
                string retString = string.Empty;
                if (_LeaveRequest != null)
                {
                    retString += "请假类型：" + _LeaveRequest.LeaveRequestType.Name;
                    retString += "；</br>" + "申请原因：" + _LeaveRequest.Reason;
                }
                else if (_OverWork != null)
                {
                    retString += "加班项目：" + _OverWork.ProjectName;
                    retString += "；</br>" + "申请原因：" + _OverWork.Reason;
                }
                else
                {
                    retString += "外出地点：" + _OutApplication.OutLocation;
                    retString += "；</br>" + "申请原因：" + _OutApplication.Reason;
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

        ///<summary>
        /// 状态
        ///</summary>
        public RequestStatus RequestStatuss
        {
            get { return _RequestStatuss; }
            set { _RequestStatuss = value; }
        }

        /// <summary>
        /// 时间
        /// </summary>
        public decimal CostTime
        {
            get { return _CostTime; }
            set { _CostTime = value; }
        }
    }
}