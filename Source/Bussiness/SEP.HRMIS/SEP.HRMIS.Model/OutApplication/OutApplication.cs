using System;
using System.Collections.Generic;
using SEP.HRMIS.Model.DiyProcesss;
using SEP.HRMIS.Model.Request;
using SEP.Model.Accounts;

namespace SEP.HRMIS.Model.OutApplication
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class OutApplication
    {
        private string _OutLocation;
        private OutType _OutType;
        private Account _Account;
        private int _PKID;
        private DateTime _SubmitDate;
        private string _Reason;
        private List<OutApplicationItem> _ApplicationItems = new List<OutApplicationItem>();
        private DateTime _FromDate;
        private DateTime _ToDate;
        private Decimal _CostTime;
        private DiyProcess _DiyProcess;

        /// <summary>
        /// 
        /// </summary>
        public OutApplication(int id, Account account, DateTime submitDate, string reason, DateTime fromDate,
                              DateTime toDate, decimal costTime,
                              List<OutApplicationItem> applicationList, string outLocation,OutType outType)
        {
            _PKID = id;
            _SubmitDate = submitDate;
            _Reason = reason;
            _Account = account;
            _ApplicationItems = applicationList;
            _FromDate = fromDate;
            _ToDate = toDate;
            _CostTime = costTime;
            _OutLocation = outLocation;
            _OutType = outType;
        }

        /// <summary>
        /// 
        /// </summary>
        public string OutLocation
        {
            get { return _OutLocation; }
            set { _OutLocation = value; }
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
        /// 请假项
        /// </summary>
        public List<OutApplicationItem> Item
        {
            get { return _ApplicationItems; }
            set { _ApplicationItems = value; }
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

        /// <summary>
        /// 是否可以编辑，如果已经被审核过则不能被编辑

        /// </summary>
        public bool IfEdit
        {
            get
            {
                if (_ApplicationItems != null && _ApplicationItems.Count > 0)
                {
                    foreach (OutApplicationItem item in _ApplicationItems)
                    {
                        if (item.Status != RequestStatus.New)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 是否可以取消，以下情况可以被取消
        /// 1 Item状态是提交
        /// 2 Item状态是审核通过
        /// </summary>
        public bool IfCancel
        {
            get
            {
                if (_ApplicationItems != null && _ApplicationItems.Count > 0)
                {
                    foreach (OutApplicationItem item in _ApplicationItems)
                    {
                        if (item.Status == RequestStatus.Submit || item.Status == RequestStatus.ApprovePass)
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
        /// 除了新增状态直接删除，其他都可以被自动取消
        /// </summary>
        public bool IfAutoCancel
        {
            get
            {
                if (_ApplicationItems != null && _ApplicationItems.Count > 0)
                {
                    foreach (OutApplicationItem item in _ApplicationItems)
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
                if (_ApplicationItems == null)
                {
                    return ret;
                }
                foreach (OutApplicationItem item in _ApplicationItems)
                {
                    ret = string.Format("{4}<tr><td>{0}~{1} {2}小时 {3}</td></tr>",
                                        RequestUtility.GetDateWithOutYear(item.FromDate),
                                        RequestUtility.GetDateWithOutYear(item.ToDate), item.CostTime,
                                        RequestStatus.FindRequestStatus(item.Status.Id).Name, ret);
                }
                return ret;
            }
        }
        /// <summary>
        /// 外出类型
        /// </summary>
        public OutType OutType
        {
            get { return _OutType; }
            set { _OutType = value; }
        }
        /// <summary>
        /// 查找overwork
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public static OutApplication FindOverWorkByPKID(List<OutApplication> list, int pkid)
        {
            foreach (OutApplication outApplication in list)
            {
                if (outApplication.PKID == pkid)
                {
                    return outApplication;
                }
            }
            return null;
        }
        public bool IsContainOutApplicationItemByItemID(int itemid)
        {
            if (_ApplicationItems == null)
            {
                return false;
            }
            foreach (OutApplicationItem item in _ApplicationItems)
            {
                if (item.ItemID == itemid)
                {
                    return true;
                }
            }
            return false;
        }
        public OutApplicationItem FindOutApplicationItemByItemID(int itemid)
        {
            if (_ApplicationItems == null)
            {
                return null;
            }
            return OutApplicationItem.FindOutApplicationItemByID(_ApplicationItems, itemid);
        }

        #endregion

    }
}