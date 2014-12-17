//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: SpecialDate.cs
// ������: yyb
// ��������: 2009-03-10
// ����: ��¼����Ĺ����ǹ���ʱ�����
// ----------------------------------------------------------------
using System;
namespace SEP.Model.SpecialDates
{
    [Serializable]
    public class SpecialDate
    {
        private int _SpecialDateID;
        private DateTime _SpecialDateTime;//��������
        private int _IsWork;//�Ƿ���,0��������1������2�����ڼ�
        private string _SpecialHeader;//˵��
        private string _SpecialDescription;//��ϸ˵��
        private string _SpecialForeColor;
        private string _SpecialBackColor;

        public SpecialDate()
        {
        }

        public SpecialDate(int specialDateID, DateTime specialDates, int isWork, string specialHeader,
            string specialDescription, string specialForeColor, string specialBackColor)
        {
            _SpecialDateID = specialDateID;
            _SpecialDateTime = specialDates;
            _IsWork = isWork;
            _SpecialHeader = specialHeader;
            _SpecialDescription = specialDescription;
            _SpecialForeColor = specialForeColor;
            _SpecialBackColor = specialBackColor;
        }

        /// <summary>
        /// ��������ID
        /// </summary>
        public int SpecialDateID
        {
            get
            {
                return _SpecialDateID;
            }
            set
            {
                _SpecialDateID = value;
            }
        }

        /// <summary>
        /// ��������,DateTime
        /// </summary>
        public DateTime SpecialDateTime
        {
            get
            {
                return _SpecialDateTime;
            }
            set
            {
                _SpecialDateTime = value;
            }
        }

        /// <summary>
        /// �Ƿ���,0��������1������2�����ڼ�
        /// </summary>
        public int IsWork
        {
            get
            {
                return _IsWork;
            }
            set
            {
                _IsWork = value;
            }
        }

        /// <summary>
        /// �����ؼ��ж���һ������ƣ��繤������Ϣ������ڣ������
        /// </summary>
        public string SpecialHeader
        {
            get
            {
                return _SpecialHeader;
            }
            set
            {
                _SpecialHeader = value;
            }
        }

        /// <summary>
        /// �����ؼ��ж���һ���������������ڷżٵ�
        /// </summary>
        public string SpecialDescription
        {
            get
            {
                return _SpecialDescription;
            }
            set
            {
                _SpecialDescription = value;
            }
        }

        /// <summary>
        /// �����ؼ��ж���һ���������ɫ���磺����Ϊ��ɫ����ϢΪ��ɫ
        /// </summary>
        public string SpecialForeColor
        {
            get
            {
                return _SpecialForeColor;
            }
            set
            {
                _SpecialForeColor = value;
            }
        }

        /// <summary>
        /// �����ؼ��ж���һ��ı�����ɫ���磺���칤�����򱳾�Ϊ��ɫ����Ϣ�򱳾�Ϊ��ɫ
        /// </summary>
        public string SpecialBackColor
        {
            get
            {
                return _SpecialBackColor;
            }
            set
            {
                _SpecialBackColor = value;
            }
        }

    }
}
