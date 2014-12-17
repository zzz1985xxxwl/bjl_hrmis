//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: Appendix.cs
// ������: colbert
// ��������: 2009-02-02
// ����: ����
// ----------------------------------------------------------------
using System;

namespace SEP.Model.Bulletins
{
    /// <summary>
    /// ����
    /// </summary>
    [Serializable]
    public class Appendix
    {
        private int _AppendixID;
        private int _BulletinID;
        private string _Title;
        private string _Directory;

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="appendixID">����ID</param>
        /// <param name="bulletinID">������Ӧ����ID</param>
        /// <param name="title">����</param>
        /// <param name="directory">Ŀ¼��ַ</param>
        public Appendix(int appendixID, int bulletinID, string title, string directory)
        {
            _AppendixID = appendixID;
            _BulletinID = bulletinID;
            _Title = title;
            _Directory = directory;
        }

        /// <summary>
        /// ����ID
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