//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// 文件名: TrainFBQuestion.cs
// 创建者: 张珍
// 创建日期: 2008-11-05
// 概述: 培训反馈问题的选项
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    ///<summary>
    /// 培训反馈项
    ///</summary>
    [Serializable]
    public class TrainFBItem
    {
        private int _FBItemID;
        private string _Description;
        private int _Worth;

        ///<summary>
        ///</summary>
        public int HashCode
        {
            get
            {
                return GetHashCode();
            }
        }

        ///<summary>
        ///</summary>
        ///<param name="fbItemID"></param>
        ///<param name="description"></param>
        ///<param name="worth"></param>
        public TrainFBItem(int fbItemID, string description, int worth)
        {
            _FBItemID = fbItemID;
            _Description = description;
            _Worth = worth;
        }
        /// <summary>
        /// 选项ID
        /// </summary>
        public int FBItemID
        {
            get
            {
                return _FBItemID;
            }
            set
            {
                _FBItemID = value;
            }
        }
        /// <summary>
        /// 选项描述
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        /// <summary>
        /// 选项分值
        /// </summary>
        public int Worth
        {
            get
            {
                return _Worth;
            }
            set
            {
                _Worth = value;
            }
        }
    }
}
