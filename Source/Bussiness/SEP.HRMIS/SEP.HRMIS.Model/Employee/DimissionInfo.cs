using System;
using System.Runtime.Serialization;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��ְ����
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
        /// ��ְ���鹹�캯��
        /// </summary>
        public DimissionInfo()
        {
        }
        /// <summary>
        /// ��ְ���鹹�캯��
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
        /// ��ְԭ��
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
        /// ��ְ����
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
        /// ��ְ���ò�����׼(������)
        /// </summary>
        public decimal NewDimissionMonth
        {
            get { return _NewDimissionMonth; }
            set { _NewDimissionMonth = value; }
        }
    
        /// <summary>
        /// ��ְ����
        /// </summary>
        public string DimissionType
        {
            get { return _DimissionType; }
            set { _DimissionType = value; }
        }
        /// <summary>
        /// ��ְԭ��
        /// </summary>
        public DimissionReasonType DimissionReasonType
        {
            get { return _DimissionReasonType; }
            set { _DimissionReasonType = value; }
        }

        #region ����
        /// <summary>
        /// ��дequals
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