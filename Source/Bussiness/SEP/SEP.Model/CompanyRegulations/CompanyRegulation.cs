//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: CompanyRegulation.cs
// ������: colbert
// ��������: 2009-02-02
// ����: ��˾����
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace SEP.Model.CompanyRegulations
{
    [Serializable]
    public class CompanyRegulation
    {
        private int _CompanyRegulationsID;
        private ReguType _ReguType;
        private string _Title;
        private string _Content;

        private List<CompanyReguAppendix> _AppendixList;

        public CompanyRegulation(ReguType reguType)
        {
            _ReguType = reguType;
            _AppendixList = new List<CompanyReguAppendix>();
        }

        public CompanyRegulation(int companyReguId, ReguType reguType, string title, string content)
            : this(reguType)
        {
            _CompanyRegulationsID = companyReguId;
            _Title = title;
            _Content = content;
        }

        public int CompanyRegulationsID
        {
            get { return _CompanyRegulationsID; }
            set { _CompanyRegulationsID = value; }
        }

        public ReguType CompanyReguType
        {
            get { return _ReguType; }
            set { _ReguType = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        public List<CompanyReguAppendix> AppendixList
        {
            get { return _AppendixList; }
            set { _AppendixList = value; }
        }

        public CompanyReguAppendix FindAppendix(int appendixId)
        {
            foreach (CompanyReguAppendix appendix in _AppendixList)
            {
                if (appendix.AppendixID == appendixId)
                    return appendix;
            }
            return null;
        }

        public static List<KeyValuePair<int, string>> GetAllReguType()
        {
            List<KeyValuePair<int,string>> items = new List<KeyValuePair<int, string>>(6);

            items.Add(new KeyValuePair<int, string>((int)ReguType.NewEmployeeGuide,  "��Ա��ָ��"));
            items.Add(new KeyValuePair<int, string>((int)ReguType.RegulationProcess, "�ƶ�����"));
            items.Add(new KeyValuePair<int, string>((int)ReguType.Welfare,           "н�긣��"));
            items.Add(new KeyValuePair<int, string>((int)ReguType.Training,          "��ѵ��չ"));
            items.Add(new KeyValuePair<int, string>((int)ReguType.EffectAssess,      "��Ч����"));
            items.Add(new KeyValuePair<int, string>((int)ReguType.FAQS,              "FAQS"));

            return items;
        }
    }

    public enum ReguType
    {
        /// <summary>
        /// ��Ա��ָ��
        /// </summary>
        NewEmployeeGuide,

        /// <summary>
        /// �ƶ�����
        /// </summary>
        RegulationProcess,

        /// <summary>
        /// н�긣��
        /// </summary>
        Welfare,

        /// <summary>
        /// ��ѵ��չ
        /// </summary>
        Training,

        /// <summary>
        /// ��Ч����
        /// </summary>
        EffectAssess,

        /// <summary>
        /// FAQS
        /// </summary>
        FAQS
    }
}
