using System;
using System.Runtime.Serialization;

namespace SmsControlContract.ClientAddressModels
{
    [DataContract]
    public class ListenAddressModel
    {
        [DataMember]
        private int _Pkid;
        [DataMember]
        private string _ListenAddress;
        [DataMember]
        private bool _IsPermitted;
        [DataMember]
        private bool _IsActived;
        [DataMember]
        private DateTime _LastTryActivitedTime;

        public ListenAddressModel(string listenAddress, bool isPermitted, bool isActived,DateTime lastTryActivitedTime)
        {
            _ListenAddress = listenAddress;
            _IsPermitted = isPermitted;
            _IsActived = isActived;
            _LastTryActivitedTime = lastTryActivitedTime;
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string ListenAddress
        {
            get { return _ListenAddress; }
            set { _ListenAddress = value; }
        }
        /// <summary>
        /// 是否被许可
        /// </summary>
        public bool IsPermitted
        {
            get { return _IsPermitted; }
            set { _IsPermitted = value; }
        }
        /// <summary>
        /// 是否处于活动状态
        /// </summary>
        public bool IsActivited
        {
            get { return _IsActived; }
            set { _IsActived = value; }
        }

        public int Pkid
        {
            get { return _Pkid; }
            set { _Pkid = value; }
        }
        /// <summary>
        /// 最后一次激活时间
        /// </summary>
        public DateTime LastTryActivitedTime
        {
            get { return _LastTryActivitedTime; }
            set { _LastTryActivitedTime = value; }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ListenAddressModel)) return false;
            return Equals((ListenAddressModel) obj);
        }

        public bool Equals(ListenAddressModel obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj._ListenAddress, _ListenAddress) && obj._IsPermitted.Equals(_IsPermitted) && obj._IsActived.Equals(_IsActived) && obj._LastTryActivitedTime.Equals(_LastTryActivitedTime);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = _Pkid;
                result = (result*397) ^ (_ListenAddress != null ? _ListenAddress.GetHashCode() : 0);
                result = (result*397) ^ _IsPermitted.GetHashCode();
                result = (result*397) ^ _IsActived.GetHashCode();
                result = (result*397) ^ _LastTryActivitedTime.GetHashCode();
                return result;
            }
        }
    }
}