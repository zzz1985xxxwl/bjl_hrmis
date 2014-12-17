using System;

namespace SEP.HRMIS.Model
{
    using System.Collections.Generic;

    [Serializable]
    public class ReimburseTotal
    {
        // 编号
        private int _ReimburseID;
        // 月份
        private string _Month;
        // 姓名
        private string _Name;
        // 长途统计
        private decimal _LongTripTotal;
        // 短途统计
        private decimal _ShortTripTotal;
        // 住宿统计
        private decimal _LodgingTotal;
        // 交际应酬统计
        private decimal _EntertainmentTotal;
        // 其他统计
        private decimal _OtherTotal;
        // 小计
        private decimal _Total;
        // 出差地点
        private string _Place;
        // 出差项目
        private string _Projuct;
        // 出差开始时间
        private string _StartTime;
        // 出差结束时间
        private string _EndTime;
        private decimal _OutCityDays;
        private decimal _OutCityAllowance;

        //add by liudan 2009-09-10 报销分类,备注，客户名称，餐费，市内交通费
        private ReimburseCategoriesEnum _ReimburseCategories;
        private string _Remark;
        private List<int> _CustomerIds;
        private string _CustomerName;
        private decimal _MealTotalCost;
        private decimal _CityTrafficTotalCost;

        /// <summary>
        /// 报销单ID
        /// </summary>
        public int ReimburseID
        {
            get
            {
                return _ReimburseID;
            }
            set
            {
                _ReimburseID = value;
            }
        }

        /// <summary>
        /// 月份
        /// </summary>
        public string Month
        {
            get
            {
                return _Month;
            }
            set
            {
                _Month = value;
            }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        /// <summary>
        /// 长途统计
        /// </summary>
        public decimal LongTripTotal
        {
            get
            {
                return _LongTripTotal;
            }
            set
            {
                _LongTripTotal = value;
            }
        }

        /// <summary>
        /// 短途统计
        /// </summary>
        public decimal ShortTripTotal
        {
            get
            {
                return _ShortTripTotal;
            }
            set
            {
                _ShortTripTotal = value;
            }
        }

        /// <summary>
        /// 住宿统计
        /// </summary>
        public decimal LodgingTotal
        {
            get
            {
                return _LodgingTotal;
            }
            set
            {
                _LodgingTotal = value;
            }
        }

        /// <summary>
        /// 交际应酬统计
        /// </summary>
        public decimal EntertainmentTotal
        {
            get
            {
                return _EntertainmentTotal;
            }
            set
            {
                _EntertainmentTotal = value;
            }
        }

        /// <summary>
        /// 其他统计
        /// </summary>
        public decimal OtherTotal
        {
            get
            {
                return _OtherTotal;
            }
            set
            {
                _OtherTotal = value;
            }
        }

        /// <summary>
        /// 其他统计
        /// </summary>
        public decimal Total
        {
            get
            {
                return _Total;
            }
            set
            {
                _Total = value;
            }
        }

        /// <summary>
        /// 出差地点
        /// </summary>
        public string Place
        {
            get
            {
                return _Place;
            }
            set
            {
                _Place = value;
            }
        }

        /// <summary>
        /// 出差项目
        /// </summary>
        public string Projuct
        {
            get
            {
                return _Projuct;
            }
            set
            {
                _Projuct = value;
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
        /// 出差开始时间
        /// </summary>
        public string StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                _StartTime = value;
            }
        }

        /// <summary>
        /// 出差结束时间
        /// </summary>
        public string EndTime
        {
            get
            {
                return _EndTime;
            }
            set
            {
                _EndTime = value;
            }
        }

        ///<summary>
        /// 分类
        ///</summary>
        public ReimburseCategoriesEnum ReimburseCategories
        {
            get { return _ReimburseCategories; }
            set { _ReimburseCategories = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

                    /// <summary>
        /// 客户名称
        /// </summary>
        public List<int> CustomerIds
        {
            get { return _CustomerIds; }
            set { _CustomerIds = value; }
        }

        /// <summary>
        /// 餐费
        /// </summary>
        public decimal MealTotalCost
        {
            get { return _MealTotalCost; }
            set { _MealTotalCost = value; }
        }

        /// <summary>
        /// 市内交通费
        /// </summary>
        public decimal CityTrafficTotalCost
        {
            get { return _CityTrafficTotalCost; }
            set { _CityTrafficTotalCost = value; }
        }

        public string Discription { get; set; }
    }
}
