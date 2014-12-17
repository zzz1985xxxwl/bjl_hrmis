//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights ReadIODataFromAccess.
// �ļ���: DataFromAccess.cs
// ������: ����
// ��������: 2008-12-01
// ����: ��ACCESS��������
// ----------------------------------------------------------------

using System;
using System.Runtime.Serialization;

namespace ReadDataAccessModel
{
    [Serializable]
    [DataContract]
    public class DataFromAccess
    {
        private string _CardNo;
        private InOutStatusEnum _InOrOut;
        private DateTime _IOTime;

        [DataMember]
        public string CardNo
        {
            get { return _CardNo; }
            set { _CardNo = value; }
        }

        [DataMember]
        public InOutStatusEnum InOrOut
        {
            get { return _InOrOut; }
            set { _InOrOut = value; }
        }

        [DataMember]
        public DateTime IOTime
        {
            get { return _IOTime; }
            set { _IOTime = value; }
        }
    }
}
