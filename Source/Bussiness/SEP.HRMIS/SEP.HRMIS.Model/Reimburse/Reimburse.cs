using System;
using System.Collections.Generic;
using SEP.Model.Accounts;
using SEP.Model.Departments;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class Reimburse
    {
        // 编号
        private int _ReimburseID;
        // 申请时间
        private DateTime _ApplyDate;
        // 部门
        private Department _Department;
        // 申请人ID
        private int _ApplierID;
        // 申请人
        private string _ApplerName;
        // 报销分类
        private ReimburseCategoriesEnum _ReimburseCategoriesEnum;
        // 单据张数
        private int _PaperCount;
        // 消费时间
        private DateTime _ConsumeDateFrom;
        private DateTime _ConsumeDateTo;
        // 目的地
        private string _Destinations;
        // 客户名
        //private string _CustomerID;
        // 项目
        private string _ProjectName;
        // 报销总额
        private decimal _TotalCost;
        // 提交时间
        private string _CommitTime;
        // 记账时间
        private string _BillingTime;
        //// 流程
        //private DiyProcess _DiyProcess;
        //// 下一步流程
        //private int _NextStepIndex;
        // 报销状态
        private ReimburseStatusEnum _ReimburseStatus;
        // 报销项
        private List<ReimburseItem> _ReimburseItems;
        // 报销记录
        private List<ReimburseFlow> _ReimburseFlows;

        private decimal _OutCityDays;
        private decimal _OutCityAllowance;
        private string _Remark;

        public Reimburse(DateTime applyDate, ReimburseStatusEnum reimburseStatus)
        {
            _ApplyDate = applyDate;
            _ReimburseStatus = reimburseStatus;
        }
        public Reimburse()
        {
        }
        /// <summary>
        /// 报销单ID
        /// </summary>
        public int ReimburseID
        {
            get { return _ReimburseID; }
            set { _ReimburseID = value; }
        }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyDate
        {
            get { return _ApplyDate; }
            set { _ApplyDate = value; }
        }

        /// <summary>
        /// 报销人员当时所属部门
        /// </summary>
        public Department Department
        {
            get { return _Department; }
            set { _Department = value; }
        }


        /// <summary>
        /// 申请人的ID
        /// </summary>
        public int ApplierID
        {
            get { return _ApplierID; }
            set { _ApplierID = value; }
        }

        /// <summary>
        /// 申请人的姓名
        /// </summary>
        public string ApplerName
        {
            get { return _ApplerName; }
            set { _ApplerName = value; }
        }

        /// <summary>
        /// 报销分类
        /// </summary>
        public ReimburseCategoriesEnum ReimburseCategoriesEnum
        {
            get { return _ReimburseCategoriesEnum; }
            set { _ReimburseCategoriesEnum = value; }
        }

        /// <summary>
        /// 单据张数
        /// </summary>
        public int PaperCount
        {
            get { return _PaperCount; }
            set { _PaperCount = value; }
        }

        /// <summary>
        /// 目的地
        /// </summary>
        public string Destinations
        {
            get { return _Destinations; }
            set { _Destinations = value; }
        }

        /// <summary>
        /// 客户名
        /// </summary>
        //public string CustomerID
        //{
        //    get { return _CustomerID; }
        //    set { _CustomerID = value; }
        //}

        /// <summary>
        /// 项目
        /// </summary>
        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }

        public DateTime ConsumeDateTo
        {
            get { return _ConsumeDateTo; }
            set { _ConsumeDateTo = value; }
        }

        /// <summary>
        /// 消费日期
        /// </summary>
        public DateTime ConsumeDateFrom
        {
            get { return _ConsumeDateFrom; }
            set { _ConsumeDateFrom = value; }
        }

        /// <summary>
        /// 报销单总计
        /// </summary>
        public decimal TotalCost
        {
            get
            {
                if (ReimburseItems != null && ReimburseItems.Count > 0)
                {
                    return CaculateTotalCost(ReimburseItems);
                }
                return _TotalCost;
            }
            set { _TotalCost = value; }
        }

        /// <summary>
        /// 报销单总计(大写)
        /// </summary>
        public string TotalCostCH
        {
            get { return MoneyChange.GetUpperMoney(Convert.ToDouble(TotalCost)); }
        }
        /// <summary>
        /// 货币类型
        /// </summary>
        public int CurrencyType { get; set; }
        /// <summary>
        /// 记账时间
        /// </summary>
        public string BillingTime
        {
            get { return _BillingTime; }
            set { _BillingTime = value; }
        }

        /// <summary>
        /// 提交时间
        /// </summary>
        public string CommitTime
        {
            get { return _CommitTime; }
            set { _CommitTime = value; }
        }

        ///// <summary>
        ///// 自定义流程
        ///// </summary>
        //public DiyProcess DiyProcess
        //{
        //    get { return _DiyProcess; }
        //    set { _DiyProcess = value; }
        //}

        ///// <summary>
        ///// 当前流程索引
        ///// </summary>
        //public int NextStepIndex
        //{
        //    get
        //    {
        //        return _NextStepIndex;
        //    }
        //    set
        //    {
        //        _NextStepIndex = value;
        //    }
        //}

        /// <summary>
        /// 报销单的状态
        /// </summary>
        public ReimburseStatusEnum ReimburseStatus
        {
            get { return _ReimburseStatus; }
            set { _ReimburseStatus = value; }
        }

        /// <summary>
        /// 新增报销项
        /// </summary>
        public List<ReimburseItem> ReimburseItems
        {
            get { return _ReimburseItems; }
            set { _ReimburseItems = value; }
        }

        /// <summary>
        /// 该方法暂时没用到暂时保留
        /// </summary>
        public List<ReimburseFlow> ReimburseFlows
        {
            get { return _ReimburseFlows; }
            set { _ReimburseFlows = value; }
        }

        public decimal CaculateTotalCost(List<ReimburseItem> items)
        {
            decimal ret = 0;
            if (items == null)
            {
                return ret;
            }
            foreach (ReimburseItem item in items)
            {
                ret = ret + item.TotalCost;
            }
            ret += OutCityAllowance;
            return ret;
        }


        public static void AddReimburseStatusValueAndNameIntoDictionary(Dictionary<string, string> dictionaryData,
                                                                        ReimburseStatusEnum reimburseStatusEnum)
        {
            dictionaryData.Add(((int)reimburseStatusEnum).ToString(),
                               GetReimburseStatusNameByReimburseStatus(reimburseStatusEnum));
        }

        public static string GetReimburseStatusNameByReimburseStatus(ReimburseStatusEnum reimburseStatus)
        {
            switch (reimburseStatus)
            {
                case ReimburseStatusEnum.Added:
                    return "新增";
                case ReimburseStatusEnum.Reimbursing:
                    return "提交中";
                case ReimburseStatusEnum.Reimbursed:
                    return "已报销";
                case ReimburseStatusEnum.Return:
                    return "退回";
                case ReimburseStatusEnum.Auditing:
                    return "通过审核";
                case ReimburseStatusEnum.WaitAudit:
                    return "待财务审核";
                default:
                    return "";
            }
        }

        public static ReimburseStatusEnum GetReimburseStatusByReimburseStatusName(string name)
        {
            switch (name)
            {
                case "新增":
                    return ReimburseStatusEnum.Added;
                case "提交中":
                    return ReimburseStatusEnum.Reimbursing;
                case "已报销":
                    return ReimburseStatusEnum.Reimbursed;
                case "退回":
                    return ReimburseStatusEnum.Return;
                case "通过审核":
                    return ReimburseStatusEnum.Auditing;
                case "待财务审核":
                    return ReimburseStatusEnum.WaitAudit;
                default:
                    return ReimburseStatusEnum.Return;
            }
        }

        ///<summary>
        /// 从一列表中找出某一费用类型的报销单列表
        ///</summary>
        ///<param name="reimburseList"></param>
        ///<param name="type"></param>
        ///<returns></returns>
        public static List<Reimburse> FindReimburseByType(List<Reimburse> reimburseList, string type)
        {
            List<Reimburse> returnReimburseList = new List<Reimburse>();
            foreach (Reimburse reimburse in reimburseList)
            {
                if (type == "差旅费")
                {
                    if (reimburse.ReimburseCategoriesEnum == ReimburseCategoriesEnum.TravelReimburse)
                    {
                        returnReimburseList.Add(reimburse);
                    }
                }
                else
                {
                    if (reimburse.ReimburseCategoriesEnum != ReimburseCategoriesEnum.TravelReimburse)
                    {
                        foreach (ReimburseItem reimburseItem in reimburse._ReimburseItems)
                        {
                            if (ReimburseItem.GetReimburseTypeNameByReimburseType(reimburseItem.ReimburseTypeEnum) ==
                                type)
                            {
                                returnReimburseList.Add(reimburse);
                                break;
                            }
                        }
                    }
                }
            }
            return returnReimburseList;
        }

        public string ReimburseContentShow
        {
            get
            {
                if (ReimburseItems == null)
                {
                    return "";
                }
                string ret = "";
                foreach (ReimburseItem item in ReimburseItems)
                {
                    if (!string.IsNullOrEmpty(ret))
                    {
                        ret = ret + "； ";
                    }
                    ret = ret + ReimburseItem.GetReimburseTypeNameByReimburseType(item.ReimburseTypeEnum) + "：" +
                          item.TotalCost ;
                }
                if (ret.Length > 40)
                {
                    return ret.Substring(0, 40) + "...";
                }
                return ret;
            }
        }
        /// <summary>
        /// 客户信息
        /// </summary>
        public string CustomerContentShow
        {
            get
            {
                return GetCustomerNameString(ReimburseItems);
            }
        }

        /// <summary>
        /// 出差天数
        /// </summary>
        public decimal OutCityDays
        {
            get { return _OutCityDays; }
            set { _OutCityDays = value; }
        }

        /// <summary>
        /// 出差补贴
        /// </summary>
        public decimal OutCityAllowance
        {
            get { return _OutCityAllowance; }
            set { _OutCityAllowance = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _Remark ?? ""; }
            set { _Remark = value; }
        }

        private string _Discription;
        public string Discription
        {
            get { return _Discription ?? ""; }
            set { _Discription = value; }
        }

        /// <summary>
        /// 货币类型
        /// </summary>
        public int ExchangeRateID { get; set; }

        /// <summary>
        /// 货币名称
        /// </summary>
        public string ExchangeRateName { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// 符号
        /// </summary>
        public string ExchangeSymbol { get; set; }

        public decimal ExchangeCost
        {
            get { return TotalCost * ExchangeRate; }
        }

        /// <summary>
        /// 去除重复客户名后，返回客户名称 例如 aaa客户; bb客户
        /// </summary>
        public static string GetCustomerNameString(List<ReimburseItem> items)
        {
            string ret = "";
            if (items != null)
            {
                List<string> Names = new List<string>();
                foreach (ReimburseItem item in items)
                {
                    if (!string.IsNullOrEmpty(item.CustomerName))
                    {
                        if (!Names.Contains(item.CustomerName))
                        {
                            Names.Add(item.CustomerName);
                        }
                    }
                }
                foreach (string s in Names)
                {
                    if (!string.IsNullOrEmpty(ret))
                    {
                        ret = ret + "； ";
                    }
                    ret = string.Format("{0}{1}", ret, s);
                }
            }
            return ret;
        }
    }
}