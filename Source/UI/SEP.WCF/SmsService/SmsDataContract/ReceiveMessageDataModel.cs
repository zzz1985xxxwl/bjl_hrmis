//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ReceiveMessageDataModel.cs
// 创建者: 倪豪
// 创建日期: 2008-11-21
// 概述: 接受到的消息的数据模型
// ----------------------------------------------------------------
using System;
using System.Runtime.Serialization;

namespace SmsDataContract
{
    [Serializable]
    [DataContract]
    public class ReceiveMessageDataModel
    {
        [DataMember]
        private int _Pkid;
        [DataMember]
        private bool _BoradCasted;
        [DataMember]
        private bool _IsObjectStatus;
        [DataMember]
        private int _Id;
        [DataMember]
        private string _TheNumber;
        [DataMember]
        private string _Content;
        [DataMember]
        private DateTime _ReceivedTime;
        [DataMember]
        private bool _IsCleanMessage;

        public ReceiveMessageDataModel(int id, string theNumber, string content, DateTime receivedTime)
        {
            Id = id;
            TheNumber = theNumber;
            Content = content;
            ReceivedTime = receivedTime;
        }

        /// <summary>
        /// 短信在短信机器中的编号，一般无用
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        /// <summary>
        /// 发送人的号码
        /// </summary>
        public string TheNumber
        {
            get { return _TheNumber; }
            set { _TheNumber = value; }
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
        /// 短信机接受到的时间
        /// </summary>
        public DateTime ReceivedTime
        {
            get { return _ReceivedTime; }
            set { _ReceivedTime = value; }
        }

        /// <summary>
        ///  指示该信息是否是干净的：即只存在于内存中，已经不在Sim卡里了
        /// </summary>
        public bool IsCleanMessage
        {
            get { return _IsCleanMessage; }
            set { _IsCleanMessage = value; }
        }

        public bool BoradCasted
        {
            get { return _BoradCasted; }
            set { _BoradCasted = value; }
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

        //移除电话号码前面的+86
        public void MoveNumber86()
        {
            _TheNumber = _TheNumber.Replace("+86", "");
        }

        public override string ToString()
        {
            return  string.Format("编号是:{0}\r发送人是:{1}\r内容是:{2}发送时间是:{3}\r干净的信息:{4}",_Id,_TheNumber,_Content,_ReceivedTime,_IsCleanMessage);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ReceiveMessageDataModel)) return false;
            return Equals((ReceiveMessageDataModel) obj);
        }

        public bool Equals(ReceiveMessageDataModel obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj._Pkid == _Pkid && obj._BoradCasted.Equals(_BoradCasted) && obj._Id == _Id && Equals(obj._TheNumber, _TheNumber) && Equals(obj._Content, _Content) && obj._ReceivedTime.Equals(_ReceivedTime) && obj._IsCleanMessage.Equals(_IsCleanMessage);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = _Pkid;
                result = (result*397) ^ _BoradCasted.GetHashCode();
                result = (result*397) ^ _IsObjectStatus.GetHashCode();
                result = (result*397) ^ _Id;
                result = (result*397) ^ (_TheNumber != null ? _TheNumber.GetHashCode() : 0);
                result = (result*397) ^ (_Content != null ? _Content.GetHashCode() : 0);
                result = (result*397) ^ _ReceivedTime.GetHashCode();
                result = (result*397) ^ _IsCleanMessage.GetHashCode();
                return result;
            }
        }
    }
}