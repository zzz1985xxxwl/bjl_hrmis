using System;
using System.Runtime.Serialization;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 离职详情
    /// </summary>
    [Serializable]
    public class DimissionInfo
    {
        private DateTime _DimissionDate;
        private string _DimissionReason;
        private DimissionReasonType _DimissionReasonType;
        [OptionalField]
        private decimal _NewDimissionMonth;
        private string _DimissionType;
        /// <summary>
        /// 离职详情构造函数
        /// </summary>
        public DimissionInfo()
        {
        }
        /// <summary>
        /// 离职详情构造函数
        /// </summary>
        /// <param name="DimissionDate"></param>
        /// <param name="DimissionReasonType"></param>
        /// <param name="DimissionReason"></param>
        /// <param name="DimissionMonth"></param>
        /// <param name="DimissionType"></param>
        public DimissionInfo(DateTime DimissionDate, DimissionReasonType DimissionReasonType, string DimissionReason, decimal DimissionMonth, string DimissionType)
        {
            _DimissionDate = DimissionDate;
            _DimissionReason = DimissionReason;
            _DimissionReasonType = DimissionReasonType;
            _NewDimissionMonth = DimissionMonth;
            _DimissionType = DimissionType;
        }

        /// <summary>
        /// 离职原因
        /// </summary>
        public string DimissionReason
        {
            get
            {
                return _DimissionReason;
            }
            set
            {
                _DimissionReason = value;
            }
        }

        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime DimissionDate
        {
            get
            {
                return _DimissionDate;
            }
            set
            {
                _DimissionDate = value;
            }
        }

        /// <summary>
        /// 离职经济补偿标准(几个月)
        /// </summary>
        public decimal NewDimissionMonth
        {
            get { return _NewDimissionMonth; }
            set { _NewDimissionMonth = value; }
        }
    
        /// <summary>
        /// 离职类型
        /// </summary>
        public string DimissionType
        {
            get { return _DimissionType; }
            set { _DimissionType = value; }
        }
        /// <summary>
        /// 离职原因
        /// </summary>
        public DimissionReasonType DimissionReasonType
        {
            get { return _DimissionReasonType; }
            set { _DimissionReasonType = value; }
        }

        #region 方法
        /// <summary>
        /// 重写equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (DimissionInfo)) return false;
            return Equals((DimissionInfo) obj);
        }
        /// <summary>
        /// Equals DimissionInfo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(DimissionInfo obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj._DimissionDate.Equals(_DimissionDate) && Equals(obj._DimissionReason, _DimissionReason) && Equals(obj._DimissionReasonType, _DimissionReasonType) && obj._NewDimissionMonth == _NewDimissionMonth && Equals(obj._DimissionType, _DimissionType);
        }
        /// <summary>
        /// HashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = _DimissionDate.GetHashCode();
                result = (result*397) ^ (_DimissionReason != null ? _DimissionReason.GetHashCode() : 0);
                result = (result*397) ^ (_DimissionReasonType != null ? _DimissionReasonType.GetHashCode() : 0);
                result = (result * 397) ^ _NewDimissionMonth.GetHashCode();
                result = (result*397) ^ (_DimissionType != null ? _DimissionType.GetHashCode() : 0);
                return result;
            }
        }

        #endregion
    }
}