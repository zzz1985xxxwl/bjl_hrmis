//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: Bulletin.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 公告
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Departments;

namespace SEP.Model.Bulletins
{
    [Serializable]
    public class Bulletin
    {
        private List<Appendix> _AppendixList;
        private string _Content;
        private int _BulletinID;
        private DateTime _PublishTime;
        private string _Title;
        private Department _Dept;

        public Bulletin(int bulletinID, string title, string content, DateTime publishTime)
        {
            _BulletinID = bulletinID;
            _Title = title;
            _Content = content;
            _PublishTime = publishTime;
        }
        /// <summary>
        /// 附件队列
        /// </summary>
        public List<Appendix> AppendixList
        {
            get
            {
                return _AppendixList;
            }
            set
            {
                _AppendixList = value;
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

        public int BulletinID
        {
            get
            {
                return _BulletinID;
            }
            set
            {
                _BulletinID = value;
            }
        }

        public DateTime PublishTime
        {
            get
            {
                return _PublishTime;
            }
            set
            {
                _PublishTime = value;
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

        /// <summary>
        /// 所属部门
        /// </summary>
        public Department Dept
        {
            get { return _Dept; }
            set { _Dept = value; }
        }
    }
}