//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: CompanyRegulation.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 公司规章
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

            items.Add(new KeyValuePair<int, string>((int)ReguType.NewEmployeeGuide,  "新员工指南"));
            items.Add(new KeyValuePair<int, string>((int)ReguType.RegulationProcess, "制度流程"));
            items.Add(new KeyValuePair<int, string>((int)ReguType.Welfare,           "薪酬福利"));
            items.Add(new KeyValuePair<int, string>((int)ReguType.Training,          "培训发展"));
            items.Add(new KeyValuePair<int, string>((int)ReguType.EffectAssess,      "绩效考核"));
            items.Add(new KeyValuePair<int, string>((int)ReguType.FAQS,              "FAQS"));

            return items;
        }
    }

    public enum ReguType
    {
        /// <summary>
        /// 新员工指南
        /// </summary>
        NewEmployeeGuide,

        /// <summary>
        /// 制度流程
        /// </summary>
        RegulationProcess,

        /// <summary>
        /// 薪酬福利
        /// </summary>
        Welfare,

        /// <summary>
        /// 培训发展
        /// </summary>
        Training,

        /// <summary>
        /// 绩效考核
        /// </summary>
        EffectAssess,

        /// <summary>
        /// FAQS
        /// </summary>
        FAQS
    }
}
