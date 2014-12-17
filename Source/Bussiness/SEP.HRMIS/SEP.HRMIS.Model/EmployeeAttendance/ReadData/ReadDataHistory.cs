//----------------------------------------------------------------
// Copyright (C) 2000-2007 Shixin Corporation
// All rights reserved.
// �ļ���: ReadDataHistory.cs
// ������: ����
// ��������: 2008-10-15
// ����: ��¼��ȡ����ʷ
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
        /// ��ȡ���ݼ�¼id
        /// </summary>
        public int ReadDataId
        {
            get { return _ReadDataId; }
            set { _ReadDataId = value; }
        }

        /// <summary>
        /// ��ȡ����ʱ��
        /// </summary>
        public DateTime ReadTime
        {
            get { return _ReadTime; }
            set { _ReadTime = value; }
        }

        /// <summary>
        /// ��ȡ���ݽṹ
        /// </summary>
        public ReadDataResultType ReadResult
        {
            get { return _ReadResult; }
            set { _ReadResult = value; }
        }

        ///<summary>
        /// ��ȡʧ�ܵ�ԭ��
        ///</summary>
        public string FailReason
        {
            get { return _FailReason; }
            set { _FailReason = value; }
        }
    }
}
