//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// 文件名: ReadDataHistory.cs
// 创建者: 刘丹
// 创建日期: 2008-10-15
// 概述: 记录读取的历史
// ----------------------------------------------------------------
using System;


namespace SEP.HRMIS.Model.EmployeeAttendance.ReadData
{
    ///<summary>
    ///</summary>
    [Serializable]
    public class ReadDataHistory
    {
        private int _ReadDataId;
        private DateTime _ReadTime;
        private ReadDataResultType _ReadResult;
        private string _FailReason;

        ///<summary>
        ///</summary>
        public ReadDataHistory()
        {

        }

        ///<summary>
        ///</summary>
        public ReadDataHistory(DateTime readTime, ReadDataResultType readResult, string failReason)
        {
            _ReadTime = readTime;
            _ReadResult = readResult;
            _FailReason = failReason;
        }
        /// <summary>
        /// 读取数据记录id
        /// </summary>
        public int ReadDataId
        {
            get { return _ReadDataId; }
            set { _ReadDataId = value; }
        }

        /// <summary>
        /// 读取数据时间
        /// </summary>
        public DateTime ReadTime
        {
            get { return _ReadTime; }
            set { _ReadTime = value; }
        }

        /// <summary>
        /// 读取数据结构
        /// </summary>
        public ReadDataResultType ReadResult
        {
            get { return _ReadResult; }
            set { _ReadResult = value; }
        }

        ///<summary>
        /// 读取失败的原因
        ///</summary>
        public string FailReason
        {
            get { return _FailReason; }
            set { _FailReason = value; }
        }
    }
}
