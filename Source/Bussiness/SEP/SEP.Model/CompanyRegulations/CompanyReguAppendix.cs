//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// 文件名: CompanyReguAppendix.cs
// 创建者: colbert
// 创建日期: 2009-02-02
// 概述: 公司规章附件
// ----------------------------------------------------------------
using System;

namespace SEP.Model.CompanyRegulations
{
    [Serializable]
    public class CompanyReguAppendix
    {
        private int _appendixId;
        private int _companyReguId;
        private string _fileName;
        private string _directory;
        private DateTime _upLoadDate;


        public CompanyReguAppendix(int companyReguId, string fileName, string dir)
        {
            _companyReguId = companyReguId;
            _fileName = fileName;
            _directory = dir;
        }

        public CompanyReguAppendix(int appendixId, int companyReguId, string fileName, string dir, DateTime upLoadDate)
            : this(companyReguId, fileName, dir)
        {
            _appendixId = appendixId;
            _upLoadDate = upLoadDate;
        }

        public int AppendixID
        {
            get { return _appendixId; }
            set { _appendixId = value; }
        }

        public int CompanyReguID
        {
            get { return _companyReguId; }
            set { _companyReguId = value; }
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public string Directory
        {
            get { return _directory; }
            set { _directory = value; }
        }

        public DateTime UpLoadDate
        {
            get { return _upLoadDate; }
            set { _upLoadDate = value; }
        }
    }
}