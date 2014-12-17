//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: OverWork.cs
// Creater:  Xue.wenlong
// Date:  2009-05-08
// Resume:
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.OverWork
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class OverWork
    {
        private string _ProjectName;
        private Account _Account;
        private int _PKID;
        private DateTime _SubmitDate;
        private string _Reason;
        private List<OverWorkItem> _OverWorkItems = new List<OverWorkItem>();
        private DateTime _FromDate;
        private DateTime _ToDate;
        private Decimal _CostTime;
        private DiyProcess _DiyProcess;
        private decimal _SurplusAdjustRest;
        /// <summary>
        /// 
        /// </summary>
        public OverWork(int id, Account account, DateTime submitDate, string reason, DateTime fromDate,
                        DateTime toDate, decimal costTime,
                        List<OverWorkItem> items, string porjectName)
        {
            _PKID = id;
            _SubmitDate = submitDate;
            _Reason = reason;
            _Account = account;
            _OverWorkItems = items;
            _FromDate = fromDate;
            _ToDate = toDate;
            _CostTime = costTime;
            _ProjectName = porjectName;
        }
        /// <summary>
        /// 剩余调休
        /// </summary>
        public decimal SurplusAdjustRest
        {
            get { return _SurplusAdjustRest; }
            set { _SurplusAdjustRest = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }

        /// <summary>
        /// 编号
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        /// <summary>
        /// 递交日期
        /// </summary>
        public DateTime SubmitDate
        {
            get { return _SubmitDate; }
            set { _SubmitDate = value; }
        }

        /// <summary>
        /// 原因
        /// </summary>
        public string Reason
        {
            get { return _Reason; }
            set { _Reason = value; }
        }

        /// <summary>
        /// 加班项
        /// </summary>
        public List<OverWorkItem> Item
        {
            get { return _OverWorkItems; }
            set { _OverWorkItems = value; }
        }

        /// <summary>
        /// 申请人
        /// </summary>
        public Account Account
        {
            get { return _Account; }
            set { _Account = value; }
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
        /// 自定义流程
        /// </summary>
        public DiyProcess DiyProcess
        {
            get { return _DiyProcess; }
            set { _DiyProcess = value; }
        }

        #region 其他属性

        private bool _IfEdit;

        /// <summary>
        /// 是否可以编辑，如果已经被审核过则不能被编辑
        /// </summary>
        public bool IfEdit
        {
            get
            {
                if (_OverWorkItems != null && _OverWorkItems.Count > 0)
                {
                    foreach (OverWorkItem item in _OverWorkItems)
                    {
                        if (item.Status != RequestStatus.New)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return _IfEdit;
            }
            set { _IfEdit = value; }
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
                if (_OverWorkItems != null && _OverWorkItems.Count > 0)
                {
                    foreach (OverWorkItem item in _OverWorkItems)
                    {
                        if (item.Status == RequestStatus.Submit || item.Status == RequestStatus.ApprovePass)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                return _IfCancel;
            }
            set { _IfCancel = value; }
        }
        /// <summary>
        /// 除了新增状态直接删除，其他都可以被自动取消
        /// </summary>
        public bool IfAutoCancel
        {
            get
            {
                if (_OverWorkItems != null && _OverWorkItems.Count > 0)
                {
                    foreach (OverWorkItem item in _OverWorkItems)
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
        /// <summary>
        /// 
        /// </summary>
        public string OutItemsShow
        {
            get
            {
                string ret = "";
                if (_OverWorkItems == null)
                {
                    return ret;
                }
                foreach (OverWorkItem item in _OverWorkItems)
                {
                    string adjust = item.Adjust ? "调休" : "不调休";
                    ret = string.Format("{5}<tr><td>{0}~{1} {2}小时 {3} {4}</td></tr>",
                                        RequestUtility.GetDateWithOutYear(item.FromDate),
                                        RequestUtility.GetDateWithOutYear(item.ToDate), item.CostTime,
                                        RequestStatus.FindRequestStatus(item.Status.Id).Name, adjust, ret);
                }
                return ret;
            }
        }
        /// <summary>
        /// 查找overwork
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public static OverWork FindOverWorkByPKID(List<OverWork> list, int pkid)
        {
            foreach (OverWork work in list)
            {
                if (work.PKID == pkid)
                {
                    return work;
                }
            }
            return null;
        }
        public bool IsContainOverWorkItemByItemID(int itemid)
        {
            if (_OverWorkItems == null)
            {
                return false;
            }
            foreach (OverWorkItem item in _OverWorkItems)
            {
                if (item.ItemID == itemid)
                {
                    return true;
                }
            }
            return false;
        }
        public OverWorkItem FindOverWorkItemByItemID(int itemid)
        {
            if (_OverWorkItems == null)
            {
                return null;
            }
            return OverWorkItem.FindOverWorkItemByID(_OverWorkItems, itemid);
        }

        #endregion
    }
}