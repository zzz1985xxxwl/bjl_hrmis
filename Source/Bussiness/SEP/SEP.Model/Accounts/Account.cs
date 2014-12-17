//----------------------------------------------------------------
// Copyright (C) 2000-2009 Shixin Corporation
// All rights reserved.
// �ļ���: Account.cs
// ������: colbert
// ��������: 2009-02-02
// ����: �˺�
// ----------------------------------------------------------------
using System;
using System.Collections.Generic;
using SEP.Model.Departments;
using SEP.Model.Positions;
using SEP.Model.Utility;

namespace SEP.Model.Accounts
{
    /// <summary>
    /// �˺�
    /// </summary>
    [Serializable]
    public class Account
    {
        public const int AdminPkid = -9;
        /// <summary>
        /// �˺�Ĭ������
        /// </summary>
        public const string DefaultPassword = "111111";

        #region

        private int _Id;
        private string _LoginName;
        private string _Password;
        private string _UsbKey;
        private VisibleType _AccountType;
        private List<Auth> _Auths;
        private string _Name;
        private string _MobileNum;
        private string _Email1;
        private string _Email2;
        private Department _Dept;
        private Position _Position;
        private bool _IsAcceptEmail;
        private bool _IsAcceptSMS;
        private bool _IsValidateUsbKey;
        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        public string LoginName
        {
            get
            {
                return _LoginName;
            }
            set
            {
                _LoginName = value;
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        public string UsbKey
        {
            get
            {
                return _UsbKey;
            }
            set
            {
                _UsbKey = value;
            }
        }
        public VisibleType AccountType
        {
            get
            {
                return _AccountType;
            }
            set
            {
                _AccountType = value;
            }
        }
        public int? GradesID{get;set;}

        public bool IsHRAccount
        {
            get
            {
                //return _AccountType == VisibleType.HRMis ||
                //       _AccountType == (VisibleType.HRMis | VisibleType.SEP) ||
                //       _AccountType == (VisibleType.HRMis | VisibleType.CRM) ||
                //       _AccountType == (VisibleType.HRMis | VisibleType.MyCMMI) ||
                //       _AccountType == (VisibleType.HRMis | VisibleType.SEP | VisibleType.MyCMMI) ||
                //       _AccountType == (VisibleType.HRMis | VisibleType.SEP | VisibleType.CRM) ||
                //       _AccountType == (VisibleType.HRMis | VisibleType.CRM | VisibleType.MyCMMI) ||
                //       _AccountType == (VisibleType.HRMis | VisibleType.CRM | VisibleType.MyCMMI | VisibleType.SEP)
                //       ;
                return (_AccountType & VisibleType.HRMis) == VisibleType.HRMis;
            }
        }
        public bool IsCRMAccount
        {
            get
            {
                //return _AccountType == VisibleType.CRM ||
                //       _AccountType == (VisibleType.CRM | VisibleType.SEP) ||
                //       _AccountType == (VisibleType.CRM | VisibleType.HRMis) ||
                //       _AccountType == (VisibleType.CRM | VisibleType.MyCMMI) ||
                //       _AccountType == (VisibleType.CRM | VisibleType.SEP | VisibleType.MyCMMI) ||
                //       _AccountType == (VisibleType.CRM | VisibleType.SEP | VisibleType.CRM) ||
                //       _AccountType == (VisibleType.CRM | VisibleType.HRMis | VisibleType.MyCMMI) ||
                //       _AccountType == (VisibleType.CRM | VisibleType.HRMis | VisibleType.MyCMMI | VisibleType.SEP)
                //       ;
                return (_AccountType & VisibleType.CRM) == VisibleType.CRM;
            }
        }
        public bool IsMyCMMIAccount
        {
            get
            {
                //return _AccountType == VisibleType.MyCMMI ||
                //       _AccountType == (VisibleType.MyCMMI | VisibleType.SEP) ||
                //       _AccountType == (VisibleType.MyCMMI | VisibleType.HRMis) ||
                //       _AccountType == (VisibleType.MyCMMI | VisibleType.CRM) ||
                //       _AccountType == (VisibleType.MyCMMI | VisibleType.SEP | VisibleType.MyCMMI) ||
                //       _AccountType == (VisibleType.MyCMMI | VisibleType.SEP | VisibleType.CRM) ||
                //       _AccountType == (VisibleType.MyCMMI | VisibleType.HRMis | VisibleType.CRM) ||
                //       _AccountType == (VisibleType.MyCMMI | VisibleType.HRMis | VisibleType.CRM | VisibleType.SEP)
                //       ;
                return (_AccountType & VisibleType.MyCMMI) == VisibleType.MyCMMI;
            }
        }

        public bool IsEShoppingAccount
        {
            get
            {
                //return _AccountType == VisibleType.MyCMMI ||
                //       _AccountType == (VisibleType.MyCMMI | VisibleType.SEP) ||
                //       _AccountType == (VisibleType.MyCMMI | VisibleType.HRMis) ||
                //       _AccountType == (VisibleType.MyCMMI | VisibleType.CRM) ||
                //       _AccountType == (VisibleType.MyCMMI | VisibleType.SEP | VisibleType.MyCMMI) ||
                //       _AccountType == (VisibleType.MyCMMI | VisibleType.SEP | VisibleType.CRM) ||
                //       _AccountType == (VisibleType.MyCMMI | VisibleType.HRMis | VisibleType.CRM) ||
                //       _AccountType == (VisibleType.MyCMMI | VisibleType.HRMis | VisibleType.CRM | VisibleType.SEP)
                //       ;
                return (_AccountType & VisibleType.EShopping) == VisibleType.EShopping;
            }
        }
        public List<Auth> Auths
        {
            get
            {
                return _Auths;
            }
            set
            {
                _Auths = value;
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        /// <summary>
        /// �ֻ�����
        /// </summary>
        public string MobileNum
        {
            get
            {
                return _MobileNum;
            }
            set
            {
                _MobileNum = value;
            }
        }
        public string Email1
        {
            get
            {
                return _Email1;
            }
            set
            {
                _Email1 = value;
            }
        }
        public string Email2
        {
            get
            {
                return _Email2;
            }
            set
            {
                _Email2 = value;
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        public Department Dept
        {
            get
            {
                return _Dept;
            }
            set
            {
                _Dept = value;
            }
        }
        /// <summary>
        /// ְλ
        /// </summary>
        public Position Position
        {
            get
            {
                return _Position;
            }
            set
            {
                _Position = value;
            }
        }
        /// <summary>
        /// �Ƿ����Email
        /// </summary>
        public bool IsAcceptEmail
        {
            get
            {
                return _IsAcceptEmail;
            }
            set
            {
                _IsAcceptEmail = value;
            }
        }
        /// <summary>
        /// �Ƿ���ն���Ϣ
        /// </summary>
        public bool IsAcceptSMS
        {
            get
            {
                return _IsAcceptSMS;
            }
            set
            {
                _IsAcceptSMS = value;
            }
        }
        /// <summary>
        /// �Ƿ���UsbKey��֤
        /// </summary>
        public bool IsValidateUsbKey
        {
            get
            {
                return _IsValidateUsbKey;
            }
            set
            {
                _IsValidateUsbKey = value;
            }
        }

        #endregion

        public Account()
        {
            _AccountType = VisibleType.SEP;
            _IsAcceptEmail = true;
            _IsAcceptSMS = true;
            _IsValidateUsbKey = false;
        }

        public Account(int id, string loginName, string name)
        {
            _Id = id;
            _LoginName = loginName;
            _Name = name;
            _AccountType = VisibleType.SEP;
            _IsAcceptEmail = true;
            _IsAcceptSMS = true;
            _IsValidateUsbKey = false;
        }

        public List<Auth> FindAuthsByType(AuthType type)
        {
            List<Auth> auths = new List<Auth>();
            foreach (Auth auth in _Auths)
            {
                if(auth.Type == type)
                    auths.Add(auth);
            }
            return auths;
        }

        public Auth FindAuth(AuthType type, int id)
        {
            foreach (Auth auth in _Auths)
            {
                if(auth.Type != type)
                    continue;

                Auth myAuth = auth.FindAuth(id);
                if(myAuth!= null)
                {
                    return myAuth;
                }
            }
            return null;
        }

        public bool IsHasAuth(AuthType type, int authID)
        {
            Auth auth = FindAuth(type, authID);
            if (auth == null)
            {
                return false;
            }
            return true;
        }

        public bool IsHasAuthOnDept(AuthType type, int authID, int deptID)
        {
            Auth auth = FindAuth(type, authID);
            if (auth == null || auth.Departments == null)
            {
                return false;
            }
            if (auth.Departments.Count == 0)
            {
                return true;
            }
            foreach (Department dept in auth.Departments)
            {
                if (dept.Id == deptID)
                {
                    return true;
                }
            }
            return false;
        }
    }

    [Flags]
    public enum VisibleType
    {
        /// <summary>
        /// ��Ч�û�
        /// </summary>
        None  = 0,

        /// <summary>
        /// ƽ̨�û�
        /// </summary>
        SEP    = 1,

        HRMis  = 2,
        CRM    = 4,
        MyCMMI = 8,
        EShopping = 16,
    }
}
