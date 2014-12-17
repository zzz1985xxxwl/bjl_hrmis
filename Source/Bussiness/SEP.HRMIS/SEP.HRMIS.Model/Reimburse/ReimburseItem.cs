using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class ReimburseItem
    {
        // 编号
        private int _ReimburseItemID;
        // 费用类别
        private ReimburseTypeEnum _ReimburseTypeEnum;
        // 消费地点
        private string _ConsumePlace;
        // 消费项目
        private string _ProjectName;
        // 金额
        private decimal _TotalCost;
        // 事由
        private string _Reason;
        public int HashCode
        {
            get
            {
                //modify by colbert
                //return GetHashCode();
                return _ReimburseItemID;
            }
        }
        //public ReimburseItem(ReimburseTypeEnum reimburseTypeEnum, DateTime consumeDateFrom, DateTime consumeDateTo, int paperCount, decimal totalCost, string projectName)
        //{
        public ReimburseItem(ReimburseTypeEnum reimburseTypeEnum, decimal totalCost, string projectName)
        {
            //modify by colbert
            _ReimburseItemID = GetHashCode();

            _ReimburseTypeEnum = reimburseTypeEnum;
            _TotalCost = totalCost;
            _ProjectName = projectName;
        }
        public int ReimburseID { get; set; }
        public int ReimburseItemID
        {
            get
            {
                return _ReimburseItemID;
            }
            set
            {
                _ReimburseItemID = value;
            }

        }
        /// <summary>
        /// 费用类别
        /// </summary>
        public ReimburseTypeEnum ReimburseTypeEnum
        {
            get
            {
                return _ReimburseTypeEnum;
            }
            set
            {
                _ReimburseTypeEnum = value;
            }
        }
        /// <summary>
        /// 消费地点
        /// </summary>
        public string ConsumePlace
        {
            get
            {
                return _ConsumePlace;
            }
            set
            {
                _ConsumePlace = value;
            }
        }
        /// <summary>
        /// 使用项目
        /// </summary>
        public string ProjectName
        {
            get
            {
                return _ProjectName;
            }
            set
            {
                _ProjectName = value;
            }
        }
        /// <summary>
        /// 金额总数
        /// </summary>
        public decimal TotalCost
        {
            get
            {
                return _TotalCost;
            }
            set
            {
                _TotalCost = value;
            }
        }
        /// <summary>
        /// 事由
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


        public static void AddReimburseTypeValueAndNameIntoDictionary(Dictionary<string, string> dictionaryData, ReimburseTypeEnum reimburseTypeEnum)
        {
            dictionaryData.Add(((int)reimburseTypeEnum).ToString(), GetReimburseTypeNameByReimburseType(reimburseTypeEnum));
        }

        public static string GetReimburseTypeNameByReimburseType(ReimburseTypeEnum reimburseTypeEnum)
        {
            switch (reimburseTypeEnum)
            {
                case ReimburseTypeEnum.CityTrafficCost:
                    return "市内交通费";
                case ReimburseTypeEnum.MealCost:
                    return "餐费";
                case ReimburseTypeEnum.AdminCost:
                    return "行政费用";
                //case ReimburseTypeEnum.BizTrip:
                //    return "差旅费";
                case ReimburseTypeEnum.CommunicationCost:
                    return "通讯费";
                //case ReimburseTypeEnum.BizCustomerCost:
                //    return "业务服务费";
                case ReimburseTypeEnum.VehicleRunningCost:
                    return "车辆运行费";
                case ReimburseTypeEnum.TrainingCost:
                    return "培训费";
                case ReimburseTypeEnum.WelfareCost:
                    return "福利费";
                case ReimburseTypeEnum.AccommodationCost:
                    return "房租";
                case ReimburseTypeEnum.ConferenceFeesCost:
                    return "会务费";
                case ReimburseTypeEnum.ConsultancyFeesCost:
                    return "顾问费";
                case ReimburseTypeEnum.OtherCost:
                    return "其它";

                case ReimburseTypeEnum.ShortDistanceCost:
                    return "短途交通费";
                case ReimburseTypeEnum.LongDistanceCost:
                    return "长途交通费";
                case ReimburseTypeEnum.LodgingCost:
                    return "住宿费";
                case ReimburseTypeEnum.CommunicationEntertainmentCost:
                    return "交际应酬费";
                case ReimburseTypeEnum.MailPostCost:
                    return "邮寄费";
                case ReimburseTypeEnum.MarkCost:
                    return "市场费用";
                case ReimburseTypeEnum.WarehouseCost:
                    return "仓库费用";
                case ReimburseTypeEnum.ExhibitionCost:
                    return "展览会费用";
                default:
                    return "";
            }
        }
        public static List<string> GetReimburseTypeEnumList()
        {
            List<string> reimburseTypeEnumList = new List<string>();
            reimburseTypeEnumList.Add("市内交通费");
            reimburseTypeEnumList.Add("餐费");
            reimburseTypeEnumList.Add("行政费用");
            //reimburseTypeEnumList.Add("差旅费");
            reimburseTypeEnumList.Add("通讯费");
            //reimburseTypeEnumList.Add("业务服务费");
            reimburseTypeEnumList.Add("车辆运行费");
            reimburseTypeEnumList.Add("培训费");
            reimburseTypeEnumList.Add("福利费");
            reimburseTypeEnumList.Add("房租");
            reimburseTypeEnumList.Add("会务费");
            reimburseTypeEnumList.Add("顾问费");
            reimburseTypeEnumList.Add("短途交通费");
            reimburseTypeEnumList.Add("长途交通费");
            reimburseTypeEnumList.Add("住宿费");
            reimburseTypeEnumList.Add("交际应酬费");
            reimburseTypeEnumList.Add("邮寄费");
            reimburseTypeEnumList.Add("市场费用");
            reimburseTypeEnumList.Add("仓库费用");
            reimburseTypeEnumList.Add("展览会费用");
            reimburseTypeEnumList.Add("其它");
            return reimburseTypeEnumList;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<string> GetReimburseTypeEnumListTravel()
        {
            List<string> reimburseTypeEnumList = new List<string>();
            reimburseTypeEnumList.Add("差旅费");
            reimburseTypeEnumList.Add("市内交通费");
            reimburseTypeEnumList.Add("餐费");
            reimburseTypeEnumList.Add("行政费用");
            //reimburseTypeEnumList.Add("差旅费");
            reimburseTypeEnumList.Add("通讯费");
            //reimburseTypeEnumList.Add("业务服务费");
            reimburseTypeEnumList.Add("车辆运行费");
            reimburseTypeEnumList.Add("培训费");
            reimburseTypeEnumList.Add("福利费");
            reimburseTypeEnumList.Add("房租");
            reimburseTypeEnumList.Add("会务费");
            reimburseTypeEnumList.Add("顾问费");
            reimburseTypeEnumList.Add("邮寄费");
            reimburseTypeEnumList.Add("市场费用");
            reimburseTypeEnumList.Add("仓库费用");
            reimburseTypeEnumList.Add("展览会费用");
            reimburseTypeEnumList.Add("其它");


            //reimburseTypeEnumList.Add("长途交通费");
            //reimburseTypeEnumList.Add("住宿费");
            //reimburseTypeEnumList.Add("交际应酬费");
            return reimburseTypeEnumList;
        }

        // 客户名  add by liudan 2009-09-07
        private int _CustomerID;
        /// <summary>
        /// 客户名
        /// </summary>
        public int CustomerID
        {
            get { return _CustomerID; }
            set { _CustomerID = value; }
        }

        private string _CustomerName;
        /// <summary>
        /// 客户名
        /// </summary>
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        /// <summary>
        /// 货币类型
        /// </summary>
        public int CurrencyType { get; set; }

        /// <summary>
        /// 货币名称
        /// </summary>
        public string ExchangeRateName { get; set; }
        public string ExchangeSymbol { get; set; }
        /// <summary>
        /// 汇率
        /// </summary>
        public decimal ExchangeRate { get; set; }

        public decimal ExchangeCost
        {
            get { return decimal.Round(TotalCost * ExchangeRate,2,MidpointRounding.AwayFromZero); }
        }
    }
}
