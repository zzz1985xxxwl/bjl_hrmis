//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: ContractBookMark.cs
// ������: xue.wenlong
// ��������: 2008-11-19
// ����: ���ڼ�¼��ͬ����ǩ
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    /// <summary>
    /// ��ͬ����ǩ
    /// </summary>
    [Serializable]
    public class ContractBookMark
    {
        private int _PKID;
        private int _ContractTypeID;
        private string _BookMarkName;
        /// <summary>
        /// ��ͬ����ǩ
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
        /// ��ǩ���
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }
        /// <summary>
        /// ��ͬ����
        /// </summary>
        public int ContractTypeID
        {
            get { return _ContractTypeID; }
            set { _ContractTypeID = value; }
        }
        /// <summary>
        /// ��ǩ����
        /// </summary>
        public string BookMarkName
        {
            get { return _BookMarkName; }
            set { _BookMarkName = value; }
        }
    }
}
