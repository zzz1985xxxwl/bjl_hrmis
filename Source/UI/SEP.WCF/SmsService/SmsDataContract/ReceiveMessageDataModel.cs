//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ReceiveMessageDataModel.cs
// ������: �ߺ�
// ��������: 2008-11-21
// ����: ���ܵ�����Ϣ������ģ��
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
        /// �����ڶ��Ż����еı�ţ�һ������
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        /// <summary>
        /// �����˵ĺ���
        /// </summary>
        public string TheNumber
        {
            get { return _TheNumber; }
            set { _TheNumber = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        /// <summary>
        /// ���Ż����ܵ���ʱ��
        /// </summary>
        public DateTime ReceivedTime
        {
            get { return _ReceivedTime; }
            set { _ReceivedTime = value; }
        }

        /// <summary>
        ///  ָʾ����Ϣ�Ƿ��Ǹɾ��ģ���ֻ�������ڴ��У��Ѿ�����Sim������
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

        //�Ƴ��绰����ǰ���+86
        public void MoveNumber86()
        {
            _TheNumber = _TheNumber.Replace("+86", "");
        }

        public override string ToString()
        {
            return  string.Format("�����:{0}\r��������:{1}\r������:{2}����ʱ����:{3}\r�ɾ�����Ϣ:{4}",_Id,_TheNumber,_Content,_ReceivedTime,_IsCleanMessage);
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