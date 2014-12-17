//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: TrainFBQuestion.cs
// ������: ����
// ��������: 2008-11-05
// ����: ��ѵ���������ѡ��
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    ///<summary>
    /// ��ѵ������
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
        /// ѡ��ID
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
        /// ѡ������
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
        /// ѡ���ֵ
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
