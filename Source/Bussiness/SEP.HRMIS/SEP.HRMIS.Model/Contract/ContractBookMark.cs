//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: ContractBookMark.cs
// 创建者: xue.wenlong
// 创建日期: 2008-11-19
// 概述: 用于记录合同的书签
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// 合同的书签
    /// </summary>
    [Serializable]
    public class ContractBookMark
    {
        private int _PKID;
        private int _ContractTypeID;
        private string _BookMarkName;
        /// <summary>
        /// 合同的书签
        /// </summary>
        /// <param name="pkid"></param>
        /// <param name="contractTypeID"></param>
        /// <param name="bookMarkName"></param>
        public ContractBookMark(int pkid,int contractTypeID,string bookMarkName)
        {
            _PKID = pkid;
            _ContractTypeID = contractTypeID;
            _BookMarkName = bookMarkName;
        }
        /// <summary>
        /// 书签编号
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }
        /// <summary>
        /// 合同类型
        /// </summary>
        public int ContractTypeID
        {
            get { return _ContractTypeID; }
            set { _ContractTypeID = value; }
        }
        /// <summary>
        /// 标签名字
        /// </summary>
        public string BookMarkName
        {
            get { return _BookMarkName; }
            set { _BookMarkName = value; }
        }
    }
}
