//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights ReadIODataFromAccess.
// 文件名: DataFromAccess.cs
// 创建者: 刘丹
// 创建日期: 2008-12-01
// 概述: 从ACCESS读出数据
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
