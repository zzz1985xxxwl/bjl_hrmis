//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: SendMessageDataModel.cs
// 创建者: 倪豪
// 创建日期: 2008-11-21
// 概述: 发送的消息的数据模型
// ----------------------------------------------------------------
using System;
using System.Runtime.Serialization;

namespace SmsDataContract
{
    public enum SendStatusEnum
    {
        //等待发送
        ToBeSend,
        //成功发送
        SuccessSended,
        //发送失败的消息，等待被回送
        FailSendedToBeCallback,
        //发送失败的消息，已经被回送
        FailSendedCallbacked,
    }

    [Serializable]
    [DataContract]
    public class SendMessageDataModel
    {
        private int _Pkid;
        private SendStatusEnum _TheStatus;
        private bool _IsObjectStatus;
        [DataMember]
        private int _SystemSmsId;
        [DataMember]
        private string _SendToNumber;
        [DataMember]
        private string _SystemNumber;
        [DataMember]
        private string _Content;
        [DataMember]
        private int _TriedCount;
        [DataMember]
        private DateTime _LastestSendTime;
        [DataMember]
        private string _HrmisId;
        //本地区默认短信中心号码
        private const string _Defualt_SystemNumber = "8613800210500";

        public SendMessageDataModel(int systemSmsId, string sendToNumber, string systemNubmer, string content,string hrmisId)
        {
            _SystemSmsId = systemSmsId;
            _SendToNumber = sendToNumber;
            _SystemNumber = systemNubmer;
            _Content = content;
            _HrmisId = hrmisId;
        }

        public SendMessageDataModel(int systemSmsId, string sendToNumber, string content,string hrmisId)
            : this(systemSmsId, sendToNumber, _Defualt_SystemNumber,content,hrmisId)
        {
        }

        /// <summary>
        /// 想要发送给的号码
        /// </summary>
        public string SendNumber
        {
            get { return _SendToNumber; }
            set { _SendToNumber = value; }
        }

        /// <summary>
        /// 短信中心号码，一般不需要设置
        /// </summary>
        public string SystemNumber
        {
            get { return _SystemNumber; }
            set { _SystemNumber = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        /// <summary>
        /// 尝试的次数
        /// </summary>
        public int TriedCount
        {
            get { return _TriedCount; }
            set { _TriedCount = value; }
        }

        /// <summary>
        /// 最后一次系统发送该信息的时间
        /// </summary>
        public DateTime SendTime
        {
            get { return _LastestSendTime; }
            set { _LastestSendTime = value; }
        }

        /// <summary>
        /// 该短信在系统中的编号
        /// </summary>
        public int SystemSmsId
        {
            get { return _SystemSmsId; }
            set { _SystemSmsId = value; }
        }

        /// <summary>
        /// Hrmis的标识
        /// </summary>
        public string HrmisId
        {
            get { return _HrmisId; }
            set { _HrmisId = value; }
        }

        public SendStatusEnum TheStatus
        {
            get { return _TheStatus; }
            set { _TheStatus = value; }
        }

        public int Pkid
        {
            get { return _Pkid; }
            set { _Pkid = value; }
        }

        public bool IsObjectStatus
        {
            get { return _IsObjectStatus; }
            set { _IsObjectStatus = value; }
        }

        public override string ToString()
        {
            return string.Format("系统编号是：{0}/{1},发送给{2},内容是：{3}", _HrmisId, _SystemSmsId, _SendToNumber, _Content);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (SendMessageDataModel)) return false;
            return Equals((SendMessageDataModel) obj);
        }

        public bool Equals(SendMessageDataModel obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj._Pkid == _Pkid && Equals(obj._TheStatus, _TheStatus) && obj._SystemSmsId == _SystemSmsId && Equals(obj._SendToNumber, _SendToNumber) && Equals(obj._SystemNumber, _SystemNumber) && Equals(obj._Content, _Content) && obj._TriedCount == _TriedCount && obj._LastestSendTime.Equals(_LastestSendTime) && Equals(obj._HrmisId, _HrmisId);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = _Pkid;
                result = (result*397) ^ _TheStatus.GetHashCode();
                result = (result*397) ^ _IsObjectStatus.GetHashCode();
                result = (result*397) ^ _SystemSmsId;
                result = (result*397) ^ (_SendToNumber != null ? _SendToNumber.GetHashCode() : 0);
                result = (result*397) ^ (_SystemNumber != null ? _SystemNumber.GetHashCode() : 0);
                result = (result*397) ^ (_Content != null ? _Content.GetHashCode() : 0);
                result = (result*397) ^ _TriedCount;
                result = (result*397) ^ _LastestSendTime.GetHashCode();
                result = (result*397) ^ (_HrmisId != null ? _HrmisId.GetHashCode() : 0);
                return result;
            }
        }
    }
}