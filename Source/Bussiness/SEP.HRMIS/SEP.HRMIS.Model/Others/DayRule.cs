//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// �ļ���: DayRule.cs
// ������: �ߺ�
// ��������: 2008-05-20
// ����: ÿһ���ҵ�����,�����ж��ʱ��Σ�������Է�ʱ���Ϊ���硢����
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    [Serializable]
    public class DayRule
    {
        private string _Name;
        private List<TimeSegment> _TimeSegments = new List<TimeSegment>();

        public DayRule(string name,List<TimeSegment> timeSegments)
        {
            _Name = name;
            _TimeSegments = timeSegments;
        }

        public List<TimeSegment> TimeSegments
        {
            get { return _TimeSegments; }
            set { _TimeSegments = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}
