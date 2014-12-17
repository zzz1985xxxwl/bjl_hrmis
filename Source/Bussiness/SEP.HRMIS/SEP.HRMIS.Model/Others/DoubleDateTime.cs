//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DoubleDateTime.cs
// ������: �ߺ�
// ��������: 2008-05-20
// ����: ������2��ʱ��㣬����8:30~9:00����һ��DoubleTimeʵ��
// ----------------------------------------------------------------

using System;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class DoubleDateTime
    {
        private string _VaildStartTime;
        private string _VaildEndTime;

        public DoubleDateTime(string vaildStartTime, string vaildEndTime)
        {
            _VaildStartTime = vaildStartTime;
            _VaildEndTime = vaildEndTime;
        }

        public string VaildStartTime
        {
            get { return _VaildStartTime; }
            set { _VaildStartTime = value; }
        }

        public string VaildEndTime
        {
            get { return _VaildEndTime; }
            set { _VaildEndTime = value; }
        }
    }
}
