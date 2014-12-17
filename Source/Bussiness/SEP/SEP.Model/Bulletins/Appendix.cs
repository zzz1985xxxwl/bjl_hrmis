//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: Appendix.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 附件
// ----------------------------------------------------------------
using System;

namespace SEP.Model.Bulletins
{
    /// <summary>
    /// 附件
    /// </summary>
    [Serializable]
    public class Appendix
    {
        private int _AppendixID;
        private int _BulletinID;
        private string _Title;
        private string _Directory;

        /// <summary>
        /// 附件
        /// </summary>
        /// <param name="appendixID">附件ID</param>
        /// <param name="bulletinID">附件对应公告ID</param>
        /// <param name="title">标题</param>
        /// <param name="directory">目录地址</param>
        public Appendix(int appendixID, int bulletinID, string title, string directory)
        {
            _AppendixID = appendixID;
            _BulletinID = bulletinID;
            _Title = title;
            _Directory = directory;
        }

        /// <summary>
        /// 附件ID
        /// </summary>
        public int AppendixID
        {
            get { return _AppendixID; }
            set { _AppendixID = value; }
        }

        public int BulletinID
        {
            get { return _BulletinID; }
            set { _BulletinID = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public string Directory
        {
            get { return _Directory; }
            set { _Directory = value; }
        }
    }
}