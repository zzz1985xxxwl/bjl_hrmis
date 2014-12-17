//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: Goal.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 目标
// ----------------------------------------------------------------
using System;

namespace SEP.Model.Goals
{
    /// <summary>
    /// 目标
    /// </summary>
    [Serializable]
    public class Goal
    {
        #region

        public  int _Id;
        public  string _Title;
        public  string _Content;
        public  DateTime _SetTime;

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }

        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }

        public string Content
        {
            get
            {
                return _Content;
            }
            set
            {
                _Content = value;
            }
        }

        public DateTime SetTime
        {
            get
            {
                return _SetTime;
            }
            set
            {
                _SetTime = value;
            }
        }

        #endregion

        public Goal()
        {
        }

        public Goal(int id, string title, string content, DateTime setTime)
        {
            _Id = id;
            _Title = title;
            _Content = content;
            _SetTime = setTime;
        }
    }
}