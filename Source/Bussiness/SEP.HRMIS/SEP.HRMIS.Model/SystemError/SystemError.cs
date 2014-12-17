//----------------------------------------------------------------
// Copyright (C) 2000-2008 Shixin Corporation
// All rights reserved.
// FileName: SystemError.cs
// Creater:  Xue.wenlong
// Date:  2009-09-28
// Resume:
// ----------------------------------------------------------------

using ShiXin.Security;

namespace SEP.HRMIS.Model.SystemError
{
    /// <summary>
    /// </summary>
    public class SystemError
    {
        private int _PKID;
        private string _Description;
        private ErrorType _ErrorType;
        private int _MarkID;
        private ErrorStatus _ErrorStatus;
        private string _EditUrl;
        private Employee _Employee;
        /// <summary>
        /// 
        /// </summary>
        public SystemError(int pkid, string description, ErrorType errortype, int markID)
            : this(description, errortype, markID)
        {
            _PKID = pkid;
        }

        /// <summary>
        /// 
        /// </summary>
        public SystemError(string description, ErrorType errortype, int markID)
        {
            _Description = description;
            _ErrorType = errortype;
            _MarkID = markID;
        }

        /// <summary>
        /// 
        /// </summary>
        public int PKID
        {
            get { return _PKID; }
            set { _PKID = value; }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        /// <summary>
        /// 错误类型
        /// </summary>
        public ErrorType ErrorType
        {
            get { return _ErrorType; }
            set { _ErrorType = value; }
        }

        /// <summary>
        /// 标识ID，为AccoutID
        /// </summary>
        public int MarkID
        {
            get { return _MarkID; }
            set { _MarkID = value; }
        }

        /// <summary>
        /// 网页地址
        /// </summary>
        public string EditUrl
        {
            set { _EditUrl = value; }
            get
            {
                if (string.IsNullOrEmpty(_EditUrl))
                {
                    _EditUrl = string.Format("{0}{1}", _ErrorType.EditPageUrl, SecurityUtil.DECEncrypt(MarkID.ToString()));
                }
                return _EditUrl;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ErrorStatus ErrorStatus
        {
            get { return _ErrorStatus; }
            set { _ErrorStatus = value; }
        }

        public Employee ErrorEmployee
        {
            get { return _Employee; }
            set { _Employee = value; }
        }
    }
}